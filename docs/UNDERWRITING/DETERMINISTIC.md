# Chapter 2: The Basic Deterministic Model

## Cash Flows

Actuarial mathematics is all about modeling the movement of money over time. Banks, insurance companies, and other financial institutions regularly receive money at certain times and pay it out at others.

To build a clear model, we fix a time unit — usually years. Time **0** is *now*, and time *t* means *t* years in the future. We assume all payments happen at whole-number times: 0, 1, 2, 3, etc.

The amount received or paid at time *k* is called the **net cash flow** at that time and is written **cₖ**.  
- Positive **cₖ** = money coming **in**  
- Negative **cₖ** = money going **out**  

The complete transaction is described by a **cash flow vector**:

> **c = (c₀, c₁, c₂, …, cₙ)**  
> where *N* is the time of the final payment.

**Example:**

> I lend you 10 units now and another 5 units in one year. You repay with three payments of 7 units each, starting at the end of year 3.  
> From my point of view: **c = (−10, −5, 0, 7, 7, 7)**  
> From your point of view: the opposite vector **(−c)**.

---

## Why We Need More Than Simple Addition

Our main goal is to answer practical questions about transactions:
- Is this deal worth doing?
- How much should I pay now to receive a certain stream of future payments?
- How much should I charge to provide a certain stream of future payments?
- Which of two possible deals is better?

If timing didn’t matter, we could just add up all the numbers. But **timing matters a lot**. We generally prefer money **now** rather than later, and there’s risk that future payments might not arrive.

This idea is called the **time value of money**. We need a systematic way to translate money from one time to another.

---

## An Analogy with Currencies

Suppose I give you:
- 300 Canadian dollars
- 200 US dollars
- 100 Australian dollars

You wouldn’t say I gave you “600 dollars” because each currency has a different value. We need **exchange rates** to make sense of the total.

**Example exchange rates** (for illustration):
- 1 US dollar is worth 1.05 Canadian dollars → *v(Canada, US) = 1.05*
- 1 Australian dollar is worth 0.95 Canadian dollars → *v(Canada, Australia) = 0.95*

All other rates can be calculated from these using simple multiplication and division.

Once we pick one currency as the base (e.g., Canadian), we can convert everything to that base to find the total value.

---

## Discount Functions

We apply the exact same idea to **time** instead of currencies.

Let **v(s, t)** = the value **at time s** of **1 unit** paid at time **t**.

- If *s* is before *t*: *v(s, t)* tells you **how much to invest at time s** to have exactly 1 unit at time *t*.
- If *s* is after *t*: *v(s, t)* tells you **how much 1 unit invested at t** will grow to by time *s*.

**The most important rule** (the consistency condition):

> $\large{v(s,t) \times v(t,u) = v(s,u)}$

This must hold true for any times *s*, *t*, and *u*.

**Definition:** A **discount function** is any positive function *v* that satisfies this multiplication rule for all nonnegative times.

Important simple results:
- $\large{v(s,s) = 1}$ (1 unit today is worth 1 unit today)
- $\large{v(s,t) = \frac{1}{v(t,s)}}$ (going forward and backward are inverses)

---

## Calculating the Discount Function

In practice, it’s easiest to work relative to **time 0**. We define a simpler function:

> $\large{v(t) = v(0,t)}$

This tells us the value today of 1 unit paid at time *t*.

Then the general value between any two times is:

> $\large{v(s,t) = \frac{v(t)}{v(s)}}$

For the first few chapters, we only need the values **v(0), v(1), v(2), …, v(N)**.

These are built step-by-step by multiplying the one-year factors:

> $\large{v(n) = v(0,1) \times v(1,2) \times v(2,3) \times \cdots \times v(n-1,n)}$

We always start with **v(0) = 1**.

---

## Interest and Discount Rates

Instead of giving the one-year discount factors directly, people usually talk in terms of **interest rates** or **discount rates**.

**Interest rate** *iₖ* for the period from time *k* to *k+1*:

> $\large{i_k = \frac{1}{v(k,k+1)} - 1}$

This is the growth rate: 1 unit at time *k* becomes **(1 + iₖ)** at time *k+1*.

**Discount rate** *dₖ* for the same period:

> $\large{d_k = 1 - v(k,k+1)}$

This tells you how much less a future payment is worth right now.

**Simple relationships between them:**

> $\large{d_k = \frac{i_k}{1 + i_k}} \qquad$ and $\qquad \large{i_k = \frac{d_k}{1 - d_k}}$

