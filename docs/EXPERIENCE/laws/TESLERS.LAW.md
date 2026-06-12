# Chapter 9: Tesler's Law

Every system has a certain amount of complexity that cannot be removed, only moved.

## Overview

Who should carry the burden of complexity in an application or process: the user, or the designers and developers?

This is one of the central questions in interface design. Designers aim to reduce complexity for the people using the products they help build. But every process contains some inherent complexity. Eventually, complexity can no longer be reduced. It can only be transferred.

At that point, the complexity either appears in the user interface or gets absorbed into the workflows, code, and decisions of the people designing and building the system.

Tesler's law, also called the law of conservation of complexity, reminds us that simplification is not the same as making complexity disappear. Good design often means moving complexity away from users and into the system.

## Origins

Tesler's law traces back to the mid-1980s and Larry Tesler, a computer scientist at Xerox PARC. Tesler helped develop the language of interaction design: a set of principles, standards, and practices for defining how interactive systems should be structured and behave.

This work was central to the development of the desktop computer and desktop publishing. Tesler realized that interface consistency would benefit both users and developers. Standards could reduce user confusion, and shared software libraries could make consistent behavior easier for developers to implement.

Later, while working at Apple on the Mac app object-oriented framework, Tesler created an intermediate "generic application." Developers could build their own apps by modifying this generic application in an object-oriented way.

Tesler used the law of conservation of complexity to explain the value of this approach to Apple management and independent software vendors. The goal was to establish standards for mass-market software while reducing complexity for customers.

Tesler argued that if a million users each waste a minute per day dealing with complexity that an engineer could have eliminated in a week, the product is penalizing users to make the engineer's work easier.

## Psychology Concept: Complexity Bias

Cognitive biases are mental shortcuts that help people make fast decisions without fully analyzing every situation. They save mental energy for harder work, such as problem-solving and creative thinking. But they can also produce errors in memory, judgment, and decision-making.

Complexity bias is the tendency to favor complex or intricate solutions over simple ones. People often associate complexity with intelligence, expertise, depth, or seriousness. As a result, a simple explanation may feel less credible even when it is correct.

A 1989 study by Hilary H. Farris and Russell Revlin illustrated this pattern. Participants were given three numbers and asked to discover the rule behind them. They could test whether other number sequences followed the same rule. The actual rule was simple: list three numbers that increase. A sequence like `1, 2, 3` or `3, 7, 99` would work.

Most participants did not guess the simple rule. Instead, they looked for more complicated explanations.

This bias is especially risky in design. When teams reach for complex solutions too quickly, they may avoid truly understanding the underlying problem. The more complexity and assumptions a solution contains, the more ways it can fail.

If a solution feels complex, that may be a signal that the team needs more information, more observation, or a clearer understanding of the problem.

## Examples

Email is a simple way to understand Tesler's law. To send an email, two pieces of information are required: who the message is from and who it should be sent to.

The message cannot be sent if either is missing. That is necessary complexity. Modern email clients reduce the user's burden by pre-populating the sender and suggesting recipients as the user types, based on prior emails or contacts.

> [!figure]
> Figure 9-1 placeholder: modern email client populating the from line and suggesting recipients.

Figure 9-1 shows how the complexity does not vanish. It is shifted into the email client, which handles known information and suggests likely input.

Gmail's Smart Compose takes this further by using artificial intelligence to suggest words and phrases as the user writes.

> [!figure]
> Figure 9-2 placeholder: Gmail Smart Compose suggesting text.

Figure 9-2 shows Smart Compose reducing typing effort by predicting likely sentence completions. Gmail also includes Smart Reply, which scans email context and suggests quick responses.

Checkout flows are another common example. Online purchases often require billing and shipping details. Many stores simplify the process by allowing the shipping address to inherit information from the billing address.

> [!figure]
> Figure 9-3 placeholder: ecommerce checkout inheriting shipping address from billing details.

