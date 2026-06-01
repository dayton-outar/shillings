# Chapter 2: Markets

Futures and forward contracts are both agreements to buy or sell an asset at a future time for a certain price. Futures contracts trade on exchanges with standardized terms, while forwards are customized over-the-counter agreements.

## Background

Major futures exchanges include the CME Group, Intercontinental Exchange, Eurex, B3 in Brazil, the National Stock Exchange of India, the China Financial Futures Exchange, and the Tokyo Financial Exchange.

A futures contract comes into existence when two parties agree on a trade. For example, a trader in New York might instruct a broker to buy one September corn futures contract (5,000 bushels), while a trader in Kansas instructs a broker to sell one contract for the same delivery. The price is set by supply and demand. Electronic trading systems match buyers and sellers automatically.

The New York trader holds a long position; the Kansas trader holds a short position. The agreed price becomes the current futures price for that delivery month.

### Closing Out Positions

Most futures contracts do not result in delivery. Traders usually close out positions by entering an offsetting trade before the delivery period. The New York trader who bought a September contract can close it by selling the same contract later. The gain or loss depends on the price change between opening and closing the position.

## Specification of a Futures Contract

When creating a new contract, the exchange defines the asset, contract size, delivery locations, and delivery timing.

### The Asset

For commodities, the exchange specifies acceptable grades. The Intercontinental Exchange orange juice contract requires U.S. Grade A frozen concentrate with a Brix value of at least 62.5 degrees. Some contracts allow grade substitutions with price adjustments. Financial assets like currencies or Treasury bonds have clear definitions, though bond contracts may allow a range of maturities and coupons with conversion formulas.

### The Contract Size

Contract size determines how much of the asset is delivered per contract. It balances accessibility for small traders with trading efficiency. Agricultural contracts might cover $10,000–$20,000 worth of the commodity, while Treasury bond contracts cover $100,000 face value. Mini contracts exist for smaller participants, such as the Mini Nasdaq 100.

### Delivery Arrangements

The exchange specifies delivery locations. For orange juice, delivery occurs at licensed warehouses in Florida, New Jersey, or Delaware. When multiple locations are allowed, the short position chooses and may receive price adjustments. Prices are typically higher for locations farther from major supply sources.

### Delivery Months

Contracts are identified by delivery month. The exchange sets the exact delivery window, often the full month. Popular months for corn include March, May, July, September, and December. Trading begins for nearby months and extends to later ones. Trading usually stops a few days before the final delivery day.

### Price Quotes

Exchanges define quotation methods. Crude oil uses dollars and cents per barrel. Treasury bonds and notes use dollars and thirty-seconds of a dollar.

### Price Limits and Position Limits

Most contracts have daily price movement limits. A contract hitting the maximum downward move is limit down; upward is limit up. Trading may halt for the day at these limits. These rules aim to curb excessive speculation but can sometimes restrict trading during rapid market moves.

Position limits cap the number of contracts a speculator can hold to prevent market manipulation.

## Convergence of Futures Price to Spot Price

As the delivery period approaches, the futures price converges to the spot price of the underlying asset. At delivery, they are equal or extremely close.

If the futures price exceeds the spot price during delivery, arbitrageurs can sell futures, buy the asset in the spot market, and deliver it for a risk-free profit. This pushes the futures price down. If futures trade below spot, buyers enter long futures positions and wait for delivery, pushing the futures price up.

**How Futures Prices Converge with Spot Prices as Delivery Approaches**

(a) Futures price starts **above** the spot price and gradually falls to meet it  
(b) Futures price starts **below** the spot price and gradually rises to meet it

This shows the powerful pull between the two prices as the contract nears its delivery date.

![Convergence of futures and spot prices approaching each other](/.attachments/futures.vs.spot.price.png)

## The Operation of Margin Accounts

Exchanges use margin accounts to minimize default risk. When entering a futures position, traders deposit initial margin. Accounts are marked to market daily.

