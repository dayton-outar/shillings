# Asset Evaluation

An _asset_ is any entity that delivers cashflow and/or appreciates in value over time.

> Valuation matters in the super-long-term, for example, while positioning and momentum matter much more in the short-term.[^1]

![Valuation Models](/.attachments/valuation-models.png)

There are 4 main approaches to valuation,

1. **Asset-based Valuation**: Asset-based valuation involves estimating the value of a company based on the value of its assets minus its liabilities. This method is particularly useful for companies with significant tangible assets, such as manufacturing or real estate companies. Asset-based valuation may include valuing assets at their book value, fair market value, or replacement cost.

2. **Discounted Cash Flow (DCF) Analysis**: DCF analysis involves estimating the present value of a company's future cash flows. It requires forecasting the company's future cash flows, determining an appropriate discount rate (usually the company's cost of capital or weighted average cost of capital), and discounting the future cash flows back to their present value. DCF analysis is considered one of the most fundamental and theoretically sound methods of valuation.

3. **Relative Valuation**: This method involves comparing the valuation metrics (such as price-to-earnings ratio, price-to-book ratio, or enterprise value-to-EBITDA ratio) of the company with those of similar companies or industry averages. Relative valuation is useful for assessing how a company's valuation multiples compare to its peers and can provide insights into whether a stock is undervalued or overvalued relative to its industry.

4. **Contingency Claim Model**: Developed by Aswath Damodaran, the Contingency Claim Model is a framework for valuing companies based on the value of their equity and debt claims. It incorporates option pricing theory and considers the company's equity as a call option on the value of its assets. This model is particularly relevant for valuing companies with complex capital structures or those facing financial distress.

Each of these methods has its strengths and weaknesses, and the choice of method depends on factors such as the company's industry, stage of development, financial condition, and the availability of data. Often, multiple valuation methods are used in conjunction to triangulate a fair value estimate for a company.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

## Asset-based Valuation Model

_Asset-based valuation_ is a model of evalaution that is best used when a business is in distress. Some analyst may prefer the simpler and more straithforward approach than _Discounted Cash Flow (DCF) Analysis_. In _asset-intensive_ industries, like manufacturing, real estate, or natural resources, the value of assets on the balance sheet can be a more reliable indicator of value than future cash flows.

Damodaran does not go into much detail explaining _asset-based valuation_ only to state[^4],

> There are some analysts who add a fourth approach to valuation to the three described in this chapter. They argue that you can value the individual assets owned by a firm and aggregate them to arrive at a firm value—asset-based valuation models. In fact, there are several variants on asset-based valuation models. The first is **liquidation value**, which is obtained by aggregating the estimated sale proceeds of the assets owned by a firm. The second is **replacement cost**, where you estimate what it would cost you to replace all of the assets that a firm has today. The third is the simplest: use **accounting book value** as the measure of the value of the assets, with adjustments to the book value made where necessary.
> 
> While analysts may use asset-based valuation approaches to estimate value, they are not alternatives to discounted cash flow, relative, or option pricing models since both replacement and liquidation values have to be obtained using one or another of these approaches. Ultimately, all valuation models attempt to value assets; the differences arise in how we identify the assets and how we attach value to each asset. In liquidation valuation, we look only at assets in place and estimate their value based on what similar assets are priced at in the market. In traditional discounted cash flow valuation, we consider all assets and include expected growth potential to arrive at value. The two approaches may, in fact, yield the same values if you have a firm that has no growth potential and the market assessments of value reflect expected cash flows.

He gives an example[^5],

> In asset-based valuation, we value the existing assets of a financial service firm, net out debt and other outstanding claims, and report the difference as the value of equity. For example, with a bank, this would require valuing the loan portfolio of the bank (which would comprise its assets) and subtracting outstanding debt to estimate the value of equity. For an insurance company, you would value the policies that the company has in force and subtract out the expected claims resulting from these policies and other debt outstanding to estimate the value of the equity in the firm.
> 
> How would you value the loan portfolio of a bank or the policies of an insurance company? One approach would be to estimate the price at which the loan portfolio can be sold to another financial service firm, but the better approach is to value it based on the expected cash flows. Consider, for instance, a bank with a $1 billion loan portfolio with a weighted average maturity of eight years, on which it earns interest income of $70 million. Furthermore, assume that the default risk on the loans is such that the fair market interest rate on the loans would be 6.50 percent; this fair market rate can be estimated by either getting the loan portfolio rated by a ratings agency or by measuring the potential for default risk in the portfolio. The value of the loans can be estimated as follows:
> 
$$\huge{\text{Value of loans} = $70 million \text{(PV of annuity, 8 years, 6.5 percent)} + {$1,000 million \over 1.065^8} = $1,030 million}$$
> 
> This loan portfolio has a fair market value that exceeds its book value because the bank is charging an interest rate that exceeds the market rate. The reverse would be true if the bank charged an interest rate that is lower than the market rate. To value the equity in this book, you would subtract out the deposits, debt, and other claims on the bank.
> 
> This approach has merit if you are valuing a mature bank or insurance company with little or no growth potential, but it has two significant limitations. First, it does not assign any value to expected future growth and the excess returns that flow from that growth. A bank, for instance, that consistently is able to lend at rates higher than justified by default risk should be able to harvest value from future loans as well. Second, it is difficult to apply when a financial service firm enters multiple businesses. A firm like Citigroup that operates in multiple businesses would prove to be difficult to value because the assets in each business—insurance, commercial banking, investment banking, portfolio management—would need to be valued separately, with different income streams and different discount rates.

### Liquidation Value

> In some valuations, we can assume that the firm will cease operations at a point in time in the future and sell the assets it has accumulated to the highest bidders. The estimate that emerges is called a liquidation value. There are two ways in which the liquidation value can be estimated. One is to base it on the book value of the assets, adjusted for any [inflation](#inflation) during the period. Thus, if the book value of assets 10 years from now is expected to be $2 billion, the average age of the assets at that point is five years and the expected inflation rate is 3 percent, the expected liquidation value can be estimated as:
> 
> The limitation of this approach is that it is based on accounting book value and does not reflect the earning power of the assets.
> 
$$\huge{\text{Expected liquidation value} = \text{Book value of assets}_\text{term year}(1 + \text{Inflation rate})^\text{average life of assets} = $2 billion(1.03)^5 = $2.319 billion}$$
>
> The alternative approach is to estimate the value based on the earning power of the assets. To make this estimate, we would first have to estimate the expected cash flows from the assets and then discount these cash flows back to the present, using an appropriate discount rate. In the preceding example, for instance, if we assumed that the assets in question could be expected to generate $400 million in after-tax cash flows for 15 years (after the terminal year) and the cost of capital was 10 percent, our estimate of the expected liquidation value would be:
> 
$$\huge{\text{Expected liquidation value} = $400 million(\text{PV of annuity, 15 years @ 10 percent}) = $3.042 billion}$$
>
> When valuing equity, there is one additional step that needs to be taken. The estimated value of debt outstanding in the terminal year has to be subtracted from the liquidation value to arrive at the liquidation proceeds for equity investors.[^6]

### Replacement Cost

To perform asset-based valuation to arrive at replacement cost, you typically follow these steps:

1. **Identify Assets**: List all tangible and intangible assets owned by the company, including property, equipment, inventory, patents, trademarks, etc.

2. **Determine Replacement Cost**: Estimate the cost of replacing each asset at current market prices. For tangible assets, this involves obtaining quotes from suppliers or contractors. For intangible assets, you may need to estimate the cost of developing or acquiring similar assets.

3. **Adjust for Depreciation**: Consider the depreciation of existing assets. Tangible assets may have depreciated in value over time due to wear and tear, while intangible assets may have lost value due to obsolescence or expiration.

4. **Summarize Values**: Total the replacement costs of all assets after adjusting for depreciation. This total represents the asset-based valuation.

5. **Consider Liabilities**: Take into account any outstanding liabilities or debts associated with the assets, as these reduce the net value of the assets.

6. **Compare to Market Value**: Evaluate how the asset-based valuation compares to the market value of the company. If the asset-based valuation significantly exceeds the market value, it may indicate undervaluation in the market.

7. **Assess Other Factors**: Consider other factors such as the company's growth potential, market conditions, and industry trends, which may impact the overall valuation.

Determining current market prices of an asset involves various methods depending on the type of asset and market conditions. Here are some common approaches:

1. **Comparable Sales Approach**: This method is commonly used for real estate and involves analyzing recent sales prices of similar properties in the same or similar location. By comparing the features and characteristics of the assets, you can estimate the market value of the subject asset.

2. **Market Indexes**: For assets traded in financial markets such as stocks, bonds, or commodities, market indexes provide a benchmark for current prices. These indexes track the performance of a specific market or sector, allowing investors to gauge the current market value of assets within that category.

3. **Auction Markets**: In auction markets, such as those for art, collectibles, or certain types of commodities, recent auction results can provide insights into current market prices. Prices realized at auctions reflect the willingness of buyers to pay for the assets at a given point in time.

4. **Online Platforms and Marketplaces**: For certain types of assets, online platforms and marketplaces provide real-time pricing information. This includes e-commerce websites for retail goods, online trading platforms for stocks and cryptocurrencies, and platforms for buying and selling used goods.

5. **Appraisal Services**: Professional appraisers can provide valuation services for a wide range of assets, including real estate, machinery, equipment, and collectibles. These appraisals consider various factors such as asset condition, demand, and market trends to determine current market prices.

6. **Industry Reports and Publications**: Industry-specific reports, publications, and databases often provide information on market prices for particular assets. These resources may include data on recent transactions, pricing trends, and supply-demand dynamics within the industry.

7. **Broker or Dealer Quotations**: For assets traded in financial markets, brokers or dealers can provide real-time quotations indicating the current market price at which they are willing to buy or sell the asset.

8. **Expert Opinion**: In some cases, experts in a particular field or industry may provide insights into current market prices based on their knowledge and experience.

When determining current market prices, it's important to consider the reliability and accuracy of the data sources used, as well as any specific factors or conditions that may impact the valuation of the asset.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

## Discounted Cashflow Model

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

## Relative Valuation Model

> In relative valuation, the objective is to value assets based on how similar assets are currently priced in the market. ...
> 
> ...
> 
> There are two components to relative valuation. The first is that, to value assets on a relative basis, prices have to be standardized, usually by converting prices into multiples of earnings, book values, or sales. The second is to find similar firms, which is difficult to do since _no two firms are identical and firms in the same business can still differ on risk, growth potential, and cash flows_.
> 
> ...
> 
> There are several reasons why relative valuation is so widely used. First, a valuation based on a multiple and comparable firms _can be completed with far fewer explicit assumptions and far more quickly than a discounted cash flow valuation_. Second, a relative valuation is _simpler to understand and easier to present to clients and customers than a discounted cash flow valuation_. Put differently, it is far easier to frame an asset as cheap or expensive using a multiple rather than a discounted cash flow valuation. Finally, a relative valuation is much more likely to reflect the current mood of the market, since it is an attempt to measure relative and not intrinsic value.
> 
> ...
> 
> The strengths of relative valuation are also its weaknesses. First, the ease with which a relative valuation can be put together, pulling together a multiple and a group of comparable firms, can also result in inconsistent estimates of value where key variables such as risk, growth, or cash flow potential are ignored. Second, the fact that multiples reflect the market mood also implies that using relative valuation to estimate the value of an asset can result in values that are too high when the market is overvaluing comparable firms, or too low when it is undervaluing these firms. Third, while there is scope for bias in any type of valuation, the lack of transparency regarding the underlying assumptions in relative valuations makes them particularly vulnerable to manipulation. A biased analyst who is allowed to choose the multiple on which the valuation is based and to pick the comparable firms can essentially ensure that almost any value can be justified.
> 
> ...
> 
> The price of a stock is a function of both the value of the equity in a company and the number of shares outstanding in the firm. Thus, a 2-for-1 stock split that doubles the number of units will approximately halve the stock price. Since stock prices are determined by the number of units of equity in a firm, stock prices cannot be compared across different firms. To compare the values of similar firms in the market, you need to standardize the values in some way. Values for businesses can be standardized relative to the earnings generated, to the book value or replacement value of the assets employed, to the revenues generated, or to measures that are specific to firms in a sector.
> 
> ...
> 
> When buying a business, as opposed to just the equity in the business, it is common to examine the value of the operating assets of the firm (also called enterprise value) as a multiple of the operating income or the earnings before interest, taxes, depreciation, and amortization (EBITDA). While, for a buyer of the equity or the operating assets, a lower multiple is better than a higher one, these multiples will be affected by the growth potential and risk of the business being acquired.
> 
> ...
> 
> Even the simplest multiples can be defined differently by different analysts. Consider, for instance, the price-earnings (PE) ratio. Most analysts define it to be the market price divided by the earnings per share, but that is where the consensus ends. There are a number of variants on the PE ratio. While the current price is conventionally used in the numerator, there are some analysts who use the average price over the prior six months or year. The earnings per share in the denominator can be the earnings per share from the most recent financial year (yielding the current PE), the last four quarters of earnings (yielding the trailing PE), or expected earnings per share in the next financial year (resulting in a forward PE). In addition, earnings per share can be computed based on primary shares outstanding or fully diluted shares, and can include or exclude extraordinary items. ... 
> 
> Not only can these variants on earnings yield vastly different values for the price-earnings ratio, but the one that gets used by analysts depends on their biases. For instance, in periods of rising earnings, the forward PE yields consistently lower values than the trailing PE, which, in turn, is lower than the current PE. A bullish analyst will tend to use the forward PE to make the case that the stock is trading at a low multiple of earnings, while a bearish analyst will focus on the current PE to make the case that the multiple is too high. The first step when discussing a valuation based on a multiple is to ensure that everyone in the discussion is using the same definition for that multiple.
> 
> **Consistency** Every multiple has a numerator and a denominator. The numerator can be either an equity value (such as market price or value of equity) or a firm value (such as enterprise value, which is the sum of the values of debt and equity, net of cash). The denominator can be an equity measure (such as earnings per share, net income, or book value of equity) or a firm measure (such as operating income, EBITDA, or book value of capital).
> 
> One of the key tests to run on a multiple is to examine whether the numerator and denominator are defined consistently. _If the numerator for a multiple is an equity value, then the denominator should be an equity value as well. If the numerator is a firm value, then the denominator should be a firm value as well._ To illustrate, the price-earnings ratio is a consistently defined multiple, since the numerator is the price per share (which is an equity value) and the denominator is earnings per share (which is also an equity value). So is the enterprise value to EBITDA multiple, since the numerator and denominator are both firm value measures.
> 
> Are there any multiples in use that are inconsistently defined? Consider the Price-to-EBITDA multiple, a multiple that acquired a few adherents in the past few years. The numerator in this multiple is an equity value, and the denominator is a measure of earnings to the firm. The analysts who use this multiple will probably argue that the inconsistency does not matter since the multiple is computed the same way for all of the comparable firms; but they would be wrong. If some firms on the list have no debt and others carry significant amounts of debt, the latter will look cheap on a Price-to-EBITDA basis, when in fact they might be overpriced or correctly priced.
> 
> **Uniformity** In relative valuation, the multiple is computed for all of the firms in a group and then compared across these firms to make judgments on which firms are overpriced and which are underpriced. For this comparison to have any merit, the multiple has to be defined uniformly across all of the firms in the group. Thus, if the trailing PE is used for one firm, it has to be used for all of the others as well. In fact, one of the problems with using the current PE to compare firms in a group is that different firms can have different fiscal year-ends. This can lead to some firms having their prices divided by earnings from July to June, with other firms having their prices divided by earnings from January to December. While the differences can be minor in mature sectors, where earnings do not make quantum jumps over six months, they can be large in high-growth sectors.
> 
> With both earnings and book value measures, there is another component to be concerned about, and that is the accounting standards used to estimate earnings and book values. Differences in accounting standards can result in very different earnings and book value numbers for similar firms. This makes comparisons of multiples across firms in different markets, with different accounting standards, very difficult. ***Even with the same accounting standards, the fact that some firms use different accounting rules (on depreciation and expensing) for reporting purposes and tax purposes and others do not can throw off comparisons of earnings multiples.***[^8]

Take note that Damodaran is elaborating the importance of coparing apples to apples.

> When using a multiple, it is always useful to have a sense of what a high value, a low value, or a typical value for that multiple is in the market. In other words, knowing the distributional characteristics of a multiple is a key part of using that multiple to identify under- or overvalued firms. In addition, you need to understand the effects of outliers on averages and unearth any biases in these values introduced in the process of estimating multiples.
> 
> **Distributional Characteristics** Many analysts who use multiples have a sector focus and have a sense of how different firms in their sector rank on specific multiples. What is often lacking, however, is a sense of how the multiple is distributed across the entire market. Why, you might ask, should a software analyst care about price-earnings ratios of utility stocks? Because both software and utility stocks are competing for the same investment dollar, they have to, in a sense, play by the same rules. Furthermore, an awareness of how multiples vary across sectors can be very useful in detecting when the sector you are analyzing is overor undervalued.
>
> What are the distributional characteristics that matter? The standard statistics—the average and standard deviation—are where you should start, but they represent the beginning of the exploration.
> 
> ...
> 
> **Biases in Estimating Multiples** With every multiple, there are firms for which the multiple cannot be computed. Consider again the price-earnings ratio. When the earnings per share are negative, the price-earnings ratio for a firm is not meaningful and is usually not reported. When looking at the average price-earnings ratio across a group of firms, the firms with negative earnings will all drop out of the sample because the price-earnings ratio cannot be computed. Why should this matter when the sample is large? The fact that the firms that are taken out of the sample are the firms losing money creates a bias in the selection process and skews the statistics.
> 
> There are three solutions to this problem. The first is to be aware of the bias and build it into the analysis. In practical terms, this will mean adjusting the average PE to reflect the elimination of the money-losing firms. The second is to aggregate the market value of equity and net income (or loss) for all of the firms in the group, including the money-losing ones, and compute the price-earnings ratio using the aggregated values. ... The third choice is to use a multiple that can be computed for all of the firms in the group. The inverse of the price-earning ratio, which is called the earnings yield, can be computed for all firms, including those losing money.
> 
> ...
> 
> **Determinants** ... ***we observed that the value of a firm is a function of three variables—its capacity to generate cash flows, its expected growth in these cash flows, and the uncertainty associated with these cash flows***. Every multiple, whether it is of earnings, revenues, or book value, is a function of the same three variables—risk, growth, and cash flow generating potential. Intuitively, then, firms with higher growth rates, less risk, and greater cash flow generating potential should trade at higher multiples than firms with lower growth, higher risk, and less cash flow potential.
> 
> ...
> 
> **Relationship** Knowing the fundamentals that determine a multiple is a useful first step, but understanding how the multiple changes as the fundamentals change is just as critical to using the multiple. To illustrate, knowing that higher-growth firms have higher PE ratios is not a sufficient insight if you are called on to analyze whether a firm with a growth rate that is twice as high as the average growth rate for the sector should have a PE ratio that is 1.5 times or 1.8 times or 2 times the average price-earnings ratio for the sector. To make this judgment, you need to know how the PE ratio changes as the growth rate changes.
> 
> A surprisingly large number of analyses are based on the assumption that there is a linear relationship between multiples and fundamentals. For instance, the price-earnings/growth (PEG) ratio, which is the ratio of the PE to the expected growth rate of a firm and widely used to analyze high-growth firms, implicitly assumes that PE ratios and expected growth rates are linearly related.
> 
> One of the advantages of deriving the multiples from a discounted cash flow model, as was done in the last section, is that you can analyze the relationship between each fundamental variable and the multiple by keeping everything else constant and changing the value of that variable.
> 
> ...
> 
> When multiples are used, they tend to be used in conjunction with comparable firms to determine the value of a firm or its equity. But what is a comparable firm? While the conventional practice is to look at firms within the same industry or business as comparable firms, this is not necessarily always the correct or the best way of identifying these firms. In addition, no matter how carefully you choose comparable firms, differences will remain between the firm you are valuing and the comparable firms. Figuring out how to control for these differences is a significant part of relative valuation.
> 
> **What Is a Comparable Firm?** _A comparable firm is one with cash flows, growth potential, and risk similar to the firm being valued_. It would be ideal if you could value a firm by looking at how an exactly identical firm—in terms of risk, growth, and cash flows—is priced. Nowhere in this definition is there a component that relates to the industry or sector to which a firm belongs. Thus a telecommunications firm can be compared to a software firm if the two are identical in terms of cash flows, growth, and risk. In most analyses, however, analysts define comparable firms to be other firms in the firm’s business or businesses. If there are enough firms in the industry to allow for it, this list is pruned further using other criteria; for instance, only firms of similar size may be considered. The implicit assumption being made here is that firms in the same sector have similar risk, growth, and cash flow profiles and therefore can be compared with much more legitimacy.
> 
> ...
> 
> With globalization, you are faced with a new challenge, where companies in a sector are incorporated and trade in different markets. Thus, in the automobile sector, you can have U.S., European, and Asian firms all competing for market share globally. Can you compare companies that are listed on different markets? Sure, as long as you recognize that these companies can have different risk, growth, and cash flow characteristics. Thus, Asian automobile companies may have higher growth potential and risk exposure than European firms. In addition, differences in accounting standards and currencies can skew both market and accounting numbers and have to be controlled for.
> 
> ...
> 
> **Controlling for Differences across Firms** No matter how carefully you construct your list of comparable firms, you will end up with firms that are different from the firm you are valuing. The differences may be small on some variables and large on others, and you will have to control for these differences in a relative valuation. There are three ways of controlling for these differences: _subjective adjustments_, _modified multiples_, and _sector_ or _market regressions_.
> 
> ***Subjective Adjustments*** Relative valuation begins with two choices—the multiple used in the analysis and the group of firms that comprises the comparable firms. The multiple is calculated for each of the comparable firms, and the average is computed. To evaluate an individual firm, you then compare the multiple it trades at to the average computed; if it is significantly different, you make a subjective judgment about whether the firm’s individual characteristics (growth, risk, or cash flows) may explain the difference. Thus, _a firm may have a PE ratio of 22 in a sector where the average PE is only 15, but you may conclude that this difference can be justified because the firm has higher growth potential than the average firm in the industry. If, in your judgment, the difference on the multiple cannot be explained by the fundamentals, the firm will be viewed as overvalued (if its multiple is higher than the average) or undervalued (if its multiple is lower than the average)._
> 
> ***Modified Multiples*** In this approach, you modify the multiple to take into account the most important variable determining it—the companion variable. Thus, the PE ratio is divided by the expected growth rate in EPS for a company to determine a growth-adjusted PE ratio or the PEG ratio. These modified ratios are then compared across companies in a sector. The implicit assumption you make is that these firms are comparable on all the measures of value, other the one being controlled for. In addition, you are assuming that the relationship between the multiples and fundamentals is linear.
> 
> ***Sector Regressions*** When firms differ on more than one variable, it becomes difficult to modify the multiple to account for the differences across firms. You can run a regression of the multiple against the variables and then use this regression to find the predicted value for each firm. This approach works reasonably well when the number of comparable firms is large and the relationship between the multiple and the variables is stable. When these conditions do not hold, a few outliers can cause the coefficients to change dramatically and make the predictions much less reliable.
> 
> ***Market Regressions*** Searching for comparable firms within the sector in which a firm operates is fairly restrictive, especially when there are relatively few firms in the sector or when a firm operates in more than one sector. Since the definition of a comparable firm is not one that is in the same business but one that has the same growth, risk, and cash flow characteristics as the firm being analyzed, you need not restrict your choice of comparable firms to those in the same industry. The regression introduced in the previous section controls for differences on those variables that you believe cause multiples to vary across firms. Based on the variables that determine each multiple, you should be able to regress any multiple (PE, EV/EBITDA, PBV) against the variables, using all of the firms in the market in your sample. You can then use the market regression to get predicted values for individual companies. A company that trades at a PE ratio lower (higher) than the predicted PE from the market regression is undervalued (over valued) relative to the market.
> 
> The first advantage of this approach over the subjective comparison across firms in the same sector is that it does quantify, based on actual market data, the degree to which higher growth or risk should affect the multiples. It is true that these estimates can have error associated with them, but this error is a reflection of the reality that many analysts choose not to face when they make subjective judgments. Second, by looking at all firms in the market, this approach allows you to make more meaningful comparisons of firms that operate in industries with relatively few firms. Third, it allows you to examine whether all firms in an industry are under- or overvalued by estimating their values relative to other firms in the market.
> 
> ...
> 
> _The differences in value between discounted cash flow valuation and relative valuation come from different views of market efficiency, or, put more precisely, market inefficiency. In discounted cash flow valuation, you assume that markets make mistakes, that they correct these mistakes over time, and that these mistakes can often occur across entire sectors or even the entire market. In relative valuation, you assume that while markets make mistakes on individual stocks, they are correct on average._[^8]

### Earnings Multiples

> When the PE ratios of firms are compared, it is difficult to ensure that the earnings per share are uniformly estimated across the firms for the following reasons:
>
> - Firms often grow by acquiring other firms, and they do not account for acquisitions the same way. While all companies now have to use purchase accounting and record goodwill as an asset, there is enough discretion in the process to make a material difference in reported earnings. These differences lead to different measures of earnings per share and different PE ratios.
>
> - Using diluted earnings per share in estimating PE ratios might bring the shares that are covered by management options into the multiple, but they treat options that are deep in-the-money or only slightly in-the-money as equivalent.
> 
> - Firm often have discretion in whether they expense or capitalize items, at least for reporting purposes. The expensing of a capital expense gives firms a way of shifting earnings from period to period, and penalizes those firms that are reinvesting more.
> 
> ...
> 
> **Discounted Cash Flow Model Perspective on PE Ratios** ... the PE ratio for a stable growth firm from the stable growth dividend discount model:[^11]

$$\huge{{P_0 \over EPS_0} = PE = \frac{\text{Payout ratio} \times {(1 + g_n)}}{k_e - g_n}}$$

> If the PE ratio is stated in terms of expected earnings ($EPS_1$) in the next time period, this can be simplified to:

$$\huge{{P_0 \over EPS_1} = Forward PE =  \frac{\text{Payout ratio}}{k_e - g_n}}$$

> The PE ratio is an increasing function of the payout ratio and the growth rate and a decreasing function of the riskiness of the firm. In fact, we can state the payout ratio as a function of the expected growth rate and return on equity:

$$\huge{\text{Payout ratio} = {1 - \text{Expected growth rate}/\text{Return on Equity}} = {1 - g_n}/ROE_n}$$

> Substituting back into the equation,

$$\huge{{P_0 \over EPS_1} = Forward PE = \frac{{1 - g_n}/ROE_n}{k_e - g_n}}$$

Earnings per share (EPS) is typically estimated by financial analysts and investors based on various factors such as historical financial performance, industry trends, company guidance, economic conditions, and other relevant information. There are several methods used to estimate EPS:

1. **Bottom-Up Approach**: Analysts forecast the earnings of individual companies based on their financial performance, industry dynamics, and other company-specific factors. These individual company estimates are then aggregated to estimate the overall EPS for a market index or sector.

2. **Top-Down Approach**: Analysts start with macroeconomic factors and industry trends to forecast the overall earnings for a market index or sector. They then allocate these earnings estimates to individual companies within the index or sector to derive their EPS estimates.

3. **Company Guidance**: Companies often provide guidance on their expected earnings for future periods. Analysts and investors use this guidance as a basis for estimating EPS.

4. **Historical Growth Rates**: Analysts may use historical growth rates of earnings and revenues to project future earnings. This method assumes that past trends will continue into the future.

5. **Peer Comparison**: Analysts may compare the financial performance of a company to its peers within the same industry to estimate its EPS.

6. **Discounted Cash Flow (DCF) Analysis**: In some cases, analysts may use DCF analysis to estimate a company's future earnings and then divide by the projected number of shares outstanding to arrive at an EPS estimate.

It's important to note that EPS estimates are subjective and can vary among analysts and forecasting methods. Investors should consider multiple estimates and factors when making investment decisions.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

> The price-earnings ratio for a high-growth firm can also be related to fundamentals. Using the two-stage dividend discount model, this relationship can be made explicit fairly simply. When a firm is expected to be in high growth for the next n years and stable growth thereafter, the dividend discount model can be written as follows:

$\Huge{P_0 = { { EPS_0 \times PR \times (1 + g) \times [ 1 - { { (1 + g)^n } \over { (1 + k_{e,hg})^n } } ] } \over { k_{e,hg} - g } } + { { EPS_0 \times PR_{n} \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,st} - g_n)(1 + k_{e,hg})^n } } }$

