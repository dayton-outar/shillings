# AI For Financial Research

Artificial intelligence can help investors research faster, compare more evidence, and ask better questions. It can also create false confidence if its output is treated as advice rather than evidence to verify.

The safest mindset is simple: AI is a research assistant, not an investment authority.

## From Rules To Machine Learning

Traditional investment analysis often starts with explicit rules. The investor decides which data matters, calculates ratios, compares companies, and forms a thesis.

Machine learning changes the workflow. Instead of writing every rule directly, the investor trains a model on historical data and asks it to detect patterns.

This can be useful, but it has a major limitation: markets are noisy, adaptive, and affected by human behavior. A model can find patterns in the past that may not survive in the future.

Use cautious language when thinking about model output:

- "This model suggests..."
- "The evidence indicates..."
- "The pattern may imply..."
- "The result needs validation..."

Avoid treating any model as if it can know the future.

## Behavioral Finance

Investors are not always rational. Fear, greed, overconfidence, loss aversion, and herd behavior can all shape markets.

AI can reduce some human weaknesses by applying rules consistently. But it can also create new risks:

- The investor may trust a model too much.
- The model may learn bad patterns.
- The model may fail when the market changes.
- The investor may not understand why the model made a recommendation.

Removing human emotion does not automatically create wisdom.

## Supervised And Unsupervised Learning

Machine learning can be divided into two useful categories for investing.

Supervised learning uses labeled data. The model learns from examples where the outcome is already known.

> Example:
>
> A dataset contains company features from one year ago, plus a label showing whether each stock later rose, fell, or stayed flat. A model can learn from this data and estimate outcomes for new companies.

Unsupervised learning uses unlabeled data. The model looks for structure without being told the correct answer.

> Example:
>
> Stocks can be grouped by return and volatility. The groups may reveal outliers, defensive companies, high-risk winners, or turnaround candidates.

In investment language, model inputs are often called features. Possible features include:

- Revenue growth.
- Earnings.
- Valuation.
- Debt.
- Margins.
- Volatility.
- Momentum.
- Interest rates.
- Inflation.
- Unemployment.
- Sector data.
- Sentiment.
- Weather, where relevant.
- Regulation, where relevant.

The more specific the feature, the narrower the model scope should be. Weather data may matter for agriculture or insurance, but it may add noise when mixed into a broad model covering unrelated industries.

## Forecasts And Analyst Estimates

Many data providers collect analyst forecasts and publish average estimates, high estimates, and low estimates.

[Image placeholder: One-year price forecasts for NVIDIA split into high, low, and mean estimates. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.1.]

Forecasts can be useful, but they are not guarantees. A better forecast process should ask:

- Who made the forecast?
- How accurate has this analyst or firm been in the past?
- What assumptions are behind the estimate?
- Is the forecast based on current information?
- How wide is the gap between high and low estimates?
- Does the forecast fit the investment thesis?

The wider the forecast range, the more uncertainty the investor should assume.

## Unsupervised Learning Example

Unsupervised learning can help screen a large universe of assets. Instead of manually reviewing hundreds of stocks, the investor can group them by behavior.

A simple clustering workflow:

- Choose a universe of assets.
- Calculate annualized return.
- Calculate volatility.
- Plot return against volatility.
- Group similar assets into clusters.
- Inspect outliers and unusual clusters.

An elbow curve helps estimate a useful number of clusters. The investor looks for the point where adding more clusters gives less additional value.

[Image placeholder: Elbow curve indicating a useful number of clusters. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.2.]

The resulting scatterplot can reveal:

- High-return, high-volatility assets.
- Low-return, low-volatility assets.
- Underperformers.
- Turnaround candidates.
- Outliers worth deeper research.

[Image placeholder: Cluster plot of stocks by returns and volatility. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.3.]

Clustering does not tell the investor what to buy. It tells the investor where to look.

## Supervised Learning Example

Supervised learning requires an analytical dataset. Each row represents an asset or time period. Each column represents a feature. One column represents the outcome.

[Image placeholder: Labeled dataset with tickers, labels, and feature candidates such as earnings, price, volatility, sentiment, inflation, interest rates, and stability scores. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.4.]

