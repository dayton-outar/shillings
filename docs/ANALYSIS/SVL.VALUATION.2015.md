# Supreme Ventures Valuation

Credit to 97083497, 03046872, 05031957, 620087213 & 620086948 enrolled in Advanced Corporate Finance (SBFI6020), Mona School of Business and Management

Below are the data sources, inputs and calculation used to determine the intrinsic value for Supreme Ventures Ltd.

| Data Point | Source | Value |
|:--- |:--- | ---:|
| Valuation Model | | Free Cash Flow to Firm[^1] |
| Levered Free Cash Flow? | Extrapolated from most recent financials. | See below |
| Discount Rate | [Cost of Capital](#cost-of-capital) | -- |
| Projected Firm Growth | 5-Year Average of Firm's ROE and Retention Ratio[^2] | 3.3% |

## Cost of Capital

| Data Point | Calculation/Source | Result |
|:--- |:--- | ---:|
| Risk-free Rate (Annual) | Estimating 5-Year Average of a 12.5% 6 month T-Bill | 15% |
| Market Risk Premium | Annualized Return of JSE Main Index (2010 - 2015) | 9.95%  |

### Deducing Risk-free Rate

To derive the 5-year yield using just the 6-month T-Bill rate of 12.5%, we can apply a simplified version of the **extrapolation method**. In this case, we assume that the yield on the 5-year bond reflects both the short-term rate and some upward adjustment due to the longer duration. Here’s a simple way to do it:

#### Step 1: **Assume a Constant Spread**
Given that the 6-month T-Bill rate is **12.5%**, we assume that the 5-year yield will be higher to compensate for the longer duration. A reasonable way to estimate this is by applying a **constant spread** between short-term and long-term rates.

Since 5-year bonds usually yield more than 6-month bonds, let’s assume a basic **rule of thumb** spread of around **2.5%**. This spread accounts for the additional risks and uncertainties associated with holding a longer-term bond.

#### Step 2: **Add the Spread**
Simply add the spread to the 6-month T-Bill rate:

$${
\text{5-Year Yield} = \text{6-month T-Bill Rate} + \text{Spread}
}$$

Substitute the given values:

$${
\text{5-Year Yield} = 12.5\% + 2.5\% = 15\%
}$$

### Deducing the Term Premium

To deduce the **term premium**, we need to break down its components. The term premium reflects the additional compensation investors require for holding long-term bonds due to the risks associated with factors like inflation, interest rate volatility, and liquidity over time. Here’s a structured approach to deducing it:

#### 1. **Interest Rate Expectations (Expectations Hypothesis)**
One component of long-term yields is the market’s expectation of future short-term rates. According to the **expectations hypothesis**, the yield on a long-term bond should reflect the average of the expected future short-term rates. If the future 6-month rates are expected to stay close to the current 6-month T-Bill rate, we can express the long-term yield as:

$${
\text{5-Year Yield (without premium)} = \frac{\text{(6-month rate + Expected future 6-month rates over the next 5 years)}}{5}
}$$

In this case, we’re given a 6-month T-Bill rate of 12.5%. If we assume that future rates will hover around this same level, the **average expected rate** over 5 years is still approximately **12.5%**.

#### 2. **Risks with Longer-Term Bonds**
The term premium compensates investors for the risks that are more pronounced with long-term bonds. These risks include:

- **Inflation risk**: Over a longer period, there is a higher probability that inflation will erode the bond’s purchasing power.
- **Interest rate risk**: Interest rates can fluctuate, and investors may miss out on higher yields available in the future if they are locked into a lower long-term rate.
- **Reinvestment risk**: In the case of coupon-paying bonds, there’s a risk that future interest payments (coupons) will need to be reinvested at lower rates.
- **Liquidity risk**: Long-term bonds may be less liquid than short-term ones.

To quantify these risks, investors demand a higher return on long-term bonds compared to short-term bonds.

#### 3. **Historical Data and Estimation**
Historically, the **term premium** for long-term government bonds has typically ranged from 1% to 3%, depending on economic conditions. During times of economic uncertainty (such as post-2008 financial crisis, in 2010), the term premium tends to increase as investors require more compensation for the higher risks.

Let’s assume, based on historical averages during periods of uncertainty, the term premium for a 5-year bond is **2.5%**.

#### 4. **Calculating the Term Premium**

To derive the term premium, we use the following relationship:

$${
\text{Term Premium} = \text{5-Year Yield} - \text{Average Expected 6-Month Rates}
}$$

Given the 5-year yield estimate is **15%**, and the average expected 6-month rate is **12.5%** (based on the 6-month T-Bill rate), we can calculate the term premium as:

$${
\text{Term Premium} = 15\% - 12.5\% = 2.5\%
}$$

#### Conclusion:
The term premium in this case is deduced to be **2.5%**, which compensates investors for the additional risks (such as inflation, interest rate volatility, and liquidity) associated with holding a 5-year bond instead of a 6-month T-Bill. This premium is added to the expected short-term rates to arrive at the 5-year yield of 15%.

### Annualized Return

$$\huge{
  \text{Annualized Return} = \left( \frac{\text{Ending Value}}{\text{Beginning Value}} \right)^{\frac{1}{n}} - 1
}$$


[^1]: Supreme Ventures started out mostly with equity but the leverage is not stable
[^2]: _Growth, g_ = Average Retention Ratio × Average Return on Equity
[^3]: The longest available bond in January 2010 was the 6 month T-Bill at a rate of 12.5%