Figure 9-3 shows a checkout feature that prevents users from entering duplicate information. The customer experience becomes simpler because the design and development team absorbed the complexity of implementing the shortcut.

Payment services such as Apple Pay simplify checkout even further. Once users set up an account, they can select Apple Pay during checkout and verify the purchase without entering additional payment details.

> [!figure]
> Figure 9-4 placeholder: Apple Pay checkout flow.

Figure 9-4 shows how Apple Pay shifts payment complexity away from the customer and into the service.

Retail also offers examples of complexity being abstracted away. Amazon Go stores provide a checkout-free shopping experience. Customers check in with the app, take what they need, and leave. Later, they receive a receipt and their Amazon account is charged.

> [!figure]
> Figure 9-5 placeholder: first Amazon Go store in Seattle.

Figure 9-5 shows the first Amazon Go store in Seattle.

The experience feels simple to shoppers, but the system behind it is extremely complex. Machine learning, computer vision, and artificial intelligence must work together so customers can shop without waiting in line, scanning items, or paying at a register.

Artificial intelligence is also creating an intent-based interaction paradigm. Instead of issuing commands through a graphical interface, users can describe the outcome they want in natural language.

This is different from the command-based model that has dominated graphical interfaces for decades. In an intent-based model, the user says what they want, and the system absorbs more of the complexity required to produce that outcome.

Mixpanel's Spark feature is an example. It lets users conduct data analysis by asking questions in natural language.

> [!figure]
> Figure 9-6 placeholder: Mixpanel Spark natural language analytics feature.

Figure 9-6 shows how natural language input can lower the knowledge barrier for complex software. Users who know the outcome they want but not the steps required can still access powerful features.

## Key Consideration: Paradox of the Active User

When designing software, it is important to remember that users usually do not read manuals first. They start using the product immediately.

This happens because people are motivated by their current task. They do not want to invest time up front reading documentation, even if learning the system first would save time later.

Mary Beth Rosson and John Carroll introduced this paradox in 1987 after observing several user studies at the IBM User Interface Institute. New users were not reading the manuals supplied with computers. Instead, they started using the systems right away, even when that led to errors and roadblocks.

The lesson is to avoid designing for an idealized, perfectly rational user. Real people do not always behave rationally. They follow immediate goals and learn as they go.

Designers can respond by making guidance available throughout the product experience. Help should appear in context, at the moment it is useful, through patterns such as tooltips, inline guidance, examples, and progressive disclosure.

## Technique: Progressive Disclosure

Progressive disclosure is an interaction design technique that shows only the most important actions or content by default, while keeping additional features or content easy to access.

The result is a cleaner interface that reduces clutter, confusion, and cognitive load. Dropdowns, accordions, and toggles are common examples. They hide secondary content by default and reveal it when the user needs it.

Progressive disclosure is useful because it lets designers defer less important actions, advanced features, or supporting content to a secondary state instead of showing everything at once.

Stripe's website provides a good example. Hovering over an item in the primary navigation reveals a menu of related links in that category.

> [!figure]
> Figure 9-7 placeholder: progressive disclosure menu on Stripe.com.

Figure 9-7 shows how Stripe keeps the default interface simple while still making deeper content easy to access.

## References

1. Dan Saffer, *Designing for Interaction: Creating Smart Applications and Clever Devices* (Berkeley, CA: Peachpit Press, 2006), 56.
2. Shane Parrish, "Complexity Bias: Why We Prefer Complicated to Simple," Farnam Street, January 8, 2018, https://oreil.ly/i9di1.
3. Hilary H. Farris and Russell Revlin, "Sensible Reasoning in Two Tasks: Rule Discovery and Hypothesis Evaluation," *Memory & Cognition* 17, no. 2 (1989): 221-32, https://doi.org/10.3758/BF03197071.
4. John M. Carroll and Mary Beth Rosson, "Paradox of the Active User," in *Interfacing Thought: Cognitive Aspects of Human-Computer Interaction*, ed. John M. Carroll (Cambridge, MA: MIT Press, 1987).
