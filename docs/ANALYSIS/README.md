# Securities Trading Analysis

This body of work is the foundation of an online business that is dedicated to educate the common man about the business of trading securities and to facilitate the ease of trading these securities. The philosophy around the education of securities trading are classified in three categories: Fundamental Analysis, Technical Analysis and Behavioural Economics.

The education provided in this project involves constant updates to the state of each business that are on a stock exchange by breaking down the details of annual and quarterly report through the presentation of all the important [multiples](./MULTIPLIERS.md) (or financial ratios) that can be calculated from each report. Also, provided in the continuous learning experience is the [evaluation](./VALUATION.md) of the business as an asset. The studying of multiples, business evaluation and the effects of the economy constitutes **Fundamental Analysis**.

Trading is an economic activity based on [human behaviour and the perception of the thing being traded](./BEHAVIOUR.md). Even though Brent Donnelly wrote _The Art of Currency Trading_ to focus solely on trading of foreign exchange currency, I think that many of the philosophies can be used in stock trading. Donnelly remarks,

> My philosophy is that sustainable long-term success in FX trading is best achieved using a fusion approach. This is a hybrid adaptive process that combines _fundamental and macroeconomic analysis, behavioral finance, technical analysis, and diligent risk management_.
>
> ...
>
> **Fundamental analysis** is the study of macroeconomic factors that drive markets (as opposed to other factors like momentum, positioning, and psychology ...).
>
> ...
>
> **Technical analysis** is the study of chart patterns in an attempt to forecast future price movements.
>
> ...
>
> ... **behavioral finance** includes human psychology, market positioning, market sentiment, cognitive bias, feedback loops, and other individual human and group behavior characteristics that lead to price moves that cannot be explained by rational macro factors.

## Fundamental Analysis

