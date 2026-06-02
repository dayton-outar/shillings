# Risk Management

Risk management is the discipline of deciding what could go wrong before loss forces the lesson. It does not remove uncertainty. It helps the investor survive uncertainty with clearer rules, better measurements, and fewer emotional decisions.

Return analysis asks, "What can I gain?" Risk analysis asks, "What can I lose, how likely is it, and what will I do if it happens?"

Both questions matter.

## Ukemi

In martial arts, students learn how to fall before they learn how to attack. Investing needs the same mindset. Before chasing upside, define how the portfolio will handle setbacks.

Risk controls feel slow when markets are exciting. They become valuable when stress arrives.

## Stop-Loss

A stop-loss order is an instruction to sell a position if it falls to a chosen price. It acts like a predefined exit rule.

> Example:
>
> An investor buys a stock at $8. The price rises to $25. Instead of selling immediately, the investor raises the stop-loss to $22. If the stock keeps rising, the investor stays invested. If it falls below $22, the position is sold and most of the gain is protected.

[Image placeholder: Stop-loss order adjusted upward after a share-price rise and triggered after a later fall. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.1.]

Stop-losses are useful, but they have tradeoffs:

- Taxes: selling a profitable position can create taxable gains.
- Transaction costs: selling and rebuying can create fees and spread costs.
- Temporary fluctuations: a brief drop can trigger a sale before the price recovers.

Stop-losses are simple protection. More advanced tools, such as options, can protect downside while preserving some upside, but they add complexity and cost.

## Risk Classification

Risk classification helps investors focus on what matters most. A small daily price swing is different from a company facing bankruptcy.

Common financial risks include:

- Market risk: broad market declines affect many assets at once.
- Sector risk: one industry faces pressure from regulation, technology, demand, or costs.
- Asset-specific risk: one company suffers from mismanagement, weak products, scandals, debt, or poor execution.

Investors should avoid spending too much attention on small, easy-to-discuss issues while ignoring larger threats.

> Example:
>
> A temporary 5% decline in one strong company may matter less than a different holding approaching default. The visible problem is not always the most dangerous one.

Consistent compounding can beat occasional large wins.

$\large{P(1+i)^n}$

Where:

- $P$ is the starting capital.
- $i$ is the annual return.
- $n$ is the number of years.

> Example:
>
> If $100,000 compounds at 10% for 10 years:
>
> $\large{100{,}000(1.1)^{10} = 259{,}374}$
>
> A single lucky doubling to $200,000 can still lose to steady compounding.

## Risk Measurement

Risk measurement turns vague fear into something an investor can compare.

Before investing, ask:

- What could go wrong?
- Which risks are most severe?
- Which risks are most likely?
- Which risks are internal to the company?
- Which risks come from markets, politics, regulation, or society?
- What action will I take if the risk becomes real?

[Image placeholder: High-level risk model for an AI startup, including funding, management, demand, regulation, politics, energy prices, and disruption. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.2.]

A risk matrix classifies threats by likelihood and harm severity.

[Image placeholder: Risk matrix mapping likelihood against harm severity. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.3.]

| Likelihood | Minor | Marginal | Critical | Catastrophic |
| --- | --- | --- | --- | --- |
| Certain | High | High | Very high | Very high |
| Likely | Medium | High | High | Very high |
| Possible | Low | Medium | High | Very high |
| Unlikely | Low | Medium | Medium | High |
| Rare | Low | Low | Medium | Medium |
| Eliminated | Eliminated | Eliminated | Eliminated | Eliminated |

The most useful risk rules are written before panic arrives.

> Example:
>
> If a trade-war risk becomes certain and one company in the portfolio would be critically harmed, the investor may have a rule to reduce or sell that position. The value of the rule is that it was chosen before emotion took over.

Beta is another risk measure:

- $\large{\beta = 1}$: the asset tends to move with the market.
- $\large{\beta > 1}$: the asset tends to move more than the market.
- $\large{\beta < 1}$: the asset tends to move less than the market.

Beta can help compare market sensitivity, but it does not capture every company-specific risk.

## Value At Risk

Value at risk, or VaR, estimates the possible loss of an investment or portfolio over a time period at a chosen confidence level.

> Example:
>
> A $1,000,000 portfolio has a one-day VaR of $30,000 at 95% confidence. This means the model estimates that 95% of the time, the portfolio should not lose more than $30,000 in one day. The remaining 5% can be worse.

