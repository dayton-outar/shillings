# Asset Evaluation

An _asset_ is any entity that delivers cashflow and/or appreciates in value over time.

> Valuation matters in the super-long-term, for example, while positioning and momentum matter much more in the short-term.[^1]

![Valuation Models](/.attachments/valuation-models.png)

> **Cash-Flow-Generating Capacity** You can categorize assets into three groups based on their capacity to generate cash flows: assets that are either generating cash flows currently or are expected to do so in the near future, assets that are not generating cash flows currently but could in the future in the event of a contingency, and assets that will never generate cash flows.
> 
> 1. The first group includes most publicly traded companies, and these firms can be valued using discounted cash flow models. Note that a distinction is not drawn between negative and positive cash flows, and young start-up companies that generate negative cash flow can still be valued using discounted cash flow models.
> 
> 2. The second group includes assets such as drug patents, promising (but not viable) technology, undeveloped oil or mining reserves, and undeveloped land. These assets may generate no cash flows currently and could generate large cash flows in the future but only under certain conditions—if the FDA approves the drug patent, if the technology becomes commercially viable, if oil prices and commercial property values go up. While you could estimate expected values using discounted cash flow models by assigning probabilities to these events, you will understate the value of the assets if you do so. You should value these assets using option pricing models.
> 
> 3. Assets that are never expected to generate cash flows include your primary residence, a baseball card collection, or fine art. These assets can only be valued using relative valuation models.
> 
> [^31]

There are 4 main approaches to valuation,

1. **Asset-based Valuation**: Asset-based valuation involves estimating the value of a company based on the value of its assets minus its liabilities. This method is particularly useful for companies with significant tangible assets, such as manufacturing or real estate companies. Asset-based valuation may include valuing assets at their book value, fair market value, or replacement cost.