> where,\
> $EPS_0$ = Earnings per share in year 0 (current year)\
> $PR$    = Payout ratio in first $n$ years\
> $g$     = Growth rate in the first $n$ years
> $k_{e,hg}$ = Cost of equity in high growth period
> $k_{e,st}$ = Cost of equity in stable growth period
> $PR_n$ = Payout ratio after $n$ years for the stable firm
> $g_n$ = Growth rate after $n$ years, forever (stable growth rate)
> 
> ...
> 
> - The PE ratio increases as the payout ratio increases, for any given growth rate. An alternative way of stating the same proposition is that the PE ratio increases as the return on equity increases, for any given growth rate, and decreases as the return on equity decreases. ...
> 
> - The PE ratio becomes lower as riskiness increases. Put differently, the PE ratio will be higher for a firm where is growth is more predictable and stable than for an otherwise similar firm with unstable growth.
> 
> - The PE increases as the growth rate increases, assuming that the ROE > cost of equity.
> 
> This formula is general enough to be applied to any firm, even one that is not paying dividends right now. In fact, the ratio of FCFE to earnings can be substituted for the payout ratio for firms that pay significantly less in dividends than they can afford to.
> 
> ...
> 
> **Comparing a Market’s PE Ratio across Time** Analysts and market strategists often compare the PE ratio of a market to its historical average to make judgments about whether the market is under- or overvalued. Thus a market that is trading at a PE ratio that is much higher than its historical norms is often considered to be overvalued, whereas one that is trading at a ratio lower than its historical norms is considered undervalued.
> 
> ... As the fundamentals (interest rates, risk premiums, expected growth, and payout) change over time, the PE ratio will also change. Other things remaining equal, for instance, you would expect the following:
> - An increase in interest rates should result in a higher cost of equity for the market and a lower PE ratio.
> - A greater willingness to take risk on the part of investors will result in a lower risk premium for equity and a higher PE ratio across all stocks.
> - An increase in expected growth in earnings across firms will result in a higher PE ratio for the market.
> - An increase in the return on equity at firms will result in a higher payout ratio for any given growth rate [g = (1 – Payout ratio)ROE] and a higher PE ratio for all firms.
> 
> In other words, it is difficult to draw conclusions about PE ratios without looking at these fundamentals. A more appropriate comparison is therefore not between PE ratios across time, but between the actual PE ratio and the predicted PE ratio based on fundamentals existing at that time.
> 
> ...
> 
> **Comparing PE Ratios across Countries** Comparisons are often made between price-earnings ratios in different countries with the intention of finding undervalued and overvalued markets. Markets with lower PE ratios are viewed as undervalued and those with higher PE ratios are considered overvalued. Given the wide differences that exist between countries on fundamentals, it is misleading to draw these conclusions. For instance, you would expect to see the following, other things remaining equal:
> - Countries with higher real interest rates should have lower PE ratios than countries with lower real interest rates.
> - Countries with higher expected real growth should have higher PE ratios than countries with lower real growth.
> - Countries that are viewed as riskier (and thus command higher risk premiums) should have lower PE ratios than safer countries.
> - Countries where companies are more efficient in their investments (and earn a higher return on these investments) should trade at higher PE ratios.[^11]

