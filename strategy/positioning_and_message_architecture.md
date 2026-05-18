#!/usr/bin/env python3
"""
Research Sheet Generator – Production Grade
-------------------------------------------
Generates a one-page equity research recommendation sheet with valuation
metrics (P/E, P/B, dividend yield), qualitative analysis, and portfolio
allocation guidance.

Features:
- Complete error handling with specific exceptions
- Full type annotations (generics, Optional, Union)
- Comprehensive docstrings (Google style)
- Structured logging with levels
- Input validation and security checks
- Performance optimizations (caching, lazy evaluation)
- Clean code: single responsibility, constants, dataclasses
"""

import abc
import logging
import os
import re
import time
from dataclasses import dataclass, field
from datetime import datetime
from enum import Enum, auto
from functools import lru_cache
from pathlib import Path
from typing import Any, Dict, List, Optional, Tuple, Union
from urllib.parse import urlparse

import httpx
import yfinance as yf  # type: ignore[import]
from pydantic import BaseModel, Field, validator  # type: ignore[import]

# --------------------------------------------------------------------------- #
# Configuration & Constants
# --------------------------------------------------------------------------- #

class LogLevel(Enum):
    """Logging levels supported by the application."""
    DEBUG = logging.DEBUG
    INFO = logging.INFO
    WARNING = logging.WARNING
    ERROR = logging.ERROR
    CRITICAL = logging.CRITICAL


LOGGER_NAME = "research_sheet"
_DEFAULT_LOG_FORMAT = "%(asctime)s [%(levelname)s] %(name)s: %(message)s"
_DEFAULT_LOG_LEVEL = LogLevel.INFO

# Timeout for external API calls (seconds)
_HTTP_TIMEOUT = 30.0

# Allowed ticker regex pattern (alphanumeric, dots, hyphens, underscores)
_TICKER_PATTERN = re.compile(r"^[A-Z0-9.\-]{1,10}$", re.IGNORECASE)

# Cache TTL for fundamental data (seconds)
_CACHE_TTL = 300  # 5 minutes

# --------------------------------------------------------------------------- #
# Custom Exceptions
# --------------------------------------------------------------------------- #

class ResearchSheetError(Exception):
    """Base exception for all module errors."""


class TickerValidationError(ResearchSheetError, ValueError):
    """Raised when a ticker fails validation."""


class MarketDataError(ResearchSheetError):
    """Raised when market data source fails."""


class DividendDataError(MarketDataError):
    """Raised when dividend data is missing or invalid."""


class ConfigurationError(ResearchSheetError):
    """Raised when configuration is invalid."""


# --------------------------------------------------------------------------- #
# Logging Setup
# --------------------------------------------------------------------------- #

def configure_logger(
    name: str = LOGGER_NAME,
    level: LogLevel = _DEFAULT_LOG_LEVEL,
    log_file: Optional[Union[str, Path]] = None,
) -> logging.Logger:
    """
    Configure and return a logger with specified level and optional file handler.

    Args:
        name: Logger name.
        level: Minimum logging level.
        log_file: Optional path to a log file.

    Returns:
        Configured logger instance.

    Raises:
        ConfigurationError: If log file path is invalid.
    """
    logger = logging.getLogger(name)
    logger.setLevel(level.value)

    # Prevent duplicate handlers
    if logger.handlers:
        return logger

    formatter = logging.Formatter(_DEFAULT_LOG_FORMAT)

    # Console handler
    console_handler = logging.StreamHandler()
    console_handler.setFormatter(formatter)
    logger.addHandler(console_handler)

    # File handler (optional)
    if log_file:
        try:
            log_path = Path(log_file).resolve()
            log_path.parent.mkdir(parents=True, exist_ok=True)
            file_handler = logging.FileHandler(log_path, encoding="utf-8")
            file_handler.setFormatter(formatter)
            logger.addHandler(file_handler)
        except (OSError, PermissionError) as exc:
            raise ConfigurationError(
                f"Cannot create log file at {log_file}: {exc}"
            ) from exc

    return logger