Consider a trader buying two December gold futures contracts at $1,750 per ounce (100 ounces each). Initial margin might be $6,000 per contract ($12,000 total). If the price drops to $1,741 by day's end, the trader loses $1,800 ($9 × 200 ounces) and the margin balance falls accordingly. If the price rises, the account is credited.

Daily settlement creates variation margin flows: gains move to long positions from short positions, and vice versa.

Traders must maintain a maintenance margin (lower than initial). Falling below it triggers a margin call to restore the account to initial margin level. Failure to meet the call leads to the broker closing the position.

**Table** Operation of margin account for a long position in two gold futures contracts. The initial margin is $6,000 per contract, or $12,000 in total; the maintenance margin is $4,500 per contract, or $9,000 in total. The contract is entered into on Day 1 at $1,750 and closed out on Day 16 at $1,726.90.

| Day | Trade price ($) | Settlement price ($) | Daily gain ($) | Cumulative gain ($) | Margin account balance ($) | Margin call ($) |
|-----|-----------------|----------------------|----------------|---------------------|----------------------------|-----------------|
| 1   | 1,750.00        | 1,741.00             | -1,800         | -1,800              | 10,200                     |                 |
| 2   |                 | 1,738.30             | -540           | -2,340              | 9,660                      |                 |
| 3   |                 | 1,744.60             | 1,260          | -1,080              | 10,920                     |                 |
| 4   |                 | 1,741.30             | -660           | -1,740              | 10,260                     |                 |
| 5   |                 | 1,740.10             | -240           | -1,980              | 10,020                     |                 |
| 6   |                 | 1,736.20             | -780           | -2,760              | 9,240                      |                 |
| 7   |                 | 1,729.90             | -1,260         | -4,020              | 7,980                      | 4,020           |
| 8   |                 | 1,730.80             | 180            | -3,840              | 12,180                     |                 |
| 9   |                 | 1,725.40             | -1,080         | -4,920              | 11,100                     |                 |
| 10  |                 | 1,728.10             | 540            | -4,380              | 11,640                     |                 |
| 11  |                 | 1,711.00             | -3,420         | -7,800              | 8,220                      | 3,780           |
| 12  |                 | 1,711.00             | 0              | -7,800              | 12,000                     |                 |
| 13  |                 | 1,714.30             | 660            | -7,140              | 12,660                     |                 |
| 14  |                 | 1,716.10             | 360            | -6,780              | 13,020                     |                 |
| 15  |                 | 1,723.00             | 1,380          | -5,400              | 14,400                     |                 |
| 16  | 1,726.90        |                      | 780            | -4,620              | 15,180                     |                 |

Traders can often post securities like Treasury bills (at a discount) instead of cash for initial margin. Excess margin above the initial level can be withdrawn. Brokers typically pay interest on cash balances.

The clearing house sets minimum margins based on asset volatility and requires members to post clearing margin. Positions are netted for margin calculations.

### The Clearing House and Its Members

The clearing house guarantees contract performance and acts as intermediary. It tracks all trades, calculates net positions for members, and handles daily settlements. Members post initial and variation margin. A guaranty fund provides additional protection against defaults.

### Credit Risk

The margin system has proven highly effective. Major exchanges have honored all contracts, even during extreme events like the 1987 market crash.

## OTC Markets

Over-the-counter derivatives traditionally carried counterparty credit risk. To reduce this, the market has adopted practices from futures exchanges.

### Central Counterparties

Central counterparties (CCPs) clear standardized OTC trades. They become the buyer to every seller and seller to every buyer, requiring initial and daily variation margin plus contributions to a guaranty fund. Post-2008 regulations mandate CCP clearing for most standardized OTC derivatives between financial institutions.

### Bilateral Clearing

Non-CCP trades use bilateral agreements with credit support annexes (CSAs) requiring collateral (similar to margin). Collateral is exchanged daily based on value changes. Regulations now often require initial margin for bilateral trades between financial institutions as well.

