# Chapter 1: Jakob's Law

_Users spend most of their time in products other than yours, so they expect your product to work like the ones they already know._

## Overview

Familiarity is powerful in digital products. When an interface behaves in a way people recognize, they can understand the navigation, locate content, read visual cues, and act without first learning a new system.

That saved effort matters. The less mental energy people spend decoding an interface, the more attention they can give to the task they came to complete. A product that feels immediately understandable lowers cognitive load and makes successful action more likely.

Designers should remove friction when that friction does not create value. Some friction is useful or necessary, but unnecessary friction slows people down and makes the experience feel harder than it needs to be. One practical way to reduce it is to use familiar patterns in important parts of the experience, such as page structure, navigation, workflows, search placement, and checkout behavior.

When familiar conventions are used well, people can become productive right away instead of pausing to figure out how the product works.

## Origins

Jakob's law, also called Jakob's law of internet user experience, was introduced by usability expert Jakob Nielsen in 2000. Nielsen observed that people build expectations from the many websites and products they have already used. Those expectations shape how they approach new interfaces.

The principle encourages designers to follow common conventions when those conventions help people focus on the product's content, message, or task. Unfamiliar conventions can make an interface feel confusing or frustrating, especially when they contradict what people already believe should happen.

This accumulated experience is one of the foundations of user experience design. It connects directly to the psychology concept of mental models.

## Psychology Concept: Mental Models

A mental model is a person's internal understanding of how a system works. The system might be digital, like a website, or physical, like a checkout line in a store. Once people form a model, they reuse it when they encounter something similar.

That means people bring knowledge from previous experiences into every new product they use. Designers can support that behavior by aligning interfaces with the mental models users already have. When the design matches the user's expectations, the user can transfer existing knowledge instead of learning from scratch.

This is one of the reasons good user experiences feel obvious. The interface does not force people to stop and rebuild their understanding. Instead, it meets them where their expectations already are.

One of the hardest parts of design is reducing the gap between the team's mental model and the user's mental model. Teams use research methods such as user interviews, personas, journey maps, and empathy maps to understand what users expect, what they need, and how they think about the system being designed.

## Examples

Form controls look familiar because they borrow from physical controls. Toggles, radio buttons, buttons, and similar interface elements are modeled after real-world switches, knobs, and panels. People understand what they can do with these elements because their appearance suggests the possible action.

![Comparison between physical control panel elements and typical form elements.](/.attachments/1-1.comparison.panel.typical.form.png)

_**Fig 1-1.** Comparison between physical control panel elements and typical form elements._

Figure 1-1 compares control panel elements with common form controls. The similarity helps people understand the affordance of each control: what action is possible and how they can interact with it.

When a design breaks from a user's mental model, confusion is likely. This is especially risky when a familiar product changes suddenly. A mismatch between the user's expectations and the redesigned interface can affect both perception and speed of understanding.

Snapchat's 2018 redesign is a well-known example. The company changed the app's familiar structure by combining stories and friend communication in the same place. The change was large, sudden, and disruptive to the way many users understood the app. Users reacted negatively, many moved toward Instagram, and Snapchat saw drops in ad views, revenue, and user count. The redesign failed to account for the mental model users had already built.

Large redesigns can work better when users are given time and control. Google has often introduced redesigned products by letting people opt in first. When YouTube launched a new desktop interface in 2017, users could preview the Material Design version, try it, give feedback, and switch back to the older version if they preferred it.