A supervised learning workflow:

- Define the outcome to predict.
- Choose a time horizon.
- Select features.
- Collect historical data.
- Split data into training and test groups.
- Train the model on the training group.
- Test the model on unseen data.
- Compare predictions with actual outcomes.
- Review errors and improve the process.

Choosing the time horizon matters. Predicting short-term price moves can be extremely noisy. Longer periods can reduce noise, but they may also hide important changes in the company or market.

## Stock Price Prediction

Stock price prediction is tempting because the reward looks obvious. If a model could reliably identify tomorrow's winners, it would be enormously valuable.

In practice, prediction is hard.

[Image placeholder: Actual stock prices compared with model-forecasted prices, showing that predictions are sometimes accurate and sometimes meaningfully wrong. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.5.]

Prediction errors can come from:

- Missing data.
- Poor features.
- Short training periods.
- Market regime changes.
- Overfitting.
- Sudden news.
- Macro events.
- Investor psychology.
- Company-specific surprises.

A useful model should be judged by out-of-sample performance, not by how well it explains the past.

## Market Challenges

Financial markets create several challenges for machine learning.

Efficient market pressure:

- Public information can be priced quickly.
- Obvious opportunities may disappear.
- Hidden advantages are hard to find.

Random walk behavior:

- Prices often move unpredictably.
- Investor emotion can dominate logic.
- Global markets influence one another.

Social and technological change:

- Data that matters today may not have existed decades ago.
- Company behavior changes with technology, regulation, and consumer habits.
- A model trained in one era may fail in another.

Seasonality and cycles:

- Retail, travel, agriculture, and other industries can vary by season.
- Recessions and bull markets affect model behavior.
- A model trained in calm markets may fail during stress.

Accounting and leadership changes:

- Companies can change strategy.
- Executives can change reporting emphasis.
- Historical data may become less comparable.

Market bubbles:

- Prices can rise far beyond sustainable value.
- A model may mistake bubble behavior for strength.
- Unsustainable rallies can corrupt training data.

## Technical Challenges

Volatility makes modeling difficult. An asset can end a period near where it started while moving wildly in between.

[Image placeholder: Price development of Cosmos (ATOM) between 2021 and 2023, showing large movement despite ending near the starting range. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.6.]

Two common modeling problems are:

- Underfitting: the model is too simple and misses important patterns.
- Overfitting: the model is too tailored to past data and fails on new data.

The core challenge is separating signal from noise.

Maintaining models is also work. A serious model process needs:

- Data collection.
- Data cleaning.
- Feature selection.
- Model training.
- Validation.
- Versioning.
- Deployment.
- Monitoring.
- Retraining.
- Documentation.

[Image placeholder: Machine learning operations cycle from data preparation through model validation, packaging, deployment, monitoring, and new data integration. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.7.]

Creating a model is one task. Keeping it trustworthy over time is another.

## Narrowing The Scope

A universal model that predicts all stock prices is unrealistic. Narrow models are more useful.

Good candidate scopes include:

- One industry.
- One business model.
- One region.
- One asset type.
- One risk signal.
- One measurable outcome.

> Example:
>
> A model for subscription businesses might focus on subscriber growth, churn, pricing power, customer acquisition cost, content cost, and user engagement. That is more realistic than asking one model to understand every company in every sector.

Traditional machine learning works best when the desired output is narrow:

- Buy, hold, or sell classification.
- Estimated return.
- Estimated risk.
- Probability of default.
- Expected churn.
- Expected revenue growth.

It is weaker when the task requires broad judgment, creative reasoning, or explanation.

## From Machine Learning To Generative AI

Traditional machine learning is usually built for a specific prediction or classification task. Generative AI is broader. It can summarize, compare, explain, draft, and reason in natural language.

For investing, this difference matters.

Traditional machine learning is useful for:

- Scoring.
- Forecasting.
- Classification.
- Pattern detection.
- Risk estimation.

Generative AI is useful for:

- Research summaries.
- Question generation.
- Company explanation.
- Risk brainstorming.
- Scenario analysis.
- Drafting scorecards.
- Comparing viewpoints.