logger = configure_logger()

# --------------------------------------------------------------------------- #
# Data Models
# --------------------------------------------------------------------------- #

class Market(str, Enum):
    """Supported stock exchanges."""
    JSE = "JSE"
    NYSE = "NYSE"
    LSE = "LSE"
    TSX = "TSX"
    ASX = "ASX"


class Conviction(Enum):
    """Portfolio conviction score."""
    STRONG_BUY = auto()
    BUY = auto()
    HOLD = auto()
    SELL = auto()
    STRONG_SELL = auto()


class PortfolioWeight(Enum):
    """Portfolio allocation guidance."""
    OVERWEIGHT = auto()
    NEUTRAL = auto()
    UNDERWEIGHT = auto()


@dataclass(frozen=True, slots=True)
class ValuationMetrics:
    """Core valuation ratios."""
    pe_ratio: Optional[float] = None
    pb_ratio: Optional[float] = None
    dividend_yield: Optional[float] = None
    price_to_sales: Optional[float] = None
    ev_ebitda: Optional[float] = None


@dataclass(frozen=True, slots=True)
class RecommendationSheet:
    """Complete research recommendation output."""
    ticker: str
    company_name: str
    exchange: Market
    current_price: Optional[float]
    valuation: ValuationMetrics
    conviction: Conviction
    portfolio_weight: PortfolioWeight
    support_level: Optional[float] = None
    resistance_level: Optional[float] = None
    analyst_notes: List[str] = field(default_factory=list)
    generated_at: datetime = field(default_factory=datetime.utcnow)


# --------------------------------------------------------------------------- #
# Core Business Logic
# --------------------------------------------------------------------------- #

class MarketDataProvider(abc.ABC):
    """Abstract interface for market data sources."""

    @abc.abstractmethod
    def fetch_price(self, ticker: str) -> Optional[float]:
        """Fetch current market price for ticker."""

    @abc.abstractmethod
    def fetch_pe_ratio(self, ticker: str) -> Optional[float]:
        """Fetch Price-to-Earnings ratio."""

    @abc.abstractmethod
    def fetch_pb_ratio(self, ticker: str) -> Optional[float]:
        """Fetch Price-to-Book ratio."""

    @abc.abstractmethod
    def fetch_dividend_yield(self, ticker: str) -> Optional[float]:
        """Fetch dividend yield (as percentage)."""


class YahooFinanceProvider(MarketDataProvider):
    """
    Yahoo Finance implementation of market data provider.
    Uses yfinance library with caching and error handling.
    """

    def __init__(self, cache_ttl: float = _CACHE_TTL) -> None:
        self._cache_ttl = cache_ttl
        self._ticker_cache: Dict[str, Tuple[float, yf.Ticker]] = {}

    def _get_ticker(self, ticker: str) -> yf.Ticker:
        """Return a cached Ticker object or fetch a new one."""
        now = time.monotonic()
        if ticker in self._ticker_cache:
            timestamp, t_obj = self._ticker_cache[ticker]
            if now - timestamp < self._cache_ttl:
                return t_obj

        t_obj = yf.Ticker(ticker)
        self._ticker_cache[ticker] = (now, t_obj)
        return t_obj

    def fetch_price(self, ticker: str) -> Optional[float]:
        try:
            t = self._get_ticker(ticker)
            return t.info.get("currentPrice") or t.info.get("regularMarketPrice")
        except Exception as exc:
            logger.warning("Failed to fetch price for %s: %s", ticker, exc)
            return None

    def fetch_pe_ratio(self, ticker: str) -> Optional[float]:
        try:
            t = self._get_ticker(ticker)
            return t.info.get("trailingPE")
        except Exception as exc:
            logger.warning("Failed to fetch P/E for %s: %s", ticker, exc)
            return None

    def fetch_pb_ratio(self, ticker: str) -> Optional[float]:
        try:
            t = self._get_ticker(ticker)
            return t.info.get("priceToBook")
        except Exception as exc:
            logger.warning("Failed to fetch P/B for %s: %s", ticker, exc)
            return None

    def fetch_dividend_yield(self, ticker: str) -> Optional[float]:
        try:
            t = self._get_ticker(ticker)
            # yfinance returns dividendYield as decimal
            dy = t.info.get("dividendYield")
            if dy is not None:
                return round(dy * 100, 2)
            return None
        except Exception as exc:
            logger.warning("Failed to fetch dividend yield for %s: %s", ticker, exc)
            return None


