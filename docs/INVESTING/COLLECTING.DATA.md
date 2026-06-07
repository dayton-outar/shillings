# Collecting Data

Investment research depends on data. The problem is not only finding data. The harder problem is deciding whether the data is reliable, comparable, current, complete, and useful for the decision being made.

Financial data is often cleaner than data in many other domains because public companies must report through formal accounting standards. That does not make it perfect. Accounting choices can still hide weakness, exaggerate strength, or make two companies hard to compare.

The goal of data collection is not to gather everything. The goal is to gather enough trustworthy evidence to support better judgment.

## Financial Data

Financial investment data usually falls into three groups:

- Fundamental data: financial statements, ratios, filings, company disclosures, and other business-performance information.
- Technical data: prices, volume, trading activity, volatility, and market history.
- Nonfinancial data: news, leadership changes, product launches, sentiment, regulation, ESG data, customer behavior, and industry signals.

Each type has a different rhythm.

- Fundamental data changes slowly, often quarterly.
- Technical data changes constantly while markets are open.
- Nonfinancial data can change at any time and may be harder to verify.

Fundamental analysis compares business quality. Technical analysis studies market behavior. Nonfinancial analysis adds context that numbers may miss.

> Example: A company may report strong earnings, but management may sound evasive during an earnings call. That nonfinancial signal does not prove anything by itself, but it can tell the investor to investigate further.

Ethics also matter. Modern tools can analyze speech, video, and sentiment, but investors should be careful when using personal or behavioral data. Just because something can be measured does not mean it should be used without limits.

## Financial Analysis Platforms

There are tens of thousands of listed companies across global markets. A user cannot study all of them manually. Screening tools help narrow the universe.

A screener lets investors filter companies by criteria such as:

- Sector.
- Country.
- Market capitalization.
- Valuation.
- Profitability.
- Dividend yield.
- Debt.
- Growth.
- Analyst rating.

> Example: An investor who understands software businesses may search for large non-domestic technology companies, then study the few companies that pass the filter.

Screeners are landing zones. They are useful for preselection, but not for final decisions. A company that passes a filter still needs deeper research.

## Types of Financial Platforms

| Platform category | Common examples | What they are useful for | Main caution |
| --- | --- | --- | --- |
| General finance pages | Search-engine finance pages and market quote pages | Quick lookups, prices, headlines, basic statements | Coverage and structure may change; data may not be suitable for production decisions |
| Advisory platforms | Private-investor research and rating services | Opinions, ratings, screeners, model portfolios, deeper commentary | Often subscription-based; opinions can be biased or wrong |
| Data providers | Dedicated market-data providers | Structured access, broader coverage, higher request limits, more reliability | Cost, licensing, quotas, and contract terms matter |
| Professional terminals | Institutional research and trading products | Deep data, analytics, news, and professional workflows | Usually too expensive for small teams or individual investors |

The right source depends on the use case. Personal exploration can tolerate more inconvenience. A public platform used by customers needs more reliability, rights, monitoring, and fallback plans.

## Research Workspaces

Investment research is often exploratory. A user may start with a question, test a few ideas, compare assets, change assumptions, and return later.

A good research workspace should allow the user to:

- Write down a hypothesis.
- Pull in relevant data.
- Compare companies.
- Rerun analysis with different assumptions.
- Keep notes beside numbers.
- Preserve the path from question to conclusion.

For personal research, a full product interface may be unnecessary at first. The important thing is a repeatable workspace where data, reasoning, and results stay connected.

## Fundamental Data Collection

Fundamental data includes income statements, balance sheets, and cash flow statements. A useful structure usually places reporting dates across one axis and statement line items across the other.

