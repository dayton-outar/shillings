# Chapter 1: Risk and Insurance

## Risk and Insurance

This book explores mathematical models used in actuarial science. This opening chapter gives you the big-picture background in plain English.

Actuaries primarily focus on two big areas: **risk** and **finance**.

**Risk** is the chance that something bad happens — especially events that cause financial loss. Examples include:
- A person dying and leaving their family without income
- Someone getting seriously ill and facing huge medical bills
- A house burning down or a car getting wrecked in an accident

No matter how careful you are, you can’t completely eliminate these risks. But you *can* protect yourself from the financial damage by buying **insurance**.

Insurance works by pooling risks together. Instead of one person bearing the full cost of a disaster, many people share the burden. Historically, neighbors helped each other out during tough times. Over time, this became more organized through insurance companies.

Here’s how modern insurance works:

- You (the **insured**) pay regular amounts called **premiums** to the insurance company (the **insurer**).
- In return, the insurer promises to pay **benefits** if a specific bad event happens.
- The contract is called an **insurance policy**.

By insuring thousands of people, the company can predict losses more accurately. For example:

Imagine an event that rarely happens but costs $100,000 when it does. If the insurer estimates that 1 out of 100 people will experience it, they might sell policies to 1,000 people. They’d expect about 10 claims. Each person pays a $1,000 premium. The company collects $1,000,000 — enough to cover the 10 people who have losses.

This way, individuals transfer their big risk to the insurance company, and the company spreads that risk across many people.

**Insurance is the opposite of gambling.** Gambling turns certainty into uncertainty (you risk losing money you already have). Insurance turns uncertainty into certainty — you pay a small, predictable premium to avoid a large, unpredictable loss.

## Deterministic versus Stochastic Models

The simple example above is a **deterministic model** — it assumes the insurer knows exactly how much it will pay out and sets premiums accordingly. In reality, things are never perfectly predictable.

Insurers rely on the **law of large numbers**: when you insure enough people, the actual results usually get close to what you expected.

Think of flipping 100 fair coins. You can’t predict exactly how many heads you’ll get, but you expect it to be close to 50 most of the time. Sometimes you might get 37 or 63 — that’s normal variation.

The same applies to insurance claims. Sometimes you’ll have more losses than expected. A **stochastic model** uses probabilities to measure how likely these variations are and helps adjust premiums to account for that risk.

We’ll start with deterministic models because they teach the core ideas clearly. Then we’ll move to the more realistic (but more complex) stochastic approach.

Some risks are **systematic** or non-diversifiable — they can hit many people at once (like a widespread epidemic or major natural disaster). In those cases, selling more policies doesn’t reduce the risk. Actuaries must stay alert to these dangers.

## Finance and Investments

Many insurance policies, especially life insurance, last for years. Premiums are collected now, but benefits might be paid far in the future. Insurers invest the money they collect, and the investment earnings help pay future claims.

Using the earlier example: If benefits are paid a year later and the insurer can earn 5% interest, they don’t need to collect the full $1,000 premium upfront. They could collect less (about $952), invest it, and still have enough when claims come due.

We’ll explore the mathematics of money over time in the next chapter.

## Adequacy and Equity

An actuary’s main job is to make sure premiums plus investment earnings are **adequate** — enough to pay all the promised benefits. If not, the company could go broke and some policyholders wouldn’t get paid.

Actuaries also aim for **equity** (fairness). Premiums should feel fair to customers. Fairness doesn’t mean everyone gets back exactly what they paid in — that would defeat the purpose of risk sharing. Instead, it means people in similar risk situations pay similar amounts, and the expected value of the deal is roughly the same for similar customers.

## Reassessment

Actuaries don’t set premiums once and forget about them. They constantly monitor and update their assessments because the world keeps changing.

This ongoing work is like steering a ship through a storm — you’ll get pushed off course sometimes, but good sailors notice and correct quickly. A big part of this involves calculating **reserves** — money the insurer must set aside to cover future obligations.

**Modern, intuitive summary**: Insurance is about sharing risk so no single person gets destroyed by bad luck. Actuaries are the math experts who figure out how much to charge, how to invest the money, and how to stay safe even when life throws curveballs.