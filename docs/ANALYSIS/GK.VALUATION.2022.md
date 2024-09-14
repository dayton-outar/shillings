# GraceKennedy Valuation

Credit to SimplyWall.st for this evaluation example.

## Share Price vs Fair Value

Below are the data sources, inputs and calculation used to determine the intrinsic value for GraceKennedy.

| Data Point | Source | Value |
|:--- |:--- | ---:|
| Valuation Model | | 2 Stage Free Cash Flow to Equity |
| Levered Free Cash Flow | Extrapolated from most recent financials. | See below |
| Discount Rate (Cost of Equity) | See below | 14.7% |
| Perpetual Growth Rate | 5-Year Average of JM Long-Term Govt Bond Rate | 7.5% |

_JMSE: GK Discounted Cash Flow Data Sources_

An important part of a discounted cash flow is the discount rate, below we explain how it has been calculated.

| Data Point | Calculation/Source | Result |
|:--- |:--- | ---:|
| Risk-Free Rate | 5-Year Average of JM Long-Term Govt Bond Rate | 7.5% |
| Equity Risk Premium | S&P Global | 9.0% |
| Consumer Retailing Unlevered Beta | Simply Wall St/ S&P Global | 0.55 |
| Re-levered Beta | = 0.33 + [(0.66 × Unlevered beta) × (1 + (1 - tax rate) (Debt/Market Equity))]<br />= 0.33 + [(0.66 × 0.551) × (1 + (1 - 25.0%) (34.81%))] | 0.795 |
| Levered Beta | Levered Beta limited to 0.8 to 2.0<br />(practical range for a stable firm) | 0.8 |
| Discount Rate/Cost of Equity | = Cost of Equity = Risk Free Rate + (Levered Beta × Equity Risk Premium)<br />= 7.54% + (0.800 × 9.00%) | 14.74% |

_Calculation of Discount Rate/ Cost of Equity for JMSE:GK_

**Discounted Cash Flow Calculation for JMSE:GK using 2 Stage Free Cash Flow to Equity**

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


|     | Calculation | Result |
|:--- |:--- | ---:|
| Terminal Value | FCF<sub>2031</sub> × (1 + g) ÷ (Discount Rate - g) <br />= J$25,098.391 × (1 + 7.54%) ÷ (14.74% - 7.54% ) | J$374,872.36 |
| Present Value of Terminal Value | = Terminal Value ÷ (1 +r )<sup>10</sup> <br />= J$374,872 ÷ (1 + 14.74%)<sup>10</sup> | J$94,783.99 |

_JMSE:GK DCF 2nd Stage: Terminal Value_


|     | Calculation | Result |
|:--- |:--- | ---:|
| Total Equity Value | = Present value of next 10 years cash flows + Terminal Value <br /> = J$86,003 + J$94,784 | J$180,786.99 |
| Equity Value per Share (JMD) | = Total value / Shares outstanding <br />= J$180,787/990 | J$182.53 |

_JMSE:GK Total Equity Value_


|     | Calculation | Result |
|:--- |:--- | ---:|
| Value per share (JMD) | From above. | JMD182.53 |
| Current discount | Discount to share price of J$98.48 <br />= (J$182.53 - J$98.48)/ J$182.53 | 46.0% |

_JMSE:GK Discount to Share Price_