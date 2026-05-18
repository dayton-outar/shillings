"""
Campaign Management Module for Wealth Management Marketing.

This module provides a robust, type-safe representation of a marketing campaign
targeting Jamaican investors on the Jamaica Stock Exchange (JSE). It includes
full input validation, error handling, logging, and documentation to ensure
production-quality operation.
"""

from __future__ import annotations

import enum
import logging
from dataclasses import dataclass, field
from datetime import datetime, timedelta
from decimal import Decimal
from typing import Dict, List, Optional, Tuple

# ------------------------------------------------------------------------------
# Logging Configuration
# ------------------------------------------------------------------------------
logger = logging.getLogger(__name__)
logger.setLevel(logging.INFO)
if not logger.handlers:
    handler = logging.StreamHandler()
    handler.setFormatter(
        logging.Formatter(
            "%(asctime)s - %(name)s - %(levelname)s - %(message)s"
        )
    )
    logger.addHandler(handler)


# ------------------------------------------------------------------------------
# Enums & Constants
# ------------------------------------------------------------------------------
class Currency(enum.Enum):
    """Supported currencies with exchange rate to USD (as of campaign date)."""
    USD = Decimal("1.0")
    JMD = Decimal("0.006535")  # 1 JMD ~ 0.006535 USD

    def to_usd(self, amount: Decimal) -> Decimal:
        return amount * self.value


class ChannelType(enum.Enum):
    """Marketing channels used in the campaign."""
    LINKEDIN = "linkedin"
    TWITTER = "twitter"
    EMAIL = "email"
    BLOG = "blog"


class AdFormat(enum.Enum):
    """Available ad formats for paid channels."""
    SPONSORED_CONTENT = "sponsored_content"
    PROMOTED_TWEET = "promoted_tweet"
    LEAD_GEN_CARD = "lead_gen_card"


class TargetAgeRange(enum.Enum):
    """Target age brackets for LinkedIn/Twitter ads."""
    AGE_35_45 = (35, 45)
    AGE_45_55 = (45, 55)
    AGE_55_65 = (55, 65)


class InvestableAssetsRange(enum.Enum):
    """Asset brackets for segmentation."""
    UNDER_500K = "< JMD 500k"
    MID_500K_2M = "JMD 500k – 2M"
    OVER_2M = "> JMD 2M"


# ------------------------------------------------------------------------------
# Data Models
# ------------------------------------------------------------------------------
@dataclass(frozen=True)
class Budget:
    """
    Immutable budget for a single channel.

    Attributes
    ----------
    amount: Decimal
        Monetary amount in the specified currency.
    currency: Currency
        Currency in which the budget is denominated.
    """
    amount: Decimal
    currency: Currency

    def __post_init__(self) -> None:
        """Validate budget amount."""
        if self.amount < Decimal("0"):
            raise ValueError(f"Budget amount must be non-negative: {self.amount}")
        if self.amount > Decimal("1000000"):
            raise ValueError(f"Budget amount exceeds maximum allowed: {self.amount}")

    @property
    def usd_value(self) -> Decimal:
        """Return the budget converted to USD."""
        return self.currency.to_usd(self.amount)

    def __add__(self, other: Budget) -> Budget:
        """Add two budgets (both converted to USD)."""
        total_usd = self.usd_value + other.usd_value
        return Budget(amount=total_usd, currency=Currency.USD)

    def __str__(self) -> str:
        return f"{self.amount:.2f} {self.currency.name}"


@dataclass(frozen=True)
class TargetingCriteria:
    """
    Demographic and behavioral targeting for ads.

    All fields optional; at least one must be provided.
    """
    locations: Optional[List[str]] = None  # e.g., ["Jamaica"]
    age_ranges: Optional[List[TargetAgeRange]] = None
    job_titles: Optional[List[str]] = None
    interests: Optional[List[str]] = None
    keywords: Optional[List[str]] = None
    follows: Optional[List[str]] = None  # Twitter account follows

    def __post_init__(self) -> None:
        """Validate that at least one criterion is set."""
        if not any([
            self.locations, self.age_ranges, self.job_titles,
            self.interests, self.keywords, self.follows
        ]):
            raise ValueError("At least one targeting criterion must be provided.")


@dataclass(frozen=True)
class AdCreative:
    """
    Creative assets for an ad.

    Attributes
    ----------
    headline: str
        Ad headline (max 150 characters).
    body_text: str
        Main ad copy (max 500 characters).
    visual_description: str
        Description of the graphic to be used.
    call_to_action: str
        CTA button text.
    """
    headline: str
    body_text: str
    visual_description: str
    call_to_action: str = "Subscribe Now"

    def __post_init__(self) -> None:
        """Validate lengths and non-emptiness."""
        if not self.headline.strip():
            raise ValueError("Headline cannot be empty.")
        if not self.body_text.strip():
            raise ValueError("Body text cannot be empty.")
        if len(self.headline) > 150:
            raise ValueError(f"Headline too long ({len(self.headline)} > 150).")
        if len(self.body_text) > 500:
            raise ValueError(f"Body text too long ({len(self.body_text)} > 500).")