**How OTC Markets Are Structured**

**(a)** Traditional setup: A complex web of direct bilateral agreements between individual market participants.

**(b)** With a Central Counterparty (CCP): All trades clear through a single central clearing house that stands between every buyer and seller.

This highlights the shift from many direct connections to a safer, more streamlined hub-and-spoke model.

![Bilateral vs. central clearing](/.attachments/traditional.vs.ccp.png)

### Futures Trades vs. OTC Trades

Futures variation margin does not earn interest (as it represents daily settlement), while OTC variation margin typically does. Securities can often be posted for margin/collateral with haircuts applied.

## Market Quotes

Futures prices are readily available from exchanges and various online platforms. Quotes typically show the underlying asset, contract size, and quotation method for each contract.

For each maturity month, key data includes the opening price, the day's high and low, the previous day's settlement price, the most recent trade price, the daily change, and trading volume.

The settlement price is especially important — it determines daily gains, losses, and margin adjustments. It is usually based on the final trades of the day.

Trading volume shows how many contracts changed hands that day, while open interest reflects the total number of outstanding contracts (long positions equal short positions).

Futures markets can display different patterns. In a **normal market**, prices rise with longer maturities. In an **inverted market**, prices fall with longer maturities. Some markets show a mix of both patterns depending on the time horizon.

---

**Table** Futures quotes for a selection of CME Group contracts on commodities on May 21, 2020.

**Gold 100 oz, $ per oz**

| Month     | Open    | High    | Low     | Prior settlement | Last trade | Change  | Volume   |
|-----------|---------|---------|---------|------------------|------------|---------|----------|
| June 2020 | 1751.7  | 1751.7  | 1715.3  | 1752.1           | 1725.5     | -26.6   | 223,200  |
| Aug. 2020 | 1765.3  | 1765.3  | 1731.2  | 1765.6           | 1740.7     | -24.9   | 54,503   |
| Oct. 2020 | 1768.0  | 1768.8  | 1739.0  | 1774.0           | 1747.4     | -26.6   | 2,559    |
| Dec. 2020 | 1778.8  | 1779.8  | 1743.8  | 1781.7           | 1752.7     | -29.0   | 5,280    |
| Dec. 2021 | 1779.0  | 1779.0  | 1755.1  | 1790.7           | 1757.2     | -33.5   | 345      |

**Crude Oil 1000 barrels, $ per barrel**

| Month     | Open   | High   | Low    | Prior settlement | Last trade | Change | Volume   |
|-----------|--------|--------|--------|------------------|------------|--------|----------|
| July 2020 | 33.53  | 34.66  | 33.26  | 33.49            | 33.96      | +0.47  | 356,081  |
| Aug. 2020 | 33.93  | 35.05  | 33.78  | 33.94            | 34.40      | +0.46  | 118,534  |
| Dec. 2020 | 35.18  | 36.08  | 35.06  | 35.23            | 35.76      | +0.53  | 78,825   |
| Dec. 2021 | 37.87  | 38.49  | 37.78  | 37.91            | 38.15      | +0.24  | 22,542   |
| Dec. 2022 | 40.30  | 40.74  | 39.92  | 40.27            | 40.24      | -0.03  | 3,732    |

**Corn 5000 bushels, cents per bushel**

| Month     | Open    | High    | Low     | Prior settlement | Last trade | Change | Volume  |
|-----------|---------|---------|---------|------------------|------------|--------|---------|
| July 2020 | 317.75  | 320.25  | 316.25  | 319.50           | 318.00     | -1.50  | 104,099 |
| Sept. 2020| 323.50  | 325.00  | 321.25  | 324.25           | 323.00     | -1.25  | 25,967  |
| Dec. 2020 | 333.25  | 334.50  | 331.00  | 334.00           | 333.00     | -1.00  | 32,855  |
| Mar. 2021 | 346.00  | 347.00  | 344.00  | 346.50           | 345.75     | -0.75  | 4,449   |
| May 2021  | 353.75  | 354.50  | 351.50  | 354.00           | 353.50     | -0.50  | 1,077   |
| Dec. 2021 | 365.25  | 365.75  | 363.50  | 365.75           | 365.75     | 0.00   | 2,775   |

