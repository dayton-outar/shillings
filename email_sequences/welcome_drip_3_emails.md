"""
JSE Research Tool – Email Sequence Generator
Generates a three-email welcome drip sequence for the portfolio management tool.
Production-grade implementation with full error handling, logging, and validation.
"""

import logging
from typing import Dict, List, Optional
from datetime import datetime
import re

# Configure module logger
logger = logging.getLogger(__name__)
logging.basicConfig(level=logging.INFO, format="%(asctime)s - %(name)s - %(levelname)s - %(message)s")


class EmailTemplateError(Exception):
    """Custom exception for email template generation errors."""
    pass


class EmailGenerator:
    """
    Generates the JSE Research Tool welcome sequence emails.

    Attributes:
        sender_name: Display name for the sender (e.g., "JSE Research Team")
        base_url: Base URL for tool links (validated at init)
        github_url: GitHub repository URL (validated at init)
    """

    def __init__(
        self,
        sender_name: str = "JSE Research Team",
        base_url: Optional[str] = None,
        github_url: Optional[str] = None,
    ) -> None:
        """
        Initialize the generator with optional custom URLs.

        Args:
            sender_name: Sender display name.
            base_url: Base URL for the tool (default: "https://jse-research-tool.com").
            github_url: GitHub repository URL (default: "https://github.com/your-org/jse-research-tool").

        Raises:
            ValueError: If URLs are provided but invalid.
        """
        if not sender_name or not isinstance(sender_name, str):
            raise ValueError("sender_name must be a non-empty string")
        self.sender_name = sender_name.strip()
        self.base_url = self._validate_url(base_url, "https://jse-research-tool.com")
        self.github_url = self._validate_url(github_url, "https://github.com/your-org/jse-research-tool")

        logger.info("EmailGenerator initialized. base_url=%s", self.base_url)

    @staticmethod
    def _validate_url(url: Optional[str], default: str) -> str:
        """Validate and return URL, falling back to default if None."""
        if url is None:
            return default
        if not url.startswith("http://") and not url.startswith("https://"):
            raise ValueError(f"Invalid URL: {url}")
        # Basic URL format check
        pattern = r"^https?://[^\s/$.?#].[^\s]*$"
        if not re.match(pattern, url):
            raise ValueError(f"Malformed URL: {url}")
        return url.rstrip("/")

    @staticmethod
    def _validate_first_name(first_name: str) -> str:
        """
        Validate and sanitize first name for email personalization.

        Args:
            first_name: Raw first name input.

        Returns:
            Sanitized first name (capitalized, stripped).

        Raises:
            ValueError: If first_name is empty or contains invalid characters.
        """
        if not first_name or not isinstance(first_name, str):
            raise ValueError("first_name must be a non-empty string")
        sanitized = first_name.strip()
        # Allow only letters, hyphens, apostrophes (common in names)
        if not re.match(r"^[A-Za-zÀ-ÖØ-öø-ÿ'\-]+$", sanitized):
            raise ValueError("first_name contains invalid characters")
        return sanitized.title()

    def _generate_email_1(self, first_name: str) -> str:
        """
        Build Email 1: Welcome & Tool Overview.

        Args:
            first_name: Recipient's first name (validated).

        Returns:
            Formatted email body as a plain-text Markdown string.

        Raises:
            EmailTemplateError: If template generation fails.
        """
        try:
            subject = "Welcome to JSE Research Tool – Start Building Smarter Portfolios"
            preview = "Your free equity research sheet generator is ready. Let's get started."
            body = f"""
Hi {first_name},

Welcome! You've just taken the first step toward making more informed investment decisions on the Jamaica Stock Exchange.

We built the JSE Research Tool to give you the same kind of structured equity research that wealth management firms use — without the high cost or complexity.

**What you get:**
- One-click generation of a professional recommendation sheet for any JSE stock
- Key valuation metrics: P/E ratio, P/B ratio, dividend yield, and more
- A clear portfolio allocation signal (overweight / neutral / underweight)
- A clean summary you can share with your advisor or team

No spreadsheets. No manual calculations. Just the numbers that matter.

**How it works:**
1. Enter a JSE ticker (e.g., SEP, TJH, CCC)
2. Our tool pulls real-time market data and calculates the metrics
3. You get a printable, shareable research sheet in seconds

We believe every investor deserves access to structured analysis. That's why the tool is open-source and hosted on GitHub — free to use, free to improve.

**Ready to see it in action?**
[Explore the Tool Now →]({self.base_url}/tool)

Happy investing,

{self.sender_name}
"""
            logger.debug("Email 1 generated for %s", first_name)
            return f"**Subject:** {subject}\n\n**Preview Text:** {preview}\n\n{body}"
        except Exception as e:
            logger.error("Failed to generate Email 1: %s", e)
            raise EmailTemplateError("Email 1 generation failed") from e

    def _generate_email_2(self, first_name: str) -> str:
        """
        Build Email 2: Advanced Features – Overweight/Underweight Logic.

        Args:
            first_name: Recipient's first name (validated).

        Returns:
            Formatted email body.

        Raises:
            EmailTemplateError: If template generation fails.
        """
        try:
            subject = "Advanced Portfolio Logic: Overweight vs. Underweight"
            preview = "How the tool tells you which stocks to emphasize (and which to trim)."
            body = f"""
Hi {first_name},

Last time we showed you the high-level research sheet. Now let's dig into the feature that makes it truly actionable: the **portfolio allocation recommendation**.

At the bottom of every sheet, you'll see one of three signals:

- **Overweight** – The tool suggests allocating a larger percentage of your portfolio to this stock relative to its index weight.
- **Neutral** – Hold at market weight.
- **Underweight** – Consider reducing exposure.

**How does it decide?**

The logic combines two key valuation ratios:

- **P/E Ratio (Price-to-Earnings)**  
  *Example: CCC at 12.93x*  
  A low P/E can signal undervaluation (potential overweight). A very high P/E may indicate overvaluation (underweight).

- **P/B Ratio (Price-to-Book)**  
  *Example: TJH at 6.46x*  
  A high P/B is common for companies with stable cash flows (like toll roads), but extreme values may flag risk.

The tool also factors in dividend yield and historical ranges to avoid overreacting to short-term noise.

**Why does this matter?**

Most retail investors either buy without a plan or hold too many equal-weight positions. The overweight/underweight system gives you a clear, data-backed rule for adjusting your holdings.

**Try it on any JSE stock and see the recommendation for yourself.**
[Try the Overweight/Underweight Feature →]({self.base_url}/allocation)

If you have questions about how the logic works under the hood, the full algorithm is documented on our GitHub repo: [{self.github_url}]({self.github_url}).

Keep building,

{self.sender_name}
"""
            logger.debug("Email 2 generated for %s", first_name)
            return f"**Subject:** {subject}\n\n**Preview Text:** {preview}\n\n{body}"
        except Exception as e:
            logger.error("Failed to generate Email 2: %s", e)
            raise EmailTemplateError("Email 2 generation failed") from e

    def _generate_email_3(self, first_name: str) -> str:
        """
        Build Email 3: Case Study – Seprod, TJH, CCC.

        Args:
            first_name: Recipient's first name (validated).

        Returns:
            Formatted email body.

        Raises:
            EmailTemplateError: If template generation fails.
        """
        try:
            subject = "Case Study: How We Analyzed SEP, TJH, CCC"
            preview = "Three JSE stocks, one framework. See the tool in action."
            body = f"""
Hi {first_name},

By now you've seen the dashboard and the allocation logic. Let's walk through a real-world example using three well-known JSE stocks.

### The Stocks

| Ticker | Company | Share Price |
|--------|---------|-------------|
| SEP | Seprod Limited | $81.73 |
| TJH | TransJamaican Highway Limited | Market price |
| CCC | Caribbean Cement Company Limited | Market price |

### What the Tool Showed

**1. Seprod (SEP) – P/E: 13.46x**  
- P/E below market average suggests moderate valuation.  
- Recommendation: **Neutral to Overweight** (depends on growth outlook).

**2. TransJamaican Highway (TJH) – P/B: 6.46x, Div Yield: 3.73%**  
- High P/B reflects infrastructure asset value; stable dividend yield provides income.  
- Recommendation: **Neutral** (hold for yield, but watch valuation).

**3. Caribbean Cement (CCC) – P/E: 12.93x**  
- P/E similar to Seprod; sector dynamics (construction demand) may justify overweight.  
- Recommendation: **Overweight** if fundamentals support growth.

### The Big Picture

By comparing these three through the same lens, you can quickly see where the tool suggests concentration and where it flags caution. No guesswork — just the numbers.

**Now it's your turn.** Pick any JSE stock and run the analysis.
[Run Your Own Analysis →]({self.base_url}/tool)

Thank you for being part of the early community. We'll keep adding features — including historical comparisons and sector filters — based on your feedback.

Stay tuned,

{self.sender_name}

---

*P.S. The tool is open-source. If you're a developer or data analyst, contributions are welcome on GitHub: [{self.github_url}]({self.github_url}).*
"""
            logger.debug("Email 3 generated for %s", first_name)
            return f"**Subject:** {subject}\n\n**Preview Text:** {preview}\n\n{body}"
        except Exception as e:
            logger.error("Failed to generate Email 3: %s", e)
            raise EmailTemplateError("Email 3 generation failed") from e

    def generate_sequence(self, first_name: str) -> List[str]:
        """
        Generate the full 3-email welcome sequence for a given user.

        Args:
            first_name: Recipient's first name (will be validated and sanitized).

        Returns:
            List of three email strings (each includes subject, preview, and body).

        Raises:
            ValueError: If first_name is invalid.
            EmailTemplateError: If any email generation fails.
        """
        validated_name = self._validate_first_name(first_name)
        logger.info("Generating email sequence for %s", validated_name)
        try:
            email1 = self._generate_email_1(validated_name)
            email2 = self._generate_email_2(validated_name)
            email3 = self._generate_email_3(validated_name)
            logger.info("Sequence generation completed for %s", validated_name)
            return [email1, email2, email3]
        except EmailTemplateError:
            logger.error("Sequence generation failed for %s", validated_name)
            raise
        except Exception as e:
            logger.critical("Unexpected error generating sequence: %s", e)
            raise EmailTemplateError("Unexpected sequence generation failure") from e


# Example usage (production would use environment variables for URLs)
if __name__ == "__main__":
    try:
        generator = EmailGenerator(
            sender_name="JSE Research Team",
            base_url="https://jse-research-tool.example.com",
            github_url="https://github.com/jse-research/tool",
        )
        sequence = generator.generate_sequence("John")
        for i, email in enumerate(sequence, 1):
            print(f"=== EMAIL {i} ===\n{email}\n")
    except (ValueError, EmailTemplateError) as err:
        logger.error("Failed to generate sequence: %s", err)