@dataclass(frozen=True)
class Channel:
    """
    Represents a marketing channel with its budget, ad format, creative, targeting,
    and expected performance.

    Attributes
    ----------
    channel_type: ChannelType
        Which platform/channel.
    budget: Budget
        Allocated budget for this channel.
    ad_format: Optional[AdFormat]
        Ad format (None for organic channels).
    creative: Optional[AdCreative]
        Creative assets (None for organic).
    targeting: Optional[TargetingCriteria]
        Targeting rules (None for organic/email/blog).
    expected_impressions: Tuple[int, int]
        (min, max) expected impressions.
    expected_clicks: Tuple[int, int]
        (min, max) expected clicks.
    """
    channel_type: ChannelType
    budget: Budget
    ad_format: Optional[AdFormat] = None
    creative: Optional[AdCreative] = None
    targeting: Optional[TargetingCriteria] = None
    expected_impressions: Tuple[int, int] = (0, 0)
    expected_clicks: Tuple[int, int] = (0, 0)

    def __post_init__(self) -> None:
        """Validate channel configuration consistency."""
        if self.channel_type in (ChannelType.LINKEDIN, ChannelType.TWITTER):
            if self.ad_format is None:
                raise ValueError(f"Paid channel {self.channel_type} requires an ad_format.")
            if self.creative is None:
                raise ValueError(f"Paid channel {self.channel_type} requires creative assets.")
        else:
            if self.ad_format is not None:
                logger.warning(
                    "Organic channel %s has ad_format set; ignoring.", self.channel_type
                )
            if self.creative is not None:
                logger.warning(
                    "Organic channel %s has creative set; ignoring.", self.channel_type
                )
        if self.expected_impressions[0] > self.expected_impressions[1]:
            raise ValueError(
                f"Min impressions {self.expected_impressions[0]} > max {self.expected_impressions[1]}"
            )
        if self.expected_clicks[0] > self.expected_clicks[1]:
            raise ValueError(
                f"Min clicks {self.expected_clicks[0]} > max {self.expected_clicks[1]}"
            )
        logger.debug("Channel %s initialized with budget %s", self.channel_type, self.budget)


@dataclass(frozen=True)
class KPI:
    """
    Key Performance Indicator definition.

    Attributes
    ----------
    name: str
        Human-readable name.
    target_value: float
        Numeric target (e.g., 30 for sign-ups).
    unit: str
        Unit of measurement ("subscriptions", "%", "views", etc.).
    measurement_tool: str
        Tool used to measure (e.g., "LinkedIn Analytics").
    """
    name: str
    target_value: float
    unit: str
    measurement_tool: str

    def __post_init__(self) -> None:
        if self.target_value < 0:
            raise ValueError(f"KPI target value must be non-negative: {self.target_value}")


@dataclass(frozen=True)
class CampaignTimeline:
    """
    Timeline for the campaign sprint.

    Attributes
    ----------
    start_date: datetime
        Campaign start (Week 1).
    end_date: datetime
        Campaign end (Week 4).
    week1_activities: List[str]
    week2_activities: List[str]
    week3_activities: List[str]
    week4_activities: List[str]
    """
    start_date: datetime
    end_date: datetime
    week1_activities: List[str] = field(default_factory=list)
    week2_activities: List[str] = field(default_factory=list)
    week3_activities: List[str] = field(default_factory=list)
    week4_activities: List[str] = field(default_factory=list)

    def __post_init__(self) -> None:
        if self.start_date >= self.end_date:
            raise ValueError("start_date must be before end_date.")
        # Ensure all activity lists are non-empty at schema level (soft warning)
        for week_name, activities in [
            ("Week 1", self.week1_activities),
            ("Week 2", self.week2_activities),
            ("Week 3", self.week3_activities),
            ("Week 4", self.week4_activities),
        ]:
            if not activities:
                logger.warning("No activities defined for %s.", week_name)

    @property
    def duration_days(self) -> int:
        return (self.end_date - self.start_date).days