**Soybeans 5000 bushels, cents per bushel**

| Month     | Open    | High    | Low     | Prior settlement | Last trade | Change  | Volume  |
|-----------|---------|---------|---------|------------------|------------|---------|---------|
| July 2020 | 835.00  | 848.50  | 833.75  | 846.75           | 835.25     | -11.50  | 89,375  |
| Sept. 2020| 849.25  | 851.50  | 839.00  | 849.75           | 840.50     | -9.25   | 5,502   |
| Nov. 2020 | 851.50  | 856.00  | 844.00  | 854.00           | 846.25     | -7.75   | 42,274  |
| Jan. 2021 | 856.75  | 859.00  | 847.75  | 857.00           | 849.75     | -7.25   | 9,173   |
| Mar. 2021 | 850.25  | 852.75  | 843.00  | 850.25           | 844.75     | -5.50   | 13,531  |
| May 2021  | 846.50  | 851.00  | 842.50  | 848.25           | 844.25     | -4.00   | 3,736   |
| July 2021 | 855.50  | 858.25  | 850.50  | 855.75           | 852.25     | -3.50   | 1,953   |

**Wheat 5000 bushels, cents per bushel**

| Month     | Open    | High    | Low     | Prior settlement | Last trade | Change | Volume  |
|-----------|---------|---------|---------|------------------|------------|--------|---------|
| July 2020 | 520.00  | 524.00  | 512.00  | 513.75           | 515.75     | +2.00  | 72,667  |
| Sept. 2020| 520.75  | 525.00  | 514.50  | 515.25           | 518.50     | +3.25  | 26,565  |
| Dec. 2020 | 528.00  | 532.25  | 523.00  | 522.75           | 526.50     | +3.75  | 18,522  |
| Mar. 2021 | 531.75  | 538.75  | 530.25  | 530.00           | 534.50     | +4.50  | 6,020   |
| May 2021  | 535.50  | 540.25  | 532.75  | 532.75           | 537.00     | +4.25  | 1,333   |

**Live Cattle 40,000 lbs, cents per lb**

| Month     | Open     | High     | Low      | Prior settlement | Last trade | Change  | Volume |
|-----------|----------|----------|----------|------------------|------------|---------|--------|
| June 2020 | 98.775   | 99.200   | 97.975   | 98.400           | 98.650     | +0.250  | 6,567  |
| Oct. 2020 | 99.800   | 99.975   | 98.775   | 99.625           | 99.800     | +0.175  | 6,875  |
| Dec. 2020 | 102.750  | 102.950  | 102.050  | 102.725          | 102.800    | +0.075  | 5,511  |
| June 2021 | 101.750  | 102.750  | 101.625  | 101.975          | 102.675    | +0.700  | 290    |

---

## Delivery

Although very few futures contracts result in actual delivery, the delivery process is what anchors futures prices to the underlying spot market.

The exchange defines the delivery window for each contract. The party with the short position decides exactly when to deliver within that window. They submit a notice of intention to deliver to the clearing house, specifying details such as grade and location (for commodities).

The clearing house then assigns the delivery notice to a party holding a long position — typically the one with the oldest outstanding position. The long party must accept delivery but may sometimes transfer the obligation if allowed.

For commodities, delivery often involves transferring a warehouse receipt in exchange for payment at the most recent settlement price (adjusted for grade or location if necessary). The buyer then assumes storage and other costs. For financial futures, delivery is usually handled electronically via wire transfer.

Key dates include the first notice day (earliest possible delivery notice), the last notice day, and the last trading day (usually a few days earlier). Traders with long positions who want to avoid taking delivery should close out before the first notice day.

### Cash Settlement

