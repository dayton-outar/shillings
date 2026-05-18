#!/usr/bin/env python3
"""
Portfolio Clarity: Smart Allocation for Jamaican Investors
Production-grade marketing strategy document generator.

This module encapsulates the logic of a targeted campaign to attract Jamaican
individual investors. It provides robust error handling, logging, input
validation, and full type annotations. The generated output is a high-quality
markdown document ready for distribution.

Usage:
    python generate_marketing_strategy.py

Requirements:
    Python 3.8+
    No external dependencies (uses standard library only).
"""

import logging
import sys
from datetime import datetime, timedelta
from typing import Dict, List, Optional, Tuple, Union

# ---------------------------------------------------------------------------
# Configuration & Constants
# ---------------------------------------------------------------------------

# Symbolic budget aligned with SEP stock price
SYMBOLIC_BUDGET: float = 81.73
SEP_TICKER: str = "SEP"

# Campaign duration in days
CAMPAIGN_DAYS: int = 15

# Target KPIs
TARGET_IMPRESSIONS: int = 2500
TARGET_CLICKS: int = 200
TARGET_SUBSCRIBERS: int = 25
TARGET_WEBINAR_REGS: int = 30
TARGET_BOOKINGS_MIN: int = 5
TARGET_BOOKINGS_MAX: int = 8
TARGET_CLIENTS_MIN: int = 2
TARGET_CLIENTS_MAX: int = 3

# Logging configuration
LOG_FORMAT: str = "%(asctime)s - %(name)s - %(levelname)s - %(message)s"
LOG_LEVEL: int = logging.INFO

# ---------------------------------------------------------------------------
# Logging Setup
# ---------------------------------------------------------------------------

logger: logging.Logger = logging.getLogger(__name__)
logger.setLevel(LOG_LEVEL)
_handler: logging.StreamHandler = logging.StreamHandler(sys.stdout)
_handler.setFormatter(logging.Formatter(LOG_FORMAT))
logger.addHandler(_handler)

# ---------------------------------------------------------------------------
# Data Structures
# ---------------------------------------------------------------------------

class CampaignMetrics:
    """Container for campaign performance KPIs."""

    def __init__(
        self,
        impressions: int = 0,
        clicks: int = 0,
        subscribers: int = 0,
        webinar_registrations: int = 0,
        consultation_bookings: int = 0,
        paid_clients: int = 0,
    ) -> None:
        self.impressions = impressions
        self.clicks = clicks
        self.subscribers = subscribers
        self.webinar_registrations = webinar_registrations
        self.consultation_bookings = consultation_bookings
        self.paid_clients = paid_clients

    def cost_per_lead(self, total_spend: float) -> float:
        """Calculate cost per email subscriber."""
        if self.subscribers == 0:
            return 0.0
        return total_spend / self.subscribers

    def return_on_ad_spend(self, revenue: float) -> float:
        """Return on ad spend ratio (revenue / total_spend)."""
        # Total spend is symbolic budget; in practice pass actual spend
        return revenue / SYMBOLIC_BUDGET


class TargetAudience:
    """Target audience segmentation."""

    def __init__(
        self,
        age_min: int = 30,
        age_max: int = 55,
        capital_min: float = 50_000.0,
        capital_max: float = 500_000.0,
        location: str = "Jamaica",
    ) -> None:
        if age_min >= age_max:
            raise ValueError("age_min must be less than age_max")
        if capital_min >= capital_max:
            raise ValueError("capital_min must be less than capital_max")
        self.age_min = age_min
        self.age_max = age_max
        self.capital_min = capital_min
        self.capital_max = capital_max
        self.location = location


class BudgetAllocation:
    """Manages line‑item budget and validates total."""

    def __init__(self, items: Optional[Dict[str, float]] = None) -> None:
        self.items: Dict[str, float] = items if items else {}
        self._validate_total()

    def add_item(self, name: str, cost: float) -> None:
        """Add a budget line item and revalidate."""
        if cost < 0:
            raise ValueError(f"Cost for '{name}' cannot be negative: {cost}")
        self.items[name] = cost
        self._validate_total()

    def total(self) -> float:
        """Compute sum of all items."""
        return round(sum(self.items.values()), 2)

    def _validate_total(self) -> None:
        """Validate that total does not exceed symbolic budget (with tolerance)."""
        tot = self.total()
        if tot > SYMBOLIC_BUDGET + 0.01:
            raise ValueError(
                f"Budget total {tot} exceeds symbolic budget {SYMBOLIC_BUDGET}"
            )


# ---------------------------------------------------------------------------
# Validation Helpers
# ---------------------------------------------------------------------------