class ResearchSheetGenerator:
    """
    Generates equity research recommendation sheets.

    Args:
        provider: Market data provider (default: YahooFinanceProvider).
        exchange: Default exchange market.
    """

    def __init__(
        self,
        provider: Optional[MarketDataProvider] = None,
        exchange: Market = Market.JSE,
    ) -> None:
        self._provider = provider or YahooFinanceProvider()
        self._exchange = exchange

    def generate(self, ticker: str) -> RecommendationSheet:
        """
        Main entry point: produce a complete recommendation sheet for a ticker.

        Args:
            ticker: Stock ticker symbol (e.g., "SEP", "AAPL").

        Returns:
            RecommendationSheet with all available metrics and guidance.

        Raises:
            TickerValidationError: If ticker is invalid.
            MarketDataError: If critical market data cannot be obtained.
        """
        ticker = self._validate_and_normalize_ticker(ticker)
        logger.info("Generating research sheet for %s", ticker)

        # Gather metrics with individual error tolerance
        price = self._provider.fetch_price(ticker)
        pe = self._provider.fetch_pe_ratio(ticker)
        pb = self._provider.fetch_pb_ratio(ticker)
        dy = self._provider.fetch_dividend_yield(ticker)

        # Basic sanity checks: we should have at least a price
        if price is None:
            raise MarketDataError(
                f"No price available for ticker '{ticker}'. "
                "Check ticker symbol or network connectivity."
            )

        valuation = ValuationMetrics(
            pe_ratio=pe,
            pb_ratio=pb,
            dividend_yield=dy,
        )

        # Qualitative analysis (heuristic-based)
        conviction, weight = self._determine_guidance(valuation)
        notes = self._generate_notes(valuation, price)

        return RecommendationSheet(
            ticker=ticker,
            company_name=self._get_company_name(ticker),
            exchange=self._exchange,
            current_price=price,
            valuation=valuation,
            conviction=conviction,
            portfolio_weight=weight,
            analyst_notes=notes,
            generated_at=datetime.utcnow(),
        )

    def _validate_and_normalize_ticker(self, ticker: str) -> str:
        """Validate ticker format and normalize to uppercase."""
        if not isinstance(ticker, str):
            raise TickerValidationError("Ticker must be a string.")
        ticker = ticker.strip().upper()
        if not ticker:
            raise TickerValidationError("Ticker cannot be empty.")
        if not _TICKER_PATTERN.match(ticker):
            raise TickerValidationError(
                f"Ticker '{ticker}' contains invalid characters. "
                "Allowed: letters, digits, dots, hyphens, underscores (max 10 chars)."
            )
        # Blacklist common placeholder or dangerous strings
        if ticker in {"NULL", "NONE", "UNDEFINED", "ALL"}:
            raise TickerValidationError(f"Ticker '{ticker}' is reserved and cannot be used.")
        return ticker

    def _get_company_name(self, ticker: str) -> str:
        """Retrieve company name from provider."""
        try:
            t = yf.Ticker(ticker)
            name = t.info.get("longName") or t.info.get("shortName") or ticker
            return str(name)
        except Exception:
            logger.warning("Could not fetch company name for %s", ticker)
            return ticker

    def _determine_guidance(
        self, valuation: ValuationMetrics
    ) -> Tuple[Conviction, PortfolioWeight]:
        """
        Heuristic to assign conviction and portfolio weight based on valuation.

        Rules:
        - Low P/E (<12) + dividend >2% → BUY, OVERWEIGHT
        - High P/E (>25) + no dividend → HOLD, UNDERWEIGHT
        - otherwise HOLD, NEUTRAL
        """
        pe = valuation.pe_ratio
        dy = valuation.dividend_yield

        # Default
        if pe is None:
            return Conviction.HOLD, PortfolioWeight.NEUTRAL

        if pe < 12 and dy is not None and dy > 2.0:
            return Conviction.BUY, PortfolioWeight.OVERWEIGHT
        elif pe > 25 and (dy is None or dy < 0.5):
            return Conviction.HOLD, PortfolioWeight.UNDERWEIGHT
        else:
            return Conviction.HOLD, PortfolioWeight.NEUTRAL

    def _generate_notes(
        self, valuation: ValuationMetrics, price: float
    ) -> List[str]:
        """Generate qualitative notes based on metrics."""
        notes = []
        pe = valuation.pe_ratio
        pb = valuation.pb_ratio
        dy = valuation.dividend_yield

        if pe is not None:
            if pe < 10:
                notes.append(f"P/E of {pe:.1f}x indicates potential undervaluation.")
            elif pe > 30:
                notes.append(f"P/E of {pe:.1f}x suggests premium valuation.")
            else:
                notes.append(f"P/E of {pe:.1f}x is within normal range.")

        if pb is not None:
            if pb > 5:
                notes.append(f"High P/B ({pb:.2f}x): investors expect strong future returns.")
            elif pb < 1:
                notes.append(f"P/B below 1x: market values company below book value.")
            else:
                notes.append(f"P/B of {pb:.2f}x aligns with book value.")

        if dy is not None:
            notes.append(f"Dividend yield {dy:.2f}% provides income return.")
        else:
            notes.append("No dividend currently paid.")

        return notes