I think Donelly's remarks still need a simpler definition for fundamental analysis because words like _macroeconomics_ is a complex word. Fundamental analysis is the studying of the asset being traded, which in the case of a stock exchange is a business. Studying a business involves going through the details of financial statements such as the income statement, balance sheet (or statement of position) and cashflow statement. A few notes from the book, [Introdution to Financial Accounting](./REPORTS.md#introduction-to-financial-accounting), were taken in this body of work. A lot of the notes will prove useful in the software design. So, what is it that analyst are looking for in these statements? Analysts and protégés of Warren Buffet will be looking for _durable competitive advantage_. Notes from Buffet's book, [Warren Buffett and the Interpretation of Financial Statements](./REPORTS.md#warren-buffets-interpretation-of-financial-statements), on how to identify such businesses that have durable competitive advantage were also taken. Some analysts may go as in-depth as forming an intrinsic value of the business, which is the value that it can offer in terms of _future cash flows_.

Another vitally important point of study for those doing fundamental analysis is identifying shenanigans within the reports. A few notes from [Financial Shenanigans](./REPORTS.md#financial-reporting-shenanigans) were also taken. Basically, financial shenanigans are tricks that accountants attempt in reporting the performance in the business through financial statements to overstate or understate their position in order to give investors a particular perception of their business. The idea is to create demand for their stock so that the price is either maintained or goes up higher.

Finally, to "put the icing on the cake" or "the cherry on top", all the performance multiples, intrinsic valuation and auditing to identify shenanigans must be within the context of the most current _industry trends_ and _economic conditions_ that the business operates within. Some key industry trends to look for include:

1. Market demand: Understanding the current and future demand for products or services within the industry.
2. Technological advancements: Assessing how technology is shaping the industry and whether companies are adapting to or leading technological changes.
3. Regulatory environment: Monitoring regulatory changes and their potential impact on the industry's operations and profitability.
4. Competitive landscape: Analyzing the competitive dynamics within the industry, including market share, pricing strategies, and innovation.
5. Economic indicators: Keeping track of macroeconomic factors such as GDP growth, interest rates, and consumer sentiment that influence the industry's performance.
6. Demographic shifts: Considering changes in demographics, such as population growth, aging populations, or shifting consumer preferences, that can affect industry trends.
7. Globalization: Evaluating how globalization impacts the industry, including international trade policies, supply chain dynamics, and market expansion opportunities.
8. Sustainability and ESG factors: Assessing the industry's efforts towards sustainability, environmental impact, and adherence to environmental, social, and governance (ESG) principles.

When conducting fundamental analysis, several economic factors are essential to consider. These factors provide insights into the broader economic environment in which a company operates and can impact its performance. Some key economic factors to look for include:

1. Gross Domestic Product (GDP): GDP measures the total value of goods and services produced within a country's borders. It provides an indication of the overall health and growth of the economy.

2. Interest rates: Central banks' monetary policies, including changes in interest rates, can influence borrowing costs for businesses, consumer spending, and investment decisions.

3. Inflation rate: Inflation measures the rate at which prices for goods and services rise over time. High inflation can erode purchasing power and affect consumer spending and business profitability.

4. Unemployment rate: The unemployment rate reflects the percentage of the labor force that is unemployed and actively seeking employment. It can indicate the strength of the job market and consumer confidence.

5. Consumer spending: Consumer spending is a significant driver of economic activity, representing the expenditures of households on goods and services. Changes in consumer spending patterns can affect various industries and companies.

6. Business investment: Business investment includes spending on capital goods, such as equipment, machinery, and infrastructure. It reflects business confidence and expectations for future growth.

7. Government policies: Government policies, such as fiscal stimulus measures, tax reforms, and regulatory changes, can impact businesses' operations and profitability.

8. Exchange rates: Exchange rate fluctuations affect international trade, export competitiveness, and the translation of foreign earnings for multinational companies.

9. Trade policies and global economic conditions: Trade policies, tariffs, and geopolitical tensions can influence international trade flows and supply chain dynamics, impacting businesses with global operations.

10. Consumer sentiment: Consumer sentiment measures consumers' confidence in the economy and their willingness to spend. It can provide insights into future consumer behavior and demand for goods and services.

By analyzing these economic factors, investors can gain a better understanding of the macroeconomic environment and make more informed investment decisions.

## Democracy of the Stock Market

Warren Buffet and his mentor, Benjamin Graham, are strong believers in fundamental analysis, especially analysis that unravels the intrinsic value of a business, to determine how to buy stocks for the long-term. Buffett looks for stocks that he believes are undervalued by the market. He seeks companies with strong fundamentals, including a competitive advantage, consistent earnings, and a durable business model.

The stock market, however, is filled with investors that may not embrace those beliefs. Investors are influenced to trade stocks on a number of factors that do not include the fundamental analysis of a company. Investors can be influenced by macro-economic factors such as inflation caused by changes in supply-chain management of goods and services in the world due to geo-political tensions. Investors are social beings and, hence, many will trade stocks based on what the 'herd' decides to do.

Price action of stocks are based on supply and demand. It's basically a democratic process. When stocks are traded, it is basically investors voting with their money on whether they believe the value of a stock is going up or down. Socrates, the Greek Philosopher, expressed concerns about democracy when he criticised the idea of majority rule without a proper emphasis on wisdom and knowledge. He believed that decisions in a democratic society were often driven by the opinions of the majority, irrespective of their level of understanding or expertise on a given issue.

Socrates argued that a democratic system could lead to decisions influenced by emotional appeals and demagogy rather than rational thinking and expertise. He was skeptical about the ability of the general populace to make informed and wise decisions, particularly in complex matters. Socrates believed that individuals with specialized knowledge and expertise, such as philosophers, should have a greater role in decision-making.

So, let's bring the relevance of Socrates philosophy on democracy to Buffet's philosophy. Buffet's philosophy will only work if all investors were operating strictly off the performance of the company to which the stocks are associated.

## Technical Analysis

So, it is the democracy of stock exchanges that causes analyst to not only studying the _durable competitive advantage_ of a business but to use tools to _forecast_ the _[predictably irrational](./BEHAVIOUR.md#predictably-irrational)_ behaviour of investors. The study of _forecasting price movements_ (or _price action_) is known as _Technical Analysis_.

This kind of forecasting usually involves the use of charts that identify _reversal patterns_ and _continuation patterns_. _Moving averages_ to identify points of inflection or major change. Oscillators to know when a period of stability is about to break out into a _bullish_ or _bearish_ trend. Various formulas to arrive at the best time cycles or seasons to use with moving averages and oscillators. Most of these tools are always used together because none of these tools can stand alone to give analysts the confidence to _forecast price movements_.

A few notes were taken from _[Technical Analysis of the Financial Markets](./TECHNICAL.md#technical-analysis-of-the-financial-markets)_ by John J. Murphy

Here's a important advisory to analyst from Appendix C of his book,

> Trading system development is part art, part science, and part common sense. Our goal is not to develop a system that achieves the highest returns using historical data, but to formulate a sound concept that has performed reasonably well in the past and can be expected to continue to perform reasonably well in the future.
> 
> Ideally, we would prefer an approach that is 100% mechanical, increasing the odds that past performance can be replicated in the future. Mechanical means objective: if 10 people follow the same rules and achieve the same results, those rules are said to be objective. It does not matter whether a mechanical system is written on paper or entered into a computer.
> 
> Here, however, we’ll assume that we are using a computer and will use the terms “mechanical” and “computerized” interchangeably. This does not imply that a computer is mandatory for trading system development, although it certainly helps.
> 
> The mechanical approach offers us three main benefits:
> 
> **We can back test ideas before trading them**. A computer allows us to test ideas on historical data rather than on hard earned cash. By helping us see how a system would have performed in the past, it allows us to make better decisions when it really counts—in the present.
> **We can be more objective and less emotional**. Most people have trouble applying their objective analysis to actual trading situations. Analysis (where we have no money at risk) is easy, trading (where we have money at risk) is stressful. Therefore, why not let the computer pull the trigger for us? It is free of human emotion and will do exactly what we had instructed it to do at the time when we developed our system.
> **We can do more work, increasing our opportunities**. A mechanical approach takes less time to apply than a subjective one, which allows us to cover more markets, trade more systems, and analyze more time frames each day. This is especially true for those of us who use a computer, since it can work faster and longer than we can, without losing its concentration.
> 
> **5 STEP PLAN**
> 
> 1. Start with a concept
>    
>    Develop your own concepts of how markets work. You can begin by looking at as many charts as you can, trying to identify moving average crossovers, oscillator configurations, price patterns or other pieces of objective evidence which precede major market moves. Also attempt to recognize clues that provide advance warning on moves that are likely to fail. I studied chart after chart after chart in the hope of finding such answers. This “visual” approach has worked for me, and I highly recommend it.
> 
>    In addition to studying price charts and reading books such as this one, I suggest you read about trading systems and study what others have done. Although no one is going to reveal the “Holy Grail” to you, there is a great deal of useful information out there. Most importantly, think for yourself. I have found that the most profitable ideas are rarely original, but frequently our own.
> 
>    Most of the successful trading systems are trend following. Counter trend systems should not be overlooked, however, because they bring a degree of negative correlation to the table. This means that when one system is making money, the other is losing money, resulting in a smoother equity curve for the two systems combined, than for either one alone.
> 
>    **Principles of Good Concept Design**
>
>    Good concepts usually make good sense. If a concept seems to work, but makes little sense, you may be sliding into the realm of coincidence, and the odds of this concept continuing to work in the future diminishes considerably. Your concepts must fit your personality in order to give you the discipline to follow them even when they are losing money (i.e. during periods of drawdown). Your concepts should be straightforward and objective, and if trend following, should trade with the major trend, let profits run and cut losses short. Most importantly, your concepts must make money in the long run (i.e. they must have a positive expectation).
> 
>    Designing entries is hard, but designing exits is harder and more important. Entry logic is fairly straightforward, but exits have to take various contingencies into account, such as how fast to cut losses or what to do with accumulated profits. I prefer systems that do not reverse automatically—I like to exit a trade first, before putting on another trade in the opposite direction. Work hard to improve your exits, and your returns will improve relative to your risk.
> 
>    Another suggestion—try to optimize as little as possible. Optimization using historical data often leads one to expect unrealistic returns that cannot be replicated in real trading. Try to use few parameters and apply the same technique across a number of different markets. This will improve your chances of long run success, by reducing the pitfalls of over optimization.
> 
>    The three main categories of trading systems are:
> 
>    - **Trend following**. These systems trade in the direction of the major trend, buying after the bottom and selling after the top. Moving averages and Donchian’s weekly rule are popular methodologies among money managers.
>    - **Counter trend**
> 
>      –   Support/Resistance. Buy a decline into support; sell a rally into resistance.
> 
>      –   Retracements. Here we buy pullbacks in a bull market and sell rallies in a bear market. For example, buy a 50% pullback of the last advance, but only if the major trend remains up. The danger of such systems is that you never know how far a retracement will go and it becomes difficult to implement an acceptable exit technique.
> 
>      –   Oscillators. The idea is to buy when the oscillator is oversold and to sell when it is overbought. If divergence between the price series and the oscillator is also present, a much stronger signal is given. However, it is usually best to wait for some sign of a price reversal before buying or selling.
>   - **Pattern recognition** (visual and statistical). Examples include the highly reliable head and shoulders formation (visual), and seasonal price patterns (statistical).
> 
> 2. Turn it into a set of objective rules
> 
>    This is the most difficult step in our 5 step plan, much more difficult than many of us would at first expect! To complete this step successfully, we must express our idea in such objective terms that 100 people following our rules will all arrive at exactly the same conclusions.
> 
>    Determine what our system is supposed to do and how it will do it. It is with this step that we produce the details needed to accomplish the programming task. We need to take the overall problem and break it down into more and more detail until we finalize all the details.
> 
> 3. Visually check it out on the charts
> 
>    Following the explicit rules we just determined in Step 2, let us visually check the trading signals that are produced on a price chart. This is an informal process, meant to achieve two results: first, we want to see whether our idea has been stated properly; and second, before writing complicated computer code, we want some proof that the idea is a potentially profitable one.
> 
> 4. Formally test it with a computer
> 
>    Now its time to convert our logic into computer code. For my own work, I use a program called TradeStation®, Omega Research, Inc. in Miami, FL. TradeStation is the most comprehensive technical analysis software package available for formulating and testing trading systems. It brings together everything from the visualization of your idea, to assistance in trading your system in real time.
> 
>    Writing code in any computer language is no easy task and TradeStation’s EasyLanguage™ is no exception. The job with EasyLanguage, however, is greatly simplified because of the program’s user friendly editor and the inclusion of many built in functions and plenty of sample code.
> 
>    Once our program has been written, we then move into the testing phase. To begin with, we must choose one or more data series to test. For stock traders this is an easy task. Futures traders, however, are faced with contracts that expire after a relatively short period of time. I like to do my initial testing using a continuous (spread adjusted) price series popularized by Jack Schwager. (_Schwager on Futures: Technical Analysis_, Wiley, 1996.) If those results look promising, I then move on to actual contracts.
> 
>    Next, we must decide how much data to use when building our system. I use the entire data series, without saving any for out-of-sample testing (building your system on part of the data and then testing it on the remaining “unseen” data). Many experts would disagree with this approach, but I believe it to be the best with my methodology that relies on good solid concepts, virtually no optimization, and a testing procedure that covers a wide range of parameter sets and markets. I start with a methodology that I believe to be sound and then test it to either prove or disprove my theory. I have found that most individuals do the reverse, they test a data series to arrive at a trading system.
> 
>    I do not account for transaction costs (slippage and commissions) when testing systems, but instead factor them in at the end. I believe that this keeps the evaluation process more pure and allows my results to remain useful should certain assumptions change in the future.
> 
>    I require my systems to work across:
> 
>    - **Different sets of parameters**. If I were considering using a 5/20 moving average crossover system, then I would expect 6/18, 6/23, 4/21, and 5/19 to also perform reasonably well. If not, I immediately become skeptical of the 5/20 results.
> 
>    - **Different periods of time** (e.g. 1990-95 and 1981-86). A system that tests well in the Japanese Yen over a recent five year period should also test reasonably well over any other five year interval. This is another area where I appear to hold the minority point of view.
> 
>    - **Many different markets**. A system that has worked well in crude oil should also work well in heating oil and unleaded gasoline over the same period of time. If not, I will look for an explanation and will usually discard the system. I go even further than this, however, and test that same system across my entire database of markets, expecting it to perform well in the majority of them.
> 
>    Once our testing is complete, let us visually inspect the computer generated trading signals on a price chart to ensure that the system does what we intended it to do. TradeStation facilitates this process by placing buy and sell arrows directly on the chart for us! If the system does not do what it is supposed to do, we need to make the necessary corrections to the code and test it again. Keep in mind that very few ideas will test out profitably, usually less than 5%. And, for one reason or another, most of these “successful” ideas will not even be tradable.
>
> 5. Evaluate the results
> 
>    Let us try to understand the concept behind our trading system. Does it make sense or is it just a coincidence? Analyze the equity curve. Can we live through the drawdowns? Evaluate the system on a trade-by-trade basis. What happens if a signal is a bad one? How quickly does the system exit from losers? How long does it stay with the winners? Make sure we are completely comfortable with the test results, otherwise we will not be able to trade this system in real time.
> 
>    Three key TradeStation statistics to analyze are:
> 
>    - **Profit factor**. Equals Gross profit on winning trades/Gross loss on losing trades. This statistic tells us how many dollars our system made for every $1 it lost, and is a measure of risk. Long term traders should aim for profit factors of 2.00 or higher. Short term traders can accept slightly lower numbers.
> 
>    - **Avg trade (win & loss)**. This is our system’s mathematical expectation. It should at least be high enough to cover transaction costs (slippage and commissions); otherwise we will be losing money.
> 
>    - **Max intraday drawdown**. This is the biggest drop, in dollar terms, from an equity peak to an equity trough. I prefer to do this calculation on a percentage basis. I also differentiate between drawdowns from a standing start (where I am losing money from my own pocket) versus drawdowns from an equity peak (where I am giving back profits taken from the markets). I am usually more lenient with the latter.

While Murphy's book is a great overall introduction into _Technical Analysis_, there are other books that are also indisposable. One of such books is [Japanese Candlestick Charting Techniques](./TECHNICAL.md#japanese-candlestick-charting-techniques), which focuses on trend patterns. Notes were also taken from this book.

## Making Money

The main aim for investors is to _make money_. Investors do this when the enter the stock market by profiting from _dividends_ and _captital gains_ coming from the assets that they trade - businesses.

So, basic techniques to do this involves getting in on stocks when it is selling for the first time as an IPO, selling in an economic depressing period or an industry meltdown, where they get them at a bargain. When the stocks appreciate in value over time, they cash in on the _captital gains_ by selling the stock at the most appropriate time. Time is crucial during trading. If you miss a window, you miss out on the opportunity to profit from _capital gains_. Investors who feel confident in _technical analysis_ get excited about these opportunities.

On the more conservative side of trading, there are those protégés of Buffet that look for _durable competitive advantage_ by working out the revenue growth, intrinsic value, studying the background of the leaders of the businesses and, most importantly, zone in on the _dividend policy_. For some investors, if the company is not paying _dividends_, it's a ***no-go***. They will not invest in a stock that is associated with a business that does not pay _dividends_.

Once the _dividend yeild_ is high and the business can be sustained for a long period of time, it is a pretty attractive prospect for investors.

## News

_News_ can be crucial to investors but what they look for are [corporate actions](./ACTIONS.md) that will affect the stock in a _bullish_ or _bearish_ way. Will stock price go up based on a particular news? Or will go down? Or will is this news _neutral_ meaning it does not affect _price movement_?

News can be crucial, especially to investors that lean more towards _Technical Analysis_.

## Conclusion

So, in a nutshell that is what analysis on stocks are about: analysing the asset, analysing people's perception of the stock and paying attention to environment in which the asset operates.

## References

1. The Art of Currency Trading by Brent Donnelly
2. Corporate Finance: The Core, Global Edition by Jonathan Berk and Peter Demarzo
3. Predictably Irrational by Dan Ariely
4. Thinking Fast and Slow by Daniel Kahneman

## Videos

1. [How do I Analyse IPOs | Top 10 Analysis Parameters for IPOs](https://youtu.be/tbc8zLcbW5Q?si=1aDREQxh8BKvEfHu) - [CA Rachana Phadke Ranade](https://www.youtube.com/@CARachanaRanade)
1. [How to Analyze an IPO: A complete Guide | Top 5 Tips to Analyze an IPO the Best Way](https://youtu.be/1iBlLTvIxX8?si=QXtU614CADHgc__O) - [Prateek Singh - LearnApp](https://www.youtube.com/@PrateekSinghLearnApp)
1. [How I Pick Stocks](https://youtu.be/IPwDxoomxuA)