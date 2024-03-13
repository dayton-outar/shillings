See below the model used by Damodaran to identify the type of Cashflow model to use to evaluate an asset,

![Discounted Cashflow Model](/.attachments/discounted-cashflow-model.png)

Now, compare the above model by Damodaran with Simply Wall Street's model (or flowchart),[^2]

> DCF is the most widely-accepted method to calculate the fair value of a company. It is based on the premise that the fair value of a company is the total value of its incoming cash flow less its expenses, technically called Free Cash Flows (FCF), discounted to today&#39;s value.
>
> The SWS app uses four variations of DCF depending on the characteristics of a particular stock, such as industry and data availability.
> 
> - **2-Stage Discounted Cash Flow Model:** suitable for companies that do not necessarily grow at a constant rate over time. They tend to be high-growth initially, and become stable after a couple of years.
> - **Dividend Discount Model (DDM):** accurate for companies that consistently pays out a meaningful portion of their earnings as dividends.
> - **Excess Returns Model:** used for financial companies such as banks and insurance, generally do not have a significant proportion of physical assets, and face different regulatory requirements for cash holdings.
> - **Adjusted-Funds-From-Operations (AFFO) 2-Stage Discounted Cash Flow Model:** used for Real Estate Investment Trusts (REITs), as they incur capital gains and other real estate-specific factors which impacts their free cash flows.
>
> ![Simply Wall St Discounted Cash Flow Model Selection Process](/.attachments/simply.wall.st.intrinsic-value-flowchart.png)



If the company that issued stocks on a stock market pays dividends, a version of the Discounted Cash Flow Model referred to as the _Dividend-Discount Model_ can be applied to arrive at the net present value of the stock.

The equation below applies to a single N-year investor, who will collect dividends for N years and then sell the stock, or to a series of investors who hold the stock for shorter periods and then resell it.[^3]

$$\huge{P_0 = {Div_1 \over 1 + r_E} + {Div_2 \over (1 + r_E)^2} + {Div_3 \over (1 + r_E)^3} + \ldots + {Div_N \over (1 + r_E)^N} + { P_N \over (1 + r_E)^N } }$$

For the special case in which the firm eventually pays dividends and is never acquired, it is possible to hold the shares forever.

$$\huge{P_0 = {Div_1 \over 1 + r_E} + {Div_2 \over (1 + r_E)^2} + {Div_3 \over (1 + r_E)^3} + \ldots = \sum_{n=1}^\infty {Div_n \over (1 + r_E)^n} }$$

The main ingredients needed to arrive at the value of a company includes,

1. Financial Statements
   
   3 main statements are required: Income-Expense, Balance Sheet and Cashflow Statement

2. Stock Prices

   Used to calculate the risk and return. Helps to deduce _Cost of capital_

3. Stock Indices

   Used to arrive at a &beta; for the risk value of stock or portfolio being evaluated

4. Interest Rates of Jurisdiction

    These rates are described as the risk-free rate; important to calculate _Cost of capital_


$$\huge{Enterprise\text{ }Value\text{ }in\text{ }Year\text{ }T = V_T^L = { FCF_{T + 1} \over r_{wacc} - g } }$$

> we observed that the value of a firm is a function of three variables—its capacity to generate cash flows, its expected growth in these cash flows, and the uncertainty associated with these cash flows

See below an example of the breakdown of the intrinsic value of GK stock on JSE by Simply Wall Street.

![Breakdown of fair value of GK stock on JSE](/.attachments/SimplyWall.St-Instrinsic.Value.GK.2022.png)