2. **Discounted Cash Flow (DCF) Analysis**: DCF analysis involves estimating the present value of a company's future cash flows. It requires forecasting the company's future cash flows, determining an appropriate discount rate (usually the company's cost of capital or weighted average cost of capital), and discounting the future cash flows back to their present value. DCF analysis is considered one of the most fundamental and theoretically sound methods of valuation.

3. **Relative Valuation**: This method involves comparing the valuation metrics (such as price-to-earnings ratio, price-to-book ratio, or enterprise value-to-EBITDA ratio) of the company with those of similar companies or industry averages. Relative valuation is useful for assessing how a company's valuation multiples compare to its peers and can provide insights into whether a stock is undervalued or overvalued relative to its industry.

4. **Contingency Claim Model**: Developed by Aswath Damodaran, the Contingency Claim Model is a framework for valuing companies based on the value of their equity and debt claims. It incorporates option pricing theory and considers the company's equity as a call option on the value of its assets. This model is particularly relevant for valuing companies with complex capital structures or those facing financial distress.

Each of these methods has its strengths and weaknesses, and the choice of method depends on factors such as the company's industry, stage of development, financial condition, and the availability of data. Often, multiple valuation methods are used in conjunction to triangulate a fair value estimate for a company.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

![Selection Process of Valuation Models](/.attachments/valuation-selecting.main.valuation.models-3.png)

_Selection Process of Valuation Models_

## Asset-based Valuation Model

_Asset-based valuation_ is a model of evalaution that is best used when a business is in distress. Some analyst may prefer the simpler and more straithforward approach than _Discounted Cash Flow (DCF) Analysis_. In _asset-intensive_ industries, like manufacturing, real estate, or natural resources, the value of assets on the balance sheet can be a more reliable indicator of value than future cash flows.

Damodaran does not go into much detail explaining _asset-based valuation_ only to state,

> There are some analysts who add a fourth approach to valuation to the three described in this chapter. They argue that you can value the individual assets owned by a firm and aggregate them to arrive at a firm value—asset-based valuation models. In fact, there are several variants on asset-based valuation models. The first is **liquidation value**, which is obtained by aggregating the estimated sale proceeds of the assets owned by a firm. The second is **replacement cost**, where you estimate what it would cost you to replace all of the assets that a firm has today. The third is the simplest: use **accounting book value** as the measure of the value of the assets, with adjustments to the book value made where necessary.
> 
> While analysts may use asset-based valuation approaches to estimate value, they are not alternatives to discounted cash flow, relative, or option pricing models since both replacement and liquidation values have to be obtained using one or another of these approaches. Ultimately, all valuation models attempt to value assets; the differences arise in how we identify the assets and how we attach value to each asset. In liquidation valuation, we look only at assets in place and estimate their value based on what similar assets are priced at in the market. In traditional discounted cash flow valuation, we consider all assets and include expected growth potential to arrive at value. The two approaches may, in fact, yield the same values if you have a firm that has no growth potential and the market assessments of value reflect expected cash flows.[^4]

![Asset-based Valuation Process](/.attachments/valuation-asset-based.valuation-2.png)

_Asset-based Valuation Process_

> The approach you use to value a business will depend on how marketable its assets are, whether it generates cash flows, and how unique it is in terms of its operations.
> 
> ![Asset Marketability and Valuation Approaches](/.attachments/valuation-separable.marketable.assets.png)
> 
> _Asset Marketability and Valuation Approaches_
> 
> **Marketability of Assets** Liquidation valuation and replacement cost valuation are easiest to do for firms that have assets that are separable and marketable. For instance, you can estimate the liquidation value for a real estate company because its properties can be sold individually, and you can estimate the value of each property easily. The same can be said about a closed-end mutual fund. At the other extreme, consider a brand-name consumer product like Proctor and Gamble. Its assets are not only intangible but difficult to separate out. For instance, you cannot separate the razor business easily from the shaving cream business, and brand name value is inherent in both businesses.
> 
> You can also use this same analysis to see why the liquidation or replacement cost value of a high-growth business may bear little resemblance to true value. Unlike assets in place, growth assets cannot be easily identified or sold.[^31]

He gives an example,

> In asset-based valuation, we value the existing assets of a financial service firm, net out debt and other outstanding claims, and report the difference as the value of equity. For example, with a bank, this would require valuing the loan portfolio of the bank (which would comprise its assets) and subtracting outstanding debt to estimate the value of equity. For an insurance company, you would value the policies that the company has in force and subtract out the expected claims resulting from these policies and other debt outstanding to estimate the value of the equity in the firm.
> 
> How would you value the loan portfolio of a bank or the policies of an insurance company? One approach would be to estimate the price at which the loan portfolio can be sold to another financial service firm, but the better approach is to value it based on the expected cash flows. Consider, for instance, a bank with a $1 billion loan portfolio with a weighted average maturity of eight years, on which it earns interest income of $70 million. Furthermore, assume that the default risk on the loans is such that the fair market interest rate on the loans would be 6.50 percent; this fair market rate can be estimated by either getting the loan portfolio rated by a ratings agency or by measuring the potential for default risk in the portfolio. The value of the loans can be estimated as follows:
> 
> $$\large{ \text{Value of loans} = $70 million \text{(PV of annuity, 8 years, 6.5 percent)} + {$1,000 million \over 1.065^8} = $1,030 million }$$
> 
> This loan portfolio has a fair market value that exceeds its book value because the bank is charging an interest rate that exceeds the market rate. The reverse would be true if the bank charged an interest rate that is lower than the market rate. To value the equity in this book, you would subtract out the deposits, debt, and other claims on the bank.
> 
> This approach has merit if you are valuing a mature bank or insurance company with little or no growth potential, but it has two significant limitations. First, it does not assign any value to expected future growth and the excess returns that flow from that growth. A bank, for instance, that consistently is able to lend at rates higher than justified by default risk should be able to harvest value from future loans as well. Second, it is difficult to apply when a financial service firm enters multiple businesses. A firm like Citigroup that operates in multiple businesses would prove to be difficult to value because the assets in each business—insurance, commercial banking, investment banking, portfolio management—would need to be valued separately, with different income streams and different discount rates.[^5]

### Liquidation Value

> In some valuations, we can assume that the firm will cease operations at a point in time in the future and sell the assets it has accumulated to the highest bidders. The estimate that emerges is called a liquidation value. There are two ways in which the liquidation value can be estimated. One is to base it on the book value of the assets, adjusted for any [inflation](#inflation) during the period. Thus, if the book value of assets 10 years from now is expected to be $2 billion, the average age of the assets at that point is five years and the expected inflation rate is 3 percent, the expected liquidation value can be estimated as:
> 
> The limitation of this approach is that it is based on accounting book value and does not reflect the earning power of the assets.
> 
> $$\large{\text{Expected liquidation value} = \text{Book value of assets}_\text{term year}(1 + \text{Inflation rate})^\text{average life of assets} = $2 billion(1.03)^5 = $2.319 billion}$$
>
> The alternative approach is to estimate the value based on the earning power of the assets. To make this estimate, we would first have to estimate the expected cash flows from the assets and then discount these cash flows back to the present, using an appropriate discount rate. In the preceding example, for instance, if we assumed that the assets in question could be expected to generate $400 million in after-tax cash flows for 15 years (after the terminal year) and the cost of capital was 10 percent, our estimate of the expected liquidation value would be:
> 
> $$\large{\text{Expected liquidation value} = $400 million(\text{PV of annuity, 15 years @ 10 percent}) = $3.042 billion}$$
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

As stated previously, _Discounted Cashflow_ involves estimating the present value of a company's _future cash flow_. To do this, the _growth rate_ and the _risk_ associated with the asset must be assessed.

> $\huge{Value = { \sum_{t=1}^{t=n}{CF_{t} } \over (1 + r)^t}}$
> 
> where, \
> $n$ = Life of the asset \
> $CF_t$ = Cash flow in period $t$ \
> $r$ = Discount rate reflecting the riskiness of the estimated cash flows[^4]

There are several approaches and combinations with which _cashflow_, _growth_ and _risk_ can be deduced and used to evaluate an asset. The complexity of this approach is due to the various circumstances that assets promise future cashflows.

When it comes to _cashflows_, an evaluation can be done by focusing either on _Equity Valuation Models_ or _Firm Valuation Models_. _Equity Valuation Models_ evaluates cashflows solely on equity, that is wealth that is had from the shareholders of the asset excluding debt. _Equity Valuation Models_ include the use of _Dividends_ or _Free Cashflows to Equity_ (FCFE). _Firm Valuation Models_ includes wealth (or financing) that includes debt. The _Firm Valuation Models_ can be broken down into 3 approaches: _Cost of Capital_, _Adjusted Present Value_ and _Excess Returns_. Damodaran explains the key differences between these approaches,

> ![Equity versus Firm Valuation](/.attachments/valuation-firm.valuation.png)
> 
> _Equity versus Firm Valuation_
> 
> **Cost of Capital versus APV Approaches** In illustration above, we noted that a firm can finance its assets, using either equity or debt. What are the effects of using debt on value? On the plus side, the tax deductibility of interest expenses provides a tax subsidy or benefit to the firm, which increases with the tax rate faced by the firm on its income. On the minus side, debt does increase the likelihood that the firm will default on its commitments and be forced into bankruptcy. The net effect can be positive, neutral or negative. In the _cost of capital approach_, we capture the effects of debt in the discount rate:
> 
> ***Cost of capital = Cost of equity (Proportion of equity used to fund business) + Pretax cost of debt (1 − Tax rate) (Proportion of debt used to fund business)***
> 
> The cash flows discounted are predebt cash flows and do not include any of the tax benefits of debt (since that would be double counting).
> 
> In a variation, called the _adjusted present value (APV) approach_, we separate the effects on value of debt financing from the value of the assets of a business. Thus, we start by valuing the business as if it were all equity funded and assess the effect of debt separately, by first valuing the tax benefits from the debt and then subtracting out the expected bankruptcy costs.
> 
> ***Value of business = Value of business with 100% equity financing + Present value of expected tax benefits of debt − Expected bankruptcy costs***
> 
> While the two approaches take different tacks to evaluating the value added or destroyed by debt, they will provide the same estimate of value, if we are consistent in our assumptions about cash flows and risk.
> 
> **Total Cash Flow versus Excess Cash Flow Models** The conventional discounted cash flow model values an asset by estimating the present value of all cash flows generated by that asset at the appropriate discount rate. In _excess return (and excess cash flow) models_, only cash flows earned in excess of the required return are viewed as value creating, and the present value of these excess cash flows can be added to the amount invested in the asset to estimate its value. To illustrate, assume that you have an asset in which you invested $100 million and that you expect to generate $12 million in after-tax cash flows in perpetuity. Assume further that the cost of capital on this investment is 10 percent. With a total cash flow model, the value of this asset can be estimated as follows:
> 
> ***Value of asset = $12 million /.1 = $120 million***
> 
> With an excess return model, we would first compute the excess return made on this asset:
> 
> ***Excess return = Cash flow earned – Cost of capital × Capital invested in asset = $12 million – .10 × $100 million = $2 million***
> 
> We then add the present value of these excess returns to the investment in the asset:
> 
> ***Value of asset = Present value of excess return + Investment in the asset = $2 million /.1 + $100 million = $120 million***
> 
> Note that the answers in the two approaches are equivalent. Why, then, would we want to use an excess return model? By focusing on excess returns, this model brings home the point that it is not earnings per se that create value, but earnings in excess of a required return.[^4]

Both debt and equity has _risk_ associated with them and their are about 3 main approaches of how to interpret the risk of capital (or wealth), which constitutes both debt and equity. The 3 main approaches for assessing the risk of cashflow includes _Capital Asset Pricing Model_, _Arbitrage Pricing Model_ and _Multifactor Models_.

### Risk

> **Components of Risk** When an investor buys stock or takes an equity position in a firm, he or she is exposed to many risks. Some risk may affect only one or a few firms, and this risk is categorized as firm-specific risk. Within this category, we would consider a wide range of risks, starting with the risk that a firm may have misjudged the demand for a product from its customers; we call this project risk. For instance, consider Boeing’s investment in a Super Jumbo jet. This investment is based on the assumption that airlines want a larger airplane and are willing to pay a high price for it. If Boeing has misjudged this demand, it will clearly have an impact on Boeing’s earnings and value, but it should not have a significant effect on other firms in the market. The risk could also arise from competitors proving to be stronger or weaker than anticipated, called competitive risk. For instance, assume that Boeing and Airbus are competing for an order from Qantas, the Australian airline. The possibility that Airbus may win the bid is a potential source of risk to Boeing and perhaps some of its suppliers, but again, few other firms will be affected by it. Similarly, Disney recently launched magazines aimed at teenage girls, hoping to capitalize on the success of its TV shows. Whether it succeeds is clearly important to Disney and its competitors, but it is unlikely to have an impact on the rest of the market. In fact, risk measures can be extended to include risks that may affect an entire sector but are restricted to that sector; we call this sector risk. For instance, a cut in the defense budget in the United States will adversely affect all firms in the defense business, including Boeing, but there should be no significant impact on other sectors. What is common across the three risks described—project, competitive, and sector risk—is that they affect only a small subset of firms.
> 
> There is another group of risks that is much more pervasive and affects many if not all investments. For instance, when interest rates increase, all investments are negatively affected, albeit to different degrees. Similarly, when the economy weakens, all firms feel the effects, though cyclical firms (such as automobiles, steel, and housing) may feel it more. We term this risk market risk.
> 
> Finally, there are risks that fall in a gray area, depending on how many assets they affect. For instance, when the dollar strengthens against other currencies, it has a significant impact on the earnings and values of firms with international operations. If most firms in the market have significant international operations, it could well be categorized as market risk. If only a few do, it would be closer to firm-specific risk. The illustration below summarizes the spectrum of firm-specific and market risks.
> 
> ![Breakdown of Risk](/.attachments/valuation-breakdown.of.risk.png)
> 
> _Breakdown of Risk_
> 
> ...[^24]

> The only securities that have a chance of being risk free are government securities, not because governments are better run than corporations, but because they usually control the printing of currency. ... Even this assumption, straightforward though it might seem, does not always hold up, especially when governments refuse to honor claims made by previous regimes and when they borrow in currencies other than their own.
> 
> There is a second condition that riskless securities need to fulfill that is often forgotten. For an investment to have an actual return equal to its expected return, there can be no reinvestment risk. To illustrate this point, assume that you are trying to estimate the expected return over a five-year period and that you want a risk-free rate. A six-month Treasury bill rate, while default free, will not be risk free, because there is the reinvestment risk of not knowing what the Treasury bill rate will be in six months. Even a five-year Treasury bond is not risk free, since the coupons on the bond will be reinvested at rates that cannot be predicted today. The risk-free rate for a five-year time horizon has to be the expected return on a default-free (government) five-year zero coupon bond. This clearly has painful implications for anyone doing corporate finance or valuation, where expected returns often have to be estimated for periods ranging from 1 to 10 years. A purist’s view of risk-free rates would then require different risk-free rates for each period, and different expected returns.
> 
> As a practical compromise, however, it is worth noting that the present value effect of using year-specific risk-free rates tends to be small for most well-behaved term structures. In these cases, we could use a duration matching strategy, where the duration of the default-free security used as the risk-free asset is matched up to the duration of the cash flows in the analysis. If, however, there are very large differences, in either direction, between short-term and long-term rates, it does pay to stick with year-specific risk-free rates in computing expected returns.
> 
> ... firms will be valued more highly when the currency used is the one with low interest rates relative to [inflation](#inflation). ...
> 
> ...
> 
> If the government issues long-term bonds denominated in the local currency and these bonds are traded, you can use the interest rates on these bonds as a starting point for estimating the risk-free rate in that currency. In early 2011, for instance, the Indian government issued 10-year rupee-denominated bonds that were trading at a yield of 8 percent. This rate, though, is not a risk-free rate, because investors perceive default risk in the Indian government. To back out how much of the yield can be attributed to the default risk, we used the local currency sovereign rating of Ba2 assigned to India by Moody’s and estimated a default spread of 2.40 percent for that rating.
> 
> The resulting risk-free rate in rupees is:
> 
> Risk-free rate in rupees = Government bond rate – Default spread \
> = 8.00% - 2.40% = 5.6%
> 
> It is true that this number assumes that the ratings agency is correct in its assessment of sovereign risk and that the default spread based on the rating is correct.
> 
> ...
> 
> **Risk-Free Rate Conversion** If the only reason for differences in risk-free rates in different currencies is expected inflation, you can convert the risk-free rate in a mature market currency (U.S. dollars, euros) into a risk-free rate in an emerging market currency, using differences in inflation across currencies.
> 
> $\huge{ r_l = { (1 + r_f) \times { { { 1 + \text{ Expected inflation }_l } \over { 1 + \text{ Expected inflation }_f } } - 1} } }$
> 
> where,\
> $l$ is local currency \
> $f$ is foreign currency
> 
> For example, assume that the risk-free rate in U.S. dollars is 4 percent and that the expected inflation rate in Indonesian rupiah is 11 percent (compared to the 2 percent inflation rate in U.S. dollars). The Indonesian risk-free rate can be written as follows:
> 
> $\huge{ \text{Cost of capital }_r = 1.04 \times \frac{1.11}{1.02} - 1 = 0.131764 }$ or 13.18%
> 
> To make this conversion, we still have to estimate the expected inflation in the local currency and the mature market currency.
> 
> What if none of these choices listed work? In other words, what if the government has no local currency bonds outstanding, there are no forward or futures contract on the currency, and/or expected inflation in the local currency is difficult to estimate? Faced with these problems, it is best to switch and do your valuation in a different currency. Thus, rather than value a Nigerian or Vietnamese company in the local currency, you would value it in euros or dollars. You will still have to estimate expected exchange rates in the future in order to convert local currency cash flows to foreign currency cash flows, but that may be a more manageable exercise.[^25]

> **Equity Risk Premium**
> 
> The notion that risk matters, and that riskier investments should have a higher expected return than safer investments to be considered good investments, is intuitive. Thus, the expected return on any investment can be written as the sum of the risk-free rate and an extra return to compensate for the risk. The disagreement, in both theoretical and practical terms, remains on how to measure this risk, and how to convert the risk measure into an expected return that compensates for risk. This section looks at the estimation of an appropriate equity risk premium (ERP) to use in risk and return models, in general, and in the capital asset pricing model, in particular.[^25]

> Different securities have different initial prices, pay different cash flows, and sell for different future amounts. To make them comparable, we express their performance in terms of their returns. The return indicates the percentage increase in the value of an investment per dollar initially invested in the security. When an investment is risky, there are different returns it may earn. Each possible return has some likelihood of occurring. We summarize this information with a **probability distribution**, which assigns a probability, $pR$, that each possible return, $R$, will occur.
> 
> ...
> 
> **Expected Return**
> 
> Given the probability distribution of returns, we can compute the expected return. We calculate the **expected** (or **mean**) **return** as a weighted average of the possible returns, where the weights correspond to the probabilities.
> 
> $\huge{ \text{Expected Return} = E[R] = {\sum}_r p_R \times R }$
> 
> ***Probability Distribution of Returns for BFI***
> 
> | Current Stock Price ($) | Stock Price in One Year ($) | Return, $R$ | Probability, $p_R$ |
> | ---:| ---:|---:|---:|
> |  | 140 | 0.40 | 25% |
> | 100 | 110 | 0.40 | 50% |
> |  | 80 | -0.20 | 25% |
> 
> ![Probability Distribution of Returns for BFI](/.attachments/valuation-probability.distribution-bfi.png)
> 
> _Probability Distribution of Returns for BFI_
> 
> The expected return is the return we would earn on average if we could repeat the investment many times, drawing the return from the same distribution each time. In terms of the histogram, the expected return is the “balancing point” of the distribution, if we think of the probabilities as weights. The expected return for BFI is
> 
> $E[R_{BFI}]$ = 25%(-0.20) + 50%(0.10) + 25%(0.40) = 10%
> 
> **Variance and Standard Deviation**
> 
> Two common measures of the risk of a probability distribution are its _variance_ and _standard deviation_. The **variance** is the expected squared deviation from the mean, and the **standard deviation** is the square root of the variance.
> 
> $\huge{ Var(R) = E[(R - E[R])^2] = {\sum}_R p_R \times (R - E[R])^2 }$
> 
> $\huge{ SD(R) = \sqrt{Var(R)} }$
> 
> If the return is risk-free and never deviates from its mean, the variance is zero. Otherwise, the variance increases with the magnitude of the deviations from the mean. Therefore, the variance is a measure of how “spread out” the distribution of the return is. The variance of BFI’s return is
> 
> $Var(R_{BFI})$ = 25% $\times (-0.20- 0.10)^2$ + 50% $\times (0.10-0.10)^2$ + 25% $\times (0.40 - 0.10)^2$ = 0.045
> 
> The standard deviation of the return is the square root of the variance, so for BFI,
> 
> $SD(R) = \sqrt{Var(R)} = \sqrt{0.045}$ = 21.2%
> 
> In finance, we refer to the standard deviation of a return as its **volatility**. While the variance and the standard deviation both measure the variability of the returns, the standard deviation is easier to interpret because it is in the same units as the returns themselves.
> 
> ...
> 
> If we could observe the probability distributions that investors anticipate for different securities, we could compute their expected returns and volatilities and explore the relationship between them. Of course, in most situations we do not know the explicit probability distribution, as we did for BFI. Without that information, how can we estimate and compare risk and return? A popular approach is to extrapolate from historical data, which is a sensible strategy if we are in a stable environment and believe that the distribution of future returns should mirror that of past returns.
> 
> ...
> 
> Of all the possible returns, the **realized return** is the return that actually occurs over a particular time period. How do we measure the realized return for a stock? Suppose you invest in a stock on date $t$ for price $P_t$. If the stock pays a dividend, $Div_{t + 1}$, on date $t + 1$, and you sell the stock at that time for price Pt +1, then the realized return from your investment in the stock from $t$ to $t + 1$ is
> 
> $\huge{ R_{t + 1} = { { { Div_{t + 1} + P_{t + 1} \over P_t } } - 1 } = { { Div_{i + 1} \over P_t } + { { P_{t + 1} - P_t } \over P_t } }  }$
> 
> $\huge{ R_{t + 1} = \text{Dividend Yield} + \text{Capital Gain Rate}  }$
> 
> ... the realized return, $R_{t + 1}$, is the total return we earn from dividends and capital gains, expressed as a percentage of the initial stock price.
> 
> ...
> 
> ***The beta of a security is the expected % change in its return given a 1% change in the return of the market portfolio.***
> 
> ...
> 
> **Beta and the Cost of Capital**
> 
> ... we have emphasized that financial managers should evaluate an investment opportunity based on its cost of capital, which is the expected return available on alternative investments in the market with comparable risk and term. For risky investments, this cost of capital corresponds to the risk-free interest rate, plus an appropriate risk premium. ...
> 
> **Estimating the Risk Premium**
> 
> Before we can estimate the risk premium of an individual stock, we need a way to assess investors’ appetite for risk. The size of the risk premium investors will require to make a risky investment depends upon their risk aversion. Rather than attempt to measure this risk aversion directly, we can measure it indirectly by looking at the risk premium investors’ demand for investing in systematic, or market, risk.
> 
> **The Market Risk Premium.** We can calibrate investors’ appetite for market risk from the market portfolio. The risk premium investors earn by holding market risk is the difference between the market portfolio’s expected return and the risk-free interest rate:
> 
> $$\huge{ \text{ Market Risk Premium } = E[R_{Mkt}] - r_f }$$
> 
> For example, if the risk-free rate is 5% and the expected return of the market portfolio is 11%, the market risk premium is 6%. In the same way that the market interest rate reflects investors’ patience and determines the time value of money, the market risk premium reflects investors’ risk tolerance and determines the market price of risk in the economy.
> 
> **Adjusting for Beta.** The market risk premium is the reward investors expect to earn for holding a portfolio with a beta of 1—the market portfolio itself. Consider an investment opportunity with a beta of 2. This investment carries twice as much systematic risk as an investment in the market portfolio. That is, for each dollar we invest in the opportunity, we could invest twice that amount in the market portfolio and be exposed to exactly the same amount of systematic risk. Because it has twice as much systematic risk, investors will require twice the risk premium to invest in an opportunity with a beta of 2.
> 
> To summarize, we can use the beta of the investment to determine the scale of the investment in the market portfolio that has equivalent systematic risk. Thus, to compensate investors for the time value of their money as well as the systematic risk they are bearing, the cost of capital $r_I$ for an investment with beta ${\beta}_I$ should satisfy the following formula:
>
> **Estimating the Cost of Capital of an Investment from Its Beta**
> 
> $\huge{ r_I = \text{Risk-Free Interest Rate} + {\beta}_I \times \text{Market Risk Premium} }$
> 
> $\huge{ = r_f + {\beta}_I \times (E[R_m] - r_f) }$
> 
> where $m$ is for market \
> and $r_f$ is the risk-free rate [^23]

> ***Alternative Models for Cost of Equity***
> 
> | Model | Pluses | Minuses |
> |:--- |:--- |:--- |
> | CAPM | Simple to compute | Does not explain differences in returns across stocks well |
> | APM | More nuanced breakdown of market risk | Factors are statistical and unnamed |
> | Multifactor model | More intuitive than APM | Factors are unstable and change over time |
> 
> [^24]

> | Model | Assumptions | Measure of Market Risk |
> |:--- |:--- |:--- |
> | CAPM | There are no transaction costs or private information. Therefore, the diversified portfolio includes all traded investments, held in proportion to their market value. | Beta measured against this market portfolio |
> | APM | Investments with the same exposure to market risk have to trade at the same price (no arbitrage). | Betas measured against multiple (unspecified) market risk factors |
> | Multifactor model | There is the same no-arbitrage assumption as with the APM. | Betas measured against multiple specified macroeconomic factors |
> 
> Note that in the special case of a single-factor model, like the CAPM, each investment’s expected return will be determined by its beta relative to the risk premium for that factor.
> 
> Assuming that the risk-free rate is known, these models all require two inputs. The first is the beta or betas of the investment being analyzed, and the second is the appropriate risk premium(s) for the factor or factors in the model.[^25]

#### Capital Asset Pricing Model

> **Assumptions** While diversification reduces the exposure of investors to firm-specific risk, most investors limit their diversification to holding only a few assets. Even large mutual funds rarely hold more than a few hundred stocks, and many of them hold as few as 10 to 20. There are two reasons why investors stop diversifying. One is that an investor or mutual fund manager can obtain most of the benefits of diversification from a relatively small portfolio, because the marginal benefits of diversification become smaller as the portfolio gets more diversified. Consequently, these benefits may not cover the marginal costs of diversification, which include transactions and monitoring costs. Another reason for limiting diversification is that many investors (and funds) believe they can find undervalued assets and thus choose not to hold those assets that they believe to be fairly valued or overvalued.
> 
> _The capital asset pricing model assumes that there are no transaction costs, all assets are traded, and investments are infinitely divisible (i.e., you can buy any fraction of a unit of the asset). It also assumes that everyone has access to the same information and that investors therefore cannot find under- or overvalued assets in the marketplace. By making these assumptions, it allows investors to keep diversifying without additional cost. At the limit, their portfolios will not only include every traded asset in the market but these assets will be held in proportion to their market value._
> 
> The fact that this portfolio includes all traded assets in the market is the reason it is called the market portfolio, which should not be a surprising result, given the benefits of diversification and the absence of transaction costs in the capital asset pricing model. If diversification reduces exposure to firm-specific risk and there are no costs associated with adding more assets to the portfolio, the logical limit to diversification is to hold a small proportion of every traded asset in the economy. If this seems abstract, consider the market portfolio to be an extremely well diversified mutual fund that holds stocks and real assets. In the CAPM, all investors will hold combinations of the riskier asset and that supremely diversified mutual fund.
> 
> **Investor Portfolios in the CAPM** If every investor in the market holds the identical market portfolio, how exactly do investors reflect their risk aversion in their investments? In the capital asset pricing model, investors adjust for their risk preferences in their allocation decision, where they decide how much to invest in a riskless asset and how much in the market portfolio. Investors who are risk averse might choose to put much or even all of their wealth in the riskless asset. Investors who want to take more risk will invest the bulk or even all of their wealth in the market portfolio. Investors who invest all their wealth in the market portfolio and are desirous of taking on still more risk would do so by borrowing at the riskless rate and investing in the same market portfolio as everyone else.
> 
> These results are predicated on two additional assumptions. First, there exists a riskless asset, where the expected returns are known with certainty. Second, investors can lend and borrow at the riskless rate to arrive at their optimal allocations. While lending at the riskless rate can be accomplished fairly simply by buying Treasury bills or bonds, borrowing at the riskless rate might be more difficult for individuals to do. There are variations of the CAPM that allow these assumptions to be relaxed and still arrive at conclusions that are consistent with the model.
> 
> ...
> 
> > 
> ...
> 
> The covariance is a percentage value, and it is difficult to pass judgment on the relative risk of an investment by looking at this value. In other words, knowing that the covariance of Boeing with the market portfolio is 55 percent does not provide us a clue as to whether Boeing is riskier or safer than the average asset. We therefore standardize the risk measure by dividing the covariance of each asset with the market portfolio by the variance of the market portfolio. This yields a risk measure called the beta of the asset:
> 
> $\huge{ \text{Beta of asset i} = { \text{ Covariance of asset i with market portfolio } \over \text{ Variance of the market portfolio } } = { {\sigma}_i \over {\sigma}^2_m } }$
> 
> where ${\sigma}_i$ is the covariance in returns between the individual asset and the market portfolio
> 
> ...[^24]

> ${\beta}_i$ i is the beta of the security with respect to the market portfolio, defined as
> 
> $\huge{ {\beta}_i = { { SD(R_i) \times Corr(R_i, R_m) } \over SD(R_m) } = { { Cov(R_i, R_m) } \over { Var(R_m)} } }$
> 
> where $m$ is market and $i$ is the individual asset in the market
> [^26]

> **Estimating the Historical Beta for Private Firms** The historical approach to estimating betas works only for assets that have been traded and have market prices. Private companies do not have a market price history. Consequently, we cannot estimate a regression beta for these companies. Nevertheless, we still need estimates of cost of equity and capital for these companies.
> 
> You might argue that this is not an issue if you do not value private companies; but you will still be confronted with this issue even when valuing publicly traded firms. Consider, for instance, the following scenarios:
> 
> - If you have to value a private firm for an initial public offering, you will need to estimate discount rates for the valuation.
> - Even after a firm has gone public, there will be a period of time lasting as long as two years when there will be insufficient data for a regression.
> - If you are called upon to value the division of a publicly traded firm that is up for sale, you will not have past prices to draw on to run a regression.
> - Finally, if the firm has gone through significant restructuring—divestitures or recapitalization—in the recent past, regression betas become meaningless because the company itself has changed its risk characteristics.
> 
> Thus regression betas are either unavailable or meaningless in a significant number of valuations.
> 
> Some analysts assume that discounted cash flow valuation is not feasible in these scenarios; instead they use multiples. Others make assumptions about discount rates based on rules of thumb. Neither approach is appealing. ...
> 
> **The Limitations of Regression Betas** Much of what has been presented in this section represents an indictment of regression betas. In the case of Boeing, the biggest problem was that the beta had high standard error. In fact, this is not a problem unique to Boeing. ...
> 
> With the Nokia regression, we seem to cure the standard error problem but at a very large cost. The low standard errors reflect the domination of the index by a stock and result in betas that may be precise but bear no resemblance to true risk.
> 
> Changing the market index, the return period, and the return interval offers no respite. If the index becomes a more representative index, the standard errors on betas will increase, reflecting the fact that more of the risk in the stock is firm-specific. If the beta changes as the return period or interval changes, it creates more uncertainty about the true beta of the company.
> 
> In short, regression betas will almost always be either too noisy or skewed by estimation choices to be useful measures of the equity risk in a company. The cost of equity is far too important an input into a discounted cash flow valuation to be left to statistical chance.
> 
> **Fundamental Betas** A second way to estimate betas is to look at the fundamentals of the business. The beta for a firm may be estimated from a regression, but it is determined by decisions the firm has made on what business to be in and how much operating leverage to use in the business, and by the degree to which the firm uses financial leverage. This section examines an alternative way of estimating betas, where we are less reliant on historical betas and more cognizant of their fundamental determinants.
> 
> **Determinants of Betas** The beta of a firm is determined by three variables: (1) the type of business or businesses the firm is in, (2) the degree of operating leverage of the firm, and (3) the firm’s financial leverage. Although we will use these determinants to find betas in the capital asset pricing model, the same analysis can be used to calculate the betas for the arbitrage pricing and the multifactor models as well.
> 
> ***Type of Business*** Since betas measure the risk of a firm relative to a market index, the more sensitive a business is to market conditions, the higher its beta. Thus, other things remaining equal, cyclical firms can be expected to have higher betas than noncyclical firms. Companies involved in housing and automobiles, two sectors of the economy that are very sensitive to economic conditions, should have higher betas than companies in food processing and tobacco, which are relatively insensitive to business cycles.
> 
> This view can be extended to a company’s products. The degree to which a product’s purchase is discretionary will affect the beta of the firm manufacturing the product. Firms whose products are much more discretionary to their customers—they can defer or delay buying these products—should have higher betas than firms whose products are viewed as necessary or less discretionary. Thus, the beta of Procter & Gamble, which sells diapers and daily household products, should be lower than the beta of Gucci, which manufactures luxury products.
> 
> ***Degree of Operating Leverage*** The degree of operating leverage is a function of the cost structure of a firm and is usually defined in terms of the relationship between fixed costs and total costs. A firm that has high fixed costs relative to total costs is said to have high operating leverage. A firm with high operating leverage will also have higher variability in operating income than would a firm producing a similar product with low operating leverage. Other things remaining equal, the higher variance in operating income will lead to a higher beta for the firm with high operating leverage.
> 
> Can firms change their operating leverage? While some of a firm’s cost structure is determined by the business it is in (an energy utility has to build expensive power plants, and airlines have to buy or lease expensive planes), firms in the United States have become increasingly inventive in lowering the fixed cost component in their total costs. For instance, firms have made cost structures more flexible by:
> 
> - Negotiating labor contracts that emphasize flexibility and allow the firm to make its labor costs more sensitive to its financial success.
> - Entering into joint venture agreements, where the fixed costs are borne by someone else.
> - Subcontracting manufacturing and outsourcing, which reduce the need for expensive plant and equipment.
> 
> While the arguments for such actions may be couched in terms of competitive advantage and flexibility, they do also reduce the operating leverage of the firm and its exposure to market risk.
> 
> While operating leverage affects betas, it is difficult to measure the operating leverage of a firm, at least from the outside, since fixed and variable costs are often aggregated in income statements. It is possible to get an approximate measure of the operating leverage of a firm by looking at changes in operating income as a function of changes in sales.
> 
> Degree of operating leverage = % change in operating profit /% change in sales
> 
> For firms with high operating leverage, operating income should change more than proportionately when sales change.
> 
> ***Degree of Financial Leverage*** Other things remaining equal, an increase in financial leverage will increase the beta of the equity in a firm. Intuitively, we would expect that the fixed interest payments on debt result in increasing income in good times and decreasing income in bad times. Higher leverage increases the variance in net income and makes equity investment in the firm riskier. If all the firm’s risk is borne by the stockholders (i.e., the beta of debt is zero),7 and debt has a tax benefit to the firm, then,
> 
> $\huge{ {\beta}_L = {\beta}_U[1 + (1 - t)(D/E)] }$
> 
> where \
> ${\beta}_L$ = Levered beta for equity in the firm
> 
> Intuitively, we expect that as leverage increases (as measured by the debt-to-equity ratio), equity investors bear increasing amounts of market risk in the firm, leading to higher betas. The tax factor in the equation captures the tax benefits that accrue from interest payments.
> 
> The unlevered beta of a firm is determined by the nature of its products and services (cyclicality, discretionary nature) and its operating leverage. It is often also referred to as the asset beta, since it is determined by the assets owned by the firm. Thus, the levered beta, which is also the beta for an equity investment in a firm, is determined both by the riskiness of the business it operates in and by the amount of financial leverage risk it has taken on.
> 
> Since financial leverage multiplies the underlying business risk, it stands to reason that firms that have high business risk should be reluctant to take on financial leverage. It also stands to reason that firms that operate in stable businesses should be much more willing to take on financial leverage. Utilities, for instance, have historically had high debt ratios but have not had high betas, mostly because their underlying businesses have been stable and fairly predictable.
> 
> **Bottom-Up Betas** Breaking down betas into their business risk and financial leverage components provides us with an alternative way of estimating betas, in which we do not need past prices on an individual firm or asset to estimate its beta.
> 
> To develop this alternative approach, we need to introduce an additional property of betas that proves invaluable. The beta of two assets put together is a weighted average of the individual asset betas, with the weights based on market value. Consequently, the beta for a firm is a weighted average of the betas of all the different businesses it is in. We can estimate the beta for a firm in five steps:
> 
> _Step 1:_ Identify the business or businesses the firm operates in.
> 
> _Step 2:_ Find other publicly traded firms in each business and obtain their regression betas, which we use to compute an average beta for the firms.
> 
> _Step 3:_ Estimate the average unlevered beta for the business by unlevering the average (or median) beta for the firms by their average (or median) debt-to-equity ratio. Alternatively, we could estimate the unlevered beta for each firm and then compute the average of the unlevered betas. The first approach is preferable because unlevering an erroneous regression beta is likely to compound the error.
> 
> $\huge{ \text{ Unlevered beta }_b = \text{Beta}_f/[1 + (1 -t)({D/E}_f)] }$
> 
> where $b$ is business and $f$ is comparable firms.
> 
> _Step 4:_ Estimate an unlevered beta for the firm being analyzed, taking a weighted average of the unlevered betas for the businesses it operates in, using the proportion of firm value derived from each business as the weights. If values are not available, use operating income or revenues as weights. This weighted average is called the bottom-up unlevered beta.
> 
> $\huge{ \text{ Unlevered beta }_f = {\sum}_{j=1}^{j=k} ( \text{Unlevered beta}_j \times \text{ Value weight }_j ) }$
> 
> where the firm is assumed to operating in $k$ different businesses.
>
> _Step 5:_ Finally, estimate the current market values of debt and equity at the firm and use this debt-to-equity ratio to estimate a levered beta.
> 
> The betas estimated using this processs are called bottom-up betas.
> 
> [^27]

> **Getting Expected Returns** The fact that every investor holds some combination of the riskless asset and the market portfolio leads to the next conclusion, which is that the expected return on an asset is linearly related to the beta of the asset. In particular, the expected return on an asset can be written as a function of the risk-free rate and the beta of that asset:
> 
> $\huge{ E(R_i) = R_f + {\beta}_i[E(R_m) – R_f] }$
> 
> where, \
> $E(R_i)$ = Expected return on asset $i$ \
> $R_f$ = Risk-free rate \
> $E(R_m)$ = Expected return on market portfolio \
> ${\delta}_i$ = Beta of asset $i$
> 
> To use the capital asset pricing model, we need three inputs. ...each of these inputs is estimated as follows:
> 
> - The riskless asset is defined to be an asset for which the investor knows the expected return with certainty for the time horizon of the analysis.
> - The risk premium is the premium demanded by investors for investing in the market portfolio, which includes all risky assets in the market, instead of investing in a riskless asset.
> - The beta, defined as the covariance of the asset divided by the market portfolio, measures the risk added by an investment to the market portfolio.
> 
> In summary, in the capital asset pricing model all the market risk is captured in one beta measured relative to a market portfolio, which at least in theory should include all traded assets in the marketplace held in proportion to their market value.[^24]

#### Arbitrage Pricing Model

> _The restrictive assumptions on transaction costs and private information in the capital asset pricing model, and the model’s dependence on the market portfolio, have long been viewed with skepticism by both academics and practitioners_. Ross (1976) suggested an alternative model for measuring risk called the arbitrage pricing model (APM).
> 
> **Assumptions** If investors can invest risklessly and earn more than the riskless rate, they have found an arbitrage opportunity. The premise of the arbitrage pricing model is that investors take advantage of such arbitrage opportunities, and in the process eliminate them. If two portfolios have the same exposure to risk but offer different expected returns, investors will buy the portfolio that has the higher expected returns and sell the portfolio with the lower expected returns, and earn the difference as a riskless profit. To prevent this arbitrage from occurring, the two portfolios have to earn the same expected return.
> 
> Like the capital asset pricing model, the arbitrage pricing model begins by breaking risk down into firm-specific and market risk components. As in the capital asset pricing model, firm-specific risk covers information that affects primarily the firm. Market risk affects many or all firms and would include unanticipated changes in a number of economic variables, including gross national product, inflation, and interest rates. Incorporating both types of risk into a return model, we get:
> 
> $\huge{ R = E(R) + m + \varepsilon }$
> 
> where $R$ is the actual return, $E(R)$ is the expected return, $m$ is the marketwide component of unanticipated risk, and $\varepsilon$ is the firm-specific component. Thus, the actual return can be different from the expected return, because of either market risk or firm-specific actions.
> 
> **Sources of Marketwide Risk** While both the capital asset pricing model and the arbitrage pricing model make a distinction between firm-specific and marketwide risk, they measure market risk differently. The CAPM assumes that market risk is captured in the market portfolio, whereas the arbitrage pricing model allows for multiple sources of marketwide risk and measures the sensitivity of investments to changes in each source. In general, the market component of unanticipated returns can be decomposed into economic factors:
> 
> $\huge{ R = E(R) + m + \varepsilon }$
> $\huge{ = R + ( {\beta}_1F_1 + {\beta}_2F_2 + \ldots + {\beta}_nF_n ) + \varepsilon }$
> 
> where, \
> ${\beta}_j$ = Sensitivity of investment to unanticipated changes in market risk factor $j$ \
> $F_j$ = Unanticipated changes in market risk factor $j$
> 
> Note that the measure of an investment’s sensitivity to any macroeconomic (or market) factor takes the form of a beta, called a factor beta. In fact, this beta has many of the same properties as the market beta in the CAPM.

#### Multifactor Models

> The arbitrage pricing model’s failure to identify the factors specifically in the model may be a statistical strength, but it is an intuitive weakness. The solution seems simple: Replace the unidentified statistical factors with specific economic factors, and the resultant model should have an economic basis while still retaining much of the strength of the arbitrage pricing model. That is precisely what multifactor models try to do.
> 
> **Deriving a Multifactor Model** Multifactor models generally are determined by historical data rather than by economic modeling. Once the number of factors has been identified in the arbitrage pricing model, their behavior over time can be extracted from the data. The behavior of the unnamed factors over time can then be compared to the behavior of macroeconomic variables over that same period, to see whether any of the variables is correlated, over time, with the identified factors.
> 
> For instance, Chen, Roll, and Ross (1986) suggest that the following macro-economic variables are highly correlated with the factors that come out of factor analysis: industrial production, changes in default premium, shifts in the term structure, unanticipated inflation, and changes in the real rate of return. These variables can then be correlated with returns to come up with a model of expected returns, with firm-specific betas calculated relative to each variable.
> 
> $\huge{ E(R) = R_f + {\beta}_G[E(R_G) - R_f] + {\beta}_I[E(R_I) - R_f] + \ldots + {\beta}_n[E(R_n) - R_f] }$
> 
> where, \
> ${\beta}_G$ = Beta relative to changes in industrial production \
> $E(R_G)$ = Expected return on a portfolio with a beta of one on the industrial production factor and zero on all other factors \
> ${\beta}_I$ = Beta relative to changes in inflation \
> $E(R_I)$ = Expected return on a portfolio with a beta of one on the inflation factor and zero on all other factors
> 
> The costs of going from the arbitrage pricing model to a macroeconomic multi-factor model can be traced directly to the errors that can be made in identifying the factors. The economic factors in the model can change over time, as will the risk premium associated with each one. For instance, oil price changes were a significant economic factor driving expected returns in the 1970s but are not as significant in other time periods. Using the wrong factor or missing a significant factor in a multifactor model can lead to inferior estimates of expected return.

### Growth

> The value of a firm is the present value of expected future cash flows generated by the firm. The most critical input in valuation, especially for high-growth firms, is the growth rate to use to forecast future revenues and earnings.
> 
> ...
> 
> There are three basic ways of estimating growth for any firm. One is to look at the growth in a firm’s past earnings—its ***historical growth rate***. While this can be a useful input when valuing stable firms, there are both dangers and limitations in using this growth rate for high-growth firms. The historical growth rate can often not be estimated, and even if it can, it cannot be relied on as an estimate of expected future growth.
> 
> The second is to trust the analysts who follow the firm to come up with the ***right estimate of growth*** for the firm, and to use that growth rate in valuation. Although many firms are widely followed by analysts, the quality of growth estimates, especially over longer periods, is poor. Relying on these growth estimates in a valuation can lead to erroneous and inconsistent estimates of value.
> 
> The third is to estimate the ***growth from a firm’s fundamentals***. A firm’s growth ultimately is determined by how much is reinvested into new assets and the quality of these investments, with investments widely defined to include acquisitions, building distribution channels, or even expanding marketing capabilities. By estimating these inputs, you are, in a sense, estimating a firm’s fundamental growth rate.
> 
> A firm can be valuable because it owns assets that generate cash flows now or because it is expected to acquire such assets in the future. The first group of assets is categorized as assets in place and the second as growth assets. ... Note that an accounting balance sheet can be very different from a financial balance sheet, since accounting for growth assets tends to be both conservative and inconsistent.
> 
> For high-growth firms, accounting balance sheets do a poor job of summarizing the values of the assets of the firm because they mostly ignore the largest component of value, which is future growth. The problems are exacerbated for firms that invest in R&D, because the book value will not include the most important asset at these firms—the research asset.
> 
> ...
> 
> **Estimating Historical Growth**
> 
> Given a firm’s earnings history, estimating historical growth rates may seem like a simple exercise but there are several measurement problems that may arise. In particular, you can get very different values for historical growth, depending on how the average is estimated and whether you allow for compounding in values over time. Estimating growth rates can also be complicated by the presence of negative earnings in the past or in the current period.
> 
> ...
> 
> **Usefulness of Historical Growth**
> 
> Is the growth rate in the past a good indicator of growth in the future? Not necessarily.
> 
> ...
> 
> **Higgledy-Piggledy Growth** Past growth rates are useful in forecasting future growth, but they have considerable noise associated with them. In a study of the relationship between past growth rates and future growth rates, Little (1960) coined the term “higgledy-piggledy growth” because he found little evidence that firms that grew fast in one period continued to grow fast in the next period. In the process of running a series of correlations between growth rates in consecutive periods of different length, he frequently found negative correlations between growth rates in the two periods, and the average correlation across the two periods was close to zero.
> 
> If past growth is not a reliable indicator of future growth at many firms, it becomes even less so at smaller firms. The growth rates at smaller firms tend to be more volatile than growth rates at other firms in the market.
> 
> While the correlations tend to be higher across the board for one-year growth rates than for three-year or five-year growth rates in earnings, they are also consistently lower for smaller firms than they are for the rest of the market. This would suggest that you should be more cautious about using past growth, especially in earnings, for forecasting future growth at these firms.
> 
> **Revenue Growth versus Earnings Growth** In general, revenue growth tends to be more persistent and predictable than earnings growth. This is because accounting choices have a far smaller effect on revenues than they do on earnings. ... Revenue growth is consistently more correlated over time than earnings growth. The implication is that historical growth in revenues is a far more useful number when it comes to forecasting than historical growth in earnings. 
> 
> **Effects of Firm Size** Since the growth rate is stated in percentage terms, the role of the size of the firm has to be weighed in the analysis. It is easier for a firm with $10 million in earnings to generate a 50 percent growth rate than it is for a firm with $500 million in earnings. Since it becomes harder for firms to sustain high growth rates as they become larger, past growth rates for firms that have grown dramatically in size may be difficult to sustain in the future. While this is a problem for all firms, it is a particular problem when analyzing small and growing firms.
> 
> While the fundamentals at these firms, in terms of management, products, and underlying markets, may not have changed, it will still be difficult to maintain historical growth rates as the firms double or triple in size.
> 
> The true test for a small firm lies in how well it handles growth. Some firms continue to deliver their products and services efficiently as they grow. In other words, they are able to scale up successfully. Other firms have had much more difficulty replicating their success as they become larger. In analyzing small firms, therefore, it is important that you look at plans to increase growth but it is even more critical that you examine the systems in place to handle this growth.
> 
> **Analyst Estimates of Growth**
> 
> Equity research analysts provide not only recommendations on the firms they follow but also estimates of earnings and earnings growth for the future. How useful are these estimates of expected growth from analysts and how, if at all, can they be used in valuing firms? ...
> 
> **Who Do Analysts Follow?**
> 
> The number of analysts tracking firms varies widely across firms. At one extreme are firms like Apple, GE, and Microsoft that are followed by dozens of analysts. At the other extreme, there are hundreds of firms that are not followed by any analysts.
> 
> Why are some firms more heavily followed than others? These seem to be some of the determinants:
> 
> - _Market capitalization._ The larger the market capitalization of a firm, the more likely it is to be followed by analysts.
> 
> - _Institutional holding._ The greater the percent of a firm’s stock that is held by institutions, the more likely it is to be followed by analysts. The open question, though, is whether analysts follow institutions or whether institutions follow analysts. Given that institutional investors are the biggest clients of equity research analysts, the causality probably runs both ways.
> 
> - _Trading volume._ Analysts are more likely to follow liquid stocks. Here again, though, it is worth noting that the presence of analysts and buy (or sell) recommendations on a stock may play a role in increasing trading volume.
> 
> **Information in Analyst Forecasts**
> 
> There is a simple reason to believe that analyst forecasts of growth should be better than using historical growth rates. Analysts, in addition to using historical data, can avail themselves of five other types of information that may be useful in predicting future growth:
> 
> 1. _Firm-specific information that has been made public since the last earnings report._ Analysts can use information that has come out about the firm since the last earnings report, to make predictions about future growth. This information can sometimes lead to significant reevaluation of the firm’s expected cash flows.
> 
> 2. _Macroeconomic information that may impact future growth._ The expected growth rates of all firms are affected by economic news on GNP growth, interest rates, and inflation. Analysts can update their projections of future growth as new information comes out about the overall economy and about changes in fiscal and monetary policy. Information, for instance, that shows the economy growing at a faster rate than forecast will result in analysts increasing their estimates of expected growth for cyclical firms.
> 
> 3. _Information revealed by competitors on future prospects._ Analysts can also condition their growth estimates for a firm on information revealed by on pricing policy and future growth. For instance, a negative earnings report by one telecommunications firm can lead to a reassessment of earnings for other telecommunications firms.competitors on pricing policy and future growth. For instance, a negative earnings report by one telecommunications firm can lead to a reassessment of earnings for other telecommunications firms.
> 
> 4. _Private information about the firm._ Analysts sometimes have access to private information about the firms they follow that may be relevant in forecasting future growth. This avoids answering the delicate question of when private information becomes illegal inside information. There is no doubt, however, that good private information can lead to significantly better estimates of future growth. In an attempt to restrict this type of information leakage, the SEC issued new regulations preventing firms from selectively revealing information to a few analysts or investors. Outside the United States, however, firms routinely convey private information to analysts following them.
> 
> 5. _Public information other than earnings._ Models for forecasting earnings that depend entirely on past earnings data may ignore other publicly available information that is useful in forecasting future earnings. It has been shown, for instance, that other financial variables such as earnings retention, profit margins, and asset turnover are useful in predicting future growth. Analysts can incorporate information from these variables into their forecasts.
> 
> **Quality of Analyst Forecast**
> 
> ...
> 
> The general consensus from studies that have looked at short-term forecasts (one quarter ahead to four quarters ahead) of earnings is that analysts provide better forecasts of earnings than models that depend purely on historical data. The mean relative absolute error, which measures the absolute difference between the actual earnings and the forecast for the next quarter, in percentage terms, is smaller for analyst forecasts than it is for forecasts based on historical data. ...
> 
> ...
> 
> **How Do You Use Analyst Forecasts in Estimating Future Growth?**
> 
> The information in the growth rates estimated by other analysts can and should be incorporated into the estimation of expected future growth. There are four factors that determine the weight assigned to analyst forecasts in predicting future growth:
> 
> 1. _Amount of recent firm-specific information._ Analyst forecasts have an advantage over historical data–based models because they incorporate more recent information about the firm and its future prospects. This advantage is likely to be greater for firms where there have been significant changes in management or business conditions in the recent past, for example, a restructuring or a shift in government policy relating to the firm’s underlying business.
> 
> 2. _Number of analysts following the stock._ Generally speaking, the larger the number of analysts following a stock, the more informative is their consensus forecast, and the greater should be the weight assigned to it in analysis. The informational gain from having more analysts is diminished somewhat by the well-established fact that most analysts do not act independently, resulting in a high correlation across analysts’ revisions of expected earnings.
> 
> 3. _Extent of disagreement between analysts._ While consensus earnings growth rates are useful in valuation, the extent of disagreement between analysts measured by the standard deviation in growth predictions is also a useful measure of the reliability of the consensus forecasts. Givoly and Lakonsihok (1984) found that the dispersion of earnings is correlated with other measures of risk such as beta and is a good predictor of expected returns.
> 
> 4. _Quality of analysts following the stock._ This is the hardest of the variables to quantify. One measure of quality is the size of the forecast error made by analysts following a stock, relative to models that use only historical data—the smaller this relative error, the larger the weight that should be attached to analyst forecasts. Another measure is the effect on stock prices of analyst revisions—the more informative the forecasts, the greater the effect on stock prices. There are some who argue that the focus on consensus forecasts misses the point that some analysts are better than others in predicting earnings, and that their forecasts should be isolated from the rest and weighted more.
> 
> Analyst forecasts may be useful in coming up with a predicted growth rate for a firm, but there is a danger to blindly following consensus forecasts. Analysts often make significant errors in forecasting earnings, partly because they depend on the same data sources (which might have been erroneous or misleading) and partly because they sometimes overlook significant shifts in the fundamental characteristics of the firm. The secret to successful valuation often lies in discovering inconsistencies between analysts’ forecasts of growth and a firm’s fundamentals.
> 
> **Fundamental Determinants of Growth**
> 
> With both historical and analyst estimates, growth is an exogenous variable that affects value but is divorced from the operating details of the firm. The soundest way of incorporating growth into value is to make it endogenous i.e., tie in more closely to the actions that a business takes to create and sustain that growth.
> 
> 
> **Growth in Earnings per Share** The simplest relationship determining growth is one based on the retention ratio (percentage of earnings retained in the firm) and the return on equity on its projects. Firms that have higher retention ratios and earn higher returns on equity should have much higher growth rates in earnings per share than firms that do not share these characteristics. To establish this, note that:
> 
> $$\huge{ g_t = (NI_t - NI_{t-1})/NI_{t-1} }$$
> 
> where \
> $g_t$ = Growth rate in net income \
> $NI_t$ = Net income in year $t$
> 
> Also note that the $ROE$ in period $t$ can be written as $NI$ in period $t$ divided by the Book value of equity in period $t – 1$. Given the definition of return on equity, the net income in year $t – 1$ can be written as:
> 
> $$\huge{ NI_{t - 1} = \text{Book value of equity}_{t-2} \times ROE_{t-1} }$$
> 
> where $ROE_{t-1}$ = Return on equity in year $t - 1$
> 
> The net income in year t can be written as:
> 
> $$\huge{ NI_t = (\text{Book value of equity}_{t–2} + \text{Retained earnings}_{t–1}) \times ROE_t }$$
> 
> Assuming that the return on equity is unchanged (i.e., $ROE_t = ROE_{t–1} = ROE$):
> 
> $\huge{ g_t = { \text{Retained earnings}_{t–1}/NI_{t–1} \times ROE } = { \text{ Retention ratio } \times ROE } = { b \times ROE} }$
> 
> where $b$ is the retention ratio. Note that the firm is not being allowed to raise equity by issuing new shares. Consequently, the growth rate in net income and the growth rate in earnings per share are the same in this formulation.
> 
> **Growth in Net Income** If we relax the assumption that the only source of equity is retained earnings, the growth in net income can be different from the growth in earnings per share. Intuitively, note that a firm can grow net income significantly by issuing new equity to fund new projects, while earnings per share stagnates. To derive the relationship between net income growth and fundamentals, we need a measure of investment that goes beyond retained earnings. One way to obtain such a measure is to estimate how much equity the firm reinvests back into its businesses in the form of net capital expenditures and investments in working capital.
> 
> ${ \text{Equity reinvested in business} = \text{Capital expenditures} − \text{Depreciation} + \text{Change in working capital} − (\text{New debt issued} − \text{Debt repaid} ) }$
> 
> Dividing this number by the net income gives us a much broader measure of the equity reinvestment rate:
> 
> $\huge{ \text{Equity reinvestment rate} = \text{Equity reinvested}/\text{Net income} }$
> 
> Unlike the retention ratio, this number can be well in excess of 100 percent with the excess being funded with new equity. The expected growth in net income can then be written as:
> 
> $\huge{ \text{Expected growth in net income} = \text{Equity reinvestment rate} \times \text{Return on equity} }$
> 
> **Determinants of Return on Equity** Both earnings per share and net income growth are affected by the return on equity of a firm. The return on equity is affected by how much debt the firm chooses to use to fund its projects. In the broadest terms, increasing debt will lead to a higher return on equity if the after-tax return on capital exceeds the after-tax interest rate paid on debt. This is captured in the following formulation of return on equity:
> 
> $\huge{ ROE = { ROC + D/E[ROC − i(1 − t)] } }$
> 
> where, \
> $ROC = EBIT(1 -t)/(\text{BV of debt} + \text{BV of equity} - \text{Cash})$ \
> $D/E$ = BV of debt/BV of equity \
> $i$ = Interest expense on debt/BV of debt \
> $t$ = Tax rate on ordinary income
> 
> In keeping with the fact that return on equity is based on book value, all of the inputs are also stated in terms of book value. The derivation is simple and is provided in a footnote. Using this expanded version of ROE, the growth rate can be written as:
> 
> $\huge{ g = { b \times { ROC + D/E[ROC - i(1 - t)]} } }$
> 
> The advantage of this formulation is that is allows use to model changes in leverage and evaluate the effects on growth.
> 
> ...
> 
> **The Effects of Changing Return on Equity** So far, this section has operated on the assumption that the overall return on equity remains unchanged over time. If we relax this assumption, we introduce a new component to growth—the effect of changing return on equity on existing investments over time. Consider, for instance, a firm that has a book value of equity of $100 million and a return on equity of 10 percent. If this firm improves its return on equity to 11 percent, it will post an earnings growth rate of 10 percent even if it does not reinvest any money. This additional growth can be written as a function of the change in the return on equity:
> 
> $\huge{ \text{Addition to expected growth rate} = (ROE_t − ROE_{t–1})/ROE_{t–1} }$
> 
> where $ROE_t$ is the return on equity in period $t$. This will be in addition to the fundamental growth rate computed as the product of the return on equity and the retention ratio.
> 
> While increasing return on equity will generate a spurt in the growth rate in the period of the improvement, a decline in the return on equity will create a more than proportional drop in the growth rate in the period of the decline.
> 
> It is worth differentiating at this point between returns on equity on new investments and returns on equity on existing investments. The additional growth that we are estimating here comes not from new investments but by changing the return on existing investments. For lack of a better term, you could consider it “efficiency-generated growth.”
> 
> ...
> 
> **Growth in Operating Income**
> 
> Just as equity income growth is determined by the equity reinvested back into the business and the return made on that equity investment, you can relate growth in operating income to total reinvestment made into the firm and the return earned on capital invested.
> 
> We will consider three separate scenarios, and examine how to estimate growth in each, in this section. The first is when a firm is earning a high return on capital that it expects to sustain over time. The second is when a firm is earning a positive return on capital that is expected to increase over time. The third is the most general scenario, where a firm expects operating margins to change over time, sometimes from negative values to positive levels.
> 
> **Stable Return on Capital Scenario** When a firm has a stable return on capital, its expected growth in operating income is a product of the reinvestment rate (i.e., the proportion of the after-tax operating income that is invested in net capital expenditures and noncash working capital), and the quality of these reinvestments, measured as the return on the capital invested.
> 
> $\huge{ \text{Expected growth}_E = \text{Reinvestment rate} \times \text{Return on capital} }$
> 
> where,\
> $E$ = EBIT \
> reinvestment rate = $(\text{Capital expenditure} - \text{Depreciation} + \Delta \text{Noncash WC})/[EBIT(1 - \text{Tax rate})]$ \
> return on capital = $EBIT(1 -t)/(\text{Book value of Equity} + \text{Book value of debt} + \text{Cash and marketable securities})$
> 
> Both measures—the reinvestment rate and return on capital—should be forward looking, and the return on capital should represent the expected return on capital on future investments. In the rest of this section, we consider how best to estimate the reinvestment rate and the return on capital.
> 
> **Reinvestment Rate** The reinvestment rate measures how much a firm is plowing back to generate future growth. The reinvestment rate is often measured using the most recent financial statements for the firm. Although this is a good place to start, it is not necessarily the best estimate of the future reinvestment rate. A firm’s reinvestment rate can ebb and flow, especially in firms that invest in relatively few large projects or acquisitions. For these firms, looking at an average reinvestment rate over time may be a better measure of the future. In addition, as firms grow and mature, their reinvestment needs (and rates) tend to decrease. For firms that have expanded significantly over the last few years, the historical reinvestment rate is likely to be higher than the expected future reinvestment rate. For these firms, industry averages for reinvestment rates may provide a better indication of the future than using numbers from the past. Finally, it is important that we continue treating R&D expenses and operating lease expenses consistently. The R&D expenses, in particular, need to be categorized as part of capital expenditures for purposes of measuring the reinvestment rate.
> 
> **Return on Capital** The return on capital is often based on the firm’s return on capital on existing investments, where the book value of capital is assumed to measure the capital invested in these investments. Implicitly, we assume that the current accounting return on capital is a good measure of the true returns earned on existing investments, and that this return is a good proxy for returns that will be made on future investments. This assumption, of course, is open to question for the following reasons:
> 
> - The book value of capital might not be a good measure of the capital invested in existing investments, since it reflects the historical cost of these assets and accounting decisions on depreciation. When the book value understates the capital invested, the return on capital will be overstated; when book value overstates the capital invested, the return on capital will be understated. This problem is exacerbated if the book value of capital is not adjusted to reflect the value of the research asset or the capital value of operating leases.
> 
> - The operating income, like the book value of capital, is an accounting measure of the earnings made by a firm during a period.
> 
> - Even if the operating income and book value of capital are measured correctly, the return on capital on existing investments may not be equal to the marginal return on capital that the firm expects to make on new investments, especially as you go further into the future.
> 
> Given these concerns, we should consider not only a firm’s current return on capital, but any trends in this return as well as the industry average return on capital. If the current return on capital for a firm is significantly higher than the industry average, the forecasted return on capital should be set lower than the current return to reflect the erosion that is likely to occur as competition responds.
> 
> Finally, any firm that earns a return on capital greater than its cost of capital is earning an excess return. The excess returns are the result of a firm’s competitive advantages or barriers to entry into the industry. High excess returns locked in for very long periods imply that this firm has a permanent competitive advantage.
> 
> ...
> 
> **Positive and Changing Return on Capital Scenario** The analysis in the preceding section is based on the assumption that the return on capital remains stable over time. If the return on capital changes over time, the expected growth rate for the firm will have a second component, which will increase the growth rate if the return on capital increases and decrease the growth rate if the return on capital decreases.
> 
> $\huge{ \text{Expected growth rate} = { ROC_t \times \text{Reinvestment rate} + (ROC_t − ROC_{t−1})/ROC_t } }$
> 
> For example, a firm that sees its return on capital improve from 10 to 11 percent while maintaining a reinvestment rate of 40 percent will have an expected growth rate of:
> 
> Expected growth rate = .11 × .40 + (.11 − .10)/.10 = 14.40%
> 
> In effect, the improvement in the return on capital increases the earnings on existing assets and this improvement translates into an additional growth of 10 percent for the firm.
> 
> **Marginal and Average Returns on Capital** So far, we have looked at the return on capital as the measure that determines return. In reality, however, there are two measures of returns on capital. One is the return earned by firm collectively on all of its investments, which we define as the average return on capital. The other is the return earned by a firm on just the new investments it makes in a year, which is the marginal return on capital.
>
> Changes in the marginal return on capital do not create a second-order effect, and the expected growth is a product of the marginal return on capital and the reinvestment rate. Changes in the average return on capital, however, will result in the additional impact on growth chronicled earlier.
> 
> **Candidates for Changing Average Return on Capital** What types of firms are likely to see their return on capital change over time? One category includes firms with poor returns on capital that improve their operating efficiency and margins, and consequently their return on capital. In these firms, the expected growth rate will be much higher than the product of the reinvestment rate and the return on capital. In fact, since the return on capital on these firms is usually low before the turnaround, small changes in the return on capital translate into big changes in the growth rate. Thus, an increase in the return on capital on existing assets from 1 percent to 2 percent doubles the earnings (resulting in a growth rate of 100 percent).
> 
> Another category includes firms that have very high returns on capital on their existing investments but are likely to see these returns slip as competition enters the business, not only on new investments but also on existing investments.
> 
> ...
> 
> **Negative Return on Capital Scenario** The third and most difficult scenario for estimating growth is when a firm is losing money and has a negative return on capital. Since the firm is losing money, the reinvestment rate is also likely to be negative. To estimate growth in these firms, we have to move up the income statement and first project growth in revenues. Next, we use the firm’s expected operating margin in future years to estimate the operating income in those years. If the expected margin in future years is positive, the expected operating income will also turn positive, allowing us to apply traditional valuation approaches in valuing these firms. We also estimate how much the firm has to reinvest to generate revenue growth growth, by linking revenues to the capital invested in the firm.
> 
> **Growth in Revenues** Many high-growth firms, while reporting losses, also show large increases in revenues from period to period. The first step in forecasting cash flows is forecasting revenues in future years, usually by forecasting a growth rate in revenues each period. In making these estimates, there are five points to keep in mind.
> 
> 1. The rate of growth in revenues will decrease as the firm’s revenues increase. Thus, a tenfold increase in revenues is entirely feasible for a firm with revenues of $2 million but unlikely for a firm with revenues of $2 billion.
> 
> 2. Compounded growth rates in revenues over time can seem low, but appearances are deceptive. A compounded annual growth rate in revenues of 20 percent over ten years will increase revenues about six fold but an increase of 40 percent over 10 years will result in an almost 30-fold increase in revenues over the period.
> 
> 3. While growth rates in revenues may be the mechanism that you use to forecast future revenues, you do have to keep track of the dollar revenues to ensure that they are reasonable, given the size of the overall market that the firm operates in. If the projected revenues for a firm 10 years out would give it a 90 or 100 percent share (or greater) of the overall market in a competitive marketplace, you clearly should reassess the revenue growth rate.
> 
> 4. Assumptions about revenue growth and operating margins have to be internally consistent. Firms can post higher growth rates in revenues by adopting more aggressive pricing strategies but the higher revenue growth will then be accompanied by lower margins.
> 
> 5. In coming up with an estimate of revenue growth, you have to make a number of subjective judgments about the nature of competition, the capacity of the firm that you are valuing to handle the revenue growth and the marketing capabilities of the firm.
> 
> ...
> 
> **Operating Margin Forecasts** Before considering how to estimate the operating margins, let us begin with an assessment of where many high-growth firms, early in the life cycle, stand when the valuation begins. They usually have low revenues and negative operating margins. If revenue growth converts low revenues into high revenues and operating margins stay negative, these firms not only will be worth nothing but are unlikely to survive. For firms to be valuable, the higher revenues eventually have to deliver positive earnings. In a valuation model, this translates into positive operating margins in the future. A key input in valuing a high-growth firm then is the operating margin you would expect it to have as it matures.
> 
> In estimating this margin, you should begin by looking at the business that the firm is in. While many new firms claim to be pioneers in their businesses and some believe that they have no competitors, it is more likely that they are the first to find a new way of delivering a product or service that was previously delivered through other channels. Thus, Amazon.com might have been one of the first online retailers, but retailing was already an established business with hundreds of players. In fact, one can consider online retailers as logical successors to catalog retailers such as L.L. Bean and Lillian Vernon. Similarly, Yahoo! might have been one of the first Internet portals, but it was following the lead of newspapers that have used content and features to attract readers and used their readership to attract advertising. Using the average operating margin of competitors in the business may strike some as conservative. After all, they would point out, Amazon can hold less inventory and does not have the burden of carrying the operating leases that a brick and mortar retailer does (on its stores) and should, therefore, be more efficient about generating its revenues. This may be true, but it is unlikely that the operating margins for online retailers can be persistently higher than their brick-and-mortar counterparts. If they were, you would expect to see a migration of traditional retailers to online retailing and increased competition among online retailers on price and products, driving the margin down.
> 
> While the margin for the business in which a firm operates provides a target value, there are still two other estimation issues that you need to confront. Given that the operating margins in the early stages of the life cycle are negative, you first have to consider how the margin will improve from current levels to the target values. Generally, the improvements in margins will be greatest in the earlier years (at least in percentage terms) and then taper off as the firm approaches maturity. The second issue is one that is linked to revenue growth. Firms may be able to post higher revenue growth with lower margins but the trade-off has to be considered. While firms generally want both higher revenue growth and higher margin, the margin and revenue growth assumptions have to be consistent.
> 
> ...
> 
> **Qualitative Aspects of Growth**
> 
> The emphasis on quantitative elements—return on capital and reinvestment rates for profitable firms, and margins, revenue growth, and sales-to-capital ratios for unprofitable firms—may strike some as skewed. After all, growth is determined by a number of subjective factors—the quality of management, the strength of a firm’s marketing, its capacity to form partnerships with other firms, and the management’s strategic vision, among many others. Where, you might ask, is there room in the growth equations that have been presented in this chapter for these factors?
> 
> The answer is that qualitative factors matter, but that they all ultimately have to show up in one or more of the quantitative inputs that determine growth. Consider the following:
> 
> - The quality of management plays a significant role in the returns on capital that you assume firms can earn on their new investments and in how long they can sustain these returns. Thus, the fact that a firm has a well-regarded management team may be one reason why you allow a firm’s return on capital to remain well above the cost of capital.
> 
> - The marketing strengths of a firm and its choice of marketing strategy are reflected in the operating margins and turnover ratios that you assume for firms. Thus, it takes faith in a Coca-Cola’s capacity to market its products effectively to assume a high turnover ratio and a high target margin. In fact, you can consider various marketing strategies, which trade off lower margins for higher turnover ratios, and consider the implications for value. The brand name of a firm’s products and the strength of its distribution system also affect these estimates.
> 
> - Defining reinvestment broadly to include acquisitions, research and development, and investments in marketing and distribution allows you to consider different ways in which firms can grow. For some firms, reinvestment and growth come from acquisitions, while for other firms it may take the form of more traditional investments in plant and equipment. The effectiveness of these reinvestment strategies is captured in the return on capital that you assume for the future, with more effective firms having higher returns on capital.
> 
> - The strength of the competition that firms face is in the background but it does determine how high excess returns (return on capital less cost of capital) will be, and how quickly they fade toward zero.
> 
> Thus, qualitative factors are quantified and the growth implications are considered. If you cannot, you should remain skeptical about whether these factors truly affect value.
> 
> Why is it necessary to impose this quantitative structure on growth estimate? One of the biggest dangers in valuing technology firms is that story telling can be used to justify growth rates that are neither reasonable nor sustainable. Thus, you might be told that Tesla Motors will grow 100% a year because the “green” movement is strong or that Coca-Cola will grow 20 percent a year because it has a great brand name. While there is truth in these stories, a consideration of how these qualitative views translate into the quantitative elements of growth is an essential step toward consistent valuations.
> 
> Can different investors consider the same qualitative factors and come to different conclusions about the implications for returns on capital, margins, and reinvestment rates, and consequently, about growth? Absolutely. In fact, you would expect differences in opinion about the future and different estimates of value. The payoff to knowing a firm and the sector it operates in better than other investors is that your estimates of growth and value will be better than theirs. Unfortunately, this does not guarantee that your investment returns will be better than theirs.
> [^28]

#### Growth Patterns

> In general, when valuing a firm, you can assume that your firm is already in ***stable growth***, assume a period of constant high growth and then drop the growth rate to stable growth (***two-stage growth***), or allow for a transition phase to get to stable growth (***three-stage or n-stage models***). There are several factors you should consider in making this judgment:
> 
> **Growth Momentum** The choice of growth pattern will be influenced by the level of current growth in earnings and revenues. You can categorize firms, based on growth in recent periods, into three groups.
> 
> 1. Stable-growth firms report earnings and revenues growing at or below the nominal growth rate in the economy that they operate in. Note that this growth rate can even be negative.
> 2. Moderate-growth firms report earnings and revenues growing at a rate moderately higher than the nominal growth rate in the economy; as a rule of thumb, consider any growth rate within 8 to 10 percent of the growth rate of the economy as a moderate growth rate.
> 3. High-growth firms report earnings and revenues growing at a rate much higher than the nominal growth rate in the economy.
> 
> For firms growing at the stable rate, the steady state models that assume constant growth provide good estimates of value. For firms growing at a moderate rate, the two-stage discounted cash flow model should provide enough flexibility in terms of capturing changes in the underlying characteristics of the firm, while a three-stage or n-stage model may be needed to capture the longer transitions to stable growth that are inherent in high-growth-rate firms.
> 
> **Source of Growth (Barriers to Entry)** The higher expected growth for a firm can come from either general competitive advantages acquired over time such as a brand name or reduced costs of production (from economies of scale) or specific advantages that are the result of legal barriers to entry—licenses or product patents. The former are likely to erode over time as new competitors enter the marketplace, while the latter are more likely to disappear abruptly when the legal barriers to entry are removed. The expected growth rate for a firm that has specific sources of growth is likely to follow the two-stage process where growth is high for a certain period (for instance, the period of the patent) and drops abruptly to a stable rate after that. The expected growth rate for a firm that has general sources of growth is more likely to decline gradually over time as new competitors come in. The speed with which this competitive advantage is expected to be lost is a function of several factors, including:
> 
> - _Nature of the competitive advantage._ Some competitive advantages, such as brand name in consumer products, seem to be more difficult to overcome and consequently are likely to generate growth for longer periods. Other competitive advantages, such as a first-mover advantage, seem to erode much faster.
> 
> - _Competence of the firm’s management._ More competent management will be able to slow, though not stop, the loss of competitive advantage over time by creating strategies that find new markets in which to exploit the firm’s current competitive advantage and that attempt to find new sources of competitive advantage.
> 
> - _Ease of entry into the firm’s business._ The greater the barriers to industry in entering the firm’s business, because of either capital requirements or technological factors, the slower will be the loss of competitive advantage.
> 
> [^31]

> **Stable Growth Model**
> 
> In the liquidation value approach, you are assuming that your firm has a finite life and that it will be liquidated at the end of that life. Firms, however, can reinvest some of their cash flows back into new assets and extend their lives. If you assume that cash flows, beyond the terminal year, will grow at a constant rate forever, the terminal value can be estimated as follows:
> 
> $\huge{ \text{Terminal value}_t = { \text{Cash flow}_q/(r - \text{Stable growth}) } }$
> 
> where $q$ is $t + 1$ 
> 
> The cash flow and the discount rate used will depend on whether you are valuing the firm or valuing equity. If you are valuing equity, the terminal value of equity can be written as:
> 
> $\huge{ \text{Terminal value of equity}_n = \text{Cash flow to equity}_q/(\text{Cost of equity}_q = g_n) }$
> 
> where $q$ is $n + 1$
> 
> The cash flow to equity can be defined strictly as dividends (in the dividend discount model) or as free cash flow to equity. If valuing a firm, the terminal value can be written as:
> 
> $\huge{ \text{Terminal value}_n = \text{Free cash flow to firm}_q/(\text{Cost of capital}_q = g_n) }$
> 
> where $q$ is $n + 1$
> 
> where the cost of capital and the growth rate in the model are sustainable forever.
> 
> ...
> 
> **Constraints on Stable Growth** Of all the inputs into a discounted cash flow valuation model, none creates as much angst as estimating the stable growth rate. Part of the reason for it is that small changes in the stable growth rate can change the terminal value significantly, and the effect gets larger as the growth rate approaches the discount rate used in the estimation.
> 
> The fact that a stable growth rate is constant forever, however, puts strong constraints on how high it can be. Since no firm can grow forever at a rate higher than the growth rate of the economy in which it operates, the constant growth rate cannot be greater than the overall growth rate of the economy. In making a judgment on what the limits on a stable growth rate are, we have to consider the following three questions:
> 
> 1. _Is the company constrained to operate as a domestic company, or does it operate (or have the capacity to operate) multinationally?_ If a firm is a purely domestic company, either because of internal constraints (such as those imposed by management) or external constraints (such as those imposed by a government), the growth rate in the domestic economy will be the limiting value. If the company is a multinational or has aspirations to be one, the growth rate in the global economy (or at least those parts of the globe that the firm operates in) will be the limiting value.
> 
> 2. _Is the valuation being done in nominal or real terms?_ If the valuation is a nominal valuation, the stable growth rate should also be a nominal growth rate (i.e., include an expected inflation component). If the valuation is a real valuation, the stable growth rate will be constrained to be lower. Using a U.S. company in 2011 as an example, the stable growth rate can be as high as 2.0 percent if the valuation is done in nominal U.S. dollars but only 1 percent if the valuation is done in real terms.
> 
> 3. _What currency is being used to estimate cash flows and discount rates in the valuation?_ The limits on stable growth will vary depending on what currency is used in the valuation. If a high-inflation currency is used to estimate cash flows and discount rates, the stable growth rate will be much higher, since the expected inflation rate is added on to real growth. If a low-inflation currency is used to estimate cash flows, the stable growth rate will be much lower. For instance, the stable growth rate that would be used to value Cemex, the Mexican cement company, will be much higher if the valuation is done in Mexican pesos than in U.S. dollars.
> 
> Although the stable growth rate cannot exceed the growth rate of the economy in which a firm operates, it can be lower. There is nothing that prevents us from assuming that mature firms will become a smaller part of the economy and it may, in fact, be the more reasonable assumption to make. Note that the growth rate of an economy reflects the contributions of both young, higher-growth firms and mature, stable-growth firms. If the former grow at a rate much higher than the growth rate of the economy, the latter have to grow at a rate that is lower.
> 
> Setting the stable growth rate to be less than or equal to the growth rate of the economy not only is the consistent thing to do but it also ensures that the growth rate will be less than the discount rate. This is because there is a link between the riskless rate that goes into the discount rate and the growth rate of the economy. Note that the riskless rate can be written as:
> 
> $\huge{ \text{Nominal riskless rate} = \text{Real riskless rate} + \text{Expected inflation rate} }$
> 
> In the long term, the real riskless rate will converge on the real growth rate of the economy, and the nominal riskless rate will approach the nominal growth rate of the economy. In fact, a simple rule of thumb on the stable growth rate is that it generally should not exceed the riskless rate used in the valuation.
> 
> **Key Assumptions about Stable Growth** In every discounted cash flow valuation, there are three critical assumptions you need to make on stable growth. The first relates to when the firm that you are valuing will become a stable growth firm, if it is not one already. The second relates to what the characteristics of the firm will be in stable growth, in terms of return on investments and costs of equity and capital. The final assumption relates to how the firm that you are valuing will make the transition from high growth to stable growth.
> 
> ***Length of the High Growth Period*** The question of how long a firm will be able to sustain high growth is perhaps one of the more difficult questions to answer in a valuation, but two points are worth making. One is that it is not a question of whether but when firms hit the stable growth wall. All firms ultimately become stable growth firms, in the best case, because high growth makes a firm larger, and the firm’s size will eventually become a barrier to further high growth. In the worst-case scenario, firms do not survive and will be liquidated. The second is that high growth in valuation, or at least high growth that creates value, comes from firms earning excess returns on their marginal investments. In other words, increased value comes from firms having a return on capital that is higher than the cost of capital (or a return on equity that exceeds the cost of equity). Thus, when you assume that a firm will experience high growth for the next 5 or 10 years, you are also implicitly assuming that it will earn excess returns (over and above the required return) during that period. In a competitive market, these excess returns will eventually draw in new competitors, and the excess returns will disappear.
> 
> You should look at three factors when considering how long a firm will be able to maintain high growth.
> 
> 1. _Size of the firm._ Smaller firms are much more likely to earn excess returns and maintain these excess returns than otherwise similar larger firms. This is because they have more room to grow and a larger potential market. Small firms in large markets should have the potential for high growth (at least in revenues) over long periods. When looking at the size of the firm, you should look not only at its current market share, but also at the potential growth in the total market for its products or services. A firm may have a large market share of its current market, but it may be able to grow in spite of this because the entire market is growing rapidly.
> 
> 2. _Existing growth rate and excess returns._ Momentum does matter, when it comes to projecting growth. Firms that have been reporting rapidly growing revenues are more likely to see revenues grow rapidly at least in the near future. Firms that are earning high returns on capital and high excess returns in the current period are likely to sustain these excess returns for the next few years.
> 
> 3. _Magnitude and sustainability of competitive advantages._ This is perhaps the most critical determinant of the length of the high growth period. If there are significant barriers to entry and sustainable competitive advantages, firms can maintain high growth for longer periods. If, on the other hand, there are no or minor barriers to entry, or if the firm’s existing competitive advantages are fading, you should be far more conservative about allowing for long growth periods. The quality of existing management also influences growth. Some top managers have the capacity to make the strategic choices that increase competitive advantages and create new ones.
> 
> **Characteristics of Stable Growth Firm** As firms move from high growth to stable growth, you need to give them the characteristics of stable growth firms. A firm in stable growth is different from that same firm in high growth on a number of dimensions. In general, you would expect stable growth firms to have average risk, use more debt, have lower (or no) excess returns, and reinvest less than high growth firms. In this section, we will consider how best to adjust each of these variables.
> 
> ***Equity Risk*** When looking at the cost of equity, high growth firms tend to be more exposed to market risk (and have higher betas) than stable growth firms. Part of the reason for this is that they tend to be niche players supplying discretionary products, and part of the reason is high operating leverage. Thus, young technology or social media firms will have high betas. As these firms mature, you would expect them to have less exposure to market risk and betas that are closer to 1—the average for the market. One option is to set the beta in stable growth to 1 for all firms, arguing that firms in stable growth should all be average risk. Another is to allow for small differences to persist even in stable growth, with firms in more volatile businesses having higher betas than firms in stable businesses. We would recommend that, as a rule of thumb, stable period betas not exceed 1.2.
> 
> But what about firms that have betas well below 1, such as commodity companies? If you are assuming that these firms will stay in their existing businesses, there is no harm in assuming that the beta remains at existing levels. However, if your estimates of growth in perpetuity will require them to branch out into other businesses, you should adjust the beta upward toward 1; invoking another rule of thumb, stable period betas should not be lower than 8.
> 
> ***Project Returns*** High growth firms tend to have high returns on capital (and equity) and earn excess returns. In stable growth, it becomes much more difficult to sustain excess returns. There are some who believe that the only assumption consistent with stable growth is to assume no excess returns; the return on capital is set equal to the cost of capital. While, in principle, excess returns in perpetuity may not seem reasonable, it is difficult in practice to assume that firms will suddenly lose the capacity to earn excess returns at a point in time (say 5 years or 10 years). To provide a simple example, consider Proctor and Gamble, a company that we estimated a high growth period of 5 years for in illustration 12.1. While the growth rate for P&G may drop to a stable level by year 6, the strong brand name and other competitive advantages are likely to persist for much longer (say 30 to 40 years). Rather than estimate cash flows for 30 to 40 years, we would stop estimating cash flows in year 5 but still allow the company to continue earning more than its cost of capital in perpetuity. Since entire industries often earn excess returns over long periods, assuming a firm’s returns on equity and capital will move toward industry averages will yield more reasonable estimates of value.
> 
> ***Debt Ratios and Costs of Debt*** High growth firms tend to use less debt than stable growth firms. As firms mature, their debt capacity increases. When valuing firms, this will change the debt ratio that we use to compute the cost of capital. When valuing equity, changing the debt ratio will change both the cost of equity and the expected cash flows. The question of whether the debt ratio for a firm should be moved toward a more sustainable level in stable growth cannot be answered without looking at the incumbent managers’ views on debt, and how much power stockholders have in these firms. If managers are willing to change their financing policy, and stockholders retain some power, it is reasonable to assume that the debt ratio will move to a higher level in stable growth; if not, it is safer to leave the debt ratio at existing levels.
> 
> As earnings and cash flows increase, the perceived default risk in the firm will also change. A firm that is currently losing $10 million on revenues of $100 million may be rated B, but its rating should be much better if your forecasts of $10 billion in revenues and $1 billion in operating income come to fruition. In fact, internal consistency requires that you reestimate the rating and the cost of debt for a firm as you change its revenues and operating income. As a general rule, stable growth firms should have at least investment grade ratings (Baa or higher).
> 
> On the practical question of what debt ratio and cost of debt to use in stable growth, you should look at the financial leverage of larger and more mature firms in the industry. One solution is to use the industry average debt ratio and cost of debt as the debt ratio and cost of debt for the firm in stable growth.
> 
> 
> ***Reinvestment and Retention Ratios*** Stable growth firms tend to reinvest less than high growth firms, and it is critical that we capture the effects of lower growth on reinvestment and that we ensure that the firm reinvests enough to sustain its stable growth rate in the terminal phase. The actual adjustment will vary depending on whether we are discounting dividends, free cash flows to equity, or free cash flows to the firm.
> 
> In the dividend discount model, note that the expected growth rate in earnings per share can be written as a function of the retention ratio and the return on equity.
> 
> Expected growth rate = Retention ratio × Return on equity
> 
> Algebraic manipulation can allow us to state the retention ratio as a function of the expected growth rate and return on equity:
> 
> Retention ratio = Expected growth rate/Return on equity
> 
> If we assume, for instance, a stable growth rate of 3 percent (based on the growth rate of the economy) for Procter & Gamble (P&G) and a return on equity of 12 percent (based on industry averages), we would be able to compute the retention ratio of the firm in stable growth:
> 
> Retention ratio = 3%/12% = 25%
> 
> Procter & Gamble will have to retain 25 percent of its earnings to generate its expected growth of 3 percent; it can pay out the remaining 75 percent.
> 
> In a free cash flow to equity model, where we are focusing on net income growth, the expected growth rate is a function of the equity reinvestment rate and the return on equity:
> 
> Expected growth rate = Equity reinvestment rate × Return on equity
> 
> The equity reinvestment rate can then be computed as follows:
> 
> Equity reinvestment rate = Expected growth rate/Return on equity
> 
> If, for instance, we assume that Coca-Cola will have a stable growth rate of 3 percent and have a return on equity in stable growth of 15 percent, we can estimate an equity reinvestment rate of 20%; the remaining 80% can be paid out as cash flows to equity investors:
> 
> Equity reinvestment rate = 3%/15% = 20%
> 
> Finally, looking at free cash flows to the firm, we estimated the expected growth in operating income as a function of the return on capital (ROC) in stable growth and the reinvestment rate:
> 
> Expected growth rate = Reinvestment rate × Return on capital
> 
> Again, algebraic manipulation yields the following measure of the reinvestment rate in stable growth:
> 
> ${ \text{Reinvestment rate in stable growth} = \text{Stable growth rate}/ROC_n }$
> 
> where $ROC_n$ is the return on capital that the firm can sustain in stable growth. This reinvestment rate can then be used to generate the free cash flow to the firm in the first year of stable growth.
> 
> Linking the reinvestment rate and retention ratio to the stable growth rate also makes the valuation less sensitive to assumptions about the stable growth rate. Whereas increasing the stable growth rate, holding all else constant, can dramatically increase value, changing the reinvestment rate as the growth rate changes will create an offsetting effect. The gains from increasing the growth rate will be partially or completely offset by the loss in cash flows because of the higher reinvestment rate. Whether value increases or decreases as the stable growth increases will entirely depend on what you assume about excess returns. If the return on capital is higher than the cost of capital in the stable growth period, increasing the stable growth rate will increase value. _If the return on capital is equal to the stable growth rate, increasing the stable growth rate will have no effect on value._ This can be proved quite easily:
> 
> $\huge{ \text{Terminal value} = { EBIT_{n+1}(1 − t)(1 − \text{Reinvestment rate}) \over { \text{Cost of capital}_n − \text{Stable growth rate} } } }$
> 
> Substituting in the stable growth rate as a function of the reinvestment rate, from the equation, you get:
> 
> $\huge{ \text{Terminal value} = { EBIT_{n+1}(1 − t)(1 − \text{Reinvestment rate}) \over { \text{Cost of capital}_n − ( \text{Reinvestment rate} \times \text{Return on capital} ) } } }$
> 
> Setting the return on capital equal to the cost of capital, you arrive at:
> 
> $\huge{ \text{Terminal value} = { EBIT_{n+1}(1 − t)(1 − \text{Reinvestment rate}) \over { \text{Cost of capital}_n − ( \text{Reinvestment rate} \times \text{Cost of capital} ) } } }$
> 
> ...
> 
> Put simply, when there are no excess returns, your terminal value is unaffected by your assumptions about expected growth. You could establish the same proposition with equity income and cash flows, and show that a return on equity equal to the cost of equity in stable growth nullifies the positive effect of growth.
> 
> ***Transition to Stable Growth*** Once you have decided that a firm will be in stable growth at a point in time in the future, you have to consider how the firm will change as it approaches stable growth. There are three distinct scenarios. In the first, the firm will maintain its high growth rate for a period of time and then become a stable growth firm abruptly; this is a two-stage model. In the second, the firm will maintain its high growth rate for a period and then have a transition period when its characteristics change gradually toward stable growth levels; this is a three-stage model. In the third, the firm’s characteristics change each year from the initial period to the stable growth period; this can be considered an n-stage model.
> 
> Which of these three scenarios gets chosen depends on the firm being valued. Since the firm goes from high growth to stable growth in one year in the two-stage model, this model is more appropriate for firms with moderate growth rates, where the shift will not be too dramatic. For firms with very high growth rates in operating income, a transition phase allows for a gradual adjustment not just of growth rates but also of risk characteristics, returns on capital and reinvestment rates toward stable growth levels. For very young firms or for firms with negative operating margins, allowing for changes in each year (in an n-stage model) is prudent.
> 
> ...
> 
> **EXTRAORDINARY GROWTH PERIODS WITHOUT A HIGH GROWTH RATE OR A NEGATIVE GROWTH RATE**
> 
> Can you have extraordinary growth periods for firms that have expected growth rates that are less than or equal to the growth rate of the economy? The answer is yes, for some firms. This is because stable growth requires not just that the growth rate be less than the growth rate of the economy, but that the other inputs into the valuation are also appropriate for a stable growth firm. Consider, for instance, a firm whose operating income is growing at 2 percent a year but whose current return on capital is 20 percent and whose beta is 1.5. You would still need a transition period in which the return on capital declined to more sustainable levels (say 12 percent) and the beta moved toward 1.
> 
> By the same token, you can have an extraordinary growth period, where the growth rate is less than the stable growth rate and then moves up to the stable growth rate. For instance, you could have a firm that is expected to see its earnings decline 5 percent a year for the next five years (which would be the extraordinary growth period) and grow 2 percent thereafter.
> 
> ...
> 
> ...
> 
> The value of a firm is the present value of its expected cash flows over its life. Since firms have infinite lives, you apply closure to a valuation by estimating cash flows for a period and then estimating a value for the firm at the end of the period—a terminal value. Many analysts estimate the terminal value using a multiple of earnings or revenues in the final estimation year. If you assume that firms have infinite lives, an approach that is more consistent with discounted cash flow valuation is to assume that the cash flows of the firm will grow at a constant rate forever beyond a point in time. When the firm that you are valuing will approach this growth rate, which you label a stable growth rate, is a key part of any discounted cash flow valuation. Small firms that are growing fast and have significant competitive advantages should be able to grow at high rates for much longer periods than larger and more mature firms, without these competitive advantages. If you do not want to assume an infinite life for a firm, you can estimate a liquidation value based on what others will pay for the assets that the firm has accumulated during the high-growth phase.[^32]

#### Earnings

> In the context of discounted cash flow valuation, cash flows to equity can be discounted at the cost of equity to arrive at a value of equity, or cash flows to the firm can be discounted at the cost of capital to arrive at the value for the firm. The cash flows to equity themselves can be defined in the strictest sense as dividends or in a more expansive sense as free cash flows to equity. These models can be further categorized on the basis of assumptions about growth into stable-growth, two-stage, three-stage and n-stage models. Finally, the measurement of earnings and cash flows may be modified to match the special characteristics of the firm/asset—current earnings for firms/assets that have normal earnings, or normalized earnings for firms/assets whose current earnings may be distorted either by temporary factors or cyclical effects.
> 
> ...
> 
> 
> Most valuations begin with the current financial statements of the firm and use the reported earnings in those statements as the base for projections. There are some firms, though, where you may not be able to do this, either because the firm’s earnings are negative or because these earnings are abnormally high or low (a firm’s earnings are abnormal if they do not fit in with the firm’s own history of earnings).
> 
> When earnings are negative or abnormal, you can sometimes replace current earnings with a normalized value, estimated by looking at the company’s history or industry averages, and value the firm based on these normalized earnings. This is the easiest route to follow if the causes for the negative or abnormal earnings are temporary or transitory, as in the following cases:
> 
> - A cyclical firm will generally report depressed earnings during an economic downturn and high earnings during an economic boom. Neither may capture properly the true earnings potential of the firm.
> 
> - A firm may report abnormally low earnings in a period during which it takes an extraordinary charge.
> 
> - A firm in the process of restructuring may report low earnings during the restructuring period as the changes made to improve firm performance are put into effect.
> 
> The presumption here is that earnings will quickly bounce back to normal levels and that little will be lost by assuming that this will occur immediately.
> 
> For some firms, though, the negative or low earnings may reflect factors that are unlikely to disappear quickly. There are at least three groups of firms where the negative earnings are likely to be a long-term phenomenon and may even threaten the firm’s survival:
> 
> 1. _Firms with long-term operating, strategic, or financial problems_ can have extended periods of negative or low earnings. If you replace current earnings with normalized earnings and value these firms, you will overvalue them.
>    - If a firm seems to be in imminent danger of default, the only models that are likely to provide meaningful measures of value are the option pricing model (if financial leverage is high) or a model based on liquidation value.
>    - If the firm is troubled but unlikely to go bankrupt, you will have to nurse it back to financial health. In practical terms, you will have to adjust the operating margins over time to healthier levels and value the firm based on its expected cash flows.
> 
> 2. _An infrastructure firm_ may report negative earnings in its initial periods of growth, not because it is unhealthy but because the investments it has made take time to pay off. The cash flows to the firm and equity are often also negative, because the capital expenditure needs for this type of firm tend to be disproportionately large relative to depreciation. For these firms to have value, capital expenditure has to drop once the infrastructure investments have been made and operating margins have to improve. The net result will be positive cash flows in future years and a value for the firm today.
> 
> 3. _Young start-up companies_ often report negative earnings early in their life cycles, as they concentrate on turning interesting ideas into commercial products. To value such companies, you have to assume a combination of high revenue growth and improving operating margins over time.
> 
> [^31]

##### Current

> Since income can be generated from a number of different sources, generally accepted accounting principles (GAAP) require that income statements be classified into four sections—income from continuing operations, income from discontinued operations, extraordinary gains or losses, and adjustments for changes in accounting principles.
> 
> Generally accepted accounting principles require the recognition of revenues when the service for which the firm is getting paid has been performed in full or substantially, and the firm has received in return either cash or a receivable that is both observable and measurable. Expenses linked directly to the production of revenues (like labor and materials) are recognized in the same period in which revenues are recognized. Any expenses that are not directly linked to the production of revenues are recognized in the period in which the firm consumes the services. Accounting has resolved one inconsistency that bedeviled it for years, with a change in the way it treats employee options. Unlike the old rules, these option grants were not treated as expenses when granted but only when exercised, the new rules require that employee options be valued and expensed, when granted (with allowances for amortization over periods). Since employee options are part of compensation, which is an operating expense, the new rules make more sense.
> 
> While accrual accounting is straightforward in firms that produce goods and sell them, there are special cases where accrual accounting can be complicated by the nature of the product or service being offered. For instance, firms that enter into long-term contracts with their customers are allowed to recognize revenue on the basis of the percentage of the contract that is completed. As the revenue is recognized on a percentage-of-completion basis, a corresponding proportion of the expense is also recognized. When there is considerable uncertainty about the capacity of the buyer of a good or service to pay for it, the firm providing the good or service may recognize the income only when it collects portions of the selling price under the installment method.
> 
> Reverting back to the discussion of the difference between capital and operating expenses, operating expenses should reflect only those expenses that create revenues in the current period. In practice, however, a number of expenses are classified as operating expenses that do not seem to meet this test. The first is depreciation and amortization. While the notion that capital expenditures should be written off over multiple periods is reasonable, the accounting depreciation that is computed on the original historical cost often bears little resemblance to the actual economic depreciation. The second expense is research and development expenses, which accounting standards classify as operating expenses, but which clearly provide benefits over multiple periods. The rationale used for this classification is that the benefits cannot be counted on or easily quantified.
> 
> Much of financial analysis is built around the expected future earnings of a firm, and many of these forecasts start with the current earnings. It is therefore important to know how much of these earnings comes from the ongoing operations of the firm and how much can be attributed to unusual or extraordinary events that are unlikely to recur on a regular basis. From that standpoint, it is useful that firms categorize expenses into operating and nonrecurring expenses, since it is the earnings prior to extraordinary items that should be used in forecasting. Nonrecurring items include:
> 
> - _Unusual or infrequent items_, such as gains or losses from the divestiture of an asset or division, and write-offs or restructuring costs. Companies sometimes include such items as part of operating expenses. As an example, Boeing in 1997 took a write-off of $1,400 million to adjust the value of assets it acquired in its acquisition of McDonnell Douglas, and it showed this as part of operating expenses.
> 
> - _Extraordinary items_, which are defined as events that are unusual in nature, infrequent in occurrence, and material in impact. Examples include the accounting gain associated with refinancing high-coupon debt with lower-coupon debt, and gains or losses from marketable securities that are held by the firm.
> 
> - _Losses associated with discontinued operations_, which measure both the loss from the phaseout period and any estimated loss on sale of the operations. To qualify, however, the operations have to be separable from the firm.
> 
> - _Gains or losses associated with accounting changes_, which measure earnings changes created by both accounting changes made voluntarily by the firm (such as a change in inventory valuation) and accounting changes mandated by new accounting standards.
> 
> [^32]

##### Normalized

> A firm with negative earnings or abnormally low earnings is more difficult to value than a firm with positive earnings. ...
> 
> **Consequences of Negative or Abnormally Low Earnings**
> 
> Firms that are losing money currently create several problems for the analysts who are attempting to value them. While none of these problems are conceptual, they are significant from a measurement standpoint:
> 
> 1. _Earnings growth rates cannot be estimated or used in valuation._ The first and most obvious problem is that we can no longer estimate an expected growth rate to earnings and apply it to _current earnings_ to estimate future earnings. When _current earnings_ are negative, applying a growth rate will just make it more negative. In fact, even estimating an earnings growth rate becomes problematic, whether one uses historical growth, analyst projections, or fundamentals. ...
> 
> 2. _Tax computation becomes more complicated._ The standard approach to estimating taxes is to apply the marginal tax rate on the pretax operating income to arrive at the after-tax operating income:
> 
>    After-tax operating income = Pretax operating income(1 – Tax rate)
> 
>    This computation assumes that earnings create tax liabilities in the current period. While this is generally true, firms that are losing money can carry these losses forward in time and apply them to earnings in future periods. Thus analysts valuing firms with negative earnings have to keep track of the net operating losses of these firms and remember to use them to shield income in future periods from taxes.
> 
> The going concern assumption may not apply. The final problem associated with valuing companies that have negative earnings is the very real possibility that these firms will go bankrupt if earnings stay negative, and that the assumption of infinite lives that underlies the estimation of terminal value may not apply in these cases.
> 
> **Causes of Negative Earnings**
> 
> There are several reasons why firms have negative or abnormally low earnings, some of which can be viewed as temporary, some of which are long-term, and some of which relate to where a firm stands in the life cycle.
> 
> ***Temporary Problems*** For some firms, negative earnings are the result of temporary problems, sometimes affecting the firm alone, sometimes affecting an entire industry, and sometimes the result of a downturn in the economy.
> 
> - Firm-specific reasons for negative earnings can include a strike by the firm’s employees, an expensive product recall, or a large judgment against the firm in a lawsuit. While these will undoubtedly lower earnings, the effect is likely to be one-time and not affect future earnings.
> 
> - Sectorwide reasons for negative earnings can include a downturn in the price of a commodity for a firm that produces that commodity. It is common, for instance, for paper and pulp firms to go through cycles of high paper prices (and profits) followed by low paper prices (and losses). In some cases, the negative earnings may arise from the interruption of a common source of supply for a necessary raw material or a spike in its price. For instance, an increase in oil prices will negatively affect the profits of all airlines.
> 
> - For cyclical firms, a recession will affect revenues and earnings. It is not surprising, therefore, that automobile companies report low or negative earnings during bad economic times.
> 
> The common thread for all of these firms is that we expect earnings to recover sooner rather than later as the problem dissipates. Thus we would expect a cyclical firm’s earnings to bounce back once the economy revives and an airline’s profits to improve once oil prices level off.
> 
> ***Long-Term Problems*** Negative earnings are sometimes reflections of deeper and much more long-term problems in a firm. Some of these are the results of poor strategic choices made in the past, some reflect operational inefficiencies, and some are purely financial, the result of a firm borrowing much more than it can support with its existing cash flows.
> 
> - A firm’s earnings may be negative because its strategic choices in terms of product mix or marketing policy might have backfired. For such a firm, financial health is generally not around the corner and will require a substantial makeover and, often, new management.
> 
> - A firm can have negative earnings because of inefficient operations. For instance, the firm’s plant and equipment may be obsolete or its workforce may be poorly trained. The negative earnings may also reflect poor decisions made in the past by management and the continuing costs associated with such decisions. For instance, firms that have gone on acquisition binges and overpaid on a series of acquisitions may face several years of poor earnings as a consequence.
> 
> - In some cases, a firm that is in generally good health operationally can end up with negative equity earnings because it has chosen to use too much debt to fund its operations.
> 
> ***Life Cycle*** In some cases, a firm’s negative earnings may not be the result of problems in the way it is run but because of where the firm is in its life cycle. Here are three examples:
> 
> 1. Firms in businesses that require huge infrastructure investments up front will often lose money until these investments are in place. Once they are made and the firm is able to generate revenues, the earnings will turn positive. You can argue that this was the case with the phone companies in the early part of the twentieth century in the United States, the cable companies in the 1980s, and the cellular companies in the early 1990s.
> 
> 2. Small biotechnology or pharmaceutical firms often spend millions of dollars on research, come up with promising products that they patent, but then have to wait years for Food and Drug Administration (FDA) approval to sell the drugs. In the meantime, they continue to have research and development expenses and report large losses.
> 
> 3. The third group includes young start-up companies. Often these companies have interesting and potentially profitable ideas, but they lose money until they convert these ideas into commercial products. Until the late 1990s, these companies seldom went public but relied instead on venture capital financing for their equity needs. One of the striking features of the boom in new technology companies in recent years has been the number of such firms that have chosen to bypass or shorten the venture capital route and go to the markets directly.
> 
> ...
> 
> **Firms with Temporary Problems**
> 
> When earnings are negative because of temporary or short-term problems, the expectation is that earnings will recover in the near term. Thus, the solutions we devise will be fairly simple ones, which for the most part will ***replace the current earnings (which are negative) with normalized earnings (which will be positive)***. How we normalize earnings will vary depending on the nature of the problem.
> 
> ***Firm-Specific Problems*** A firm can have a bad year in terms of earnings, but the problems may be isolated to that firm, and be short-term in nature. If the loss can be attributed to a specific event—a strike or a lawsuit judgment, for instance—and the accounting statements report the cost associated with the event, the solution is fairly simple. You should estimate the earnings prior to these costs and use these earnings not only for estimating cash flows but also for computing fundamentals such as return on capital. In making these estimates, though, note that you should remove not just the expense but all of the tax benefits created by the expense as well, assuming that it is tax deductible.
> 
> If the cause of the loss is more diffuse or if the cost of the event causing the loss is not separated out from other expenses, you face a tougher task. First, you have to ensure that the loss is in fact temporary and not the symptom of long-term problems at the firm. Next, you have to estimate the normal earnings of the firm. The simplest and most direct way of doing this is to compare each expense item for the firm for the current year with the same item in previous years, scaled to revenues. Any item that looks abnormally high, relative to prior years, should be normalized (by using an average from previous years). Alternatively, you could apply the operating margin that the firm earned in prior years to the current year’s revenues and estimate an operating income to use in the valuation.
> 
> In general, you will have to consider making adjustments to the earnings of firms after years in which they have made major acquisitions, since the accounting statements in these years will be skewed by large items that are generally nonrecurring and related to the acquisition.
> 
> ***Sectorwide or Market-Driven Problems*** The earnings of cyclical firms are, by definition, volatile and depend on the state of the economy. In economic booms the earnings of these firms are likely to increase, while in recessions the earnings will be depressed. The same can be said of commodity firms that go through price cycles, where periods of high prices for the commodity are often followed by low prices. In both cases, you can get misleading estimates of value if you use the current year’s earnings as your base year earnings.
> 
> ***Valuing Cyclical Firms*** Cyclical firm valuations can be significantly affected by the level of base year earnings. There are two potential solutions: One is to adjust the expected growth rate in the near periods to reflect cyclical changes, and the other is to value the firm based on normalized rather than current earnings.
> 
> **Adjust Expected Growth** Cyclical firms often report low earnings at the bottom of an economic cycle, but the earnings recover quickly when the economy recovers. One solution, if earnings are not negative, is to adjust the expected growth rate in earnings, especially in the near term, to reflect expected changes in the economic cycle. This would imply using a higher growth rate in the next year or two, if both the firm’s earnings and the economy are depressed currently but are expected to recover quickly. The strategy would be reversed if the current earnings are inflated (because of an economic boom), and if the economy is expected to slow down. The disadvantage of this approach is that it ties the accuracy of the estimate of value for a cyclical firm to the precision of the macroeconomic predictions of the analyst doing the valuation. The criticism, though, may not be avoidable since it is difficult to value a cyclical firm without making assumptions about future economic growth. The actual growth rate in earnings in turning-point years (years when the economy goes into or comes out of a recession) can be estimated by looking at the experience of this firm (or similar firms) in prior recessions.
> 
> ...
> 
> **Normalize Earnings** For cyclical firms, the easiest solution to the problem of volatile earnings over time and negative earnings in the base period, is to normalize earnings. When normalizing earnings for a firm with negative earnings, we are simply trying to answer the question: “What would this firm earn in a normal year?” Implicit in this statement is the assumption that the current year is not a normal year and earnings will recover quickly to normal levels. This approach, therefore, is most appropriate for cyclical firms in mature businesses. There are a number of ways in which earnings can be normalized:
> 
> - _Average the firm’s dollar earnings over prior periods._ The simplest way to normalize earnings is to use the average earnings over prior periods. How many periods should you go back in time? For cyclical firms, you should go back long enough to cover an entire economic cycle—between 5 and 10 years. While this approach is simple, it is best suited for firms that have not changed in scale (or size) over the period. ***If it is applied to a firm that has become larger or smaller (in terms of the number of units it sells or total revenues) over time, it will result in a normalized estimate that is incorrect.***
> 
> - _Average the firm’s return on investment or profit margins over prior periods._ This approach is similar to the first one, but the averaging is done on scaled earnings (operating margins or return on capital) instead of dollar earnings. The advantage of the approach is that it allows the normalized earnings estimate to reflect the current size of the firm. Thus a firm with an average return on capital of 12 percent over prior periods and a current capital invested of $1,000 million would have normalized operating income of $120 million. Using average return on equity and book value of equity yields normalized net income. A close variant of this approach is to estimate the average operating or net margin in prior periods and apply this margin to current revenues to arrive at normalized operating or net income. The advantage of working with revenues is that they are less susceptible to accounting manipulation.
> 
> There is one final question that we have to deal with when normalizing earnings, and it relates to when earnings will be normalized. Replacing current earnings with normalized earnings essentially is equivalent to assuming that normalization will occur instantaneously (i.e., in the very first time period of the valuation). If earnings will not return to normalized levels for several periods, the value obtained by normalizing current earnings will be too high. A simple correction that can be applied is to discount the value back by the number of periods it will take to normalize earnings.
> 
> ...
> 
> **Valuing Commodity and Natural Resource Firms** Commodity prices are not only volatile but go through cycles—periods of high prices followed by periods with lower prices.
> 
> Some natural resource companies smooth out their earnings using futures and options contracts, but many let the price changes flow through into their bottom lines. As a consequence, the earnings of commodity companies tend to move up and down with commodity prices. To value natural resource companies—and that group would include not just oil and mining firms but also forest product firms (such as timber) and agricultural businesses—you have three choices:
> 
> 1. One is to try to forecast future commodity prices—the commodity price cycle—and build these forecasts into expected revenues in future years. This may be difficult to do since the cycles are unpredictable. However, you could use prices from the futures market as your forecasted prices.
> 
> 2. You could value the firms using a normalized commodity price, estimated by looking at the average price of the commodity over a cycle. Thus, the average price of coffee over the past decade can be used to estimate the value of a coffee plantation. The danger, of course, is that the price of coffee may stay well above or below this average price for an extended period, throwing off estimates of value.
> 
> 3. You could value the firm’s current production using the current price for the commodity, even if it is at historic lows, and add to it the value of the option that the company possesses, which is to produce more if prices go up and less if they go down.
> 
> ...
> 
> **Firms with Long-Term Problems**
> 
> ...
> 
> **Strategic Problems** Firms can sometimes make mistakes in terms of the product mixes they offer, the marketing strategies they adopt, or even the markets that they choose to target. They often end up paying a substantial cost in terms of negative or lower earnings and perhaps a permanent loss of market share. Consider the following examples:
> 
> - IBM found its dominant position in the mainframe computer business and the extraordinary profitability of that business challenged by the explosion of the personal computer market in the 1980s. While IBM could have developed the operating system for personal computers early in the process, it ceded that business to an upstart called Microsoft. By 1989, IBM had lost more than half its market value and its return on equity had dropped into the single digits.
> 
> - For decades, Xerox dominated the copier business to the extent that its name became synonymous with the product. In the 1970s and 1980s it was challenged for the market by Asian firms with lower cost structures, like Ricoh and Canon. After initial losses Xerox was able to recoup some of its market share. However, the last part of the 1990s saw a steady decline in Xerox’s fortunes as technology (in the form of e-mails, faxes, and low-cost printers) took its toll. By the end of 2000, there were questions about whether Xerox had a future.
> 
>  - Under the leadership of Michael Armstrong, AT&T tried to shed its image as a stodgy phone company and become a technology firm. After some initial successes, a series of miscues and poor acquisitions saw the firm enter the new millennium with a vastly reduced market capitalization and no clear vision on where to go next.
> 
> When firms have low or negative earnings that can be traced to strategic missteps, you have to determine whether the shift is a permanent one. If it is, you will have to value the firm on the assumption that it will never recover lost ground, and scale down your expectations of revenue growth and expected margins. If, on the other hand, you are more optimistic about the firm’s recovery or its entry into new markets, you can assume that the firm will be able to revert to its traditional margins and high growth.
> 
> **Operating Problems** Firms that are less efficient in the delivery of goods and services than their competitors will also be less profitable and less valuable. But how and why do firms become less efficient? In some cases, the reasons can be traced to a failure to keep up with the times and replenish assets and keep up with the latest technology. A steel company whose factories are decades old and whose equipment is outdated will generally bear higher costs for every ton of steel that it produces than its newer competitors. In other cases, the problem may be labor costs. A steel company with plants in the United States faces much higher labor costs than a similar company in Asia.
> 
> The variable that best measures operating efficiency is the operating margin, with firms that have operating problems tending to have much lower margins than their competitors. One way to build in the effect of operating improvements over time is to increase the margin toward the industry average, but the speed with which the margins will converge will depend on several factors:
> 
> - _Size of the firm._ Generally, the larger the firm, the longer it will take to eliminate inefficiencies. Not only is inertia a much stronger force in large firms, but the absolute magnitude of the changes that have to be made are much larger. A firm with $10 billion in revenues will have to cut costs by $300 million to achieve a 3 percent improvement in pretax operating margin, whereas a firm with $100 million in revenues will have to cut costs by $3 million to accomplish the same objective.
> 
> - _Nature of the inefficiency._ Some inefficiencies can be fixed far more quickly than others. For instance, a firm can replace outdated equipment or a poor inventory system quickly, but retraining a labor force will take much more time.
> 
> - _External constraints._ Firms are often restricted in terms of how much and how quickly they can move to fix inefficiencies by contractual obligations and social pressure. For instance, laying off a large portion of the workforce may seem an obvious solution for a firm that is overstaffed, but union contracts and the potential for negative publicity may make firms reluctant to do so.
> 
> - _Management quality._ A management that is committed to change is a critical component of a successful turnaround. In some cases, a replacement of top management may be necessary for a firm to be able to resolve its operating problems.
> 
> ...
> 
> **The Special Case of Privatizations** In many privatizations, we are called on to value firms with long financial histories but not very profitable ones. The lack of profitability is not surprising, since many of these firms have been run with objectives other than maximizing value or profitability. In some cases, employment in these firms has been viewed as a source of political patronage. Consequently, they end up overstaffed and inefficient.
> 
> Will this all change as soon as they are privatized? Not necessarily, and certainly not immediately. The power of unions to preserve existing jobs, the power that governments continue to have on how they are run, and the sheer size of these firms makes change both daunting and slow. While it is reasonable to assume that these firms will, in fact, become more efficient once they are privatized, the speed of the improvement will vary from firm to firm. In general, you would expect the adjustment to be much quicker if the government relinquishes its power to control the management of the firm and if there are strong competitive pressures to become more efficient. It will be slower if the firm is a monopoly and the government continues to handpick the top management of the firm.
> 
> **Financial Leverage** In some cases firms get into trouble because they borrow too much and not because of operating or strategic problems. In these cases, it will be the equity earnings that will be negative while operating earnings will be positive. The solution to the problem depends, in large part, on how distressed the firm really is. If the distress is not expected to push the firm into bankruptcy, there are a variety of potential solutions. If, however, the distress could be terminal, finding a solution is much more difficult.
> 
> ***Overlevered with No Immediate Threat of Bankruptcy*** Firms that borrow too much are not always on the verge of bankruptcy. In fact, firms with valuable operating assets and substantial operating cash flows can service much more debt than is optimal for them, even though they might not do so comfortably. So, what are the costs of being overlevered? First, the firm might end up with a large enough exposure to default risk that it affects its operations—customers might not buy its products, suppliers might demand speedier payment, and it might have trouble retaining valued employees. Second, the higher beta and cost of debt that go with the higher leverage will increase the firm’s cost of capital and reduce its value. It is therefore in the best interests of the firm to reduce its debt ratio, if not immediately, at least over time.
> 
> There are two choices when it comes to valuing levered firms as going concerns:
> 
> 1. You can estimate free cash flows to the firm and value the firm. If the firm is operationally healthy (the operating margins are both positive and similar to those of comparable firms), the only modification you have to make is to reduce the debt ratio over time—in practical terms, a disproportionate share of the reinvestment each year has to come from equity—and compute costs of capital that change with the debt ratio. If the firm’s operating margins have suffered because it borrowed too much, you might need to adjust the operating margins over time toward industry averages as well.
> 
> 2. You can use the adjusted present value approach and value the firm as an unlevered firm, and add to this unlevered firm value the costs (expected bankruptcy costs) and benefits (tax benefits) of debt. ..., estimating the expected bankruptcy cost can be difficult to do.
> 
> ...
> 
> ***Overlevered with High Probability of Bankruptcy*** Discounted cash flow valuation is conditioned on a firm being a going concern, with cash flows continuing into the future. When a firm’s financial problems are severe enough to suggest a strong likelihood of bankruptcy, two other approaches may need to be used to value a firm and the equity claim in it. One is to estimate a liquidation value for the assets today, and the other is to value the company on the assumption that it stays a going concern and then adjust that value for the likelihood and consequences of distress.
> 
> _Liquidation Value_ The liquidation value of a firm is the aggregate of the value that the assets of the firm would command on the market, net of transactions and legal costs. The value of equity can be obtained by subtracting the value of the outstanding debt from the asset value.
> 
> Value of equity = Liquidation value of assets – Outstanding debt
> 
> Estimating liquidation value is complicated when the assets of the firm are not easily separated and thus cannot be valued individually. Furthermore, the likelihood that assets will fetch their fair market value will decrease as the urgency of the liquidation increases. A firm in a hurry to liquidate its assets may have to accept a discount on fair market value as a price for speedy execution.
> 
> As a note of caution, it is almost never appropriate to treat the book value of the assets as the liquidation value. Most distressed firms earn subpar returns on their assets, and the liquidation value will reflect the earning capacity of the assets rather than the original capital invested in the assets (which is what the book value measures, net of depreciation).
> 
> **Distress-Adjusted DCF**
> 
> Discounted cash flow valuation will yield too high a value for a firm where there is a significant likelihood of distress or default, because we assume that the firm will survive as a going concern. One way of counteracting this bias is to first value the firm using a DCF approach, assuming that it makes it back to financial health and profitability. We then follow this up by estimating two inputs:
> 
> 1. _The probability that the firm will not make it as a going concern_ (i.e., the probability of default). ...[See book for details]...
> 
> 2. _The value that the firm will be able to get for its assets in the event of default._ In effect, we are using the techniques for estimating liquidation value .... Netting out the debt outstanding should yield a value for equity in default. (In most cases, the equity investors will get nothing.)
> 
> Once these numbers have been estimated, the value for the equity in the firm today can be written as a probability weighted average of the going concern value and the distress value:
>
> Value of equity today = Value of equity in going concern (1 – Probability of default) + Value of equity in default (Probability of default)
> 
> ...
> 
> Life Cycle Earnings As noted earlier in the chapter, it is normal for firms to lose money at certain stages in their life cycles. When valuing such firms, you cannot normalize earnings, as we did with cyclical firms or firms with temporary problems. Instead, you have to estimate the cash flows of the firm over its life cycle, and let them turn positive at the right stage of the cycle. There are three groups of companies where this issue is central to valuation: companies that make large infrastructure investments with long lives, young biotechnology companies that derive their value primarily from a patent or patents and start up companies.
> 
> ***Infrastructure Firms*** If the business that a firm is in requires large infrastructure investments early in the life cycle and the firm has to wait for a long period before it can generate earnings, it is entirely possible that the firm will report large losses in the initial periods when the investments are made. In fact, as an added complication, many of these firms have to borrow large amounts to fund their infrastructure investments, creating a fairly toxic combination—negative earnings and high leverage.
> 
> Given this combination, how can an infrastructure firm—a telecom firm or cable company—ever be valuable? Consider one possible path to success. A firm borrows money and makes large investments in infrastructure. Having made these investments, though, it has a secure market where entry for competitors is prohibitively expensive. In some cases, the firm may have a legally sanctioned monopoly to provide the service. No further large investments are needed in infrastructure but depreciation on the existing investments continues to generate large tax benefits. The net effect is that the firm will be sitting on a cash machine that allows it to not only pay off its debt but ready itself for the next generation of investments. In a sense, phone companies and power companies, as well as some cable and cellular firms, followed this path to success in the last century.
> 
> Since the 1990s, we have seen an explosion both in the number of telecom firms and the capital raised by these firms in a variety of ventures. While they followed the timeworn path of high debt and large up-front infrastructure investments laid by their predecessors, we believe that there are two critical ingredients that are missing with this generation of firms. The first is that technology has become a wild card and large investments in infrastructure do not guarantee future profitability or even that a market will exist. The second is that the protection from competition that allowed the old-time infrastructure firms to generate large and predictable profits is unlikely to be there for this new generation of firms. As a consequence, we would predict that far more of these firms will go bankrupt and that they would be well advised to rethink their policies on how much they should be borrowing as a consequence.
> 
> **Firms with Patents** The value of a firm generally comes from two sources—assets in place and expected future growth opportunities. The value of the former is generally captured in current cash flows, while the value of the latter is reflected in the expected growth rate. In the special case of a firm that derives a large portion of its value from a product patent or patents, expected growth will be from developing the patents. Ignoring them in a discounted cash flow valuation will understate the value of the firm.
> 
> There are three possible solutions to the problems associated with valuing firms with product options:
> 
> 1. Value the product options on the open market and add them to the value from discounted cash flow (DCF) valuation. If there is an active market trading in product options, this offers a viable and simple way of valuing these options. In the absence of such a market, or when the product options are not separable and tradable, this approach becomes difficult to apply.
> 
> 2. Use a higher growth rate than the one justified by existing projects and assets, to capture the additional value from product options. While this keeps the analysis within the traditional discounted cash flow valuation framework, the increase in the growth rate is essentially subjective and it converts contingent cash flows (where the product option will be exercised if and only if it makes economic sense) to expected cash flows.
> 
> 3. Use an option pricing model to value product options and add the value to that obtained from DCF valuation of assets in place. The advantage of this approach is that it mirrors the cash flow profile of a product option much more precisely.
> 
> The primary problem in valuing firms with product options is not that these options are ignored, but that they are often double counted. Analysts all too frequently use a higher growth rate to reflect the product options that a firm owns, but then add on a premium to the DCF value for the same product options. See [Option to Delay](#option-to-delay) to examine the valuation of this approach.
> 
> **Young Start-Up Firms** Many firms begin as ideas in the minds of entrepreneurs and develop into commercial ventures over time. During this transition from idea companies to commercial ventures, it is not unusual for these firms to lose money. This does not make them worthless. In fact, the boom in the market value of new economy companies in the late 1990s brought home the fact that good ideas can have substantial values, though the correction in 2000 also illustrated how volatile these values can be.
> 
> Valuing young start-up firms is perhaps the most difficult exercise in valuation and one that was, until very recently, the domain of venture capitalists and private equity investors, who often compensated for uncertainty by demanding very high returns on these investments. The challenge becomes much more daunting if a young start-up firm is publicly traded.[^29]

> When valuing a firm, you draw on information from _three sources_. The first is ***the current financial statements*** for the firm. You use these to determine how profitable a firm’s investments are or have been, how much it reinvests back to generate future growth and for all of the inputs that are required in any valuation. The second is ***the past history of the firm, in terms of both earnings and market prices***. A firm’s earnings and revenue history over time let you make judgments on how cyclical a firm’s business has been and how much growth it has shown, while a firm’s price history can help you measure its risk. Finally, you can look at ***the firm’s competitors or peer group to get a measure of how much better or worse a firm is than its competition***, and also to estimate key inputs on risk, growth, and cash flows.
> 
> ...
> 
> There are some firms, especially in new sectors of the economy, where you might run into information problems. First, these firms usually have not been in existence for more than a year or two, leading to a very limited history. Second, their current financial statements reveal very little about the component of their assets—expected growth—that contributes the most to their value. Third, these firms often represent the first of their kind of business. In many cases, there are no competitors or a peer group against which they can be measured. When valuing these firms, therefore, you may find yourself constrained on all three counts when it comes to information. How have investors responded to this absence of information? Some have decided that these stocks cannot be valued and should not therefore be held in a portfolio. Others have argued that while these stocks cannot be valued with traditional models, the fault lies in the models. They have come up with new and inventive ways, based on the limited information available, of justifying the prices paid for them. ...
> 
> The value of a firm is based on its capacity to generate cash flows and the uncertainty associated with these cash flows. ...
> 
> ...
> 
> ... The problem with young firms is not that they lose money, have no history, or do not have substantial tangible assets. It is that they are far earlier in their life cycles than established firms, and often have to be valued before they have an established market for their products. In fact, in some cases, the firms being valued have an interesting idea that could be a commercial success but has not been tested yet. The problem, however, is not a conceptual problem but one of estimation. The value of a firm is still the present value of the expected cash flows from its assets, but those cash flows are likely to be much more difficult to estimate.
> 
> ...
> 
> ![Valuation Issues across the Life Cycle](/.attachments/valuation-issues.across.life.cycle.png)
> 
> _Valuation Issues across the Life Cycle_
> 
> - _Start-up._ This represents the initial stage after a business has been formed. The product is generally still untested and does not have an established market. The firm has little in terms of current operations, no operating history, and no comparable firms. The value of this firm rests entirely on its future growth potential. Valuation poses the most challenges at this firm, since there is little useful information to go on. The inputs have to be estimated and are likely to have considerable error associated with them. The estimates of future growth are often based on assessments of the competence of existing managers and their capacity to convert a promising idea into commercial success. This is often the reason why firms in this phase try to hire managers with a successful track record in converting ideas into dollars, because it gives them credibility in the eyes of potential investors.
> 
> - _Expansion._ Once a firm succeeds in attracting customers and establishing a presence in the market, its revenues increase rapidly, though it still might be reporting losses. The current operations of the firm provide useful clues on pricing, margins, and expected growth, but current margins cannot be projected into the future. The operating history of the firm is still limited, and shows large changes from period to period. Other firms generally are in operation, but usually are at the same stage of growth as the firm being valued. Most of the value for this firm also comes from its expected growth. Valuation becomes a little simpler at this stage, but the information is still limited and unreliable, and the inputs to the valuation model are likely to be shifting substantially over time.
> 
> - _High growth._ While the firm’s revenues are growing rapidly at this stage, earnings are likely to lag behind revenues. At this stage, both the current operations and operating history of the firm contain information that can be used in valuing the firm. The number of comparable firms is generally highest at this stage, and these firms are more diverse in where they are in the life cycle, ranging from small, high-growth competitors to larger, lower-growth competitors. The existing assets of this firm have significant value, but the larger proportion of value still comes from future growth. There is more information available at this stage, and the estimation of inputs becomes more straightforward.
> 
> - _Mature growth._ As revenue growth starts leveling off, firms generally find two phenomena occurring. The earnings and cash flows continue to increase rapidly, reflecting past investments, and the need to invest in new projects declines. At this stage in the process, the firm has current operations that are reflective of the future, an operating history that provides substantial information about the firm’s markets, and a large number of comparable firms at the same stage in the life cycle. Existing assets contribute as much or more to firm value than expected growth, and the inputs to the valuation are likely to be stable.
> 
> - _Decline._ The last stage in this life cycle is decline. Firms in this stage find both revenues and earnings starting to decline, as their businesses mature and new competitors overtake them. Existing investments are likely to continue to produce cash flows, albeit at a declining pace, and the firm has little need for new investments. Thus, the value of the firm depends entirely on existing assets. While the number of comparable firms tends to become smaller at this stage, they are all likely to be either in mature growth or in decline as well.
> 
> Valuation is clearly more of a challenge in the earlier stages in a life cycle, and estimates of value are much more likely to contain errors for start-up or high-growth firms. But the payoff to valuation is also likely to be highest with these firms for two reasons. The first is that the absence of information scares many analysts away, and analysts who persist and end up with a valuation, no matter how imprecise, are likely to be rewarded. The second is that these are the firms that are most likely to be coming to the market in the form of initial public offerings and new issues, and need estimates of value.
> 
> **Venture Capital Valuation**
> 
> Until very recently, young start-up firms raised additional equity primarily from venture capitalists. It is useful to begin by looking at how venture capitalists assess the value of these firms. While venture capitalists sometimes use discounted cash flow models to value firms, they are much more likely to value private businesses using what is called the venture capital method. Here, the earnings of the private firm are forecast in a future year, when the company can be expected to go public. These earnings, in conjunction with an earnings multiple that is estimated by looking at publicly traded firms in the same business, are used to assess the value of the firm at the time of the initial public offering; this is called the exit or terminal value.
> 
> For instance, assume that you are valuing InfoSoft, a small software firm, that is expected to have an initial public offering in three years, and that the net income in the third year for the firm is expected to be $4 million. If the price-earnings ratio of publicly traded software firms is 25, this would yield an estimated exit value of $100 million. This value is discounted back to the present at what venture capitalists call a target rate of return, which measures what venture capitalists believe is a justifiable return, given the risk that they are exposed to. This target rate of return is usually set at a much higher level than the conventional cost of equity for the firm.
> 
> $\huge{ \text{Discounted terminal value} = \text{Estimated exit value}/(1 + \text{Target return})^n }$
> 
> Using the InfoSoft example again, if the venture capitalist requires a target return of 30 percent on his or her investment, the discounted terminal value for InfoSoft would be:
> 
> Discounted terminal value for InfoSoft = $100 million/1.30<sup>3</sup> = $45.52 million
> 
> So, how do venture capitalists come up with target rates of return and why are they so high? It is possible that there are some venture capitalists who have developed sophisticated risk-return models that yield target returns, but for the most part, the target returns represent a mix of judgment, historical experience, and guesswork. As for why they are so high, it is a combination of three factors:
> 
> 1. Young and start-up firms are more exposed to macroeconomic risk than the rest of the market. In CAPM terms, they should command high betas.
> 2. Venture capitalists are often sector-focused and not diversified. Consequently, they demand a premium for firm-specific risk that can be diversified away.
> 3. Many young, start-up companies don’t make it, and the target rate of return incorporates the risk of failure.
> 
> In practice, target rates of return become more instruments of negotiation than conventional discount rates. Put differently, the interests of a venture capitalist are served by using a high target rate of return and demanding a much larger stake in the start up company. The interests of the owners of the company are advanced with a lower target rate of return. The final number used will depend upon the relative bargaining power of the two sides.
>
> The venture capital approach is also exposed to another problem. To the extent that exit multiples are based on how comparable firms are priced today, they can result in serious misevaluations if the market is wrong. For instance, venture capitalists who valued Internet firms in 2000 on the assumption that they would be able to sell these firms at 80 times revenues (which was what the market was pricing small, publicly traded Internet firms at that time) would have overestimated the value of these firms.
> 
> ...
> 
> **General Framework For Analysis**
> 
> To value firms with negative earnings, little or no historical data, and few comparables, the steps involved are essentially the same as in any valuation. This section will look at some of the issues that are likely to come up at each step when valuing young companies.
> 
> ***Step 1: Assess the Firm’s Current Standing: The Importance of Updated Information***
> 
> It is conventional, when valuing firms, to use data from the most recent financial year to obtain the current year’s inputs. For firms with negative earnings and high growth in revenues, the numbers tend to change dramatically from period to period. Consequently, it makes more sense to look at the most recent information that one can obtain, at least on revenues and earnings. Using the revenues and earnings from the trailing 12 months, for instance, will provide a much better estimate of value than using earnings from the last financial year. It is true that some items, such as operating leases and options outstanding, may not be updated as frequently. Even so, we would argue for using estimates for these inputs2 and valuing firms with more recent data.
> 
> ***Step 2: Estimate Revenue Growth***
> 
> Young firms tend to have fairly small amounts of revenues, but the expectation is that these revenues will grow at a substantial rate in the future. Not surprisingly, this is a key input in these valuations, and we would suggest drawing on a number of sources.
> 
> - _Past growth rate in revenues at the firm itself._ Since the firm increases in scale as it grows, it will become more and more difficult to maintain very high growth rates. Thus, a firm that grew 300 percent two years ago and 200 percent last year is likely to grow at a lower rate this year.
> 
> - _Growth rate in the overall market that the firm serves._ It is far easier for firms to maintain high growth rates in markets that are themselves growing at high rates than it is for them to do so in stable markets.
> 
> - _Barriers to entry and competitive advantage possessed by the firm._ For a firm to be able to sustain high growth rates, it has to have some sustainable competitive advantage. This may come from legal protection (as is the case with a patent), a superior product or service, or a brand name, or from being the first mover into a market. If the competitive advantage looks sustainable, high growth is much more likely to last for a long period. If it is not, it will taper off much faster.
> 
> ***Step 3: Estimate a Sustainable Operating Margin in Stable Growth***
> 
> For a firm losing money, high revenue growth alone will accomplish little more than make the losses become larger over time. A key component for a young firm to be valuable is the expectation that the operating margin, while negative now, will become positive in the future. In many ways the true test in valuation is being able to evaluate what a young, high-growth firm will have as an operating margin when growth stabilizes. In the absence of comparables, the difficulty of this task is magnified. Again, a few guidelines help:
> 
> - _Looking at the underlying business that this firm is in, consider its true competitors._ For instance, while Tesla is considered to be an electric automobile or even a technology company, it is ultimately in the automobile business. At least from the perspective of margins, is seems reasonable to argue that Tesla’s margins will approach those of other automobile manufacturers.
> 
> - _Deconstruct the firm’s current income statement to get a truer measure of its operating margin._ Many young start-up firms that report losses do so not because their operating expenses from generating current revenues are large, but because a significant portion of operating expenses are in pursuit of future growth and should really be considered to be capital expenses. Since many of these expenses are treated as selling, general, and administrative (SG&A) expenses in income statements, estimating margins and profitability prior to these expenses is a useful exercise in figuring out how profitable a company’s products truly are.
> 
> ***Step 4: Estimate Reinvestment to Generate Growth***
> 
> To grow, firms have to reinvest, and this principle cannot be set aside when you are looking at a young firm. Unlike a mature firm, though, there is likely to be little in the firm’s history that will help in determining how much the firm will need to reinvest. As the firm grows, the nature of its reinvestment and the amount reinvested will probably change, and the challenge is to estimate this amount.
> 
> Earlier sections related growth in operating income to how much a firm reinvests and how well it reinvests (measured by the return on capital).
> 
> Expected growth = Reinvestment rate × Return on capital
> 
> In fact, this equation has been used to estimate growth in most of the valuations done so far in this book. However, note that this equation becomes inoperable when operating earnings are negative, which is the position we are in when valuing young firms. In those cases, the growth in revenues must be estimated first, and the reinvestment must be based on the revenue growth. To make this link, we used a sales-to-capital ratio, that is, a ratio that specifies how many additional dollars of revenue will be generated by each additional dollar of capital:
> 
> Expected reinvestment = Expected change in revenue/(Sales/Capital)
> 
> For instance, to grow revenues by $1 billion, with a sales-to-capital ratio of 4, would require a reinvestment of $250 million. The key input required for this formulation is the sales-to-capital ratio, and it can be estimated by looking at the firm’s history, limited though it might be, and at industry averages, with the industry defined broadly to reflect the business the firm is in.
> 
> In steady state, however, the reinvestment needs can be computed using the expected growth rate and the expected return on capital:
> 
> $\huge{ \text{Expected reinvestment rate}_s = \text{Expected growth}_s / \text{ROC}_s }$
> 
> where $s$ for stable. Hence equation is for variables of stable growth.
> 
> An alternative approach is to use the industry-average reinvestment rates (broken up into capital expenditures and working capital needs) to estimate cash flows.
> 
> ***Step 5: Estimate Risk Parameters and Discount Rates***
> 
> In the standard approaches for estimating beta, we regress stock returns against market returns. Young start-up firms, even when publicly traded, have little historical data, and we cannot use the conventional approach to estimate risk parameters.3 ..., we suggested alternative approaches for estimating betas that are useful to bridge this gap. One is the bottom-up approach. If there are comparable firms that have been listed for two or more years, the current risk parameters for the firm can be estimated by looking at the averages for these firms. If such firms do not exist, risk parameters can be estimated using the financial characteristics of the firm—the volatility in earnings, their size, cash flow characteristics, and financial leverage.
> 
> If a young firm has debt, we run into a different problem when estimating the cost of debt. The firm will generally not be rated, thus denying us a chance to estimate a cost of debt based on the rating. We could try estimating a synthetic rating, but the negative operating income will yield a negative interest coverage ratio and a default rating for the firm. One solution is to estimate an expected interest coverage ratio for the firm based on expected operating income in future periods (note that these forecasts were already made in steps 2 and 3) and to use this expected interest coverage ratio to estimate a synthetic rating.
> 
> Whatever approach we use to estimate costs of equity and debt, they should not be left unchanged over the estimation period. As the firm matures and moves toward its sustainable margin and stable growth, the risk parameters should also approach those of an average firm—the betas should move toward 1 and the cost of debt should adjust toward a mature firm’s cost of debt.
> 
> In addition to estimating the cost of equity for these firms, we have to estimate how leverage will change over time. Again, targeting an industry average or an optimal debt ratio for this firm (as it will look in steady state) should yield reasonable estimates for the cost of capital over time.
> 
> 
> ***Step 6: Estimate the Value of the Firm***
> 
> With the inputs on earnings, reinvestment rates, and risk parameters over time, this valuation starts resembling a conventional valuation. In many cases, the cash flows in the early years will be negative, driven by negative earnings and large reinvestment needs, but turn positive in later years as margins improve and reinvestment drops off. The bulk of the value will generally be in the terminal value. Note, though, that the magnitude of the terminal value is determined by your growth and target margin assumptions during the high growth phase.
> 
> Having valued the operating assets of the firm, you need to consider two other factors—the possibility that the firm will not survive to become a going concern and the value of nonoperating assets—to value the firm.
> 
> Survival When we value firms using discounted cash flow valuation, we tend to assume that the firm will be a going concern and continue to generate cash flows in perpetuity. This assumption might be suspect when valuing young companies, since many of them will not survive the tests that they will be put to over the next few years. If we ignore this possibility and consider only the best-case scenario of expansion and perpetual profitability, we will overestimate the value of these firms. We have two choices when it comes to dealing with this possibility.
> 
> 1. The first is to build into the expected growth rates and earnings the likelihood of unfavorable outcomes. Thus, the growth rate used in revenues will be the expected growth rate over all scenarios, both optimistic and pessimistic and incorporate the likelihood that the firm will not make it. For young firms, this will become progressively more difficult to do as you get further and further into the future.
> 
> 2. The second is to estimate a discounted cash flow value across only the scenarios where the firm is a going concern, and then apply a probability that the firm will be a going concern to this value. Once we have estimated the probability of surviving as a going concern, the value of a firm can then be estimated as follows:
>   
>    Value of firm = Probability of surviving as a going concern × Discounted cash flow value of firm + (1 − Probability of surviving as a going concern) × Distress or liquidation sale value
> 
> One approach to estimating the probability of survival is to look at the empirical data. Knaup (2005) and Knaup and Piazza (2008) used data from the U.S. Bureau of Labor Statistics Quarterly Census of Employment and Wages (QCEW) to compute survival statistics across firms. This census contains information on more than 8.9 million U.S. businesses in both the public sector and private sector. Using a seven-year database from 1998 to 2005, the authors concluded that only 44 percent of all businesses that were founded in 1998 survived at least four years and only 31 percent made it through all seven years. In addition, they categorized firms into 10 sectors and estimated survival rates for each. Table 23.1 presents their findings on the proportion of firms that made it through each year for each sector and the average for the entire sample. Note that survival rates vary across sectors, with 25 percent of firms in the information sector (which includes technology) surviving seven years, whereas almost 44 percent of health services businesses made it through that period.
> 
> **Value of Nonoperating Assets** As with the valuation of any firm, you have to consider cash, marketable securities, and holdings in other companies when you value a firm. The only note of caution that we would add is that young firms can burn through significant cash balances in short periods because their operations drain cash rather than generate it. Thus, the cash balance from the last financial statements, especially if those statements are more than a few months old, can be very different from the current cash balances.
> 
> To the extent that young firms often have holdings in other young firms, there is also the danger that investments in other firms may be shown on the books at values that are not reflective of their true value. If there are only one or two large holdings, you should value those holdings using cash flow–based approaches as well.
> 
> ***Step 7: Estimate the Value of Equity and Per-Share Value***
> 
> To get from firm value to equity value, we generally subtract out all nonequity claims on the firm. For mature firms, the nonequity claims take the form of bank debt and bonds outstanding. For young firms, there can also be preferred equity claims that have to be valued and subtracted to get to the value of the common equity.
> 
> To get from equity value to value per share, you have to consider equity options outstanding on the firm. ... this is something that needs to be done for all firms, but it becomes particularly important with young start-up firms, because the value of the options outstanding can be a much larger share of the overall equity value. Given the importance of these claims, we would suggest that the options—vested as well as nonvested—be valued using an option pricing model, and that the value of the options be subtracted from the value of the equity to arrive at the value of equity in common stock. This value should then be divided by the actual number of shares outstanding to arrive at the equity value per share. Since Tesla will probably have to issue more shares in the next few years to cover its reinvestment needs, you may wonder why we do not incorporate these additional shares when computing value per share.
> 
> **Value Drivers**
> 
> _What are the key inputs that determine the value of a young high-growth firm with negative earnings?_ In general, the inputs that have the greatest impact on value are the estimates of sustainable margins and revenue growth. To a lesser extent, assumptions about how long it will take the firm to reach a sustainable margin and reinvestment needs in stable growth also have an impact on value.
> 
> In practical terms, the bulk of the value of these firms is derived from the terminal value. While this will trouble some, it mirrors how an investor makes returns in these firms. The payoff to these investors takes the form of price appreciation rather than dividends or stock buybacks. Another way of explaining the dependence on terminal value and the importance of the sustainable growth assumption is in terms of assets in place and future growth. The value of any firm can be written as the sum of the two:
> 
> Value of firm = Value of assets in place + Value of growth potential
> 
> For start-up firms with negative earnings, almost all of the value can be attributed to the second component. Not surprisingly, the firm value is determined by assumptions about the latter.
> 
> 
> **Estimation Noise**
> 
> The framework for valuation provided in this section should not be considered a recipe for precision. _The valuation of a firm with negative earnings, high growth, and limited information will always have estimation error._ One way to present this error is in terms of a valuation range, and the range on the value for these firms will be large. This is often used as an excuse by analysts who do not want to go through the process of valuing such firms. It also provides critics with a simplistic argument against trusting the numbers that emerge from these models.
> 
> We have a different view. The error in the valuation is not always a reflection of the quality of the valuation model, or the analyst using it, but of the underlying real uncertainty about the future prospects of the firm. This uncertainty is a fact of life when it comes to investing in these firms. In a valuation, we attempt to grapple with this uncertainty and make our best estimates about the future. Note that those who disdain valuation models for their potential errors end up using far cruder approaches, such as comparing price-sales ratios across firms. The difference, as we see it, is that they choose to sweep the uncertainties under the rug and act as if they do not exist.
> 
> There are two other points to make about the precision in these valuations. First, _even if a valuation is imprecise, it provides a powerful tool to answer the question of what has to occur for the current market price of a firm to be justified._ Investors can then decide whether they are comfortable with these assumptions, and make their decisions on buying and selling stock. Second, _even if individual valuations are noisy, portfolios constructed based on these valuations will be more precisely valued._ Thus, an investor who buys 40 stocks that he or she has found to be undervalued using traditional valuation models, albeit with significant error, should find that error averaging out across the portfolio. The ultimate performance of the portfolio then should reflect the valuation skills, or the absence of them, of the analyst.
> [^30]

### Cashflow

> The value of an asset comes from its capacity to generate cash flows. When valuing a firm, these cash flows should be after taxes, prior to debt payments, and after reinvestment needs. When valuing equity, the cash flows should be after debt payments. There are thus three basic steps to estimating these cash flows.[^34]

#### Equity Valuation Models

> In the strictest sense, the only cash flow you receive when you buy shares in a publicly traded firm is a dividend. The simplest model for valuing equity is the dividend discount model (DDM)—the value of a stock is the present value of expected dividends on it. While many analysts have turned away from the dividend discount model and view it as outmoded, much of the intuition that drives discounted cash flow valuation stems from the dividend discount model. In fact, there are companies where the dividend discount model remains a useful tool for estimating value.[^35]

> The dividend discount model is based on the premise that the only cash flows received by stockholders are dividends. Even if we use the modified version of the model and treat stock buybacks as dividends, we may misvalue firms that consistently fail to return what they can afford to their stockholders.
> 
> ... a more expansive definition of cash flows to equity [can involve] the cash flows left over after meeting all financial obligations, including debt payments, and after covering capital expenditure and working capital needs. ... reasons for differences between dividends and free cash flows to equity (FCFE) [are explored in this section][^36]
> 
> ...
> 
> Given what firms are returning to their stockholders in the form of dividends or stock buybacks, how do we decide whether they are returning too much or too little? We propose a simple measure how much cash is available to be paid out to stockholders after meeting reinvestment needs and compare this amount to the amount actually returned to stockholders.
> 
> **Free Cash Flows to Equity**
> 
> To estimate how much cash a firm can afford to return to its stockholders, we begin with the net income—the accounting measure of the stockholders’ earnings during the period—and convert it to a cash flow by subtracting out a firm’s reinvestment needs. First, any capital expenditures, defined broadly to include acquisitions, are subtracted from the net income, since they represent cash outflows. Depreciation and amortization, on the other hand, are added back in because they are accounting but not cash expenses. The difference between capital expenditures and depreciation (net capital expenditures) is usually a function of the growth characteristics of the firm. High-growth firms tend to have high net capital expenditures relative to earnings, whereas low-growth firms may have low, and sometimes even negative, net capital expenditures.
> 
> Second, increases in working capital drain a firm’s cash flows, while decreases in working capital increase the cash flows available to equity investors. Firms that are growing fast, in industries with high working capital requirements (retailing, for instance), typically have large increases in working capital. Since we are interested in the cash flow effects, we consider only changes in noncash working capital in this analysis.
> 
> Finally, equity investors also have to consider the effect of changes in the levels of debt on their cash flows. Repaying the principal on existing debt represents a cash outflow, but the debt repayment may be fully or partially financed by the issue of new debt, which is a cash inflow. Again, netting the repayment of old debt against the new debt issues provides a measure of the cash flow effects of changes in debt.
> 
> Allowing for the cash flow effects of net capital expenditures, changes in working capital, and net changes in debt on equity investors, we can define the cash flows left over after these changes as the free cash flow to equity (FCFE):
> 
> ${ \text{Free cash flow to equity} = \text{Net income} − (\text{Capital expenditures} − \text{Depreciation}) − (\text{Change in noncash working capital}) + (\text{New debt issued} − \text{Debt repayments}) }$
> 
> This is the cash flow available to be paid out as dividends. Deconstructing this equation, the reinvestment by equity investors into the firm can be written as:
> 
> Equity reinvestment = Capital expenditures − Depreciation + Change in noncash working capital − New debt issues + Debt repayments
> 
> Equity reinvestment rate = Equity reinvestment/Net income
> 
> This calculation can be simplified if we assume that the net capital expenditures and working capital changes are financed using a fixed mix of debt and equity. If δ is the proportion of the net capital expenditures and working capital changes that is raised from debt financing, the effect on cash flows to equity of these items can be represented as follows:
> 
> Equity cash flows associated with meeting capital expenditure needs = −(Capital expenditures − Depreciation)(1 − δ)
> 
> Equity cash flows associated with meeting working capital needs = −(Δ Working capital)(1 − δ)
> 
> Accordingly, the cash flow available for equity investors after meeting capital expenditure and working capital needs is:
> 
> Free cash flow to equity = Net income − (Capital expenditures − Depreciation) × (1 − δ) − (Δ Working capital)(1 − δ)
> 
> Note that the net debt payment item is eliminated, because debt repayments are financed with new debt issues to keep the debt ratio fixed. It is appropriate to assume that a specified proportion of net capital expenditures and working capital needs will be financed with debt if the target or optimal debt ratio of the firm is used to forecast the free cash flow to equity that will be available in future periods. Alternatively, in examining past periods, we can use the firm’s average debt ratio over the period to arrive at approximate free cash flows to equity.
> 
> **Comparing Dividends to Free Cash Flows to Equity**
> 
> The conventional measure of dividend policy—the dividend payout ratio—gives us the value of dividends as a proportion of earnings. The modified approach measures the total cash returned to stockholders as a proportion of the free cash flow to equity:
> 
> Dividend payout ratio = Dividends/Earnings
> 
> Cash to stockholders to FCFE ratio = (Dividends + Equity repurchases)/FCFE
> 
> The ratio of cash to stockholders to FCFE shows how much of the cash available to be paid out to stockholders is actually returned to them in the form of dividends and stock buybacks. If this ratio, over time, is equal or close to 1, the firm is paying out all that it can to its stockholders. If it is significantly less than 1, the firm is paying out less than it can afford to and is using the difference to increase its cash balance or to invest in marketable securities. If it is significantly over 1, the firm is paying out more than it can afford and is either drawing on an existing cash balance or issuing new securities (stocks or bonds).
> 
> We can observe the tendency of firms to pay out less to stockholders than they have available in free cash flows to equity by examining cash returned to stockholders paid as a percentage of free cash flow to equity. ...
> 
> When a firm is paying out less in dividends than it has available in free cash flows, it is generating surplus cash. For those firms, this cash surplus appears as an increase in the cash balance. Firms that pay dividends that exceed FCFE have to finance these dividend payments either out of existing cash balances or by making new stock issues.
> 
> The implications for valuation are simple. If we use the dividend discount model and do not allow for the buildup of cash that occurs when firms pay out less than they can afford, we will underestimate the value of equity in firms. If we use the model to value firms that pay out more dividends than they have available, we will overvalue the firms. The rest of this chapter is designed to correct for this limitation.
> 
> **Why Firms May Pay Out Less than Is Available**
> 
> Many firms pay out less to stockholders, in the form of dividends and stock buybacks, than they have available in free cash flows to equity. The reasons vary from firm to firm.
> 
> **Desire for Stability** Firms are generally reluctant to change dividends, and dividends are considered “sticky” because the variability in dividends is significantly lower than the variability in earnings or cash flows. The unwillingness to change dividends is accentuated when firms have to reduce dividends, and increases in dividends outnumber cuts in dividends by at least a five-to-one margin in most periods. As a consequence of this reluctance to cut dividends, firms will often refuse to increase dividends even when earnings and FCFE go up, because they are uncertain about their capacity to maintain these higher dividends. This leads to a lag between earnings increases and dividend increases. Similarly, firms frequently keep dividends unchanged in the face of declining earnings and FCFE. ...
> 
> The number of firms increasing dividends outnumbers those decreasing dividends seven to one. The number of firms, however, that do not change dividends outnumbers firms that do about four to one. Dividends are also less variable than either FCFE or earnings, but this reduced volatility is a result of keeping dividends significantly below the FCFE.
> 
> **Future Investment Needs** A firm might hold back on paying its entire FCFE as dividends if it expects substantial increases in capital expenditure needs in the future. Since issuing stocks is expensive (with floatation costs and issuance fees), it may choose to keep the excess cash to finance these future needs. Thus, to the degree that a firm is unsure about its future financing needs, it will retain some cash to take on unexpected investments or meet unanticipated needs.
> 
> **Tax Factors** If dividends are taxed at a higher tax rate than capital gains, a firm may choose to retain the excess cash and pay out much less in dividends than it has available. This is likely to be accentuated if the stockholders in the firm are in high tax brackets, as is the case with many family-controlled firms. If, however, investors in the firm like dividends or tax laws favor dividends, the firm may pay more out in dividends than it has available in FCFE, often borrowing or issuing new stock to do so.
> 
> **Signaling Prerogatives** Firms often use dividends as signals of future prospects, with increases in dividends being viewed as positive signals and decreases as negative signals. The empirical evidence is consistent with this signaling story, since stock prices generally go up on dividend increases and down on dividend decreases. The use of dividends as signals may lead to differences between dividends and FCFE.
> 
> **Managerial Self-interest** The managers of a firm may gain by retaining cash rather than paying it out as a dividend. The desire for empire building may make increasing the size of the firm an objective on its own. Or management may feel the need to build up a cash cushion to tide over periods when earnings may dip; in such periods, the cash cushion may reduce or obscure the earnings drop and may allow managers to remain in control.
> 
> ...
> 
> **FCFE Valuation versus Dividend Discount Model Valuation**
> 
> The discounted cash flow model that uses FCFE can be viewed as an alternative to the dividend discount model. Since the two approaches sometimes provide different estimates of value, it is worth examining when they provide similar estimates of value, when they provide different estimates of value, and what the difference tells us about the firm.
> 
> **When They Are Similar**
> 
> There are two conditions under which the value from using the FCFE in discounted cash flow valuation will be the same as the value obtained from using the dividend discount model. The first is the obvious one, where the dividends are equal to the FCFE. The second condition is more subtle, where the FCFE is greater than dividends, but the excess cash (FCFE minus dividends) is invested in projects with net present value of zero. (For instance, investing in financial assets that are fairly priced should yield a net present value of zero.)
> 
> **When They Are Different**
> 
> There are several cases where the two models will provide different estimates of value. First, when the FCFE is greater than the dividend and the excess cash either earns below-market interest rates or is invested in negative net present value projects, the value from the FCFE model will be greater than the value from the dividend discount model. There is reason to believe that this is not as unusual as it would seem at first glance. There are numerous case studies of firms that, having accumulated large cash balances, by paying out low dividends relative to FCFE, have chosen to use this cash to finance unwise takeovers (where the price paid is greater than the value received from the takeover). Second, the payment of smaller dividends than can be afforded to be paid out by a firm may lead to a lower debt ratio and a higher cost of capital, causing a loss in value.
> 
> In the cases where dividends are greater than FCFE, the firm will have to issue either new stock or new debt to pay these dividends leading to at least three negative consequences for value. One is the issuance cost on these security issues, which can be substantial for equity issues, creates an unnecessary expenditure that decreases value. Second, if the firm borrows the money to pay the dividends, the firm may become overlevered (relative to the optimal), exposing itself to distress/default and leading to a loss in value. Finally, paying too much in dividends can lead to capital rationing constraints where good projects are rejected, resulting in a loss of value.
> 
> There is a third possibility and it reflects different assumptions about rein-
vestment and growth in the two models. If the same growth rate is used in the
dividend discount and FCFE models, the FCFE model will give a higher value
than the dividend discount model whenever FCFE is higher than dividends and a
lower value when dividends exceed FCFE. In reality, the growth rate in FCFE
should be different from the growth rate in dividends, because the free cash flow
to equity is assumed to be paid out to stockholders. This will affect the reinvest-
ment rate of the firm. In addition, the return on equity used in the FCFE model
should reflect the return on equity on noncash investments, whereas the return on
equity used in the dividend discount model should be the overall return on equity.
> 
> _Differences between DDM and FCFE Models_
> 
> | | Dividend Discount Model | FCFE Model |
> |:--- |:--- |:-- |
> | Implicit assumption | Only dividends are paid. Remaining portions of earnings are invested back into the firm, some in operating assets and some in cash and marketable securities. | The FCFE is paid out to stockholders. The remaining earnings are invested only in operating assets. |
> | Expected growth | Measures growth in income from both operating and cash assets. In terms of fundamentals, it is the product of the retention ratio and the return on equity. | Measures growth only in income from operating assets. In terms of fundamentals, it is the product of the equity reinvestment rate and the noncash return on equity. |
> | Dealing with cash and marketable securities | The income from cash and marketable securities is built into earnings and ultimately into dividends. Therefore, cash and marketable securities do not need to be added in. | <p>You have two choices:</p><ol><li>Build income from cash and marketable securities into projections of income, and estimate the value of equity.</li><li>Ignore income from cash and marketable securities, and add their value to equity value in model.</li></ol> |
> 
> In general, when firms pay out much less in dividends than they have available in FCFE, the expected growth rate and terminal value will be higher in the dividend discount model, but the year-to-year cash flows will be higher in the FCFE model. The net effect on value will vary from company to company.
> 
> **What Does It Mean When They Are Different?**
> 
> When the value using the FCFE model is different from the value using the dividend discount model, with consistent growth assumptions, there are two questions that need to be addressed: What does the difference between the two models tell us? Which of the two models is the appropriate one to use in evaluating the market price?
> 
> The less frequent scenario is that the dividend discount model yields a higher value than the FCFE model, largely because dividends exceed FCFE. In this case, it is best to go with the FCFE model because the dividends are not sustainable. The more common occurrence is for the value from the FCFE model to exceed the value from the dividend discount model. The difference between the value from the FCFE model and the value using the dividend discount model can be considered one component of the value of controlling a firm—it measures the value of controlling dividend policy. In a hostile takeover, the bidder can expect to control the firm and change the dividend policy (to reflect FCFE), thus capturing the higher FCFE value.
> 
> As for which of the two values is the more appropriate one for use in evaluating the market price, the answer lies in the openness of the market for corporate control. If there is a sizable probability that a firm can be taken over or its management changed, the market price will reflect that likelihood, and the appropriate benchmark to use is the value from the FCFE model. As changes in corporate control become more difficult because of a firm’s size and/or legal or market restrictions on takeovers, the value from the dividend discount model will provide the appropriate benchmark for comparison.
> 
> So, why are they different? The FCFE model does use a lower growth rate than the dividend discount model, but it allows for more cash to be returned to stockholders. In effect, we are incorporating the fact that Coca-Cola does not pay out its FCFE as dividends. The net effect, at least in this case, is an increase in value per share. For companies that pay out more dividends than they have available in FCFE, the value per share might drop with the FCFE model. In either case, we would argue that the FCFE estimate of value per share is a more realistic one than the dividend discount model estimate of value per share.[^36]

##### Dividend Discount Model

> In the strictest sense, the only cash flow you receive when you buy shares in a publicly traded firm is a dividend. The simplest model for valuing equity is the dividend discount model (DDM)—the value of a stock is the present value of expected dividends on it. While many analysts have turned away from the dividend discount model and view it as outmoded, much of the intuition that drives discounted cash flow valuation stems from the dividend discount model. In fact, there are companies where the dividend discount model remains a useful tool for estimating value.
> 
> ...
> 
> **The General Model**
> 
> When an investor buys stock, he or she generally expects to get two types of cash flows—dividends during the period the stock is held and an expected price at the end of the holding period. Since this expected price is itself determined by future dividends, the value of a stock is the present value of dividends through infinity:
> 
> $$\huge{ \text{Value per share of stock} = { {\sum_{t=1}^{t=\infty}} { {E (DPS_t)} \over (1 + k_e)^t } } }$$
> 
> where, \
> $DPS_t$ = Expected dividends per share \
> $k_e$ = Cost of equity
> 
> ***The rationale for the model lies in the present value rule—the value of any asset is the present value of expected future cash flows, discounted at a rate appropriate to the riskiness of the cash flows being discounted.***[^35]

> We can continue this process for any number of years by replacing the final stock price with the value that the next holder of the stock would be willing to pay. Doing so leads to the general **dividend-discount model** for the stock price, where the horizon $N$ is arbitrary:
> 
> $$\huge{P_0 = {Div_1 \over 1 + r_E} + {Div_2 \over (1 + r_E)^2} + {Div_3 \over (1 + r_E)^3} + \ldots + {Div_N \over (1 + r_E)^N} + { P_N \over (1 + r_E)^N } }$$
> 
> ... For the special case in which the firm eventually pays dividends and is never acquired, it is possible to hold the shares forever.
> 
> $$\huge{P_0 = {Div_1 \over 1 + r_E} + {Div_2 \over (1 + r_E)^2} + {Div_3 \over (1 + r_E)^3} + \ldots = \sum_{n=1}^\infty {Div_n \over (1 + r_E)^n} }$$
> 
> [where $r_E$ is Cost of equity]
> ...
> 
> That is, _the price of the stock is equal to the present value of the expected future dividends it will pay_.[^3]

> There are two basic inputs to the model—expected dividends and the cost on equity. To obtain the expected dividends, we make assumptions about expected future growth rates in earnings and payout ratios. The required rate of return on a stock is determined by its riskiness, measured differently in different models—the market beta in the capital asset pricing model (CAPM) and the factor betas in the arbitrage and multifactor models. The model is flexible enough to allow for time-varying discount rates, where the time variation is because of expected changes in interest rates or risk across time.
> 
> Since projections of dollar dividends cannot be made through infinity, several versions of the dividend discount model have been developed based on different assumptions about future growth. We will begin with the simplest—a model designed to value stock in a stable growth firm that pays out what it can afford to in dividends—and then look at how the model can be adapted to value companies in high growth that may be paying little or no dividends.
> 
> **The Gordon Growth Model**
> 
> The Gordon growth model can be used to value a firm that is in “steady state” with dividends growing at a rate that can be sustained forever.
> 
> **The Model** The Gordon growth model relates the value of a stock to its expected dividends in the next time period, the cost of equity, and the expected growth rate in dividends.
> 
> $\large{ \text{Value of stock} = \text{Expected dividends next period}/(\text{Cost of equity} - \text{Expected growth rate in perpetuity}) }$
> 
> **What Is a Stable Growth Rate?** While the Gordon growth model provides a simple approach to valuing equity, its use is limited to firms that are growing at a stable growth rate. There are two insights worth keeping in mind when estimating a stable growth rate. First, since the growth rate in the firm’s dividends is expected to last forever, the firm’s other measures of performance (including earnings) can also be expected to grow at the same rate. To see why, consider the consequences in the long term of a firm whose earnings grow 2 percent a year forever, while its dividends grow at 3 percent. Over time, the dividends will exceed earnings. If a firm’s earnings grow at a faster rate than dividends in the long term, the payout ratio, in the long term, will converge toward zero, which is also not a steady state. Thus, though the model’s requirement is for the expected growth rate in dividends, analysts should be able to substitute in the expected growth rate in earnings and get precisely the same result, if the firm is truly in steady state.
> 
> The second issue relates to what growth rate is reasonable as a stable growth rate. ..., this growth rate has to be less than or equal to the growth rate of the economy in which the firm operates. No firm, no matter how well run, can be assumed to grow forever at a rate that exceeds the growth rate of the economy (or as a proxy, the risk-free rate). In addition, the caveats made about stable growth apply:
> 
> - The return on equity ($ROE$) that we assume in perpetuity should reflect not what the company may have made last year nor what it is expected to make next year, but, rather, a longer-term estimate. The estimate of $ROE$ matters because the payout ratio in stable growth has to be consistent:
> 
>   $\large{ \text{Payout ratio} = g/ROE}$
> 
> - The cost of equity has to be consistent with the firm being mature; if a beta is being used, it should be close to 1.
> 
> **Limitations of the Model** As most analysts discover quickly, the Gordon growth model is extremely sensitive to assumptions about the growth rate, as long as other inputs to the model (payout ratio, cost of equity) are kept constant. Consider a stock with an expected dividend per share next period of $2.50, a cost of equity of 15 percent, and an expected growth rate of 5 percent forever. The value of this stock is:
> 
> Value = 2.50/(.15 − .05) = $25
> 
> There are, of course, two common sense fixes to this problem. The first is to work with the constraint that a stable growth rate cannot exceed the risk-free rate; ... The second is to recognize that growth is not free; when the growth rate is increased, the payout ratio should be decreased. This creates a trade-off on growth, with the net effect of increasing growth being positive, neutral, or even negative.
> 
> **Firms Model Works Best For** In summary, the Gordon growth model is best suited for firms growing at a rate equal to or lower than the nominal growth in the economy with well-established dividend payout policies that they intend to continue into the future. The dividend payout and cost of equity of the firm have to be consistent with the assumption of stability, since stable firms generally pay substantial dividends and have betas close to 1. In particular, this model will underestimate the value of the stock in firms that consistently pay out less than they can afford to and accumulate cash in the process.
> 
> ...
> 
> **Two-Stage Dividend Discount Model**
> 
> The two-stage growth model allows for two stages of growth—an initial phase where the growth rate is not a stable growth rate and a subsequent steady state where the growth rate is stable and is expected to remain so for the long term. While, in most cases, the growth rate during the initial phase is higher than the stable growth rate, the model can be adapted to value companies that are expected to post low or even negative growth rates for a few years and then revert back to stable growth.
> 
> **The Model** The model is based on two stages of growth, an extraordinary growth phase that lasts n years, and a stable growth phase that lasts forever after that.
> 
> $\large{ \text{Value of the stock} = \text{PV of dividends during extraordinary phase} + \text{PV of terminal price} }$
> 
> $$\huge{ P_0 = { {\sum_{t=1}^{t=\infty}} { {E (DPS_t)} \over (1 + k_{e,g})^t } } + { P_n \over {1 + k_{e,g}}^n } }$$
> 
> $$\huge{ { \text{where } P_n  } = { DPS_{n+1} \over { k_{e,s} - g_n } } }$$ 
> 
>
> where, \
> $DPS_t$ = Expected dividends per share in year $t$ \
> $k_e$ = Cost of equity ($g$: high growth period; $s$: stable growth period) \
> $P_n$ = Price at the end of year $n$ \
> $g$ = Extraordinary growth rate for the first $n$ years \
> $g_n$ = Growth rate forever after year $n$
> 
> In the case where the extraordinary growth rate ($g$) and payout ratio are unchanged for the first $n$ years, this formula can be simplified as follows:
> 
> $$\huge{ P_0 = { { { { DPS_0 \times (1 + g) \times \left[ 1 - { { (1 + g)^n } \over { (1 + k_{e,g})^n } } \right] } \over { k_{e,s} - g_n } } + { DPS_{n+1} \over { (k_{e,s} - g_n)(1 + k_{e,g})^n } } } } }$$ 
> 
> where the inputs are as defined previously.
> 
> **Calculating the Terminal Price** The same constraint that applies to the growth rate for the Gordon growth model (i.e., that the growth rate in the firm is comparable to the nominal growth rate in the economy) applies for the terminal growth rate ($g_n$) in this model as well.
> 
> In addition, the payout ratio has to be consistent with the estimated growth rate. If the growth rate is expected to drop significantly after the initial growth phase, the payout ratio should be higher in the stable phase than in the growth phase. A stable firm can pay out more of its earnings in dividends than a growing firm. One way of estimating this new payout ratio is to use the fundamental growth model ...:
> 
> $\large{ \text{Expected growth} = \text{Retention ratio} \times \text{Return on equity} = (1 − \text{Payout ratio}) \times \text{Return on equity} }$
> 
> Algebraic manipulation yields the following stable period payout ratio:
> 
> $\large{ \text{Stable payout ratio} = 1 − \text{Stable growth rate}/\text{Stable period return on equity} }$
> 
> Thus a firm with a 5 percent growth rate and a return on equity of 15 percent will have a stable period payout ratio of 66.67 percent.
> 
> The other characteristics of the firm in the stable period should be consistent with the assumption of stability. For instance, it is reasonable to assume that a high growth firm has a beta of 2.0, but unreasonable to assume that this beta will remain unchanged when the firm becomes stable. In fact, the rule of thumb that we developed ...—that stable period betas be between 0.8 and 1.2—is worth repeating here. Similarly, the return on equity, which can be high during the initial growth phase, should come down to levels commensurate with a stable firm in the stable growth phase. What is a reasonable stable period return on equity? The industry average return on equity and the firm’s own stable period cost of equity provide useful information to make this judgment.
> 
> **Limitations of the Model** There are three problems with the two-stage dividend discount model; the first two would apply to any two-stage model, and the third is specific to the dividend discount model.
> 
> 1. The first practical problem is in defining the length of the extraordinary growth period. Since the growth rate is expected to decline to a stable level after this period, the value of an investment will increase as this period is made longer. While we did develop criteria that might be useful in making this judgment ..., it is difficult in practice to convert these qualitative considerations into a specific time period.
> 
> 2. The second problem with this model lies in the assumption that the growth rate is high during the initial period and is transformed overnight to a lower stable rate at the end of the period. While these sudden transformations in growth can happen, it is much more realistic to assume that the shift from high growth to stable growth happens gradually over time.
> 
> 3. The focus on dividends in this model can lead to skewed estimates of value for firms that are not paying out what they can afford to in dividends. In particular, we will underestimate the value of firms that accumulate cash and pay out too little in dividends.
> 
> **Firms Model Works Best For** Since the two-stage dividend discount model is based on two clearly delineated growth stages—high growth and stable growth—it is best suited for firms that are in high growth and expect to maintain that growth rate for a specific time period, after which the sources of the high growth are expected to disappear. One scenario, for instance, where this may apply is when a company has patent rights to a very profitable product for the next few years, and is expected to enjoy supernormal growth during this period. Once the patent expires, it is expected to settle back into stable growth. Another scenario where it may be reasonable to make this assumption about growth is when a firm is in an industry that is enjoying supernormal growth because there are significant barriers to entry (either legal or as a consequence of infrastructure requirements), which can be expected to keep new entrants out for several years.
> 
> The assumption that the growth rate drops precipitously from its level in the initial phase to a stable rate also implies that this model is more appropriate for firms with modest growth rates in the initial phase. For instance, it is more reasonable to assume that a firm growing at 7 percent in the high growth period will see its growth rate drop to 2 percent afterward than it is for a firm growing at 40 percent in the high-growth period.
> 
> Finally, the model works best for firms that maintain a policy of paying out residual cash flows (i.e., cash flows left over after debt payments and reinvestment needs have been met) as dividends.
> 
> ...
> 
> **Modifying the Model to Include Stock Buybacks** In recent years, firms in the United States have increasingly turned to stock buybacks as a way of returning cash to stockholders. Figure 13.3 presents the cumulative amounts paid out by firms in the form of dividends and stock buybacks from 1988 to 2010. The trend toward stock buybacks was very strong, especially in the 1990s. Even the banking crisis of 2008 created only a momentary blip in buybacks in 2009, before they returned in force in 2010.
> 
> What are the implications for the dividend discount model? Focusing strictly on dividends paid as the only cash returned to stockholders exposes us to the risk that we might be missing significant cash returned to stockholders in the form of stock buybacks. The simplest way to incorporate stock buybacks into a dividend discount model is to add them onto the dividends and compute an augmented payout ratio:
> 
> $\large{ \text{Augmented dividend payout ratio} = (\text{Dividends} + \text{Stock buybacks})/\text{Net income} }$
> 
> While this adjustment is straightforward, the resulting ratio for any one year can be skewed by the fact that stock buybacks, unlike dividends, are not smoothed out. In other words, a firm may buy back $3 billion in stock in one year, and not buy back stock for the next three years. Consequently, a much better estimate of the modified payout ratio can be obtained by looking at the average value over a four- or five-year period. In addition, firms may sometimes buy back stock as a way of increasing financial leverage. We could adjust for this by netting out new debt issued from the earlier calculation:
> 
> $\large{ \text{Augmented dividend payout} = (\text{Dividends} + \text{Stock buybacks} − \text{Long-term debt issues})/\text{Net income} }$
> 
> Adjusting the payout ratio to include stock buybacks will have ripple effects on estimated growth and the terminal value. In particular, the modified growth rate in earnings per share can be written as:
> 
> $\large{ \text{Augmented growth rate} = (1 − \text{Augmented payout ratio}) \times \text{Return on equity} }$
> 
> Even the return on equity can be affected by stock buybacks. Since the book value of equity is reduced by the market value of equity bought back, a firm that buys back stock can reduce its book equity (and increase its return on equity) dramatically. If we use this return on equity as a measure of the marginal return on equity (on new investments), we will overstate the value of a firm. Adding back stock buybacks in recent years to the book equity and reestimating the return on equity can sometimes yield a more reasonable estimate of the return on equity on investments.
> 
> **Valuing an Entire Market Using the Dividend Discount Model** All our examples of the dividend discount model so far have involved individual companies, but there is no reason why we cannot apply the same model to value a sector or even the entire market. The market price of the stock would be replaced by the cumulative market value of all of the stocks in the sector or market. The expected dividends would be the cumulated dividends of all these stocks, and could be expanded to include stock buybacks by all firms. The expected growth rate would be the growth rate in cumulated earnings of the index. There would be no need for a beta or betas, since you are looking at the entire market (which should have a beta of 1), and you could add the risk premium (or premiums) to the risk-free rate to estimate a cost of equity. You could use a two-stage model, where this growth rate is greater than the growth rate of the economy, but you should be cautious about setting the growth rate too high or the growth period too long, because it will be difficult for cumulated earnings growth of all firms in an economy to run ahead of the growth rate in the economy for extended periods.
> 
> Consider a simple example. Assume that you have an index trading at 700, and that the average dividend yield of stocks in the index is 5 percent. Earnings and dividends can be expected to grow at 4 percent a year forever, and the riskless rate is 5.4 percent. If you use a market risk premium of 4 percent, the value of the index can be estimated as follows:
> 
> Cost of equity = Riskless rate + Risk premium = 5.4% + 4% = 9.4%
>
> Expected dividends next year = (Dividend yield × Value of the index)(1 + Expected growth rate) = (.05 × 700)(1.04) = 36.4
> 
> Value of the index = Expected dividends next year/(Cost of equity − Expected growth rate) = 36.4/(.094 − .04) = 674
> 
> At its existing level of 700, the market is slightly overpriced.
> 
> **The Value of Growth**
> 
> Investors pay a premium when they acquire companies with high growth potential. This premium takes the form of higher price-earnings or price–book value ratios. While no one will contest the proposition that growth is valuable, it is possible to pay too much for growth. In fact, empirical studies that show low price-earnings ratio stocks earning return premiums over high price-earnings ratio stocks in the long term support the notion that investors overpay for growth. ...
> 
> **Estimating the Value of Growth** The value of the equity in any firm can be written in terms of three components:
> 
> ![Formula using 3 components of growth](/.attachments/valuation-valuing.three.components.png)
> 
> where, \
> $DPS_t$ = Expected dividends per share in year $t$ \
> $k_e$ = Cost of equity \
> $g_n$ = Growth rate forever after year $n$
> 
> Value of extraordinary growth = Value of the firm with extraordinary growth in first $n$ years – Value of the firm as a stable growth firm
> 
> Value of stable growth = Value of the firm as a stable growth firm − Value of firm with no growth
> 
> Assets in place = Value of firm with no growth
> 
> In making these estimates, though, we have to remain consistent. For instance, to value assets in place, you would have to assume that the entire earnings could be paid out in dividends, while the payout ratio used to value stable growth should be a stable period payout ratio.
> 
> ...
> 
> **H Model for Valuing Growth**
> 
> The H model is a two-stage model for growth, but unlike the classic two-stage model, the growth rate in the initial growth phase is not constant but declines linearly over time to reach the stable growth rate in steady state. This model was presented in Fuller and Hsia (1984).
> 
> **The Model** The model is based on the assumption that the earnings growth rate starts at a high initial rate ($g_a$) and declines linearly over the extraordinary growth period (which is assumed to last 2H periods) to a stable growth rate ($g_n$). It also assumes that the dividend payout and cost of equity are constant over time, and are not affected by the shifting growth rates.
> 
> ![Expected Growth in the H Model](/.attachments/valuation-expected.growth.h-model.png)
> 
> _Expected Growth in the H Model_
> 
> The value of expected dividends in the H model can be written as follows:
> 
> $\huge{ P_0 = \text{Stable growth} + \text{Extraordinary growth} }$
> 
> where,
> 
> $\large{ \text{Stable growth} = { {DPS_0 \times (1 + g_n)} \over {k_e - g_n} } }$
> 
> $\large{ \text{Extraordinary growth} = { {DPS_0 \times H \times (g_a - g_n)} \over {k_e - g_n} } }$
> 
> $P_0$ = Value of the firm now per share \
> $DPS_t$ = $DPS$ in year $t$ \
> $k_e$ = Cost of equity \
> $g_a$ = Growth rate initially
> $g_n$ = Growth rate at end of 2H years, applies forever after that
> 
> **Limitations** This model avoids the problems associated with the growth rate dropping precipitously from the high growth to the stable growth phase, but it does so at a cost. First, the decline in the growth rate is expected to follow the strict structure laid out in the model—it drops in linear increments each year based on the initial growth rate, the stable growth rate, and the length of the extraordinary growth period. While small deviations from this assumption do not affect the value significantly, large deviations can cause problems. Second, the assumption that the payout ratio is constant through both phases of growth exposes the model to an inconsistency—as growth rates decline, the payout ratio usually increases.
> 
> **Firms Model Works Best For** The allowance for a gradual decrease in growth rates over time may make this a useful model for firms that are growing rapidly right now, but where the growth is expected to decline gradually over time as the firms get larger and the differential advantage they have over their competitors declines. The assumption that the payout ratio is constant, however, makes this an inappropriate model to use for any firm that has low or no dividends currently. Thus, the model, by requiring a combination of high growth and high payout, may be quite limited in its applicability.
> 
> ...
> 
> **Three-Stage Dividend Discount Model**
> 
> The three-stage dividend discount model combines the features of the two-stage model and the H model. It allows for an initial period of high growth, a transitional period where growth declines, and a final stable growth phase. It is the most general of the models because it does not impose any restrictions on the payout ratio.
> 
> **The Model** This model assumes an initial period of stable high growth, a second period of declining growth, and a third period of stable low growth that lasts forever.
> 
> ![Expected Growth in the Three-Stage Dividend Discount Model](/.attachments/valuation-3-stage.growth.png)
> 
> _Expected Growth in the Three-Stage Dividend Discount Model_
> 
> The value of the stock is then the present value of expected dividends during the high-growth and the transitional periods, and of the terminal price at the start of the final stable growth phase.
> 
> $\huge{ P_0 = \text{High-growth phase} + \text{Transition} + \text{Stable growth phase} }$
> 
> [inject rest of formulas here]
> 
> where, \
> $EPS_t$ = Earnings per share in year $t$ \
> $DPS_t$ = Dividends per share in year $t$ \
> $g_a$ = Growth rate in high-growth phase (lasts $n1$ periods) \
> $g_n$ = Growth rate in stable phase \
> $\Pi_a$ = Payout ratio in high-growth phase \
> $\Pi_n$ = Payout ratio in stable growth phase \
> $k_e$ = Cost of equity in high growth ($g$), transition ($t$), and stable growth ($s$)
> 
> **Assumptions** This model removes many of the constraints imposed by other versions of the dividend discount model. In return, however, it requires a much larger number of inputs—year-specific payout ratios, growth rates, and betas. For firms where there is substantial noise in the estimation process, the errors in these inputs can overwhelm any benefits that accrue from the additional flexibility in the model.
> 
> **Firms Model Works Best For** This model’s flexibility makes it a useful model for any firm that in addition to changing growth over time is expected to change on other dimensions as well—in particular, payout policies and risk. It is best suited for firms that are growing at an extraordinary rate now and are expected to maintain this rate for an initial period, after which the differential advantage of the firm is expected to deplete leading to gradual declines in the growth rate to a stable growth rate. Practically speaking, this may be the more appropriate model to use for a firm whose earnings are growing at very high rates,4 are expected to continue growing at those rates for an initial period, but are expected to start declining gradually toward a stable rate as the firm become larger and loses its competitive advantages.
> 
> ...
> 
> **Issues in using the Dividend Discount Model**
> 
> The dividend discount model’s primary attraction is its simplicity and its intuitive logic. There are many analysts, however, who view its results with suspicion because of limitations that they perceive it to possess. The model, they claim, is not really useful in valuation except for a limited number of stable, high-dividend-paying stocks.
> 
> **Valuing Non-Dividend-Paying or Low-Dividend-Paying Stocks**
> 
> The conventional wisdom is that the dividend discount model cannot be used to value a stock that pays low or no dividends. It is wrong. If the dividend payout ratio is adjusted to reflect changes in the expected growth rate, a value can be obtained even for non-dividend-paying firms. Thus, a high-growth firm, paying no dividends currently, can still be valued based on dividends that it is expected to pay out when the growth rate declines. If the payout ratio is not adjusted to reflect changes in the growth rate, however, the dividend discount model will underestimate the value of non-dividend-paying or low-dividend-paying stocks.
> 
> **Is the Model Too Conservative in Estimating Value?**
> 
> A standard critique of the dividend discount model is that it provides too conservative an estimate of value. This criticism is predicated on the notion that the value is determined by more than the present value of expected dividends. For instance, it is argued that the dividend discount model does not reflect the value of “unutilized assets.” There is no reason, however, that these unutilized assets cannot be valued separately and added on to the value from the dividend discount model. Some of the assets that are supposedly ignored by the dividend discount model, such as the value of brand names, can be dealt with fairly simply within the context of the model.
> 
> A more legitimate criticism of the model is that it does not incorporate other ways of returning cash to stockholders (such as stock buybacks). If you use the augmented version of the dividend discount model, this criticism can also be countered.
> 
> **Contrarian Nature of the Model**
> 
> The dividend discount model is also considered by many to be a contrarian model. As the market rises, fewer and fewer stocks, they argue, will be found to be undervalued using the dividend discount model. This is not necessarily true. If the market increase is due to an improvement in economic fundamentals, such as higher expected growth in the economy and/or lower interest rates, there is no reason, a priori, to believe that the values from the dividend discount model will not increase by an equivalent amount. If the market increase is not due to fundamentals, the dividend discount model values will not follow suit, but that is more a sign of strength than weakness. The model is signaling that the market is overvalued relative to dividends and cash flows, and the cautious investor will pay heed.
> 
> 
> **Tests of the Dividend Discount Model**
> 
> The ultimate test of a model lies in how well it works at identifying undervalued and overvalued stocks. The dividend discount model has been tested and the results indicate that it does, in the long term, provide for excess returns. It is unclear, however, whether this is because the model is good at finding undervalued stocks or because it proxies for well-known empirical irregularities in returns relating to price-earnings ratios and dividend yields.
> 
> ...[^35] 

##### Free Cashflow to Equity Model

> The free cash flow to equity model does not represent a radical departure from the traditional dividend discount model. In fact, one way to describe a free cash flow to equity model is that it represents a model where we discount potential dividends rather than actual dividends. Consequently, the three versions of the FCFE valuation model presented in this section are simple variants on the dividend discount model, with one significant change—free cash flows to equity replace dividends in the models.
> 
> **Underlying Principle**
> 
> When we replace the dividends with FCFE to value equity, we are doing more than substituting one cash flow for another. We are implicitly assuming that the FCFE will be paid out to stockholders. There are two consequences:
> 
> 1. There will be no future cash buildup in the firm, since the cash that is available after debt payments and reinvestment needs is assumed to be paid out to stockholders each period.
> 
> 2. The expected growth in FCFE will include growth in income from operating assets and not growth in income from increases in marketable securities. This follows directly from the last point.
> 
> How does discounting free cash flows to equity compare with the augmented dividend discount model, where stock buybacks are added back to dividends and discounted? You can consider stock buybacks to be the return of excess cash accumulated largely as a consequence of not paying out their FCFE as dividends. Thus, FCFE represents a smoothed-out measure of what companies can return to their stockholders over time in the form of dividends and stock buybacks.
> 
> **Estimating Growth in FCFE**
> 
> Free cash flows to equity, like dividends, are cash flows to equity investors and you could use the same approach that you used to estimate the fundamental growth rate in dividends per share:
> 
> Expected growth rate = Retention ratio × Return on equity
> 
> The use of the retention ratio in this equation implies that whatever is not paid out as dividends is reinvested back into the firm. There is a strong argument to be made, though, that this is not consistent with the assumption that free cash flows to equity are paid out to stockholders, which underlies FCFE models. It is far more consistent to replace the retention ratio with the equity reinvestment rate, which measures the percent of net income that is invested back into the firm.
> 
> $\large{ \text{Equity reinvestment rate} = { { \text{Capital Expenditures} - \text{Depreciation} + \text{Change in noncash working capital} - \text{Net debt issues} } \over \text{Net income} } }$
> 
> When discounting FCFE, it is safest to separate the existing cash balance from the operating assets of the firm, to value the equity in the operating assets and then add on the existing cash balance. Consequently, the return on equity can also have to be modified to reflect the fact that the conventional measure of the return includes interest income from cash and marketable securities in the numerator and the book value of equity also includes the value of the cash and marketable securities. In the FCFE model, there is no excess cash left in the firm and the return on equity should measure the return on noncash investments. You could construct a modified version of the return on equity that measures this:
> 
> $\large{ \text{Noncash ROE} = { { \text{Net income} − \text{After-tax income from cash and marketable securities} } \over { \text{Book value of equity} − \text{Cash and marketable securities} } } }$
> 
> The product of the equity reinvestment rate and the modified ROE will yield the expected growth rate in FCFE:
> 
> Expected growth in FCFE = Equity reinvestment rate × Noncash ROE
> 
> **Constant Growth FCFE Model**
> 
> The constant growth FCFE model is designed to value firms that are growing at a stable growth rate and are hence in steady state.
>
> **The Model** The value of equity, under the constant growth model, is a function of the expected FCFE in the next period, the stable growth rate, and the required rate of return.
> 
> $$\huge{ \text{Value} = { FCFE_1 \over { k_e - g_n } } }$$
> 
> where \
> Value = Value of stock today \
> $FCFE_1$ = Expected $FCFE$ next year \
> $k_e$ = Cost of equity of the firm \
> $g_n$ = Growth rate in $FCFE$ for the firm forever
> 
> **Caveats** The model is very similar to the Gordon growth model in its underlying assumptions and works under some of the same constraints. The growth rate used in the model has to be reasonable, relative to the nominal growth rate in the economy in which the firm operates. As a general rule, a stable growth rate cannot exceed the growth rate of the economy in which the firm operates.
> 
> The assumption that a firm is in steady state also implies that it possesses other characteristics shared by stable firms. This would mean, for instance, that capital expenditures are not disproportionately large, relative to depreciation, and the firm is of average risk. (If the capital asset pricing model is used, the beta of the equity should be close to 1.) To estimate the reinvestment for a stable growth firm, you can use one of two approaches:
> 
> 1. You can use the typical reinvestment rates for firms in the industry to which the firm belongs. A simple way to do this is to use the average capital expenditure to depreciation ratio for the industry (or better still, just stable firms in the industry) to estimate a normalized capital expenditure for the firm. The danger of doing so is that the industry itself may not be steady state and the average will therefore be skewed (high or low).
> 
> 2. Alternatively, you can use the relationship between growth and fundamentals to estimate the required reinvestment. The expected growth in net income can be written as:
> 
>    Expected growth rate in net income = Equity reinvestment rate × Return on equity
> 
>    This allows us to estimate the equity reinvestment rate:
> 
>    Equity reinvestment rate = Expected growth rate/Return on equity
> 
>    To illustrate, a firm with a stable growth rate of 4 percent and a return on equity of 12 percent would need to reinvest about one-third of its net income back into net capital expenditures and working capital needs. Put differently, the free cash flows to equity should be two-thirds of net income.
> 
> **Best Suited for Firms** This model, like the stable growth dividend discount model, is best suited for firms growing at a rate comparable to or lower than the nominal growth in the economy. It is, however, a better model to use than the dividend discount model for stable firms that pay out dividends that are unsustainably high (because they exceed FCFE by a significant amount) or are significantly lower than the FCFE. Note, though, that if the firm is stable and pays out its FCFE as dividends the value obtained from this model will be the same as the one obtained from the Gordon growth model.
> 
> ...
> 
> **Two-Stage FCFE Model**
> 
> The two-stage FCFE model is designed to value a firm that is expected to grow much faster than a stable firm in the initial period and at a stable rate after that.
> 
> **The Model** The value of any stock is the present value of the FCFE per year for the extraordinary growth period plus the present value of the terminal price at the end of the period.
> 
> $$\large{ \text{Value} = { \text{PV of FCFE} + \text{PV of terminal price} } }$$
> 
> $$\huge{ = \sum_{t=1}^{t=n} { { FCFE_t \over { (1 + k_{e,g})^t } } + { P_n \over { (1 + k_{e,g})^n } } } }$$
> 
> where \
> $FCFE_t$ = Free cash flow to equity in year $t$ \
> $P_n$ = Price at the end of the extraordinary growth period \
> $k_e$ = Cost of equity in high growth ($g$) and stable growth ($s$) periods
> 
> The terminal price is generally calculated using the infinite growth rate model:
> 
> $$\large{ P_n = { FCFE_{n+1}/{ (k_{e,s} − g_n)} } }$$
> 
> where $g_n$ = Growth rate after terminal year forever
> 
> **Calculating the Terminal Price** The same caveats that apply to the growth rate for the stable growth rate model, described in the previous section, apply here as well. In addition, the assumptions made to derive the free cash flow to equity after the terminal year have to be consistent with this assumption of stability. For instance, while capital spending may be much greater than depreciation in the initial high-growth phase, the difference should narrow as the firm enters its stable growth phase. We can use the two approaches described for the stable growth model—industry average capital expenditure requirements or the fundamental growth equation (equity reinvestment rate = g/ROE)—to make this estimate.
> 
> The beta and debt ratio may also need to be adjusted in stable growth to reflect the fact that stable growth firms tend to have average risk (betas closer to 1) and use more debt than high-growth firms.
> 
> **Firms Model Works Best For** This model makes the same assumptions about growth as the two-stage dividend discount model (i.e., that growth will be high and constant in the initial period and drop abruptly to stable growth after that). It is different because of its emphasis on FCFE rather than dividends. Consequently, it provides much better results than the dividend discount model when valuing firms which either have dividends which are unsustainable (because they are higher than FCFE) or which pay less in dividends than they can afford to (i.e., dividends are less than FCFE).
> 
> ...
> 
> **E Model—A Three-Stage FCFE Model** 
> 
> The E model is designed to value firms that are expected to go through three stages of growth—an initial phase of high growth rates, a transitional period in which the growth rate declines, and a steady-state period in which growth is stable.
> 
> **The Model** The E model calculates the present value of expected free cash flow to equity over all three stages of growth:
> 
> $$\huge{ P_0 = { \sum_{t=1}^{t=n1} { { FCFE_t \over { (1 + k_{e})^t } } } } + { \sum_{t=n1+1}^{t=n2} { { FCFE_t \over { (1 + k_{e})^t } } } } + { P_{n2} \over { (1 + k_{e})^{n2} } } }$$
> 
> where \
> $P_0$ = Value of the stock today \
> $FCFE_t$ = Free cash flow to equity in year $t$ \
> $k_e$ = Cost of equity \
> $P_{n2}$ = Terminal price at the end of transitional period = $FCFE_{n2+1}/(k_e - g_n)$ \
> $n1$ = End of initial high growth period \
> $n2$ = End of transition period
> 
> **Caveats in Using Model** Since the model assumes that the growth rate goes through three distinct phases—high growth, transitional growth, and stable growth—it is important that assumptions about other variables are consistent with these assumptions about growth.
> 
> ***Capital Spending versus Depreciation*** It is reasonable to assume that as the firm goes from high growth to stable growth, the relationship between capital spending and depreciation will change. In the high-growth phase, capital spending is likely to be much larger than depreciation. In the transitional phase, the difference is likely to narrow and the difference between capital spending and depreciation will be lower still in stable growth, reflecting the lower expected growth rate.
> 
> ![Three-Stage FCFE Model: Reinvestment Needs](/.attachments/valuation-3-stage.fcfe.png)
> 
> _Three-Stage FCFE Model: Reinvestment Needs_
> 
> ***Risk*** As the growth characteristics of a firm change, so do its risk characteristics. In the context of the CAPM, as the growth rate declines the beta of the firm can be expected to change. The tendency of betas to converge toward one in the long term has been confirmed by empirical observation of portfolios of firms with high betas. Over time, as these firms get larger and more diversified, the average betas of these portfolios move toward 1.
> 
> **Firms Model Works Best For** Since the model allows for three stages of growth and for a gradual decline from high to stable growth, it is the appropriate model to use to value firms with very high growth rates currently. The assumptions about growth are similar to the ones made by the three-stage dividend discount model, but the focus is on FCFE instead of dividends, making it more suited to value firms whose dividends are significantly higher or lower than the FCFE. [^36]

#### Firm Valuation Models

> @ pg. 380 --> 383 [^37]

##### Cost of Capital

> @ pg. 383 --> 398 [^37]

##### Adjusted Present Value

> @ pg. 398 --> 419 [^37]

##### Excess Returns

> Banks, insurance companies, and other financial service firms pose particular challenges for an analyst attempting to value them for two reasons. The first is that the nature of their businesses makes it difficult to define both debt and reinvestment, making the estimation of cash flows much more messy. The other is that they tend to be heavily regulated, and the effects of regulatory requirements on value have to be considered.
> 
> ...
> 
> Any firm that provides financial products and services to individuals or other firms can be categorized as a financial service firm. We would break down financial service businesses into four groups from the perspective of how they make their money. A bank makes money on the spread between the interest it pays to those from whom it raises funds and the interest it charges those who borrow from it, and from other services it offers its depositors and its lenders. Insurance companies make their income in two ways. One is through the premiums they receive from those who buy claims from them, and the other is income from the investment portfolios that they maintain to service these claims. An investment bank provides advice and supporting products for non–financial service firms who are desirous of raising capital or to consummate deals such as acquisitions or divestitures. Investment firms provide investment advice or manage portfolios for clients. Their income comes from advisory fees for the advice, and management and sales fees for investment portfolios.
> 
> ...
> 
> **Debt: Raw Material or Source of Capital**
> 
> When we talk about capital for non–financial service firms, we tend to talk about both debt and equity. A firm raises funds from both equity investors and bondholders (and banks) and uses these funds to make its investments. When we value the firm, we value the assets owned by the firm, rather than just the value of its equity.
> 
> With a financial service firm, debt takes on a different connotation. Rather than view debt as a source of capital, most financial service firms view it as a raw material. In other words, debt is to a bank is akin to steel for an automobile company, something to be molded into other financial products that can then be sold at a higher price and yield a profit. Consequently, capital at financial service firms is more narrowly defined as including only equity capital. This definition of capital is reinforced by the regulatory authorities who count only equity or equity-like financing in regulatory capital.
> 
> The definition of what comprises debt also is murkier with a financial service firm than it is with a non–financial service firm. For instance, should deposits made by customers into their checking accounts at a bank be treated as debt by that bank? Especially on interest-bearing deposits, there is little distinction between a deposit and debt issued by the bank. If we do categorize this as debt, the operating income for a bank should be measured prior to interest paid to depositors, which would be problematic since interest expenses are usually the biggest single expense item for a bank.
> 
> **The Regulatory Overlay**
> 
> Financial service firms are heavily regulated all over the world, though the extent of the regulation varies from country to country. In general, these regulations take three forms. First, banks and insurance companies are required to maintain capital ratios to ensure that they do not expand beyond their means and put their claimholders or depositors at risk. Second, financial service firms are often constrained in terms of where they can invest their funds. For instance, the Glass-Steagall Act in the United States restricted commercial banks from investment banking activities and from taking active equity positions in manufacturing firms for decades after the Great Depression. Third, entry of new firms into the business is often restricted by the regulatory authorities, as are mergers between existing firms.
> 
> _Why does this matter? From a valuation perspective, assumptions about growth are linked to assumptions about reinvestment. With financial service firms, these assumptions have to be scrutinized to ensure that they pass regulatory constraints. There might also be implications for how we measure risk at financial service firms. If regulatory restrictions are changing or are expected to change, it adds a layer of uncertainty to the future, which can have an effect on value._
> 
> **Reinvestment at Financial Services Firms**
> 
> ...
> 
> Consider net capital expenditures first. Unlike manufacturing firms that invest in plant, equipment, and other fixed assets, financial service firms invest in intangible assets such as brand name and human capital. Consequently, their investments for future growth often are categorized as operating expenses in accounting statements. Not surprisingly, the statement of cash flows to a bank show little or no capital expenditures and correspondingly low depreciation. With working capital, we run into a different problem. If we define working capital as the different between current assets and current liabilities, a large proportion of a bank’s balance sheet would fall into one or the other of these categories. Changes in this number can be both large and volatile and may have no relationship to reinvestment for future growth.
> 
> As a result of this difficulty in measuring reinvestment, we run into two practical problems in valuing these firms. The first is that we cannot estimate cash flows without estimating reinvestment. In other words, ***if we cannot identify net capital expenditures and changes in working capital, we cannot estimate cash flows, either***. The second is that estimating expected future growth becomes more difficult if the reinvestment rate cannot be measured.
> 
> **General Framework for Valuation**
> 
> Given the unique role of debt at financial service firms, the regulatory restrictions that they operate under, and the difficulty of identifying reinvestment at these firms, how can we value these firms? ... First, it makes far more sense to value equity directly at financial service firms, rather than the entire firm. Second, we either need a measure of cash flow that does not require us to estimate reinvestment needs or need to redefine reinvestment to make it more meaningful for a financial service firm.
> 
> **Equity versus Firm**
> 
> We noted the distinction between valuing a firm and valuing the equity in the firm. We value firms by discounting expected cash flows prior to debt payments at the weighted average cost of capital. We value equity by discounting cash flows to equity investors at the cost of equity.
> 
> Estimating cash flows prior to debt payments or a weighted average cost of capital is problematic when debt and debt payments cannot be easily identified, which, as we argued earlier, is the case with financial service firms. Equity can be valued directly, however, by discounting cash flows to equity at the cost of equity. Consequently, we would argue for the latter approach for financial service firms. We would extend this argument to multiples as well. Equity multiples such as price-to-earnings or price-to-book ratios are a much better fit for financial service firms than value multiples such as EV to EBITDA.
> 
> **Estimating Cash Flows**
> 
> To value the equity in a firm, we normally estimate the free cash flow to equity. ... we defined the free cash flow to equity thus:
> 
> $\large{ \text{Free cash flow to equity} = \text{Net income} − \text{Net capital expenditures} − \text{Change in noncash working capital} − (\text{Debt repaid} − \text{New debt issued}) }$
> 
> If we cannot estimate the net capital expenditures or noncash working capital, we clearly cannot estimate the free cash flow to equity. Since this is the case with financial service firms, we have two choices. ***The first is to use dividends as cash flows to equity, and assume that firms over time pay out their free cash flows to equity as dividends***. Since dividends are observable, we therefore do not have to confront the question of how much firms reinvest. ***The second is to adapt the free cash flow to equity measure to allow for the types of reinvestment that financial service firms***. For instance, given that banks operate under a regulatory capital ratio constraint, it can be argued that these firms have to reinvest in regulatory capital in order to be able to grow in the future.
> 
> ...
> 
> **Basic Model** Given the difficulty associated with defining total capital in a financial service firm, it makes far more sense to focus on just equity when using an excess return model to value a financial service firm. The value of equity in a firm can be written as the sum of the equity invested in a firm’s current investments and the expected excess returns to equity investors from these and future investments.
> 
> $\large{ \text{Value of equity} = \text{Equity capital invested currently} + \text{Present value of expected excess returns to equity investors} }$
> 
> The most interesting aspect of this model is its focus on excess returns. A firm that invests its equity and earns just the fair-market rate of return on these investments should see the market value of its equity converge on the equity capital currently invested in it. A firm that earns a below-market return on its equity investments will see its equity market value dip below the equity capital currently invested.
> 
> The other point that has to be emphasized is that this model considers expected future investments as well. Thus it is up to the analyst using the model to forecast not only where the financial service firm will direct its future investments but also the returns it will make on those investments.
> 
> **Inputs to Model** There are two inputs needed to value equity in the excess return model. The first is a measure of equity capital currently invested in the firm. The second and more difficult input is the expected excess returns to equity investors in future periods.
> 
> The equity capital invested currently in a firm is usually measured as the book value of equity in the firm. While the book value of equity is an accounting measure and is affected by accounting decisions, it should be a much more reliable measure of equity invested in a financial service firm than in a manufacturing firm for two reasons. The first is that the assets of a financial service firm are often financial assets that are marked up to market; the assets of manufacturing firms are real assets and deviations between book and market value are usually much larger. The second is that depreciation, which can be a big factor in determining book value for manufacturing firms, is often negligible at financial service firms. Notwithstanding this, the book value of equity can be affected by stock buybacks and extraordinary or one-time charges. The book value of equity for financial service firms that buy back stock or take extraordinary charges may understate the equity capital invested in the firm.
> 
> The excess returns, defined in equity terms, can be stated in terms of the return on equity and the cost of equity:
> 
> $\large{ \text{Excess equity return} = (\text{Return on equity} – \text{Cost of equity})(\text{Equity capital invested}) }$
> 
> Here again, we are assuming that the return on equity is a good measure of the economic return earned on equity investments. When analyzing a financial service firm, we can obtain the return on equity from the current period and past periods, but the return on equity that is required is the expected future return. This requires an analysis of the firm’s strengths and weaknesses as well as the competition faced by the firm and changes in regulatory capital requirements.
> 
> In making estimates of expected equity return spreads, we have to allow for the fact that the presence of large excess returns is likely to attract competition. These excess returns will fade over time and this should be reflected in the forecasts.
> [^5]

## Relative Valuation Model

![Relative Valuation Process](/.attachments/valuation-relative.valuation.process-2.png)

_Relative Valuation Process_

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
> $\huge{ \text{Relative PE} = { { \text{Current PE ratio}_f }/{ \text{Current PE ratio}_m }  } }$
> 
> where, \
> $f$ = firm \
> $m$ = market
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
> $\huge{ P_0 = { BV_0 \times ROE \times \text{Payout ratio} \over { k_e - g_n } } }$
> 
> Rewriting in terms of PBV ratio,
> 
> $\huge{ { P_0 / BV_0 } = PBV = { { ROE \times \text{Payout ratio} } \over { k_e - g_n} } }$
> 
> The PBV ratio is an increasing function of the return on equity, the payout ratio, and the growth rate, and a decreasing function of the riskiness of the firm.
> 
> $\huge{ g = (1 - \text{Payout ratio}) \times ROE}$
> 
> This formulation can be simplified even further by relating growth to the return on equity:
> 
> $\huge{ { P_0 / BV_0 } = { { ROE - g_n} \over { k_e - g_n } } }$
> 
> The price–book value ratio of a stable firm is determined by the differential between the return on equity and its cost of equity. If the return on equity exceeds the cost of equity, the price will exceed the book value of equity; if the return on equity is lower than the cost of equity, the price will be lower than the book value of equity.
> 
> ...
> 
> **PBV Ratio for a High-Growth Firm**
> 
> The price–book value ratio for a high-growth firm can also be related to fundamentals. In the special case of the two-stage dividend discount model, this relationship can be made explicit fairly simply. The value of equity of a high-growth firm in the two-stage dividend discount model can be written as:
> 
> $\huge{ \text{Value of equity} = \text{Present value of expected dividends} + \text{Present value of terminal price} }$
> 
> When the growth rate is assumed to be constant after the initial high-growth phase, the dividend discount model can be written as follows:
> 
$$\huge{ 
P_0 = { { EPS_0 \times PR \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{e,h}^n } } } \right] } \over { k_{e,h} - g } } + { { EPS_0 \times PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,s} - g_n)(1 + k_{e,h})^n } }
}$$
> 
> where, \
> $g$ = Growth rate in the first $n$ years \
> $PR$ = Payout ratio in the first $n$ years \
> $g_n$ = Growth rate after $n$ years forever (stable growth rate) \
> $PR_n$ = Payout ratio after $n$ years for the stable firm \
> $k_e$ = Cost of equity ($h$: high-growth period; $s$: stable-growth period)
> 
> Rewriting $EPS_0$ in terms of the return on equity, $EPS_0$ = $BV_0 \times ROE$, and bringing $BV_0$ to the left-hand side of the equation, we get:
> 
$$\huge{
   { { P_0 \over BV_0 } = { { ROE \times { { PR \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{e,h}^n } } } \right] } \over { k_{e,h} - g } } } + { ROE \times { { PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,s} - g_n)(1 + k_{e,h})^n } } } } }
}$$
> 
> where $ROE$ is the return on equity and $k_e$ is the cost of equity.
> 
> ...
> 
> ... firms may not always pay out what they can afford to and recommended that the free cash flows to equity be substituted in for the dividends in those cases. You can, in fact, modify the equation to state the price-to-book ratio in terms of free cash flows to equity.
> 
$$\huge{
   { { P_0 \over BV_0 } = { { ROE \times { { FE_h \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{e,h}^n } } } \right] } \over { k_{e,h} - g } } } + { ROE \times { FE_n \times { PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,s} - g_n)(1 + k_{e,h})^n } } } } }
}$$
> 
> where,\
> $FE_h$ is $FCFE \over Earnings$ for high growth period \
> $FE_n$ is $FCFE \over Earnings$ for stable period
> 
> The only substitution that we have made is the replacement of the payout ratio by the FCFE as a percent of earnings.
> 
> **PBV Ratios and Return on Equity**
> 
> The ratio of price to book value is strongly influenced by the return on equity. A lower return on equity affects the price–book value ratio directly through the formulation specified in the prior section and indirectly by lowering the expected growth or payout.
> 
> $\text{Expected growth rate} = \text{Retention ratio} \times \text{Return on equity}$
> 
> ...
> 
> **Determinants of Return on Equity** The difference between return on equity and the cost of equity is a measure of a firm’s capacity to earn excess returns in the business in which it operates. Corporate strategists have examined the determinants of the size and expected duration of these excess profits (and high ROE) using a variety of frameworks. One of the better known is the “five forces of competition” framework developed by Porter (1980). In his approach, competition arises not only from established producers producing the same product but also from suppliers of substitutes and from potential new entrants into the market. The illustration below summarizes the five forces of competition.
> 
> ![Five Forces of Competition](/.attachments/valuation-pbv.five.forces.of.competition.png)
> 
> _Five Forces of Competition and Return on Equity ***Source:*** Porter (1980)._
> 
> In Porter’s framework, a firm is able to maintain a high return on equity because there are significant barriers to entry by new firms or because the firm has significant advantages over its competition. The analysis of the return on equity of a firm can be made richer and much more informative by examining the competitive environment in which it operates. There may also be clues in this analysis to the future direction of the return on equity. Value investors have their own variant on this theme that they call the “moat.” A firm with strong and sustainable competitive advantages is considered to have a strong moat, which in turn makes it more valuable. In the framework developed in this chapter, the strength of the moat is measured by the level of the ROE and how long it can be maintained.
> 