Both can fail when the scope is too broad or the data is weak.

## Comparing AI Assistants

Different AI assistants may give different answers to the same investment question. Their responses can vary because of training data, model design, retrieval behavior, hidden instructions, and randomness.

### Results Of Prompts Related To Stocks

| Investor style | Assistant A | Assistant B | Finance-focused assistant |
| --- | --- | --- | --- |
| Value-oriented investor | Microsoft, Costco, Visa | Costco, Microsoft, Procter & Gamble | Allegion, Danaher, Coca-Cola |
| Growth-oriented investor | Etsy, Zoom, Square | Trade Desk, Etsy, Shopify | Tesla, Allegion, DCP |

This illustration shows why AI output needs verification:

- Some suggestions may already belong to a referenced investor's portfolio.
- Some company names may be outdated.
- Some repeated picks may reveal shallow reasoning.
- Different assistants may rely on overlapping sources.
- The answer may sound confident without enough current evidence.

For investment advice, a strong human analyst or advisor may still provide deeper context than a generic AI response.

## Combining Machine Learning And Generative AI

Machine learning and generative AI can complement each other.

Generative AI can help:

- Brainstorm useful features for a model.
- Explain why a feature may matter.
- Summarize sector-specific risk.
- Identify missing data sources.
- Generate research questions.
- Draft model documentation.
- Compare model output with narrative evidence.

Machine learning can help:

- Test whether a proposed feature actually predicts anything.
- Score many assets consistently.
- Estimate risk and return.
- Detect outliers.
- Monitor changes over time.

The best workflow uses each tool for what it does well.

## Challenges With Generative AI

Generative AI has two major investment risks.

Dated information:

- The model may not know recent events.
- It may miss breaking news, filings, lawsuits, earnings updates, or management changes.
- It may provide advice based on old conditions.

Hallucinations:

- The model may invent facts.
- It may cite weak or nonexistent evidence.
- It may mix up companies.
- It may produce plausible but wrong explanations.

For investing, plausible is not enough. The output must be checked.

## Practical Use Of Generative AI

Generative AI is most useful when the investor asks focused research questions instead of asking for direct stock picks.

Weak question:

> What are the best stocks to buy?

Better questions:

> What are the main revenue sources of this company?

> What risks did management mention in the latest annual filing?

> What would need to be true for this company to double revenue in five years?

> What are the strongest arguments against my investment thesis?

> Which customer segments does this company depend on most?

## Research Assistants

Generative AI can reduce time spent on research tasks such as:

- Summarizing long documents.
- Extracting risks from filings.
- Comparing management commentary over time.
- Identifying pending lawsuits.
- Explaining business models.
- Identifying customer segments.
- Summarizing earnings calls.
- Drafting company scorecards.
- Reviewing insider transactions.
- Brainstorming nonfinancial risks.

The output should be treated as a starting point. The investor still needs to review primary sources when the decision matters.

## Nonfinancial Risk Assessment

Generative AI can help create a high-level risk assessment when formal data is hard to collect.

### Reference AI-Assisted Risk Assessment

| Company | Pandemic | Reason | Trade war | Reason | Climate change | Reason |
| --- | ---: | --- | ---: | --- | ---: | --- |
| Google | 2 | Digital services can remain resilient | 6 | Global ad spending is exposed to geopolitical pressure | 3 | Low direct climate exposure |
| Pfizer | 4 | Initial benefit from COVID-like events may not repeat | 3 | Limited export vulnerability | 2 | Low direct environmental risk |
| Ali Baba | 5 | Consumer activity can fall during pandemics | 9 | Highly exposed to US-China technology tension | 6 | Logistics and energy exposure |
| Orsted | 1 | Renewable energy demand may remain steady | 2 | Localized green projects limit exposure | 9 | Strong dependence on climate policy |
| CCJ | 1 | Uranium demand may remain steady | 4 | Export-oriented but strategically important | 6 | Nuclear demand may rise from climate pressure |
| Lyft | 8 | Transportation demand can fall in lockdowns | 3 | Mainly domestic exposure | 4 | Regulatory pressure from emissions goals |
| MNMD | 3 | Biotech trials can be delayed | 1 | Low global export relevance | 2 | Limited climate exposure |
| Uber | 6 | Rides may fall while delivery rises | 5 | Global operations create exposure | 4 | Electrification and emissions targets matter |
| TSM | 3 | Demand may dip then rebound | 10 | Central to chip-related geopolitical tension | 5 | Energy and water footprint matter |

