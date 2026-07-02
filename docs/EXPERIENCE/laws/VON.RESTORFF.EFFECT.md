# Chapter 8: Von Restorff Effect

_When several similar objects are present, the one that differs from the rest is most likely to be remembered._

## Overview

Human vision and cognition are remarkably good at finding patterns and spotting differences. We can identify objects quickly, recognize visual relationships, and notice small differences between things.

These abilities affect how we perceive the world and how we remember it. They also affect how people use digital interfaces. A visually distinct element can capture attention faster than surrounding elements, which makes contrast a powerful design tool.

The challenge is managing attention. Designers can use emphasis to guide people toward important actions and information. But too many emphasized elements compete with each other, making it harder for users to identify what matters.

Color, shape, size, position, and motion can all direct attention. Each should be used deliberately.

## Origins

The von Restorff effect is named after German psychiatrist and pediatrician Hedwig von Restorff. In a 1933 study using the isolation paradigm, she found that people best remembered items that were distinctly different from other categorically similar items.

In other words, memory improves for items that are visually or conceptually isolated from the surrounding set.

Von Restorff was not the first person to study this effect, but her work became strongly associated with distinctiveness and memory. Later research, including work by Shelley Taylor and Susan Fiske, also suggested that people are drawn to salient, novel, surprising, or distinctive stimuli.

## Psychology Concept: Selective Attention

People live in a world full of distraction. At any moment, many signals compete for attention: while driving, working, attending events, shopping online, or simply moving through a busy environment.

Objects may be visible, but that does not mean people actually notice them. Attention shapes perception. To stay focused on what matters, people filter out information that seems irrelevant.

Selective attention is the cognitive ability to focus on relevant information while ignoring nonrelevant information. It is essential because attention is limited in both capacity and duration.

Working memory is closely related to attention. Because both are limited, interfaces need to guide attention carefully, reduce distraction, and help users find relevant information or actions.

Banner blindness is a common example of selective attention in digital interfaces. People often ignore elements that look like ads, even when those elements contain legitimate content. This behavior has been documented across decades.

Banner blindness makes sense when viewed through attention limits. People learn that ads usually do not help them complete their goals, so they filter them out. They are more likely to search for useful patterns such as navigation, search bars, headlines, links, and buttons.

This creates a design risk: if content is styled like an advertisement or placed near ads, users may ignore it.

Change blindness is related. It describes the tendency to miss significant changes when attention is focused elsewhere or when visual cues are not strong enough. If users need to notice a change in an interface, the design should make that change clear and visible.

## Examples

The von Restorff effect appears throughout digital products. Designers often need to make important elements or actions visually distinct. When used sparingly, contrast draws attention and helps guide users toward valuable information.

Buttons and links are common examples. Their visual difference communicates that they are interactive and helps users understand available actions.

Consider a confirmation modal with two versions. In one version, the actions are visually similar. In the other, the destructive action receives stronger emphasis.

![Confirmation modal showing how contrast can emphasize an important destructive action.](/.attachments/8-1-laws-contrast.draws.attention.png)

_**Figure 8-1.** Confirmation modal showing how contrast can emphasize an important destructive action._

Figure 8-1 shows how contrast can help users avoid accidentally selecting the wrong option. The emphasized destructive action is easier to identify, and the warning icon adds another cue that the decision is important.

The floating action button, or FAB, is another example. Introduced by Google's Material Design, the FAB represents the primary or most common action on a screen.

![Examples of floating action buttons from Material Design.](/.attachments/8-2-laws-floating.action.buttons.png)

_**Figure 8-2.** Examples of floating action buttons from Material Design._

Figure 8-2 shows floating action buttons. Their size, shape, position, and consistent behavior make them visually distinct and recognizable. This is also an example of Jakob's law because the pattern becomes familiar across products.

Pricing tables often use the von Restorff effect by emphasizing one subscription plan over the others. Designers may use color, size, labels, position, or shape to make a recommended plan stand out.

