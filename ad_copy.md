#!/usr/bin/env python3
"""
Portfolio Insight Campaign – Ad Copy Module

This module provides a production‑ready, type‑safe representation of the ad copy
for a Jamaican wealth management firm’s newsletter subscription campaign.
It includes validation, logging, and clean separation of concerns.
"""

from __future__ import annotations

import enum
import logging
import re
from dataclasses import dataclass, field
from typing import Dict, Final, List, Optional, Sequence, Set, Tuple

# ---------------------------------------------------------------------------
# Logging configuration
# ---------------------------------------------------------------------------

_logger: logging.Logger = logging.getLogger(__name__)
_logger.addHandler(logging.NullHandler())

# ---------------------------------------------------------------------------
# Enums and Constants
# ---------------------------------------------------------------------------

class Platform(enum.Enum):
    """Supported advertising platforms."""
    LINKEDIN = "linkedin"
    TWITTER = "twitter"

    def __str__(self) -> str:
        return self.value


class ImageDimension(enum.Enum):
    """Standard image dimensions per platform."""
    LINKEDIN = (1200, 628)
    TWITTER = (1200, 675)

    @property
    def width(self) -> int:
        return self.value[0]

    @property
    def height(self) -> int:
        return self.value[1]


# Allowed metric keywords used in the copy (for validation)
_ALLOWED_METRICS: Final[Set[str]] = {"P/E", "P/B", "Dividend Yield"}

# Regex to detect placeholder links (simple URL or [Link] token)
_PLACEHOLDER_LINK_PATTERN: Final[re.Pattern] = re.compile(r"\[Link\]|https?://\S+")

# ---------------------------------------------------------------------------
# Custom Exceptions
# ---------------------------------------------------------------------------

class AdCopyError(Exception):
    """Base exception for ad copy errors."""


class ValidationError(AdCopyError):
    """Raised when ad copy fails validation."""


# ---------------------------------------------------------------------------
# Data Models
# ---------------------------------------------------------------------------

@dataclass(frozen=True)
class LinkedInAdVariation:
    """Represents a single LinkedIn ad variation with headline, body, and visuals."""
    headline: str
    subhead: str
    body: str
    visual_option: str
    image_dimensions: ImageDimension = ImageDimension.LINKEDIN

    def __post_init__(self) -> None:
        """Validate fields after initialization."""
        if not self.headline or len(self.headline) > 150:
            raise ValidationError(
                f"Headline must be non‑empty and ≤150 chars (got {len(self.headline)})"
            )
        if not self.body or len(self.body) > 700:
            raise ValidationError(
                f"Body must be non‑empty and ≤700 chars (got {len(self.body)})"
            )


@dataclass(frozen=True)
class TwitterTweet:
    """Represents a single Twitter promoted tweet."""
    text: str
    visual_description: str
    card_type: str = "summary_large_image"

    def __post_init__(self) -> None:
        if not self.text or len(self.text) > 280:
            raise ValidationError(
                f"Tweet text must be ≤280 characters (got {len(self.text)})"
            )
        # Ensure at least one valid link placeholder
        if not _PLACEHOLDER_LINK_PATTERN.search(self.text):
            raise ValidationError("Tweet must contain a link or [Link] placeholder")


@dataclass(frozen=True)
class LandingPageConfig:
    """Configuration for the sign‑up landing page."""
    offer_statement: str
    capture_fields: List[str] = field(default_factory=lambda: ["email"])
    preview_text: str = "Monthly JSE portfolio research, straight to your inbox."
    cta_button: str = "Subscribe Free"

    def __post_init__(self) -> None:
        if not self.offer_statement:
            raise ValidationError("Offer statement cannot be empty")
        if not self.cta_button:
            raise ValidationError("CTA button text cannot be empty")
        valid_fields = {"email", "name_and_email"}
        if not all(f in valid_fields for f in self.capture_fields):
            raise ValidationError(f"Capture fields must be one of {valid_fields}")


@dataclass(frozen=True)
class CampaignConfiguration:
    """Full campaign configuration including targeting and budget notes."""
    platform: Platform
    budget_weeks: Tuple[int, int]  # (start_week_duration, end_week_duration)
    targeting: Dict[str, List[str]] = field(default_factory=dict)
    utm_parameters: Dict[str, str] = field(default_factory=dict)
    compliance_disclaimer: str = (
        "This is marketing content. Past performance does not guarantee future results."
    )
    brand_name_required: bool = True

    def __post_init__(self) -> None:
        if not isinstance(self.budget_weeks, tuple) or len(self.budget_weeks) != 2:
            raise ValidationError("budget_weeks must be a tuple of (start, end) durations")
        if self.budget_weeks[0] < 0 or self.budget_weeks[1] < 0:
            raise ValidationError("Budget weeks must be non‑negative")

# ---------------------------------------------------------------------------
# Core Service
# ---------------------------------------------------------------------------