def validate_budget_consistency(budget: float) -> None:
    """
    Ensure budget matches symbolic SEP price (within floating point tolerance).

    Args:
        budget: Total campaign budget in JMD.

    Raises:
        ValueError: If budget deviates from SYMBOLIC_BUDGET.
    """
    if not abs(budget - SYMBOLIC_BUDGET) < 0.01:
        raise ValueError(
            f"Budget {budget} does not match symbolic price {SYMBOLIC_BUDGET} "
            f"of {SEP_TICKER} stock."
        )


def validate_date_range(start_date: datetime, end_date: datetime) -> None:
    """Ensure end_date is after start_date."""
    if end_date <= start_date:
        raise ValueError("end_date must be after start_date")


# ---------------------------------------------------------------------------
# Document Generation
# ---------------------------------------------------------------------------

def generate_executive_summary(
    budget: float,
    campaign_days: int,
    audience: TargetAudience,
    core_message: str,
) -> str:
    """Generate the executive summary section."""
    return f"""
### 1. Executive Summary

This strategy outlines a targeted campaign to attract Jamaican individual investors aged {audience.age_min}–{audience.age_max} with investable capital of JMD ${audience.capital_min:,.0f}–${audience.capital_max:,.0f}. The campaign leverages educational content on stock valuation metrics (P/E, P/B, dividend yield) to build trust, differentiate our advisory services, and generate qualified leads. With a total budget of JMD ${budget:.2f} (aligned with the {SEP_TICKER} stock price symbolism), we will execute a {campaign_days}-day three-phase campaign across LinkedIn, Facebook, email, and local business forums. The core message: *\"{core_message}\"*.
"""


def generate_audience_analysis(audience: TargetAudience) -> str:
    """Generate market & audience analysis section."""
    return f"""
### 2. Market & Audience Analysis

#### 2.1 Target Audience Profile
- **Demographics**: {audience.location} residents, aged {audience.age_min}–{audience.age_max}, employed professionals, entrepreneurs, or retirees with liquid savings of JMD ${audience.capital_min:,.0f}–${audience.capital_max:,.0f}.
- **Psychographics**: Self-directed investors or those considering professional management; value financial literacy; distrust generic "get-rich-quick" advice; seek transparency and education.
- **Behavior**: Active on Facebook, LinkedIn for professional networking; participate in Jamaican finance forums (e.g., InvestJa, Jamaica Stock Exchange investor groups); may use email for business correspondence.

#### 2.2 Market Context
- The Jamaica Stock Exchange (JSE) has seen increased retail participation post-COVID, but many individual investors lack proper valuation skills (P/E, P/B, dividend yield).
- Existing wealth management firms either cater to high-net-worth clients (JMD $1M+) or provide generic tips without personalised allocation.
- Opportunity: Position as the "educator-first" advisory service for the mass-affluent segment.
"""


def generate_swot_analysis() -> str:
    """Generate SWOT analysis table."""
    return """
### 3. SWOT Analysis

| **Strengths** | **Weaknesses** |
|---------------|----------------|
| - Deep knowledge of JSE valuation metrics<br>- Ability to simplify complex concepts (P/E, P/B, dividends)<br>- Low-cost initial offer (first session discount)<br>- Agile, digital-native team | - Limited brand recognition in Jamaica<br>- Small budget (JMD $81.73)<br>- No established CRM or automation<br>- Single geographic focus (Jamaica) |
| **Opportunities** | **Threats** |
| - Rising interest in stock market among young professionals<br>- Low financial literacy creates demand for education<br>- Low competition in "educational advisory" niche<br>- Synergy with local business forums and LinkedIn groups | - Saturated low-cost advisory offers from local banks<br>- Economic volatility may reduce investable capital<br>- Trust deficit due to past investment scams<br>- Competitors with larger ad budgets |
"""


def generate_competitor_analysis() -> str:
    """Generate competitor analysis table."""
    return """
### 4. Competitor Analysis

| **Competitor** | **Offer** | **Key Weakness** |
|----------------|-----------|------------------|
| Local Bank Wealth Management (e.g., NCB, JMMB) | Free basic seminars, high minimum portfolio JMD $1M | Not accessible to smaller investors; generic allocation models. |
| Independent Financial Advisors (e.g., Wealth Masters Ja) | One-on-one, fee-only advice | High fees (2% AUM); minimal digital presence. |
| DIY Investment Education (online courses, YouTube channels) | Cheap courses on stock valuation | No personalisation; no ongoing advisory relationship. |
| Robo-advisors (e.g., Maya Wealth, SmartFolio) | Low fees, algorithm-based | Limited human touch; not tailored to JSE stocks. |

**Our Competitive Advantage**: Combine educational depth (P/E, P/B, dividend yield) with affordable human-led portfolio allocation advice and a limited-time discount to lower the barrier.
"""