@dataclass
class Campaign:
    """
    Top-level campaign representation.

    Parameters
    ----------
    name: str
        Campaign name.
    firm_name: str
        Wealth management firm.
    total_budget: Budget
        Overall campaign budget.
    channels: List[Channel]
        Active channels.
    kpis: List[KPI]
        Success metrics.
    timeline: CampaignTimeline
        Sprint timeline.
    primary_goal: str
        Campaign primary objective.
    target_audience_description: str
        Text description of target audience.
    landing_page_config: dict
        Configuration for the signup page (headline, subhead, form fields, etc.).
    messaging_pillars: List[Dict[str, str]]
        List of pillars with title and example post.
    risk_mitigation: List[str]
        List of risk mitigation strategies.
    """
    name: str
    firm_name: str
    total_budget: Budget
    channels: List[Channel]
    kpis: List[KPI]
    timeline: CampaignTimeline
    primary_goal: str = ""
    target_audience_description: str = ""
    landing_page_config: dict = field(default_factory=dict)
    messaging_pillars: List[Dict[str, str]] = field(default_factory=list)
    risk_mitigation: List[str] = field(default_factory=list)

    def __post_init__(self) -> None:
        """Validate campaign consistency."""
        # Validate total budget matches channels sum
        channel_budget_sum = sum(
            (c.budget.usd_value for c in self.channels),
            Decimal("0")
        )
        total_usd = self.total_budget.usd_value
        if channel_budget_sum > total_usd:
            raise ValueError(
                f"Channel budgets sum ({channel_budget_sum:.2f} USD) "
                f"exceeds total budget ({total_usd:.2f} USD)"
            )
        logger.info(
            "Campaign '%s' initialized. Total budget: %s. Channels: %d.",
            self.name, self.total_budget, len(self.channels)
        )

    def validate_completeness(self) -> List[str]:
        """
        Check that all required campaign elements are present and valid.

        Returns
        -------
        List[str]
            List of warning/error messages.
        """
        issues: List[str] = []
        if not self.primary_goal:
            issues.append("No primary goal defined.")
        if not self.target_audience_description:
            issues.append("No target audience description.")
        if not self.messaging_pillars:
            issues.append("No messaging pillars defined.")
        if not self.risk_mitigation:
            issues.append("No risk mitigation strategies defined.")
        # Check that landing page has essential fields
        if "headline" not in self.landing_page_config:
            issues.append("Landing page config missing 'headline'.")
        if "form_fields" not in self.landing_page_config:
            issues.append("Landing page config missing 'form_fields'.")
        return issues