These rates are usually positive, though negative interest rates are possible in some situations.

---

**# Constant Interest**

If you’ve studied compound interest before, you’re already familiar with one common family of discount functions.

Suppose the growth of money depends **only on how long** it is invested — not on the exact starting time. In math terms, this means:

> For any times *s*, *t*, and length *h*:  
> **Value from s to s+h** = **Value from t to t+h**

When this is true, the discount function simplifies beautifully. It turns out that:

> $\large{v(t) = v^t}$

for some constant number *v* (where *v* is between 0 and 1).

This is the classic **compound interest** setup. The constant interest rate *i* is related by:

> $\large{v = \frac{1}{1+i}} \quad \Rightarrow \quad i = \frac{1}{v} - 1$

**Example:** Investing 1 unit at time 0 grows to $\large{(1+i)^n}$ at time *n*.

In the old days (before calculators and computers), people almost always used this constant interest assumption because it made calculations easier. Many textbooks still focus heavily on it.

However, with modern tools like spreadsheets, there’s no real downside to using more general (flexible) discount functions. In this book, we’ll mostly use general discount functions, but we’ll sometimes switch to constant interest to keep things simple.

One big advantage of the general approach shows up later when we include life contingencies (like death) into the discount function.

---

**# Values and Actuarial Equivalence**

Now we combine the two big ideas: **cash flow vectors** and **discount functions**.

Given a cash flow vector **c** = (c₀, c₁, …, cₙ) and a discount function *v*, we want to find the **single equivalent payment at time 0**.

This is called the **present value** (sometimes abbreviated P.V.):

> $\large{\text{Present Value} = \sum_{k=0}^{N} c_k \times v(k)}$

**Interpretation:**
- For positive *cₖ* (money you receive later): *cₖ × v(k)* is what you should pay **now** to get it.
- For negative *cₖ* (money you pay later): it shows what you need now to cover that future outflow.

**Example 2.1**

> Let *v(k) = (1/2)^k* (money doubles every period — unrealistic for real life but great for learning).  
> You receive 12 at time 2 and pay 8 at time 3.  
> Present value = 12 × (1/4) − 8 × (1/8) = **2**.  
> 
> *Check:* The 12 grows to 24 by time 3. After paying 8, you have 16 left.  
> Two units now would also grow exactly to 16 by time 3. Perfect match!

---

We can also calculate the **value of the cash flows at any time n**:

> $\large{Val_n(\mathbf{c}) = \sum_{k=0}^{N} c_k \times v(n, k)}$

This is the single amount at time *n* that is equivalent to the entire cash flow stream.

**Key relationship** (very important):

> $\large{Val_m(\mathbf{c}) = Val_n(\mathbf{c}) \times v(m, n)}$

Values at different times are linked by the discount function — just like converting between currencies.

---

**Special notation for present value at time 0:**

> $\large{\ddot{a}(\mathbf{c}) = Val_0(\mathbf{c})}$

(The double dot is traditional actuarial notation for annuities — sequences of regular payments.)

In vector form, this is simply the dot product:

> $\large{\ddot{a}(\mathbf{c}) = \mathbf{v} \cdot \mathbf{c}}$

**Two cash flow vectors c and e are actuarially equivalent** if they have the same value at any time (which automatically means at all times).

This is the core idea: two different payment schedules are “fair” to each other if their values match under the discount function.

---

**# Vector Notation**

To make our work easier, we’ll use some helpful shorthand for cash flow vectors.

All vectors in our examples go from time 0 up to some maximum time *N*. If we write a shorter vector, it means the rest of the entries are zero.

**Handy shortcuts:**

- **(c, d)** means glue vector **c** followed immediately by vector **d**.
- **(r^k)** means the number *r* repeated *k* times.  
  Example: (5³) = (5, 5, 5)
- **eᵢ** = the basic vector with 1 at position *i* and 0 everywhere else.

**Two especially useful operations:**

1. **Forward difference** Δ**b**  
   For a vector **b** = (b₀, b₁, b₂, …, bₙ),  
   > **Δb = (b₀, b₁−b₀, b₂−b₁, b₃−b₂, …, −bₙ)**

   It’s like taking the change from one period to the next (with the first entry staying the same).

2. **Pointwise multiplication** (denoted by ∗)  
   > **a ∗ b = (a₀b₀, a₁b₁, a₂b₂, …)**  
   Just multiply corresponding entries.

---

There’s also a more advanced operation (you can skip this on first reading):