VaR can be estimated with:

- Variance-based methods: assume returns follow a statistical distribution.
- Monte Carlo simulation: simulate many possible outcomes from historical patterns.

[Image placeholder: Monte Carlo simulation showing a one-day loss threshold for Apple shares. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.4.]

VaR is useful under normal market conditions. It can fail during black swan events, which are rare, extreme, and hard to predict.

## Correlation

Correlation measures how assets move relative to one another.

- $\large{+1}$: assets move together perfectly.
- $\large{0}$: no clear relationship.
- $\large{-1}$: assets move in opposite directions perfectly.

Highly correlated assets can create hidden concentration. Owning many companies in the same industry may feel diversified, but they can still fall together.

### Share Price Statistics

| Company | Mean | Standard deviation | Variance |
| --- | ---: | ---: | ---: |
| Microsoft (MSFT) | 418.73445 | 18.19813 | 331.17207 |
| Amazon (AMZN) | 184.49020 | 17.32285 | 300.08126 |
| Alphabet (GOOGL) | 163.31029 | 15.40605 | 237.34623 |

Raw share prices are not enough for comparison. A higher price per share does not mean a better or larger company.

### Log Return Statistics

| Company | Mean | Standard deviation | Variance |
| --- | ---: | ---: | ---: |
| Microsoft | 0.14443 | 0.20078 | 0.04031 |
| Amazon | 0.39247 | 0.28154 | 0.07926 |
| Alphabet | 0.33129 | 0.28045 | 0.07865 |

Returns make comparison more meaningful because they focus on percentage movement.

### Covariance

| Company | MSFT | AMZN | GOOGL |
| --- | ---: | ---: | ---: |
| Microsoft | 0.04031 | 0.03887 | 0.03239 |
| Amazon | 0.03887 | 0.07926 | 0.04290 |
| Alphabet | 0.03239 | 0.04290 | 0.07865 |

Covariance shows whether assets tend to move together, but the scale is harder to interpret.

### Correlation

| Company | MSFT | AMZN | GOOGL |
| --- | ---: | ---: | ---: |
| Microsoft | 1.00000 | 0.68765 | 0.57522 |
| Amazon | 0.68765 | 1.00000 | 0.54331 |
| Alphabet | 0.57522 | 0.54331 | 1.00000 |

These companies show meaningful correlation, which makes sense because they share exposure to cloud computing, artificial intelligence, and large technology spending.

### Correlation Between Walmart And NVIDIA

| Company | WMT | NVDA |
| --- | ---: | ---: |
| Walmart | 1.00000 | -0.00532 |
| NVIDIA | -0.00532 | 1.00000 |

Low or negative correlation can reduce portfolio risk, though it may also reduce upside during strong growth periods.

## The Human Factor

Investing risk is not only market risk. The investor's own behavior can be the largest weakness.

Common human risks include:

- Greed.
- Fear.
- Fear of missing out.
- Loss aversion.
- Overconfidence.
- Refusal to admit mistakes.
- Panic selling.
- Chasing recent winners without understanding them.

A risk-aware investor reviews past decisions with evidence. What worked? What failed? Was the decision good but the outcome unlucky, or was the decision flawed?

Helpful controls include:

- Written investment rules.
- Position-size limits.
- Waiting periods before risky trades.
- Peer review.
- Risk profiles.
- Regular decision reviews.
- Clear exit conditions.

## Risk Avoidance

The simplest way to reduce risk is to choose safer assets and avoid strategies that exceed the investor's capacity.

Risk appetite is willingness to take risk. Risk capacity is the ability to survive loss. They are not the same.

Risk-reduction strategies include:

- Broad index investing.
- Dollar-cost averaging.
- Investing in businesses the investor understands.
- Keeping a margin of safety.
- Limiting position size.
- Avoiding leverage when unnecessary.
- Holding enough cash or liquid assets for emergencies.

Margin of safety means buying with a cushion. If the investor is wrong by a small amount, the investment should not fail immediately.

High-risk strategies include:

- Leverage: borrowed money can magnify both gains and losses.
- Short selling: losses can grow sharply if the asset rises.
- Derivatives: contracts can magnify outcomes and require specialized understanding.

Time horizon matters. A long-term investor can often survive short-term volatility. A short-term trader may face immediate losses, financing costs, and pressure to act quickly.

## Resilience

Resilience is the ability to make rational decisions after loss.