#### Applications of Price-Book Value Ratios

> **PBV Ratios for a Market**
> 
> The price-to-book value ratio for an entire market is determined by the same variables that determine the price-to-book value ratio for an individual firm. Other things remaining equal, therefore, you would expect the price-to-book ratio for a market to go up as the equity return spread (ROE minus cost of equity) earned by firms in the market increases. Conversely, you would expect the price-to-book ratio for the market to decrease as the equity return spread earned by firms decreases.
> 
> ...
> 
> **Comparisons across Firms in a Sector**
> 
> Price–book value ratios vary across firms for a number of reasons—different expected growth, different payout ratios, different risk levels, and most importantly, different returns on equity. Comparisons of price–book value ratios across firms that do not take into account these differences are likely to be flawed.
> 
> The most common approach to estimating PBV ratios for a firm is to choose a group of comparable firms, to calculate the average PBV ratio for this group, and to base the PBV ratio estimate for a firm on this average. The adjustments made to reflect differences in fundamentals between the firm being valued and the comparable group are usually made subjectively. There are several problems with this approach. First, the definition of a comparable firm is essentially a subjective one. The use of other firms in the industry as the control group is often not a complete solution because firms within the same industry can have very different business mixes and risk and growth profiles. There is also plenty of potential for bias. Second, even when a legitimate group of comparable firms can be constructed, differences will continue to persist in fundamentals between the firm being valued and this group. Adjusting for differences subjectively does not provide a satisfactory solution to this problem, since these judgments are only as good as the analysts making them.
> 
> Given the relationship between price–book value ratios and returns on equity, it should not be surprising to see firms that have high returns on equity sell for well above book value and firms that have low returns on equity sell at or below book value. The firms that should draw attention from investors are those that provide mismatches of price–book value ratios and returns on equity—low PBV ratios and high ROE, or high PBV ratios and low ROE. There are two ways in which we can bring home these mismatches—a matrix approach and a sector regression.
> 
> **Matrix Approach** If the essence of misvaluation is finding firms that have price-to-book ratios that do not go with their equity return spreads, the mismatch can be brought home by plotting the price-to-book value ratios of firms against their excess returns, i.e., the difference between return and cost of equity. Illustration below presents such a plot.
> 
> ![Price-to-Book Ratios and Return on Equity](/.attachments/valuation-price.to.book.ratios.and.roe.png)
> 
> _Price-to-Book Ratios and Return on Equity_
> 
> If we assume that firms within a sector have similar costs of equity, we could replace the equity return spread with the raw return on equity. Though we often use current returns on equity in practice, the matrix is based on expected returns on equity in the future.
> 
> **Regression Approach** If the price-to-book ratio is largely a function of the return on equity, we could regress the former against the latter:
> 
> $PBV = a + b\text{ ROE}$
> 
> If the relationship is strong and linear, we could use this regression to obtain predicted price-to-book ratios for all of the firms in the sector, separating out those firms that are undervalued from those that are overvalued.
> 
> This regression can be enriched in two ways. The first is to allow for nonlinear relationships between price-to-book and return on equity; this can be done either by transforming the variables (natural logs, exponentials, etc.) or by running nonlinear regressions. The second is to expand the regression to include other independent variables such as risk and growth.[^12]