class AdCopyGenerator:
    """
    Production‑ready generator for campaign ad copy.

    Usage:
        >>> gen = AdCopyGenerator()
        >>> li_ad = gen.create_linkedin_ad(
        ...     variation="A",
        ...     headline="Decode the JSE Like a Pro",
        ...     subhead="Free monthly newsletter reveals real valuation insights.",
        ...     body="Most investors see stock prices...",
        ...     visual_option="Infographic style"
        ... )
        >>> print(li_ad.headline)
    """

    def __init__(self, logger: Optional[logging.Logger] = None) -> None:
        self._logger = logger or _logger
        self._validated: List[str] = []  # Audit trail

    # ------------------------------------------------------------------
    # Public factory methods
    # ------------------------------------------------------------------

    def create_linkedin_ad(
        self,
        variation: str,
        headline: str,
        subhead: str,
        body: str,
        visual_option: str,
        image_dimensions: ImageDimension = ImageDimension.LINKEDIN,
    ) -> LinkedInAdVariation:
        """Create a validated LinkedIn ad variation."""
        self._logger.info("Creating LinkedIn ad variation '%s'", variation)
        try:
            ad = LinkedInAdVariation(
                headline=headline,
                subhead=subhead,
                body=body,
                visual_option=visual_option,
                image_dimensions=image_dimensions,
            )
            self._validated.append(f"LinkedIn variation {variation}: OK")
            return ad
        except ValidationError as exc:
            self._logger.error("LinkedIn ad validation failed: %s", exc)
            raise

    def create_twitter_tweet(
        self,
        text: str,
        visual_description: str,
        card_type: str = "summary_large_image",
    ) -> TwitterTweet:
        """Create a validated Twitter tweet."""
        self._logger.info("Creating Twitter tweet")
        if not visual_description:
            raise ValidationError("visual_description is required")
        try:
            tweet = TwitterTweet(
                text=text,
                visual_description=visual_description,
                card_type=card_type,
            )
            self._validated.append("Twitter tweet: OK")
            return tweet
        except ValidationError as exc:
            self._logger.error("Twitter tweet validation failed: %s", exc)
            raise

    def build_campaign(
        self,
        platform: Platform,
        budget_weeks: Tuple[int, int],
        targeting: Optional[Dict[str, List[str]]] = None,
        utm: Optional[Dict[str, str]] = None,
    ) -> CampaignConfiguration:
        """Build a validated campaign configuration."""
        self._logger.info("Building campaign configuration for %s", platform)
        try:
            config = CampaignConfiguration(
                platform=platform,
                budget_weeks=budget_weeks,
                targeting=targeting or {},
                utm_parameters=utm or {},
            )
            self._validated.append(f"Campaign config for {platform.value}: OK")
            return config
        except ValidationError as exc:
            self._logger.error("Campaign config validation failed: %s", exc)
            raise

    # ------------------------------------------------------------------
    # Utility methods
    # ------------------------------------------------------------------

    def generate_audit_trail(self) -> List[str]:
        """Return the audit trail of all validations performed."""
        return list(self._validated)

    def clear_audit_trail(self) -> None:
        """Clear the internal audit trail."""
        self._validated.clear()
        self._logger.debug("Audit trail cleared")

    # ------------------------------------------------------------------
    # Static helpers (input sanitization)
    # ------------------------------------------------------------------

    @staticmethod
    def sanitize_text(text: str, max_length: int = 280) -> str:
        """
        Sanitize and truncate text to ``max_length`` characters.

        Strips leading/trailing whitespace and replaces multiple spaces.
        """
        if not isinstance(text, str):
            raise TypeError("text must be a string")
        stripped = text.strip()
        # Normalise whitespace
        normalised = re.sub(r"\s+", " ", stripped)
        if len(normalised) > max_length:
            normalised = normalised[:max_length].rstrip()
        return normalised


# ---------------------------------------------------------------------------
# Module‑level test (when run directly)
# ---------------------------------------------------------------------------

def _demo() -> None:
    """Simple demonstration of the module's functionality."""
    logging.basicConfig(level=logging.INFO)

    gen = AdCopyGenerator()

    # Create LinkedIn variation A
    li_ad = gen.create_linkedin_ad(
        variation="A",
        headline="Decode the JSE Like a Pro",
        subhead="Free monthly newsletter reveals real valuation insights.",
        body=(
            "Most investors see stock prices. We help you see **value**. "
            "Every month we break down a JSE stock using the same metrics "
            "that fund managers use: P/E, P/B, dividend yield, and qualitative moats."
        ),
        visual_option="Infographic style",
    )
    print(f"Created LinkedIn ad: {li_ad.headline}")

    # Create Twitter tweet
    tweet = gen.create_twitter_tweet(
        text=(
            "P/E 13.46. P/B 6.46. Div Yield 3.73%.\n"
            "Those aren’t random numbers – they’re the story of a JSE stock.\n"
            "Our free monthly newsletter teaches you to read them like an analyst.\n"
            "Sign up: [Link]"
        ),
        visual_description="Clean card with three metrics on gradient background",
    )
    print(f"Created tweet (len={len(tweet.text)}): {tweet.text[:60]}...")

    # Build campaign config
    config = gen.build_campaign(
        platform=Platform.LINKEDIN,
        budget_weeks=(2, 2),
        targeting={
            "geo": ["Jamaica"],
            "job_titles": ["Investor", "Portfolio Manager", "Financial Analyst"],
        },
    )
    print(f"Campaign config for {config.platform} created.")

    # Audit trail
    print("Audit trail:", gen.generate_audit_trail())


if __name__ == "__main__":
    _demo()