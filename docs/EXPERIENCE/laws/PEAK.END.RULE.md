# Chapter 6: Peak-End Rule

_People judge an experience mostly by how they felt at its emotional peak and at its end, not by the total average of every moment._

## Overview

When people remember an experience, they usually do not replay the entire thing from beginning to end. Instead, they remember representative snapshots: the most emotionally intense moments and the final moments.

Those moments can be positive or negative. Either way, they strongly influence how people evaluate the whole experience and whether they would repeat it or recommend it to someone else.

This is the peak-end rule. For designers, the lesson is practical: identify the emotional high points and final moments in a user journey, then design those moments with care.

## Origins

Evidence for the peak-end rule was first explored in the 1993 paper "When More Pain Is Preferred to Less: Adding a Better End" by Daniel Kahneman and colleagues.

In the experiment, participants experienced two versions of an unpleasant event. In the first trial, they submerged one hand in cold water at 14°C, about 57°F, for 60 seconds. In the second trial, they submerged the other hand in the same cold water for 60 seconds, then kept it there for another 30 seconds while the water warmed slightly to 15°C.

When asked which experience they would repeat, participants were more willing to repeat the second trial, even though it lasted longer. The researchers concluded that participants preferred the memory of the longer trial because it ended less unpleasantly.

Later studies supported the same pattern. In one study, colonoscopy and lithotripsy patients evaluated their discomfort based mainly on the worst and final moments of pain, regardless of the total length of the procedure or the variation in pain during it.

Another study divided colonoscopy patients into two groups. One group received the standard procedure. The other group received the same procedure, but the tip of the scope was left in place for three extra minutes without inflation or suction. Patients in the longer procedure experienced the final moments as less painful, rated the overall experience as less unpleasant, and were more likely to return for future procedures.

The longer procedure was remembered more positively because it ended better.

## Psychology Concept: Cognitive Biases

To understand the peak-end rule, it helps to understand cognitive biases.

Cognitive biases are systematic errors in thinking or judgment. They shape how we perceive the world and how we make decisions. Amos Tversky and Daniel Kahneman introduced the idea in 1972.

Biases often work as mental shortcuts. They help people make fast decisions without analyzing every situation from scratch. That can be useful because constant deep analysis would be exhausting. But cognitive biases can also distort perception and lead to poor decisions.

Confirmation bias is one common example. People tend to seek, interpret, and remember information that confirms what they already believe, while discounting information that challenges those beliefs.

The peak-end rule is also a cognitive bias. More specifically, it is a memory bias because it affects how we recall an experience. We do not remember the full average of how we felt from beginning to end. Instead, we overweight the emotional peak and the end.

The peak-end rule is related to the recency effect, which says that items near the end of a sequence are easier to recall.

## Examples

Spotify Wrapped is a strong example of designing for a positive peak and ending moment. The end of the year naturally invites reflection, and Spotify turns that moment into a personalized recap of a user's listening habits.

Wrapped shows favorite artists, most-played songs, listening statistics, interactive quizzes, personalized insights, global rankings, and other shareable moments.

![Spotify Wrapped 2022.](/.attachments/6-1-laws-spotify.png)

_**Figure 6-1.** Spotify Wrapped 2022._

Figure 6-1 shows Spotify Wrapped creating a personalized, memorable experience. The feature helps users reflect on themselves through music, learn more about the artists and podcasts they enjoyed, and participate in a larger musical community through sharing.

Negative moments can shape memory just as strongly as positive ones. Wait times are a common source of negative emotional peaks.

Uber recognized that waiting was unavoidable in its Express POOL model, so it worked to improve the perception of waiting. The app focused on three ideas: idleness aversion, operational transparency, and the goal gradient effect.

Idleness aversion means people feel better when they have something to pay attention to while waiting. Operational transparency means the system explains what is happening. The goal gradient effect means people feel more motivated when they can see progress toward a goal.

![Uber app wait-time experience.](/.attachments/6-2-laws-uber.png)

_**Figure 6-2.** Uber app wait-time experience._

Figure 6-2 shows Uber using animation, estimated arrival times, process explanations, and visible progress to reduce the pain of waiting. By improving the perceived wait, Uber reduced post-request cancellations and avoided a negative emotional peak.

Duolingo also designs around emotional peaks. The product makes language learning feel playful through levels, streaks, celebrations, and feedback that reinforce progress.

![Duolingo gamified learning features.](/.attachments/6-3-laws-duolingo.png)

_**Figure 6-3.** Duolingo gamified learning features._

Figure 6-3 shows Duolingo celebrating milestones. These moments represent accumulated effort and make progress feel visible.