#### Value-to-Book Ratios

> Instead of relating the market value of equity to the book value of equity, the value-to-book ratio relates the firm value to the book value of capital of the firm. Consequently, it can be viewed as the firm value analogue to the price-to-book ratio.
> 
> **Definition**
> 
> The value-to-book ratio is obtained by dividing the market value of both debt and equity by the book value of capital invested in a firm:
> 
> $\huge{ \text{Value-to-book ratio} = { \text{Market value of equity} + \text{Market value of debt} } \over { \text{Book value of equity} + \text{Book value of debt} } }$
> 
> If the market value of debt is unavailable, the book value of debt can be used in the numerator as well. Needless to say, debt has to be consistently defined for both the numerator and denominator. For instance, if you choose to convert operating leases to debt for computing market value of debt, you have to add the present value of operating leases to the book value of debt as well.
>
> There are two common variants of this multiple that do not pass the consistency test. One uses the book value of assets, which will generally exceed the book value of capital by the magnitude of current liabilities, in the denominator. This will result in price-to-book ratios that are biased down for firms with substantial current liabilities. The other uses the enterprise value in the numerator, with cash netted from the market values of debt and equity. Since the book value of equity incorporates the cash holdings of the firm, this will also bias the multiple down. If you decide to use enterprise value in the numerator, you would need to net cash out of the denominator as well. Netting out cash from book capital creates a measure called invested capital:
> 
> $\huge{ \text{Invested capital} = \text{BV of equity} + \text{BV of debt} – Cash }$
> 
> 
> In addition, the multiple may need to be adjusted for a firm’s cross holdings just as EV/EBITDA multiples were. ... The adjustment ... will require that you net out the portion of the market value and book value of equity that is attributable to subsidiaries.
> 
> **Analysis**
> 
> The value-to-book ratio is a firm value multiple. To analyze it, we go back to a free cash flow to the firm valuation model, and use it to value a stable growth firm:
> 
> $\huge{ \text{Enterprise value} = { FCFF_1 \over (\text{Cost of capital} - g) } }$
> 
> Substituting in $FCFF = EBIT_1(1 – t)(1 – \text{Reinvestment rate})$, we get:
> 
> $\huge{ \text{Enterprise value} = { {EBIT_1(1 - t)(1 - \text{Reinvestment rate})} \over (\text{Cost of capital} - g) } }$
> 
> Dividing both sides by the book value of capital, we get:
> 
> $\huge{ { \text{Enterprise value} \over \text{Invested capital} } = { { ROC(1 - \text{Reinvestment rate}) } \over (\text{Cost of capital} - g) } }$
> 
> The value-to-book ratio is fundamentally determined by its return on capital—firms with high returns on capital tend to have high value-to-book ratios. In fact, the determinants of value-to-book mirror the determinants of price-to-book equity, but we replace equity measures with firm value measures—the ROE with the ROC, the cost of equity with the cost of capital, and the payout ratio with (1 – Reinvestment rate). In fact, if we substitute in the fundamental equation for the reinvestment rate:
> 
> $\huge{ \text{Reinvestment rate} = g/ROC }$
> 
> $\huge{ { \text{Enterprise value} \over \text{Invested capital} } = { { (ROC - g) } \over (\text{Cost of capital} - g) } }$
>
> The analysis can be extended to cover high-growth firms, with the value-to-book capital ratio determined by the return on capital, cost of capital, growth rate, and reinvestment—in the high growth and stable growth periods:
> 
> $\huge{ { \text{Enterprise value}_0 \over \text{Invested capital}_0 } = { { ROC_h \times { { (1 - RIR_h) \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{c,h}^n } } } \right] } \over { k_{c,h} - g } } } + { ROC_h \times { (1 - RIR_s) \times { PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{c,s} - g_n)(1 + k_{c,h})^n } } } } }$
> 
> where,\
> $ROC$ = Return on capital ($h$: high-growth; $s$: stable period) \
> $RIR$ = Reinvestment rate ($h$: high-growth; $s$: stable period) \
> $k_c$ = Cost of capital ($h$: high-growth; $s$: stable period)
> 
> **Application**
> 
> The value-to-book ratios can be compared across firms just as the price-to-book value of equity ratio was in the preceding section. The key variable to control for in making this comparison is the return on capital. The value matrix developed for price-to-book ratios can be adapted for the value-to-book ratio shown in illustration below. Firms with high return on capital will tend to have high value-to-book value ratios, whereas firms with low return on capital will generally have lower value-to-book ratios.
> 
> ![Valuation Matrix: Value to Book and Excess Returns](/.attachments/valuation-value.matrix.png)
> 
> _Valuation Matrix: Value to Book and Excess Returns_
> 
> This matrix also yields an interesting link to a widely used value enhancement measure—economic value added (EVA). One of the biggest sales pitches for EVA, which is computed as the product of the return spread (ROC minus cost of capital) and capital invested, is its high correlation with market value added (MVA) which is defined as the difference between market value and book value of capital. This is not surprising, since MVA is a variant on the value-to-book ratio and EVA is a variant on the return spread.
>
> Is the link between value-to-book and return on capital stronger or weaker than the link between price-to-book and return on equity?
> 
> ...
> 
> If the results from using value-to-book and price-to-book ratios parallel each other, why would you choose to use one multiple over the other? The case for using value-to-book ratios is stronger for firms that have high and/or shifting leverage.
> 
> Firms can use leverage to increase their returns on equity, but in the process they also increase the volatility in the measure: in good times they report very high returns on equity, and in bad times, very low or negative returns on equity. For such firms, the value-to-book ratio and the accompanying return on capital will yield more stable and reliable estimates of relative value. In addition, the value-to-book ratio can be computed even for firms that have negative book values of equity and is thus less likely to be biased.[^12]

