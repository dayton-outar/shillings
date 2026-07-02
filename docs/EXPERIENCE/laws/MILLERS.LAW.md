# Chapter 3: Miller's Law

_The average person can hold only about ${7 \pm 2}$ items in working memory._

## Overview

Many designers have heard of Miller's law, but it is often misunderstood. It is commonly used to justify claims like "navigation should never have more than seven items." That interpretation is too rigid and misses the real value of the principle.

Miller's law is not a rule for limiting every interface group to seven items. It is a reminder that people have limited working memory, and that designers can reduce cognitive effort by organizing information into meaningful chunks.

Limiting choices can be useful in some contexts, especially when decision speed matters, but that idea is more closely connected to Hick's law. Miller's law is more useful when thinking about how people process, understand, and remember information.

## Origins

Miller's law comes from George Miller's 1956 paper, "The Magical Number Seven, Plus or Minus Two: Some Limits on Our Capacity for Processing Information." Miller, a cognitive psychologist at Harvard, explored the relationship between one-dimensional absolute judgment and short-term memory.

Miller observed that young adults could usually remember about seven items, regardless of whether those items contained very different amounts of information. This led him to focus on chunks rather than raw bits of information. In cognitive psychology, a chunk is a group of familiar units that has been collected and stored as a single meaningful unit in memory.

Miller's paper is often summarized as saying that people can hold ${7 \pm 2}$ objects in short-term memory. But Miller used "the magical number seven" rhetorically, and he was surprised by how often the idea was interpreted as a strict rule. Later research showed that memory span is not fixed, even when measured in chunks.

Miller's deeper contribution was helping establish the idea that the mind can be understood through an information-processing model. His work also helped move psychology beyond behaviorism and toward research on how people process information internally. That shift laid the groundwork for cognitive load theory.

## Psychology Concept: Cognitive Load

When people use a digital product, they first need to understand how it works. They must figure out the navigation, interpret the layout, interact with controls, and sometimes enter information into forms. All of that requires mental effort.

At the same time, users must remember what they came to do. If the interface makes basic understanding difficult, users have less mental capacity left for their actual goal. The amount of mental effort required to understand and interact with an interface is called cognitive load.

One useful analogy is a phone or laptop. Run too many apps at once and performance drops: the battery drains, the device slows down, and sometimes it crashes. Processing power depends on memory, and memory is finite.

Human working memory behaves in a similar way. When too much information arrives at once, people struggle to keep up. Tasks feel harder, details get missed, and the experience can become overwhelming.

Working memory acts like a temporary buffer for information related to the current task.

![Working memory buffer illustration.](/.attachments/3-1-laws-memory.buffer.png)

_**Figure 3-1.** Working memory buffer illustration._

Figure 3-1 illustrates working memory as a limited buffer. If a task requires more space than the buffer can provide, information starts to fall out of working memory so new information can fit.

This becomes a problem when the lost information is important to the task. The user may need to retrace steps, reread content, or start over. That friction can lead to frustration and task abandonment.

## Technique: Chunking

Miller's interest was not really the number seven itself. He was more interested in chunking and how it helps people retain information.

He found that the size of a chunk mattered less than the number of chunks. People could hold seven familiar words in short-term memory about as easily as seven individual letters. The exact number varies by person, context, familiarity, and complexity, but the broader lesson holds: short-term memory is limited, and chunking helps people handle information more effectively.

In UX design, chunking is a practical way to make content easier to understand. Designers can group related content and objects, then use color, scale, dividers, spacing, and hierarchy to make those groups visually distinct.

Chunking helps users scan a page, identify the information that matches their goal, and consume it more quickly. By creating clear visual groups, designers align content structure with the way people evaluate and process information.

## Examples

Phone numbers are one of the simplest examples of chunking. Without formatting, a phone number is just a long string of digits. With chunking, the same number becomes easier to read, process, and remember.

![US phone number with and without chunking applied.](/.attachments/3-2-laws-chunking.png)

_**Figure 3-2.** US phone number with and without chunking applied._

Figure 3-2 shows how grouping digits makes a phone number easier to handle.

