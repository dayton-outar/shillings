# Chapter 9: XVAs

Before we dive into pricing options and other complex derivatives, it's important to understand some key price adjustments that have become standard in modern derivatives markets. These are known as **XVAs**. The main ones are:

- **CVA** (Credit Valuation Adjustment)
- **DVA** (Debit or Debt Valuation Adjustment)
- **FVA** (Funding Valuation Adjustment)
- **MVA** (Margin Valuation Adjustment)
- **KVA** (Capital Valuation Adjustment)

Some of these adjustments (especially CVA and DVA) have strong theoretical support, while others (FVA, MVA, and KVA) are more debated among financial economists.

### CVA and DVA

Most derivatives pricing assumes **no one defaults** — this is called the no-default value. CVA and DVA adjust this value to account for the real possibility that one side might default.

Imagine a bank and a company (the counterparty) have a bunch of derivatives trades between them. These are usually governed by a master agreement that includes **netting** — all trades are treated as one big position if someone defaults.

If the counterparty defaults:
- The bank looks at the net value of all trades.
- If the trades are worth money to the bank, it becomes an unsecured creditor and likely recovers only a portion of what it's owed.
- If the trades are worth money to the counterparty, the bank pays in full.

**CVA** is the bank's estimate of the present value of expected losses if the counterparty defaults. To calculate it, the bank divides the life of the trades into time intervals and estimates:

- The probability of the counterparty defaulting in each interval
- The expected loss if default happens in the middle of that interval

The formula is:

$\large{ CVA = \sum_{i=1}^N q_i v_i }$

where $q_i$ is the default probability in interval $i$, and $v_i$ is the present value of expected loss in that interval.

**DVA** is the opposite: it's the present value of the expected *gain* to the bank if *it* defaults. The formula looks similar:

$\large{ DVA = \sum_{i=1}^N q_i^* v_i^* }$

The adjusted value of the portfolio to the bank is:

$\large{ f_{nd} - CVA + DVA }$

where $f_{nd}$ is the no-default value.

Many people find DVA counterintuitive — how can a bank *benefit* from its own possible default? The simple explanation is that if the bank defaults when it owes money on derivatives, it doesn't have to pay the full amount. Since derivatives are zero-sum (one side's gain is the other's loss), the counterparty's loss becomes the bank's gain.

DVA also helps trades get done. Without it, both sides might demand too much compensation for the other's default risk, making agreement impossible.

**Collateral** makes things more complex. When collateral is posted, the bank can keep it to cover losses if the counterparty defaults (and vice versa). However, calculations must account for a "cure period" — a few days before default when the defaulting party might stop posting or returning collateral.

**Placeholder for diagram illustrating CVA/DVA**

### FVA and MVA

**FVA** (Funding Valuation Adjustment) and **MVA** (Margin Valuation Adjustment) account for the cost (or benefit) of funding derivatives positions.

Consider a bank that does an interest rate swap with a corporate client and hedges it perfectly with another bank through a central clearing party (CCP). The hedge might require posting margin, but the client trade might not.

- When the hedge requires the bank to post margin (initial or variation), the bank may have to borrow money to fund it → a cost.
- Sometimes the bank receives margin → a funding benefit.

FVA captures the net present value of these expected funding costs and benefits. MVA specifically focuses on the cost of funding **initial margin**.

**Placeholder for Figure 9.1 showing swaps with Bank A**

There is debate about how to measure funding costs:
- Many banks use their average borrowing cost.
- Financial economists argue you should use a marginal cost close to the risk-free rate, because margin is very low-risk and funding a low-risk investment shouldn't require a high return.

### KVA

**KVA** (Capital Valuation Adjustment) is a charge for the extra regulatory capital a bank must hold because of a new derivatives trade.

Banks must hold capital as a buffer against risks. If a trade requires more capital, some practitioners want to charge enough to earn the shareholders' required return (e.g., 15%) on that extra capital. Financial economists disagree, arguing that adding low-risk capital should lower the bank's overall cost of capital, so the marginal cost is smaller.

### Calculation Issues

All XVAs are computationally heavy. Banks use Monte Carlo simulations to estimate future exposures, funding needs, and capital requirements.

- CVA and DVA must be calculated for the **entire portfolio** with a counterparty because of netting.
- Incremental effects of a new trade depend on how it changes overall exposure.
- FVA can often be done trade-by-trade.
- MVA and KVA usually require looking at the whole relevant portfolio.

**Placeholder for image related to XVA calculations**

Banks are increasingly using machine learning (such as neural networks) to speed up these calculations, especially for quickly evaluating the impact of proposed new trades.