### Revenue Multiples

> A revenue multiple measures the value of the equity or a business relative to the revenues that it generates. As with other multiples, other things remaining equal, firms that trade at low multiples of revenues are viewed as cheap relative to firms that trade at high multiples of revenues.
> 
> Revenue multiples have proved attractive to analysts for a number of reasons. First, unlike earnings and book value ratios, which can become negative for many firms and thus not meaningful, revenue multiples are available even for the most troubled firms and for very young firms. Thus, the potential for bias created by eliminating firms in the sample is far lower. Second, unlike earnings and book value, which are heavily influenced by accounting decisions on depreciation, inventory, research and development (R&D), acquisition accounting, and extraordinary charges, revenue is relatively difficult to manipulate. Third, revenue multiples are not as volatile as earnings multiples, and hence are less likely to be affected by year-to-year swings in a firm’s fortunes. For instance, the price-earnings ratio of a cyclical firm changes much more than its price-sales ratios, because earnings are much more sensitive to economic changes than revenues are.
> 
> The biggest disadvantage of focusing on revenues is that it can lull you into assigning high values to firms that are generating high revenue growth while losing significant amounts of money. Ultimately, a firm has to generate earnings and cash flows for it to have value. While it is tempting to use revenue multiples to value firms with negative earnings and book value, the failure to control for differences across firms in costs and profit margins can lead to misleading valuations.
> 
> **Definition of Revenue Multiple**
> 
> There are two basic revenue multiples in use. The first, and more popular, one is the multiple of the market value of equity to the revenues of a firm; this is termed the price-to-sales ratio. The second, and more robust, ratio is the multiple of the value of the operating assets to revenues; this is the EV-to-sales ratio.
> 
> $\huge{ \text{Price-to-sales ratio} = { \text{Market value of equity} \over \text{Revenues} } }$
>
> $\huge{ \text{Value-to-sales ratio} = { { \text{Market value of equity} + \text{Market value of debt} − \text{Cash} } \over \text{Revenues} } }$
> 
> As with the EBITDA multiple, we net cash out of firm value, because the income from cash is not part of revenue. The enterprise value-to-sales ratio is a more robust multiple than the price-to-sales ratio because it is internally consistent. It divides the total value of the operating assets by the revenues generated by those assets. The price-to-sales ratio divides an equity value by revenues that are generated for the firm. Consequently, it will yield lower values for more highly levered firms, and may lead to misleading conclusions when price-to-sales ratios are compared across firms in a sector with different degrees of leverage.
> 
> Accounting standards across different sectors and markets are fairly similar when it comes to how revenues are recorded. There have been firms in recent years, though, that have used questionable accounting practices in recording installment sales and intracompany transactions to make their revenues higher. Notwithstanding these problems, revenue multiples suffer far less than other multiples from differences in accounting treatment across firms.
> 
> ...
> 
> **Analysis of Revenue Multiples**
> 
> The variables that determine the revenue multiples can be extracted by going back to the appropriate discounted cash flow models—dividend discount model (or an FCFE valuation model) for price-to-sales ratios and a firm valuation model for value-to-sales ratios.
> 
> ...
> 
> **Price-to-Sales Ratios** The price-to-sales ratio for a stable firm can be extracted from a stable growth dividend discount model:
> 
> $\huge{ P_0 = { DPS_1 \over { k_e − g_n } } }$
>
> where,\
> $P_0$ = Value of equity \
> $DPS_1$ = Expected dividends per share next year \
> $k_e$ = Cost of equity \
> $g_n$ = Growth rate in dividends (forever)
> 
> Substituting in for $DPS_1 = EPS_0(1 + g_n)(\text{Payout ratio})$, the value of the equity can be written as:
> 
> $\huge{ P_0 = { { EPS_0 \times \text{Payout ratio} \times (1 + g_n ) } \over {ke − gn} } }$
> 
> Defining the net profit margin = $EPS_0/\text{Sales per share}$, the value of equity can be written as:
> 
> $\huge{ P_0 = { { Sales_0 \times \text{Net margin} \times \text{Payout ratio} \times (1 + g_n) } \over { k_e − g_n} } }$
> 
> Rewriting in terms of the price-sales ratio,
> 
> $\huge{ { P_0 \over Sales_0 } = PS = { { \text{Net margin} \times \text{Payout ratio} \times (1 + g_n) } \over { k_e − g_n} } }$
> 
> The PS ratio is an increasing function of the profit margin, the payout ratio, and the growth rate, and a decreasing function of the riskiness of the firm.
> 
> The price-sales ratio for a high-growth firm can also be related to fundamentals. In the special case of the two-stage dividend discount model, this relationship can be made explicit fairly simply. With two stages of growth, a high-growth stage and a stable-growth phase, the dividend discount model can be written as follows:
> 
> $\huge{ P_0 = { { EPS_0 \times PR \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{e,h}^n } } } \right] } \over { k_{e,h} - g } } + { { EPS_0 \times PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,s} - g_n)(1 + k_{e,h})^n } } }$
> 
> where, \
> $g$ = Growth rate in the first $n$ years \
> $PR$ = Payout ratio in the first $n$ years \
> $g_n$ = Growth rate after $n$ years forever (stable growth rate) \
> $PR_n$ = Payout ratio after $n$ years for the stable firm \
> $k_e$ = Cost of equity ($h$: high-growth period; $s$: stable-growth period)
> 
> Rewriting $EPS_0$ in terms of the profit margin, $EPS_0 = Sales_0 \times \text{Profit margin}$, and bringing $Sales_0$ to the left-hand side of the equation, you get:
> 
> $\huge{ { Price \over Sales } = \text{Net margin} \times \left[ { { PR \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{e,h}^n } } } \right] } \over { k_{e,h} - g } } + { { PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,s} - g_n)(1 + k_{e,h})^n } } \right] }$
> 
> As with the price-to-book ratio, you can substitute in the free cash flows to equity for the dividends in making this estimate. Doing so will yield a more reasonable estimate of the price-to-sales ratio for firms that pay out dividends that are far lower than they can afford to pay out.
> 
> $\huge{ { Price \over Sales } = \text{Net margin} \times \left[ { { FE \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{e,h}^n } } } \right] } \over { k_{e,h} - g } } + { { FE_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{e,s} - g_n)(1 + k_{e,h})^n } } \right] }$
> 
> where $FE = FCFE/Earnings$
> 
> As with the price-to-book ratio, the firm can have a different net margin during the stable growth phase. That margin, though, will affect only the payout ratio during the stable phase.
> 
> ...
> 
> **Value-to-Sales Ratios** To analyze the relationship between value and sales, consider the value of a stable-growth firm:
> 
> $\huge{ \text{Enterprise value} = { { EBIT(1 − t)(1 − \text{Reinvestment rate}) } \over { \text{Cost of capital} − g_n } } }$
> 
> Dividing both sides by the revenue, you get:
> 
> $\huge{ { \text{Enterprise value} \over \text{Sales} } = { { [EBIT(1 − t)/\text{Sales}](1 − \text{Reinvestment rate}) } \over { \text{Cost of capital} − g_n } } }$
> 
> $\huge{ { \text{Enterprise value}_0 \over \text{Sales} } = { { \text{After-tax operating margin}(1 − \text{Reinvestment rate}) } \over { \text{Cost of capital} − g_n } } }$
> 
> Just as the price-to-sales ratio is determined by net profit margins, payout ratios, and costs of equity, the value-to-sales ratio is determined by after-tax operating margins, reinvestment rates, and the cost of capital. Firms with higher operating margins (ATOM), lower reinvestment rates (for any given growth rate), and lower costs of capital will trade at higher value-to-sales multiples.
> 
> This equation can be expanded to cover a firm in high growth by using a two-stage firm valuation model:
> 
> $\huge{ EV/Sales = ATOM { \left[ { { { (1 - RIR) \times (1 + g) \times \left[ 1 - { { (1 + g)^n \over { 1 + k_{c,h}^n } } } \right] } \over { k_{c,h} - g } } } + { { (1 - RIR_n) \times { PR_n \times (1 + g)^n \times (1 + g_n) } \over { (k_{c,s} - g_n)(1 + k_{c,h})^n } } } \right] } }$
> 
> where,\
> $ATOM$ = After-tax operating margin = $EBIT(1 - t)/Sales$ \
> $RIR$ = Reinvestment rate ($RIR_n$ is for stable growth period)\
> $k_c$ = Cost of capital ($h$: high growth and $s$: stable growth periods)\
> $g$ = Growth rate in operating income in high growth and stable growth periods
> 
> Note that the determinants of the EV-to-sales ratio remain the same as they were in the stable growth model—the growth rate, the reinvestment rate, the operating margin, and the cost of capital—but the number of estimates increases to reflect the existence of a high growth period.
> 
> **Revenue Multiples and Profit Margins** The key determinant of revenue multiples is the profit margin—the net margin for price-to-sales ratios and operating margin for value-to-sales ratios. Firms involved in businesses that have high margins can expect to sell for high multiples of sales. However, a decline in profit margins has a twofold effect. First, the reduction in profit margins reduces the revenue multiple directly. Second, the lower profit margin can lead to lower growth and hence lead to even lower revenue multiples.
> 
> The profit margin can be linked to expected growth fairly easily if an additional term is defined—the ratio of sales to book value (BV), which is also called a turnover ratio. This turnover ratio can be defined in terms of book equity (Equity turnover = Sales/Book value of equity) or book capital (Capital turnover = Sales/Book value of capital). Using a relationship developed between growth rates and fundamentals, the expected growth rates in equity earnings can be written as a function of net profit margins and turnover ratios:
> 
> $\huge{ \text{Expected growth}_e = { \text{Retention ratio} \times \text{Return on equity} } = { \text{Retention ratio} \times (\text{Net profit}/\text{Sales}) \times (\text{Sales}/\text{BV of equity})  } = { \text{Retention ratio} \times \text{Net margin} \times \text{Sales}/\text{BV of equity} } }$
> 
> where $e$ is equity,
> 
> ...
> 
> **Multiples and Companion Variables**
> 
> By this point in the relative valuation discussion, the process of deconstructing multiples should no longer be a mystery. In fact, with each multiple, while we have highlighted multiple variables that affect its value, there is one variable that operates as a key driver. We call this variable the companion variable and the table below lists it out for each multiple:
> 
> | Multiples | Companion Variables |
> |:--- |:--- |
> | PE Ratio | Expected growth rate in EPS |
> | PBV | Return on equity |
> | PS | Net margin |
> | EV/EBITDA | Reinvestment rate |
> | EV/Invested capital | Return on invested capital |
> | EV/Sales | After-tax operating margin |
> 
> These variables matter for two reasons. The first is that changes in the variables have big effects on the multiples that they relate to. The second is that when a stock looks cheap, because it has a low value on a multiple, the first item to check is the companion variable. Thus, if a stock trades at a low price-to-book ratio, you should check its return on equity; most low price-to-book stocks have low or negative returns on equity.
> 
> How do you find the companion variable for a multiple? One way is to run the market regression for the multiple against all of the independent variables that should determine it. The variable that has the most statistical significance (highest t statistic) is invariably the companion variable. The other, more intuitive, approach is to do the following. If working with an equity multiple, divide net income by the denominator of the multiple to get the companion variable. With price-to-book value of equity, for instance, using this approach would require dividing net income by the book value of equity, which would yield the return on equity. With enterprise value multiples, dividing the after-tax operating income by the denominator should yield the companion variable. With EV-to-sales, for instance, dividing the after-tax operating income by sales results in the after-tax operating margin.
> 
> **Marketing Strategy and Value** At the risk of oversimplifying pricing strategy, you can argue that every firm has to decide whether it wants to go with a low-price, high-volume strategy (volume leader) or with a high-price, lower-volume strategy (price leader). In terms of the variables that link growth to value, this choice will determine the profit margin and turnover ratio to use in valuation.
> 
> You could analyze the alternative pricing strategies that are available to a firm by examining the impact that each strategy will have on margins and turnover, and valuing the firm under each strategy. The strategy that yields the highest value for the firm is, in a sense, the optimal strategy.
> 
> Note that the effect of price changes on turnover ratios will depend in large part on how elastic or inelastic the demand for the firm’s products are. Increases in the price of a product will have a minimal effect on turnover ratios if demand is inelastic. In this case, the value of the firm will generally be higher with a price leader strategy. On the other hand, the turnover ratio could drop more than proportionately if the product price is increased and demand is elastic. In this case, firm value will increase with a volume leader strategy.
> 
> ...
> 
> **Value of a Brand Name** One of the critiques of traditional valuation is that it fails to consider the value of brand names and other intangibles. Hiroyumi Itami, in his 1987 book _Mobilizing Invisible Assets_, provides a summary of this criticism. He says:
> 
> _Analysts have tended to define assets too narrowly, identifying only those that can be measured, such as plant and equipment. Yet the intangible assets, such as a particular technology, accumulated consumer information, brand name, reputation, and corporate culture, are invaluable to the firm’s competitive power. In fact, these invisible assets are the only real source of competitive edge that can be sustained over time._
> 
> While this criticism is clearly overstated, the approaches used by analysts to value brand names are often ad hoc and may significantly overstate or understate their value. Firms with well-known brand names often sell for higher multiples than lesser-known firms. The standard practice of adding on a “brand name premium,” often set arbitrarily, to discounted cash flow value can lead to erroneous estimates. Instead, the value of a brand name can be estimated using the approach that relates profit margins to price-sales ratios.
> 
> One of the benefits of having a well-known and respected brand name is that firms can charge higher prices for the same products, leading to higher profit margins and hence to higher price-sales ratios and firm value. The larger the price premium that a firm can charge, the greater is the value of the brand name. In general, the value of a brand name can be written as:
> 
> $\huge{ \text{Value of brand name} = (V/S_b − V/S_g) \times \text{Sales} }$
> 
> where,\
> $V/S_b$ = EV-sales ratio of the firm with the benefit of the brand name\
> $V/S_g$ = EV-sales ratio of the same firm with the generic product
> 
> ...
> 
> **Using Revenue Multiples in Investment Analysis**
> 
> The key determinants of the revenue multiples of a firm are its expected margins (net and operating), risk, cash flow, and growth characteristics. To use revenue multiples in analysis and to make comparisons across firms, you would need to control for differences on these characteristics.
> 
> **Looking for Mismatches** While growth, risk, and cash flow characteristics affect revenue multiples, the key determinants of revenue multiples are profit margins—net profit margin for equity multiples and operating margins for firm value multiples. Thus it is not surprising to find firms with low profit margins and low revenue multiples, and firms with high profit margins and high revenue multiples. However, firms with high revenue ratios and low profit margins as well as firms with low revenue multiples and high profit margins should attract investors’ attention as potentially overvalued and undervalued securities respectively. This is presented in the matrix below. You can identify under- or overvalued firms in a sector or industry by plotting them on this matrix, and looking for potential mismatches between margins and revenue multiples.
> 
> ![Value-to-Sales vs. Margin](/.attachments/valuation-value.to.sales.margin.png)
> 
> _Value/Sales and Margins_
> 
> While intuitively appealing, there are at least three practical problems associated with this approach. The first is that data is more easily available on historical (current) profit margins than on expected profit margins. If a firm’s current margins are highly correlated with future margins (a firm that has earned high margins historically will continue to do so, and one that have earned low margins historically will also continue to do so), using current margins and current revenue multiples to identify under- or overvalued securities is reasonable. If the current margins of firms are not highly correlated with expected future margins, it is no longer appropriate to argue that firms are overvalued just because they have low current margins and trade at high price-to-sales ratios. The second problem with this approach is that it assumes that revenue multiples are linearly related to margins. In other words, as margins double, you would expect revenue multiples to double as well. The third problem is that it ignores differences on other fundamentals, especially risk. Thus a firm that looks undervalued because it has a high current margin and is trading at a low multiple of revenues may in fact be a fairly valued firm with very high risk.
> 
> ...
> 
> **Market Regressions** If you can control for differences across firms using a regression, you can extend this approach to look at much broader cross sections of firms. Here, the cross-sectional data is used to estimate the price-to-sales ratio as a function of fundamental variables—profit margin, dividend payout, beta, and growth rate in earnings.

