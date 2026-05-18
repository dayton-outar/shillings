package main

import (
	"context"
	"encoding/json"
	"errors"
	"fmt"
	"io"
	"log/slog"
	"math"
	"os"
	"strings"
	"time"
)

// ---------------------------------------------------------------------------
// Core domain types
// ---------------------------------------------------------------------------

// StockTicker represents a unique stock symbol on the Jamaica Stock Exchange.
type StockTicker string

// StockRecommendation defines the investment action for a stock.
type StockRecommendation int

const (
	RecommendBuy  StockRecommendation = iota + 1 // Buy – attractive valuation
	RecommendHold                                 // Hold – fair valuation
	RecommendSell                                 // Sell – overvalued
)

// String returns a human-readable representation of the recommendation.
func (r StockRecommendation) String() string {
	switch r {
	case RecommendBuy:
		return "BUY"
	case RecommendHold:
		return "HOLD"
	case RecommendSell:
		return "SELL"
	default:
		return "UNKNOWN"
	}
}

// StockData contains all fundamental data required for the recommendation.
type StockData struct {
	Ticker       StockTicker `json:"ticker"`
	Price        float64     `json:"price"`         // Current share price in JMD
	EPS          float64     `json:"eps"`           // Earnings per share (LTM)
	BookValue    float64     `json:"book_value"`    // Book value per share
	Dividend     float64     `json:"dividend"`      // Annual dividend per share
	Industry     string      `json:"industry"`      // Optional industry grouping
	LastUpdated  time.Time   `json:"last_updated"`
}

// StockMetrics holds the calculated P/E, P/B, Dividend Yield and a rating.
type StockMetrics struct {
	Ticker           StockTicker         `json:"ticker"`
	PE               float64             `json:"pe_ratio"`
	PB               float64             `json:"pb_ratio"`
	DividendYield    float64             `json:"dividend_yield"` // as decimal, e.g. 0.0373
	Recommendation   StockRecommendation `json:"recommendation"`
	AllocationWeight float64             `json:"allocation_weight"` // fractional weight (0.0–1.0)
}

// Validation errors for input data.
var (
	ErrInvalidPrice     = errors.New("price must be positive")
	ErrInvalidEPS       = errors.New("EPS must be positive")
	ErrInvalidBookValue = errors.New("book value must be positive")
	ErrInvalidDividend  = errors.New("dividend must be non-negative")
	ErrEmptyTicker      = errors.New("ticker cannot be empty")
)

// Validate checks all fields of StockData for consistency.
func (s StockData) Validate() error {
	if strings.TrimSpace(string(s.Ticker)) == "" {
		return ErrEmptyTicker
	}
	if s.Price <= 0 {
		return fmt.Errorf("%w: %.2f", ErrInvalidPrice, s.Price)
	}
	if s.EPS <= 0 {
		return fmt.Errorf("%w: %.2f", ErrInvalidEPS, s.EPS)
	}
	if s.BookValue <= 0 {
		return fmt.Errorf("%w: %.2f", ErrInvalidBookValue, s.BookValue)
	}
	if s.Dividend < 0 {
		return fmt.Errorf("%w: %.2f", ErrInvalidDividend, s.Dividend)
	}
	return nil
}

// ---------------------------------------------------------------------------
// Analysis engine – single responsibility: compute metrics
// ---------------------------------------------------------------------------

// Analyser defines the contract for deriving StockMetrics from raw StockData.
type Analyser interface {
	Analyse(ctx context.Context, data StockData) (StockMetrics, error)
	AnalyseMany(ctx context.Context, data []StockData) ([]StockMetrics, error)
}

// defaultAnalyser implements a simple rule‑based recommendation.
type defaultAnalyser struct {
	logger *slog.Logger
}

// NewAnalyser creates a new Analyser with an optional logger.
func NewAnalyser(logger *slog.Logger) Analyser {
	if logger == nil {
		logger = slog.New(slog.NewTextHandler(io.Discard, nil)) // silent by default
	}
	return &defaultAnalyser{logger: logger}
}