| Income statement line item | 2024-06-30 | 2023-06-30 | 2022-06-30 | 2021-06-30 |
| --- | ---: | ---: | ---: | ---: |
| Tax effect of unusual items | -99,918,000.0 | -2,850,000.0 | 43,754,000.0 | 180,160,797.164637 |
| Tax rate for calculations | 0.182 | 0.19 | 0.131 | 0.138266 |
| Normalized EBITDA | 133,558,000,000.0 | 105,155,000,000.0 | 99,905,000,000.0 | 83,031,000,000.0 |
| Total unusual item | -549,000,000.0 | -15,000,000.0 | 334,000,000.0 | 1,303,000,000.0 |
| Net income from continuing operations | 88,136,000,000.0 | 72,361,000,000.0 | 72,738,000,000.0 | 61,271,000,000.0 |
| Reconciled depreciation | 22,287,000,000.0 | 13,861,000,000.0 | 14,461,000,000.0 | 11,686,000,000.0 |
| Reconciled cost of revenue | 74,114,000,000.0 | 65,863,000,000.0 | 62,650,000,000.0 | 52,232,000,000.0 |
| EBITDA | 133,009,000,000.0 | 105,140,000,000.0 | 100,239,000,000.0 | 85,134,000,000.0 |
| EBIT | 110,722,000,000.0 | 91,279,000,000.0 | 85,779,000,000.0 | 73,448,000,000.0 |

This table illustrates why structured data matters. Once financial statement data is organized consistently, the platform can calculate ratios, compare years, and watch for unusual changes.

For ratios that are not already provided, the platform should derive them from source statements.