![Before-and-After comparison of YouTube's 2017 redesign.](/.attachments/1-2.youtube.2017.png)

_**Figure 1-2.** Before-and-After comparison of YouTube's 2017 redesign._

Figure 1-2 shows the YouTube redesign. The important lesson is not simply the visual change, but the rollout strategy. By letting people move at their own pace, Google reduced the shock of the mental model mismatch.

Ecommerce sites also rely heavily on shared mental models. People expect to browse products, select items, add them to a cart, review the cart, and check out. These patterns are familiar because they are repeated across many shopping experiences.

![Etsy interface showing familiar ecommerce patterns.](/.attachments/1-3-etsy.png)

_**Figure 1-3.** Etsy interface showing familiar ecommerce patterns._

Figure 1-3 shows how Etsy uses common ecommerce conventions to keep customers focused on finding and buying products instead of learning a new interaction model. The experience feels easier because it matches what shoppers already know.

Mental models are not limited to digital interfaces. Automotive controls often use the same principle. In the 2023 Mercedes-Benz EQS SUV, the seat controls are shaped and arranged to match the seat itself.

![Seat controls in the 2023 Mercedes-Benz EQS SUV.](/.attachments/1-4.seats.controls.mercedes.png)

_**Figure 1-4.** Seat controls in the 2023 Mercedes-Benz EQS SUV._

Figure 1-4 shows how the controls map directly to the object being controlled. A user can infer which part of the seat will move because the control resembles the seat's shape.

Familiar patterns also help people adopt new technology. Apple's Vision Pro uses recognizable interface components such as sidebars, tabs, search fields, and movable windows. Even in a spatial computing environment, these familiar elements help users understand what they can do.

![Apple Vision Pro interface using common components and interaction patterns.](/.attachments/1-5.apple.vision.png)

_**Figure 1-5.** Apple Vision Pro interface using common components and interaction patterns._

Figure 1-5 shows how Vision Pro blends new interaction possibilities with familiar interface structures. Windows can be moved, resized, and closed, while their visual treatment helps them sit naturally inside the user's physical surroundings.

## Technique: User Personas

Design becomes harder when a team talks about "the user" without a shared understanding of who that user is. Each designer may imagine a different person, which leads to inconsistent decisions.

User personas help solve this by turning research into a focused representation of a specific audience segment. A persona is fictional, but it should be based on patterns found in real user data. It gives the team a shared reference point for the user's traits, needs, motivations, behaviors, and frustrations.

![User persona example](/.attachments/1-6.personas.png)

_**Figure 1-6.** User persona example._

Figure 1-6 shows an example of a persona. Personas are useful because they support empathy, reduce self-referential decision-making, and help teams prioritize features around real user needs.

Research-based personas are more reliable than purely invented ones. Fictional personas may still align a team, but if they are not grounded in actual user research, they may point the team in the wrong direction.

Most useful personas include three kinds of information.

### Info

This section includes quick identifying details such as a photo, name, age, occupation, and memorable tagline. These details make the persona feel realistic and represent the shared traits of a specific group in the target audience.

### Details

This section builds empathy and context. It often includes a short bio, relevant behaviors, frustrations, goals, motivations, and tasks the user may perform while using the product or feature.

### Insights

This section captures the user's attitude and mindset. It often includes direct quotes from user research so the team can keep the user's actual language and perspective close to the design process.

## Key Consideration: Sameness

Jakob's law does not mean every website or app should look and behave exactly the same. It means designers should understand the user's existing mental models and use familiar conventions when those conventions make the experience easier.

There is a fair concern that too much convention can make digital products feel repetitive. Many products look similar because of popular frameworks, mature platform standards, competitive imitation, and design trends. Some of that sameness is uninspired. But some conventions exist because they solve real usability problems.

Search placement, footer navigation, and multistep checkout flows are common because people have learned how they work. When these patterns appear where users expect them, users spend less energy finding their way around.

The alternative would be exhausting. If every website and app used completely different layouts, navigation systems, styling, and interaction rules, people could not rely on prior experience. They would have to explore and experiment before every task. Even a simple action, such as finding navigation or search, would require extra mental effort.

Innovation still has a place. Sometimes a new approach is better, and sometimes breaking a convention can help a product stand apart. The important point is that designers should make that choice deliberately. User needs, context, and technical constraints should guide the decision. When a design departs from familiar patterns, it should be tested carefully to make sure people understand how it works.

## References

1. Jakob Nielsen, "End of Web Design," Nielsen Norman Group, July 22, 2000, https://oreil.ly/-kfBV.
2. Jakob Nielsen, "Mental Models," Nielsen Norman Group, October 17, 2010, https://oreil.ly/2zrw7.
3. Donald A. Norman, *The Design of Everyday Things: Revised and Expanded Edition* (New York: Basic Books, 2013), 10.