Some financial futures, particularly those on stock indices, are cash-settled because physical delivery would be impractical. On the final settlement day, all open contracts are closed out at a price based on the spot value of the underlying index (often at the open or close of trading that day).

## Types of Traders and Types of Orders

Futures trading involves two main groups: futures commission merchants (who execute trades for clients and charge commissions) and locals (who trade for their own accounts).

Traders themselves fall into hedgers, speculators, and arbitrageurs. Among speculators, there are scalpers (who hold positions for minutes to capture tiny moves), day traders (who close positions by the end of the trading day), and position traders (who hold for longer periods expecting bigger market shifts).

### Orders

Traders can place various types of orders:

- **Market order**: Execute immediately at the best available current price.
- **Limit order**: Execute only at a specified price or better.
- **Stop order (stop-loss)**: Triggers a market order once the price hits a certain level — useful for limiting losses.
- **Stop-limit order**: Combines stop and limit — becomes a limit order after hitting the stop price.
- **Market-if-touched (MIT) order**: Triggers a market order once the price reaches a favorable level — good for locking in profits.
- **Discretionary (market-not-held) order**: A market order where the broker has some flexibility on timing to seek a better price.

Orders can also include time conditions, such as day orders (expire at end of day), good-till-canceled (remain active until filled or canceled), or fill-or-kill (must execute immediately or be canceled).

## Regulation

In the United States, futures markets are primarily regulated by the Commodity Futures Trading Commission (CFTC). The CFTC protects the public interest by ensuring transparent price reporting, position disclosures for large traders, licensing of brokers, and enforcement against misconduct.

The National Futures Association (NFA) complements this with industry self-regulation, handling dispute arbitration and monitoring for fraud.

Additional rules introduced after the 2008 financial crisis expanded oversight, particularly requiring standardized over-the-counter derivatives between financial institutions to trade on swap execution facilities and clear through central counterparties.

Regulators address abuses such as attempts to corner the market by adjusting margin requirements, tightening position limits, or forcing position reductions.

## Accounting and Tax

### Accounting

Changes in the market value of futures contracts must be recognized immediately unless the contract qualifies as a hedge. For qualifying hedges, gains and losses are matched in timing with the underlying exposure being hedged (hedge accounting).

### Tax

Tax treatment depends on whether gains/losses are classified as capital or ordinary income. For noncorporate taxpayers, futures positions are generally treated as closed out at year-end under the “60/40” rule (60% long-term, 40% short-term capital treatment), regardless of actual holding period.

Hedging transactions are exempt from this rule and treated as ordinary income, with timing aligned to the hedged item. Proper documentation and identification are required for hedge treatment.

## Forward vs. Futures Contracts

Forward and futures contracts serve similar purposes but differ in key ways:

- **Forward**: Private, customized contract between two parties; usually one delivery date; settled at maturity; some credit risk.
- **Futures**: Standardized, exchange-traded; range of delivery dates; marked to market daily; virtually no credit risk due to clearing house and margins.

### Profits from Forward and Futures Contracts

The total economic gain or loss is the same for equivalent forward and futures positions. The difference is timing: forwards realize everything at maturity, while futures realize gains and losses daily through margin settlements.

**Table** Comparison of forward and futures contracts.

|                      | Forward                          | Futures                          |
|----------------------|----------------------------------|----------------------------------|
| Private contract between two parties | Traded on an exchange           |
| Not standardized     | Standardized contract            |
| Usually one specified delivery date | Range of delivery dates         |
| Settled at end of contract | Settled daily                   |
| Delivery or final cash settlement usually takes place | Contract is usually closed out prior to maturity |
| Some credit risk     | Virtually no credit risk         |

### Foreign Exchange Quotes

Foreign exchange futures and forwards are both actively traded. Futures prices are quoted in U.S. dollars per unit of foreign currency (or cents). Forward quotes sometimes use the reciprocal (foreign currency per USD), requiring conversion for direct comparison.