![Pricing table emphasizing Notion's Plus plan.](/.attachments/8-3-laws-von.restorff.effect.png)

_**Figure 8-3.** Pricing table emphasizing Notion's Plus plan._

Figure 8-3 shows Notion emphasizing one pricing option through a darker button, a "Most popular" label, a slightly larger card, and a central position.

Notifications also rely on contrast. They are designed to tell users that something requires attention or action.

![iOS notifications using contrast to draw attention.](/.attachments/8-4-laws-von.restorff.effect.notifications.png)

_**Figure 8-4.** iOS notifications using contrast to draw attention._

Figure 8-4 shows notifications using visual emphasis to call attention to new information.

The same principle applies beyond individual elements. News websites often emphasize featured content within dense layouts filled with headlines, images, and ads.

![News websites using scale to emphasize featured headlines.](/.attachments/8-5-laws-news.websites.png)

_**Figure 8-5.** News websites using scale to emphasize featured headlines._

Figure 8-5 shows news sites using scale to make featured content stand out from surrounding columns and headlines.

Visual contrast can come from many properties. Color is common, but scale, shape, spacing, negative space, and motion can also make content stand out.

## Key Consideration: Accessibility

Accessibility deserves deep attention, especially when using visual contrast to communicate meaning. Designers should understand which visual properties create contrast and how different users may experience them.

### Color Contrast

People with color vision deficiency may not be able to distinguish certain colors. Some people cannot see color at all. Other vision impairments, such as cataracts, can make subtle differences harder to perceive.

Sufficient contrast between foreground and background elements helps users with low vision and improves readability for everyone. Text contrast is especially important.

According to the Web Content Accessibility Guidelines, the contrast ratio between text and background should be at least 4.5:1. For larger text, at least 18 pt, or bold text, at least 14 pt, the minimum ratio is 3:1.

### Visual Cues

Color should not be the only way to communicate contrast, interactivity, or feedback. Users with color blindness or low vision may miss meaning that depends entirely on color.

Additional cues such as strokes, patterns, shape, labels, and focus indicators make elements easier to identify. Focus indicators are especially important for keyboard users because they show which link, form field, widget, button, or menu item is currently active.

### Moderation

Contrast should be intentional. Too little contrast makes important information hard to find. Too much contrast dilutes emphasis and can visually overwhelm people.

Moderation also matters because of banner blindness and change blindness. If emphasized content looks like an ad, users may ignore it. If too many items are emphasized, users may tune out the noise and miss important information.

Motion can create contrast too, but it must be used carefully. Motion can negatively affect people with vestibular disorders, benign paroxysmal positional vertigo, labyrinthitis, epilepsy, or migraine sensitivity. It can trigger dizziness, nausea, headaches, or worse.

Designers should use motion only when it serves a clear purpose and should provide safe alternatives where appropriate.

## Technique: Eye Tracking

Eye tracking is a research technique that measures where users look and how they interact visually with digital interfaces or physical objects.

Using specialized hardware and software, eye-tracking studies can reveal where users look, how they navigate, what they ignore, and how they respond emotionally. This data can help teams understand behavior, improve usability, and reduce reliance on self-reported feedback.

Common types of eye-tracking studies include heat maps, gaze plots, fixation duration studies, attentional bias studies, and comparative studies. The right type depends on the research question, study goals, and interface or object being studied.

### 1. Define the Research Question

Identify the research question or hypothesis the study should answer.

### 2. Select the Participants

Choose participants who represent the target user group.

### 3. Set Up the Equipment

Set up the eye-tracking hardware and software, then calibrate the system for each participant.

### 4. Develop the Stimuli

Create the stimuli participants will interact with, such as interfaces, websites, or physical objects.

### 5. Conduct the Study

Ask participants to interact with the stimuli while their eye movements are recorded.

### 6. Analyze the Data

Analyze the eye-tracking data to answer the research question or hypothesis.

### 7. Interpret the Results

Interpret the results and draw conclusions about user behavior, preferences, and cognitive processes.

Eye tracking is powerful, but it has limitations. It can lack context, introduce interference, use limited sample sizes, rely on limited stimuli, miss cultural differences, and face technical constraints. It is best used alongside other research methods so teams can build a fuller understanding of user behavior.

## References

1. Mark P. Mattson, "Superior Pattern Processing Is the Essence of the Evolved Human Brain," *Frontiers in Neuroscience* 8, no. 8 (2014): 265.
2. Hedwig von Restorff, "Über die Wirkung von Bereichsbildungen im Spurenfeld," *Psychologische Forschung* 18 (1933): 299-342.
3. Shelley E. Taylor and Susan T. Fiske, "Salience, Attention, and Attribution: Top of the Head Phenomena," in *Advances in Experimental Social Psychology*, vol. 11, ed. Leonard Berkowitz (New York: Academic Press, 1978), 249-88.
4. Jakob Nielsen, "Tunnel Vision and Selective Attention," Nielsen Norman Group, August 26, 2012, https://oreil.ly/8OHG-.
5. Klaus Oberauer, "Working Memory and Attention-A Conceptual Analysis and Review," *Journal of Cognition* 2, no. 1 (2019): 36.
6. Kara Pernice, "Banner Blindness Revisited: Users Dodge Ads on Mobile and Desktop," Nielsen Norman Group, April 22, 2018, https://oreil.ly/d1wTo.
7. Raluca Budiu, "Change Blindness in UX: Definition," Nielsen Norman Group, September 23, 2018, https://oreil.ly/UAtMz.
8. "Understanding Success Criterion 1.4.3," World Wide Web Consortium, September 2023, https://oreil.ly/GfD4i.
