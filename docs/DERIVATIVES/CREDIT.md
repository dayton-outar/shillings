# Chapter 24: Credit Risk

Most derivatives we've discussed so far deal with market risk — what happens when prices move against you. But financial institutions face another major risk: **credit risk**. This is the danger that borrowers or trading partners will default and not pay what they owe. Banks and other institutions spend a lot of time and money measuring and managing this risk. Regulators also require banks to hold extra capital as a buffer against potential credit losses.

Credit risk comes from the possibility that someone you lent money to — or traded derivatives with — might go bankrupt. This chapter explains ways to estimate how likely a company is to default, the difference between real-world and risk-neutral default probabilities, how credit risk shows up in over-the-counter derivatives, and tools like default correlation and Gaussian copula models. It also covers how to calculate credit value at risk.

## Credit Ratings

Rating agencies like Moody’s, S&P, and Fitch rate the creditworthiness of corporate bonds. 

- The best rating from Moody’s is **Aaa** — these bonds almost never default.
- Next come **Aa**, **A**, **Baa**, **Ba**, **B**, **Caa**, **Ca**, and **C**.
- Bonds rated **Baa** or higher are considered **investment grade** (relatively safe).
- Lower ratings are **speculative grade** or "junk" bonds.

S&P and Fitch use a similar scale: AAA, AA, A, BBB, BB, B, CCC, CC, and C. They also add pluses and minuses for finer detail (e.g., AA+, AA, AA−).

**Placeholder for chapter opening image**

## Historical Default Probabilities

Rating agencies publish data showing how often bonds of different ratings actually defaulted over long periods.

Here is typical data showing the **cumulative percentage** of bonds that had defaulted by the end of each time period:

**Table: Average cumulative default rates (%), 1981–2019**

| Rating | 1 yr | 2 yr | 3 yr | 4 yr | 5 yr | 7 yr | 10 yr | 15 yr |
|--------|------|------|------|------|------|------|-------|-------|
| AAA    | 0.00 | 0.03 | 0.13 | 0.24 | 0.35 | 0.51 | 0.70  | 0.91  |
| AA     | 0.02 | 0.06 | 0.12 | 0.21 | 0.31 | 0.50 | 0.72  | 1.02  |
| A      | 0.05 | 0.14 | 0.23 | 0.35 | 0.47 | 0.79 | 1.24  | 1.89  |
| BBB    | 0.16 | 0.45 | 0.78 | 1.17 | 1.58 | 2.33 | 3.32  | 4.69  |
| BB     | 0.61 | 1.92 | 3.48 | 5.05 | 6.52 | 9.01 | 11.78 | 14.67 |
| B      | 3.33 | 7.71 | 11.55| 14.58| 16.93| 20.36| 23.74 | 27.12 |
| CCC/C  |27.08 |36.64 |41.41 |44.10 |46.19 |48.26 |50.38  |52.59  |

**Example**: A bond rated BBB had a 0.16% chance of defaulting in the first year, and 0.45% by the end of year 2. So the chance it defaults specifically *during* year 2 is 0.45% - 0.16% = 0.29%.

## Hazard Rates

We can dig deeper by calculating **hazard rates** — the probability of default in a short period, *assuming the company hasn't defaulted yet*.

For example, for a CCC/C bond:
- Cumulative default by end of year 2: 36.64%
- Cumulative default by end of year 3: 41.41%
- Unconditional probability of default in year 3: 4.77%
- Survival probability to end of year 2: 63.36%
- **Conditional** probability of default in year 3 (given survival so far): about 7.53%

Mathematically, if ${V(t)}$ is the probability of surviving until time ${t}$, and ${\lambda(t)}$ is the hazard rate, then:

$${V(t) = e^{-\int_0^t \lambda(s) ds}}$$

Or, if the hazard rate is roughly constant:

$${Q(t) = 1 - e^{-\lambda t} \quad (24.1)}$$

where ${Q(t)}$ is the cumulative default probability by time ${t}$.

## Recovery Rates

When a company defaults, creditors don't usually lose everything. The **recovery rate** is what they get back as a percentage of the face value.

- Recovery depends on whether the bond is senior (paid first) or secured (has collateral).
- A common average assumption is **40%** recovery.

Recovery rates tend to be lower when many companies are defaulting at once (bad economy = more houses or assets for sale = lower prices = worse recoveries).

## Estimating Default Probabilities from Bond Yield Spreads

Another way to estimate default risk is by looking at how much extra yield (spread) risky bonds pay compared to safe government bonds.

The idea is simple: that extra yield compensates investors for expected losses from defaults.

If ${s(T)}$ is the annual spread for a ${T}$-year bond, and ${R}$ is the recovery rate, then the average hazard rate is roughly:

$${\lambda(T) \approx \frac{s(T)}{1 - R} \quad (24.2)}$$