### Sector-specific Multiples

> The value of a firm can be standardized using a number of sector-specific multiples. The value of steel companies can be compared based on market value per ton of steel produced, and the value of electricity generators can be computed on the basis of kilowatt hour (kwh) of power produced. In the past few years, analysts following new technology firms have become particularly inventive with multiples that range from value per subscriber for online service providers to value per web site visitor for Internet portals to value per member for social media companies.
> 
> **Why Analysts Use Sector-Specific Multiples**
> 
> The increase in the use of sector-specific multiples in the last few years has opened up a debate about whether they yield good estimates of relative value. There are several reasons why analysts use sector-specific multiples:
> 
> - They link firm value to operating details and output. For analysts who begin with these forecasts—predicted number of subscribers or number of social media site members, for instance—they provide a much more intuitive way of estimating value.
> 
> - Sector-specific multiples can often be computed with no reference to accounting statements or measures. Consequently, they can be estimated for firms where accounting statements are nonexistent, unreliable, or just not comparable. Thus, you could compute the value per kwh sold for Latin American power companies and not have to worry about accounting differences across these countries.
> 
> - Though this is usually not admitted to, sector-specific multiples are sometimes employed in desperation because none of the other multiples can be estimated or used. For instance, an impetus for the use of sector-specific multiples for dotcom companies in the late 1990s was that they often had negative earnings and little in terms of book value or revenues.
> 
> **Limitations**
> 
> Though it is understandable that analysts sometimes turn to sector-specific multiples, there are two significant problems associated with their use:
> 
> 1. They feed into the tunnel vision that plagues analysts who are sector focused, and thus they allow entire sectors to become overpriced. A service company trading at $50 a subscriber might look cheap next to another one trading at $125 a subscriber, but it is entirely possible that they are both overpriced or underpriced.
> 
> 2. As will be shown later in this section, the relationship of sector-specific multiples to fundamentals is complicated, and consequently it is very difficult to control for differences across firms when comparing them on these multiples.
> 
> **Definitions of Sector-Specific Multiples**
> 
> The essence of sector-specific multiples is that the way they are measured vary from sector to sector. In general, though, they share some general characteristics:
> 
> - The numerator is usually enterprise value—the market values of both debt and equity netted out against cash and marketable securities.
> 
> - The denominator is defined in terms of the operating units that generate revenues and profits for the firm.
> 
> For commodity companies such as oil refineries and gold-mining companies, where revenue is generated by selling units of the commodity, the market value can be standardized by dividing by the value of the reserves that these companies have of the commodity:
> 
> $\huge{ \text{Value per commodity unit} = { \text{Market value of equity} + \text{Market value of debt} − \text{Cash} \over \text{Number of units of the commodity in reserves} } }$
> 
> Oil companies can be compared on enterprise value per barrel of oil in reserves and gold-mining companies on the basis of enterprise value per ounce of gold in reserves.
> 
> For manufacturing firms that produce a homogeneous product (in terms of quality and units), the market value can be standardized by dividing by the number of units of the product that the firm produces or has the capacity to produce:
> 
> $\huge{ \text{Value per unit product} = { \text{Market value of equity} + \text{Market value of debt} − \text{Cash} \over \text{Number of units produced (or capacity)} } }$
> 
> For instance, steel companies can be compared based on their enterprise value per ton of steel produced or in capacity.
> 
> For subscription-based firms such as cable companies, online service providers, and information providers, revenues come from the number of subscribers to the base service provided. Here, the value of a firm can be stated in terms of the number of subscribers:
> 
> $\huge{ \text{Value per subscriber} = { \text{Market value of equity} + \text{Market value of debt} − \text{Cash} \over \text{Number of subscribers} } }$
> 
> In each of the cases we have discussed, you could make an argument for the use of a sector-specific multiple because the units (whether they be barrels of oil, kwh of electricity, or subscribers) generate similar revenues. Sector multiples become much more problematic when the units used to scale value are not homogeneous. Let us consider two examples.
> 
> For retailers such as Amazon that generate revenue from customers who shop at their web sites, the value of the firm can be stated in terms of the number of regular customers:
> 
> $\huge{ \text{Value per customer} = { \text{Market value of equity} + \text{Market value of debt} − \text{Cash} \over \text{Number of customers} } }$
> 
> The problem, here, is that amount spent can vary widely across customers, so it is not clear that a firm that looks cheap on this basis is undervalued.
> 
> For Internet portals that generate revenue from advertising revenues that are based on traffic to the sites, the revenues can be stated in terms of the number of visitors to the sites:
> 
> $\huge{ \text{Value per subscriber} = { \text{Market value of equity} + \text{Market value of debt} − \text{Cash} \over \text{Number of subscribers} } }$
> 
> Here, again, the link between visitors and advertising revenues is neither clearly established nor obvious. In 2010, it was the social media companies such as Facebook and Twitter that were attracting market attention, partly because of their huge membership rolls. For these companies, the enterprise value can be scaled to the number of members, but the relationship between the number of members and profitability is tenuous and untested.
> 
> **Determinants of Value**
> 
> What are the determinants of value for these sector-specific multiples? Not surprisingly, they are the same as the determinants of value for other multiples—cashflows, growth, and risk—though the relationship can be complex. The fundamentals that drive these multiples can be derived by going back to a discounted cash flow model stated in terms of these sector-specific variables.
> 
> Consider a service provider that has NX existing subscribers, and assume that each subscriber is expected to remain with the provider for the next $n$ years. In addition, assume that the firm will generate net cash flows per customer (revenues from each customer minus cost of serving the customer) of CFX per year for these $n$ years.[^14] The value of each existing customer to the firm can then be written as:
> 
> $$\huge{ \text{Value per customer} = VX = \sum_{t=1}^{t=n} { CFX \over (1 + r)^t } }$$
> 
> The discount rate used to compute the value per customer can range from close to the riskless rate, if the customer has signed a contract to remain a subscriber for the next $n$ years, to the cost of capital, if the estimate is just an expectation based on past experience.
> 
> Assume that the firm expects to continue to add new subscribers in future years and that the firm will face a cost (advertising and promotion) of $C_t$ for each new subscriber added in period $t$. If the new subscribers ($\Delta NX_t$) added in period $t$ will generate the a value $VX_t$ per subscriber, the value of this firm can be written as:
> 
> $$\huge{ \text{Value of firm} = { { NX \times VX } + \sum_{t=1}^{t=\infty } { { {\Delta NX_t} (VX_t - C_t) } \over (1 + k_c)^t } } }$$
> 
> Note that the first term in this valuation equation represents the value generated by existing subscribers, and that the second is the value of expected growth. The subscribers added generate value only if the cost of adding a new subscriber ($C_t$) is less than the present value of the net cash flows generated by that subscriber for the firm.
> 
> Dividing both sides of this equation by the number of existing subscribers ($NX$) yields the following:
> 
> $$\huge{ \text{Value per existing subscriber} = { \text{Value of firm} \over NX } = { { { VX } + { { \sum_{t=1}^{t=\infty} } { { {\Delta NX_t} (VX_t - C_t) } } \over (1 + k_c)^t } } \over NX} }$$
> 
> In the most general case, then, the value of a firm per subscriber will be a function not only of the expected value that will be generated by existing subscribers, but of the potential for value creation from future growth in the subscriber base. If you assume a competitive market, where the cost of adding new subscribers ($C_t$) converges on the value that is generated by that customer, the second term in the equation drops out and the value per subscriber becomes just the present value of cash flows that will be generated by each existing subscriber.
> 
> $\huge{ \text{Value per existing subscriber}_{C = VX} = VX}$
> 
> A similar analysis can be done to relate the value of an online retailer to the number of customers it has, though it is generally much more difficult to estimate the value that will be created by a customer. Unlike subscribers who pay a fixed fee, retail customers’ buying habits are more difficult to predict.
> 
> In either case, you can see the problems associated with comparing these multiples across firms. Implicitly, either you have to assume competitive markets and conclude that the firms with the lowest market value per subscriber are the most undervalued, or, alternatively, you have to assume that the value of growth is the same proportion of the value generated by existing customers for all of the firms in your analysis, leading to the same conclusion.
> 
> For social media companies, value can be related to the number of members but only if the link between revenue and the number of members is made explicit. For instance, Facebook’s advertising revenues can be directly tied to the number of members, and the value of the company can be stated on a per-member basis. Since social media companies may have to invest resources to add to their membership, it is the net value generated for each member that ultimately determines value.
> 
> ...
> 
> **Analysis Using Sector-Specific Multiples**
> 
> To analyze firms using sector-specific multiples, you have to control for the differences across firms on any or all of the fundamentals that you identified as affecting these multiples in the last part.
> 
> With value per subscriber, for instance, you have to control for differences in the value generated by each subscriber. In particular:
> 
> - Firms that are more efficient in delivering a service for a given subscription price (resulting in lower costs) should trade at a higher value per subscriber than comparable firms. This would also apply if a firm has significant economies of scale. In Illustration 20.13, the value per subscriber would be higher if each existing subscriber generated $120 in net cash flows for the firm each year instead of $100.
> - Firms that can add new subscribers at a lower cost (through advertising and promotion) should trade at a higher value per subscriber than comparable firms.
> - Firms with higher expected growth in the subscriber base (in percentage terms) should trade at a higher value per subscriber than comparable firms. You could make similar statements about value per customer.
> 
> You could make similar statements about value per customer.


