# Chapter 2: Hedging Strategies Using Futures

Many participants in futures markets are hedgers who aim to reduce a specific risk they face, such as fluctuations in oil prices, foreign exchange rates, or stock market levels. A perfect hedge completely eliminates risk, but these are rare. Most hedging involves constructing positions that perform as close to perfectly as possible.

This chapter explores general issues in setting up hedges. When should you use a short futures position? When is a long position better? Which contract should you choose, and what is the optimal size? At this stage, we focus on straightforward "hedge-and-forget" strategies where the position is set at the beginning and closed at the end, without ongoing adjustments.

We initially treat futures like forward contracts (ignoring daily settlement) and later explain necessary adjustments for the differences.

## Basic Principles

When using futures to hedge, the goal is usually to neutralize risk as much as possible. For example, suppose a company will gain $10,000 for every 1-cent increase in a commodity's price over the next three months and lose $10,000 for every 1-cent decrease. To hedge, the treasurer should take a short futures position that offsets this exposure — losing $10,000 when the price rises and gaining $10,000 when it falls. This way, gains on the futures offset losses in the business (and vice versa).

### Short Hedges

A short hedge involves selling futures contracts. It is appropriate when you already own the asset and plan to sell it later, or when you will own it in the future. 

For instance, a farmer with hogs ready for market in two months can short futures to lock in a selling price. Similarly, a U.S. exporter expecting euros in three months can short euro futures to protect against a decline in the euro's value.

**Example of a Short Hedge**  
On May 15, an oil producer agrees to sell 1 million barrels in August at the market price on that day. The current spot price is $50 per barrel, and the August futures price is $49. By shorting 1,000 futures contracts (1,000 barrels each), the producer can effectively lock in a price close to $49 per barrel.  

- If the August spot price falls to $45, the company receives $45 million from the sale but gains about $4 million from the futures (closing at roughly $45), for a net of $49 million.  
- If the price rises to $55, the company receives $55 million from the sale but loses $6 million on the futures, again netting close to $49 million.

### Long Hedges

A long hedge involves buying futures contracts. It is suitable when a company knows it will need to purchase an asset later and wants to lock in today's price now.

**Example of a Long Hedge**  
On January 15, a copper fabricator knows it will need 100,000 pounds of copper on May 15. The spot price is 340 cents per pound, and the May futures price is 320 cents. By going long four futures contracts (25,000 pounds each), the fabricator locks in a price close to 320 cents per pound.  

Regardless of whether the May spot price ends up higher or lower, the net cost after futures gains or losses is approximately 320 cents per pound.

In both examples, the futures position is typically closed out in the delivery month rather than taking or making physical delivery, which can be costly and inconvenient. Long hedgers usually close positions before the delivery period begins to avoid taking delivery.

Daily settlement has only a minor effect on hedge performance, as gains and losses are realized gradually rather than all at once.

## Arguments For and Against Hedging

The case for hedging is straightforward. Most companies focus on manufacturing, retailing, or providing services — not on forecasting interest rates, exchange rates, or commodity prices. Hedging lets them reduce uncertainty and avoid nasty surprises, allowing management to concentrate on core operations.

However, many risks remain unhedged in practice for several reasons.

### Hedging and Shareholders

Some argue shareholders can hedge on their own if they want. But this overlooks that management usually has better information about the company's risks, and large-scale hedging is cheaper and more efficient when done by the company. Well-diversified shareholders may already have limited exposure to certain risks, but managers must still consider whether hedging serves the company's best interests.

### Hedging and Competitors

If hedging is uncommon in an industry, doing so might create uneven profit margins. For example, if gold prices rise, unhedged jewelry makers can pass on higher costs through higher prices. A hedged competitor might see improved margins, but if prices fall, the hedged company could suffer while unhedged competitors remain stable. Hedging strategies must consider the broader competitive picture.

### Hedging Can Lead to a Worse Outcome

A hedge can sometimes make results worse than doing nothing. If the price moves in your favor, the futures position produces losses that offset business gains. While the decision may have been sound, it can be difficult to justify to management or shareholders who focus only on the visible futures loss.

Strong internal understanding and clear communication about hedging goals are essential to avoid misjudgments.

## Basis Risk

The hedges discussed so far were nearly perfect because the asset, quantity, and timing matched exactly. In reality, hedging is rarely that clean due to basis risk.

### The Basis

The basis is the difference between the spot price of the asset being hedged and the futures price of the contract used:  

**Basis = Spot price - Futures price**

At futures expiration, the basis should be zero if the assets match. Before then, it can be positive or negative and changes over time. An increasing basis is a strengthening; a decreasing basis is a weakening.

![Variation of basis over time](/.attachments/variation.of.basis.png)

For a short hedger (selling futures), an unexpected strengthening of the basis improves the outcome, while weakening worsens it. For a long hedger, the opposite applies.

Basis risk arises from uncertainty about the basis when the hedge is closed. It increases when:  
- The asset being hedged differs from the futures underlying asset (cross hedging).  
- The exact timing of the purchase or sale is uncertain.  
- The futures contract must be closed before its delivery month.

### Choice of Contract

