# AI Agents

AI agents turn one-off AI conversations into structured research workflows. Instead of asking one question and accepting one answer, an investor can design a process that gathers context, asks reusable questions, compares responses, reviews evidence, and stores results for later audit.

The durable idea is not the tool. The durable idea is repeatable research.

## Requirements

A simple AI chat can answer a single prompt. Serious investment research often needs more:

- Memory: the workflow should remember prior context, holdings, prompts, answers, and assumptions.
- Language access: the workflow should retrieve information that was not available during model training.
- Strategy: the workflow should decide which questions to ask, in what order, and how answers should be checked.
- Review: the workflow should separate generated answers from verified evidence.
- Storage: the workflow should preserve results so future decisions can be audited.

If a human expert were allowed to answer only one question, the result would depend heavily on that question. A research workflow should behave more like an interview, where each answer can lead to a better follow-up.

## Successful Communication

Good AI research depends on the same communication principles as good human research.

Memory matters because a model does not automatically learn from every conversation in the way a human does. The workflow needs a way to provide relevant prior context.

Language access matters because a model cannot use information it does not have. Recent filings, earnings calls, private notes, and current prices may need to be retrieved and added to the prompt context.

Strategy matters because unstructured creativity can produce scattered answers. The workflow should define the goal, choose the right sources, ask focused questions, and review the result.

> Example:
>
> A single prompt asks, "Should I buy this company?"
>
> A structured workflow asks:
>
> - What is the investment thesis?
> - What changed recently?
> - What risks are rising?
> - What do financial statements show?
> - What do management comments imply?
> - What would prove the thesis wrong?
> - Which claims need verification?

## Agentic Design Patterns

Agentic workflows can be designed with four useful patterns.

## Reflection

Reflection means the workflow evaluates its own results and improves the next cycle.

For investment research, reflection can ask:

- Did the recommendation match later outcomes?
- Which sources were useful?
- Which assumptions were wrong?
- Did the workflow miss a major risk?
- Did the model overstate certainty?
- Should the prompt be refined?

Reflection turns research into a learning system.

## Tool Use

Tool use means the workflow can call external sources or services when needed.

Examples include:

- Market prices.
- Financial statements.
- Company filings.
- Earnings-call transcripts.
- News sources.
- Portfolio holdings.
- Economic indicators.
- Saved investment notes.

The point is not to let the model guess. The point is to give it the right evidence at the right time.

## Planning

Planning means the workflow breaks a complex goal into steps.

> Example:
>
> Goal: reassess a holding after an earnings report.
>
> Steps:
>
> - Retrieve the latest earnings materials.
> - Compare revenue, margins, cash flow, and guidance with prior expectations.
> - Summarize management's tone and commitments.
> - Identify new risks.
> - Compare the result with the original thesis.
> - Produce a hold, add, reduce, or sell review for human inspection.

Planning helps the workflow stay organized instead of reacting randomly.

## Multi-Agent Collaboration

Multi-agent collaboration means assigning different roles to different AI passes or agents.

Useful investment roles include:

- Optimist: argues the strongest case for buying or holding.
- Skeptic: argues the strongest case against the investment.
- Risk reviewer: focuses on downside scenarios.
- Evidence checker: asks which claims need sources.
- Judge: compares the arguments and produces a balanced summary.

This pattern works because investment decisions benefit from disagreement. A workflow that only confirms the user's thesis is dangerous.

## Reference Workflow

A structured AI research workflow often begins with a trigger.

Common triggers include:

- Scheduled review: run every week, month, or quarter.
- User question: investigate a specific asset or risk.
- Alert: market movement, earnings release, credit-rating change, news event, or thesis trigger.

[Image placeholder: Reference workflow for an AI agent, including trigger, orchestrator, retrieval, generation, review, connected sources, and output. Source: `Investing.for.Programmers-2025-9.pdf`, Fig. 9.1.]

A useful workflow has several stages:

- Input: receive the question, alert, or scheduled task.
- Orchestration: decide which research path to run.
- Retrieval: collect relevant current and stored information.
- Generation: ask the model to produce analysis using the retrieved context.
- Review: challenge, fact-check, and compare answers.
- Output: store or deliver the final result.

Retrieval can come from:

- Saved research notes.
- Portfolio records.
- Current web sources.
- Data providers.
- Earnings transcripts.
- Filings.
- Messages or user notes.
- Standardized connectors to external systems.

Generation can use one model or several. Multiple models or multiple prompts can reveal disagreements, but they also increase cost and complexity.

## Agentic Workflows Without Specialized Frameworks

A simple workflow can be built without adopting a full agent platform. The important building blocks are:

- A prompt repository.
- A way to submit prompts.
- A way to retrieve supporting context.
- A way to store answers.
- A way to review and tag results.

For many research tasks, this is enough.

## Prompt Repository

A prompt repository stores reusable research prompts so the same question can be applied consistently across companies, sectors, and events.

Each prompt should have:

- ID: a stable identifier.
- Prompt text: the actual question or instruction.
- Tags: contexts where the prompt is useful.
- Placeholders: variables such as company, ticker, sector, or event.
- Version: a way to know when the prompt changed.
- Purpose: what decision or research need the prompt supports.

> Example:
>
> Prompt ID: `bcg_position`
>
> Prompt:
>
> As an investor, I am researching `{company}`. Analyze the company using the Boston Consulting Group Growth-Share Matrix. Explain which quadrant best fits the company, what evidence supports that view, and what uncertainty remains.

Prompts should improve over time. If a prompt produces vague answers, refine it. If it works only for one sector, tag it accordingly.

Useful prompt tags include:

- Earnings call.
- Risk review.
- Growth thesis.
- Income thesis.
- Management assessment.
- Competitive analysis.
- Valuation.
- Sector research.
- Catalyst review.
- Exit decision.

## Exporting Results

Research results should not remain scattered across chats, scratch files, browser tabs, or memory. They should be stored in one reviewable research journal.

[Image placeholder: Research journal with reference entries for investment prompts and company research. Source: `Investing.for.Programmers-2025-9.pdf`, Fig. 9.2.]

A saved research entry should include:

- Title.
- Company or asset.
- Date.
- Prompt ID.
- Prompt version.
- Model or assistant used.
- Input context.
- Answer.
- Sources.
- Confidence level.
- Verification status.
- Tags.
- Follow-up questions.
- Human decision.

This structure lets the investor compare answers over time.

[Image placeholder: Example investment research entry storing prompts and generated responses in a structured research journal. Source: `Investing.for.Programmers-2025-9.pdf`, Fig. 9.3.]

A good research journal supports:

- Filtering by company.
- Filtering by tag.
- Searching past answers.
- Comparing models or prompts.
- Tracking unresolved questions.
- Auditing why a decision was made.

The habit matters more than the storage tool.

## Frameworks For AI Agents

Agent frameworks and workflow tools can simplify the process, but they are optional. The platform-agnostic question is:

> What should the research workflow do reliably?

A useful agent framework usually helps with:

- Connecting to models.
- Connecting to external data.
- Managing prompts.
- Passing context between steps.
- Running workflows.
- Storing intermediate results.
- Handling retries and failures.
- Showing the execution path.

No-code tools may make prototypes faster. Code-first tools may provide more control. The right choice depends on complexity, team skill, governance, and production needs.

## From One-Shot Prompting To Agents

One-shot prompting sends one prompt and receives one answer.

An agentic workflow can:

- Read the user's investing profile.
- Retrieve relevant holdings.
- Pull recent information.
- Choose a prompt from the repository.
- Ask one or more models.
- Compare the answers.
- Ask a reviewer model to critique the result.
- Save the final output.
- Trigger follow-up tasks.

The difference is discipline. A workflow reduces the chance that research becomes a random collection of disconnected answers.

## Source-Connected Research

A source-connected assistant can use external information during analysis instead of relying only on model memory.

This is useful for:

- Recent news.
- Earnings calls.
- Company filings.
- Portfolio positions.
- Private notes.
- Market prices.
- Analyst reports.
- Sector-specific data.

But source-connected research still needs caution:

- Sources may be stale.
- Sources may be biased.
- The assistant may misread the source.
- The workflow may retrieve irrelevant context.
- The answer may sound stronger than the evidence supports.

Every generated answer should distinguish between retrieved evidence and model inference.

## Retrieval-Augmented Research

Retrieval-augmented research means collecting relevant documents or data, selecting the parts most related to the question, and adding them to the model's context before generation.

This helps when the model needs information that is:

- Recent.
- Private.
- Niche.
- Long-form.
- Domain-specific.
- Too detailed to memorize.

A retrieval workflow usually has four stages:

- Load data: collect documents, notes, filings, transcripts, or reports.
- Prepare data: split long content into smaller searchable pieces.
- Retrieve data: find the pieces most relevant to the question.
- Generate answer: ask the model to answer using the retrieved context.

[Image placeholder: Execution graph for retrieval-augmented research, retrieving relevant context before generating the answer. Source: `Investing.for.Programmers-2025-9.pdf`, Fig. 9.4.]

> Example:
>
> An investor wants to compare autonomous-driving companies. The workflow loads recent earnings-call transcripts, retrieves passages about partnerships, production, and sensor strategy, then asks the model to compare candidates against the investor's thesis.

Changing the supplied context can change the answer. If the investor states a preference for LiDAR-based systems, one candidate may look attractive. If the investor prefers approaches that avoid LiDAR, another candidate may look better.

That is not a flaw by itself. It shows why assumptions must be visible.

## Research Governance

AI research workflows should be governed like any other decision-support process.

Important controls include:

- Preserve prompts and answers.
- Preserve source references.
- Label unverified claims.
- Separate facts from interpretation.
- Track prompt versions.
- Track model or assistant versions.
- Record who reviewed the output.
- Store the final human decision.
- Revisit old decisions after outcomes are known.

An investment platform should not present generated output as final truth. It should show the path from question to evidence to judgment.

## Failure Modes

AI workflows can fail in predictable ways:

- The prompt is too vague.
- The workflow retrieves irrelevant information.
- The model hallucinates.
- The answer overstates confidence.
- The answer ignores the investor's constraints.
- The workflow uses stale data.
- The source is biased.
- The review step is skipped.
- The result is not saved.
- The investor treats the output as advice instead of research.

Design the workflow so these failures are visible.

## Practical Research Workflow

A repeatable workflow for investment research can look like this:

- Start with a thesis or question.
- Select the relevant prompt.
- Add investor profile and portfolio context.
- Retrieve current and saved evidence.
- Generate an initial answer.
- Generate a skeptical review.
- Identify claims that need verification.
- Save the prompt, answer, sources, and review.
- Make a human decision.
- Schedule follow-up review.

This workflow can support many events:

- Earnings calls.
- New filings.
- Major price moves.
- New product launches.
- Leadership changes.
- Regulatory news.
- Sector shocks.
- Thesis updates.

The durable lesson is that AI agents are most valuable when they make research more consistent, not when they make decisions feel effortless. A good agent helps the investor ask better questions, retrieve better evidence, preserve reasoning, and notice uncertainty before money is at risk.