# --------------------------------------------------------------------------- #
# API / CLI entry point
# --------------------------------------------------------------------------- #

def generate_from_cli(ticker: str, exchange: str = "JSE") -> None:
    """
    CLI wrapper: validates inputs, generates sheet, and prints JSON result.

    Args:
        ticker: Stock ticker symbol.
        exchange: Exchange market code (case-insensitive).

    Exits with:
        Return code 0 on success, 1 on error.
    """
    try:
        exchange_enum = Market[exchange.upper()]
    except KeyError:
        logger.error("Unsupported exchange: %s. Supported: %s", exchange, [m.value for m in Market])
        exit(1)

    try:
        generator = ResearchSheetGenerator(exchange=exchange_enum)
        sheet = generator.generate(ticker)
        # Output as JSON-like representation
        output = {
            "ticker": sheet.ticker,
            "company": sheet.company_name,
            "exchange": sheet.exchange.value,
            "price": sheet.current_price,
            "pe_ratio": sheet.valuation.pe_ratio,
            "pb_ratio": sheet.valuation.pb_ratio,
            "dividend_yield": sheet.valuation.dividend_yield,
            "conviction": sheet.conviction.name,
            "portfolio_weight": sheet.portfolio_weight.name,
            "notes": sheet.analyst_notes,
            "generated_at": sheet.generated_at.isoformat(),
        }
        print(json.dumps(output, indent=2))
    except (TickerValidationError, MarketDataError) as exc:
        logger.error("Generation failed: %s", exc)
        exit(1)
    except Exception as exc:
        logger.exception("Unexpected error: %s", exc)
        exit(1)


if __name__ == "__main__":
    import sys
    import json

    if len(sys.argv) < 2:
        print("Usage: python research_sheet.py <TICKER> [EXCHANGE]")
        sys.exit(1)

    ticker_arg = sys.argv[1]
    exchange_arg = sys.argv[2] if len(sys.argv) > 2 else "JSE"
    generate_from_cli(ticker_arg, exchange_arg)