Selecting the right futures contract involves two decisions: the underlying asset and the delivery month.  

When a perfect match exists, the choice is easy. Otherwise, choose the contract whose price movements correlate most closely with the exposure.  

For delivery month, pick one as close as possible but after the hedge ends. This avoids erratic price behavior during delivery and the risk of physical delivery. Liquidity is also higher in nearer contracts, sometimes leading hedgers to use shorter contracts and roll them forward.

## Cross Hedging

In the earlier examples, the asset underlying the futures contract matched the asset being hedged exactly. Cross hedging occurs when they are different. For example, an airline worried about future jet fuel prices might use heating oil futures, since active jet fuel futures contracts are not readily available.

The hedge ratio is the size of the futures position divided by the size of the exposure. When the assets match perfectly, a hedge ratio of 1.0 is natural. In cross hedging, the optimal ratio is usually different. The goal is to choose a hedge ratio that minimizes the variance of the overall hedged position.

### Calculating the Minimum Variance Hedge Ratio

Assuming no daily settlement for simplicity, the minimum variance hedge ratio depends on how changes in the spot price (ΔS) relate to changes in the futures price (ΔF).  

We can model this relationship approximately as:  
**ΔS = a + b ΔF + error**

The value of b that minimizes risk is the optimal hedge ratio (h*).  

**h* = ρ × (σ_S / σ_F)**  

where:  
- ρ is the correlation between ΔS and ΔF  
- σ_S is the standard deviation of ΔS  
- σ_F is the standard deviation of ΔF  

![Regression diagram showing change in spot price vs. change in futures price](/.attachments/regression.of.change.spot.price.png)

The hedge effectiveness is measured by ρ² — the proportion of variance eliminated by the hedge.

![Dependence of variance](/.attachments/dependence.of.variance.png)

_Dependence of variance of hedger’s position on hedge ratio._

These parameters (ρ, σ_S, σ_F) are typically estimated from historical data using equal time intervals matching the hedge horizon (or shorter if data is limited).

**Optimal Number of Contracts**

Define:  
- Q_A = Size of the position being hedged (in units)  
- Q_F = Size of one futures contract (in units)  

The optimal number of futures contracts (N*) is:  

**N* = h* × (Q_A / Q_F)**

**Impact of Daily Settlement**

When using futures (which are marked to market daily), the hedge consists of a series of one-day hedges rather than one long-term hedge.  

The formulas can be adjusted using daily percentage changes:  
- σ_nS = Standard deviation of daily percentage changes in spot price  
- σ_nF = Standard deviation of daily percentage changes in futures price  
- ρ_n = Correlation between daily percentage changes  

An alternative hedge ratio (h_n) based on percentage changes leads to:  

**N* = h_n × (V_A / V_F)**  

where V_A is the current value of the position being hedged and V_F is the current value of one futures contract.

This hedge ratio may need small daily adjustments as relative values change, though changes are usually minor.  

For longer horizons, you can refine the number by "tailing the hedge" — adjusting for interest that can be earned or paid over the remaining life of the hedge.

**Stock Index Futures**

A stock index tracks the value of a hypothetical portfolio of stocks. The percentage change in the index reflects the percentage change in that portfolio's value (typically excluding dividends).

Stock indices can be price-weighted (weights based on stock prices) or market-capitalization-weighted (weights based on market value of shares outstanding). Portfolios are automatically adjusted for splits, dividends, and new issues.

Popular contracts include those on the Dow Jones Industrial Average, S&P 500, and Nasdaq-100. These are cash-settled, with final settlement based on the opening price on the last trading day.

**Hedging an Equity Portfolio**

Stock index futures are excellent for hedging diversified equity portfolios.  

Define:  
- V_A = Current value of the portfolio  
- V_F = Current value of one futures contract (futures price × multiplier)  

If the portfolio closely mirrors the index, the optimal number of contracts to short is:  

**N* = V_A / V_F**

For portfolios that do not perfectly track the index, use the portfolio's beta (β) from the capital asset pricing model. Beta measures the portfolio's sensitivity to market movements.  

The number of contracts to short becomes:  

**N* = β × (V_A / V_F)**

- To reduce beta to zero (full hedge), use this formula directly.  
- To change beta from β to β*, adjust the position size accordingly: short (β - β*) × (V_A / V_F) contracts if lowering beta, or go long if increasing beta.

**Locking in the Benefits of Stock Picking**

If you believe you can select stocks that will outperform the market but are uncertain about overall market direction, you can hedge market risk while keeping your stock-picking exposure.  

Short β × (V_A / V_F) index futures contracts, where β is your portfolio's beta. This removes broad market risk, leaving you exposed only to how well your specific stocks perform relative to the market.

**Stack and Roll**

Sometimes the hedge horizon extends beyond available futures delivery dates. In this case, hedgers roll the position forward: close out the near-term contract and open a new position in a later contract. This can be repeated as needed — a process known as stack and roll.

For ongoing monthly exposures, companies often stack enough short-term contracts to cover the full horizon, then roll them forward each month into new near-term contracts.  

This approach requires careful liquidity management, as large price moves can create significant cash flow timing mismatches between the hedge and the underlying exposure.