**Discounted difference ∇b**  
> ∇bₖ = bₖ − v(k, k+1) × bₖ₊₁

This combines the idea of differences with discounting.

**Key identity** (very useful later):

> $\large{\ddot{a}(\nabla\mathbf{b} \ast \mathbf{c}) = \ddot{a}(\mathbf{b} \ast \Delta\mathbf{c})}$

It’s a kind of “product rule” for present values — the Δ and ∇ can trade places under certain conditions.

---

**# Regular Pattern Cash Flows**

Before computers, people loved cash flow patterns that were easy to calculate by hand — especially **level payments** (same amount every period) and **increasing payments** (arithmetic progression).

We’ll assume constant interest (so *v(t) = vᵗ*).

### Level Payments
Let **(1ₙ)** = (1, 1, 1, …, 1) — *n* payments of 1.

The present value is a geometric series:

> $\large{\ddot{a}(1_n) = 1 + v + v^2 + \cdots + v^{n-1} = \frac{1 - v^n}{1 - v}}$

This is the classic **annuity** formula.

### Increasing Payments
Let **jₙ** = (1, 2, 3, …, n) — payments that increase by 1 each time.

The present value is:

> $\large{\ddot{a}(j_n) = \frac{\ddot{a}(1_n) - n \cdot v^n}{1 - v}}$

---

**Why these formulas matter:**

There’s a nice intuitive way to understand them without summing series.

Imagine lending 1 unit. You could charge interest *i* each period and get the principal back at the end. Using the replacement principle and discount rates, you can show these formulas make perfect sense.

These regular patterns were historically important for hand calculations. Today, with spreadsheets, we can handle any irregular cash flows easily — but the classic formulas are still useful for understanding and quick checks.

---

**# Balances and Reserves**

This section introduces one of the most important ideas in actuarial science: the concept of a **reserve**.

When you enter into any financial transaction (represented by a cash flow vector **c**), at any future time *k* you want to know two key things:

1. **How much money do I have right now** from all the payments received so far?
2. **How much money do I need to set aside** right now to cover all my future obligations?

### Basic Concepts

**Example 2.4**

> Consider this cash flow: **c = (3, 6, 1, 2, −20)** with the following one-year discount factors:  
> v(0,1) = 0.6, v(1,2) = 0.5, v(2,3) = 0.4, v(3,4) = 0.5.  
>
> At time 2 (just before the payment of 1 arrives), how much do we have accumulated, and how much do we need to set aside for future payments?

**Solution:**  
At time 2 we have:  
- The 3 from time 0 has grown for 2 years  
- The 6 from time 1 has grown for 1 year  
→ Total accumulated = **22**

For future obligations: We owe 20 at time 4, which is worth 4 at time 2. But we will also receive 1 (immediately) and 2 at time 3 (worth 0.8 at time 2).  
Net amount we need to set aside = 4 − 1 − 0.8 = **2.2**

---

### Useful Notation

We split any cash flow vector **c** at time *k* into two parts:

- **Past cash flows** (up to time *k−1*): ₖ**c**  
- **Future cash flows** (from time *k* onward): ₖ**c**

So **c = ₖc + ₖc**

**Definitions:**

- **Balance at time k** — **Bₖ(c)**  
  How much you have accumulated from **past** payments, valued at time *k*.  
  > $\large{B_k(\mathbf{c}) = \sum_{j=0}^{k-1} c_j \times v(k, j)}$

- **Reserve at time k** — ₖ**V(c)**  
  How much you need to set aside at time *k* to cover **future** net obligations.  
  > $\large{{}_kV(\mathbf{c}) = -\sum_{j=k}^{N} c_j \times v(k, j)}$

**Note:** The reserve carries a negative sign because it represents *obligations* (money you may have to pay out).

---

### Relationship Between Balance and Reserve

At any time *k*, the overall value of the transaction is:

> $\large{Val_k(\mathbf{c}) = B_k(\mathbf{c}) - {}_kV(\mathbf{c})}$

This makes perfect sense:  
**What you have** minus **what you need to reserve** = **net value of the deal at that moment**.

For **zero-value transactions** (like a fairly priced loan where present value = 0), we have:

> **Balance = Reserve** at every time *k*

---

### Prospective vs Retrospective Methods

- **Prospective method**: Looks to the **future** → uses the **reserve** ₖ**V**
- **Retrospective method**: Looks to the **past** → uses the **balance** **Bₖ**

Both should give the same answer for the outstanding balance on a loan if the same discount function is used.

**Example 2.5** (Loan with changing payments)

