# Building An Asset Monitor

An asset monitor helps an investor see what they own, where it is held, what it is worth, what income it may produce, and what has changed over time.

Choosing assets is only the beginning. Once assets are purchased, the investor needs a reliable way to stay informed. A portfolio that is not monitored can hide concentration, stale prices, currency exposure, missing income, weak performers, and risks that slowly grow in the background.

The goal is not to build a fancy dashboard. The goal is to maintain portfolio truth.

## Architecture

A useful asset monitor gathers holdings from different sources, normalizes them into a shared structure, enriches them with market data, and exports the result into a reviewable report.

[Image placeholder: Data flow from asset data to worksheets in a portfolio spreadsheet. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.1.]

A practical monitoring flow has five stages:

- Extract: collect holdings from brokers, exchanges, wallets, banks, and manual records.
- Normalize: convert each source into the same basic data structure.
- Enrich: add prices, yields, names, sectors, ratings, or other useful metadata.
- Aggregate: calculate total value, income, gains, losses, and allocation.
- Report: export the results into a view the investor can inspect and compare over time.

Not every asset can be collected automatically. Some assets may have no convenient digital feed. Real estate, private investments, collectibles, cash held outside an account, and some bond positions may need manual tracking.

[Image placeholder: Online and offline asset sources flowing into a shared asset dataset. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.2.]

## Offline Assets

Offline assets are holdings that cannot be reliably retrieved from a connected account. They still belong in the monitor.

A simple offline asset record should include:

- Identifier: a ticker, symbol, ISIN, internal label, property name, or other unique reference.
- Yield: expected recurring income, if any.
- Average purchase price: weighted average cost of the position.
- Venue or location: where the asset is held or traded.
- Amount: number of shares, units, tokens, bonds, or ownership amount.
- Asset type: stock, ETF, bond, crypto, real estate, cash, or another category.

The identifier should be unique. If two sources use different identifiers for the same asset, the monitor needs a mapping layer.

## The Spreadsheet

A spreadsheet or tabular report is useful because it is easy to filter, sort, inspect, and share. The format matters less than the structure.

A stock worksheet should show:

- Ticker.
- Portfolio group.
- Number of shares.
- Average purchase price.
- Current price.
- Total value.
- Expected yearly yield.
- Past gain or loss.
- Possible future gain or loss.
- Source or broker.
- Live or refreshed value, if available.

[Image placeholder: Stock worksheet with tickers, portfolios, shares, value, yield, gains, and live data. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.3.]

An overview worksheet should summarize all assets across categories.

It should answer:

- What is the total portfolio value?
- How much income is expected?
- Which asset types dominate the portfolio?
- Which portfolios or goals hold the most value?
- Is the investor overexposed to one category?

[Image placeholder: Overview worksheet grouping assets by value and passive income. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.4.]

The overview should make concentration obvious. A portfolio that looks large may still be fragile if most value sits in one risky asset type.

## Extracting Data

Different brokers, banks, exchanges, and wallets expose portfolio data in different ways. Some provide structured access. Some only provide exports. Some provide no useful automated access at all.

The extraction layer should collect a minimum shared structure:

- Ticker or identifier.
- Number of shares or units held.
- Average purchase price.
- Exchange, venue, wallet, or account location.
- Source name.

This makes different sources comparable. Once the fields match, positions from many accounts can be combined into one portfolio view.

Before connecting any financial account, the investor should check:

- Jurisdiction and availability.
- Fees, transfer costs, and currency-conversion costs.
- Account security.
- Regulatory status.
- Data access limits.
- Whether automation is read-only or can place trades.
- How credentials are stored and protected.

Credentials should be treated as financial keys. If someone can use them to see, move, or trade assets, they must be protected carefully.

## Enriching Data

Raw holdings are not enough. A monitor needs additional information to make the holdings meaningful.

Common enrichment fields include:

- Current price.
- Currency.
- Company or asset name.
- Sector or asset category.
- Dividend rate.
- Yield.
- Target price or analyst estimate, where appropriate.
- Credit rating for bonds.
- Maturity date for bonds.
- Staking reward for crypto.
- Portfolio grouping.
- Alternate identifiers used by data providers.

Identifier mapping is essential. One source may refer to a security one way, while another source uses a slightly different symbol.

> Example:
>
> A broker may use one ticker format for a company, while a market-data source uses another. Without a lookup table, the monitor may fail to enrich the position or may enrich it incorrectly.

A lookup table should include:

- Original identifier from the holding source.
- Asset type.
- Portfolio group.
- Identifier used by each data source.
- Notes for unusual mappings.

If no alternate identifier is needed, the monitor can use the original identifier.

## Processing Assets

Once data is extracted and enriched, the monitor can calculate position-level and portfolio-level values.

For each position:

$\large{\text{initial value} = \text{amount held} \times \text{average purchase price}}$

$\large{\text{current value} = \text{amount held} \times \text{current price}}$

$\large{\text{annual income} = \text{amount held} \times \text{income per unit}}$

$\large{\text{past gain or loss} = \text{current value} - \text{initial value}}$

$\large{\text{projected gain or loss} = (\text{target price} - \text{current price}) \times \text{amount held}}$

These formulas are simple, but they become powerful when applied consistently across every account and asset type.

## Stocks

Stocks are usually easy to monitor because they often have clear tickers, current prices, and dividend information.

A stock monitor should track:

- Ticker.
- Company name.
- Exchange.
- Currency.
- Portfolio group.
- Number of shares.
- Average purchase price.
- Current price.
- Total value.
- Dividend rate.
- Expected annual income.
- Past gain or loss.
- Possible future gain or loss.