Duolingo also uses Legendary Level challenges. When users complete a timed challenge successfully, they unlock a new interface theme.

![Duolingo Legendary Level unlock screen.](/.attachments/6-4-laws-legendary.png)

_**Figure 6-4.** Duolingo Legendary Level unlock screen._

Figure 6-4 shows how a reward moment can turn achievement into a stronger positive memory.

## Technique: Journey Mapping

Journey mapping is a useful way to identify emotional peaks throughout an experience. It is a qualitative exercise that visualizes how people use a product or service while trying to accomplish a specific task or goal.

A journey map creates a shared artifact that helps designers and stakeholders align around a common understanding of the experience. It also helps reveal challenges, opportunities, and emotional moments that might otherwise be missed.

![Example journey map.](/.attachments/6-5-laws-journey.map.png)

_**Figure 6-5.** Example journey map._

Figure 6-5 shows a journey map as a design artifact.

Journey maps should be tailored to the goals of the project and grounded in research with real users. They usually contain three major parts.

### Lens

The lens defines whose experience is being mapped. It usually includes the persona, the scenario, and the user's expectations.

For example: Jane is using a ride-share app to order a ride, and she expects the ride to arrive at her exact location in 10 minutes or less. The persona, scenario, and expectation create the perspective for the rest of the map.

### Experience

The experience section maps the user's actions, mindset, and emotions across a timeline.

It usually starts with high-level phases. Under each phase are the actions the user takes to complete the task. The map also captures the user's thoughts, questions, motivations, and pain points, usually based on research and interviews.

The emotional layer is especially important for the peak-end rule. It is often shown as a line across the journey and captures how the persona feels throughout the experience. This makes emotional peaks easier to see and discuss.

### Insights

The insights section captures the important takeaways from the journey. It often includes opportunities to improve the experience, metrics that can track improvement, and internal ownership for those areas.

In a ride-share example, real-time vehicle location could reduce the pain of waiting. The product team might own the feature, and post-ride ratings could help measure whether the change improves the experience.

## Key Consideration: Negativity Bias

People tend to register negative events more readily than positive ones, and they often dwell on those negative events longer. This negativity bias can make bad moments feel more important than they objectively are.

Every product or service will eventually have something go wrong. There may be an outage, a security issue, a confusing workflow, or a design decision that fails to account for some users. These situations can create emotional peaks that shape the overall memory of the experience.

Designers should reduce negative peaks whenever possible. One effective approach is to provide guidance that prevents users from reaching error states in the first place.

Account creation is a common risk area, especially when password rules are rigid or unclear. Mailchimp reduces this friction with real-time validation that makes password requirements visible and easier to follow.

![Mailchimp real-time password validation.](/.attachments/6-6-laws-real.time.password.validation.png)

_**Figure 6-6.** Mailchimp real-time password validation._

Figure 6-6 shows password validation that helps users avoid a frustrating error state.

Setbacks can also become opportunities when the right fallback is in place. A 404 page can frustrate users because it means the page they wanted cannot be found. But some companies use 404 pages to create a lighter moment and reinforce brand personality.

![404 pages using humor and brand personality.](/.attachments/6-7-laws-404.pages.png)

_**Figure 6-7.** 404 pages using humor and brand personality._

Figure 6-7 shows 404 pages that use humor and brand voice. Humor must be used carefully, though. If the context is serious or the user's frustration is high, a joke can make the experience worse.

## References

1. Daniel Kahneman, Barbara L. Fredrickson, Charles A. Schreiber, and Donald A. Redelmeier, "When More Pain Is Preferred to Less: Adding a Better End," *Psychological Science* 4, no. 6 (1993): 401-5.
2. Donald A. Redelmeier and Daniel Kahneman, "Patients' Memories of Painful Medical Treatments: Real-Time and Retrospective Evaluations of Two Minimally Invasive Procedures," *Pain* 66, no. 1 (1996): 3-8.
3. Donald A. Redelmeier, Joel Katz, and Daniel Kahneman, "Memories of Colonoscopy: A Randomized Trial," *Pain* 104, no. 1-2 (2003): 187-94.
4. Daniel Kahneman and Amos Tversky, "Subjective Probability: A Judgment of Representativeness," *Cognitive Psychology* 3, no. 3 (1972): 430-54.
5. Scott Plous, *The Psychology of Judgment and Decision Making* (New York: McGraw-Hill, 1993).
6. Candice Hogan, "How Uber Leverages Applied Behavioral Science at Scale," Uber Engineering (blog), January 28, 2019, https://oreil.ly/n1csD.