These scores are illustrative. They are not objective truth. Their value is that they reveal where the portfolio may be exposed and where deeper analysis is needed.

## Integrating AI Into Research Workflows

Different AI systems may be accessed through chats, internal tools, enterprise systems, local models, or research platforms. The specific access method is less important than the workflow.

A useful AI workflow should:

- Preserve the prompt.
- Preserve the answer.
- Record the date.
- Record sources used.
- Record assumptions.
- Mark confidence level.
- Require verification for important claims.
- Compare multiple viewpoints.
- Keep the user's investing profile in context.
- Make it easy to revisit prior reasoning.

Sensitive investment strategies, personal financial information, and private company research should be handled carefully. If an external system receives the prompt, the investor should assume the content may be processed outside their own environment unless strong contractual and technical controls exist.

## Prompt Engineering

Prompt engineering means giving the AI enough context and direction to produce a useful answer.

Good prompts are:

- Specific.
- Concise.
- Context-rich.
- Explicit about the desired format.
- Clear about uncertainty.
- Clear about what evidence is acceptable.
- Clear about what the AI should avoid.

The investor can improve prompts by including:

- Goals.
- Risk preference.
- Investment horizon.
- Available capital.
- Income needs.
- Experience.
- Asset preferences.
- Tax constraints.
- Ethical constraints.
- Existing holdings.
- Excluded industries.
- Preferred answer format.

## Investor Profile

An investor profile helps AI answer consistently. It works like a standing instruction for research.

Useful profile fields include:

- Background: what the investor understands well.
- Goals: desired outcome and time frame.
- Capital: approximate amount available.
- Income needs: whether passive income matters.
- Experience: assets and sectors already understood.
- Interests: themes the investor wants to research.
- Current holdings: portfolio context.
- Risk preference: comfort with volatility and loss.
- Strategy preference: long-term, income, growth, value, or mixed.
- Geographic preference: domestic, global, or region-specific.
- Tax residency and citizenship: only when needed and handled carefully.
- Ethical exclusions: industries or practices to avoid.

> Example:
>
> I understand digital businesses and financial services. I want financial independence within five years. I prefer long-term quality investments, but I can accept researched risk. I do not day trade. I want diversification across countries and asset types. I avoid tobacco and companies that violate my ethical preferences.

The more personal the context, the more useful the answer can become. But personal and financial details should be shared only in settings that match the investor's privacy needs.

## Finding Companies With Prompts

Generative AI can help search for companies that resemble a successful business pattern.

[Image placeholder: Simplified Netflix business model where profitability depends on subscription revenue exceeding production and licensing costs. Source: `Investing.for.Programmers-2025-8.pdf`, Fig. 8.8.]

Instead of asking for "good stocks," define the business pattern.

> Example:
>
> I want to find listed companies with a similar outlook to Netflix in its early streaming years. I am looking for businesses that can scale globally, sell directly to consumers through subscriptions, and build a strong economic moat. Give three examples and explain why each might fit.

This kind of prompt is better because it defines:

- The reference company.
- The growth pattern.
- The business model.
- The desired moat.
- The output format.

Even then, the result is only an entry point. Each suggested company needs due diligence.

## Better Prompt Checklist

Before trusting an AI-assisted answer, ask:

- Was the question specific enough?
- Did the prompt include investor goals and constraints?
- Did the prompt ask for reasons?
- Did the prompt ask for risks?
- Did the prompt ask what could prove the idea wrong?
- Did the answer cite checkable evidence?
- Are the facts current?
- Are there signs of hallucination?
- Did another source disagree?
- Is the result actionable, or only interesting?

The durable lesson is that AI can widen the investor's field of vision. It can summarize, structure, challenge, and accelerate research. But the investor must still decide what counts as evidence, what needs verification, and what belongs in the portfolio.
