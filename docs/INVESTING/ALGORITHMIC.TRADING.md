# Algorithmic Trading

Algorithmic trading turns research signals into explicit action rules. Instead of relying on mood or impulse, the investor defines conditions for buying, selling, holding, or reviewing.

The simplest structure is:

- If a measurable buy condition occurs, buy.
- If a measurable sell condition occurs, sell.
- If no condition occurs, do nothing.

The hard part is defining conditions that are measurable, testable, and durable.

## Nonfinancial Data

Investment analysis often uses three broad data flows:

- Fundamental data: financial statements, ratios, filings, and company disclosures.
- Technical data: prices, volume, volatility, and market behavior.
- Nonfinancial data: media, sentiment, movement, demographics, weather, regulation, leadership, disasters, and other external signals.

[Image placeholder: Fundamental, technical, and nonfinancial data flows with different update frequencies. Source: `Investing.for.Programmers-2025-11.pdf`, Fig. 11.1.]

Nonfinancial data can be valuable because it may reveal information not fully captured in financial statements or price charts.

Useful nonfinancial data can include:

- News and media coverage.
- Social sentiment.
- Search trends.
- Product reviews.
- Employee sentiment.
- Insider activity.
- Geolocation and movement data.
- Satellite or image-based observations.
- Demographic changes.
- Regulatory signals.
- Weather and climate events.
- Supply-chain activity.

Nonfinancial data is not equally useful for every industry. Social sentiment may matter more for consumer brands than for business-to-business suppliers. Weather may matter more for agriculture, insurance, energy, or travel than for software.

## Big Data By Example

Nonfinancial data should support a thesis. Do not collect unusual data just because it exists.

> Example:
>
> Thesis: a robotaxi service may become a major growth driver for a parent company.
>
> Useful evidence could include:
>
> - Number of rides per week.
> - Expansion into new cities.
> - Accident reports.
> - Customer sentiment.
> - Regulatory approvals.
> - Fleet size.
> - Mentions in local news.

The value of underused data is that it may give the investor an edge before the broader market recognizes the trend.

## Media

Media analysis can reveal attention, sentiment, and changing narratives.

Questions to ask:

- Is the company mentioned more often over time?
- Is coverage positive, negative, or neutral?
- Are new topics appearing?
- Are important deployments on schedule?
- Are customer complaints increasing?
- Are expert opinions changing?

Media data can be noisy. A loud story is not always an important story.

## Movement Data

Movement data can reveal what is happening in the physical world.

Examples:

- Counting cars in parking lots.
- Tracking store traffic.
- Measuring shipping activity.
- Monitoring factory or port movement.
- Estimating fleet expansion.

Movement data can be powerful, but it may require specialized collection, cleaning, and interpretation.

## Demographic Data

Demographic data helps estimate future demand.

Examples:

- Aging populations may increase demand for healthcare, hearing aids, mobility services, and assisted living.
- Younger populations may increase demand for education, entertainment, housing, or consumer technology.
- Urbanization may increase demand for transport, logistics, infrastructure, and housing.

Demographics are usually slow-moving, which makes them more useful for long-term theses than short-term trades.

## Catalysts

A catalyst is an event that can move an asset price sharply.

Common catalysts include:

- Earnings reports.
- Analyst upgrades or downgrades.
- Product announcements.
- Lawsuits.
- Regulatory changes.
- Mergers and acquisitions.
- Bankruptcy filings.
- Activist-investor involvement.
- Natural disasters.
- War or geopolitical shocks.
- Interest-rate changes.

Catalysts can create opportunity or risk. They are especially important for traders and for investors deciding whether to add, reduce, or review a position.

## Mergers And Acquisitions

Companies move through phases: introduction, growth, maturity, saturation, decline, and sometimes rebirth.

[Image placeholder: Company lifecycle showing a possible merger or acquisition window during decline and potential rebirth. Source: `Investing.for.Programmers-2025-11.pdf`, Fig. 11.2.]

Mergers and acquisitions can change a company's path.

A merger combines companies, ideally creating more value together than separately. An acquisition is usually one company absorbing another.

Possible benefits:

- Expanded product range.
- Larger customer base.
- Cost savings.
- Stronger market position.
- Access to talent or technology.
- Faster entry into a new market.

Possible risks:

- Culture clash.
- Integration failure.
- Overpayment.
- Management distraction.
- Employee resistance.
- Unrealistic synergy claims.
- Destroyed shareholder value.

Mergers can look attractive on paper and still fail in practice.

