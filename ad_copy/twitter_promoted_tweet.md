package main

import (
	"context"
	"encoding/json"
	"fmt"
	"io"
	"log/slog"
	"net/http"
	"os"
	"strings"
	"time"
)

// ---------- Types and Interfaces ----------

// StockData holds all fundamental metrics for a single stock.
type StockData struct {
	Ticker       string  `json:"ticker"`
	Price        float64 `json:"price"`
	EPS          float64 `json:"eps"`
	BookValue    float64 `json:"book_value"`
	Dividend     float64 `json:"dividend_per_share"`
	PE           float64 `json:"pe_ratio"`
	PB           float64 `json:"pb_ratio"`
	DividendYield float64 `json:"dividend_yield"`
}

// Recommendation holds the final analysis output.
type Recommendation struct {
	StockData
	Recommendation string `json:"recommendation"`
	Reason         string `json:"reason"`
}

// StockDataSource defines the interface for fetching stock data.
type StockDataSource interface {
	FetchStockData(ctx context.Context, ticker string) (*StockData, error)
}

// StockAnalyzer applies portfolio logic and generates recommendations.
type StockAnalyzer struct {
	source StockDataSource
	logger *slog.Logger
}

// NewStockAnalyzer creates a new analyzer with a given data source.
func NewStockAnalyzer(source StockDataSource, logger *slog.Logger) *StockAnalyzer {
	if logger == nil {
		logger = slog.Default()
	}
	return &StockAnalyzer{
		source: source,
		logger: logger,
	}
}

// Analyze computes valuation metrics and generates a recommendation.
func (a *StockAnalyzer) Analyze(ctx context.Context, ticker string) (*Recommendation, error) {
	if err := validateTicker(ticker); err != nil {
		a.logger.ErrorContext(ctx, "invalid ticker", "ticker", ticker, "error", err)
		return nil, fmt.Errorf("validate ticker: %w", err)
	}

	data, err := a.source.FetchStockData(ctx, ticker)
	if err != nil {
		a.logger.ErrorContext(ctx, "failed to fetch stock data", "ticker", ticker, "error", err)
		return nil, fmt.Errorf("fetch stock data: %w", err)
	}

	rec := &Recommendation{
		StockData: *data,
	}
	rec.PE = computePE(data.Price, data.EPS)
	rec.PB = computePB(data.Price, data.BookValue)
	rec.DividendYield = computeDividendYield(data.Dividend, data.Price)

	rec.Recommendation, rec.Reason = generateCall(rec.PE, rec.PB, rec.DividendYield)

	a.logger.InfoContext(ctx, "analysis complete", "ticker", ticker, "pe", rec.PE, "pb", rec.PB, "yield", rec.DividendYield)
	return rec, nil
}

// ---------- Input Validation ----------

func validateTicker(ticker string) error {
	ticker = strings.TrimSpace(ticker)
	if len(ticker) == 0 {
		return fmt.Errorf("ticker cannot be empty")
	}
	if len(ticker) > 5 {
		return fmt.Errorf("ticker length too long (max 5 characters)")
	}
	for _, r := range ticker {
		if !((r >= 'A' && r <= 'Z') || (r >= 'a' && r <= 'z')) {
			return fmt.Errorf("ticker must contain only alphabetic characters")
		}
	}
	return nil
}

// ---------- Metric Calculations ----------

func computePE(price, eps float64) float64 {
	if eps <= 0 {
		return 0 // avoid division by zero or negative P/E for simplicity
	}
	return price / eps
}

func computePB(price, bookValue float64) float64 {
	if bookValue <= 0 {
		return 0
	}
	return price / bookValue
}

func computeDividendYield(dividend, price float64) float64 {
	if price <= 0 {
		return 0
	}
	return (dividend / price) * 100.0
}

// generateCall returns an Overweight/Underweight recommendation based on simple thresholds.
func generateCall(pe, pb, yield float64) (string, string) {
	score := 0
	if pe > 0 && pe < 15 {
		score++
	}
	if pb > 0 && pb < 2 {
		score++
	}
	if yield > 3.0 {
		score++
	}
	if score >= 2 {
		return "Overweight", fmt.Sprintf("Attractive valuation: P/E=%.2f, P/B=%.2f, Yield=%.2f%%", pe, pb, yield)
	}
	return "Underweight", fmt.Sprintf("Less attractive: P/E=%.2f, P/B=%.2f, Yield=%.2f%%", pe, pb, yield)
}

// ---------- Data Source Implementations ----------

// MockStockDataSource provides hardcoded data for demonstration. In production, replace with actual API client.
type MockStockDataSource struct {
	logger *slog.Logger
}