Loss aversion can trap investors. A losing position may feel "not really lost" until it is sold, but the market value has already changed. The better question is:

> Example:
>
> If I did not own this asset today, would I buy it now?

If the answer is no, holding may be emotional rather than rational. If the answer is yes, the decline may be an opportunity. The difference depends on evidence, not hope.

## Hedging

Hedging means reducing possible loss by taking an offsetting position. It is similar to insurance: the investor gives up some upside or pays a cost to reduce damage from a bad outcome.

Hedging does not remove risk. It changes the shape of risk.

## Derivatives

Derivatives are contracts whose value depends on an underlying asset.

Common types include:

- Options: give a right to buy or sell under specific terms.
- Futures: lock in a future transaction price.
- Swaps: exchange one set of cash flows or exposures for another.

> Example:
>
> Put option: an investor owns shares bought at $100 and buys the right to sell at $95. If the stock falls below $95, the put limits the loss. If the stock stays above $95, the investor paid for protection they did not need.

> Example:
>
> Futures: a farmer locks in a future selling price before harvest. If market prices later fall, the farmer is protected from the full decline.

> Example:
>
> Currency swap: two companies in different countries exchange currency exposure so each can fund operations more efficiently in the currency it needs.

Options can also be used for income strategies, but they can be complex.

- Covered call: sell a call option against shares already owned.
- Cash-secured put: sell a put while holding enough cash to buy the shares if assigned.
- Iron condor: combine options to profit if the asset remains within a range, while using additional options to limit maximum loss.

These strategies require careful study because a small misunderstanding can create large losses.

## Diversification

Diversification reduces dependence on one asset, sector, country, currency, or strategy.

Owning several companies in the same sector may not be enough. If the same event affects all of them, the portfolio can still suffer heavily.

Better diversification may include:

- Different sectors.
- Different countries.
- Different currencies.
- Different asset classes.
- Different income sources.
- Different time horizons.
- Assets with lower correlation.

Diversification can reduce extreme loss, but it can also reduce exceptional upside.

## Pair Trading

Pair trading is a strategy where the investor goes long one asset and short another related asset. The goal is to profit from relative performance rather than overall market direction.

[Image placeholder: Pair-trading scenarios showing long exposure to one company and short exposure to another. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.5.]

> Example:
>
> An investor believes Company A is stronger than Company B in the same sector. The investor buys Company A and shorts Company B. If the sector rises, Company A may rise more. If the sector falls, the short position may offset some losses.

Pair trading still has risks:

- The long position can fall.
- The short position can rise.
- Borrowing costs can reduce returns.
- Both sides can move against the investor.
- The relationship between the assets can break.

## Risk Pairing

Risk pairing means balancing speculative investments with stable holdings.

> Example:
>
> An investor keeps 80% of the portfolio in broad, stable assets and 20% in high-risk emerging technologies. If the speculative portion fails, the financial foundation survives.

Staged investing can also help. Instead of committing all capital at once, the investor adds smaller amounts over time as evidence improves.

## Catalysts And Events

Some events can change risk quickly:

- Earnings reports.
- Product launches.
- Lawsuits.
- Regulatory decisions.
- Credit-rating changes.
- Leadership changes.
- Mergers or acquisitions.
- Geopolitical events.
- Major customer wins or losses.

A risk plan should define which events require review and what evidence would justify action.

## Nonfinancial Risk

Nonfinancial risks are risks not fully visible in financial statements.

Examples include:

- Operational risk: outages, breaches, failed processes.
- Regulatory risk: lawsuits, fines, compliance changes.
- ESG risk: environmental, social, and governance concerns.
- Technology-obsolescence risk: a product becomes outdated.
- Political risk: instability, trade restrictions, policy shifts.
- Reputation risk: trust or brand damage.
- Management risk: poor leadership, turnover, culture problems.

Nonfinancial risks are harder to measure because there is no single universal database for them. They often require judgment, source comparison, and scenario thinking.

## Markets

Market mood affects risk. Rising markets can make investors overconfident. Falling markets can create fear, forced selling, and permanent mistakes.

The hard part is deciding whether a decline is temporary or a sign that the thesis has broken.

Investors should ask:

- Is the whole market falling, or only this asset?
- Did the investment thesis change?
- Is the company still financially strong?
- Is the decline caused by fear, fundamentals, or both?
- Would I buy this asset today?

## Economic Data

Economic indicators can help estimate broad market risk, though they do not predict the future perfectly.