Currency matters. An investor may hold one stock traded in US dollars and another traded in euros, francs, pounds, or another currency. To calculate total portfolio value, the monitor needs a target currency.

Currency normalization should:

- Identify the trading currency for each exchange or asset.
- Convert prices into the target currency.
- Convert income into the target currency.
- Preserve original currency information for auditability.

Some investors avoid multiple currencies because exchange-rate movement adds risk. Others accept the risk for international diversification.

> Example:
>
> A $300 gain on one position and a $250 gain on another may feel similar. But if the first position rose 30% and the second rose 50%, the second performed better relative to the money invested. A monitor should show both money amounts and percentages.

Investors should review performance across multiple time frames. A short-term decline may hide strong long-term performance, while a short-term jump may hide weak fundamentals.

## Exchange-Traded Funds

Exchange-traded funds, or ETFs, are pooled investments. They can hold stocks, bonds, other funds, commodities, or mixed assets.

ETFs can be monitored in a stock-like way, but they are not the same as individual companies.

Useful ETF fields include:

- Ticker.
- Fund name.
- Exchange.
- Currency.
- Number of units.
- Net asset value or current market price.
- Total value.
- Yield.
- Portfolio group.
- Average purchase price.

[Image placeholder: ETF worksheet showing value, yield, amount held, and initial value without projected gains. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.5.]

Some stock metrics do not translate cleanly to ETFs. A price-to-earnings ratio for an ETF may represent a weighted average across many holdings, not one company. A target price may be unavailable or unreliable because the fund contains many assets.

At the abstract level, the monitor can still treat ETF income as yield. The investor should remember that the details behind the yield may differ from dividends, coupon payments, or staking rewards.

## Bonds

Bonds are harder to monitor than stocks because each bond issue can have its own identifier, terms, coupon rate, maturity date, and risk profile.

Unlike a stock ticker, a bond identifier often refers to one specific issuance. If the same borrower issues a new bond later, that new bond can have different terms and a different identifier.

Important bond fields include:

- Bond identifier, such as an ISIN or internal reference.
- Issuer.
- Principal or face value.
- Coupon rate.
- Maturity date.
- Number of bonds or units held.
- Expected annual income.
- Credit rating.
- Current market value, if monitored.
- Portfolio group.

[Image placeholder: Bond worksheet showing par value, annual yield, number of bonds held, and expected income. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.6.]

For cautious bond investors, a simple monitor may focus on par value, coupon income, maturity, and issuer risk. More advanced monitoring can add market price, yield-to-maturity, duration, credit-rating changes, and default-risk signals.

## Cryptocurrencies

Cryptocurrency monitoring has two distinct problems:

- Tracking where the assets are held.
- Tracking current value and staking income.

Some crypto assets may be held on exchanges. Others may be controlled through hardware or software wallets. Assets held outside an exchange may need manual tracking unless the wallet or chain data can be connected safely.

Useful crypto fields include:

- Token symbol.
- Amount held.
- Custody location.
- Current price.
- Total value.
- Staking yield or reward rate.
- Whether the asset is locked.
- Lockup period.
- Source of price data.
- Portfolio group.

[Image placeholder: Crypto worksheet showing total value, staking yield, amount owned, and live data. Source: `Investing.for.Programmers-2025-6.pdf`, Fig. 6.7.]

Crypto price data can be less consistent across sources. Some reporting tools may not support many tokens. A monitor should define a fallback rule for missing or failed price updates.

Fallback examples:

- Keep the last known value and mark it stale.
- Require manual update.
- Use a secondary price source.
- Exclude the asset from live totals until verified.

Crypto staking rewards may change often, and token prices can move sharply. The monitor should separate token rewards from total economic return.

## Live Data And Stale Data

Live values are useful, but they can also create false confidence. A live price is only one part of portfolio truth.

A monitor should make freshness visible:

- When was the value last updated?
- Which source supplied it?
- Was it live, delayed, estimated, or manual?
- Did the update fail?
- Is the value being carried forward from a previous export?

Stale data is not always wrong, but it should be labeled. A bond held to maturity may not need constant live pricing. A volatile crypto position probably does.

## Portfolio Perspectives

The same portfolio can be viewed in different ways.

Useful perspectives include:

- Total current value.
- Total invested value.
- Past gain or loss.
- Percentage return.
- Expected annual income.
- Yield on current value.
- Yield on cost.
- Asset-type allocation.
- Currency allocation.
- Account or broker allocation.
- Portfolio goal allocation.
- Best and worst performers.

No single view is enough. Money amounts show impact. Percentages show efficiency. Income shows cash-flow usefulness. Allocation shows concentration.

## Reporting

A recurring portfolio report should help the investor answer:

- What changed since the last review?
- Which assets gained or lost value?
- Which assets produced income?
- Which values are stale or uncertain?
- Which positions are too large?
- Which assets no longer match the thesis?
- Which accounts need reconciliation?
- What action, if any, is needed?

The report does not need to force action. Sometimes the right answer is to keep watching.

## Outlook

An asset monitor is a foundation. Once the investor can reliably track assets, they can build better risk analysis, income planning, rebalancing rules, tax awareness, and decision reviews.

A strong monitor can be extended with:

- Risk dashboards.
- Valuation metrics.
- ESG or sustainability data.
- Tax lots.
- Rebalancing alerts.
- Income calendars.
- Currency exposure.
- Sector exposure.
- Thesis notes.
- Review history.

The durable principle is simple: the investor should be able to explain the portfolio from the data up. What is owned, where it is held, what it is worth, what it produces, how fresh the data is, and why each holding still belongs there.