func (m *MockStockDataSource) FetchStockData(ctx context.Context, ticker string) (*StockData, error) {
	// Simulate network delay
	time.Sleep(50 * time.Millisecond)

	// Example data (would come from JSE API or file)
	ticker = strings.ToUpper(ticker)
	switch ticker {
	case "SEP":
		return &StockData{
			Ticker:    "SEP",
			Price:     81.73,
			EPS:       6.08,
			BookValue: 45.00,
			Dividend:  1.20,
		}, nil
	case "TJH":
		return &StockData{
			Ticker:    "TJH",
			Price:     150.00,
			EPS:       8.50,
			BookValue: 23.20,
			Dividend:  5.60,
		}, nil
	case "CCC":
		return &StockData{
			Ticker:    "CCC",
			Price:     120.00,
			EPS:       9.28,
			BookValue: 40.00,
			Dividend:  2.50,
		}, nil
	default:
		return nil, fmt.Errorf("ticker %s not found", ticker)
	}
}

// ---------- Output Formatting ----------

func (r *Recommendation) String() string {
	return fmt.Sprintf(`📊 JSE Equity Research Sheet – %s
━━━━━━━━━━━━━━━━━━━━━━━━━━
Price:      $%.2f
P/E:       %.2f
P/B:       %.2f
Dividend:  %.2f%%
Recommendation: %s
Reason: %s
`, r.Ticker, r.Price, r.PE, r.PB, r.DividendYield, r.Recommendation, r.Reason)
}

// ---------- Configuration and Dependency Injection ----------

// Config holds application settings.
type Config struct {
	LogLevel string `json:"log_level"`
	Port     int    `json:"port"`
}

// LoadConfig reads configuration from environment or file.
func LoadConfig() *Config {
	level := os.Getenv("LOG_LEVEL")
	if level == "" {
		level = "info"
	}
	return &Config{
		LogLevel: level,
	}
}

// SetupLogger configures the structured logger.
func SetupLogger(level string) *slog.Logger {
	var l slog.Level
	switch strings.ToLower(level) {
	case "debug":
		l = slog.LevelDebug
	case "warn":
		l = slog.LevelWarn
	case "error":
		l = slog.LevelError
	default:
		l = slog.LevelInfo
	}
	opts := &slog.HandlerOptions{Level: l}
	return slog.New(slog.NewJSONHandler(os.Stdout, opts))
}

// ---------- CLI / HTTP Handlers ----------

// handleAnalyze is an HTTP handler for /analyze?ticker=SEP.
func handleAnalyze(analyzer *StockAnalyzer) http.HandlerFunc {
	return func(w http.ResponseWriter, r *http.Request) {
		if r.Method != http.MethodGet {
			http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
			return
		}
		ticker := strings.TrimSpace(r.URL.Query().Get("ticker"))
		if ticker == "" {
			http.Error(w, "ticker query parameter required", http.StatusBadRequest)
			return
		}

		ctx, cancel := context.WithTimeout(r.Context(), 5*time.Second)
		defer cancel()

		rec, err := analyzer.Analyze(ctx, ticker)
		if err != nil {
			slog.ErrorContext(ctx, "analysis failed", "ticker", ticker, "error", err)
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		w.Header().Set("Content-Type", "application/json")
		json.NewEncoder(w).Encode(rec)
	}
}

// ---------- Main ----------

func main() {
	cfg := LoadConfig()
	logger := SetupLogger(cfg.LogLevel)
	slog.SetDefault(logger) // set as global default

	source := &MockStockDataSource{logger: logger}
	analyzer := NewStockAnalyzer(source, logger)

	// Example CLI usage
	rec, err := analyzer.Analyze(context.Background(), "SEP")
	if err != nil {
		logger.Error("analysis failed", "error", err)
		os.Exit(1)
	}
	fmt.Print(rec.String())

	// Start an HTTP server for integration
	http.HandleFunc("/analyze", handleAnalyze(analyzer))
	port := "8080"
	if cfg.Port != 0 {
		port = fmt.Sprintf("%d", cfg.Port)
	}
	server := &http.Server{
		Addr:         ":" + port,
		Handler:      http.DefaultServeMux,
		ReadTimeout:  10 * time.Second,
		WriteTimeout: 10 * time.Second,
	}
	logger.Info("starting server", "port", port)
	if err := server.ListenAndServe(); err != nil && err != http.ErrServerClosed {
		logger.Error("server failed", "error", err)
		os.Exit(1)
	}
}

// Ensure io is used (for future network calls)
var _ = io.Discard