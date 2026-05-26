# Chapter 1: Introduction

Derivatives have become essential in modern finance over the past four decades. Futures and options trade actively on exchanges worldwide, while forward contracts, swaps, and many other derivatives are used extensively in over-the-counter markets by financial institutions, fund managers, and corporate treasurers. They appear in bond issues, executive compensation, capital investments, and mortgage risk transfers. 

Whether you love them or hate them, derivatives cannot be ignored. The market is enormous — far larger than the stock market in terms of underlying assets, with values several times global GDP. Derivatives derive their value from underlying variables like asset prices, interest rates, currencies, or even unusual factors such as hog prices or snowfall at a ski resort. They enable hedging, speculation, and arbitrage, transferring risks efficiently across the economy.

Key developments include new instruments like credit, electricity, weather, and insurance derivatives; expanded interest rate, foreign exchange, and equity products; advances in risk management and real options; post-2008 regulations; changes in discount rates and LIBOR; adjustments for credit, funding, and capital; greater focus on collateral; and the rise of machine learning for portfolio management.

## Exchange-Traded Markets**

Derivatives exchanges standardize contracts for trading. The Chicago Board of Trade (established 1848) pioneered futures-style contracts for grains, followed by the Chicago Mercantile Exchange. Today, major players like the CME Group dominate, offering contracts on commodities and financial assets.

The Chicago Board Options Exchange launched standardized stock options in 1973, adding puts in 1977. Options now cover thousands of stocks, indices, currencies, and futures. Once a trade is agreed, the exchange's clearing house steps in as intermediary, guaranteeing performance and managing credit risk through margin requirements.

### Electronic Markets**

Traditional open outcry trading on exchange floors has largely given way to electronic platforms. Traders enter orders via keyboards, and computers match buyers and sellers. This shift has fueled high-frequency trading using algorithms, often without direct human intervention.

## Over-the-Counter Markets**

Not all derivatives trade on exchanges. The over-the-counter (OTC) market involves banks, financial institutions, fund managers, and corporations negotiating customized deals. Trades can clear through a central counterparty (similar to an exchange clearing house) or bilaterally with collateral agreements.

Large banks often serve as market makers, continuously quoting bid and ask prices for common instruments.

### Regulatory Changes**

Post-financial crisis regulations have increased transparency and reduced systemic risk in OTC markets. Key requirements include:
- Trading standardized OTC derivatives between financial institutions on swap execution facilities (platforms like exchanges).
- Using central counterparties for most standardized transactions.
- Reporting all trades to central repositories.

### Market Size**

Both OTC and exchange-traded derivatives markets are massive. OTC transactions tend to be larger, making that segment significantly bigger overall. Growth was rapid until 2007, after which compression techniques (restructuring trades to reduce notional amounts) slowed net expansion.

![Over-the-Counter Market versus Exchange-Traded Market](/.attachments/otc.vs.xt.markets.png)

_Size of over-the-counter and exchange-traded derivatives markets._

## Forward Contracts**

A forward contract is an over-the-counter agreement to buy or sell an asset at a future date for a price agreed today. One party takes the long position (agrees to buy), the other the short (agrees to sell).

Forward foreign exchange contracts are very common. Banks quote spot and forward rates. For example, a U.S. company expecting to pay £1 million in six months can lock in the rate by entering a forward contract, eliminating exchange rate uncertainty.

### Payoffs from Forward Contracts**

The payoff for a long forward position is the spot price at maturity minus the delivery price. For the short position, it's the reverse. Payoffs can be positive or negative, with no initial cost beyond potential margin.

### Forward Prices and Spot Prices**

Forward prices relate closely to spot prices, adjusted for factors like interest rates. For a non-dividend stock, the fair one-year forward price equals the spot price grossed up by the risk-free rate. Deviations create arbitrage opportunities.

## Futures Contracts**

Futures are standardized forward-like contracts traded on exchanges. The clearing house intermediates, and daily settlement (marking to market) occurs. Contracts cover commodities (e.g., gold, oil, cattle) and financials (currencies, indices, bonds). Prices reflect supply and demand.

## Options**

Options come in two main types: calls (right to buy) and puts (right to sell) at a strike price by or on a certain date. American options can be exercised anytime; European only at expiration. Most exchange-traded equity options are American.

Unlike forwards and futures, options require an upfront premium but give the holder the right (not obligation) to exercise. They provide asymmetric payoff profiles.

## Types of Traders**

Derivatives attract hedgers, speculators, and arbitrageurs due to high liquidity.

### Hedgers**

Hedgers reduce existing risks. A company expecting to pay foreign currency can buy it forward to lock in costs. An investor worried about stock declines can buy put options for protection. Hedging reduces risk but doesn't guarantee better outcomes than not hedging.

### Speculators**

Speculators take directional bets. They can use futures for leveraged exposure with margin or options for limited downside. Futures offer high leverage but unlimited risk; purchased options limit losses to the premium while offering large upside.

### Arbitrageurs**

Arbitrageurs exploit price discrepancies across markets for risk-free profits. For example, buying a stock cheap in one market and selling it higher in another (adjusted for exchange rates). Such opportunities are rare and short-lived due to rapid trading.

## Dangers**

Derivatives' versatility is a double-edged sword. Traders mandated to hedge or arbitrage sometimes become speculators, leading to massive losses. Strong internal controls, clear risk limits, and daily monitoring are essential. Risk managers must continually ask: "What can go wrong?" and quantify potential impacts, especially during periods of apparent stability.