def generate_customer_journey(campaign_days: int) -> str:
    """Generate customer journey map based on campaign duration."""
    phase1_end = campaign_days // 3
    phase2_end = 2 * campaign_days // 3
    phase3_end = campaign_days
    return f"""
### 5. Customer Journey Map

| **Phase** | **Touchpoints** | **Activities** | **Goal** |
|-----------|----------------|----------------|----------|
| **Awareness** (Days 1–{phase1_end}) | Facebook posts, LinkedIn articles, forum threads | Post educational carousels (e.g., "What P/E Ratio Tells You About Seprod"); run paid LinkedIn ad (if budget allows); engage in InvestJa forum Q&A. | Drive 500+ impressions, 60 clicks to landing page. |
| **Engagement** (Days {phase1_end + 1}–{phase2_end}) | Email sequence, webinar landing page, LinkedIn DM | Capture email via lead magnet ("Free Stock Valuation Cheat Sheet"); send 3-email sequence explaining P/B, dividends, allocation; host live Q&A via Zoom or Instagram Live. | Convert 10% of clicks to email subscribers; 30 webinar registrants. |
| **Conversion** (Days {phase2_end + 1}–{phase3_end}) | One-on-one consultation booking page, email reminder | Offer free 30-minute portfolio review; promote limited-time 20% discount on first advisory session; follow up with non-converts via email. | Secure 5–8 consultation bookings; close 2–3 paid advisory clients. |
"""


def generate_tactics_channels() -> str:
    """Generate campaign tactics and channels section."""
    return """
### 6. Campaign Tactics & Channels

#### 6.1 LinkedIn
- **Posts**: 3 educational posts (e.g., "How to Read a P/E Ratio", "Why P/B Matters for TJH", "Dividend Yield vs Growth").
- **Ad**: Single image ad targeting "Finance & Banking" professionals in Jamaica, budget JMD $40 (if remaining headroom).

#### 6.2 Facebook
- **Carousel ads**: 5 slides explaining each metric with Jamaican examples (SEP, TJH, CCC).
- **Boosted post**: Share the "Free Stock Valuation Cheat Sheet" lead magnet.

#### 6.3 Email (Sequence of 3 emails)
1. **Email 1 – The Problem**: "Why Most Investors Overpay for Stocks" (link to cheat sheet).
2. **Email 2 – The Solution**: "How We Use P/E, P/B, and Dividends to Build Your Personal Allocation" (case study of a hypothetical JMD $200k portfolio).
3. **Email 3 – The Offer**: "Your First Advisory Session – 20% Off (Only 3 Days)" + direct booking link.

#### 6.4 Local Business Forums (e.g., InvestJa, JSE Investor Forum)
- Post a thread: "Free Guide: How to Value JSE Stocks (P/E, P/B, Dividend Yield Explained)".
- Answer user questions with genuine educational value, then direct to landing page (no hard sell).
"""


def generate_budget_allocation(budget: BudgetAllocation) -> str:
    """Generate budget allocation table."""
    rows = ""
    total = budget.total()
    for name, cost in budget.items.items():
        rows += f"| {name} | ${cost:.2f} | |\n"

    return f"""
### 7. Budget Allocation (Total JMD ${total:.2f})

| **Item** | **Cost** | **Rationale** |
|----------|----------|---------------|
{rows}
| **Total** | **${total:.2f}** | Aligned with symbolic {SEP_TICKER} stock price. |
"""


def generate_kpi_section() -> str:
    """Generate KPIs and success metrics table."""
    return f"""
### 8. Campaign KPIs & Success Metrics

| **KPI** | **Target** | **Measurement Tool** |
|---------|------------|----------------------|
| Total impressions (all channels) | {TARGET_IMPRESSIONS:,} | Facebook/Instagram Insights, LinkedIn analytics, forum view count. |
| Landing page clicks | {TARGET_CLICKS:,} | URL shortener (Bitly) + UTM tags; Google Analytics (if integrated). |
| Email subscribers | {TARGET_SUBSCRIBERS} ({TARGET_SUBSCRIBERS / TARGET_CLICKS * 100:.1f}% of clicks) | Mailchimp list growth. |
| Webinar registrations | {TARGET_WEBINAR_REGS} | Zoom registration report, link clicks. |
| Consultation bookings | {TARGET_BOOKINGS_MIN}–{TARGET_BOOKINGS_MAX} | Booking system (Calendly) or manual email. |
| Paid advisory clients | {TARGET_CLIENTS_MIN}–{TARGET_CLIENTS_MAX} | CRM follow-up. |
| Cost per lead (email subscriber) | JMD ${{:.2f}} | Total spend / email subscribers. |
| Return on ad spend (ROAS) | At least 1:3 (cost vs first session fee) | Actual revenue from advisory sessions. |
"""


