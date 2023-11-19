# Asset Evaluation

> Valuation matters in the super-long-term, for example, while positioning and momentum matter much more in the short-term.[^1]

![Valuation Models](/.attachments/valuation-models.png)

There are 2 main approaches to valuation,

1. Discounted Cash Flow Model
2. Relative Valuation

## Discounted Cashflow Model

See below the model used by Damodaran to identify the type of Cashflow model to use to evaluate an asset,

![Discounted Cashflow Model](/.attachments/discounted-cashflow-model.png)

Now, compare the above model by Damodaran with Simply Wall Street's model (or flowchart),

![Simply Wall Street](/.attachments/simply.wall.st.intrinsic-value-flowchart.png)

The value of any asset following the present value rule is, 

$$\huge{Value = \sum_{t=1}^{t=n}{CF_{t} \over (1 + r)^t}}$$

where,

<blockquote>
<p>n = Life of the asset</p>
<p>CF<sub>t</sub> = Cash flow in period t</p>
<p>r = Discount rate reflecting the riskiness of the estimated cash flows</p>
</blockquote>

Cash flow can be determined from 2 main sources for stocks: dividends and free cash flow. Some of the mathematical approaches to evaluation of a stock includes,

1. Dividend-Discount Model
2. Free Cash Flow to Equity Model
3. Free Cash Flow to Firm Model

If the company that issued stocks on a stock market pays dividends, a version of the Discounted Cash Flow Model referred to as the _Dividend-Discount Model_ can be applied to arrive at the net present value of the stock.

The equation below applies to a single N-year investor, who will collect dividends for N years and
then sell the stock, or to a series of investors who hold the stock for shorter periods and
then resell it.[^2]

$$\huge{P_0 = {Div_1 \over 1 + r_E} + {Div_2 \over (1 + r_E)^2} + {Div_3 \over (1 + r_E)^3} + \ldots + {Div_N \over (1 + r_E)^N} + { P_N \over (1 + r_E)^N } }$$

For the special case in which the firm eventually
pays dividends and is never acquired, it is possible to hold the shares forever.[^2]

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


## Further Reading

