# Jamaica's Stock Market Industry

| | Main Questions | Jamaica's Landscape |
|:--- |:--- |:--- |
| <p><strong>Competitors</strong><br /><small>Identifies incumbent competitors and their relative strengths</small></p> | <ul><li>Who are our competitors?</li><li>Who are the dominant players?</li><li>What are their competitive advantages or disadvantages? (Describe their main offers)</li><li>Which <i>customer segments</i> are they focusing on?</li><li>What is their <i>cost structure</i>?</li><li>How much influence do they exert on our <i>customer segments</i>, <i>revenue streams</i>, and margins?</li></ul> | <ul><li>See [competitors](#competitors).</li><li>Main competitors: JTrader Pro and MyMoneyJA.</li><li>See [competition analysis](#competition-analysis).</li><li>Most competitors are focused on investors/traders including retail traders.</li><li>Don't know their cost structure. May have to reverse engineer.</li><li>Some players only provide analysis tools but have a significant following</li></ul> |
| <p><strong>New Entrants</strong><br /><small>Identifies new, insurgent players and determines whether they compete with a business model different from yours</small></p> | <ul><li>Who are the new entrants in your market?</li><li>How are they different?</li><li>What competitive advantage or disadvantages do they have?</li><li>Which barriers must they overcome?</li><li>What are their <i>value propositions</i>?</li><li>Which <i>customer segments</i> are they focused on?</li><li>What is their <i>cost structure</i>?</li><li>To what extent do they influence your <i>customer segments</i>, <i>revenue streams</i>, and margins?</li></ul> | <ul><li>As of 2023, there are no new entrants</li></ul> |
| <p><strong>Substitute Products and Services</strong><br /><small>Describes potential substitutes for your offers - including those from other markets and industries</small></p> | <ul><li>Which products or services could replace ours?</li><li>How much do they cost compared to ours?</li><li>How easy it is for customers to switch to these substitutes?</li><li>What business model traditions do these substitute products stem from (e.g. high-speed trains versus airplanes, mobile phones versus cameras, Skype versus long-distance telephone companies)?</li></ul> | <ul><li>There are no applications that provide ample analysis on a stock trading platform.</li><li>JTrader Pro is free but on-boarding involves many steps that takes time.</li><li>Retail investors will have to fill out paper forms with their brokers to switch to it.</li><li>The business model are based on a traditionally fragmented operations.</li></ul> |
| <p><strong>Suppliers and Other Value Chain Actors</strong><br /><small>Describes the key value chain incumbents in your market and spots new, emerging players</small></p> | <ul><li>Who are the key players in your industry value chain?</li><li>To what extent does your business model depend on other players?</li><li>Are peripheral players emerging?</li><li>Which are most profitable?</li></ul> | <ul><li>See [key players](#key-players). _Infographic of operations needed_.</li><li>Analsis is heavily dependent on [market data providers](#market-data-providers). Trading is dependent on the [clearing house](#clearing-house). [Regulators](#regulators) oversee on-boarding and trading practices.</li><li>Stock trading and analysis platforms would be considered _peripheral_ in this market. Anything more _peripheral_ would be further down the value stream and would not be beneficial for business.</li><li>Jamaica Stock Exchange makes around 25% profit annually.</li></ul> |
| <p><strong>Stakeholders</strong><br /><small>Specifies which actors may influence your organization and business model</small></p> | <ul><li>Which stakeholders might influence your business model?</li><li>How influential are shareholders? Workers? The government? Lobbyists?</li></ul> | <ul><li>All [key players](#key-players) except the Market Makers.</li><li>Government has the greatest influence in making on-boarding _frictionless_.</li></ul> |

## Key Players

![Stages of Stock Trading in Jamaica](/.attachments/jamaica.stock.exchange.landscape-3.png)

Steps 1 (Transfer funds through bank and notify broker via email) and 2 (Communicate order through JTrader or to broker via email) can be done in any order but funds will have to be transferred through the bank for the broker to receive it.

Once the broker acknowledes the funds have been received at Step 3, then the broker approves funds for use in JTrader or, if the investor prefers to also place order through broker, asks the broker to place the order (whether it be BUY or SELL).

As of December 2023, the Jamaica Stock Exchange uses the NASDAQ electronic platform to match and fill orders so all orders are either placed directly onto that platform through a user interface that the broker's accredited trader uses or through the NASDAQ API. So, at Step 4, orders are placed into the NASDAQ system.

It's possible that a trading platform can be built by accessing Jamaica's stock trading data through the NASDAQ API. But is it possible to gain this access without permission from Jamaica Stock Exchange? Is it possible that Jamaica Stock Exchange operates as an intermediary for this region by offering their ["API Services"](https://www.jamstockex.com/services/api-services/),

> **Market Data Feed (MDF)**
> 
> The Market Data Feed (referred to as the MDF) is a JavaScript Object Notation (JSON), Application Programming Interface (API) that is used to display real-time market and allows consumers to:
> 
> - Display real-time market data to their customer base.
> - Populate public data walls or websites.
> 
> _Market Data API – US$4,000.00 per annum_
> 
> ...
> 
> To subscribe to the services above,  please contact the [marketing department](mailto:jsegroupmarketing@jamstockex.com)

See below results of conversation with Andrew Martin, Senior Database Administrator,

**[Andrew Martin](https://www.linkedin.com/in/andrew-martin-b5031039/)**

 1. Do you have any documentation about the structure of the information?
    
    No. API consumed by the public is in development but only brokers use the current API.

 2. As it relates archived information, can a customer decide how they want the information structured? (This is for archival data not the API)
    
    Information that was once on the site for download is old. The latest information will have all the necessary details for each record. Details on how the information can be delivered should be discussed with Suzzette McNaught (the IT Manager)

 3. I understand that the NASDAQ platform communicates with the JCSD system. What is the nature of the communication and how often does this communication happen? (Is it just during the creation of an account?)
 
    JCSD's settlement system is slave when NASDAQ is master during order placement and match making. JCSD is the master when the account is being created.

**[Suzzette McNaught](https://www.linkedin.com/in/suzettemcnaught/)**

 1. I see API services advertized on the JSE site. Is there any documentation available for the API?
 2. What functions will be available from the API?
 3. What's involved in making request for archived data? Format? Data structure?

![Stages of KYC in Jamaica](/.attachments/jamaica.stock.exchange.landscape-kyc.png)

When someone indicates interest in investing in the stock market, the brokers are engaged and they are the ones that take the prospect through all the KYC steps to meet the due diligence needs to fulfill legal requirements. The information gathered usually includes, identity information, proof of address and sources of funds.

At step 3 in the illustration above, the broker has to review the information and take it through a process of approval. The most critical part of the information is the identity document. While it is reviewed and approved before being uploaded to the JCSD system, it has to be validated by a Government system.

API solutions provided by [Credit Info](https://creditinfo.com/) can be used to retrieve and validate identity documents from customer against Government systems on the internet through the browser. The GOJ is also making moves to make KYC easier by digitizing documents through NIDS[^2]. The finance sector will benefit from this initiative as it will simplify and speed up the process of on-boarding new customers. This initiative is something that is encouraged by the World Bank.[^3] So, we can expect that other countries that are aligned with the World Bank have similar ongoing projects.

The archival information can be had for each year at a rate of J$5,500 per year (according to email received from Shanari McCarthy, Marketing Officer, on February 7, 2024). From 2020 back to 1968 is 52 years. Fifty two (52) years of stock prices, indices and dividend history will cost around J$330,000. Retrieving the annual reports dating back to that time maybe a challenge. But a relationship can be established from doing business first by getting the stock prices and dividends before demanding annual reports.

### Market Makers

The specific market makers in Jamaica's stock market might have changed or evolved. In Jamaica's stock market context, market makers are entities that provide liquidity and facilitate trading by offering to buy and sell specific securities at quoted bid and ask prices. They play a crucial role in ensuring there is a continuous market for securities.

At the time of my last update, some of the market makers operating in the Jamaica Stock Exchange (JSE) included:

1. **Barita Investments Limited:** Barita is a financial services company that operates as a market maker on the JSE. They facilitate trading by providing bid and ask prices for various securities.

2. **JMMB Securities Limited:** JMMB is a subsidiary of the JMMB Group and also serves as a market maker on the JSE. They help maintain liquidity in the market for certain securities.

3. **NCB Capital Markets Limited:** NCB Capital Markets, a subsidiary of the National Commercial Bank (NCB), is another market maker on the JSE. They provide liquidity for various securities.

Please note that the information provided might have changed since my last update, and I recommend checking with the Jamaica Stock Exchange or reliable financial news sources for the most up-to-date information on market makers in Jamaica's stock market.

### Clearing House

As of my last update in September 2021, the Jamaica Central Securities Depository (JCSD) is the central clearing and settlement entity for the Jamaica Stock Exchange (JSE). The JCSD handles the clearing, settlement, and custody of securities traded on the JSE. It's responsible for ensuring that trades are settled, ownership is transferred, and the associated securities are properly accounted for.

Please note that the information provided is based on the situation as of September 2021, and there might have been developments or changes since that time. I recommend checking with the Jamaica Stock Exchange or reliable financial sources for the most current information about clearinghouses for the JSE.

### Market Data Providers

As of my last update in September 2021, there are several market data providers that offer information and data related to Jamaica's stock market. These providers offer real-time and historical data on stock prices, trading volumes, indices, and other market-related information. Keep in mind that the market data landscape can change, so it's advisable to verify this information with current sources. Some of the market data providers in Jamaica's stock market might include:

1. **[Bloomberg Terminal](https://www.bloomberg.com/professional/solution/bloomberg-terminal/):** Bloomberg is a well-known financial information and data provider that offers real-time market data, news, and analysis on various asset classes, including stocks, bonds, and commodities.

2. **[Reuters](https://www.reuters.com/business/finance/):** Reuters provides financial news and market data, including information about the Jamaica Stock Exchange.

3. **Jamaica Stock Exchange (JSE):** The JSE itself provides market data on its website, including real-time stock prices, trading volumes, and other market-related statistics.

4. **Jamaica Central Securities Depository (JCSD):** The JCSD, which is responsible for the clearing and settlement of securities in Jamaica, may also provide market data and information related to securities trading.

5. **Financial News Media:** Various financial news websites, both local and international, might offer market data and news related to Jamaica's stock market.

6. **Local Financial Institutions:** Some local financial institutions, such as brokerage firms and investment banks, might provide market data and research reports on Jamaica's stock market to their clients.

7. **Independent Data Providers:** There might be independent data providers that offer specialized market data and analysis for Jamaica's stock market.

Please note that the availability of specific market data providers can change over time. It's recommended to directly check with the Jamaica Stock Exchange, financial news outlets, and relevant financial institutions for the most up-to-date and accurate information on market data providers for Jamaica's stock market.

### Regulators

As of my last update in September 2021, the regulatory oversight of the Jamaican stock market is primarily carried out by the Financial Services Commission (FSC) and the Jamaica Stock Exchange (JSE). These organizations have roles in regulating and overseeing various aspects of the financial and securities markets in Jamaica.

1. **Financial Services Commission (FSC):** The FSC is the main regulatory body responsible for supervising and regulating Jamaica's financial services industry. It oversees a wide range of financial institutions and activities, including securities dealers, investment advisers, and collective investment schemes. The FSC plays a crucial role in ensuring the integrity, stability, and transparency of Jamaica's financial markets.

2. **Jamaica Stock Exchange (JSE):** While the JSE primarily operates as a stock exchange, it also plays a role in regulating and overseeing the activities of market participants. The JSE has its own set of rules and regulations that govern trading activities on its platform. It ensures compliance with these rules to maintain fair and transparent trading practices.

Please note that regulatory landscapes can evolve, and there might have been changes or developments since my last update. It's recommended to verify this information with current sources, such as the Financial Services Commission and the Jamaica Stock Exchange, for the most accurate and up-to-date information about regulatory authorities in Jamaica's stock market.

### Financial News Media Houses: Bloggers and Journalists

As of my last knowledge update in September 2021, several financial news media outlets provide coverage and news related to Jamaica's stock market and financial developments. Please note that the availability of sources can change over time, so it's a good idea to verify this information with current sources. Here are some financial news media houses that might deliver news on Jamaica's stock market:

1. **[Jamaica Observer Business](https://www.jamaicaobserver.com/business/):** The business section of the Jamaica Observer often covers financial news, including updates on the stock market and economic developments.

2. **[The Gleaner Business](https://jamaica-gleaner.com/business):** The Gleaner's business section also provides coverage of financial news and events, including information about the Jamaica Stock Exchange.

3. **[Loop News Business](https://jamaica.loopnews.com/category/loopjamaica-business):** Loop News offers a business section that covers economic and financial news, including updates on the stock market.

4. **[Nationwide News Network (NNN)](https://nationwideradiojm.com/):** NNN covers a wide range of news topics, including business and financial news, which can include coverage of the stock market.

6. **[RJR News Business](https://radiojamaicanewsonline.com/business):** RJR News offers business news coverage, including information about the stock market and other financial developments.

7. **[TVJ](https://www.televisionjamaica.com/) Business Report:** Television Jamaica (TVJ) provides business news updates, which may include coverage of the stock market.

8. **[Jamaica Gleaner's Hospitality Jamaica](https://jamaica-gleaner.com/hospitality-jamaica):** While it mainly covers the hospitality sector, this publication sometimes includes coverage of economic and financial matters, including the stock market.

Please keep in mind that the availability and content of financial news sources can change. It's recommended to visit the websites of these media outlets or consult reputable news aggregators for the most up-to-date and accurate information about financial news coverage related to Jamaica's stock market.

_While the above was generated by ChatGPT, the information immediate below in this section was my addition._

Other minor players that deliver news and offer thought leadership on matters related to Jamaica's Stock Market includes,

1. **[MoneyMax 101](https://moneymax101.com/):** MoneyMax 101 provides a news feed for markets within the Caribbean and North America, while offering portfolio analysis tools as part of paid subscription model. Backlinks are made to [Jamaica Stock Exchange](https://www.jamstockex.com/newsroom/), [YouTube](https://www.youtube.com/) and other online news media houses.

2. **[Every Mickle](https://www.everymickle.com/):** Every Mickle offers a blog maintained by thought leader, Randy Rowe.

3. **[IC Insider](http://icinsider.com/):** News, Views & Advice from Investors's Choice.

4. **[Jamaica Stock Exchange Newsroom](https://www.jamstockex.com/newsroom/):** The Jamaica Stock Exchange provides a compilation of the major Company News, Corporate Actions, Upcoming AGM’s or EGM’s and the Bond Indices on a weekly basis.

### Stock Brokerage Firms

As of my last knowledge update in September 2021, there are several brokerage firms in Jamaica that facilitate buying and selling of securities on the Jamaica Stock Exchange (JSE). These firms act as intermediaries between investors and the stock market, executing trade orders on behalf of their clients. Please note that the brokerage landscape might have changed since then, so it's a good idea to verify the information with current sources. Here are some brokerage firms that were active in Jamaica's stock market:

1. **Barita Investments Limited:** Apart from offering investment banking services, Barita Investments also operates as a brokerage firm, providing trading and investment services to clients.

2. **Jamaica Money Market Brokers (JMMB) Securities Limited:** A subsidiary of the JMMB Group, JMMB Securities offers brokerage services for securities trading and investment.

3. **NCB Capital Markets Limited:** A subsidiary of the National Commercial Bank (NCB), NCB Capital Markets offers brokerage services for trading on the JSE.

4. **Sagicor Investments Jamaica Limited:** Sagicor Investments, a part of the Sagicor Group, provides brokerage services for securities trading and investment.

5. **Scotia Investments Jamaica Limited:** A subsidiary of Scotiabank, Scotia Investments offers brokerage services for clients looking to trade on the JSE.

6. **First Global Bank Limited:** First Global Bank provides brokerage services as part of its suite of financial services.

7. **Mayberry Investments Limited:** Mayberry Investments is another well-known brokerage firm in Jamaica, offering a range of investment services.

8. **Proven Wealth Limited:** Proven Wealth offers brokerage and investment services to its clients.

9. **Stocks & Securities Limited:** Stocks & Securities is a brokerage firm that provides trading and investment services in Jamaica.

10. **VM Wealth Management:** VM Wealth Management offers brokerage and wealth management services to individual and institutional clients.

Please be aware that this is not an exhaustive list, and there might be other brokerage firms operating in Jamaica's stock market. To get the most accurate and up-to-date information about brokerage firms in Jamaica, it's recommended to check with the Jamaica Stock Exchange or consult reliable financial sources.

<image src="/.attachments/chatgpt-logo.png" alt="Chat GPT Logo" width="16" height="16" />

_I noticed that ChatGPT did not list the following as brokers,_

1. **[GK Capital Management Limited](https://gk-capital.com/):** A subsidiary of GraceKennedy Financial Group offers brokerage services for trading on the JSE.

See [Brokers/Member Dealers](https://www.jamstockex.com/investors/brokers/) for more Stock Brokerage Firms that could be working within the industry.

Simon Johnson community leader for "Stocks on d' Rocks" shares information gathered about Stock brokerage firm on Twitter on January 2024,

![Top 4 Brokers in Jamaica in 2024](/.attachments/Screenshot_20240111_130252_Samsung%20Internet.jpg)

A little bit more details on the broker firm,

![More on the Top 4 Brokers in Jamaica in 2024](/.attachments/Screenshot_20240111_092950_Telegram.jpg)


### Communities and Thought Leaders

#### Communities

As of August 2023, a few communities exist that focus on analysing Jamaica's public businesses and the Stock Market. Some communities include,

1. **[Stocks on the Rocks](https://www.youtube.com/@stocksontherockssotr985):** Stocks on the Rocks #SOTR started as a means of creating an open space to have conversations around finance. The aim is to promote Financial Literacy by discussing seemingly complex Investment and Finance lingo in simple ways to all cross-sections of people. We believe in holistic financial development through the promoting of proper saving and money management habits, Investing wisely, and Insuring our hard-earned assets. This community started in July 2019.

2. **[Learn, Grow and Invest](https://www.youtube.com/c/LearnGrowInvestClub):** Learn Grow Invest is an investment community founded on Biblical principles and built on Deuteronomy 8:18. The community was founded by the husband and wife team - Jermaine & Renate McDonald.

#### Thought Leaders

As of August 2023, there are at least 5 thought leaders (or social media influencers) that brings some focus on the Jamaican stock market,

1. **[Randy Rowe](https://twitter.com/RTRowe):** Randy Rowe is co-founder at [MyMoneyJA.com](https://mymoneyja.com/) and team lead at [Every Mickle](https://www.everymickle.com/). He prefers to be known for being a Retail Investor Advocate (not an Investment Advisor).

2. **[Kalila Reynolds](https://twitter.com/kalilahrey):** Kalila Reynolds is a Belizean journalist and poet. She currently resides in Kingston, Jamaica, where she co-hosts the popular current affairs radio programme, [Nationwide This Morning](http://nationwideradiojm.com/nationwide-this-morning) on Nationwide News Network. She hosts a programme called, _Taking Stock_ on her YouTube channel, [Kalila Reynolds Media](https://www.youtube.com/channel/UC00lCQiVt90KVYzkELVqrlA).

3. **[Jermaine McDonald](https://twitter.com/jerrymackd):** Jermaine McDonald is the founder of the [Learn, Grow, Invest Club](https://learngrowinvestclub.com/) and educates prospects on personal finance and the Jamaican stock market on his YouTube channel, [Learn Grow Invest](https://www.youtube.com/c/LearnGrowInvestClub).

4. **[Odetta Rockhead-Kerr](https://www.instagram.com/odettarockheadkerr/?hl=en):** Odetta Rockhead-Kerr personal finance advice and tips on making money on her YouTube channel, [Odetta Rockhead-Kerr](https://www.youtube.com/@RockstarAcademy)

5. **Anna Nova:** Anna Novia offers personal financial advice on her YouTube channel, [Anna Novia](https://www.youtube.com/@annanovia94)

6. **Demetress Fairman:** Demetress Fairman offers personal financial advice on his YouTube channel, [Demetress Fairman](https://www.youtube.com/@DemetressFairman)

Here's how they stack up,

| Thought Leader  | Following | Portfolio | Focus |
|:---             |:---       |:---       |:---   |
| Randy Rowe      | 10.3K followers (Twitter) | 68K posts (Twitter) | stocks, personal finance, social commentary |
| Kalila Reynolds | 49.9K subscribers | 1.1K videos | personal finance, financial education |
| Jermaine McDonald | 9.08K subscribers | 251 videos | faith, personal finance, financial education |
| Odetta Rockhead-Kerr | 600K subscribers | 373 videos | making money |
| Anna Novia | 27K subscribers | 102 videos | travel, self-development, making money |
| Demetress Fairman | 12.6K subscribers | 183 videos | business, making money, personal finance |


## Competitors

Q. Market share?

A. Can get the market share for brokerages from JCSD

Q. Customer base?

A. _Don't know_

Q. Marketing tactics?

A. Most seem to rely on word-of-mouth, investment clubs and thought leaders (or influencers).

Q. Distribution channels? 

A. All distributes analysis over the internet. Trading information is also distributed over the internet. Trading is facilitated by a stock brokerage firm.

Q. Financial performance?

A. Most of these applications except the JTrader Pro is owned privately. JTrader Pro is owned by the Jamaica Stock Exchange.

### Competition Analysis

#### Domain Authority

![Domain Authority by Tier](/.attachments/domain-authority-by-tier.png)

> What’s a good score? It depends. But a good DA is a HIGH DA.
>
> However, it depends on how long the domain and your business have existed. To give you a quick sense, websites that have been around a very long time, like Google and Apple, will have a high DA (95+).
>
> Conversely, startups with a new website will probably be near 10-20. It’s easier to move the needle when it’s lower than trying to move from 70 to 80 plus. On average, Domain Authority of 50 and above is good, with 60-70 very good and above 80 excellent.
>
> Domain Authority builds over time. It is based on a scale that measures the likelihood of a website ranking on Google’s SERP. Today it is still considered one of the many metrics executives, heads of marketing, and SEO professionals should pay attention to. But when looking and analyzing, the playing field should be equal. Compare your site and DA to those of similar value.[^1]

See [Domain Authority: What is Domain Authority and why it is important?](https://moz.com/learn/seo/domain-authority).

|     | Founded | Domain Authority | Linking Domains | Inbound Links | Ranking Keywords |
|:--- |:--- | ---:| ---:| ---:| ---:|
| [Simply Wall Street](https://simplywall.st) | Mar 2015 | 64 | 22.5k | 3.1m | 114.2k |
| [TIKR Financial Data](https://app.tikr.com/) | Aug 2020 | 34 | 430 | 7.9k | 2 |
| [MoneyMax 101](https://moneymax101.com/) | Nov 2011 | 21 | 238 | 1.3k | 81 |
| [Every Mickle](https://www.everymickle.com/) | March 2016 | 16 | 53 | 536 | 17 |
| [MyMoneyJA](https://mymoneyja.com/) | Nov 2020 | 12 | 193 | 367 | 0 |
| [JSE Investor](https://jseinvestor.com) | Jan 2017 | 9 | 131 | 428 | 92 |
| [JTrader Pro](https://jtraderpro.jamstockex.com) | Nov 2020 | 40 | 60 | 149 | 3 |
| [Sagicor eInvest](https://einvest.sagicorjamaica.com/login) | April 2021 | 34 | [11](#sagicor-einvest-linking-domains) | 18 | 0 |
| [JMMB Moneyline](https://moneyline.jmmb.com) | May 1998 * | 32 | 2.2k | 218.8k | 432 |

Also, see mobile apps below,

| | Rating | Downloads | Release |
|:--- | ---:| ---:|:--- |
| JSA | 4.3 | 5k | May 2020 |
| JStock | 4.8 | 1k+ | Nov 2020 |

##### Sagicor eInvest Linking Domains

| Root Domain | DA | Linking Domains | Spam Score |
|:--- | ---:| ---:| ---:|
| sagicor.com | 43 | 2970 | 28% |
| link-de.com | 37 | 5401 | 21% |
| freekeyworddifficultytool.com | 36 | 4129 | 39% |
| linkmio.com | 35 | 5460 | 20% |
| nutter.life | 35 | 1050 | 9% |
| nitter.ir | 34 | 972 | 17% |
| c99.nl | 31 | 2310 | 37% |
| fdn.org | 30 | 365 | --% |
| dataslist.com | 9 | 46 | 38% |
| loginoniq.com | 6 | 58 | 8% |
| ... | | | |

#### Feature & Price Plan Review

##### MyMoneyJA

I think the greatest feature on MyMoneyJA is offered in the **Portfolio** section. The charts shown are standard across every stocks analysis platform. The presentation of the information is more friendly to experts. Portfolio information is presented in separate cards rather than a grid, which makes a quick comparison difficult. The information presented on most pages including the _Overview_ confronts the user with cognitive loading problem, too much information all in one area.

I think their **Dollar-cost Averaging** feature is onto something but a better idea is a feature for the bearish investors to show how much investment is required to break-even a stock that is in a loss.

![MyMoneyJA Dollar-cost Averaging Feature](/.attachments/mymoneyja-dca.png)

My first impression of the **Corporate Actions** is that it needs context, the context of the company that they're associated with. I think Jamaica Stock Exchange has a better delivery of the _Corporate Actions_ within the _Instrument Summary_.

![Jamaica Stock Exchange Instrument Summary of a Common Stock](/.attachments/jse-instrument-summary.png)

No real value is added to news other than financial news related to companies on the stock exchanged is centralized into one place. The claim is that the news is filtered and curated. Because the news presented is broadened to more sources other than the Jamaica Stock Exchange, the feeds from the other sources has to be filtered. There is no curation, users are sent directly to the source of information when news links are clicked.

When it comes to alerts, I think people are less welcoming to more bombardment of information to their devices and personal space. Less is more (A more minimal approach is more effective). I don't think alerts provide any great value to investors. It may provide some value to day and swing traders but they may prefer to be using a stock screener where they can quickly find opportunities for capital gains.

The financial reports are in PDF format, which is what is provided by either the listed company's website or the Jamaica Stock Exchange. It's listed under the FREE plan as a value added feature by stating, "Current and last financial year report".

In their attempt to appeal to prospects they have announced their future plans in their price plans. I think this price plan has not changed since 2020 and yet this review was done in 2023. They have promised,
 - Sentiment analysis on news and social media chatter
 - Private/public contests
 - Themes (dark mode)
 - Access to market research newsletter
 - Ability to run custom market data queries

There are two promised features that are stand outs: the sentiment analysis and the market research newsletter. Newsletters are provided by some Stock Brokerage firms and it basically consist of insightful information about the market trends. So, for MyMoneyJA would have to offer a unique selling proposition to appeal to investors who already are receiving newsletters from their Stock Brokers. The sentimental analysis can be a real unique selling proposition if they present the information in a way that is digestable to the investors.

![MyMoneyJA Offers and Price Plans](/.attachments/mymoneyja-price-plans.png)

So, what does MyMoneyJA offer to the regular investor that is of unique value?

I think MyMoneyJA present opportunities to offer unique value to investors with the following features,
 1. Full history of Corporate Actions
 2. All history of company news
 3. Views of the current market queue (BUY and SELL orders) and live trading data
 4. Sentiment analysis on news and social discourse about companies

History and live information can be had from the Jamaica Stock Exchange. So, their real value-added is in the user experience of the provided information. The sentiment analysis is the only stand out that I see from this app as a unique selling proposition. All other features are standard for applications that offer stock market analysis, even the dividend calculations.

##### MoneyMax 101

MoneyMax 101 is basically a WordPress Blog that uses plugins to bring it's services to their prospects and customers. The user experience, in terms of page layout, look and feel needs improvement.

![MoneyMax 101 Offers and Price Plans](/.attachments/moneymax101-price-plans.png)

The offerings in their price plan are similar to MyMoneyJA. The main difference is that the features are summarized under categories of interest to investors. The main takeaway from this particular application is the pricing for subscribing to their services. So, the highest available plan costs US$10.49 per month. This positions them somewhere in between MyMoneyJA and Simply Wall Street. One of their plans is "Coming Soon". How long has that subscription plan been "Coming Soon"?

##### Simply Wall Street

[Simply Wall Street](https://simplywall.st/) has the most comprehensive list of features when it comes to fundamental analysis. The page designs are engaging and the information is presented within context. This application gathers information on stocks for about 89 jurisdictions (countries), which is mind-blowing. It's global reach is one of its greatest strengths. Also, what must be noted is the ability for this application to gather the most current information that's usually found in the annual and quarterly report of every company listed on the Jamaica Stock Exchange.

![Simply Wall Street Markets: Jamaica](/.attachments/simplywall.st-markets.png)

I think that their marketing tactics when it comes to price plan is the most attractive and engaging of all the applications that offer analytics for the Jamaican market. The prices place emphasis on volume of information that the prospects can gather. There is some mention of additional features but when it comes to features, only 2 features sets the FREE plan apart from the UNLIMITED plan: the Stock Screener and the Export feature.

![Simply Wall Street Offers and Price Plans](/.attachments/simplywall.st-price-plans.png)

As it relates to the marketing tactics within the application, they make good use of the bull in a suit as their avatar.

The dashboard presents a lot of information but the cognitive load does not appear overwhelming. The main theme is the news and how well industries over the world are doing. The information on the dashboard can be defaulted to show for a particular jurisdiction once that is set in the customer's profile.

![Simply Wall Street Dash](/.attachments/simplywall.st-dash.png)

The news within this application is indeed _filtered and curated_. By observing the icons for each news item, you can deduce that the news is being classified. The source is probably the Jamaica Stock Exchange but they don't make any reference to that in their application. Corporate actions are bundled into news, which makes sense. Corporate actions like dividend payout announcements are given a narrative to explain the announcement.

See below a screenshot of the _curated_ dividend announcement.

![Simply Wall Street Dividend Announcement](/.attachments/simplywall.st-dividend.png)

A company report on Simply Wall Street contains sections for,

1. Valuation (which includes Intrinsic Valuation)
2. Future Growth
3. Past Performance
4. Financial Health
5. Dividend
6. Management
7. Ownership

All that information is suitable for investors that are keen on fundamental analysis of companies listed on the stock exchange. While the information is comprehensive, it can be overwhelming. I think this tool is a value investor's dream. One thing that is intended to be intuitive but can be consterning is the snowflake. The snowflake is intended to be a _quick "eyeball" scan of a particular stock, a group of stocks or the stock market as a whole_. The feedback that I have received from one customer is that she was confounded as to what to think about it and how to make decisions from it. I see it and I understand it but would I make a stock order decision based on it? No. It's like a scorecard that tries to involve the complexities of dividend payout, intrinsic value, financial health, past performance and future prospects. Most of the times, there's not enough information to arrive at a conclusion for some of the 5 points of complexity of the snowflake.

![Simply Wall Street Company Report Header](/.attachments/simplywall.st-company.report.png)

One of the most intriguing features of the company report is the intrinsic valuation. Intrinsic valuation can be a very involved process and is susceptible to bias. Some describe the process of intrinsic valuation as art using mathematics. it's probably one of the most sophisticated metric to arrive at. For investors that are into fundamental analysis, this is a must-have feature.

![Simply Wall Street Intrinsic Value](/.attachments/simplywall.st-intrinsic-value.png)

Other popular metrics are showcased in this application but is done with some visualization to increase the appeal. Take for example the P/E ratio that makes use of a speedometer, where anything over 20x start to go into the red (this is coming from philosophies of Benjamin Graham and Warren Buffet).

![Simply Wall Street P/E Ratio](/.attachments/simplywall.st-pe.ratio.png)

That same visualization concept of using the speedometer is extended to ROCE and ROA.

![Simply Wall Street ROCE and ROA](/.attachments/simplywall.st-more.ratios.png)

A new feature that went into beta testing in 2023 is the _Revenue & Expenses Breakdown_, which makes use of a Sankey diagram.

![Simply Wall Street Revenue & Expenses Breakdown](/.attachments/simplywall.st-revenue.breakdown.png)

This application even extracts ownership information provided in the annual reports.

![Simply Wall Street Ownership](/.attachments/simplywall.st-owners.png)

The company report is impressive!

So, when it comes to comprehensive analysis and presentation of the information, Simply Wall Street outperforms all competitors. The fundamental analysis is provided for 5 companies per month for each customer but when that customer pays for PREMIUM or UNLIMITED service they get more reports and they also get technical analysis from the Stock Screener. Wow! That's hard to outperform.

But what if there are investors who want to compare multiples such as margins and index P/E ratios, where would they get that vizualization? An excellent visualization that allows investors to compare market capitalization for the US Market can be found at [Companies Market Cap](https://companiesmarketcap.com/). This concept can be extended for profit margins, ROA and so on. I do not see where Simply Wall Street does this.

##### JTrader Pro

The JTrader Pro application created by [Software Architects](https://www.softwarearchitectsjm.com/portfolio) can be accessed over the internet at https://jtraderpro.jamstockex.com/. This is a financial trading platform and yet it is not an eCommerce application. It does not allow for users to make payments online to buy stocks. Placing orders has to be placed through Stock Brokerage Firms, which are listed on the platform.

![JTrader Pro: Placing orders](/.attachments/jtrader-3.png)

The investor/trader would place the order on JTrader Pro, where the user would have setup a particular Broker to a JCSD account.

![Accounts Overview](/.attachments/jtrader-accounts-overview.png)

If the orders are BUY orders, the order would have to be followed by a **Pending Fund Request**.

![JTrader Pro Funds In/Out](/.attachments/jtraderpro-funds-in-out.png)

This approach is in contrast to internet FX trading platform, [IQ Option](https://iqoption.com/en), where the wallet for trading is funded through credit card transactions. An important point to note about **IQ Option** is that they provided a _practice account_ as well as a real account.

![IQ Option offering Practice Account](/.attachments/iq-option.png)

The process of trading stocks on JTrader Pro, as mentioned above, demostrates that there is a lot of friction in the trading process. It's important to note that the on-boarding process is also a long  process. Simply put, the on-boarding process involves indicating to your Broker that you're interested in trading on the JTrader platform, providing all the necessary KYC information so that it can be processed by the JCSD. I have personally made request to be on-boarded onto JTrader Pro after making trades through a Broker for over a year. It took over a month to get access to JTrader Pro.

Trading platforms like **JMMB Moneyline** may have less friction in their on-boarding and trading, since the users of **JMMB Moneyline** would have an account with JMMB. In this case, BUY and SELL orders can be more quickly facitlitated since JMMB are custodians of their account. Two-factor security is implemented in the same manner as many banking application to confirm placement of orders.

![JMMB Moneyline Order Screen](/.attachments/jmmb-moneyline-buy-order-screen.png)

See also a screen in **JMMB Moneyline**, where the list of BUY/SELL orders are shown for a particular stock.

![JMMB Moneyline BUY/SELL Orders for a Stock](/.attachments/jmmb-moneyline-buy-stocks.png)

These trading applications also offer the feature to generate statements that show the gains/loss made on stocks within a portfolio. This is pretty much as far as these trading platforms go when it comes to offering analysis.

The experience on **JTrader Pro** and **JMMB Moneyline** are not as immersive as FX Trading Platforms such as **IQ Options**. See a screen from **IQ Options**, where the user can place orders while viewing the live trades.

![IQ Options Trading Dashboard](/.attachments/iq-dash.png)

The **JTrader Pro** platform offers a screen that shows the live BUY and SELL orders of a particular stock but is more for viewing purposes to inform the decision-making. When the user makes the decision, the user will have to navigate to the screen that places the order.

![JTrader Live BUY/SELL orders](/.attachments/jtrader-2.png)

So, all the main features of **JTrader Pro** is to facilitate trading of stocks and monitoring portfolios. The approach to have the trades made through the bank accounts of Stock Broker is slow but it limits the risk of the Jamaica Central Securities Depository (JCSD) from handling fraud that comes from the use of stolen credit cards.

Creating a trading platform must involve access to the live trades, which must come from the central authority, JCSD. The technical and fundamental analysis can be integrated into the trading experience in an immersive way but the real challenge in making trading frictionless is enabling the users to top-up their wallet with a convenient online payment solution, such as credit cards. But the question arises: how do you handle chargebacks that come as a result of using stolen credit cards?

If the risk of using credit cards as the payment solution is taken up, we can look at involving the Brokers by having payments trasferred to their accounts by setting up the backbone of the application with multiple gateway credentials, where each credential is associated with a particular Broker. See screenshot below for an application that stores gateway credentials in database.

![Managing Gateways](/.attachments/manage-gateways-1.png)

Because **JTrader Pro** is owned by the Jamaica Stock Exchange, it has a captive audience. That captive audience may feel that they have to take what Jamaica Stock Exchange has to offer them. But what if a better option could be provided?

![JTrader Accounts Overview](/.attachments/jtrader.accounts.overview.png)

My experience using JTrader Pro was as follows,

 - November 7, 2023 at 9:00 AM. I created a ***Fund In Request*** entry, which was placed in _Pending_ state.
   
   ![JTrader Order View](/.attachments/jtrader.order.view.png)
   
 - November 7, 2023 at 9:14 AM. An ACH Transfer was done through my online banking platform to brokers account.
 - Novermber 7, 2023 at 9:20 AM. Sent email to broker to inform her that money was sent to brokers account and it was to fulfill the ***Fund In Request*** so that I can place a BUY order.
 - November 9, 2023 at 1:34 PM. I sent another email after noticing that I still was not able to place a BUY order. Broker decided to follow up.
 - November 10, 2023 at 10:55 AM. I received an email feedback from JTrader Pro to go ahead and place BUY order as the JTrader Account was updated.
 - November 13, 2023 at 7:58 AM. I placed a BUY order for 970 stock units at $62 per stock unit.
   
   ![BUY Order for NCBFG Units at $62](/.attachments/jtrader.order.62.ncbfg.png)

   [See fee schedule for JSE](https://www.jamstockex.com/investors/fee-schedule/)

   The **GCT Fee** for the transaction above is 15% of the **Broker Fee** (2% of Share Value), **JSE Fee** (0.35 % of Share Value) and **JCSD Fee**. So, 
   
   ```
   GCT Fee = (J$1,202.80 + J$210.49 + J$0) x 0.15 = J$211.9935
   ```

 - November 21, 2023 at ~11 AM. I cancelled the previous BUY order for asking price of $62 because the market started trending up.
 - November 21, 2023 at 11:32 AM. I placed a BUY order for 870 stock units at $69 per stock unit.

   ![BUY Order for NCBFB Units at $69](/.attachments/jtrader.order.69.ncbfg.png)

 - November 21, 2023 at 12:40 PM. A match was made and the order was filled.
 - November 22, 2023 at 1:34 PM. I received a notification from my broker that the order was filled. I had not known this until later that day when I checked by email.
 - November 22, 2023. Logged into JTrader and search to find if my account was updated with the new filled order. The added stock units could not be found in JTrader's "Accounts: Overview"

   ![JTrader Account's Overview](/.attachments/jtrader.accounts.overview-2.png)

 - November 22, 2023. After searching through the interface, I found an option in the main menu, "View Orders".

   ![JTrader Main Menu](/.attachments/jtrader.main.menu.orders.png)

 - November 22, 2023. When the "View Orders" menu link was navigated, the transaction status of the orders were displayed.

   ![JTrader Transaction Status](/.attachments/jtrader.transactions.status.png)

See below screenshot taking note of customer's experience during the fund-in process in JTrader Pro,

![Stocks on d' Rocks members share experience of Fund In](/.attachments/Screenshot_20240111_125349_Telegram.jpg)

##### Few Good Mentions

 - [Investing.com](https://www.investing.com/stock-screener/?sp=country::119|sector::a|industry::a|equityType::a|exchange::124%3Ceq_market_cap;1)
 - [WeBull](https://www.webull.com/)
    - [Webull for Beginners Tutorial - What You MUST Know](https://youtu.be/4CEw1ZNjBMs?si=AOmk11ye6wtrLM5M)
    - [Webull App Tutorial for COMPLETE Beginners! [DON'T FORGET THIS]](https://youtu.be/MMvTMfxT6uE?si=RNTJ1LJJGwToWWYO)
 - [Robinhood](https://robinhood.com/us/en/)
 - [Charles Schwab](https://www.schwab.com/trading/tools-and-platforms)
 - [eTrade](https://us.etrade.com/platforms)
 - [Trading 212](https://www.trading212.com/)
 - [Stockpile](https://www.stockpile.com/)
 - [Go IPO](https://goipo.jncb.com/)

## Further Readings

1. [JSE shortening settlement time again](https://www.jamaicaobserver.com/business/jse-shortening-settlement-time-again/)

## Videos

1. [The Complete Guide to Dividend Investing on the Jamaica Stock Market](https://youtu.be/guhqztem9fA) - [Learn Grow Invest](https://www.youtube.com/@learngrowinvest)
1. [How to trade stocks with Jtraderpro](https://youtu.be/OwlkE77s1AI) - [Kalila Reynolds Media](https://www.youtube.com/@kalilahrey)
1. [Investing in the Jamaica Stock Market for Beginners](https://youtu.be/bsXA7nJ7jW8?si=9r-996221fzkeRLn) - [Learn Grow Invest](https://www.youtube.com/@learngrowinvest)
1. [How to Value Companies Like a Value Investor - Chike Verwey | Learn Grow Invest Meeting - July 2020](https://youtu.be/JdgBlCKAa0M?si=iYWiFcex19X7627A) - [Learn Grow Invest](https://www.youtube.com/@learngrowinvest)
1. [The Top 5 Jamaican Dividend Stock To Invest Right Now in 2022](https://youtu.be/DooE-5QiL_4?si=Sm8La8h7ogpktpk-) - [Garth Grant](https://www.youtube.com/@GarthGrant)
1. [How to Buy Stocks in Jamaica 2022](https://youtu.be/sRaCVQXm-QA?si=XVFmGSwpS3IM4sJN) - [Emar Morrison](https://www.youtube.com/@emarjm)
1. [Robinhood vs Charles Schwab 2023: Best Brokerage?](https://youtu.be/OlTiorM1fYQ)
1. [Robinhood vs Charles Schwab | Which Brokerage Is Better For You?](https://youtu.be/RzmUCm835T4)
1. [Charles Schwab Trading Platform Web Tutorial](https://youtu.be/CZsiRomcUeE)
1. [GOIPO Demo | How To Invest Using GOIPO](https://youtu.be/vyJmKdo_uF8?si=v8Xjsku7--ADhv2k)
1. [The SECRET FEATURES Of Investing.com I Guarantee Will Make You Millions In Forex Trading](https://youtu.be/QPRUjozJa4w?si=qoDodL13HWfXliFt)

[^1]: [Importance of Domain Authority as the Key Site Metric for Growth](https://www.responsify.com/importance-of-domain-authority/) by Ginny Dwyer
[^2]: [NATIONAL IDENTIFICATION SYSTEM (NIDS)](https://opm.gov.jm/portfolios/national-identification-system/)
[^3]: [BOJ to introduce e-KYC this year](https://www.jamaicaobserver.com/business/boj-to-introduce-e-kyc-this-year/)