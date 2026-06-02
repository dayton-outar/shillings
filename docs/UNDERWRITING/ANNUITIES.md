# Chapter 4: Life Annuities

## Introduction

Most people worry about the financial impact of dying too soon. But there is another major risk that is less obvious: **living too long**.

Imagine a retired person with $1,000,000 saved, invested at 5% per year. This provides $50,000 of annual income. If they decide this is not enough and start spending some of the original savings each year, they face the danger that the money will run out before they die — leaving them with no income for their remaining years.

**Life annuities** protect against this risk. 

A life annuity is a contract between you (the annuitant) and an insurance company (the insurer). You pay one or more premiums. In return, the insurer promises to pay you regular benefits for the rest of your life. Payments stop when you die.

People who buy life annuities are essentially giving up some capital that they won’t need for dependents after death. In exchange, they get a higher effective return because the money from those who die early helps support those who live longer. This extra income is called **survivorship earnings**.

You can picture it like this: Imagine many people each putting money into their own “box.” Interest is added to every box. When someone dies, the money in their box is shared among the surviving boxes. Everyone gets their regular payments plus these survivorship boosts. In practice, this is all done mathematically — no actual boxes are needed.

Insurers usually group people of similar age together, since they have similar chances of survival. Premiums are mainly calculated based on age (and sometimes other factors like gender).

---

## Calculating Annuity Premiums

We now bring in the mathematics. We use cash flow vectors from Chapter 2, plus a life table for survival probabilities and a discount function *v* for investment earnings.

Consider a person now age **x** (denoted (x)). Benefits are paid only if they are alive at the payment time. The benefit vector **c** = (c₀, c₁, …) tells us how much is paid at each time *k* (if alive).

The **net single premium** (the fair price) for this annuity is denoted **äₓ(c)**.

**Key Idea:** Each possible payment is treated like a **pure endowment** — a benefit paid at time *k* only if (x) is still alive.

For a single payment of 1 at time *k* if alive, the premium is:

> $\large{v(k) \times {}_k p_x}$

Where *v(k)* is the interest discount factor, and *ₖpₓ* is the probability that (x) survives *k* years.

For the full annuity with multiple payments:

> $\large{\ddot{a}_x(\mathbf{c}) = \sum_{k} c_k \times v(k) \times {}_k p_x}$

This is the same formula as in Chapter 2, except each term is multiplied by the survival probability.

**Types of Annuities:**
- **Temporary life annuity**: Payments for a fixed number of years (or until death, whichever comes first).
- **Whole life annuity**: Payments continue for the rest of the person’s life.
- **Deferred annuity**: Payments start after several years (e.g., at retirement).

---

## The Interest and Survivorship Discount Function

Notice that the annuity premium formula looks exactly like a regular present value from Chapter 2, but with *v(k)* replaced by *v(k) × ₖpₓ*.

This leads to a powerful observation. Define a new discount function:

> $\large{y_x(k) = v(k) \times {}_k p_x}$

We can extend this to a full two-variable discount function *yₓ(s, t)* that satisfies all the required properties.

**This is huge:** Life annuities are simply regular annuities calculated under this special **interest and survivorship discount function** *yₓ*.

All the tools we learned in Chapter 2 (present values, balances, reserves, splitting identities, recursion formulas, etc.) work directly when we use *yₓ* instead of *v*.

**Recursion for yₓ:**

> $\large{y_x(k+1) = y_x(k) \times v(k, k+1) \times p_{x+k}}$

This makes spreadsheet calculations straightforward.

**Notation Note:** The symbol **äₓ** (with no vector specified) means the whole life annuity paying 1 per year for life, starting immediately.

This combined discount function beautifully merges the time value of money with the probabilities of survival. It lets us carry over everything we know from deterministic cash flows into the world of life-contingent payments.

---

## Guaranteed Payments

Suppose someone buys a life annuity and dies shortly after paying the premium. Their family might feel the insurer has taken the money unfairly, since almost nothing was paid back.

To make the product more appealing, insurers often offer **guaranteed periods**. For example, the contract might promise that payments will continue for 10 or 15 years no matter what — even if the annuitant dies early. After the guaranteed period ends, payments become life-contingent again (only paid if alive).