1. Corporate Finance: The Core, Global Edition by Jonathan Berk, Peter Demarzo
2. Investment Valuation by Aswath Damodaran
3. Investment Banking by Joshua Rosenbaum and Joshua Pearl
4. [How Investors Can Use Adjusted Funds From Operations (AFFO) to Measure REIT Performance](https://www.millionacres.com/real-estate-investing/reits/how-to-use-affo-to-meaure-reit-performance/)
5. [Funds From Operations (FFO)](https://www.investopedia.com/terms/f/fundsfromoperation.asp)
6. [Adjusted Funds From Operations—AFFO](https://www.investopedia.com/terms/a/affo.asp)
7. [Why It's Important to Unlever the Beta When Making WACC Calculations](https://www.investopedia.com/ask/answers/102714/why-do-i-need-unlever-beta-when-making-wacc-calculations.asp)
8. [Valuing Firms Using Present Value of Free Cash Flows](https://www.investopedia.com/articles/fundamental-analysis/11/present-value-free-cash-flow.asp)
9. [What the Dow Means and How It Is Calculated](https://www.investopedia.com/articles/investing/082714/what-dow-means-and-why-we-calculate-it-way-we-do.asp)
10. [Simply Wall St Company Analysis Model](https://github.com/SimplyWallSt/Company-Analysis-Model/blob/master/MODEL.markdown)
11. [What Is the Formula for Calculating Free Cash Flow?](https://www.investopedia.com/ask/answers/033015/what-formula-calculating-free-cash-flow.asp) - [Investopedia](https://www.investopedia.com/)
12. [What Is Free Cash Flow?](https://www.thebalancemoney.com/what-is-free-cash-flow-and-how-can-you-calculate-it-393111) - [The Balance](https://www.thebalancemoney.com/)
13. [Stable Growth vs. 2-Stage Valuation Model](https://corporatefinanceinstitute.com/resources/templates/excel-modeling/stable-growth-vs-2-stage-valuation-model/) - [CFI](https://corporatefinanceinstitute.com/)
14. [Valuing Firms Using Present Value of Free Cash Flows](https://www.investopedia.com/articles/fundamental-analysis/11/present-value-free-cash-flow.asp) - [Investopedia](https://www.investopedia.com/)
15. [Terminal Value (TV) Definition and How to Find The Value (With Formula)](https://www.investopedia.com/terms/t/terminalvalue.asp) - [Investopedia](https://www.investopedia.com/)
16. [Weighted Average Cost of Capital (WACC) Explained with Formula and Example](https://www.investopedia.com/terms/w/wacc.asp) - [Investopedia](https://www.investopedia.com/)
17. [Working Capital: Formula, Components, and Limitations](https://www.investopedia.com/terms/w/workingcapital.asp) - [Investopedia](https://www.investopedia.com/)
18. [Non-Cash Charge Definition](https://www.investopedia.com/terms/n/noncashcharge.asp#:~:text=Non%2Dcash%20charges%20can%20be,cash%20transfer%20has%20been%20made.) - [Investopedia](https://www.investopedia.com/)
19. [Beta Formula: How to Calculate the Beta of a Stock](https://www.investopedia.com/ask/answers/070615/what-formula-calculating-beta.asp#:~:text=Beta%20could%20be%20calculated%20by,returns%20and%20the%20benchmark's%20returns.) - [Investopedia](https://www.investopedia.com/)
20. [Company growth rate: the best formula to calculate it](https://www-profitwell-com.cdn.ampproject.org/v/s/www.profitwell.com/recur/all/company-growth-rate/?amp_gsa=1&amp_js_v=a9&hs_amp=true&usqp=mq331AQKKAFQArABIIACAw%3D%3D#amp_tf=From%20%251%24s&aoh=16704998568074&referrer=https%3A%2F%2Fwww.google.com&ampshare=https%3A%2F%2Fwww.profitwell.com%2Frecur%2Fall%2Fcompany-growth-rate%2F)
21. [LaTeX/Mathematics - Wikibooks, open books for an open world](https://en.wikibooks.org/wiki/LaTeX/Mathematics#Operators)
22. [Markdown Math Support](https://github.blog/2022-05-19-math-support-in-markdown/)
23. [Sigma, summation symbol in Latex](https://latexhelp.com/latex-sigma-symbol/) - [Latex Help](https://latexhelp.com/)
24. [How to Calculate the Beta of a Private Company](https://www.investopedia.com/articles/personal-finance/050515/how-calculate-beta-private-company.asp) - [Investopedia](https://www.investopedia.com/)
25. [Capitalization Rate: Cap Rate Defined With Formula and Examples](https://www.investopedia.com/terms/c/capitalizationrate.asp) - [Investopedia](https://www.investopedia.com/)
26. [Enterprise Multiple (EV/EBITDA): Definition, Formula, Examples](https://www.investopedia.com/terms/e/ev-ebitda.asp) - [Investopedia](https://www.investopedia.com/)
27. [What Is Enterprise Value-to-Sales (EV/Sales)? How to Calculate](https://www.investopedia.com/terms/e/enterprisevaluesales.asp) - [Investopedia](https://www.investopedia.com/)
28. [How to: Excess Return Model for Valuing Financial Stocks](https://einvestingforbeginners.com/excess-return-model-daah/)

## Tutorial Videos

1. [How to Calculate Beta using Covariance and Variance](https://youtu.be/nDcZJcxOwVI) - [Edspira](https://www.youtube.com/c/Edspira)
2. [How to Calculate Beta In Excel - All 3 Methods (Regression, Slope & Covariance)](https://youtu.be/vr1lQeKX8Mc) - [hey i'm aaron](https://www.youtube.com/channel/UCqBYFpLfaytqGkzGTsHTlVQ)
3. [How to calculate percentage price changes correctly with natural logs for stock prices](https://youtu.be/Ytk_WTmPhCs) - [Stachanov Holding B.V.](https://www.youtube.com/c/StachanovSolutionsServices)
4. [Free Cash Flow: Back to Basics](https://youtu.be/9GnwzjV9qS0) - [Aswath Damodaran](https://www.youtube.com/c/AswathDamodaranonValuation)
5. [Valuing Financial Service Firms, Excess Return Model](https://youtu.be/hLIK_nQml88) - [Chris Hughen](https://www.youtube.com/@ChrisHughen)
6. [REIT Valuation](https://youtu.be/lz8T0owadXU) - [Chris Hughen](https://www.youtube.com/@ChrisHughen)


[^1]: Page 75. Chapter 5. _The Art of Currency Trading_ by Brent Donnelly.
[^2]: Page 314. Chapter 9. _Corporate Finance: The Core, Global Edition_ by Jonathan Berk and Peter Demarzo.
[^3]: Page 460. Chapter 17. _Investment Valuation_ by Aswath Damodaran.