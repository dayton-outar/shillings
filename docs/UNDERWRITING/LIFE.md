# Chapter 3: The Life Table

## Basic Definitions

Actuaries working in life insurance need a clear way to understand how long people are likely to live. The main tool for this is called a **life table** (sometimes also called a mortality table).

Imagine starting with a large group of newborn babies — usually 100,000 for easy round numbers. The life table shows how many of these people are expected to still be alive at each future age, and how many are expected to die each year.

- **$\ell_0$** = starting number (e.g., 100,000 newborns)
- **$\ell_x$** = number still alive at exact age x
- **$d_x$** = number who die between age x and x+1

The basic relationship is simple:  
**${ \ell_{x+1} = \ell_x - d_x }$**

The table continues until a very old age called **$\omega$**, where everyone has died ($\ell_\omega = 0$). This limiting age is often around 110 or higher.

Here is an example of what part of a life table looks like:

**[Placeholder for life table illustration]**

## Probabilities

Even though the life table gives exact numbers for large groups, any single person’s survival is still uncertain. We use these numbers to calculate probabilities.

- **${}_np_x$** = probability that a person now age x will still be alive in n more years
- **${}_nq_x$** = probability that a person now age x will die within the next n years

A very common shorthand drops the “1” when n=1:  
**$p_x$** means the chance of surviving one more year.  
**$q_x$** means the chance of dying within the next year (this is called the **mortality rate** at age x).

There are three useful ways to express the probability that (x) dies between ages x+n and x+n+k:

- **${ (\ell_{x+n} - \ell_{x+n+k}) / \ell_x }$**  
- **${}_np_x - {}_{n+k}p_x$**  
- **${}_np_x \times {}_kq_{x+n}$**

All three give the same answer.  

A helpful rule (the multiplication rule) is:  
**${}_{n+k}p_x = {}_np_x \times {}_kp_{x+n}$**  
This just says: to survive n+k years, you must first survive n years, and then survive another k years from there.

## Constructing the Life Table from the Values of qₓ

In real life, actuaries first estimate $q_x$ (the probability of dying in the next year) for each age using large amounts of data. Once they have these $q_x$ values, they build the life table using two simple formulas:

- **${ d_x = \ell_x \times q_x }$**  
- **${ \ell_{x+1} = \ell_x - d_x }$**

They usually start with $\ell_0 = 100{,}000$ and work forward year by year.  
In practice, many calculations only need the $q_x$ values, but the full table with $\ell_x$ and $d_x$ is easier to understand intuitively.

## Life Expectancy

A common question is: “How long can a person of a certain age expect to live?”

Life expectancy is an **average**. Some people live much longer, some die sooner.  

One way to calculate it is to add up all the future years that the group is expected to live and divide by the number of people.  

The **curtate life expectancy** ($e_x$) counts only complete future years:  
**${ e_x = (\ell_{x+1} + \ell_{x+2} + \ell_{x+3} + \cdots) / \ell_x }$**

Because this slightly undercounts the fraction of the year people live in the year they die, the more realistic **complete life expectancy** ($e^\circ_x$) is roughly:  
**${ e^\circ_x \approx e_x + \frac{1}{2} }$**

There is a handy recursive formula:  
**${ e_x = p_x \times (1 + e_{x+1}) }$**  
Starting from the oldest age where $e_\omega = 0$, you can work backwards to find life expectancy at every younger age.

**Important notes about life expectancy:**
- It changes with age. A 50-year-old’s remaining life expectancy is very different from a newborn’s.
- It is the *average additional years* you live, not the age you reach. So if life expectancy at age 50 is 31.2 years, that means the average 50-year-old lives to about 81.2.

You can also calculate **temporary life expectancy** for only the next n years if needed.

## Choice of Life Tables

Age is the biggest factor affecting how long someone will live, but other things matter too. Actuaries create different life tables for different groups:

- **Male vs Female** (women generally live longer)
- **Smokers vs Non-smokers**
- **Insurance applicants** (healthier than the general population)
- **Annuity buyers** (even healthier on average, since sick people rarely buy them)
- **Individual vs Group policies**

Sometimes they adjust a standard table using simple multiples (e.g., 150% of standard mortality for higher-risk groups).

Choosing the right table for the situation is an important part of an actuary’s job.

## Standard Notation and Terminology

Here are the key symbols you’ll see:

- **${}_np_x$** — probability of surviving n years
- **${}_nq_x$** — probability of dying within n years
- **${}_n|_kq_x$** — probability of surviving n years and then dying in the following k years
- **$e_x$** — curtate life expectancy
- **$e^\circ_x$** — complete life expectancy
- **$e_{x:n}$** — temporary life expectancy for next n years

This system of symbols helps actuaries communicate clearly and precisely.