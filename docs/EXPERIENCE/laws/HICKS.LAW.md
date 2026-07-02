# Chapter 4: Hick's Law

_The time it takes to make a decision increases as the number and complexity of available choices increases._

## Overview

Designers often need to take complex information and present it in a way that does not overwhelm people. Redundancy, excess, and unclear structure create confusion. Confusion makes products feel less intuitive and slows users down.

The goal is to understand what users are trying to accomplish, then reduce or remove anything that does not help them achieve that goal. Good design simplifies complexity through clarity, efficiency, and elegance.

An interface with too many options usually signals that the user's needs are not fully understood. Complexity can appear in the interface, but it can also appear in a process. Unclear calls to action, weak information architecture, unnecessary steps, too many choices, and too much information can all prevent people from completing a task.

Hick's law captures this relationship: decision time increases with the number and complexity of available choices. The principle matters because decision-making effort directly affects how people perceive and use an interface.

## Origins

Hick's law was formulated in 1952 by psychologists William Edmund Hick and Ray Hyman. They studied the relationship between the number of stimuli present and a person's reaction time to a given stimulus.

They found that increasing the number of available choices increases decision time logarithmically. In practical terms, people take longer to decide when there are more options to choose from.

The relationship is represented by this formula:

$$
\huge{RT = a + b\log_2(n)}
$$

In the formula, $\large{RT}$ is response time, $\large{n}$ is the number of stimuli, and $\large{a}$ and $\large{b}$ are measurable constants that depend on the task.

![Diagram representing Hick's law.](/.attachments/4-1-laws-diagram.hick's.law.png)

_**Figure 4-1.** Diagram representing Hick's law._

Designers do not need to master the math to apply the principle. The main lesson is straightforward: the more options an interface presents, the more time users need to process those options and decide which one matches their goal.

When an interface is busy, actions become harder to identify and important information becomes harder to find. The mental effort required to move forward increases, which raises cognitive load.

## Psychology Concept: Paradox of Choice

People often assume that more choice is better, but more choice can create indecision and overwhelm. A large restaurant menu, for example, can take more effort to process than a focused menu with a smaller set of options.

This is the paradox of choice: modern consumers have more options than ever, but more options do not automatically make people happier or more confident. The idea was popularized by psychologist Barry Schwartz and builds on earlier work by Herbert A. Simon.

Schwartz was inspired by a study from psychologists Sheena Iyengar and Mark Lepper. In the study, shoppers at an upscale food market saw a display with 24 varieties of gourmet jam. On another day, shoppers saw a similar display with only 6 varieties.

The larger display attracted more attention, but the smaller display led to more purchases. Shoppers who saw the larger display were only one-tenth as likely to buy as those who saw the smaller display. More choice created interest, but fewer choices made action easier.

## Examples

Hick's law appears in both physical and digital interfaces. A common physical example is the TV remote.

As TVs gained more features, remotes gained more buttons. Eventually, many remotes became so complex that they required repeated use, muscle memory, or significant mental effort. Some people responded by taping over every button except the essentials, creating "grandparent-friendly remotes."

![Modified TV remotes that simplify the interface.](/.attachments/4-2-laws-modified.remote.png)

_**Figure 4-2.** Modified TV remotes that simplify the interface._

Figure 4-2 shows remotes simplified by hiding nonessential controls.

Modern smart TV remotes often take the opposite approach from the start. They reduce the hardware controls to a small set of essential actions and move the remaining complexity into the TV interface, where it can be organized and progressively disclosed.

![Smart TV remote with only essential controls.](/.attachments/4-3-laws-smart.remote.png)

_**Figure 4-3.** Smart TV remote with only essential controls._

Figure 4-3 shows a simplified smart TV remote that reduces visible choices.

Digital interfaces face the same problem. A better experience often comes from showing the right choices at the right time instead of showing every possible choice all at once.

Google Search is a clear example. The initial screen focuses on the search task. Filters such as All, Images, Videos, and News appear after the search begins, when they become relevant.

![Google Search showing a simple initial search state and filters after search begins.](/.attachments/4-4-laws-google.simplifies.png)

_**Figure 4-4.** Google Search showing a simple initial search state and filters after search begins._

Figure 4-4 shows how Google reduces initial decision effort and then reveals filtering options when they are useful.

Onboarding is another place where Hick's law matters. A new user can easily feel overwhelmed by a product's full set of possibilities. Notion handles this by giving beginners a clear checklist of steps.

![Notion progressive onboarding checklist.](/.attachments/4-5-laws-notion.progressive.onboarding.png)