## Companies In Distress

Distressed-company investing looks for companies that are deeply undervalued because the market fears failure.

[Image placeholder: Distressed-company workflow showing bankruptcy, possible reopening, or closure. Source: `Investing.for.Programmers-2025-11.pdf`, Fig. 11.3.]

Potential opportunity:

- Investors panic and sell too aggressively.
- Valuable assets remain.
- A buyer may appear.
- A restructuring may preserve equity value.
- A turnaround may occur.

Major risk:

- Equity can be wiped out.
- Creditors may take control.
- Bankruptcy can destroy existing shareholders.
- A rebound may never happen.

Distressed investing requires deep research and high risk tolerance.

> Example:
>
> A stalking horse agreement sets a floor price for asset sale in a bankruptcy process. This can reduce uncertainty, but it does not make the investment safe.

## Earnings Calls

Public companies report results regularly. Earnings calls can move prices when the company beats, misses, or changes expectations.

Before an earnings call, investors may review:

- Analyst expectations.
- Prior guidance.
- Recent product news.
- Insider buying or selling.
- New or lost contracts.
- Sector conditions.
- Management tone from prior calls.

After the call, investors may review:

- Revenue and earnings surprise.
- Margin changes.
- Cash flow.
- Guidance.
- Management confidence.
- Mentioned risks.
- Analyst questions.
- Changes in customer demand.

Trading around earnings can be risky because prices may move sharply in either direction. Leverage and options can magnify both gains and losses.

## Disasters

Disasters can create winners and losers.

Examples:

- Pandemics may hurt travel and transport while helping some healthcare or remote-service businesses.
- Wildfires and hurricanes may hurt insurers while increasing demand for mitigation technologies.
- Wars may harm exposed economies while increasing defense demand.

The goal is not to profit from suffering. The investment question is whether the portfolio understands how large events change demand, cost, supply, and risk.

## Interest Rate Changes

Interest rates affect borrowing costs, investor behavior, and asset valuation.

Low interest rates can:

- Encourage borrowing.
- Support investment.
- Increase speculation.
- Boost capital-intensive companies.
- Raise inflation risk.

High interest rates can:

- Make borrowing expensive.
- Reduce investment appetite.
- Pressure companies with high cash needs.
- Increase bankruptcy risk.
- Make bonds and cash-like assets more attractive.

One possible strategy is to study capital-intensive companies when rates are high and prices are depressed. The danger is that some companies may not survive long enough to benefit from lower rates.

## Trading Algorithms

Trading algorithms need quantifiable signals.

Examples of rule-based signals:

- Price crosses a moving average.
- Short-term average crosses long-term average.
- Sentiment score crosses a threshold.
- Insider activity changes.
- Related assets move together.
- A catalyst occurs.
- Volatility expands.
- Volume rises above normal.

Every signal should be testable against historical data before real money is used.

## Backtesting

Backtesting evaluates a trading strategy on historical data.

A simple moving-average crossover strategy:

- Buy when the short-period moving average crosses above the long-period moving average.
- Sell when the short-period moving average crosses below the long-period moving average.

Backtesting should compare the strategy with a baseline, such as buying on the first day and holding until the end.

A fair backtest should consider:

- Transaction costs.
- Bid-ask spread.
- Slippage.
- Taxes.
- Data quality.
- Survivorship bias.
- Whether historical prices reflect splits or corporate actions.
- Whether the strategy was tuned too closely to past data.

### SMA Crossover Results For NVIDIA

| SMA low window | SMA high window | Gains |
| ---: | ---: | ---: |
| 90 | 120 | $309,821.27 |
| 100 | 110 | $301,097.67 |
| 60 | 160 | $300,504.11 |
| 50 | 110 | $298,242.05 |
| 50 | 180 | $297,201.84 |

These results illustrate that parameter choice matters. A strategy can fail with one setup and look successful with another.

### Backtest Results Across Companies

| Ticker | Lower SMA | Upper SMA | Gain | Baseline to beat |
| --- | ---: | ---: | ---: | ---: |
| KO | 100 | 110 | $664 | $1,042 |
| MMM | 120 | 190 | $810 | $310 |
| PFE | 110 | 180 | $1,243.55 | $312.55 |
| AAPL | 160 | 170 | $10,136.21 | $9,258.81 |
| MSFT | 80 | 140 | $10,240.63 | $9,514.61 |

One strategy will not beat the baseline for every asset. Backtesting is useful because it makes this visible before capital is committed.

