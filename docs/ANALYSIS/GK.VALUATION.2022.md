# GraceKennedy Valuation

Credit to SimplyWall.st for this evaluation example.

## Share Price vs Fair Value

Below are the data sources, inputs and calculation used to determine the intrinsic value for GraceKennedy.

| Data Point | Source | Value |
|:--- |:--- | ---:|
| Valuation Model | | 2 Stage Free Cash Flow to Equity |
| Levered Free Cash Flow | Extrapolated from 2022 financials. | See below |
| Discount Rate | [Cost of Equity](#cost-of-equity) | 14.7% |
| Perpetual Growth Rate | 5-Year Average of JM Long-Term Govt Bond Rate | 7.5% |

_JMSE: GK Discounted Cash Flow Data Sources_

## Cost of Equity

An important part of a discounted cash flow is the discount rate, below we explain how it has been calculated.

| Data Point | Calculation/Source | Result |
|:--- |:--- | ---:|
| Risk-free Rate | 5-Year Average of JM Long-Term Govt Bond Rate | 7.5% |
| Equity Risk Premium | S&P Global | 9.0% |
| Consumer Retailing Unlevered Beta | Simply Wall St/ S&P Global | 0.55 |
| Re-levered Beta | = 0.33 + [(0.66 × Unlevered beta) × (1 + (1 - tax rate) (Debt/Market Equity))]<br />= 0.33 + [(0.66 × 0.551) × (1 + (1 - 25.0%) (34.81%))] | 0.795 |
| Levered Beta | Levered Beta limited to 0.8 to 2.0<br />(practical range for a stable firm) | 0.8 |
| Discount Rate/Cost of Equity | = Cost of Equity = Risk-free Rate + (Levered Beta × Equity Risk Premium)<br />= 7.54% + (0.800 × 9.00%) | 14.74% |

_Calculation of Discount Rate/ Cost of Equity for JMSE:GK_

## Free Cash Flow to Equity

***Discounted Cash Flow Calculation for JMSE:GK using 2 Stage Free Cash Flow to Equity***

The calculations below outline how an intrinsic value for GraceKennedy is arrived at by discounting future cash flows to their present value using the 2 stage method. We use analyst's estimates of cash flows going forward 10 years for the 1st stage, the 2nd stage assumes the company grows at a stable rate into perpetuity.


|     | Levered FCF (JMD, Millions) | Source | Present Value Discounted (@ 14.74%) |
|:--- | ---:|:--- | ---:|
| 2022 | 12,865.78 | Est @ 8.21% | J$11,212.98 |
| 2023 | 13,896.49 | Est @ 8.01% | J$10,555.41 |
| 2024 | 14,990.12 | Est @ 7.87% | J$9,923.4 |
| 2025 | 16,154.99 | Est @ 7.77% | J$9,320.67 |
| 2026 | 17,399.19 | Est @7.7% | J$8,748.93 |
| 2027 | 18,730.78 | Est @ 7.65% | J$8,208.55 |
| 2028 | 20,157.91 | Est @ 7.62% | J$7,699.13 |
| 2029 | 21,688.99  | Est @7.6% | J$7,219.73 |
| 2030 | 23,332.76 | Est @ 7.58% | J$6,769.13 |
| 2031 | 25,098.39 | Est @ 7.57% | J$6,345.96 |

Present value of next 10 years cash flows ... J$86,003

_JMSE:GK DCF 1st Stage: Next 10 years cash flow forecast_

## Terminal Value

|     | Calculation | Result |
|:--- |:--- | ---:|
| Terminal Value | FCF<sub>2031</sub> × (1 + g) ÷ (Discount Rate - g) <br />= J$25,098.391 × (1 + 7.54%) ÷ (14.74% - 7.54% ) | J$374,872.36 |
| Present Value of Terminal Value | = Terminal Value ÷ (1 +r )<sup>10</sup> <br />= J$374,872 ÷ (1 + 14.74%)<sup>10</sup> | J$94,783.99 |

_JMSE:GK DCF 2nd Stage: Terminal Value_

## Equity Value

$$\large{
  \text{Total Equity Value} = { \text{Present value of next 10 years cash flows} + \text{Terminal Value} } = 86,003 + 94,784 = 180,786.99
}$$

_JMSE:GK Total Equity Value_

## Stock Value

$$\huge{
  \text{Equity Value per Share} = { \text{Total Value} \over \text{Shares Outstanding} } = { 180,787 \over 990 } = 182.53
}$$

where $\text{Shares Outstanding}$ is Weighted average number of stock units outstanding (‘000) at 990,756.

## Discount to Stock Price

Discount to share price of J$98.48 is,

$$\huge{
  \text{Discount} = { (182.53 - 98.48) \over 182.53 } = 46.0
}$$

46.0%

_JMSE:GK Discount to Share Price_

## Appendix

### Equity Risk Premium vs. Market Risk Premium

The terms **Equity Risk Premium (ERP)** and **Market Risk Premium (MRP)** are closely related but can have slightly different meanings depending on the context. Here’s how they compare:

### 1. **Equity Risk Premium (ERP)**
The **Equity Risk Premium** refers specifically to the extra return that investors demand for holding **equities (stocks)** instead of a risk-free asset (such as government bonds). It represents the compensation for the higher risk associated with investing in stocks, as opposed to safer assets.

\[
\text{Equity Risk Premium} = \text{Expected Return on Stocks} - \text{Risk-Free Rate}
\]

### 2. **Market Risk Premium (MRP)**
The **Market Risk Premium** is a broader term that can refer to the extra return required for investing in the **overall market portfolio**, which often includes equities but can also include other assets, depending on the market definition.

In practice, the **Market Risk Premium** is usually used interchangeably with the Equity Risk Premium when discussing the returns expected from the stock market relative to the risk-free rate.

\[
\text{Market Risk Premium} = \text{Expected Market Return} - \text{Risk-Free Rate}
\]

### Key Differences (in Some Contexts):
- **Equity Risk Premium** is typically specific to the **equity (stock) market**.
- **Market Risk Premium** could refer to the premium for taking on the risk of investing in the **entire market** or a broader portfolio, which may include other assets like bonds, real estate, etc., but is often used to mean the equity market.

### Common Usage:
In most financial models, especially in the **Capital Asset Pricing Model (CAPM)**, the **Market Risk Premium** is commonly used to refer to the excess return of the stock market over the risk-free rate. So, in practical terms, the **Equity Risk Premium** and the **Market Risk Premium** are generally recognized as the same thing when discussing equities and their risk relative to risk-free assets.

### Summary:
In most cases, **Equity Risk Premium** and **Market Risk Premium** are used interchangeably to refer to the excess return expected from the stock market compared to a risk-free asset, although technically, the Market Risk Premium could be broader.