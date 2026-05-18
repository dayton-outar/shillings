"""
Social Media Portfolio Insight Campaign Manager
Production-grade module with full validation, error handling, logging, and type safety.
"""

import logging
import json
from datetime import datetime, time
from enum import Enum
from typing import List, Dict, Optional, Union, Final
from dataclasses import dataclass, field, asdict
from pathlib import Path

# Configure logging
logging.basicConfig(
    level=logging.INFO,
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s",
    handlers=[logging.StreamHandler(), logging.FileHandler("campaign_manager.log")]
)
logger = logging.getLogger(__name__)

# --- Constants & Enums ---

class Platform(Enum):
    """Supported social media platforms."""
    LINKEDIN = "linkedin"
    TWITTER = "twitter"
    FACEBOOK = "facebook"

class PostPhase(Enum):
    """Campaign phase identifier."""
    TEASER = "teaser"
    EDUCATIONAL = "educational"
    SOCIAL_PROOF = "social_proof"
    COUNTDOWN = "countdown"
    ENGAGEMENT = "engagement"
    INFOGRAPHIC = "infographic"
    TESTIMONIAL = "testimonial"

class RiskLevel(Enum):
    LOW = "low"
    MEDIUM = "medium"
    HIGH = "high"

# --- Data Models ---

@dataclass(frozen=True)
class StockCard:
    """Immutable representation of a stock analysis card."""
    ticker: str
    name: str
    pe_ratio: Optional[float] = None
    pb_ratio: Optional[float] = None
    share_price: Optional[float] = None
    dividend_yield: Optional[float] = None
    risk_level: RiskLevel = RiskLevel.MEDIUM

    def __post_init__(self) -> None:
        """Validate stock card fields."""
        if not self.ticker or not isinstance(self.ticker, str):
            raise ValueError("Ticker must be a non-empty string")
        if len(self.ticker) > 10:
            raise ValueError("Ticker too long")
        if self.pe_ratio is not None and self.pe_ratio <= 0:
            raise ValueError("P/E ratio must be positive")
        if self.pb_ratio is not None and self.pb_ratio <= 0:
            raise ValueError("P/B ratio must be positive")
        if self.share_price is not None and self.share_price <= 0:
            raise ValueError("Share price must be positive")
        if self.dividend_yield is not None and (self.dividend_yield < 0 or self.dividend_yield > 100):
            raise ValueError("Dividend yield must be between 0 and 100")

@dataclass
class Post:
    """Represents a single social media post."""
    platform: Platform
    phase: PostPhase
    headline: Optional[str] = None
    body: str = ""
    image_description: Optional[str] = None
    link: Optional[str] = None
    hashtags: List[str] = field(default_factory=list)
    scheduled_time: Optional[time] = None
    stock_cards: List[StockCard] = field(default_factory=list)

    def validate(self) -> bool:
        """Validate post completeness and constraints."""
        if not self.body.strip():
            raise ValueError("Post body cannot be empty")
        if self.platform == Platform.TWITTER and len(self.body) > 280:
            raise ValueError("Twitter post exceeds 280 characters")
        if self.link and not self.link.startswith("https://"):
            raise ValueError("Link must be HTTPS")
        if self.scheduled_time and not (time(6,0) <= self.scheduled_time <= time(22,0)):
            raise ValueError("Scheduled time outside allowed window (06:00-22:00)")
        logger.debug(f"Post validated: {self.platform.value} - {self.phase.value}")
        return True

    def to_dict(self) -> Dict:
        """Export post to dictionary."""
        return asdict(self)

# --- Campaign Manager ---