This guarantee makes the annuity more expensive, but it provides peace of mind.

**How to calculate the premium:** Treat the contract as two separate pieces and add their values:

1. The **guaranteed portion** — calculated as a regular annuity-certain using the interest discount function *v*.
2. The **life-contingent portion** after the guarantee — calculated using the combined discount function *yₓ*.

**Example 4.3**

> A person age 40 buys a life annuity paying 10,000 per year for life, starting at age 41. The first 10 payments are guaranteed regardless of survival.  
> 
> Premium = 10,000 × [ä(c; v) + ä₄₀(f)]  
> where **c** is the guaranteed vector and **f** is the life-contingent vector after year 10.

**Example 4.4**

> A deferred annuity on (40) starts payments at age 65, with a 10-year guarantee once payments begin.  
> The calculation carefully combines the deferred life portion with the guaranteed portion (which is itself contingent on reaching age 65).

---

## Deferred Annuities with Annual Premiums

Many people buy deferred annuities to provide income starting at retirement. Instead of paying one large premium upfront, they pay a series of annual premiums while still working.

The premiums themselves stop when the person dies or when the benefit payments begin. We describe the premium pattern with a vector **ρ**, where ρ₀ = 1, and ρₖ tells the relative size of the premium at time *k*.

The actual premiums are then **πₖ = π₀ × ρₖ**, where π₀ is the initial premium we need to solve for.

To find the right premium level, we set the present value of all premiums equal to the present value of all benefits, using the combined **yₓ** discount function.

**Example 4.5 / 4.6**

> An annuity on (40) will pay 1 per year for life starting at age 65.  
> Premiums are paid for 25 years, but reduce by half after 15 years.  
> 
> Solve **ä₄₀(benefits)** = π₀ × ä₄₀(premium pattern)  
> for the initial premium π₀.

This structure is very common in pension plans, where both the employee and employer contribute during working years.

---

## Some Practical Considerations

### Gross Premiums

The premiums calculated above are called **net premiums** or **benefit premiums** — the pure mathematical amount needed to cover the benefits.

In real life, insurers charge **gross premiums**, which are higher. They must cover:
- Operating expenses
- Profit margin
- A safety buffer (in case interest rates are lower than expected or people live longer than predicted)

Marketing also matters — premiums must be competitive with other companies.

### Gender Aspects

On average, women live longer than men. In a pure “female age x room,” participants receive payments for more years on average. This means women typically need to pay higher premiums than men for the same benefit level if insurers use separate life tables.

This has created controversy, especially in pension plans. Using separate tables can result in women receiving smaller pensions for the same contributions. Many plans now use **unisex (blended) life tables** to avoid gender discrimination. As a result, men get slightly lower benefits and women get slightly higher benefits than they would under gender-specific tables.

---

## Standard Notation and Terminology

Actuarial science uses a compact traditional notation for life annuities:

- **äₓₙ** : Temporary life annuity-due paying 1 per year for up to *n* years
- **äₓ** : Whole life annuity-due paying 1 per year for life
- **ₖ|äₓ** : Deferred life annuity (starts after *k* years)
- **ₖEₓ** : Pure endowment of 1 payable after *k* years if alive

Other variations exist for increasing payments (Iäₓ), decreasing payments, etc.

These symbols are widely used in professional work and exams. The book’s vector approach is more flexible for general cases, but familiarity with standard notation is important.

---

## Spreadsheet Calculations

Spreadsheets make life annuity work very practical. Here’s a typical setup:

- Column A: Time *k*
- Column B: Interest rates *iₖ*
- Column C: Mortality rates *q_{x+k}*
- Column D: Interest discount factors *v(k)*
- Column E: Combined discount factors *yₓ(k)* using the recursion  
  > *y(k+1) = y(k) × v(k,k+1) × (1 − q_{x+k})*
- Column F: Benefit cash flows *cₖ*

The net single premium is then a simple `SUMPRODUCT` of columns E and F.

For deferred annuities with annual premiums, add another column for the premium pattern and solve for the initial premium by dividing the benefit value by the premium pattern value.

This setup handles varying interest rates, arbitrary payment patterns, and different starting ages with ease.