[Image placeholder: 10-year Treasury yield minus 2-year Treasury yield as a recession-risk indicator. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.6.]

[Image placeholder: Unemployment rate over time with recession periods shown. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.7.]

Indicators can conflict. Some experts may expect crisis while others expect growth. The investor should treat indicators as signals, not certainties.

## Assessing Nonfinancial Risk

Nonfinancial risk assessment can use:

- News reports.
- Social sentiment.
- Legal filings.
- Weather and climate data.
- Regulatory documents.
- Management communication.
- Employee signals.
- Customer complaints.
- Supplier information.
- Political and country-risk analysis.

Because these risks are subjective, different analysts may reach different conclusions. A platform should preserve assumptions and source evidence instead of presenting the score as unquestionable truth.

## Portfolio Optimization

Portfolio optimization asks how to combine assets so the portfolio has a better balance of risk and return.

## Markowitz-Efficient Portfolio

A Markowitz-efficient portfolio is a portfolio that offers the highest expected return for a given level of risk, or the lowest risk for a given level of return.

The efficient frontier is the set of these optimal portfolios.

The Sharpe ratio measures risk-adjusted return:

$\large{\text{Sharpe ratio} = \frac{\text{portfolio return} - \text{risk-free rate}}{\text{portfolio volatility}}}$

A higher Sharpe ratio means more return per unit of risk.

The risk-free rate is a baseline return from an asset treated as having very low default risk, such as short-term government debt. It is not the average stock-market return.

[Image placeholder: Annual market returns from 1950 onward. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.8.]

[Image placeholder: Efficient frontier showing simulated portfolios and the highest-Sharpe portfolio. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.9.]

### Markowitz Portfolio Calculation

| Stock | Optimal weight |
| --- | ---: |
| AAPL | 0.045226 |
| WMT | 0.015196 |
| GOOGL | 0.005023 |
| KO | 0.004842 |
| PFE | 0.293244 |
| BRK-B | 0.000245 |
| NVDA | 0.636224 |

These results are based on historical data and assumptions. If the time period or risk-free rate changes, the result can change. Portfolio optimization helps manage risk; it does not guarantee future performance.

## Shiller P/E Ratio

The Shiller P/E ratio, also called CAPE, compares current market price with average inflation-adjusted earnings over the past 10 years.

$\large{\text{CAPE} = \frac{\text{current price}}{\text{average real earnings over 10 years}}}$

High CAPE can suggest an overvalued market. Low CAPE can suggest an undervalued market. It is a long-term valuation signal, not a precise crash predictor.

[Image placeholder: Shiller CAPE ratio per month for the S&P 500. Source: `Investing.for.Programmers-2025-7.pdf`, Fig. 7.10.]

Possible allocation logic:

- Low CAPE: increase equity exposure.
- High CAPE: reduce equity exposure and increase defensive assets.

CAPE has limits. Interest rates, tax rules, sector composition, and economic structure can change what counts as expensive or cheap.

## Rebalancing

Rebalancing adjusts a portfolio back toward its target allocation.

Common methods:

- Periodic rebalancing: rebalance on a schedule.
- Threshold rebalancing: rebalance when allocation drifts beyond a set range.
- Hybrid rebalancing: use both schedule and drift thresholds.

Rebalancing controls concentration risk, but it can create taxes and transaction costs.

Investors can rebalance by:

- Selling overweight positions and buying underweight positions.
- Directing new cash into underweight positions.
- Reducing future purchases of overexposed assets.

### Rebalancing Actions

| Stock | Current value | Target value | Adjustment | Action |
| --- | ---: | ---: | ---: | --- |
| AAPL | 10,000 | 1,176.28 | -8,823.72 | Sell |
| WMT | 10,000 | 519.89 | -9,480.11 | Sell |
| GOOGL | 10,000 | 1,116.92 | -8,883.08 | Sell |
| PFE | 10,000 | 13,561.10 | 3,561.10 | Buy |
| BRK-B | 10,000 | 652.05 | -9,347.95 | Sell |
| NVDA | 10,000 | 42,984.76 | 32,984.76 | Buy |

This table is an illustration, not a recommendation. Real rebalancing must account for taxes, fees, fractional-share limits, risk tolerance, and whether the target allocation still makes sense.

The durable lesson is that risk management should be written into the investing process before the market becomes stressful. Measure risk, define actions, preserve discipline, and keep enough flexibility to adapt when new evidence appears.