## Contingency Claim Model

The Contingency Claim Model, developed by Aswath Damodaran, is particularly appropriate for evaluating businesses with complex capital structures or those facing financial distress. Let's break down the key features of the model and discuss scenarios in which it is suitable:

1. **Incorporates Option Pricing Theory**: The Contingency Claim Model is grounded in _option pricing theory_, which treats a company's equity as a call option on the value of its assets. This means that equity holders benefit when the value of the company's assets exceeds its liabilities, similar to how call option holders benefit when the underlying asset's price exceeds the strike price.

2. **Accounts for Financial Distress**: The model is especially useful for companies facing financial distress or uncertainty about their future viability. In such scenarios, the company's equity behaves like a call option with a high degree of uncertainty and volatility, as there is a possibility of the company defaulting on its obligations or undergoing bankruptcy proceedings.

3. **Analyzes Equity and Debt Claims**: The Contingency Claim Model evaluates the value of both equity and debt claims on a company's assets. By considering the rights and priorities of different stakeholders in the capital structure, the model provides insights into the potential distribution of value among shareholders and creditors under different scenarios.

4. **Suitable for Leveraged Companies**: Companies with high levels of debt or complex capital structures, such as those with multiple layers of debt or hybrid securities, can benefit from the Contingency Claim Model. The model helps assess the impact of leverage on the value of equity and debt claims and allows stakeholders to make informed decisions about capital structure optimization and risk management.

5. **Useful for Valuing Distressed Companies**: When valuing distressed companies or companies operating in volatile industries, traditional valuation methods may not accurately capture the value of equity due to the high degree of uncertainty and risk. The Contingency Claim Model provides a framework for incorporating this uncertainty into the valuation process and can help stakeholders make more informed decisions in such challenging circumstances.

In summary, the Contingency Claim Model is appropriate for evaluating businesses with complex capital structures, facing financial distress, or operating in volatile industries where traditional valuation methods may not adequately capture the value of equity. It provides a comprehensive framework for analyzing equity and debt claims and assessing the impact of uncertainty and leverage on the company's value.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

![Contingency Claim Valuation Selection Process](/.attachments/valuation-contingency.claim.valuation.png)

_Contingency Claim Valuation Selection Process_

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

#### Properties of Stock Options

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

#### Option Pricing Theory and Models

> **Binomial Model**
> 
> The binomial option pricing model is based on a simple formulation for the asset price process in which the asset, in any time period, can move to one of two possible prices. The general formulation of a stock price process that follows the binomial path is shown in illustration below. In this illustration, $S$ is the current stock price; the price moves up to $Su$ with probability $p$ and down to $Sd$ with probability $1 – p$ in any time period.
> 
> ![General Formulation for Binomial Price Path](/.attachments/valuation-binomial.price.path.png)
> 
> _General Formulation for Binomial Price Path_
> 
> **Creating a Replicating Portfolio** The objective in creating a replicating portfolio is to use a combination of risk-free borrowing/lending and the underlying asset to create the same cash flows as the option being valued. The principles of arbitrage apply then, and the value of the option must be equal to the value of the replicating portfolio. In the case of the general formulation shown above, where stock prices can move either up to Su or down to Sd in any time period, the replicating portfolio for a call with strike price K will involve borrowing \$B and acquiring $\Delta$ of the underlying asset, where:
> 
> $\huge{ \Delta = \text{ Number of units of the underlying asset bought } = { {C_u - C_s } \over { Su -Sd } } }$ 
> 
> where,\
> $C_u$ = Value of the call if the stock price is Su \
> $C_d$ = Value of the call if the stock price is Sd
> 
> In a multiperiod binomial process, the valuation has to proceed iteratively (i.e., starting with the final time period and moving backward in time until the current point in time). The portfolios replicating the option are created at each step and valued, providing the values for the option in that time period. The final output from the binomial option pricing model is a statement of the value of the option in terms of the replicating portfolio, composed of Δ shares (option delta) of the underlying asset and risk-free borrowing/lending.
> 
> Value of the call = Current value of underlying asset × Option delta – Borrowing needed to replicate the option
> 
> ...
> 
> **The Determinants of Value** The binomial model provides insight into the determinants of option value. The value of an option is not determined by the expected price of the asset but by its current price, which, of course, reflects expectations about the future. This is a direct consequence of arbitrage. If the option value deviates from the value of the replicating portfolio, investors can create an arbitrage position (i.e., one that requires no investment, involves no risk, and delivers positive returns). To illustrate, if the portfolio that replicates the call costs more than the call does in the market, an investor could buy the call, sell the replicating portfolio, and be guaranteed the difference as a profit. The cash flows on the two positions will offset each other, leading to no cash flows in subsequent periods. The call option value also increases as the time to expiration is extended, as the price movements (u and d) increase, and with increases in the interest rate.
>
> While the binomial model provides an intuitive feel for the determinants of option value, it requires a large number of inputs, in terms of expected future prices at each node. As time periods are made shorter in the binomial model, you can make one of two assumptions about asset prices.You can assume that price changes become smaller as periods get shorter; this leads to price changes becoming infinitesimally small as time periods approach zero, leading to a continuous price process. Alternatively, you can assume that price changes stay large even as the period gets shorter; this leads to a jump price process, where prices can jump in any period. This section considers the option pricing models that emerge with each of these assumptions.
> 
> **Black-Scholes Model**
> 
> When the price process is continuous (i.e., price changes become smaller as time periods get shorter), the binomial model for pricing options converges on the Black-Scholes model. The model, named after its cocreators, Fischer Black and Myron Scholes, allows us to estimate the value of any option using a small number of inputs, and has been shown to be robust in valuing many listed options.[^15]

> In the early 1970s, Fischer Black, Myron Scholes, and Robert Merton achieved a major breakthrough in the pricing of European stock options. This was the development of what has become known as the Black–Scholes–Merton (or Black–Scholes) model. The model has had a huge inﬂuence on the way that traders price and hedge derivatives. In 1997, the importance of the model was recognized when Robert Merton and Myron Scholes were awarded the Nobel prize for economics. Sadly, Fischer Black died in 1995; otherwise he too would undoubtedly have been one of the recipients of this prize.[^10]

> **The Model** While the derivation of the Black-Scholes model is far too complicated to present here, it is based on the idea of creating a portfolio of the underlying asset and the riskless asset with the same cash flows, and hence the same cost, as the option being valued. The value of a call option in the Black-Scholes model can be written as a function of the five variables:
> 
> $S$ = Current value of the underlying asset \
> $K$ = Strike price of the option \
> $t$ = Life to expiration of the option \
> $r$ = Riskless interest rate corresponding to the life of the option \
> $σ^2$ = Variance in the ln(value) of the underlying asset
> 
> The value of a call is then:
> 
> $\huge{ \text{Value of call} = S N(d_1) – K e^{–rt} N(d_2) }$
> 
> where, \
> ${ d_1 = { { { ln \left( \frac{S}{K} \right) + \left( r + \frac{σ^2}{2} \right)t } } \over { σ\sqrt{t} } } }$ \
> $d_2 = d_1 - { σ\sqrt{t} }$
> 
> Note that $e^{–rt}$ is the present value factor, and reflects the fact that the exercise price on the call option does not have to be paid until expiration, since the model values European options. $N(d_1)$ and $N(d_2)$ are probabilities, estimated by using a cumulative standardized normal distribution, and the values of $d_1$ and $d_2$ obtained for an option. The cumulative distribution is shown below.
> 
> ![Cumulative Normal Distribution](/.attachments/valuation-cumulative.normal.distribution.png)
> 
> _Cumulative Normal Distribution_
> 
> In approximate terms, $N(d_2)$ yields the likelihood that an option will generate positive cash flows for its owner at exercise (i.e., that $S > K$ in the case of a call option and that $K > S$ in the case of a put option). The portfolio that replicates the call option is created by buying $N(d_1)$ units of the underlying asset, and borrowing $Ke^{–rt} N(d_2)$. The portfolio will have the same cash flows as the call option, and thus the same value as the option. $N(d_1)$, which is the number of units of the underlying asset that are needed to create the replicating portfolio, is called the option delta.
> 
> **A NOTE ON ESTIMATING THE INPUTS TO THE BLACK-SCHOLES MODEL**
> 
> The Black-Scholes model requires inputs that are consistent on time measurement. There are two places where this affects estimates. The first relates to the fact that the model works in continuous time, rather than discrete time. That is why we use the continuous time version of present value ($exp^{–rt}$) rather than the discrete version, $(1 + r)^{–t}$. It also means that the inputs such as the riskless rate have to be modified to make them continuous time inputs. For instance, if the one-year Treasury bond rate is 6.2 percent, the risk-free rate that is used in the Black-Scholes model should be:
> 
> Continuous riskless rate = ln(1 + Discrete riskless rate)
> = ln(1.062) = .06015 or 6.015%
> 
> The second relates to the period over which the inputs are estimated. For instance, the preceding rate is an annual rate. The variance that is entered into the model also has to be an annualized variance. The variance, estimated from ln(asset prices), can be annualized easily because variances are linear in time if the serial correlation is zero. Thus, if monthly or weekly prices are used to estimate variance, the variance is annualized by multiplying by 12 or 52, respectively.
> 
> **Model Limitations and Fixes** The Black-Scholes model was designed to value European options that can be exercised only at maturity and whose underlying assets do not pay dividends. In addition, options are valued based on the assumption that option exercise does not affect the value of the underlying asset. In practice, assets do pay dividends, options sometimes get exercised early, and exercising an option can affect the value of the underlying asset. Adjustments exist that, while not perfect, provide partial corrections to the Black-Scholes model.[^15]

### Option to Delay

> In traditional investment analysis, a project or new investment should be accepted only if the returns on the project exceed the hurdle rate; in the context of cash flows and discount rates, this translates into investing in projects with positive net present values (NPVs). The limitation of this view of the world, which analyzes projects on the basis of expected cash flows and discount rates, is that it fails to consider fully the options that are usually associated with many investments.
> 
> [Here we] consider an option that is embedded in many projects, namely the option to wait and take the project in a later period. Why might a firm want to do this? If the present value of the cash flows on the project are volatile and can change over time, a project or technology that does not pass [the capital budget evaluation] now may become valuable in the future. Furthermore, a firm may gain by waiting on a project even after a project has a positive net present value, because the project may have a higher value taken at a future date. This option is most valuable in projects where a firm has the exclusive right to invest in a project and becomes less valuable as the barriers to entry decline.
> 
> There are at least three cases where the option to delay can make a difference when valuing a firm. The first is ***undeveloped land*** in the hands of real estate investor or company. The choice of when to develop rests in the hands of the owner, and presumably development will occur when real estate values increase enough to justify it. The second is a firm that owns a ***patent or patents***. Since a patent provides a firm with the exclusive rights to produce the patented product or service, it can and should be valued as an option. The third is a natural resource company that has ***undeveloped reserves*** that it can choose to develop at a time of its choosing—presumably when the price of the resource is high.
> 
> ... ***In an environment in which a project can be taken by only one firm because of legal restrictions or other barriers to entry to competitors, however, the changes in the project’s value over time give it the characteristics of a call option.***
> 
> **Payoff on the Option to Delay**
> 
> Assume that a project requires an initial up-front investment of $X$, and that the present value of expected cash inflows from investing in the project, computed today, is $V$. The net present value of this project is the difference between the two:
> 
> $\huge{ NPV = V - X }$
> 
> Now assume that the firm has exclusive rights to this project for the next $n$ years, and that the present value of the cash inflows may change over that time (but that the cost of the project stays fixed at $X$), because of changes in either the cash flows or the discount rate. Thus, the project may have a negative net present value right now, but it may still be a good project if the firm waits. Defining $V$ again as the present value of the cash flows, the firm’s decision rule on this project can be summarized as follows:
> 
> If $V > X$ Invest in the project: Project has positive net present value.
> 
> If $V < X$ Do not invest in the project: Project has negative net present value.
> 
> If the firm does not invest in the project over its life, it incurs no additional cash flows, though it will lose what it invested to get exclusive rights to the project. This relationship can be presented in a payoff diagram of cash flows on this project, as shown in illustration below, assuming that the firm holds out until the end of the period for which it has exclusive rights to the project.
> 
> ![The Option to Delay a Project](/.attachments/valuation-option-to-delay.png)
> 
> _The Option to Delay a Project_
> 
> Note that this payoff diagram is that of a call option—the underlying asset is the project, the strike price of the option is the investment needed to take the project, and the life of the option is the period for which the firm has rights to the project. The present value of the cash flows on this project and the expected variance in this present value represent the value and variance of the underlying asset.
> 
> ...
> 
> **Value of the Underlying Asset** In the case of product options, the underlying asset is the project to which the firm has exclusive rights. The current value of this asset is the present value of expected cash flows from initiating the project now, not including the up-front investment. This present value can be obtained from a standard investment analysis, discounting expected cash flows at a risk adjusted discount rate. There is likely to be a substantial amount of error in the cash flow estimates and the present value, especially if the project is in a new business or involves an untested technology. Rather than being viewed as a problem, this uncertainty should be viewed as the reason the project delay option has value. _If the expected cash flows on the project were known with certainty and were not expected to change, there would be no need to adopt an option pricing framework, since there would be no value to the option._
> 
> **Variance in the Value of the Asset** As noted in the prior section, there is likely to be considerable uncertainty associated with the cash flow estimates and the present value that measures the value of the project now. This is partly because the potential market for the product may be unknown, and partly because technological shifts can change the cost structure and profitability of the product. The variance in the present value of cash flows from the project can be estimated in one of three ways.
> 
> 1. If we have invested in similar projects in the past, the variance in the cash flows from those projects can be used as an estimate. This may be the way that a consumer product company like Gillette might estimate the variance associated with introducing a new blade for its razors.
> 
> 2. We can assign probabilities to various market scenarios, estimate cash flows and a present value under each scenario, and then calculate the variance across present values. Alternatively, the probability distributions can be estimated for each of the inputs into the project analysis—the size of the market, the market share, and the profit margin, for instance—and simulations used to estimate the variance in the present values that emerge. This approach tends to work best when there are only one or two sources of significant uncertainty about future cash flows.
> 
> 3. We can use the variance in the value of firms involved in the same business (as the project being considered) as an estimate of the variance in present value for the project. Thus, the average variance in the value of firms involved in the software business can be used as the variance in present value of a software project.
> 
> The value of the option is largely derived from the variance in cash flows; the higher the variance, the higher the value of the project delay option. Thus, the value of an option to invest in a project in a stable business will be less than the value of one in an environment where technology, competition, and markets are all changing rapidly.
> 
> **Exercise Price on Option** The option to delay a project is exercised when the firm owning the rights to the project decides to invest in it. The cost of making this initial investment is the exercise price of the option. The underlying assumption is that this cost remains constant (in present value dollars) and that any uncertainty associated with the investment is reflected in the present value of cash flows on the product. That is more an assumption of convenience than necessity, since it makes valuing the option a little easier.
> 
> **Expiration of the Option and the Riskless Rate** The project delay option expires when the rights to the project lapse. Investments made after the project rights expire are assumed to deliver a net present value of zero as competition drives returns down to the required rate. The riskless rate to use in pricing the option should be the rate that corresponds to the expiration of the option. While expiration dates can be estimated easily when firms have the explicit right to a project (through a license or a patent, for instance), they become far more difficult to obtain when the right is less clearly defined. If, for instance, a firm has a competitive advantage on a product or project, the option life can be defined as the expected period over which the advantage can be sustained.
> 
> **Cost of Delay** An American option generally will not be exercised prior to expiration. When you have the exclusive rights to a project, though, and the net present value turns positive, you would not expect the owner of the rights to wait until the rights expire to exercise the option (invest in the project). Note that there is a cost to delaying investing in a project, once the net present value turns positive. If you wait an additional period, you may gain if the variance pushes value higher but you also lose one period of protection against competition. You have to consider this cost when analyzing the option, and there are two ways of estimating it:
> 
> 1. Since the project rights expire after a fixed period, and excess profits (which are the source of positive present value) are assumed to disappear after that time as new competitors emerge, each year of delay translates into one less year of value-creating cash flows. If the cash flows are evenly distributed over time, and the life of the patent is n years, the cost of delay can be written as:
> 
>    $\huge{ \text{ Annual cost of delay } = \frac{1}{n} }$
> 
>    Thus, if the project rights are for 20 years, the annual cost of delay works out to $\frac{1}{20}$ or 5% in the first year. Note, though, that this cost of delay rises each year, to $\frac{1}{19}$ in year 2, $\frac{1}{18}$ in year 3, and so on, making the cost of delaying exercise larger over time.
> 
> 2. If the cash flows are uneven, the cost of delay can be more generally defined in terms of the cash flow that can be expected to occur over the next period as a percent of the present value today:
> 
>    $\huge{ \text{Cost of delay} = { \text{Cash flow}_p \over \text{Present value}_n } }$
>    
>    where $p$ is next period and $n$ is now
> 
> In either case, the likelihood that a firm will delay investing in a project is higher early in the exclusive rights period rather than later and will increase as the loss in cash flows from waiting a period increases.
> 
> ...
> 
> **Problems in Valuing the Option to Delay**
> 
> While it is quite clear that the option to delay is embedded in many projects, several problems are associated with the use of option pricing models to value these options. First, the underlying asset in this option, which is the project, is not traded, making it difficult to estimate its value and variance. The value can be estimated from the expected cash flows and the discount rate for the project, albeit with error. The variance is even more difficult to estimate, however, since we are attempting the estimate a variance in project value over time.
> 
> Second, the behavior of prices over time may not conform to the price path assumed by the option pricing models. In particular, the assumption that value follows a diffusion process, and that the variance in value remains unchanged over time, may be difficult to justify in the context of a project. For instance, a sudden technological change may dramatically change the value of a project, either positively or negatively.
> 
> Third, there may be no specific period for which the firm has rights to the project. Unlike the case of a patent, in which the firm has exclusive rights to produce the patented product for a specified period, the firm’s rights to a specific project often are less clearly defined, in terms of both exclusivity and time. For instance, a firm may have significant advantages over its competitors, which may, in turn, provide it with the virtually exclusive rights to a project for a period of time. An example would be a company with strong brand name recognition in retailing or consumer products. The rights are not legal restrictions, however, and will erode over time. In such cases, the expected life of the project itself is uncertain and only an estimate. In the valuation of the rights to the product in the previous section a life of five years for the option was used, but competitors could in fact enter sooner than anticipated. Alternatively, the barriers to entry may turn out to be greater than expected, and allow the firm to earn excess returns for longer than five years. Ironically, uncertainty about the expected life of the option can increase the variance in present value, and through it, the expected value of the rights to the project.
> 
> **Implications and Extensions of Delay Options**
> 
> Several interesting implications emerge from the analysis of the option to delay a project as an option. First, a project may have a negative net present value currently based on expected cash flows, but the rights to it may still be valuable because of the option characteristics. By the same token, the exclusive rights to a non-viable technology in a risky business can be worth a great deal.
> 
> Second, a project may have a positive net present value but still not be accepted right away. This can happen because the firm may gain by waiting and accepting the project in a future period, for the same reasons that investors do not always exercise an option that is in the money. A firm is more likely to wait if it has the rights to the project for a long time, protection against competition and the variance in project inflows is high. To illustrate, assume a firm has the patent rights to produce a new type of disk drive for computer systems and building a new plant will yield a positive net present value today. If the technology for manufacturing the disk drive is in flux, however, the firm may delay investing in the project in the hopes that the improved technology will increase the expected cash flows and consequently the value of the project. It has to weigh this benefit against the cost of delaying the project, which will be the cash flows that will be forsaken by not investing in it.
> 
> Third, factors that can make a project less attractive in a static analysis can actually make the rights to the project more valuable. As an example, consider the effect of uncertainty about the size of the potential market and the magnitude of excess returns. In a static analysis, increasing this uncertainty increases the riskiness of the project and may make it less attractive. When the project is viewed as an option, an increase in the uncertainty may actually make the option more valuable, not less. The chapter will consider two cases, product patents and natural resource reserves, where the project delay option allows value to be estimated more precisely.
> 
> **Option Pricing Models**
>
> Once you have identified the option to delay a project as a call option and identified the inputs needed to value the option, it may seem like a trivial task to actually value the option. There are, however, some serious estimation issues that we have to deal with in valuing these options. Chapter 5 noted that while the more general model for valuing options is the binomial model, many practitioners use the Black-Scholes model, which makes far more restrictive assumptions about price processes and early exercise to value options. With listed options on traded assets, you can do this at fairly low cost. With real options, there can be a substantial cost to this practice for the following reasons:
> 
> - Unlike listed options, real options tend to be exercised early, if they are in the money. While there are ways in which the Black-Scholes model can be adjusted to allow for this early exercise, the binomial model allows for much more flexibility.
> 
> - The binomal option pricing model allows for a much wider range of price processes for the underlying asset than the Black-Scholes model, which assumes that prices are not only continuous but log-normally distributed. With real options, where the present value of the cash flows is often equivalent to the price, the assumptions of nonnormality and continuous distributions may be difficult to sustain.
> 
> The biggest problem with the binomial model is that the prices at each node of the binomial tree have to be estimated. As the number of periods expands, this will become more and more difficult to do. You can, however, use the variance estimate in the Black-Scholes to come up with measures of the magnitude of the up and down movements, which can be used to obtain the binomial tree.
> 
> Having made a case for the binomial model, you may find it surprising that we use the Black-Scholes model to value any real options. We do so not only because the model is more compact and elegant to present, but because we believe that it will provide a lower bound on the value in most cases. To provide a frame of reference, we will present the values that we would have obtained using a binomial model in each case.
> 
> **From Black-Scholes to Binomial** It is a fairly simple exercise to convert the inputs to the Black-Scholes model into a binomial model. To make the adjustment, you have to assume a multiplicative binomial process, where the magnitude of the jumps, in percent terms, remains unchanged from period to period. If you assume symmetric probabilities, the up (u) and down (d) movements can be estimated as a function of the annualized variance in the price process and how many periods you decide to break each year into (t).
> 
> $\huge{ u = exp^{ { \sigma \sqrt{dt} } + { \left(r - y - { { \sigma }^2 \over 2 } \right) } } }$
> 
> $\huge{ d = exp^{ -{ \sigma \sqrt{dt} } + { \left(r - y - { { \sigma }^2 \over 2 } \right) } } }$
> 
> where $dt$ = 1/Number of periods each year [^16]