# ------------------------------------------------------------------------------
# Example / Factory Function
# ------------------------------------------------------------------------------
def create_jse_campaign() -> Campaign:
    """
    Create the default JSE Portfolio Insight Campaign as defined in the marketing document.

    Returns
    -------
    Campaign
        Fully initialized campaign instance.
    """
    # Budget items
    linkedin_budget = Budget(Decimal("50.00"), Currency.USD)
    twitter_budget = Budget(Decimal("31.73"), Currency.USD)

    # Channels
    linkedin_channel = Channel(
        channel_type=ChannelType.LINKEDIN,
        budget=linkedin_budget,
        ad_format=AdFormat.SPONSORED_CONTENT,
        creative=AdCreative(
            headline="Decode JSE Stocks in 60 Seconds",
            body_text="P/E, P/B, dividend yield – make sense of the numbers. Get our free monthly research sheet + portfolio strategy.",
            visual_description="Clean graphic comparing SEP, TJH, CCC with metrics highlighted.",
        ),
        targeting=TargetingCriteria(
            locations=["Jamaica"],
            age_ranges=[TargetAgeRange.AGE_35_45, TargetAgeRange.AGE_45_55, TargetAgeRange.AGE_55_65],
            job_titles=["Investor", "Business Owner", "Manager", "Director", "Financial Analyst", "Consultant"],
            interests=["Investing", "Financial Markets", "Stock Trading", "Wealth Management"],
        ),
        expected_impressions=(5000, 8000),
        expected_clicks=(50, 80),
    )

    twitter_channel = Channel(
        channel_type=ChannelType.TWITTER,
        budget=twitter_budget,
        ad_format=AdFormat.PROMOTED_TWEET,
        creative=AdCreative(
            headline="What does a P/B of 6.46x tell you about TJH?",
            body_text="It means market value is 6x book value – investors expect strong future returns from toll roads. Our monthly research sheet breaks down 5 key ratios for 10 JSE stocks. Subscribe today and get the full allocation guide.",
            visual_description="Thread with 4 tweets (as defined in doc).",
        ),
        targeting=TargetingCriteria(
            locations=["Jamaica"],
            follows=["@JSEstockexchange", "@JamaicaObserver", "@JamaicaGleaner"],
            keywords=["JSE", "Jamaica stock", "invest Jamaica", "dividend stock", "SEP", "TJH", "CCC"],
        ),
        expected_impressions=(10000, 15000),
        expected_clicks=(40, 60),
    )

    # KPIs
    kpis = [
        KPI("Newsletter sign-ups", 30, "subscriptions", "LinkedIn/landing page"),
        KPI("Cost per acquisition", 2.0, "USD per sign-up", "CPA calculation"),
        KPI("Click-through rate LinkedIn", 2.5, "%", "Platform analytics"),
        KPI("Click-through rate Twitter", 1.5, "%", "Platform analytics"),
        KPI("Email open rate", 35, "%", "Email marketing tool"),
        KPI("Social engagement", 100, "combined likes/shares/comments", "Native analytics"),
        KPI("Blog post page views", 200, "views", "Google Analytics"),
    ]

    # Timeline (starting 2025-04-01 as example)
    timeline = CampaignTimeline(
        start_date=datetime(2025, 4, 1),
        end_date=datetime(2025, 4, 28),
        week1_activities=[
            "Finalize creative assets (graphic, ad copy, landing page)",
            "Set up LinkedIn Campaign Manager & Twitter Ads"
        ],
        week2_activities=[
            "Launch LinkedIn Sponsored Content + Twitter Promoted Tweet",
            "Publish blog post; send organic email"
        ],
        week3_activities=[
            "Monitor ads, adjust targeting/bids if needed",
            "Re-share blog + social posts"
        ],
        week4_activities=[
            "End ad campaigns; collect all data",
            "Analyze results against KPIs; prepare report",
            "Optimize for next sprint (if repeating)"
        ],
    )

    # Landing page config
    landing_page = {
        "headline": "Get Your Monthly JSE Research Sheet + Portfolio Allocation Guide",
        "subhead": "Decode stocks like SEP, TJH, and CCC – straight to your inbox.",
        "visual": "research_sheet_graphic.png",
        "form_fields": [
            {"name": "Name", "type": "text", "required": True},
            {"name": "Email", "type": "email", "required": True},
            {
                "name": "Investable Assets",
                "type": "dropdown",
                "options": [
                    InvestableAssetsRange.UNDER_500K.value,
                    InvestableAssetsRange.MID_500K_2M.value,
                    InvestableAssetsRange.OVER_2M.value,
                ],
                "required": False,
            },
        ],
        "privacy_note": "We respect your inbox. Unsubscribe anytime.",
        "thank_you_page": "Confirmation with download link for sample PDF.",
    }

    # Messaging pillars
    pillars = [
        {
            "title": "Know Your Numbers",
            "example_post": "P/E ratio of 13.46x – cheap or expensive? Here’s how to decode Seprod."
        },
        {
            "title": "Allocation That Works",
            "example_post": "3 stocks, 3 different P/Bs – which belongs in your growth bucket vs. income bucket?"
        },
        {
            "title": "Research Without the Noise",
            "example_post": "Your monthly JSE cheat sheet is ready: CCC, TJH, SEP insider breakdown."
        },
    ]

    # Risk mitigation
    risks = [
        "Paid reach is limited due to low budget. Mitigation: Optimize targeting narrowly; use organic amplification.",
        "Ad fatigue possible. Mitigation: Rotate creative every 2 weeks; A/B test headlines.",
        "Low response from email segment. Mitigation: Segment by past engagement; personalize subject lines.",
    ]

    campaign = Campaign(
        name="Portfolio Insight Campaign",
        firm_name="Wealth Management Firm",
        total_budget=Budget(Decimal("81.73"), Currency.USD),
        channels=[linkedin_channel, twitter_channel],
        kpis=kpis,
        timeline=timeline,
        primary_goal="Drive qualified newsletter subscriptions from individual Jamaican investors aged 35–65 with investable assets >JMD 500k.",
        target_audience_description="Jamaican investors aged 35–65 with investable assets >JMD 500k, interested in JSE stocks, seeking structured advice.",
        landing_page_config=landing_page,
        messaging_pillars=pillars,
        risk_mitigation=risks,
    )

    return campaign


# ------------------------------------------------------------------------------
# Main (for testing)
# ------------------------------------------------------------------------------
if __name__ == "__main__":
    # Configure root logger for test output
    logging.basicConfig(level=logging.INFO)

    try:
        camp = create_jse_campaign()
        print(f"Campaign: {camp.name}")
        print(f"Total budget: {camp.total_budget}")
        issues = camp.validate_completeness()
        if issues:
            print("Completeness issues:")
            for issue in issues:
                print(f"  - {issue}")
        else:
            print("All campaign elements present.")
        print("Campaign created successfully.")
    except Exception as e:
        logger.exception("Failed to create campaign: %s", e)
        raise