def generate_risk_management() -> str:
    """Generate risk management section."""
    return """
### 9. Risk Management & Contingencies

- **Low ad engagement**: Pivot to more organic forum posts; increase frequency of LinkedIn engagement.
- **Budget overrun**: Use only $60 on ads; rely on earned media and referrals.
- **Low webinar attendance**: Record session and send replay via email; offer one-on-one Q&A.
- **Negative sentiment**: Monitor comments; respond with sincere, helpful advice; never defensive.
"""


def generate_conclusion() -> str:
    """Generate concluding section."""
    return """
### 10. Conclusion & Next Steps

This campaign combines educational empowerment with a clear call-to-action, positioning our advisory service as the trustworthy partner for Jamaican investors. By focusing on valuation literacy (P/E, P/B, dividend yield) we build long-term relationships. The symbolic budget of $81.73 aligns our marketing directly with the stock we analyse.

**Next Steps**:
1. Finalise landing page and lead magnet.
2. Schedule social media posts for awareness phase.
3. Prepare email sequence.
4. Set up booking system.
5. Launch campaign.
"""


def generate_full_document(
    budget: float,
    audience: TargetAudience,
    campaign_days: int,
    core_message: str,
    budget_items: Optional[Dict[str, float]] = None,
) -> str:
    """
    Compile the complete marketing strategy document.

    Args:
        budget: Total campaign budget (must equal SYMBOLIC_BUDGET).
        audience: TargetAudience instance.
        campaign_days: Duration in days.
        core_message: Central campaign message.
        budget_items: Optional dictionary of line-item costs.

    Returns:
        Full markdown document as a string.

    Raises:
        ValueError: If inputs are inconsistent.
    """
    validate_budget_consistency(budget)

    budget_alloc = BudgetAllocation(budget_items)

    doc = f"# Portfolio Clarity: Smart Allocation for Jamaican Investors  \n## Marketing Strategy Document  \n"
    doc += generate_executive_summary(budget, campaign_days, audience, core_message)
    doc += generate_audience_analysis(audience)
    doc += generate_swot_analysis()
    doc += generate_competitor_analysis()
    doc += generate_customer_journey(campaign_days)
    doc += generate_tactics_channels()
    doc += generate_budget_allocation(budget_alloc)
    doc += generate_kpi_section()
    doc += generate_risk_management()
    doc += generate_conclusion()

    return doc


# ---------------------------------------------------------------------------
# Main Execution
# ---------------------------------------------------------------------------

def main() -> None:
    """Entry point for script execution."""
    logger.info("Starting marketing strategy document generation.")

    try:
        audience = TargetAudience(
            age_min=30,
            age_max=55,
            capital_min=50_000.0,
            capital_max=500_000.0,
        )

        # Example budget items (can be overridden via argument or config)
        budget_items = {
            "Facebook boosted post (7 days)": 30.00,
            "LinkedIn single image ad (5 days)": 30.00,
            "Canva Pro one-month subscription (existing)": 0.00,
            "Webinar hosting (Zoom basic)": 0.00,
            "Email service (Mailchimp free tier)": 0.00,
            "Lead magnet design (in-house)": 0.00,
            "Contingency / remaining budget": 21.73,
        }

        document = generate_full_document(
            budget=SYMBOLIC_BUDGET,
            audience=audience,
            campaign_days=CAMPAIGN_DAYS,
            core_message="Understand the numbers behind your portfolio. We simplify P/E, P/B, dividends and give you a clear allocation plan.",
            budget_items=budget_items,
        )

        # Output to file
        output_filename = "marketing_strategy.md"
        with open(output_filename, "w", encoding="utf-8") as f:
            f.write(document)
        logger.info("Document successfully written to %s", output_filename)

        # Display first 500 characters as a quick preview
        preview = document[:500]
        print("\n--- Preview ---")
        print(preview)
        print("... (document continues)")

    except ValueError as ve:
        logger.error("Input validation error: %s", ve)
        sys.exit(1)
    except IOError as ioe:
        logger.error("IO error while writing document: %s", ioe)
        sys.exit(2)
    except Exception as e:
        logger.exception("Unexpected error during generation: %s", e)
        sys.exit(3)


if __name__ == "__main__":
    main()