The growth rate for a given market can be had from the growth percentage in GNP - [Gross National Product](https://www.investopedia.com/terms/g/gnp.asp). GNP is calculated as follows,

$$\huge{C + I + G + X + Z}$$ 

That stands for $GNP$ = Consumption + Investment + Government + $X$ (net exports) + $Z$ (net income earned by domestic residents from overseas investments minus net income earned by foreign residents from domestic investments).

**Comparing PE Ratios across Firms in a Sector** The most common approach to estimating the PE ratio for a firm is to choose a group of comparable firms, to calculate the average PE ratio for this group, and to subjectively adjust this average for differences between the firm being valued and the comparable firms. There are several problems with this approach. First, the definition of a comparable firm is essentially a subjective one. The use of other firms in the industry as the control group is often not the solution because firms within the same industry can have very different business mixes and risk and growth profiles. There is also plenty of potential for bias. One clear example of this is in takeovers, where a high PE ratio for the target firm is justified using the price-earnings ratios of a control group of other firms that have been taken over. This group is designed to give an upwardly biased estimate of the PE ratio and other multiples. Second, even when a legitimate group of comparable firms can be constructed, differences will continue to persist in fundamentals between the firm being valued and this group. It is very difficult to subjectively adjust for differences across firms. Thus, knowing that a firm has much higher growth potential than other firms in the comparable firm list would lead you to estimate a higher PE ratio for that firm, but how much higher is an open question.
> 
> The alternative to subjective adjustments is to control explicitly for the one or two variables that you believe account for the bulk of the differences in PE ratios across companies in the sector in a regression. The regression equation can then be used to estimate predicted PE ratios for each firm in the sector, and these predicted values can be compared to the actual PE ratios to make judgments on whether stocks are under- or overpriced.
> 
> ...
> 
> **Comparing PE Ratios across Firms in the Market** In the preceding section, comparable firms were narrowly defined to be other firms in the same business. This section considers ways in which we can expand the number of comparable firms by looking at an entire sector or even the market. There are two advantages in doing this. The first is that the estimates may become more precise as the number of comparable firms increase. The second is that it allows you to pinpoint when firms in a small subgroup are being under- or overvalued relative to the rest of the sector or the market. Since the differences across firms will increase when you loosen the definition of comparable firms, you have to adjust for these differences. The simplest way of doing this is with a multiple regression, with the PE ratio as the dependent variable, and proxies for risk, growth, and payout forming the independent variables.[^11]

#### Normalizing Earnings for PE Ratios

> The dependence of PE ratios on current earnings makes them particularly vulnerable to the year-to-year swings that often characterize reported earnings. In making comparisons, therefore, it may make much more sense to use normalized earnings. The process used to normalize earnings varies widely, but the most common approach is a simple averaging of earnings across time. For a cyclical firm, for instance, you would average the earnings per share across a cycle. In doing so, you should adjust for [inflation](#inflation). If you do decide to normalize earnings for the firm you are valuing, consistency demands that you normalize them for the comparable firms in the sample as well.[^11]

#### THE PEG Ratio

> The PEG ratio is defined to be the price-earnings ratio divided by the expected growth rate in earnings per share:

$\huge{\text{PEG ratio} = \text{PE ratio}/\text{Expected growth rate}}$

> For instance, a firm with a PE ratio of 20 and a growth rate of 10 percent is estimated to have a PEG ratio of 2. Consistency requires that the growth rate used in this estimate be the growth rate in earnings per share rather than operating income, because PEG ratio is an equity multiple.
> 
> Given the many definitions of the PE ratio, which one should you use to estimate the PEG ratio? The answer depends on the base on which the expected growth rate is computed. If the expected growth rate in earnings per share is based on earnings in the most recent year (current earnings), the PE ratio that should be used is the current PE ratio. If it is based on trailing earnings, the PE ratio used should be the trailing PE ratio. The forward PE ratio should never be used in this computation, since it may result in a double counting of growth.[^11]

#### Variants of the PE Ratio

> While the PE ratio and the PEG ratio may be the most widely used earnings multiples, there are other equity earnings multiples that are also used by analysts. The first is the relative PE ratio, the second is a multiple of price to earnings in a future year (say 5 or 10 years from now), and the third is a multiple of price to earnings prior to R&D expenses (used primarily for technology firms).
> 
> Relative price earnings ratios measure a firm’s PE ratio relative to the market average. It is obtained by dividing a firm’s current PE ratio by the average for the market:
>
> $\text{Relative PE} = { {\text{Current PE ratio}}_{\text{firm}} \over {\text{Current PE ratio}}_{\text{market}} }$
> 
> Not surprisingly, the distribution of relative PE ratios mimics the distribution of the actual PE ratios, with one difference—the average relative PE ratio is 1.[^11]

#### Relative PE Ratios and Market Growth

> As the expected growth rate on the market increases, the divergence in PE ratios increases, resulting in a bigger range for relative PE ratios. This can be illustrated very simply, if you consider the relative PE for a company that grows at half the rate of the market. When the market growth rate is 4 percent, this firm will trade at a PE that is roughly 80 percent of the market PE. When the market growth rate increases to 10 percent, the firm will trade at a PE that is 60 percent of the market PE.
> 
> This has consequences for analysts who use relative PE ratios. Stocks of firms whose earnings grow at a rate much lower than the market growth rate will often look cheap on a relative PE basis when the market growth rate is high and expensive when the market growth rate is low.[^11]

#### Enterprise Value to EBITDA Multiple

> Unlike the earnings multiples discussed so far in this chapter, the enterprise value to EBITDA multiple is a firm value multiple. In the past two decades, this multiple has acquired a number of adherents among analysts for several reasons. First, there are far fewer firms with negative EBITDA than there are firms with negative earnings per share, and thus fewer firms are lost from the analysis. Second, differences in depreciation methods across different companies—some might use straight-line while others use accelerated depreciation—can cause differences in operating income or net income but will not affect EBITDA. Third, this multiple can be compared far more easily than other earnings multiples across firms with different financial leverage (the numerator is firm value and the denominator is a predebt earnings). For all of these reasons, this multiple is particularly useful for firms in sectors that require large investments in infrastructure with long gestation periods. Telecom companies or companies involved in airport or toll road construction would be good examples.
> 
> **Definition** The enterprise value to EBITDA multiple relates the total market value of the firm, net
of cash, to the earnings before interest, taxes, depreciation, and amortization of the firm:
>
> $\huge{\text{EV/EBITDA} = (\text{Market value of equity} − \text{Market value of debt} − Cash)/EBITDA}$
>
> Why is cash netted out of firm value for this calculation? Since the interest income from the cash is not counted as part of the EBITDA, not netting out the cash will result in an overstatement of the EV-to-EBITDA multiple.
> 
> The enterprise value to EBITDA multiple can be difficult to estimate for firms with cross holdings. To see why, note that cross holdings can be categorized as either majority active, minority active, or minority passive holdings. When a holding is categorized as a minority holding, the operating income of a firm does not reflect the income from the holding. The numerator, on the other hand, includes the market value of equity, which should incorporate the value of the minority holdings. Consequently, the value to EBITDA multiple will be too high for these firms, leading a casual observer to conclude that they were overvalued. When a holding is categorized as a majority holding, a different problem arises. The EBITDA includes 100 percent of the EBITDA of the holding, but the numerator reflects only the portion of the holding that belongs to the firm. Thus the value to EBITDA multiple will be too low, leading it to be categorized as an undervalued stock.
> 
> The correction for cross holdings is tedious and difficult to do when the holdings are in private firms. With minority holdings, you can either subtract the estimated value of the holdings from the numerator or add the portion of the EBITDA of the subsidiary to the denominator. With consolidated holdings, you can subtract the proportional share of the value of the holding from the numerator and the entire EBITDA of the holding from the denominator.[^11]

### Book Value Multiples

#### Price-to-Book

> The market value of the equity in a firm reflects the market’s expectation of the firm’s earning power and cash flows. The book value of equity is the difference between the book value of assets and the book value of liabilities, a number that is largely determined by accounting conventions. In the United States, the book value of assets is the original price paid for the assets reduced by any allowable depreciation on the assets. Consequently, the book value of an asset generally decreases as it ages. The book value of liabilities similarly reflects the at-issue values of the liabilities. Since the book value of an asset reflects its original cost, it might deviate significantly from market value if the earning power of the asset has increased or declined significantly since its acquisition.
> 
> There are several reasons why investors find the price–book value ratio useful in investment analysis. The first is that the book value provides a relatively stable, intuitive measure of value that can be compared to the market price. For investors who instinctively mistrust discounted cash flow estimates of value, the book value is a much simpler benchmark for comparison. The second is that, given reasonably consistent accounting standards across firms, price–book value ratios can be compared across similar firms for signs of under- or overvaluation. Finally, even firms with negative earnings, which cannot be valued using price-earnings ratios, can be evaluated using price–book value ratios; there are far fewer firms with negative book value for equity than there are firms with negative earnings.
> 
> There are several disadvantages associated with measuring and using price–book value ratios. First, book values, like earnings, are affected by accounting decisions on depreciation and other variables. When accounting standards vary widely across firms, the price–book value ratios may not be comparable. A similar statement can be made about comparing price–book value ratios across countries with different accounting standards. Second, book value may not carry much meaning for service and technology firms that do not have significant tangible assets. Third, the book value of equity can become negative if a firm has a sustained string of negative earnings reports, leading to a negative price–book value ratio.
> 
> **Definition**
> 
> The price-to-book ratio is computed by dividing the market price per share by the current book value of equity per share.
> 
> $\huge{ \text{Price-to-book ratio} = PBV = { \text{Price per share} \over \text{Book value of equity per share} } }$
> 
> The safest way to measure this ratio when there are multiple classes of equity is to use the composite market value of all classes of common stock in the numerator and the composite book value of equity in the denominator—you would still ignore preferred stock for this computation.
> 
> There are two other measurement issues that you have to confront in computing this multiple. The first relates to the book value of equity, which as an accounting measure gets updated infrequently—once every quarter for U.S. companies and once every year for European companies. While most analysts use the most current book value of equity, there are some who use the average over the previous year or the book value of equity at the end of the latest financial year. Consistency demands that you use the same measure of book equity for all firms in your sample. The second and more difficult problem concerns the value of options outstanding. Technically, you would need to compute the estimated market value of management options and conversion options (in bonds and preferred stock) and add them to the market value of equity before computing the price to book value ratio.1 If you have a small sample of comparable firms and options represent a large and variable porion of equity value, you should do this. With larger samples and less significant option issues, you can stay with the conventional measure of market value of equity.
> 
> Accounting standards can affect book values of equity and price-to-book ratios and skew comparisons made across firms. For instance, assume that you are comparing the price-to-book ratios of technology firms in two markets, and that one of them allows research expenses to be capitalized and the other does not. You should expect to see lower price-to-book value ratios in the former, since the book value of equity will be augmented by the value of the research asset.
> 
> ...
> 
> **Analysis**
> 
> The price–book value ratio can be related to the same fundamentals that determine value in discounted cash flow models. Since this is an equity multiple, we will use an equity discounted cash flow model—the dividend discount model—to explore the determinants. The value of equity in a stable growth dividend discount model can be written as:
> 
> $\huge{ P_0 = {DPS_1 \over { k_e - g_n} } }$
> 
> where,
> $P_0$ = Value of equity per share today
> $DPS_1$ = Expected dividends per share next year
> $k_e$ = Cost of equity
> $g_n$ = Growth rate in dividends (forever)
> 
> Substituting for $DPS_1 = EPS_1(\text{Payout ratio})$, the value of the equity can be written as:
> 
> $\huge{ P_0 = { { EPS_1 \times \text{ Payout ratio } } \over { k_e - g_n } } }$
> 
> Defining the return on equity $(ROE) = EPS_1/\text{Book value of equity}_0$, the value of equity can be written as:
> 
> 
> 
> 
> 
> 
> [^12]

## Contingency Claim Model

The Contingency Claim Model, developed by Aswath Damodaran, is particularly appropriate for evaluating businesses with complex capital structures or those facing financial distress. Let's break down the key features of the model and discuss scenarios in which it is suitable:

1. **Incorporates Option Pricing Theory**: The Contingency Claim Model is grounded in _option pricing theory_, which treats a company's equity as a call option on the value of its assets. This means that equity holders benefit when the value of the company's assets exceeds its liabilities, similar to how call option holders benefit when the underlying asset's price exceeds the strike price.

2. **Accounts for Financial Distress**: The model is especially useful for companies facing financial distress or uncertainty about their future viability. In such scenarios, the company's equity behaves like a call option with a high degree of uncertainty and volatility, as there is a possibility of the company defaulting on its obligations or undergoing bankruptcy proceedings.

3. **Analyzes Equity and Debt Claims**: The Contingency Claim Model evaluates the value of both equity and debt claims on a company's assets. By considering the rights and priorities of different stakeholders in the capital structure, the model provides insights into the potential distribution of value among shareholders and creditors under different scenarios.

4. **Suitable for Leveraged Companies**: Companies with high levels of debt or complex capital structures, such as those with multiple layers of debt or hybrid securities, can benefit from the Contingency Claim Model. The model helps assess the impact of leverage on the value of equity and debt claims and allows stakeholders to make informed decisions about capital structure optimization and risk management.

5. **Useful for Valuing Distressed Companies**: When valuing distressed companies or companies operating in volatile industries, traditional valuation methods may not accurately capture the value of equity due to the high degree of uncertainty and risk. The Contingency Claim Model provides a framework for incorporating this uncertainty into the valuation process and can help stakeholders make more informed decisions in such challenging circumstances.

In summary, the Contingency Claim Model is appropriate for evaluating businesses with complex capital structures, facing financial distress, or operating in volatile industries where traditional valuation methods may not adequately capture the value of equity. It provides a comprehensive framework for analyzing equity and debt claims and assessing the impact of uncertainty and leverage on the company's value.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

### Options

> A _call option_ gives the holder of the option the right to buy an asset by a certain date for a certain price. A _put option_ gives the holder the right to sell an asset by a certain date for a certain price. The date speciﬁed in the contract is known as the _expiration date_ or the _maturity date_. The price speciﬁed in the contract is known as the _exercise price_ or the _strike price_.
> 
> Options can be either American or European, a distinction that has nothing to do with geographical location. American options can be exercised at any time up to the expiration date, whereas European options can be exercised only on the expiration date itself. Most of the options that are traded on exchanges are American. However, European options are generally easier to analyze than American options, and some of the properties of an American option are frequently deduced from those of its European counterpart.
> 
> ...
> 
> There are two sides to every option contract. On one side is the investor who has taken the long position (i.e., has bought the option). On the other side is the investor who has taken a short position (i.e., has sold or _written_ the option). The writer of an option receives cash up front, but has potential liabilities later. The writer’s proﬁt or loss is the reverse of that for the purchaser of the option.[^9]

Options are traded for several underlying assets, which includes,

- Stocks

- Foreign Currency

- Index (e.g. S&P 500, NASDAQ, Dow Jones)

  Consider, for example, one _call contract_ on an index with a strike price of 980. If it is exercised when the value of the index is 992, the _writer_ of the contract pays the holder (992 - 980) x 100 = $1,200.

- Futures

  When an exchange trades a particular futures contract, it often also trades American options on that contract. The life of a futures option normally ends a short period of time before the expiration of trading in the underlying futures contract. When a call option is exercised, the holder’s gain equals the excess of the futures price over the strike price. When a put option is exercised, the holder’s gain equals the excess of the strike price over the futures price.

> **Dividends and Stock Splits**
> 
> The early over-the-counter options were dividend protected. If a company declared a cash dividend, the strike price for options on the company’s stock was reduced on the ex-dividend day by the amount of the dividend. Exchange-traded options are not usually adjusted for cash dividends. In other words, when a cash dividend occurs, there are no adjustments to the terms of the option contract. An exception is sometimes made for large cash dividends.
> 
> Exchange-traded options are adjusted for stock splits. A stock split occurs when the existing shares are ‘‘split’’ into more shares. For example, in a 3-for-1 stock split, three new shares are issued to replace each existing share. Because a stock split does not change the assets or the earning ability of a company, we should not expect it to have any eﬀect on the wealth of the company’s shareholders. All else being equal, the 3-for-1 stock split should cause the stock price to go down to one-third of its previous value. In general, an n-for-m stock split should cause the stock price to go down to m=n of its previous value. The terms of option contracts are adjusted to reﬂect expected changes in a stock price arising from a stock split. After an n-for-m stock split, the strike price is reduced to m=n of its previous value, and the number of shares covered by one contract is increased to n=m of its previous value. If the stock price declines in the way expected, the positions of both the writer and the purchaser of a contract remain unchanged.
> 
> ***Example 10.1***
> 
> Consider a call option to buy 100 shares of a company for $30 per share. Suppose the company makes a 2-for-1 stock split. The terms of the option contract are then changed so that it gives the holder the right to purchase 200 shares for $15 per share.
> 
> Stock options are adjusted for stock dividends. A stock dividend involves a company issuing more shares to its existing shareholders. For example, a 20% stock dividend means that investors receive one new share for each ﬁve already owned. A stock dividend, like a stock split, has no eﬀect on either the assets or the earning power of a company. The stock price can be expected to go down as a result of a stock dividend. The 20% stock dividend referred to is essentially the same as a 6-for-5 stock split. All else being equal, it should cause the stock price to decline to 5/6 of its previous value. The terms of an option are adjusted to reﬂect the expected price decline arising from a stock dividend in the same way as they are for that arising from a stock split.
> 
> ***Example 10.2***
> 
> Consider a put option to sell 100 shares of a company for $15 per share. Suppose the company declares a 25% stock dividend. This is equivalent to a 5-for-4 stock split. The terms of the option contract are changed so that it gives the holder the right to sell 125 shares for $12.
> 
> Adjustments are also made for rights issues. The basic procedure is to calculate the theoretical price of the rights and then to reduce the strike price by this amount.
> 
> **Position Limits and Exercise Limits**
> 
> The Chicago Board Options Exchange often speciﬁes a _position limit_ for option contracts. This deﬁnes the maximum number of option contracts that an investor can hold on one side of the market. For this purpose, long calls and short puts are considered to be on the same side of the market. Also considered to be on the same side are short calls and long puts. The _exercise limit_ usually equals the position limit. It deﬁnes the maximum number of contracts that can be exercised by any individual (or group of individuals acting together) in any period of ﬁve consecutive business days. Options on the largest and most frequently traded stocks have positions limits of 250,000 contracts. Smaller capitalization stocks have position limits of 200,000, 75,000, 50,000, or 25,000 contracts.
>
> Position limits and exercise limits are designed to prevent the market from being unduly inﬂuenced by the activities of an individual investor or group of investors. However, whether the limits are really necessary is a controversial issue.
> 
> ...
> 
> _Warrants_ are options issued by a ﬁnancial institution or nonﬁnancial corporation. For example, a ﬁnancial institution might issue put warrants on one million ounces of gold and then proceed to create a market for the warrants. To exercise the warrant, the holder would contact the ﬁnancial institution. A common use of warrants by a nonﬁnancial corporation is at the time of a bond issue. The corporation issues call warrants on its own stock and then attaches them to the bond issue to make it more attractive to investors.
>
> _Employee stock options_ are call options issued to employees by their company to motivate them to act in the best interests of the company’s shareholders. They are usually at the money at the time of issue. They are now a cost on the income statement of the company in most countries.
> 
> _Convertible bonds_, often referred to as _convertibles_, are bonds issued by a company that can be converted into equity at certain times using a predetermined exchange ratio. They are therefore bonds with an embedded call option on the company’s stock.
>
> One feature of warrants, employee stock options, and convertibles is that a predetermined number of options are issued. By contrast, the number of options on a particular stock that trade on the CBOE or another exchange is not predetermined. As people take positions in a particular option series, the number of options outstanding increases; as people close out positions, it declines. Warrants issued by a company on its own stock, employee stock options, and convertibles are diﬀerent from exchange-traded options in another important way. When these instruments are exercised, the company issues more shares of its own stock and sells them to the option holder for the strike price. The exercise of the instruments therefore leads to an increase in the number of shares of the company’s stock that are outstanding. By contrast, when an exchange-traded call option is exercised, the party with the short position buys in the market shares that have already been issued and sells them to the party with the long position for the strike price. The company whose stock underlies the option is not involved in any way.
> 
> ...
> 
> ... The over-the-counter market for options has become increasingly important since the early 1980s and is now larger than the exchange-traded market. ... the main participants in over-the-counter markets are ﬁnancial institutions, corporate treasurers, and fund managers.[^9]

### Properties of Stock Options

> There are six factors aﬀecting the price of a stock option:
> 1. The current stock price, $S_0$
> 2. The strike price, $K$
> 3. The time to expiration, $T$
> 4. The volatility of the stock price, $σ$
> 5. The risk-free interest rate, $r$
> 6. The dividends that are expected to be paid.
> 
> **Table 11.1** Summary of the eﬀect on the price of a stock option of increasing one variable while keeping all others ﬁxed.
>
> | Variable | European call | European put | American call | American put |
> |:--- |:---:|:---:|:---:|:---:|
> | Current stock price | + | - | + | - |
> | Strike price | - | + | - | + |
> | Time to expiration | ? | ? | + | + |
> | Volatility | + | + | + | + |
> | Risk-free rate | + | - | + | - |
> | Amount of future dividends | - | + | - | + |
> 
> ---
> \+ indicates that an increase in the variable causes the option price to increase or stay the same; \
> \- indicates that an increase in the variable causes the option price to decrease or stay the same; \
> ? indicates that the relationship is uncertain

### The Black–Scholes–Merton Model

> In the early 1970s, Fischer Black, Myron Scholes, and Robert Merton achieved a major breakthrough in the pricing of European stock options.1 This was the development of what has become known as the Black–Scholes–Merton (or Black–Scholes) model. The model has had a huge inﬂuence on the way that traders price and hedge derivatives. In 1997, the importance of the model was recognized when Robert Merton and Myron Scholes were awarded the Nobel prize for economics. Sadly, Fischer Black died in 1995; otherwise he too would undoubtedly have been one of the recipients of this prize.[^10]

## Inflation

> ... the _quantity theory of money_ implies that inflation occurs when the growth rate of _money supply_ exceeds the growth rate in _real GDP_. This is the implication of the last equation that we derived: the inflation equation.
> 
> ...
> 
> It is possible that inflation increases all prices by the same percentage. For example, increasing all prices of the goods and services that a consumer buys by 5 percent and simultaneously increasing that worker’s nominal wage by 5 percent does not change any of the relative prices or the worker’s buying power. If inflation raised all prices, including all nominal wages, by the same percentage, then inflation would not matter.
> 
> However, all prices and all wages do not always move in sync, at least not in the short run. An increase in the inflation rate generates windfall losses for some and windfall gains for others. Imagine that you have negotiated a fixed 3-year nominal wage contract with your employer. If the inflation rate unexpectedly rises during this 3-year contract, you will be harmed by the unexpected inflation. In this example, though you and the other employees of the firm lose out, the shareholders of the firm benefit from the unexpected inflation, because the extra inflation lowers the real (inflation-adjusted) value of the wages that the firm pays its workers.
>
> Next consider a retiree receiving a fixed pension that is not indexed to inflation. In other words, the pension payments do not automatically rise with the overall level of prices. A rise in inflation makes the retiree worse off, because the buying power of the pension declines. Here, too, there is a winner on the other side of the relationship: the shareholders of the firm that is paying the pension. The real (inflation-adjusted) costs of the pension payments have gone down.
> 
> As yet another example, imagine that you have a mortgage at a fixed rate of interest. In other words, you borrowed money from a bank to buy your home and you are repaying that loan back at a fixed (predetermined) interest rate. If the inflation rate rises, your real interest rate falls, lowering the real cost of your mortgage. In this case, the consumer is the winner and the bank’s shareholders are the losers.
> 
> When contracts for wages, pensions, or mortgage payments are not indexed to inflation, an increase in inflation hurts some economic agents and helps others. In these three examples, inflation generates specific winners and losers but no clear overall impact on society. However, some consequences of inflation are more generally harmful—almost everyone is a loser. We now turn to those cases. We then discuss some cases where inflation is generally helpful.
> 
> ...
> 
> **Sometimes inflation can stimulate economic activity.** Assume that a worker’s nominal wage is above the competitive equilibrium level, and assume that the nominal wage is downwardly rigid (a case we highlighted in the labor supply and labor demand framework discussed in Chapter 23). The real wage is the nominal wage divided by an overall price index, like the consumer price index (CPI). A rise in the overall price index causes a fall in the real wage when the nominal wage is fixed. A fall in the real wage implies that labor has become less expensive to firms relative to the price of the firms’ outputs, which rise with inflation. A fall in the real wage therefore induces firms to hire more workers.[^13]

The Consumer Price Index (CPI) is used to calculate the inflation rate by comparing changes in the CPI over time. Here's a step-by-step process of how the CPI is used to arrive at an inflation rate:

1. **Collect CPI Data**: Statistical agencies, such as the Bureau of Labor Statistics (BLS) in the United States or the Statistical Institute of Jamaica (STATIN) in Jamaica, collect data on the prices of a basket of goods and services regularly purchased by urban consumers. This basket represents the typical spending patterns of households.

2. **Calculate CPI**: The collected price data is used to calculate the CPI for each period, typically on a monthly basis. The CPI is calculated using a weighted average formula, where each item in the basket is assigned a weight based on its relative importance in household spending.

3. **Compare CPI Across Time**: Once the CPI values are calculated for different time periods (e.g., months or years), they are compared to observe changes in the cost of the basket of goods and services over time.

4. **Calculate Inflation Rate**: The inflation rate is calculated by comparing the current CPI to a base period or year. The formula for calculating the inflation rate (annual inflation rate in this case) is as follows:

   $$\huge{
      \text{Inflation Rate} = \left( \frac{\text{Current CPI} - \text{Base CPI}}{\text{Base CPI}} \right) \times 100\%
   }$$

   - Current CPI: CPI value for the current period.
   - Base CPI: CPI value for the base period (often chosen as 100 or 1 for easier calculation).
   - The result is then multiplied by 100 to express the inflation rate as a percentage.

5. **Interpretation**: A positive inflation rate indicates that the cost of the basket of goods and services has increased over time, leading to a decrease in the purchasing power of money. Conversely, a negative inflation rate (deflation) suggests a decrease in the overall price level.

6. **Monitoring and Policy Decisions**: Economists, policymakers, businesses, and individuals use inflation rate data to monitor changes in the economy, make informed decisions regarding investments, wages, interest rates, and adjust monetary and fiscal policies accordingly to promote economic stability.

By using the CPI to track changes in the cost of living over time, economists can gauge the rate of inflation and its impact on consumers, businesses, and the overall economy.

To calculate the inflation rate using the Consumer Price Index (CPI) for August 2021 compared to August 2020 in United States, use the following formula:

$$\huge{
   \text{Inflation Rate} = \left( \frac{\text{CPI}_{\text{current}} - \text{CPI}_{\text{base}}}{\text{CPI}_{\text{base}}} \right) \times 100\%
}$$

Where:
- ${\text{CPI}_{\text{current}}}$ is the CPI for the current period (August 2021).
- ${\text{CPI}_{\text{base}}}$ is the CPI for the base period (August 2020).

Let's assume:
- ${\text{CPI}_{\text{current}} = 271.678}$, the CPI for August 2021 (hypothetical value).
- ${\text{CPI}_{\text{base}} = 257.797}$, the CPI for August 2020 (hypothetical value).

Using these values in the formula:

$$\huge{
\text{Inflation Rate} = \left( \frac{271.678 - 257.797}{257.797} \right) \times 100\%
}$$

$$\huge{
\text{Inflation Rate} = \left( \frac{13.881}{257.797} \right) \times 100\%
}$$

$$\huge{
\text{Inflation Rate} \approx 0.0538 \times 100\%
}$$

$$\huge{
\text{Inflation Rate} \approx 5.38\%
}$$

So, the inflation rate in August 2021 compared to August 2020 in the United States was approximately 5.38%.

This calculation represents a simplified example using hypothetical CPI values. For precise calculations, you would need to use the actual CPI values reported by the U.S. Bureau of Labor Statistics.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

### Consumer Price Index

The Consumer Price Index (CPI) for an item is interpreted as the percentage change in the price of that item over a specified period, typically compared to a base period or year. Here's how it's generally understood:

1. **Percentage Change**: The CPI represents the percentage change in the price of a particular item or group of items over time. A positive CPI indicates an increase in price, while a negative CPI indicates a decrease.

2. **Inflation Indicator**: The CPI is often used as a key indicator of inflation. When the CPI increases, it suggests that the cost of living is rising, and therefore, inflation is occurring. Conversely, a decrease in the CPI may indicate deflation or a decrease in the cost of living.

3. **Relative Comparison**: The CPI allows for relative comparisons of price changes across different time periods. For example, if the CPI for a specific item is 120 in the current year and was 100 in the base year, it suggests that the price of that item has increased by 20% since the base year.

4. **Purchasing Power**: Changes in the CPI can impact consumers' purchasing power. If prices increase faster than incomes, consumers may find that their money doesn't stretch as far, leading to a decrease in purchasing power.

5. **Policy Implications**: Central banks and policymakers often use CPI data to make decisions about monetary policy, including interest rates. High CPI figures may prompt central banks to raise interest rates to combat inflation, while low CPI figures may lead to interest rate cuts to stimulate economic growth.

In summary, the CPI for an item provides valuable insight into changes in the cost of living and helps individuals, businesses, and policymakers understand inflation trends and make informed decisions.

For more detailed information, you can refer to resources provided by statistical agencies such as the Statistical Institute of Jamaica (STATIN) or economic publications discussing CPI interpretation.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

### Producer Price Index

The main difference between the Producer Price Index (PPI) and the Consumer Price Index (CPI) lies in what they measure:

1. **Producer Price Index (PPI)**:
   - Measures changes in the prices received by domestic producers for their output.
   - Focuses on the prices of goods and services at the wholesale or producer level before they reach the consumer.
   - Tracks price changes for a basket of goods and services sold by producers, including raw materials, intermediate goods, and finished goods.
   - Used by businesses, policymakers, and economists to analyze trends in input costs, production inflation, and changes in profit margins along the supply chain.

2. **Consumer Price Index (CPI)**:
   - Measures changes in the prices paid by urban consumers for a basket of goods and services they commonly purchase.
   - Reflects the cost of living for households and individuals and is widely used as a measure of inflation.
   - Tracks price changes for a broad range of consumer goods and services, including food, housing, transportation, healthcare, and entertainment.
   - Used by policymakers, economists, and individuals to assess changes in purchasing power, inflation rates, and the overall cost of living.

In summary, while both the PPI and CPI measure changes in prices over time, they focus on different segments of the economy: the PPI tracks prices at the producer level, while the CPI tracks prices at the consumer level. Additionally, the PPI is more closely associated with input costs and production inflation, while the CPI is more closely tied to household expenses and changes in the cost of living.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

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
[^2]: [Simply Wall Street. Company Analysis Model](https://github.com/SimplyWallSt/Company-Analysis-Model/blob/master/MODEL.markdown)
[^3]: Page 314. Chapter 9. _Corporate Finance: The Core, Global Edition_ by Jonathan Berk and Peter Demarzo.
[^4]: Page 22. Chapter 2. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^5]: Page 599. Chapter 21. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^6]: Page 305. Chapter 12. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^7]: Page 537. Chapter 19. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^8]: Chapter 17. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^9]: Chapter 10. Mechanics of Options Markets. _Options, Futures, and Other Derivatives, Global Edition, 9th Edition_ by John C. Hull
[^10]: Chapter 15. Black-Scholes-Merton Model. _Options, Futures, and Other Derivatives, Global Edition, 9th Edition_ by John C. Hull.
[^11]: Chapter 18. Earnings Multiples. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^12]: Chapter 19. Book Value Multiples. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^13]: Chapter 25. The Monetary System. _Economics, Global Edition, Second Edition_ by Daron Acemoglu, David Laibson, John A. List