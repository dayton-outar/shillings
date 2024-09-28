# Supreme Ventures Valuation

Credit to 97083497, 03046872, 05031957, 620087213 & 620086948 enrolled in Advanced Corporate Finance (SBFI6020), Mona School of Business and Management

Below are the data sources, inputs and calculation used to determine the intrinsic value for Supreme Ventures Ltd.

| Data Point | Source | Value |
|:--- |:--- | ---:|
| Valuation Model | | [Free Cash Flow to Firm](#free-cash-flow-to-firm)[^1] |
| Discount Rate | [Cost of Capital](#cost-of-capital) | 11.5% |
| Projected Firm Growth | 5-Year Average of Firm's ROE and Retention Ratio[^2] | 3.3% |

### Firm Growth, 2010 - 2015

|                                                           | 2010             | 2011             | 2012             | 2013             | 2014             | 2015             | Average |
|:----------------------------------------------------------|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|--------:|
| Net Income                                                | $421,267         | $606,326         | $1,073,089       | $482,569         | $929,917         | $1,183,750       |         |
| Shareholder's Equity                                      | $3,324,028       | $3,326,772       | $3,793,292       | $3,642,919       | $4,045,385       | $3,594,037       |         |
| **Return on Equity (ROE)**                                | 12.7%            | 18.2%            | 28.3%            | 13.2%            | 23.0%            | 32.9%            | 21.4%   |
| Dividends                                                 | $369,216         | $580,249         | $738,432         | $448,334         | $659,313         | $1,081,274       |         |
| **Retention Ratio (RR)**                                  | 12.4%            | 4.3%             | 31.2%            | 7.1%             | 29.1%            | 8.7%             | 15.4%   |

## Cost of Capital

| Data Point | Calculation/Source | Result |
|:--- |:--- | ---:|
| Risk-free Rate (Annual) | Estimating 5-Year Average of a 12.5% 6 month T-Bill | 15% |
| Market Risk Premium | [Annualized Return](#annualized-return) of JSE Main Index Weekly Data (2010 - 2015) | 9.95%  |
| Levered Beta (β) | SVL Stock Prices vs. JSE Main Index Regression Analysis (2010 - 2015) | 0.9114 |
| Enterprise Risk Premium | Levered Beta (β) × ( Market Risk Premium - Risk-free Rate ) | -4.6% |
| Cost of Equity | Risk-free Rate + Enterprise Risk Premium (or Cost of Equity) | 10.4% |
| Cost of Debt | Varies based on the year. See [Breakdown of Cost of Debt](#breakdown-of-cost-of-debt) | [--](#breakdown-of-cost-of-debt) |
| Corporate Tax Rate | Using rate effective in 2013. See [Corporate Tax Rate](#corporate-tax-rate) | 25% |
| Weighed Average Cost of Capital | Average of Cost of Capital (2010 - 2015). See [Breakdown of Cost of Capital](#breakdown-of-cost-of-capital) | 11.5% |

### Breakdown of Cost of Debt

|                                                           | 2010             | 2011             | 2012             | 2013             | 2014             | 2015             |
|:----------------------------------------------------------|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|
| Long-term liabilities ('000)                              | $192,761         | $189,444         | $216,555         | $77,000          |                  |                  |
| Current portion of Long-term liabilities ('000)           | $118,614         | $214,605         | $142,708         | $141,408         | $77,000          |                  |
| ***Total Debt ('000)***                                   | ***$311,375***   | ***$404,049***   | ***$359,263***   | ***$218,408***   | ***$77,000***    | ***$0***         |
| ***Interest Expense***                                    | ***$41,608***    | ***$44,449***    | ***$39,791***    | ***$28,486***    | ***$16,344***    | ***$2,973***     |
| **[Cost of Debt](#cost-of-debt)**                         | **14.21%**       | **14.28%**       | **9.85%**        | **7.93%**        | **7.48%**        | **3.86%**        |

### Breakdown of Enterprise Value

|                                                    |      ***2010*** |      ***2011*** |      ***2012*** |      ***2013*** |      ***2014*** |      ***2015*** |
|:---------------------------------------------------|----------------:|----------------:|----------------:|----------------:|----------------:|----------------:|
| Total Shares                                       |   2,637,254,926 |   2,637,254,926 |   2,637,254,926 |   2,637,254,926 |   2,637,254,926 |   2,637,254,926 |
| Share Price                                        |           $2.20 |           $3.00 |           $2.85 |           $2.78 |           $1.91 |           $4.66 |
|**Market Capitalization ($) (’000) (Total Equity)** |  **$5,801,961** |  **$7,911,765** |  **$7,516,177** |  **$7,331,569** |  **$5,037,157** | **$12,289,608** |

To understand how the enterprise value based on market capitalization can be much higher than the share capital, we need to clarify a few concepts:

1. **Share Capital**: This refers to the funds raised by the company in exchange for shares of stock. In your example, the share capital is $1,967,183,000, which is based on the 2,637,254,926 stock units.

2. **Market Capitalization**: This is calculated by multiplying the total number of outstanding shares by the current market price per share. If the market capitalization is $12,289,608,000, it implies that the market price per share is significantly higher than the book value (share capital) per share.

3. **Enterprise Value (EV)**: This is a measure of a company's total value, often considered as the theoretical takeover price. It is calculated using the formula:
   $${
   \text{EV} = \text{Market Capitalization} + \text{Debt} - \text{Cash}
   }$$
   In this case, if the enterprise value is equal to the market capitalization of $12,289,608,000, it suggests that the company has minimal debt and cash, or that these factors balance out.

#### Example Calculation
If the market capitalization is $12,289,608,000 and the share capital is $1,967,183,000, the market price per share can be calculated as follows:

1. **Calculate Market Price per Share**:
   $${
   \text{Market Price per Share} = \frac{\text{Market Capitalization}}{\text{Number of Shares}} = \frac{12,289,608,000}{2,637,254,926} \approx 4.66
   }$$

2. **Book Value per Share**:
   $${
   \text{Book Value per Share} = \frac{\text{Share Capital}}{\text{Number of Shares}} = \frac{1,967,183,000}{2,637,254,926} \approx 0.75
   }$$

The significant difference between the market price per share ($4.66) and the book value per share ($0.75) indicates that investors are valuing the company based on its growth potential, assets, and future earnings, rather than just the capital contributed by shareholders.

### Breakdown of Cost of Capital

|                                                           | 2010             | 2011             | 2012             | 2013             | 2014             | 2015             |
|:----------------------------------------------------------|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|
| Long-term liabilities ('000)                              | $192,761         | $189,444         | $216,555         | $77,000          |                  |                  |
| Current portion of Long-term liabilities ('000)           | $118,614         | $214,605         | $142,708         | $141,408         | $77,000          |                  |
| *Total Debt ('000)*                                       | *$311,375*       | *$404,049*       | *$359,263*       | *$218,408*       | *$77,000*        | *$0*             |
| Cash ('000)                                               | $883,921         | $1,418,477       | $1,660,455       | $1,474,083       | $2,227,493       | $1,639,049       |
| ***Net Debt ('000)***                                     | ***-$572,546***  | ***-$1,014,428***| ***-$1,301,192***| ***-$1,255,675***| ***-$2,150,493***| ***-$1,639,049***|
| *Total Equity ('000)*                                     | *$5,801,961*     | *$7,911,765*     | *$7,516,177*     | *$7,331,569*     | *$5,037,157*     | *$12,289,608*    |
| ***Enterprise Value ('000)***                             | ***$5,229,415*** | ***$6,897,337*** | ***$6,214,985*** | ***$6,075,894*** | ***$2,886,664*** | ***$10,650,559***|
| Net Debt to Enterprise Value (D/(D+E))                    | -11%             | -15%             | -21%             | -21%             | -74%             | -15%             |
| Equity to Enterprise Value (E/(D+E))                      | 111%             | 115%             | 121%             | 121%             | 174%             | 115%             |
| Cost of Equity                                            | 10.40%           | 10.40%           | 10.40%           | 10.40%           | 10.40%           | 10.40%           |
| Cost of Debt                                              | 14.21%           | 14.28%           | 9.85%            | 7.93%            | 7.48%            | 3.86%            |
| Tax Rate                                                  | 33.33%           | 33.33%           | 33.33%           | 25.00%           | 25.00%           | 25.00%           |
| **WACC**                                                  | **10.50%**       | **10.52%**       | **11.20%**       | **11.32%**       | **13.96%**       | **11.55%**       |

The WACC remained relatively stable, averaging around 11.5%, with variations depending on debt levels, cash holdings, tax rates, and cost of debt.

## Free Cash Flow to Firm

Figures quoted in '000

|                                                           | 2009             | 2010             | 2011             | 2012             | 2013             | 2014             | 2015             |
|:----------------------------------------------------------|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----------------:|
| ***Net Income***                                          |                  | ***$421,267***   | ***$606,326***   | ***$1,073,089*** | ***$482,569***   | ***$929,917***   | ***$1,183,750*** |
| --                                                        |               -- |               -- |               -- |               -- |               -- |               -- |               -- |
| Profit Before Taxation                                    |                  | $705,588         | $1,063,561       | $1,453,766       | $711,092         | $1,215,741       | $1,614,830       |
| Taxation                                                  |                  | ($284,321)       | ($443,294)       | ($376,880)       | ($228,523)       | ($285,824)       | ($431,080)       |
| Profit                                                    |                  | $421,267         | $620,267         | $1,076,886       | $482,569         | $929,917         | $1,183,750       |
| *Effective Tax Rate*                                      |                  | *~40%*           | *~42%*           | *~26%*           | *~32%*           | *~24%*           | *~27%*           |
| Interest (Finance cost)                                   |                  | $41,608          | $48,600          | $39,791          | $28,486          | $16,344          | $2,973           |
| ***Interest × (1 - Effective Tax Rate)***                 |                  | ***$24,842***    | ***$28,343***    | ***$29,475***    | ***$19,331***    | ***$12,501***    | ***$2,179***     |
| --                                                        |               -- |               -- |               -- |               -- |               -- |               -- |               -- |
| Depreciation of property and equipment                    |                  | $185,590         | $196,731         | $187,322*        | $200,928         | $204,181         | $177,913         |
| Depreciation of investment properties                     |                  |                  |                  |                  |                  |                  | $9,102           |
| Amortisation of intangible assets                         |                  | $12,586          | $26,401          | $29,573          | $27,953          | $17,023          | $10,658          |
| Amortisation of other assets                              |                  | $6,023           | $5,019           | $656             | $6,393           | $6,855           | $4,381           |
| Impairment of available-for-sale investment               |                  |                  |                  | $2,124           | $9,048           | $348             |                  |
| Impairment of investment properties                       |                  |                  |                  |                  |                  |                  | $102,729         |
| Impairment losses recognised on trade receivables         |                  | $11,880          | $5,971           | $78,946          | $58,032          |                  |                  |
| Impairment losses on other receivables                    |                  |                  |                  | $26,000          |                  |                  |                  |
| Impairment of other assets                                |                  |                  |                  |                  |                  |                  | $15,988          |
| Intangible assets (such as Goodwill) written off          |                  |                  | $14,963          |                  |                  |                  | $3,627           |
| Bad debts recognised                                      |                  |                  |                  |                  |                  | $48,068          | $97,331          |
| Transfer from property and equipment to profit or loss    |                  |                  |                  | $197             |                  |                  |                  |
| Write-off of income tax receivable                        |                  |                  | $10,379          |                  |                  |                  |                  |
| Write-off of inventory                                    |                  | $3,470           |                  |                  |                  |                  |                  |
| Loss on disposal and write-off of property and equipment  |                  | $7,397 + ($27)   | ($859)           | $28,286          | $16,399          | $29,926          | $57,782          |
| Other gains and losses                                    |                  | $15,056          |                  |                  |                  |                  |                  |
| ***Depreciation/Amortization (Non-cash Charges)***        |                  | ***$241,975***   | ***$258,605***   | ***$353,104***   | ***$318,753***   | ***$306,401***   | ***$479,511***   |
| --                                                        |               -- |               -- |               -- |               -- |               -- |               -- |               -- |
| Current Assets                                            | $1,559,235       | $1,581,371       | $1,994,494       | $2,336,975       | $2,068,083       | $2,993,692       | $2,553,772       |
| Current Liabilities                                       | $1,144,693       | $1,122,577       | $1,403,740       | $1,609,123       | $1,590,616       | $1,847,178       | $1,804,876       |
| Net Working Capital (NWC)                                 | $414,542         | $458,794         | $590,754         | $727,852         | $477,467         | 1,146,514        | $748,896         |
| ***Change in Networking Capital (NWC)***                  |                  | ***$44,252***    | ***$131,960***   | ***$137,098***   | ***($250,385)*** | ***$669,047***   | ***($397,618)*** |
| --                                                        |               -- |               -- |               -- |               -- |               -- |               -- |               -- |
| Acquisition of property and equipment                     | $140,184         | $166,142         | $139,883         | $309,011         | $222,134         | $94,783          | $124,250         |
| Proceeds on disposal of property and equipment            | $6,485           | $249             | $6,101           | $4,350           | $15,059          | $204             | $353             |
| ***Fixed Assets (CAPEX)***                                |               -- | ***$165,893***   | ***$133,782***   | ***$304,661***   | ***$207,075***   | ***$94,579***    | ***$123,897***   |
| --                                                        |               -- |               -- |               -- |               -- |               -- |               -- |               -- |
| **Free Cash Flow to Firm (FCFF)**                         |                  | **$477,939**     | **$627,532**     | **$1,013,909**   | **$863,963**     | **$485,193**     | **$1,939,161**   |


## Appendix

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

The term premium in this case is deduced to be **2.5%**, which compensates investors for the additional risks (such as inflation, interest rate volatility, and liquidity) associated with holding a 5-year bond instead of a 6-month T-Bill. This premium is added to the expected short-term rates to arrive at the 5-year yield of 15%.

### Annualized Return

$$\huge{
  \text{Annualized Return} = \left( \frac{\text{Ending Value}}{\text{Beginning Value}} \right)^{\frac{1}{n}} - 1
}$$

### Cost of Equity

$$\huge{ 
  \text{Cost of Equity} = r_f + {\beta}_I \times (E[R_m] - r_f)
}$$

### Cost of Debt

The cost of debt can be calculated using total debt and interest expense. This method provides a straightforward way to estimate the effective interest rate that a company pays on its outstanding debt. The formula is:

$$\huge{
   \text{Cost of Debt} = \frac{\text{Interest Expense}}{\text{Total Debt}}
}$$

#### Steps to Calculate

1. **Determine Interest Expense:** 
   - This is typically found on the company's income statement and represents the total interest payments made during a specific period.

2. **Determine Total Debt:**
   - This includes all interest-bearing liabilities, which can be found on the balance sheet. It typically comprises both long-term and short-term debt.

3. **Apply the Formula:**
   - Plug the values into the formula to calculate the cost of debt as a percentage.

#### Example

- If a company has an interest expense of $100,000 and total debt of $1,000,000, the cost of debt would be:
$${
\text{Cost of Debt} = \frac{100,000}{1,000,000} = 0.10 \text{ or } 10\%
}$$

#### Note

- This calculation gives the nominal cost of debt. To find the after-tax cost of debt, you can multiply the cost of debt by (1 - tax rate), as interest expenses are tax-deductible.

### Corporate Tax Rate

Between 2010 and 2015, Jamaica's corporate tax rate was as follows:

- **2010 to 2013**: The standard corporate income tax rate was **33.33%**.
- **2013 onwards**: The government implemented a dual-rate system:
  - **25%** for most companies.
  - **30%** for regulated companies such as financial institutions (e.g., banks and insurance companies).

This tax reform aimed to simplify the system and stimulate business growth.

### Weighted Average Cost of Capital

The **Weighted Average Cost of Capital (WACC)** represents a firm's overall cost of capital, which is the weighted average of the cost of equity and the cost of debt. It reflects the required return on a company’s capital and is used as a discount rate to evaluate investment projects. The formula for WACC is:

$$\huge{
\text{WACC} = \left( \frac{E}{V} \times r_e \right) + \left( \frac{D}{V} \times r_d \times (1 - T) \right)
}$$

Where:
- ${ E }$ = Market value of the firm's equity
- ${ D }$ = Market value of the firm's debt
- ${ V }$ = Total value of the firm ( ${ V = E + D }$ )
- ${ r_e }$ = Cost of equity (the return required by equity investors)
- ${ r_d }$ = Cost of debt (the effective interest rate the firm pays on its debt)
- ${ T }$ = Corporate tax rate (since interest payments on debt are tax-deductible)

#### Key Components

1. **Cost of Equity ( ${ r_e }$ ):**
   The cost of equity is the return that equity investors expect to earn on their investment. It is often estimated using the **Capital Asset Pricing Model (CAPM)**:
   
   $$\large{
   r_e = r_f + \beta_e \times (E[R_m] - r_f)
   }$$
   
   Where:
   - ${ r_f }$ = Risk-free rate (usually based on government bond yields),
   - ${ \beta_e }$ = Levered beta of the company’s equity,
   - ${ E[R_m] - r_f }$ = Market risk premium (expected return of the market minus the risk-free rate).

2. **Cost of Debt ( ${ r_d }$ ):**
   The cost of debt is the effective interest rate that the company pays on its borrowings. Since interest is tax-deductible, the after-tax cost of debt is:

   $${
   \text{After-tax Cost of Debt} = r_d \times (1 - T)
   }$$

   Where ${ T }$ is the corporate tax rate.

3. **Weights ( ${ \frac{E}{V} }$ and ${ \frac{D}{V} }$ ):**
   The weights represent the proportion of financing that comes from equity ( ${ \frac{E}{V} }$ ) and debt ( ${ \frac{D}{V} }$ ) in the firm’s capital structure. These weights are based on the market values of equity and debt, not the book values.

#### Steps to Calculate WACC

1. **Determine the Market Value of Equity ( ${ E }$ ):**
   The market value of equity is the company’s share price multiplied by the number of outstanding shares.

2. **Determine the Market Value of Debt ( ${ D }$ ):**
   The market value of debt can be more complex to estimate but is often approximated by the book value of debt or by discounting the future interest payments.

3. **Calculate the Cost of Equity ( ${ r_e }$ ):**
   Using the CAPM formula or another model, estimate the cost of equity based on the risk-free rate, beta, and market risk premium.

4. **Estimate the Cost of Debt ( ${ r_d }$ ):**
   The cost of debt is generally the average yield to maturity on the company’s outstanding debt or the interest rate on recent borrowings.

5. **Calculate the Weights ( ${ \frac{E}{V} }$ and ${ \frac{D}{V} }$ ):**
   The weights are calculated by dividing the market value of equity and debt by the total firm value ${ V = E + D }$.

6. **Apply the WACC Formula:**
   Plug all values into the WACC formula to determine the company’s weighted average cost of capital.

#### Example Calculation
Assume the following data for a company:
- Market value of equity ( ${ E }$ ): $200 million,
- Market value of debt ( ${ D }$ ): $100 million,
- Cost of equity ( ${ r_e }$ ): 10%,
- Cost of debt ( ${ r_d }$ ): 6%,
- Corporate tax rate ( ${ T }$ ): 30%.

First, calculate the weights:

$${
V = E + D = 200 + 100 = 300 \text{ million}
}$$

$${
\frac{E}{V} = \frac{200}{300} = 0.67, \quad \frac{D}{V} = \frac{100}{300} = 0.33
}$$

Now calculate WACC:

$${
\text{WACC} = \left( 0.67 \times 10 \right) + \left( 0.33 \times 6 \times (1 - 0.30) \right)
}$$

$${
\text{WACC} = 6.7 + 1.386 = 8.086
}$$

Thus, the company’s WACC is **8.09%**.

The **WACC** reflects the company’s blended cost of capital across its debt and equity, taking into account the tax benefits of debt. It is a critical input for valuing projects and investments, as it serves as the discount rate for future cash flows.

### Free Cash Flow

When incorporating **interest expenses** into the Free Cash Flow (FCF) formula, it depends on whether you're calculating **Free Cash Flow to the Firm (FCFF)** or **Free Cash Flow to Equity (FCFE)**. Here's how interest affects both:

1. **Free Cash Flow to the Firm (FCFF)** (Unlevered Free Cash Flow)
FCFF represents the cash flow available to **all investors** (both equity and debt holders). In this case, **interest expenses** are added back after adjusting for taxes, because FCFF shows cash flow before debt payments.

$${
\text{FCFF} = \text{Net Income} + \text{Non-Cash Charges} + \text{Interest Expense} \times (1 - \text{Tax Rate}) - \text{Change in Working Capital} - \text{Capital Expenditures (CapEx)}
}$$

Where:
- **Interest Expense**: The cost of servicing debt (found on the income statement).
- **(1 - Tax Rate)**: Represents the tax shield on interest, as interest payments are tax-deductible.

2. **Free Cash Flow to Equity (FCFE)** (Levered Free Cash Flow)
FCFE represents the cash flow available **only to equity shareholders**. In this case, interest payments are **not added back**, because they are cash outflows paid to debt holders.

$${
\text{FCFE} = \text{Net Income} + \text{Non-Cash Charges} - \text{Change in Working Capital} - \text{Capital Expenditures (CapEx)} + \text{Net Borrowing}
}$$

Where:
- **Net Borrowing**: Represents the additional debt raised (or repaid), which impacts cash flow to equity holders.

#### Expanded **FCFF** Formula (with Interest)

$${
\text{FCFF} = \left( \text{Net Income} + \text{Depreciation/Amortization} \right) + \left( \text{Interest Expense} \times (1 - \text{Tax Rate}) \right) - \text{Change in Working Capital} - \text{CapEx}
}$$

***Note Well*** $\text{Depreciation/Amortization}$ is also referred to as ${\text{Non-cash Charges}}$

#### Expanded **FCFE** Formula (without adding back Interest)

$${
\text{FCFE} = \left( \text{Net Income} + \text{Depreciation/Amortization} \right) - \text{Change in Working Capital} - \text{CapEx} + \text{Net Borrowing}
}$$


#### Explanation

- In **FCFF**, **interest expense** is added back (adjusted for tax savings) because it represents cash flow before payments to debt holders.
- In **FCFE**, interest is **not added back** because the cash flow to equity holders occurs after debt obligations are met.

**Which formula to use** depends on whether you are evaluating cash flows from the perspective of the entire firm (FCFF) or only equity shareholders (FCFE).

[^1]: Supreme Ventures started out mostly with equity but the leverage is not stable
[^2]: _Growth, g_ = Average Retention Ratio × Average Return on Equity
[^3]: The longest available bond in January 2010 was the 6 month T-Bill at a rate of 12.5%