**Example**: If a bond yields 1.5% more than the risk-free rate and recovery is 40%, the implied hazard rate is about 2.5% per year.

More precise calculations match actual bond prices by solving for hazard rates that make the present value of expected default losses match the price discount.

**Placeholder for bond pricing calculation image**

## The Risk-Free Rate

These calculations depend heavily on choosing the right risk-free rate. Treasury rates are often used but tend to be too low. Many experts now use rates close to OIS (Overnight Indexed Swap) rates instead.

## Comparison of Default Probability Estimates

Default probabilities from **historical data** (real-world) are usually much lower than those implied by **bond prices** (risk-neutral).

Here's a comparison for 7-year average hazard rates:

**Table 24.2: Seven-year average hazard rates (% per annum)**

| Rating     | Historical | From bonds | Ratio | Difference |
|------------|------------|------------|-------|------------|
| Aaa        | 0.04       | 0.67       | 16.8  | 0.63       |
| Aa         | 0.06       | 0.78       | 13.0  | 0.72       |
| A          | 0.13       | 1.28       | 9.8   | 1.15       |
| Baa        | 0.47       | 2.38       | 5.1   | 1.91       |
| Ba         | 2.40       | 5.07       | 2.1   | 2.67       |
| B          | 7.49       | 9.02       | 1.2   | 1.53       |
| Caa+lower  |16.90       |21.30       | 1.3   | 4.40       |

Risk-neutral probabilities (from bond spreads) are higher because they include a risk premium — investors demand extra return for the uncertainty and clustering of defaults.

**Table 24.3: Expected excess return on bonds (basis points)**

| Rating | Bond yield spread | Spread for historical defaults | Excess return |
|--------|-------------------|--------------------------------|---------------|
| Aaa    | 40                | 2                              | 38            |
| Aa     | 47                | 4                              | 43            |
| A      | 77                | 8                              | 69            |
| Baa    |143                |28                              |115            |
| Ba     |304                |144                             |160            |
| B      |542                |449                             | 93            |
| Caa    |1278               |1014                            |264            |

## Real-World vs. Risk-Neutral Probabilities

- **Real-world (physical) probabilities**: Based on actual history. Use these when doing "what if" stress tests or forecasting actual losses.
- **Risk-neutral probabilities**: Higher, because they come from market prices. Use these when **valuing** derivatives or pricing instruments that have credit risk.

The gap exists because defaults tend to happen in clusters during bad economic times (systematic risk), and individual bond risk is hard to fully diversify away.

> **Which probability should you use?**  
> Use risk-neutral probabilities when valuing credit derivatives or pricing instruments.  
> Use real-world probabilities when running scenario analyses for potential future losses.

This modernized approach makes credit risk concepts much more approachable while keeping the core data, tables, and math intact.

**Using Equity Prices to Estimate Default Probabilities**

Credit ratings are updated slowly. Analysts realized that a company's stock price can give more timely clues about default risk. In 1974, Robert Merton proposed a clever way to think about this.

Imagine a company with assets worth **V** today. It has debt that must be repaid **D** at time **T**. At maturity:

- If the assets are worth more than **D**, the company pays the debt and shareholders get the rest.
- If assets are worth less than **D**, the company defaults and shareholders get nothing.

This makes **equity** like a **call option** on the company's assets, with a strike price equal to the debt repayment.

Using the Black-Scholes-Merton formula, the value of equity today is:

$${E_0 = V_0 N(d_1) - D e^{-rT} N(d_2)}$$

where

$${d_1 = \frac{\ln(V_0 / D) + (r + \sigma_V^2 / 2)T}{\sigma_V \sqrt{T}}, \quad d_2 = d_1 - \sigma_V \sqrt{T}}$$

The risk-neutral probability of default is **N(-d₂)**.

We can solve for the unobservable asset value **V₀** and asset volatility **σ_V** using the observed equity value and equity volatility.

**Placeholder for Merton model diagram**

**Example**: A company's equity is worth $3 million with 80% volatility. It owes $10 million in debt due in 1 year. Risk-free rate is 5%. Solving gives asset value ≈ $12.4 million and asset volatility ≈ 21.2%. Default probability ≈ 12.7%.

Merton's model and its extensions do a good job ranking companies by default risk. They can be calibrated to estimate either real-world or risk-neutral default probabilities.

## Credit Risk in Derivatives Transactions

Derivatives traded directly between two parties (bilaterally cleared) are usually governed by an ISDA Master Agreement. When one party defaults, the other can terminate all contracts.

Losses occur in two main situations:

- The non-defaulting party is owed money overall, but the collateral posted is not enough.
- The defaulting party is owed money, but the non-defaulting party has posted excess collateral that isn't fully returned.

## CVA and DVA

**Credit Valuation Adjustment (CVA)** is the expected cost to a bank if its counterparty defaults.  
**Debit Valuation Adjustment (DVA)** is the benefit to the bank if *it* defaults (it might not have to pay everything owed).