_**Figure 4-5.** Notion progressive onboarding checklist._

Figure 4-5 shows how progressive onboarding helps users learn by doing. The experience gives people a manageable next step instead of presenting every possibility at once.

Streaming services also show Hick's law in action. Netflix found that customers could spend an average of 18 minutes deciding what to watch. The volume of choices created indecision.

To reduce that friction, Netflix introduced sections such as "Trending Now" and "Popular on Netflix." These groups give extra weight to certain options through social proof.

![Netflix sections such as Trending Now and Popular on Netflix.](/.attachments/4-6-laws-netflix.png)

_**Figure 4-6.** Netflix sections such as Trending Now and Popular on Netflix._

Figure 4-6 shows how social proof can help users decide by making certain choices feel more relevant.

## Technique: Card Sorting

The number and clarity of choices has a direct effect on decision time. This is especially important in information architecture, where users need to find the right path to the information they want.

Too many items can increase cognitive load, especially when the choices are unclear. Too few choices can also cause problems if users cannot identify which option is likely to lead to the information they need.

Card sorting is a research method for understanding how users expect information to be organized. Participants sort topics into groups that make sense to them.

![Card sorting exercise.](/.attachments/4-7-laws-card.sorting.png)

_**Figure 4-7.** Card sorting exercise._

Figure 4-7 shows a card sorting activity.

Card sorting can be open or closed, moderated or unmoderated. A moderated open card sort usually follows four steps.

### 1. Identify Topics

First, identify the topics participants will organize. These topics should represent the main content in the information architecture, with each item written on an individual card. The exercise can also be done digitally.

Avoid labeling topics with the same words because that can bias participants and lead them to group items together for the wrong reason.

### 2. Organize Topics

Next, ask participants to organize the topics one at a time into groups that make sense to them. It is common to have participants think aloud during this step, which can reveal how they understand the relationships between items.

### 3. Name Categories

After participants create groups, ask them to name each group using the term they think best describes it. This step is especially valuable because it reveals the participant's mental model and can inform future category labels.

### 4. Debrief Participants

The final step is optional but recommended. Ask participants to explain why they grouped items the way they did. This helps uncover decision rationale, confusion, and thoughts about any items that remained unsorted.

## Key Consideration: Oversimplification

Designers should remove unnecessary complexity and become elegant simplifiers. Good experiences often feel easy because obstacles have been removed.

But simplicity can go too far. When an interface is simplified to the point of abstraction, users may no longer know which actions are available, what the next step is, or where specific information can be found.

In that case, the interface may look less complex, but it actually requires more mental effort because it removes the cues people need to move forward.

Icon-only interfaces are a common example.

![Facebook iOS app bar showing icon-based navigation.](/.attachments/4-8-laws-facebook.app.bar.png)

_**Figure 4-8.** Facebook iOS app bar showing icon-based navigation._

Figure 4-8 shows an app bar that relies on icons to represent actions or destinations.

Icons have real advantages. They add visual interest, save space, create strong tap or click targets, and can be recognized quickly when their meaning is universal.

The problem is that truly universal icons are rare. Different people may interpret the same icon differently. The same icon can also mean different things across products. A heart or star might mean like, favorite, bookmark, rate, or featured, depending on the product.

Without enough context, icons can increase cognitive load because users must interpret what each symbol means and what will happen if they select it.

Text labels reduce that abstraction. Studies show that adding labels to icons improves discovery and recognition, especially for important elements such as navigation.

![X web app navigation with text labels accompanying icons.](/.attachments/4-9-laws-text.labels.png)

_**Figure 4-9.** X web app navigation with text labels accompanying icons._

Figure 4-9 shows navigation where text labels clarify icon meaning. The labels add context, reduce ambiguity, and help users understand available options faster.

## References

1. "Why Do We Have a Harder Time Choosing When We Have More Options?," The Decision Lab, August 16, 2018, https://oreil.ly/mmpYT.
2. Barry Schwartz, *The Paradox of Choice: Why More Is Less* (New York: HarperCollins, 2004).
3. Sheena S. Iyengar and Mark R. Lepper, "When Choice Is Demotivating: Can One Desire Too Much of a Good Thing?," *Journal of Personality and Social Psychology* 79, no. 6 (2000): 995-1006.
4. In a closed exercise, the groups are predefined by the researcher.
5. Jakob Nielsen, "Card Sorting: Pushing Users Beyond Terminology Matches," Nielsen Norman Group, August 23, 2009, https://oreil.ly/bxhNN.