// Analyse computes P/E, P/B, Dividend Yield and a basic Buy/Hold/Sell rating.
func (a *defaultAnalyser) Analyse(ctx context.Context, data StockData) (StockMetrics, error) {
	if err := data.Validate(); err != nil {
		return StockMetrics{}, fmt.Errorf("validate stock data: %w", err)
	}

	pe := data.Price / data.EPS
	pb := data.Price / data.BookValue
	divYield := data.Dividend / data.Price

	// Simple rule: buy if P/E < 15 and P/B < 1.5, sell if P/E > 25 and P/B > 3, else hold.
	var rec StockRecommendation
	switch {
	case pe < 15 && pb < 1.5:
		rec = RecommendBuy
	case pe > 25 && pb > 3:
		rec = RecommendSell
	default:
		rec = RecommendHold
	}

	// Allocation weight inversely proportional to P/E (naïve diversification).
	weight := math.Round((1.0/pe)*1000) / 1000 // keep it small

	return StockMetrics{
		Ticker:           data.Ticker,
		PE:               math.Round(pe*100) / 100,
		PB:               math.Round(pb*100) / 100,
		DividendYield:    math.Round(divYield*10000) / 10000,
		Recommendation:   rec,
		AllocationWeight: weight,
	}, nil
}

// AnalyseMany processes a slice of StockData concurrently.
func (a *defaultAnalyser) AnalyseMany(ctx context.Context, data []StockData) ([]StockMetrics, error) {
	if len(data) == 0 {
		return nil, errors.New("no stock data provided")
	}

	results := make([]StockMetrics, len(data))
	errCh := make(chan error, len(data))

	for i, d := range data {
		i, d := i, d // capture for goroutine
		go func() {
			select {
			case <-ctx.Done():
				errCh <- ctx.Err()
				return
			default:
			}
			metrics, err := a.Analyse(ctx, d)
			if err != nil {
				errCh <- fmt.Errorf("analyse %s: %w", d.Ticker, err)
				return
			}
			results[i] = metrics
			errCh <- nil
		}()
	}

	// Collect errors and wait for all goroutines.
	var errs []error
	for i := 0; i < len(data); i++ {
		if err := <-errCh; err != nil {
			errs = append(errs, err)
		}
	}
	close(errCh)

	if len(errs) > 0 {
		return results, errors.Join(errs...)
	}
	return results, nil
}

// ---------------------------------------------------------------------------
// Output formatter – produces the recommendation sheet in JSON (or could be table)
// ---------------------------------------------------------------------------

// Formatter renders StockMetrics into a final output.
type Formatter interface {
	Format(ctx context.Context, metrics []StockMetrics) (string, error)
}

// JSONFormatter writes a JSON array.
type JSONFormatter struct {
	indent string
}

// NewJSONFormatter creates a formatter with optional indentation.
func NewJSONFormatter(indent string) *JSONFormatter {
	if indent == "" {
		indent = "  "
	}
	return &JSONFormatter{indent: indent}
}

// Format serialises metrics as pretty JSON.
func (f *JSONFormatter) Format(ctx context.Context, metrics []StockMetrics) (string, error) {
	if len(metrics) == 0 {
		return "", errors.New("empty metrics slice")
	}
	b, err := json.MarshalIndent(metrics, "", f.indent)
	if err != nil {
		return "", fmt.Errorf("marshal metrics: %w", err)
	}
	return string(b), nil
}

// ---------------------------------------------------------------------------
// Command‑line interface (simple demo)
// ---------------------------------------------------------------------------

func main() {
	// Use structured logging with context.
	logger := slog.New(slog.NewJSONHandler(os.Stderr, &slog.HandlerOptions{Level: slog.LevelInfo}))
	slog.SetDefault(logger)

	// Sample dataset (replace with real data source in production).
	stocks := []StockData{
		{Ticker: "SEP", Price: 81.73, EPS: 6.07, BookValue: 55.20, Dividend: 1.50, LastUpdated: time.Now()},
		{Ticker: "TJH", Price: 45.00, EPS: 8.50, BookValue: 6.96, Dividend: 1.68, LastUpdated: time.Now()},
		{Ticker: "CCC", Price: 78.50, EPS: 6.07, BookValue: 29.30, Dividend: 0.80, LastUpdated: time.Now()},
	}

	ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()

	analyser := NewAnalyser(logger)
	formatter := NewJSONFormatter("  ")

	metrics, err := analyser.AnalyseMany(ctx, stocks)
	if err != nil {
		slog.Error("analysis failed", "error", err)
		os.Exit(1)
	}

	output, err := formatter.Format(ctx, metrics)
	if err != nil {
		slog.Error("formatting failed", "error", err)
		os.Exit(1)
	}

	fmt.Println(output)
}