> A borrower takes 1000 now + 2000 in one year. Repays with level payments that double after 5 years.  
> At time 8 (just before payment), the outstanding balance is **3483.97** (using either method).  
> After making the payment, it drops to **3121**.

---

### Real-World Applications

- **Early loan repayment**: If interest rates have fallen, the lender may charge a penalty based on the updated (higher) reserve.
- **Bond trading**: The market price of a bond is essentially its outstanding balance calculated with current market interest rates.

---

### Recursion Formulas

Balances and reserves can be updated easily from one period to the next.

**Balance recursion:**

> $\large{B_{k+1}(\mathbf{c}) = \bigl(B_k(\mathbf{c}) + c_k\bigr) \times v(k, k+1)}$

This says: Take what you had, add the payment at time *k*, then grow it forward by one period.

There are similar recursions for reserves and for “after-payment” balances (used in loan amortization schedules).

These recursion formulas are very practical — they let you build a full schedule step-by-step, just like a loan amortization table that shows interest and principal repayment each period.

---

**# Time Shifting and the Splitting Identity**

This section helps explain some classic actuarial formulas you’ll see in older textbooks.

### The Splitting Identity

One very useful way to calculate the present value of a long cash flow stream is to **split** it at some point *k*:

> $\large{\ddot{a}(\mathbf{c}) = \ddot{a}({}_k\mathbf{c}) + v(k) \times Val_k({}^k\mathbf{c})}$

**Interpretation:**  
The total present value equals:  
- The value of everything that happens **before** time *k*, plus  
- The value at time *k* of everything that happens **after** time *k*, discounted back to today.

This is called the **splitting identity**. It’s like breaking a big problem into two smaller, easier pieces.

---

### Time Shifting Notation

To make this cleaner, we introduce the idea of “shifting time” so that time *k* becomes the new “time 0”.

- **c ◦ k** = the cash flow vector **starting at time k**, shifted to begin at 0.  
  Example: If **c = (2, 3, 4, 5)**, then **c ◦ 2 = (4, 5)**.

- **v ◦ k** = the discount function as seen from time *k* onward.

When interest is constant, time shifting is especially simple because **v ◦ k = v**.

Using this, the value at time *k* of the future cash flows can be written as:

> $\large{Val_k({}^k\mathbf{c}) = \ddot{a}(\mathbf{c} \circ k;\; v \circ k)}$

Putting it all together gives the splitting identity in a nice form:

> $\large{\ddot{a}(\mathbf{c}) = \ddot{a}({}_k\mathbf{c}) + v(k) \times \ddot{a}(\mathbf{c} \circ k)}$

This formula is very practical when there is a clear change in payments or interest rates at time *k*.

---

**\* Change of Discount Function** *(Technical section — can be skimmed on first reading)*

This part shows a clever trick for switching from one discount function (*v*) to another (*v′*) while keeping the balances the same.

Suppose we have a cash flow vector **c** under discount function *v*. We create a new cash flow vector **c′** where we adjust each payment by:

> $\large{c'_k = c_k + \bigl[v'(k,k+1) - v(k,k+1)\bigr] \times B_{k+1}(\mathbf{c})}$

**Key result:** The **balances** under the new discount function *v′* are exactly the same as the old balances under *v*.

> $\large{B_k(\mathbf{c}; v) = B_k(\mathbf{c}'; v')}$ for all *k*

This is useful because it lets us change the interest rate assumptions without completely redoing everything. It also proves some important relationships used later in life insurance.

One practical application: It formally justifies the classic way of repaying a loan by paying interest each period on the outstanding balance and returning the principal at the end.

---

**# Internal Rates of Return**

In this section, we look at things from the **investor’s or lender’s point of view**. You put money in (negative cash flows) and hope to get more money back later (positive cash flows). The net cash flow vector is **c = (c₀, c₁, …, cₙ)**, with *cₙ ≠ 0*.

We don’t start with a discount function. Instead, we want to find the constant interest rate *i* that makes the whole transaction a **zero-value** deal — meaning the present value of everything coming in equals everything going out.

We use **after-payment balances** (denoted **̃Bₖ**) for this analysis.

**Definition 2.8** — **Internal Rate of Return (IRR)** (also called **yield rate**)

An interest rate *i* (where *i* > −1) is an internal rate of return if, using *v(k) = (1 + i)^(−k)*:

- The final balance after the last payment is exactly zero: **̃Bₙ = 0**
- All earlier balances are less than or equal to zero: **̃Bₖ ≤ 0** for *k = 0* to *N−1*