A more complex example is the "wall of text": a dense block of content with little hierarchy, little formatting, and overly long line lengths.

![Wall of text example.](/.attachments/3-3-laws-wall.of.text-wiki.png)

_**Figure 3-3.** Wall of text example._

Figure 3-3 shows content that is difficult to scan and process. Because the structure is unclear, users need more effort to understand it.

The same content becomes easier to consume when it has hierarchy, formatting, and appropriate line lengths.

![Wall of text improved with hierarchy, formatting, and appropriate line lengths.](/.attachments/3-4-laws-wall.of.text.png)

_**Figure 3-4.** Wall of text improved with hierarchy, formatting, and appropriate line lengths._

Figure 3-4 shows the improved version. Headings and subheadings create hierarchy, whitespace separates sections, shorter line lengths improve readability, links are underlined, and important words are highlighted.

Chunking also works at the page level. It can group dense information into modules, separate related content with rules or spacing, and create a clear hierarchy.

![Chunking applied to dense information.](/.attachments/3-5-laws-chunking.applied.png)

_**Figure 3-5.** Chunking applied to dense information._

Figure 3-5 shows how chunking helps users scan information-dense content, such as news or financial headlines, and decide what deserves their attention.

Ecommerce sites use chunking constantly. On Nike.com, product information is visually grouped through proximity: image, title, price, product type, and available colors all sit together. Filters in the sidebar are also grouped by relationship.

![Chunking used to group products and filters on an ecommerce website.](/.attachments/3-6-laws-chunking.ecommerce.png)

_**Figure 3-6.** Chunking used to group products and filters on an ecommerce website._

Figure 3-6 shows how proximity can create a clear group even without a shared background or border.

Chunking can also organize related actions or functions. Toolbars in editing applications often group similar controls so users can understand which actions belong together.

![Google Docs toolbar using chunking to group related functions.](/.attachments/3-7-laws-google.docs.grouped.functions.png)

_**Figure 3-7.** Google Docs toolbar using chunking to group related functions._

Figure 3-7 shows how Google Docs separates toolbar functions into recognizable groups.

These examples show that chunking can organize almost any content for easier comprehension. It helps users understand relationships and hierarchy. What it does not do is set a universal limit on how many items can appear in a group.

## Key Consideration: The "Magical" Number Seven

Miller's law is sometimes misused as a rule that interface groups must contain only ${7 \pm 2}$ items. Navigation menus are a common example. Someone may argue that a menu must be limited to seven links because of Miller's law.

That argument misses an important distinction: visible navigation does not need to be memorized. The options are available on the screen. Users only need to remember their goal, then scan the visible options for the relevant path.

As long as the menu is designed clearly, limiting the number of links to seven does not automatically improve usability.

![Nike.com navigation menu with more than seven items.](/.attachments/3-8-laws-nike.png)

_**Figure 3-8.** Nike.com navigation menu with more than seven items._

Figure 3-8 shows Nike.com's primary navigation. The menu contains more than seven links, but it remains understandable because the links are categorized clearly and separated with whitespace and vertical dividers.

Miller's findings are best understood as guidance about short-term memory and the usefulness of meaningful chunks. The actual number of chunks a person can hold varies by individual knowledge, information complexity, and context.

Some research suggests that the average short-term memory limit may be closer to four items. Other theories argue against measuring working memory as a fixed number of elements at all.

## References

1. George A. Miller, "The Magical Number Seven, Plus or Minus Two: Some Limits on Our Capacity for Processing Information," *Psychological Review* 63, no. 2 (1956): 81-97.
2. John Sweller, "Cognitive Load During Problem Solving: Effects on Learning," *Cognitive Science* 12, no. 2 (1988): 257-85.
3. Nelson Cowan, "The Magical Number 4 in Short-Term Memory: A Reconsideration of Mental Storage Capacity," *Behavioral and Brain Sciences* 24, no. 1 (2001): 87-114.
4. Wei Ji Ma, Masud Husain, and Paul M. Bays, "Changing Concepts of Working Memory," *Nature Neuroscience* 17, no. 3 (2014): 347-56.