class CampaignManager:
    """Manages the full portfolio insight campaign lifecycle."""

    def __init__(self, branding: str = "Wealth Management Co.") -> None:
        self.branding = branding
        self.posts: List[Post] = []
        self.load_campaign_data()

    def load_campaign_data(self) -> None:
        """Load hardcoded campaign posts with validation."""
        try:
            # Define stock cards used across posts
            sep_card = StockCard(
                ticker="SEP", name="Seprod Limited",
                pe_ratio=13.46, share_price=81.73, risk_level=RiskLevel.LOW
            )
            tjh_card = StockCard(
                ticker="TJH", name="TransJamaican Highway Limited",
                pb_ratio=6.46, dividend_yield=3.73, risk_level=RiskLevel.MEDIUM
            )
            ccc_card = StockCard(
                ticker="CCC", name="Caribbean Cement Company Limited",
                pe_ratio=12.93, risk_level=RiskLevel.LOW
            )
            logger.info("Stock cards loaded successfully")

            # Build posts
            linkedin_teaser = Post(
                platform=Platform.LINKEDIN, phase=PostPhase.TEASER,
                headline="Decoding the numbers that matter.",
                body=(
                    "Ever wondered what a P/E ratio *really* tells you about a stock?\n"
                    "Or why a high P/B might not mean a company is overvalued?\n\n"
                    "Most investors see the numbers but miss the story.\n\n"
                    "Our latest portfolio insight breaks down three JSE stocks using "
                    "the same metrics professional analysts use every day. No fluff. Just clarity.\n\n"
                    "[Image: Simplified stock recommendation card showing P/E, P/B, Dividend Yield for SEP, TJH, CCC]\n\n"
                    "The full analysis is in this month’s newsletter – along with a practical "
                    "allocation framework for building a resilient JSE portfolio.\n\n"
                    "Subscribe now to get it delivered."
                ),
                link="https://example.com/newsletter-signup",
                hashtags=["#JSE", "#Investing", "#PortfolioManagement", "#FinancialLiteracy", "#JamaicaStocks"],
                scheduled_time=time(8, 30),
                stock_cards=[sep_card, tjh_card, ccc_card]
            )

            linkedin_educational = Post(
                platform=Platform.LINKEDIN, phase=PostPhase.EDUCATIONAL,
                headline="P/E ratio – friend or foe?",
                body=(
                    "P/E = Price ÷ Earnings Per Share. Simple formula. But what does it tell you "
                    "about a stock like Caribbean Cement (CCC)?\n\n"
                    "At 12.93x, investors are paying about $13 for every $1 of CCC’s earnings. "
                    "That’s reasonable for a stable player. But compare that to a growth stock "
                    "with a P/E of 30x – and suddenly the story changes.\n\n"
                    "Knowing *why* a P/E is high or low is what separates informed investors "
                    "from the crowd.\n\n"
                    "We cover this – plus P/B, dividend yield, and qualitative factors – in "
                    "every issue of our monthly portfolio newsletter.\n\n"
                    "Join 200+ subscribers already getting smarter with their JSE investments."
                ),
                link="https://example.com/signup",
                hashtags=["#JSE", "#ValueInvesting", "#StockAnalysis", "#PErRatio", "#Jamaica"],
                scheduled_time=time(9, 0),
                stock_cards=[ccc_card]
            )

            linkedin_social_proof = Post(
                platform=Platform.LINKEDIN, phase=PostPhase.SOCIAL_PROOF,
                headline="“Finally – a newsletter that doesn’t just tell me what to buy, but *why*.”",
                body=(
                    "That’s what one subscriber said after reading our last issue.\n\n"
                    "We don’t do stock tips. We do frameworks.\n\n"
                    "Each month we analyse 3-5 JSE stocks using the same metrics fund managers use: "
                    "P/E, P/B, dividend yield, debt levels, and management track record. Then we "
                    "show you where they might fit in your portfolio.\n\n"
                    "This month’s issue is about to go out. Don’t miss it."
                ),
                link="https://example.com/subscribe",
                hashtags=["#JSE", "#PortfolioManagement", "#WealthBuilding", "#JamaicaInvestors"],
                scheduled_time=time(8, 45)
            )

            # Twitter/X posts
            twitter_teaser = Post(
                platform=Platform.TWITTER, phase=PostPhase.TEASER,
                body=(
                    "P/E. P/B. Dividend yield.\n"
                    "Three numbers that can make or break your portfolio.\n\n"
                    "We just published a free breakdown of 3 JSE stocks using these exact metrics.\n\n"
                    "Get the full analysis + portfolio allocation framework in this month’s newsletter:\n"
                    "https://example.com/newsletter"
                ),
                hashtags=["#JSE", "#Investing", "#Stocks"],
                scheduled_time=time(12, 0)
            )

            twitter_educational = Post(
                platform=Platform.TWITTER, phase=PostPhase.EDUCATIONAL,
                body=(
                    "What does a P/B of 6.46x tell you about TransJamaican Highway (TJH)?\n\n"
                    "It means the market values the company at 6x its book value. Why so high? "
                    "Because toll roads generate predictable, long-term cash flow.\n\n"
                    "That’s the kind of insight in our monthly newsletter. Subscribe now: "
                    "https://example.com/signup"
                ),
                hashtags=["#JSE", "#ValueInvesting", "#Dividends"],
                scheduled_time=time(12, 30)
            )

            twitter_tip = Post(
                platform=Platform.TWITTER, phase=PostPhase.TESTIMONIAL,
                body=(
                    "Dividend yield ≠ free money.\n\n"
                    "TJH yields ~3.73%. But if the stock price drops, your yield goes up – "
                    "not because dividends increased, but because you paid less.\n\n"
                    "Know the difference. Subscribe for real portfolio insights: "
                    "https://example.com/signup"
                ),
                hashtags=["#JSE", "#DividendInvesting"],
                scheduled_time=time(13, 0)
            )

            twitter_countdown = Post(
                platform=Platform.TWITTER, phase=PostPhase.COUNTDOWN,
                body=(
                    "⏰ This month’s Portfolio Insight newsletter drops in 48 hours.\n\n"
                    "Inside:\n"
                    "- Deep dive on 3 JSE stocks\n"
                    "- P/E, P/B, dividend yield analysis\n"
                    "- Portfolio allocation recommendations\n\n"
                    "Don’t miss it. Subscribe: https://example.com/signup"
                ),
                hashtags=["#JSE", "#PortfolioManagement"],
                scheduled_time=time(12, 0)
            )

            # Facebook posts
            facebook_engagement = Post(
                platform=Platform.FACEBOOK, phase=PostPhase.ENGAGEMENT,
                headline="Is a low P/E always a bargain?",
                body=(
                    "Not necessarily. A stock with a P/E of 13x (like SEP) might be cheap – "
                    "or it might reflect weak growth prospects. The key is understanding the *context*.\n\n"
                    "That’s exactly what our monthly newsletter helps you do. Each edition breaks "
                    "down real JSE stocks using professional analysis tools – in plain English.\n\n"
                    "👉 Subscribe for free and get this month’s issue: https://example.com/signup\n\n"
                    "Comment with a stock you’d like us to analyse next!"
                ),
                hashtags=["#JSE", "#InvestingTips", "#WealthManagement", "#Jamaica"],
                scheduled_time=time(17, 30)
            )

            facebook_infographic = Post(
                platform=Platform.FACEBOOK, phase=PostPhase.INFOGRAPHIC,
                headline="3 Stocks, 3 Metrics, 1 Framework",
                body=(
                    "Don’t just watch the market – understand it.\n\n"
                    "We analysed Seprod, TransJamaican Highway, and Caribbean Cement using "
                    "the same metrics pros use. Want to see how they stack up in a balanced portfolio?\n\n"
                    "Subscribe to our monthly Portfolio Insight newsletter – it’s free and comes "
                    "straight to your inbox.\n\n"
                    "[Carousel image 1 – title card: “3 Stocks, 3 Metrics, 1 Framework”]\n"
                    "[Image 2 – SEP card: P/E 13.46x, Price $81.73, Low risk]\n"
                    "[Image 3 – TJH card: P/B 6.46x, Dividend yield 3.73%, Medium risk]\n"
                    "[Image 4 – CCC card: P/E 12.93x, Solid earnings, Low risk]\n"
                    "[Image 5 – Call to action: “Get the full analysis + allocation guide in our free newsletter”]"
                ),
                link="https://example.com/signup",
                hashtags=["#JSE", "#StockAnalysis", "#PortfolioInsight"],
                scheduled_time=time(17, 0)
            )

            facebook_testimonial = Post(
                platform=Platform.FACEBOOK, phase=PostPhase.TESTIMONIAL,
                headline="“I’ve been trading JSE for 5 years, but this newsletter taught me how to *structure* my portfolio.”",
                body=(
                    "That’s the feedback we keep getting.\n\n"
                    "Our latest issue covers: P/E vs P/B, dividend yield myths, and a ready-to-use "
                    "allocation model for JSE investors.\n\n"
                    "Last call for this month’s edition. Subscribe now to receive it:\n"
                    "https://example.com/signup"
                ),
                hashtags=["#JSE", "#PortfolioManagement", "#Investing"],
                scheduled_time=time(18, 0)
            )

            # Collect all posts
            self.posts = [
                linkedin_teaser, linkedin_educational, linkedin_social_proof,
                twitter_teaser, twitter_educational, twitter_tip, twitter_countdown,
                facebook_engagement, facebook_infographic, facebook_testimonial
            ]

            # Validate all posts
            for post in self.posts:
                post.validate()

            logger.info(f"Campaign loaded with {len(self.posts)} posts")

        except ValueError as e:
            logger.error(f"Validation error loading campaign: {e}")
            raise
        except Exception as e:
            logger.critical(f"Unexpected error loading campaign: {e}")
            raise

    def get_posts_by_platform(self, platform: Platform) -> List[Post]:
        """Return posts filtered by platform."""
        return [p for p in self.posts if p.platform == platform]

    def schedule_posts(self) -> None:
        """Simulate scheduling (placeholder for production scheduler)."""
        for post in self.posts:
            logger.info(
                f"Scheduled: [{post.platform.value.upper()}] {post.phase.value} "
                f"at {post.scheduled_time or 'default'}"
            )

    def export_campaign(self, output_path: Union[str, Path] = "campaign_export.json") -> None:
        """Export all posts to JSON file."""
        try:
            output_path = Path(output_path)
            data = {
                "campaign": "Portfolio Insight",
                "generated_at": datetime.now().isoformat(),
                "posts": [p.to_dict() for p in self.posts]
            }
            with open(output_path, "w", encoding="utf-8") as f:
                json.dump(data, f, indent=2, default=str)
            logger.info(f"Campaign exported to {output_path}")
        except IOError as e:
            logger.error(f"Failed to export campaign: {e}")
            raise

    def run(self) -> None:
        """Orchestrate full campaign operation."""
        try:
            logger.info("Starting Portfolio Insight Campaign")
            self.schedule_posts()
            self.export_campaign()
            logger.info("Campaign execution completed successfully")
        except Exception as e:
            logger.critical(f"Campaign failed: {e}")
            raise

# --- Entry Point ---

if __name__ == "__main__":
    manager = CampaignManager()
    manager.run()