**Key Theorem:** If an IRR exists, it is **unique**.

**Why the extra condition?**  
If balances become positive, your role switches from lender to borrower. The simple IRR definition only works cleanly when you stay on one side (usually as the lender).

---

**\* Forward Prices and Term Structure**

This section gives a real-world example of how discount functions arise naturally in financial markets.

### Zero-Coupon Bonds and Forward Contracts

A **zero-coupon bond** pays a fixed amount at a future maturity date and nothing before then. A **risk-free** one (e.g., government bond) is assumed to pay for sure.

A **forward contract** is an agreement today to buy or sell something at a future date for a price agreed upon **today** (the **forward price**). This locks in the price and removes uncertainty.

Let **̃v(0, t)** = today’s price of a 1-unit zero-coupon bond maturing at time *t*.  
Let **̃v(s, t)** = the forward price at time *s* for a bond maturing at time *t*.

Under reasonable assumptions (especially the **no-arbitrage** principle), these prices satisfy:

> $\large{\tilde{v}(s, t) = \frac{\tilde{v}(t)}{\tilde{v}(s)}}$

This relationship means that **̃v** itself is a proper **discount function**.

### No-Arbitrage Hypothesis

If this formula didn’t hold, clever traders could make risk-free profits (arbitrage) by buying low and selling high simultaneously. Markets quickly eliminate such opportunities through supply and demand.

**Example of arbitrage** (if the formula is violated):  
The book shows a concrete case where mispricing allows a guaranteed profit with no risk.

This framework is fundamental in modern finance. The collection of prices **̃v(t)** for different maturities is called the **term structure of interest rates** and is widely used to value all kinds of financial contracts.

---

**# Standard Notation and Terminology**

Actuarial science has a long history and uses a very specific international system of notation. It can look intimidating at first with all the symbols, subscripts, and superscripts.

In this book, we keep things as simple as possible using vector notation. You don’t need to learn the full traditional system to understand this book. However, if you plan to read other actuarial textbooks, take exams, or work in the field, you’ll eventually need to know the standard symbols.

### Traditional Notation for Cash Flows with Interest

The traditional system uses the basic symbol **a** for present values, with decorations added to describe the specific payment pattern.

**Examples:**

- **aₙ** = present value of *n* payments of 1, starting in one year (often called an *immediate annuity*).
- **äₙ** = present value of *n* payments of 1, starting immediately (called an *annuity-due*).  
  (The two dots above the *a* indicate a payment at time 0.)

Other common symbols:
- **Iaₙ** = present value of payments that increase: 1, 2, 3, …, n
- **Daₙ** = present value of payments that decrease: n, n−1, …, 1
- **sₙ** = accumulated value at the end of *n* periods (future value)

The “angle” symbol (ₙ) indicates a time duration. The double dot (ä) signals that payments begin right away.

These symbols were designed for common cases with level or regularly changing payments under constant interest.

---

**# New Notation Used in This Book**

We introduced three main innovations that make things clearer and more flexible:

1. **Vector notation** — lets you describe *any* sequence of cash flows easily (e.g., **c = (−10, −5, 0, 7, 7, 7)**). This also makes it obvious how to enter data into a spreadsheet.

2. **Valₖ(c)** — the value of the cash flows at any specific time *k* (not just at time 0).

3. **Time-shifting notation** (c ◦ k and v ◦ k) — lets us treat any time *k* as the new “time 0.”

These tools are especially powerful when payments are irregular or interest rates change over time.

---

**# Spreadsheet Calculations**

Modern computing makes general discount functions easy to handle. Here’s how to set up these calculations in Microsoft Excel (the ideas work in other spreadsheets too).

### Basic Spreadsheet Setup

- **Column A**: Time *k* (0, 1, 2, …, N)
- **Column B**: One-period interest rates *iₖ*
- **Column C**: Discount factors *v(k)*  
  Start with 1 at time 0. Then use the formula:  
  > `=C10 / (1 + B10)` (and copy down)
- **Column D**: Cash flows *cₖ*

**Present value formula** (in one cell):

> `=SUMPRODUCT(C10:C10+N, D10:D10+N)`

This single formula computes **ä(c)** — the present value at time 0.

You can easily copy this setup for multiple different cash flow vectors or change interest rates to see the effect.

**Values at other times**: Just divide the present value by *v(k)* from column C.

This approach is flexible and powerful. You can quickly solve for unknown payments, compute balances, reserves, and more.