#### Patent

> A number of firms, especially in the technology and pharmaceutical sectors, can patent products or services. A product patent provides a firm with the exclusive right to develop and market a product, and thus can be viewed as an option.
> 
> **Patents as Call Options**
> 
> The firm will develop a patent only if the present value of the expected cash flows from the product sales exceed the cost of development. If this does not occur, the firm can shelve the patent and not incur any further costs. If $I$ is the present value of the costs of commercially developing the patent and $V$ is the present value of the expected cash flows from development, then:
> 
> Payoff from owning a product patent, \
> = $V − I$ if $V > I$ \
> = $0$ if $V \leq I$
> 
> Thus a product patent can be viewed as a call option, where the product is the underlying asset.
> 
> **Valuing a Firm with Patents**
> 
> If the patents owned by a firm can be valued as options, how can this estimate be incorporated into firm value? The value of a firm that derives its value primarily from commercial products that emerge from its patents can be written as a function of three variables:
> 
> 1. The cash flows it derives from patents that it has already converted into commercial products.
> 
> 2. The value of the patents that it already possesses that have not been commercially developed.
> 
> 3. The expected value of any patents that the firm can be expected to generate in future periods from new patents that it might obtain as a result of its research.
> 
>    Value of firm = Value of commercial products + Value of existing patents + (Value of new patents that will be obtained in the future − Cost of obtaining these patents)
> 
> The expected cash flows from existing products can be estimated for their commercial lives and discounted back to the present at the appropriate cost of capital to arrive at the value of these products. The value of the second component can be obtained using the option pricing model described earlier to value each patent. The value of the third component will be based on perceptions of a firm’s research capabilities. In the special case where the expected cost of research and development in future periods is equal to the value of the patents that will be generated by this research, its value will become zero. In the more general case, firms that have a history of generating value from research will derive positive value from this component as well. There is also the possibility that some companies destroy value with ongoing research, where the cost of the research exceeds the value created.
> 
> How would the overall estimate of value obtained using this approach contrast with the estimate obtained in a traditional discounted cash flow model? In traditional discounted cash flow valuation, the second and the third components of value are captured in the expected growth rate in cash flows. Firms are allowed to grow at much higher rates for longer periods because of the patents they possess and their research prowess. In contrast, the approach described in this section looks at each patent separately and allows for the option component of value explicitly.
> 
> The biggest limitation of the option-based approach is the information that is needed to put it in practice. To value each patent separately, you need access to proprietary information that is usually available only to managers of the firm. In fact, some of the information, such as the expected variance to use in option pricing, may not even be available to insiders and will have to be estimated for each patent separately.
> 
> Given these limitations, the real option approach should be used to value small firms with one or two patents and little in terms of established assets. A good example would be Biogen in 1997. For more established firms that have significant assets in place and dozens of patents, discounted cash flow valuation is a more pragmatic choice.[^16]

#### Undeveloped Reserves

> Natural resource companies, such as oil and mining companies, generate cash flows from their existing reserves but also have undeveloped reserves that they can develop if they choose to do so. They will be much more likely to develop these reserves if the price of the resource (oil, gold, copper, etc.) increases and these undeveloped reserves can be viewed as call options. This section begins by looking at the value of an undeveloped reserve and then consider how this can be extended to look at natural resource companies that have both developed and undeveloped reserves.
> 
> ...
> 
> **Inputs for Valuing a Natural Resource Option** To value a natural resource investment as an option, we need to make assumptions about a number of variables:
> 
> - _Available reserves of the resource and estimated value if extracted today_. Since the quantity of the reserve is not known with certainty at the outset, it has to be estimated. In an oil tract, for instance, geologists can provide reasonably accurate estimates of the quantity of oil available in the tract. The value of the reserves is then the product of the estimated reserves and the contribution (price of the resource minus variable cost of extraction) per unit of reserve.
> 
> - _Estimated cost of developing the resource_. The estimated cost of developing the resource reserve is the exercise price of the option. In an oil reserve, this would be the fixed cost of installing the rigs to extract oil from the reserve. With a mine, it would be the cost associated with making the mine operational. Since oil and mining companies have done this before in a variety of settings, they can use their experience to come up with a reasonable measure of development cost.
> 
> - _Time to expiration of the option_. The life of a natural resource option can be defined in one of two ways. First, if the ownership of the investment has to be relinquished at the end of a fixed period of time, that period will be the life of the option. In many offshore oil leases, for instance, the oil tracts are leased to the oil company for a fixed period. The second approach is based on the inventory of the resource and the capacity output rate, as well as estimates of the number of years it would take to exhaust the inventory. Thus, a gold mine with a mine inventory of 3 million ounces and a capacity output rate of 150,000 ounces a year will be exhausted in 20 years, which is defined as the life of the natural resource option.
> 
> - _Variance in value of the underlying asset_. The variance in the value of the underlying asset is determined by the variability in the price of the resource and the variability in the estimate of available reserves. In the special case where the quantity of the reserve is known with certainty, the variance in the underlying asset’s value will depend entirely on the variance in the price of the natural resource.
> 
> - _Cost of delay_. The net production revenue is the annual cash flow that will be generated, once a resource reserve has been developed, as a percentage of the value of the reserve. This is the equivalent of the dividend yield and is treated the same way in calculating option values. An alternative way of thinking about this cost is in terms of a cost of delay. Once a natural resource option is in-the-money (value of the reserves is greater than the cost of developing these reserves), by not developing the reserve the firm is costing itself the net production revenue it could have generated by doing so.
> 
> An important issue in using option pricing models to value natural resource options is the effect of development lags on the value of these options. Since oil or gold or any other natural resource reserve cannot be developed instantaneously, a time lag has to be allowed between the decision to extract the resources and the actual extraction. A simple adjustment for this lag is to reduce the value of the developed reserve for the loss of cash flows during the development period. Thus, if there is a one-year lag in development, you can estimate the cash flow you would make over the year as a percent of your reserve value, and discount the current value of the developed reserve at that rate. This is the equivalent of removing the first year’s cash flow from your investment analysis and lowering the present value of your cash flows.
> 
> ...
> 
> **Individual Reserves versus Aggregate Reserves** The preferred approach would be to consider each reserve separately, value it, and cumulate the values of the reserves to get the value of the firm. Since this information is likely to be difficult to obtain for large natural resource firms, such as oil companies, which own hundreds of such reserves, a variant of this approach is to value the entire firm’s undeveloped reserves as one option. A purist would probably disagree, arguing that valuing an option on a portfolio of assets (as in this approach) will provide a lower value than valuing a portfolio of options (which is what the natural resource firm really owns). Nevertheless, the assumption that the only source of variance is the price of the natural resource effectively makes the values of the reserves perfectly correlated and allows us to use the short cut with limited or no cost.
> 
> **Inputs to Option Valuation** If you decide to apply the option pricing approach to estimate the value of aggregate undeveloped reserves, you have to estimate the inputs to the model. In general terms, while the process resembles the one used to value an individual reserve, there are a few differences.
> 
> - _Value of underlying asset_. You should cumulate all of the undeveloped reserves owned by a company and estimate the value of these reserves, based on the price of the resource today and the average variable cost of extracting these reserves today. The variable costs are likely to be higher for some reserves and lower for others, and weighting the variable costs at each reserve by the quantity of the resource of that reserve should give you a reasonable approximation of this value. At least hypothetically, we are assuming that the company can decide to extract all of its undeveloped reserves at one time and not affect the price of the resource.
> 
> - _Exercise price_. For this input, you should consider what it would cost the company today to develop all of its undeveloped reserves. Again, the costs might be higher for some reserves than for others, and you can use a weighted average cost.
> 
> - _Life of the option_. A firm will probably have different lives for each of its reserves. As a consequence, you will have to use a weighted average of the lives of the different reserves.
> 
> - _Variance in the value of the asset_. Here, there is a strong argument for looking at only the oil price as the source of variance, since a firm should have a much more precise estimate of its total reserves than it does of any one of its reserves.
> 
> - _Dividend yield (cost of delay)_. As with an individual reserve, a firm with viable reserves will be giving up the cash flows it could receive in the next period from developing these reserves if it delays exercise. This cash flow, stated as a percent of the value of the reserves, becomes the equivalent of the dividend yield. The development lag reduces the value of this option just as it reduces the value of an individual reserve. The logical implication is that undeveloped reserves will be worth more at oil companies that can develop their reserves quicker than at less efficient companies.
> 
> ...
> 
> **Table**. _Inputs to Value Other Options to Delay_ 
> 
> |     | Undeveloped Land | License/Copyright |
> |:--- |:--- |:--- |
> | Value of the underlying asset | Present value of the cash flows that would be obtained from commercial development of land today. | Present value of the cash flows that would be obtained from commercially utilizing the license or copyright today. |
> | Variance in value of underlying asset| Variance in the values of commercial property in the area where the real estate is located. | Variance in the present values from commercial utilization of copyright or license (from a simulation). |
> | Exercise price | Cost of commercially developing land today. | Up-front cost of commercially utilizing copyright or license today. |
> | Life of the option | If land is under long-term lease, you could use the lease period. If not, you should set the option life equal to the period when the loan that you used to buy the land comes due. | Period for which you have rights to copyright or license. |
> | Cost of delay | Property taxes and other costs associated with holding land. | Cash flow you could generate in next year as a percent of present value of the cash flows today. |
> 
> [^16]

### Option to Expand

> Firms sometimes invest in projects because the investments allow them either to make further investments or to enter other markets in the future. In such cases, we can view the initial projects as yielding options allowing the firm to invest in other projects, and these options have value. Put another way, a firm may accept a negative net present value on the initial project because of the possibility of high positive net present values on future projects.
> 
> ...
> 
> ![The Option to Expand a Project](/.attachments/valuation-option.to.expand.png) 
> 
> _The Option to Expand a Project_
> 
> **Inputs to Value the Option to Expand** To understand how to estimate the value of the option to expand, let us begin by recognizing that there are two linked projects. The first project generally has a negative net present value and is recognized as a poor investment, even by the firm investing in it. The second project is the potential to expand that comes with the first project. It is the second project that represents the underlying asset for the option. The inputs have to be defined accordingly:
> 
> - The present value of the cash flows that you would generate if you were to invest in the second project today (the expansion option) is the value of the underlying asset— $S$ in the option pricing model.
> 
> - If there is substantial uncertainty about the expansion potential, the present value is likely to be volatile and change over time as circumstances change. It is the variance in this present value that you would want to use to value the expansion option. Since projects are not traded, you have to either estimate this variance from simulations or use the variance in values of publicly traded firms in the business.
> 
> - The cost that you would incur up front, if you invest in the expansion today, is the equivalent of the strike price.
> 
> - The life of the option is fairly difficult to define, since there is usually no externally imposed exercise period. (This is in contrast to the patents valued in the preceding chapter, which have a legal life that can be used as the option life.) When valuing the option to expand, the life of the option will be an internal constraint imposed by the firm on itself. For instance, a firm that invests on a small scale in China might impose a constraint that it will either expand within five years or pull out of the market. Why might it do so? There may be considerable costs associated with maintaining the small presence or the firm may have scarce resources that have to be committed elsewhere.
> 
> - As with other real options, there may be a cost to waiting once the expansion option becomes viable. That cost may take the form of cash flows that will be lost on the expansion project if it is not taken or a cost imposed on the firm until it makes its final decision. For instance, the firm may have to pay a fee every year until it makes its final decision.
> 
> ...
> 
> **Problems in Valuing the Option to Expand**
> 
> The practical considerations associated with estimating the value of the option to expand are similar to those associated with valuing the option to delay. In most cases, firms with options to expand have no specific time horizon by which they have to make an expansion decision, making these open-ended options or, at best, options with arbitrary lives. Even in those cases where a life can be estimated for the option, neither the size nor the potential market for the product may be known, and estimating either can be problematic. To illustrate, consider the Ambev example discussed earlier. While we adopted a period of five years, at the end of which Ambev has to decide one way or another on its future expansion in United States, it is entirely possible that this time frame is not specified at the time the initial investment is made. Furthermore, we have assumed that both the cost and the present value of expansion are known at the time of the initial investment. In reality, the firm may not have good estimates for either input before opening the first store, since it does not have much information on the underlying market.
> 
> **Extensions and Implications of Expansion Options**
> 
> The option to expand can be used by firms to rationalize investing in projects that have negative net present values but provide significant opportunities to enter new markets or to sell new products. The option pricing approach adds rigor to this argument by estimating the value of these options, and it also provides insight into those occasions when they are most valuable. The option to expand is clearly more valuable for more volatile businesses with higher returns on projects (such as biotechnology or computer software), than it is for stable businesses with lower returns (such as automobile production). We will consider three cases where the expansion option may yield useful insights—strategic acquisitions, research and development expenses, and multistage projects.
> 
> ...
> 
> **Quantitative Estimation**
> 
> When real options are used to justify a decision, the justification has to be in more than qualitative terms. In other words, managers who argue for investing in a project with poor returns or paying a premium on an acquisition on the basis of the real options generated by this investment should be required to value these real options and show that the economic benefits exceed the costs. There will be two arguments made against this requirement. The first is that real options cannot be easily valued, since the inputs are difficult to obtain and often noisy. The second is that the inputs to option pricing models can be easily manipulated to back up whatever the conclusion might be. While both arguments have some basis, an estimate is better than no estimate at all, and the process of trying to estimate the value of a real option is, in fact, the first step to understanding what drives its value.
> 
> ...
> 
> **Valuing a Firm with the Option to Expand**
> 
> Is there an option to expand embedded in some firms that can lead to these firms to trade at a premium over their discounted cash flow values? At least in theory, there is a rationale for making this argument for a small, high-growth firm in a large and evolving market. The discounted cash flow valuation is based on expected cash flows and expected growth and these expectations should reflect the probability that the firm could be hugely successful (or a huge failure). What the expectations might fail to consider is that, in the event of success, the firm could invest more, add new products or expand into new markets and augment this success. This is the real option that is creating the additional value.
> 
> **Relationship to Discounted Cash Flow Valuation**
> 
> If the value of this option to expand is estimated, the value of a firm can be written as the sum of two components—a discounted cash flow value based on expected cash flows and a value associated with the option to expand:
> 
> Value of firm = Discounted cash flow value + Option to expand
> 
> The option pricing approach adds rigor to this argument by estimating the value of the option to expand, and it also provides insight into those occasions when it is most valuable. In general, the option to expand is clearly more valuable for more volatile businesses with higher returns on projects and greater barriers to competitive entry (such as new technology), than in stable businesses with lower returns (such as housing, utilities, or automobile production).
> 
> Again, though, you have to be careful not to double count the value of the option. If you use a higher growth rate than would be justified based on expectations because of the option to expand, you have already counted the value of the option in the discounted cash flow valuation. Adding an additional component to reflect the value of the option would be double counting.[^17]

### Option to Abandon

> When investing in new projects, firms worry about the risk that the investment will not pay off, and that actual cash flows will not measure up to expectations. Having the option to abandon a project that does not pay off can be valuable, especially on projects with a significant potential for losses.
> 
> **Payoff on the Option to Abandon**
> 
> The option pricing approach provides a general way of estimating and building in the value of abandonment. To illustrate, assume that V is the remaining value on a project if it continues to the end of its life, and L is the liquidation or abandonment value for the same project at the same point in time. If the project has a remaining life of n years, the value of continuing the project can be compared to the liquidation (abandonment) value. If the value from continuing is higher, the project should be continued; if the value of abandonment is higher, the holder of the abandonment option could consider abandoning the project. The payoffs can be written as:
> 
> Payoff from owning an abandonment option, \
> = $0$ if $V > L$ \
> = $L - V$ if $V \leq L$
> 
> ![The Option to Abandon a Project](/.attachments/valuation-option.to.abandon.png)
> 
> _The Option to Abandon a Project_
> 
> Unlike the prior two cases, the option to abandon takes on the characteristics of a put option.
> 
> ...
> 
> **Problems in Valuing the Option to Abandon**
> 
> ... More often, however, the firm has the option to abandon, and the salvage value from abandonment can only be estimated. Further, the abandonment value may change over the life of the project, making it difficult to apply traditional option pricing techniques. Finally, it is entirely possible that abandoning a project may not bring in a liquidation value but may create costs instead; a manufacturing firm may have to pay severance to its workers, for instance. In such cases, it would not make sense to abandon unless the cash flows on the project are even more negative.[^17]

### Option to Liquidate

> In most publicly traded firms, equity has two features. The first is that the equity investors run the firm and can choose to liquidate its assets and pay off other claim holders at any time. The second is that the liability of equity investors in some private firms and almost all publicly traded firms is restricted to their equity investments in these firms. This combination of the option to liquidate and limited liability allows equity to have the features of a call option. In firms with substantial liabilities and negative earnings, the option value of equity may be in excess of the discounted cash flow value.
> 
> **Payoff on Equity as an Option**
> 
> The equity in a firm is a residual claim, that is, equity holders lay claim to all cash flows left after other financial claimholders (debt, preferred stock, etc.) have been satisfied. If a firm is liquidated, the same principle applies; equity investors receive the cash that is left in the firm after all outstanding debt and other financial claims have been paid off. With limited liability, if the value of the firm is less than the value of the outstanding debt, equity investors cannot lose more than their investment in the firm. The payoff to equity investors on liquidation can therefore be written as:
> 
> Payoff to equity on liquidation, \
> = $V - D$ if $V > D$ \
> = $0$ if $V \leq D$
> 
> where, \
> $V$ = Liquidation value of the firm \
> $D$ = Face value of the outstanding debt and other nonequity claims
> 
> Equity can thus be viewed as a call option on the firm, where exercising the option requires that the firm be liquidated and the face value of the debt (which corresponds to the exercise price) be paid off. The firm is the underlying asset and the option expires when the debt comes due.
> 
> ![Payoff on Equity as Option on a Firm](/.attachments/valuation-option.payoff.firm.png)
> 
> _Payoff on Equity as Option on a Firm_
> 
> **IMPORTANCE OF LIMITED LIABILITY**
> 
> The argument that equity is a call option holds only if equity has limited liability—that is, the most that an equity investor can lose is what he or she has invested in a firm. This is clearly the case in publicly traded companies. In private companies, however, the owners often have unlimited liability. If these firms get into financial trouble and are unable to make their debt payments, the owner’s personal assets can be put at risk. You should not value equity as a call option in these cases.
> 
> **When Will Equity Be Worthless?**
> 
> In discounted cash flow valuation, we argue that equity is worthless if what you own (the value of the assets) is less than what you owe. The first implication of viewing equity as a call option is that equity will have value, even if the value of the assets falls well below the face value of the outstanding debt. While the firm will be viewed as troubled by investors, accountants, and analysts, its equity is not worthless. In fact, just as deep out-of-the-money [or in the red] traded options command value because of the possibility that the value of the underlying asset may increase above the strike price in the remaining lifetime of the option, equity commands value because of the time premium on the option (the time until the bonds mature and come due) and the possibility that the value of the assets may increase above the face value of the bonds before they come due.
> 
> ...
> 
> **Increasing Risk Can Increase Equity Value**
> 
> In traditional discounted cash flow valuation, higher risk almost always translates into lower value for equity investors. When equity takes on the characteristics of a call option, you should not expect this relationship to continue to hold. Risk can become your ally, when you are an equity investor in a troubled firm. In essence, you have little to lose and much to gain from swings in firm value.
> 
> ...
> 
> **Probability of Default and Default Spreads**
> 
> One of the more interesting pieces of output from the option pricing model is the risk-neutral probability of default that you can obtain for the firm. In the Black-Scholes model, you can estimate this value from N(d2), which is the risk-neutral probability that $S > K$, which in this model is the probability that the value of the assets will exceed the face value of the debt.
> 
> Risk-neutral probability of default = 1 − N(d2)
> 
> In addition, the interest rate from the debt allows us to estimate the appropriate default spread to charge on bonds.
> 
> You can see the potential in applying this model to bank loan portfolios to extract both the probability of default and to measure whether you are charging an interest rate that is high enough on the debt. In fact, there are commercial services that use fairly sophisticated option pricing models to estimate both values for firms.
> 
> **Estimating the Value of Equity as an Option**
> 
> The examples we have used thus far to illustrate the application of option pricing to value equity have included some simplifying assumptions. Among them are the following:
>
> - There are only two _claimholders_ in the firm—debt and equity.
> - There is only one issue of debt outstanding, and it can be retired at face value.
> - The debt has a zero coupon and no special features (convertibility, put clauses, etc.).
> - The value of the assets of the firm and the variance in that value can be estimated. In liquidation, we assume that you will get the value of the assets as the liquidation proceeds.
>
> Each of these assumptions is made for a reason. First, restricting the claimholders to just debt and equity makes the problem more tractable; introducing other claimholders such as preferred stock makes it more difficult to arrive at a result, albeit not impossible. Second, by assuming only one zero coupon debt issue that can be retired at face value any time prior to maturity, we align the features of the debt more closely to the features of the strike price on a standard option. Third, if the debt is coupon debt, or more than one debt issue is outstanding, the equity investors can be forced to exercise (liquidate the firm) at these earlier coupon dates if they do not have the cash flows to meet their coupon obligations.
> 
> Finally, knowing the value of the firm assets in liquidation and the variance in that value makes the option pricing possible, but it also raises an interesting question about the usefulness of option pricing in equity valuation. If the bonds of the firm are publicly traded, the market value of the debt can be subtracted from the value of the firm to obtain the value of equity much more directly. The option pricing approach does have its advantages, however. Specifically, when the debt of a firm is not publicly traded, option pricing theory can provide an estimate of value for the equity in the firm. Even when the debt is publicly traded, the bonds may not be correctly valued, and the option pricing framework can be useful in evaluating the values of debt and equity. Finally, the value of the firm may be different from the liquidation value of the assets; the former also incorporate the expected value of growth potential.
> 
> **Inputs for Valuing Equity as an Option**
> 
> Since most firms do not fall into the neat framework just developed (such as having only one zero coupon bond outstanding), some compromises are needed in order to use this model in valuation.
> 
> **Value of the assets of the Firm** The liquidation value of the assets of the firm can be obtained in one of four ways. In the first, we cumulate the market values of outstanding debt and equity, assuming that all debt and equity are traded, to obtain firm value and we assume that this approximately liquidation value. The option pricing model then reallocates the firm value between debt and equity. This approach, while simple, is internally inconsistent. We start with one set of market values for debt and equity and, using the option pricing model, end up with entirely different values for each. We are also assuming that the going concern value of the firm is equal to what you would get if you liquidated its assets.
> 
> In the second, we estimate the value of the assets of the firm by discounting expected cash flows at the cost of capital. The one consideration that we need to keep in mind is that the value of the firm in an option pricing model should be the value obtained on liquidation. This may be less than the total firm value, which includes expected future growth potential, and it may also be reduced to reflect the cost of liquidation. If we estimate the firm value using a discounted cash flow model this would suggest that only existing investments should be considered while estimating firm value.[^20]
> 
> In the third approach, we estimate a multiple of revenues by looking at healthy mature firms (with little or no growth potential) in the same business and apply this multiple to the revenues of the firm you are valuing. Implicitly, we are assuming that a potential buyer, in the event of liquidation, will pay this value.
> 
> **Variance in Firm Value** We can obtain the variance in firm value directly if both stocks and bonds in the firm are traded. Defining ${\sigma}_e^2$ as the variance in the stock price and ${\sigma}_d^2$ as the variance in the bond price, $w_e$ as the market-value weight of equity, and $w_d$ as the market-value weight of debt, we can write the variance in firm value as:[^21]
> 
> $\huge{ { {\sigma}_{firm}^2 } = { {w_e^2} {\sigma_e^2} } + { {w_d^2} {\sigma_d^2}} + { 2 {w_e} {w_d} { {\rho}_{ed} } {\sigma_e} {\sigma}_d } }$
> 
> where ${\rho}_{ed}$ is the correlation between the stock and the bond prices. When the bonds of the firm are not traded, we can use the variance of similarly rated bonds as the estimate of ${\sigma}_d^2$ and the correlation between similarly rated bonds and the firm’s stock as the estimate of ${\rho}_{ed}$.
> 
> When companies get into financial trouble, this approach can yield misleading results as both its stock prices and its bond prices become more volatile. An alternative that often yields more reliable estimates is to use the average variance in firm value for other firms in the sector. Thus the value of equity in a deeply troubled steel company can be estimated using the average variance in firm value of all traded steel companies.
> 
> **Maturity of the Debt** Most firms have more than one debt issue on their books, and much of the debt comes with coupons. Since the option pricing model allows for only one input for the time to expiration, we have to convert these multiple bonds issues and coupon payments into one equivalent zero coupon bond.
> 
> - One solution, which takes into account both the coupon payments and the maturity of the bonds, is to estimate the duration of each debt issue and calculate a face-value-weighted average of the durations of the different issues. This value-weighted duration is then used as a measure of the time to expiration of the option.
> - An approximation is to use the face-value-weighted maturity of the debt coming for the maturity of the zero coupon bond in the option pricing model.
> 
> **Face Value of Debt** When a distressed firm has multiple debt issues outstanding, you have three choices when it comes to what you use as the face value of debt:
> 
> 1. You could add up the principal due on all of the debt of the firm and consider it to be the face value of the hypothetical zero coupon bond that you assume that your firm has issued. The limitation of this approach is that it will understate what the firm will truly have to pay out over the life of the debt, since there will be coupon payments and interest payments during the period.
> 
> 2. At the other extreme, you could add the expected interest and coupon payments that will come due on the debt to the principal payments to come up with a cumulated face value of debt. Since the interest payments occur in the near years and the principal payments are due only when the debt comes due, you are mixing cash flows up at different points in time when you do this. This is, however, the simplest approach of dealing with intermediate interest payments coming due.
> 
> 3. You can consider only the principal due on the debt as the face value of the debt and the interest payments each year, specified as a percent of firm value, can take the place of the dividend yield in the option pricing model. In effect, each year that the firm remains in existence, you would expect to see the value of the firm decline by the expected payments on the debt.


## Inflation

![Inflation in Jamaica between January 2023 and January 2024](/.attachments/valuation-inflation.boj.2024.webp)

_Inflation in Jamaica between January 2023 and January 2024_

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
      \text{Inflation Rate} = \left( \frac{\text{Current CPI} - \text{Base CPI}}{\text{Base CPI}} \right) \times 100
   }$$

   - Current CPI: CPI value for the current period.
   - Base CPI: CPI value for the base period (often chosen as 100 or 1 for easier calculation).
   - The result is then multiplied by 100 to express the inflation rate as a percentage.

5. **Interpretation**: A positive inflation rate indicates that the cost of the basket of goods and services has increased over time, leading to a decrease in the purchasing power of money. Conversely, a negative inflation rate (deflation) suggests a decrease in the overall price level.

6. **Monitoring and Policy Decisions**: Economists, policymakers, businesses, and individuals use inflation rate data to monitor changes in the economy, make informed decisions regarding investments, wages, interest rates, and adjust monetary and fiscal policies accordingly to promote economic stability.

By using the CPI to track changes in the cost of living over time, economists can gauge the rate of inflation and its impact on consumers, businesses, and the overall economy.

To calculate the inflation rate using the Consumer Price Index (CPI) for August 2021 compared to August 2020 in United States, use the following formula:

$$\huge{
   \text{Inflation Rate} = \left( \frac{CPI_{current} - CPI_{base} }{CPI_{base}} \right) \times 100
}$$

Where:
- ${\text{CPI}_{\text{current}}}$ is the CPI for the current period (August 2021).
- ${\text{CPI}_{\text{base}}}$ is the CPI for the base period (August 2020).

Let's assume:
- ${\text{CPI}_{\text{current}} = 271.678}$, the CPI for August 2021 (hypothetical value).
- ${\text{CPI}_{\text{base}} = 257.797}$, the CPI for August 2020 (hypothetical value).

Using these values in the formula:

$$\huge{
\text{Inflation Rate} = \left( \frac{271.678 - 257.797}{257.797} \right) \times 100
}$$

$$\huge{
\text{Inflation Rate} = \left( \frac{13.881}{257.797} \right) \times 100
}$$

$$\huge{
\text{Inflation Rate} \approx 0.0538 \times 100
}$$

$$\huge{
\text{Inflation Rate} \approx 5.38 percent
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

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

> The CPI serves as a gauge for assessing the performance of the economy and it is an important tool used by government in formulating and evaluating many economic policies. Additionally, private researchers, students and the public use the CPI for social and economic studies of the economy, school projects and general information.
> 
> The CPI is relevant to all persons who earn and spend money. When prices rise the purchasing power of money is reduced and consequently, people are able to buy less with the same amount of money. It is therefore used extensively in collective bargaining by labour unions and employers for the adjustment of wages and salaries. Rental agreements, insurance premiums, pensions, alimony and child support payments are all forms of contractual and price-setting arrangements, very often tied to movements in the CPI.
> 
> ...
> 
> The Consumer Price Index measures price movements of a given quantity of consumer goods and services. The goods and services included within the scope of the index can be figuratively thought of as a "basket".
> 
> The "basket" represents a mix of consumer products purchased by the typical household. No two households are exactly alike in their spending habits. Each household purchases a different combination of goods and services for consumption. Generally speaking, the CPI "basket" includes those goods and services which are important in terms of the size of expenditure made on them by consumer households.
> 
> The items in the "basket", in addition to being representative of households' spending habits, must also have their prices associated with specific quantities. Without the quantity/price relation, it is extremely difficult to measure pure price changes.
> 
> A pure price change is a change in the price of a good or service whose characteristics do not change over time.
> 
> ...
> 
> Once the “basket” is selected, the quantity of the items is kept constant. However, the total cost of this “fixed basket” will vary from one period of time to another, as the prices of the items change. Price changes resulting from such a “constant or fixed basket” are defined as “pure” price movements, which is what the CPI, in essence, measures. Thus, the CPI gives the percentage change in the cost of purchasing the contents of the basket.
> 
> ...
> 
> In organizing the CPI “basket”, the selected items of goods and services are grouped together according to various categories. They are first grouped by commodity type. Related commodity types are then grouped into sub-components which are then assigned to a major expenditure Division. All goods and services in the CPI basket are divided into twelve (12) major expenditure Division that are based on a consumption classification system developed by the United Nations.
> 
> The classification system is the Classification of Individual Consumption According to Purpose (COICOP), and the 12 broad expenditure divisions are:
> 
> 1. Food and Non-Alcoholic Beverages
> 2. Alcoholic Beverages and Tobacco
> 3. Clothing and Footwear
> 4. Housing, Water, Electricity, Gas and Other Fuels
> 5. Furnishings, Household Equipment and Routine Household Maintenance
> 6. Health
> 7. Transport
> 8. Communication
> 9. Recreation and Culture
> 10. Education
> 11. Restaurants and Accommodation Services
> 12. Miscellaneous Goods and Services
> 
> 
> _Table 1_. Weight Structure in the Revised CPI
> 
> |    | Divisions | Weights (%) |
> |:---|:--- | ---:|
> | 01 | Food and Non-Alcoholic Beverages | 37.4|
> | 02 | Alcoholic Beverages and Tobacco | 1.4 |
> | 03 | Clothing and Footwear | 3.3 |
> | 04 | Housing, Water, Electricity, Gas and Other Fuels| 12.8 |
> | 05 | Furnishings, Household Equipment and Routine, Household Maintenance | 4.9 |
> | 06 | Health | 3.3 |
> | 07 | Transport | 12.8 |
> | 08 | Communication | 4.0 |
> | 09 | Recreation & Culture | 3.4 |
> | 10 | Education | 2.1 |
> | 11 | Restaurants & Accommodation Services| 6.2 |
> | 12 | Miscellaneous Goods & Services | 8.4 |
> 
> *The weights applied are based on the 2004/2005 Household Expenditure Survey[^19]

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
1. [How to Calculate Beta In Excel - All 3 Methods (Regression, Slope & Covariance)](https://youtu.be/vr1lQeKX8Mc) - [hey i'm aaron](https://www.youtube.com/channel/UCqBYFpLfaytqGkzGTsHTlVQ)
1. [How to calculate percentage price changes correctly with natural logs for stock prices](https://youtu.be/Ytk_WTmPhCs) - [Stachanov Holding B.V.](https://www.youtube.com/c/StachanovSolutionsServices)
1. [Free Cash Flow: Back to Basics](https://youtu.be/9GnwzjV9qS0) - [Aswath Damodaran](https://www.youtube.com/c/AswathDamodaranonValuation)
1. [Valuing Financial Service Firms, Excess Return Model](https://youtu.be/hLIK_nQml88) - [Chris Hughen](https://www.youtube.com/@ChrisHughen)
1. [REIT Valuation](https://youtu.be/lz8T0owadXU) - [Chris Hughen](https://www.youtube.com/@ChrisHughen)
1. [Aswath Damodaran: PRICELESS LECTURE About The Stock Market (Every Investor MUST WATCH)](https://youtu.be/zjXvbJUnCsM?si=Mze389kztEnuBROm)
1. [Here Are The REAL RISKS To The US Economy](https://youtu.be/MrsiIt2pUUc?si=2JDAjtONY5AXXiYK) - [George Gammon](https://www.youtube.com/@GeorgeGammon)


[^1]: Page 75. Chapter 5. Understand Fundamental Analysis. _The Art of Currency Trading_ by Brent Donnelly.
[^3]: Page 314. Chapter 9. Valuing Stocks. _Corporate Finance: The Core, Global Edition_ by Jonathan Berk and Peter Demarzo.
[^4]: Chapter 2. Approaches to Valuation. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^5]: Chapter 21. Valuing Financial Service Firms. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^6]: Chapter 12. Closure in Valuation: Estimating Terminal Value. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^8]: Chapter 17. Fundamental Principles of Relative Valuation. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^9]: Chapter 10. Mechanics of Options Markets. _Options, Futures, and Other Derivatives, Global Edition, 9th Edition_ by John C. Hull
[^10]: Chapter 15. Black-Scholes-Merton Model. _Options, Futures, and Other Derivatives, Global Edition, 9th Edition_ by John C. Hull.
[^11]: Chapter 18. Earnings Multiples. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^12]: Chapter 19. Book Value Multiples. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^13]: Chapter 25. The Monetary System. _Economics, Global Edition, Second Edition_ by Daron Acemoglu, David Laibson, John A. List
[^14]: For purposes of simplicity, it has been assumed that the cash flow is the same in each year. This can be generalized to allow cash flows to grow over time.
[^15]: Chapter 5. Option Pricing Theory and Models. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^16]: Chapter 28. Option to Delay and Valuation Implications. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^17]: Chapter 29. The Options to Expand and to Abandon: Valuation Implications. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^19]: _Understanding the Consumer Price Index_ by Statistical Institute of Jamaica
[^20]: Technically, this can be done by putting the firm into stable growth and valuing it as a stable growth firm, where reinvestments are used to either preserve or augment existing assets.
[^21]: This is an extension of the variance formula for a two-asset portfolio.
[^23]: Chapter 10. Capital Markets and the Pricing Risk. _Corporate Finance: The Core, Global Edition_ by Jonathan Berk and Peter Demarzo.
[^24]: Chapter 4. The Basics of Risk. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^25]: Chapter 7. Riskless Rates and Risk Premiums. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^26]: Chapter 11. Optimal Portfolio Choice and the Capital Asset Pricing Model. _Corporate Finance: The Core, Global Edition_ by Jonathan Berk and Peter Demarzo.
[^27]: Chapter 8. Estimating Risk Parameters and Costs of Financing. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^28]: Chapter 11. Estimating Growth. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^29]: Chapter 22. Valuing Firms with Negative Earnings. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^30]: Chapter 23. Valuing Young or Start-Up Firms. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^31]: Chapter 34. Overview and Conclusion. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^32]: Chapter 3. Understanding Financial Statements. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^34]: Chapter 10. From Earnings to Cash Flows. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^35]: Chapter 13. Dividend Discount Model. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^36]: Chapter 14. Free Cash Flow to Equity Discount Models. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.
[^37]: Chapter 15. Firm Valuation: Cost of Capital and Adjusted Present Value Approaches. _Investment Valution: Tools and Techniques for Determining the Value of Any Asset_ by Aswath Damodaran.