## Complex Trading Signals

Simple rules can be expanded into scorecards.

Possible signal scores:

- Price movement score: related assets rising or falling.
- Keyword score: selected words or themes appearing more often in monitored sources.
- Insider score: executives or institutions buying or selling.
- Sentiment score: media or social tone changing.
- Catalyst score: major event likelihood or impact.
- Risk score: macro, regulatory, or geopolitical pressure.

A trading signal must be:

- Measurable.
- Comparable over time.
- Available at decision time.
- Linked to a clear action.
- Tested before use.

Nonfinancial signals can be hard to compare because sources change. A sentiment score from one media pool may not match a score from another.

## Trading Costs And Slippage

Backtests often look cleaner than reality.

Real trading has frictions:

- Bid-ask spread.
- Transaction costs.
- Taxes.
- Slippage.
- Delayed execution.
- Partial fills.
- Data delays.
- Liquidity limits.

Slippage is the gap between the price a strategy expects and the price actually received.

Frequent trading can turn a profitable-looking strategy into a losing one once costs are included.

## Orders

An order is an instruction to buy or sell an asset under defined conditions.

An investment decision is not the same as execution. A good idea can still suffer from poor order handling, low liquidity, bad timing, or misunderstood order terms.

## Exchanges And Brokers

An exchange is a marketplace where buyers and sellers trade assets. A broker is an intermediary that gives investors access to one or more exchanges.

[Image placeholder: Exchange model showing direct buyers and sellers, and broker model showing brokerage between buyers and sellers. Source: `Investing.for.Programmers-2025-11.pdf`, Fig. 11.4.]

Brokers differ by:

- Supported exchanges.
- Supported assets.
- Fees.
- Data freshness.
- Order types.
- Margin and leverage rules.
- Investor protections.
- International access.
- Currency handling.

Crypto exchanges differ from stock exchanges because regulation, custody, transparency, and investor protection can vary widely. Holding crypto on an exchange can also mean relying on the exchange's custody and operational quality.

## High-Frequency Trading

High-frequency trading uses very fast systems to place many trades in fractions of a second.

It depends on:

- Low-latency infrastructure.
- Fast market access.
- Sophisticated algorithms.
- Co-location near exchanges.
- Tiny repeated price advantages.

This is a professional domain with major operational and infrastructure demands. Most individual investors should understand that it exists, not assume they can compete casually.

## Order Types

| Order type | Description |
| --- | --- |
| Market order | Buy or sell immediately at the available market price. Fast, but the final price may differ from expectation. |
| Limit order | Buy or sell only at a chosen price or better. Gives price control, but may not execute. |
| Stop order | Trigger a market order when a stop price is reached. Often used to limit losses. |
| Stop-limit order | Trigger a limit order when a stop price is reached. Gives more control, but the order may not fill if the market moves too quickly. |
| Trailing stop | Adjust the stop level as the asset price moves favorably, then trigger if the price reverses by a set amount. |

Order types shape execution risk. A market order prioritizes completion. A limit order prioritizes price. A stop order prioritizes protection. A stop-limit order adds price control but can fail to execute.

## Order Modalities

| Order modality | Description |
| --- | --- |
| Fill or kill | Execute the entire order immediately or cancel it. Useful when partial execution is unacceptable. |
| Good til canceled | Keep the order active until executed, canceled, or expired by broker rules. Useful for standing stop-loss or limit orders. |

Modalities change how long an order lives and whether partial execution is acceptable.

## Executing Orders

Before executing orders, an investor should confirm:

- Is the asset tradable through the chosen broker?
- Which exchange or venue will be used?
- Is the quoted price live or delayed?
- What is the bid-ask spread?
- What fees apply?
- Is the order real or simulated?
- Is the order size reasonable for liquidity?
- What happens if the order only partially fills?
- What risk controls are active?

Paper trading or simulated trading can help test execution logic without risking real money.

Real orders should be treated carefully. Once submitted, execution may happen faster than the investor can rethink the decision.

## Using Strategy Tests Well

Backtesting and algorithmic signals are decision-support tools. They are not magic.

A disciplined testing process should:

- Define the rule before testing.
- Use clean historical data.
- Compare against a baseline.
- Include costs.
- Test across multiple assets and periods.
- Avoid tuning only to one lucky period.
- Preserve failed tests.
- Separate research from real execution.

The durable lesson is that algorithmic trading forces clarity. If a strategy cannot be written as measurable rules, it cannot be tested. If it cannot be tested, it should not be automated.