The adjusted value of a derivatives portfolio is:  
**No-default value − CVA + DVA**

Banks calculate these by dividing the life of the deals into time intervals and using risk-neutral default probabilities from credit spreads. They run Monte Carlo simulations to estimate future exposure at each possible default time.

**Placeholder for CVA calculation image**

When collateral is posted, calculations get more complex. Banks assume the defaulting party stops posting or returning collateral during a "cure period" (often 10–20 days) before default.

**Example scenarios for collateralized exposure**:

- Positive value to bank but collateral covers most → small exposure.
- Negative value to bank but excess collateral posted → exposure on the excess.

Banks also track **peak exposure** (high percentile of possible losses) for risk management.

**Wrong-way risk** happens when default probability rises at the same time as exposure. **Right-way risk** is the opposite.

## Credit Risk Mitigation

Common ways to reduce credit risk:

- **Netting**: All deals with one counterparty are treated as one net position instead of separate ones.
- **Collateral**: Cash or securities posted to cover potential losses.
- **Downgrade triggers**: If a counterparty's credit rating falls below a level (e.g., BBB), the bank can demand collateral or close out deals.

> **Business Snapshot: Downgrade Triggers and AIG**  
> AIG had many derivatives guaranteeing AAA-rated mortgage securities. Contracts said AIG didn't need to post collateral while rated AA or better. When downgraded below AA in September 2008, massive collateral calls came in. AIG couldn't pay and needed a huge government bailout.

## Special Cases

For simple cases, CVA can be calculated without full simulation.

For a single uncollateralized option paying off at time **T**:

$${CVA = (1 - R) \times f_{nd} \sum q_i}$$

where **f_nd** is the no-default value and **q_i** are default probabilities in each interval.

The risky value of the derivative becomes:

$${f = f_{nd} \times e^{-sT}}$$

where **s** is the counterparty's credit spread.

For a forward contract, exposure can be calculated analytically using Black's model.

**Example**: A bank agrees to buy gold forward. CVA reduces the value based on expected losses from counterparty default.

## Default Correlation

Defaults are correlated — companies tend to default together during recessions, in the same industry, or due to contagion. This is why risk-neutral default probabilities are higher than real-world ones.

Two modeling approaches:

- **Reduced-form models**: Hazard rates move together with the economy.
- **Structural models**: Based on asset values (like Merton), with correlated asset processes.

## The Gaussian Copula Model for Time to Default

This popular model links default times of different companies. It transforms cumulative default probabilities into standard normal variables and assumes those are jointly normal with a correlation parameter.

For many companies, a **one-factor version** is often used:

$${x_i = a_i F + \sqrt{1 - a_i^2} Z_i}$$

where **F** is a common market factor and **Z_i** is company-specific.

## Credit VaR

Credit Value at Risk measures potential credit losses over a time horizon at a high confidence level (e.g., 99.9%).

Using the one-factor Gaussian copula, the worst-case default rate at confidence **X** is:

$${V(X, T) = N\left( \frac{N^{-1}(Q(T)) + \sqrt{\rho} N^{-1}(X)}{\sqrt{1 - \rho}} \right)}$$

**Example**: $100 million portfolio, 2% average default probability, 60% recovery, 10% correlation → 99.9% Credit VaR ≈ $5.13 million.

## CreditMetrics

Many banks use Monte Carlo simulation of credit rating changes (including downgrades) for all counterparties, then revalue the portfolio to get the full loss distribution.

**Table: One-year ratings transition matrix, 1981–2019**

| Initial rating | AAA   | AA    | A     | BBB   | BB    | B     | CCC/C | Default |
|----------------|-------|-------|-------|-------|-------|-------|-------|---------|
| AAA            | 89.83 | 9.37  | 0.55  | 0.05  | 0.11  | 0.03  | 0.05  | 0.00    |
| AA             | 0.51  | 90.77 | 8.06  | 0.50  | 0.05  | 0.06  | 0.02  | 0.02    |
| A              | 0.03  | 1.74  | 92.49 | 5.27  | 0.28  | 0.12  | 0.02  | 0.05    |
| BBB            | 0.01  | 0.10  | 3.59  | 91.83 | 3.73  | 0.47  | 0.11  | 0.17    |
| BB             | 0.01  | 0.03  | 0.12  | 5.23  | 86.06 | 7.27  | 0.60  | 0.67    |
| B              | 0.00  | 0.02  | 0.08  | 0.18  | 5.43  | 85.38 | 5.10  | 3.80    |
| CCC/C          | 0.00  | 0.00  | 0.13  | 0.22  | 0.69  |15.33 |51.61 |32.03   |

A Gaussian copula links the rating changes across companies using equity return correlations.

**Placeholder for transition matrix visualization**