| Ratio | How to calculate it |
| --- | --- |
| Return on assets | $\large{\frac{\text{net income}}{\text{total assets}} \times 100}$ |
| Return on equity | $\large{\frac{\text{net income}}{\text{shareholders' equity}} \times 100}$ |
| Profit margin | $\large{\frac{\text{net income}}{\text{total revenue}} \times 100}$ |
| Asset turnover | $\large{\frac{\text{total revenue}}{\text{total assets}}}$ |
| Debt-to-equity | $\large{\frac{\text{total debt}}{\text{shareholders' equity}}}$ |

Ratios should also be tracked over time. A high ratio may be normal for a company. A sudden change may be the real warning.

## Technical Data Collection

Technical data records market behavior. A typical price-history table includes date, open, high, low, close, and volume.

| Date | Open price | High price | Low price | Close price | Volume |
| --- | ---: | ---: | ---: | ---: | ---: |
| 2025-05-07 | 433.05 | 437.32 | 430.32 | 432.56 | 23,295,300 |
| 2025-05-06 | 431.41 | 436.93 | 430.38 | 432.52 | 15,104,200 |
| 2025-05-05 | 432.08 | 438.69 | 431.32 | 435.37 | 20,136,100 |
| 2025-05-02 | 430.95 | 438.63 | 429.20 | 434.48 | 30,757,400 |
| 2025-05-01 | 430.32 | 436.19 | 424.12 | 424.62 | 58,938,100 |

Price alone is not enough for comparison. A $1,000 share is not automatically more expensive than a $10 share. Share count matters. Splits can also change the price without changing the economic value of the holding.

To compare price movement across assets, normalize each asset to the same starting point, such as 100%.

One year can tell a misleading story. A stock that looks weak in one period may surge in another.

## Returns

Daily return compares today's closing price with the previous closing price.

Simple return:

$\large{\text{Simple return}_t = \frac{P_t - P_{t-1}}{P_{t-1}}}$

Log return:

$\large{\text{Log return}_t = \ln\left(\frac{P_t}{P_{t-1}}\right)}$

Simple returns are easy to understand. Log returns are often useful for statistical analysis because they behave better when returns compound over time.

A histogram can show how returns are distributed and whether a stock has many extreme days.

![Histogram of returns for Apple, Coca-Cola, and NuScale](/.attachments/3.5-histogram.returns.aapl.ko.smr.png)

_Histogram of returns for Apple, Coca-Cola, and NuScale_

| Company | Mean | Standard deviation | Variance |
| --- | ---: | ---: | ---: |
| Coca-Cola | -0.035349 | 0.134959 | 0.018214 |
| Apple | 0.442217 | 0.199222 | 0.039690 |
| NuScale | -1.149094 | 0.799615 | 0.639385 |

Mean is the average. Variance shows how spread out values are. Standard deviation is the square root of variance and is easier to compare because it uses the same scale as the original data.

$\large{\text{Variance} = \frac{\sum (x_i - \bar{x})^2}{n}}$

$\large{\text{Standard deviation} = \sqrt{\text{Variance}}}$

High variation means the stock may be more unpredictable. It can create opportunity, but it can also create pain.

## Data Source Limits

Not all data sources are equally reliable. Some sources are built on official feeds. Others gather data from web pages that can change without warning.

Common risks include:

- Page layouts changing.
- Access rules changing.
- Missing data.
- Delayed data.
- Incorrect identifiers.
- Limited international coverage.
- Paid features hidden behind subscriptions.
- Different naming conventions for exchanges or assets.

A platform should not depend on a single fragile source for important decisions.

## Data Providers

The cleanest model is that data providers gather:

- Fundamental data from regulators, company filings, annual reports, and official disclosures.
- Technical data from exchanges.
- Nonfinancial data from news, filings, company websites, transcripts, and other public sources.

![Simplified data-provider flow](/.attachments/3.7-financial.data.providers.png)

_Simplified data-provider flow_

Accounting statements may arrive quarterly. Price data may stream continuously while markets are open. The platform should treat these data types differently.

## Provider Categories and Packages

| Provider type | Typical package pattern | Useful when | Main caution |
| --- | --- | --- | --- |
| Screener-first platform | Usually has a paid tier for exports or advanced filtering | The user wants rich filters and a visual exploration flow | Coverage may be limited by market or region |
| Data-first provider | Often has free, limited, and paid tiers | The product needs structured data and higher request limits | Cost, quota, licensing, and coverage must be checked |
| Sentiment or news provider | May include text analysis and news feeds | The user wants nonfinancial signals | Sentiment can be noisy and should not replace research |
| Multi-asset provider | May cover stocks, currencies, fixed income, and digital assets | The product needs more than public equity data | Broad coverage can still vary in depth and quality |

Pricing and access rules change. The durable lesson is to evaluate quota, coverage, licensing, reliability, speed, and support before depending on a provider.

## Exchange Coverage

International coverage matters if the platform serves users beyond one country.

| Name | Code | Operating MIC | Country | Currency | Country ISO2 | Country ISO3 |
| --- | --- | --- | --- | --- | --- | --- |
| USA Stocks | US | XNAS, XNYS, OTCM | US | USD | US | US |
| London Stock Exchange | LSE | XLON | UK | GBP | GB | GBR |
| Toronto Exchange | TO | XTSE | Canada | CAD | CA | CAN |
| TSX Venture Exchange | V | XTSX | Canada | CAD | CA | CAN |
| NEO Exchange | NEO | NEOE | Canada | CAD | CA | CAN |

The platform should understand that exchanges, country codes, currencies, and asset identifiers are separate concepts.

## Historical Market Data Shape

Different providers often return similar market data: date, open, high, low, close, adjusted close, and volume.

| Date | Open | High | Low | Close | Adjusted close | Volume |
| --- | ---: | ---: | ---: | ---: | ---: | ---: |
| 2024-06-03 | 459.30000000 | 468.10000000 | 458.60000000 | 460.90000000 | 460.90000000 | 51,917,078 |
| 2024-06-04 | 460.20000000 | 462.70000000 | 448.00000000 | 448.00000000 | 448.00000000 | 31,952,811 |
| 2024-06-05 | 450.70000000 | 458.00000000 | 448.80000000 | 453.30000000 | 453.30000000 | 19,116,760 |
| 2024-06-06 | 458.00000000 | 463.10000000 | 450.50000000 | 458.20000000 | 458.20000000 | 19,410,820 |
| 2024-06-07 | 458.20000000 | 462.30000000 | 451.00000000 | 456.90000000 | 456.90000000 | 15,420,780 |

Adjusted close matters because it accounts for events such as splits and dividends. A provider that does not include adjusted close may be less useful for return analysis.

Some providers return data in different shapes. The same information may appear with dates as columns instead of rows.

| Type | 2025-06-06 | 2025-06-05 | 2025-06-04 | 2025-06-03 |
| --- | ---: | ---: | ---: | ---: |
| Open | 203.0000 | 203.5000 | 202.9100 | 201.3500 |
| High | 205.7000 | 204.7500 | 206.2400 | 203.7700 |
| Low | 202.0500 | 200.1500 | 202.1000 | 200.9550 |
| Close | 203.9200 | 200.6300 | 202.8200 | 203.2700 |
| Volume | 46,607,693 | 55,221,235 | 43,603,985 | 46,381,567 |

After reshaping, the same data can become easier to process:

| Date | Open | High | Low | Close | Volume |
| --- | ---: | ---: | ---: | ---: | ---: |
| 2025-06-06 | 203.0000 | 205.7000 | 202.0500 | 203.9200 | 46,607,693 |
| 2025-06-05 | 203.5000 | 203.5000 | 200.1500 | 200.6300 | 55,221,235 |
| 2025-06-04 | 202.9100 | 206.2400 | 202.1000 | 202.8200 | 43,603,985 |

The platform should normalize provider output before using it in analytics.

## Sentiment Data

News and sentiment data can add context to price and fundamentals.

![News sentiment results for a nuclear energy company from Alpha Vantage](/.attachments/3.11-sentiment.analysis.png)

_News sentiment results for a nuclear energy company from [Alpha Vantage: Market News & Sentiment](https://www.alphavantage.co/documentation/)_

Sentiment data is useful for:

- Spotting attention around a company.
- Finding positive or negative news clusters.
- Comparing market mood with fundamentals.
- Triggering deeper research.

Sentiment data is dangerous when treated as truth. A headline can be emotional, incomplete, or wrong.

## Multi-Asset Data

An investing platform should not assume that all users only care about stocks. A broader data system may need to support:

- Public equities.
- Currencies.
- Fixed income.
- Digital assets.
- Funds.
- Commodities.

| Date | Open | High | Low | Close | Volume |
| --- | ---: | ---: | ---: | ---: | ---: |
| 2023-06-26 | 42.460999 | 42.76400 | 40.099998 | 40.632000 | 594,322,000 |
| 2023-06-27 | 40.799000 | 41.93999 | 40.448002 | 41.875999 | 4,621,750,000 |
| 2023-06-28 | 40.660000 | 41.845001 | 40.518002 | 41.117001 | 582,639,000 |
| 2023-06-29 | 41.557999 | 41.599998 | 40.599998 | 40.821999 | 380,514,000 |
| 2023-06-30 | 41.680000 | 42.549999 | 41.500999 | 42.301998 | 501,148,000 |

The more asset classes the platform supports, the more careful it must be with identifiers, calendars, trading hours, currencies, and data conventions.

## Choosing Data Tools and Sources

A data source should be judged before it becomes part of a product.

Useful criteria:

- Recent maintenance or vendor support.
- Clear documentation.
- Multiple contributors or reliable support team.
- Broad enough exchange coverage.
- Reasonable licensing.
- Suitable request limits.
- Clear pricing.
- Stable identifiers.
- Support for adjusted prices.
- Ability to retrieve both fundamental and technical data.
- Compatibility with the platform's operating environment.
- Data quality monitoring.

Avoid sources that:

- Only support one region when the product needs global coverage.
- Require fragile scraping for important workflows.
- Have unclear licensing.
- Hide critical data behind unpredictable paywalls.
- Are no longer maintained.
- Return inconsistent data without warning.

Data collection is not a one-time setup. It is a continuing responsibility.
