# Chapter 2: Fitts's Law

_The time it takes to reach a target depends on how far away the target is and how large it is._

## Overview

Usability is central to good design. A usable interface is easy to understand, easy to navigate, and straightforward to interact with. People should not need excessive effort to complete basic actions.

One important part of usability is the time it takes to move to an interactive object and select it. Buttons, links, controls, and other targets need to be sized and placed so people can select them accurately. This becomes more complex because people use different input methods, such as a mouse, finger, stylus, or gaze, and people also vary in dexterity and precision.

Fitts's law helps designers think through this problem. It states that the time required to engage with a target is related to the target's size and distance. Larger targets are faster to select. Targets that are closer are also faster to select. The reverse is also true: small targets that are far away take more time and precision.

This simple principle has wide implications for interface design.

## Origins

Fitts's law began with the work of American psychologist Paul Fitts in 1954. Fitts predicted that the time required to move quickly to a target area depends on the ratio between the distance to the target and the width of the target.

![Diagram depicting Fitts's law.](/.attachments/2-1-laws-fitt's.diagram.png)

_**Figure 2-1.** Diagram depicting Fitts's law._

Figure 2-1 shows the relationship between target distance and target width. Today, Fitts's law is one of the most influential mathematical models of human movement. It is widely used in ergonomics and human-computer interaction to model pointing, whether that pointing is physical or virtual.

Fitts also proposed an index of difficulty for target selection. In this model, the distance to the center of the target, `D`, acts like signal, and the tolerance or width of the target, `W`, acts like noise.

$$\huge{ 
  ID = \log_2\left(\frac{2D}{W}\right)
}$$

The formula captures the basic design lesson: increasing target size or reducing movement distance makes the interaction easier.

## Key Consideration: The Human Factor

During World War II, the American military experienced many accidental deaths and crashes. In one 22-month period, the Air Force reported 457 crashes, many of which were blamed on "pilot error."

Paul Fitts was assigned to investigate the cause. He noticed that the crash data did not look random, which suggested the issue was not simply a matter of accident-prone pilots. Fitts and his colleague Alfonse Chapanis interviewed pilots and found a clearer cause: under stress, pilots were confusing the flap controls with the landing gear controls because the controls looked identical.

Chapanis addressed the issue with a system called shape coding. Knobs and levers were given distinct shapes so pilots could tell them apart by feel, even in the dark or under pressure.

This work helped define the field of human factors. The core idea is that machines and systems should be designed around human behavior, limitations, and stress responses instead of assuming perfect attention and perfect rationality.

That lesson remains essential. Better technology does not force people to adapt to rigid systems. It adapts to the way people actually behave.

## Examples

Fitts's law began as a model for physical movement, but it also applies to digital interfaces. Three practical guidelines follow from it:

- Make touch targets large enough to recognize and select accurately.
- Leave enough space between touch targets.
- Place targets where people can reach them easily.

Touch target size is especially important. If a target is too small, people need more time and precision to select it. Different organizations recommend different minimum sizes, but each recommendation reflects the same concern: small targets are harder to use.

**Table 2-1.** Minimum touch target size recommendations

| Company/Org | Size |
| --- | --- |
| Spatial interfaces - Human Interface Guidelines (Apple) | 60 × 60 pt |
| Touch interfaces - Human Interface Guidelines (Apple) | 44 × 44 pt |
| Material Design guidelines (Google) | 48 × 48 dp |
| Web Content Accessibility Guidelines (WCAG) | 44 × 44 CSS px |
| Nielsen Norman Group | 1 × 1 cm |

These are minimums, not ideals. Designers should exceed them when possible so people do not need unnecessary precision. Larger targets make controls easier to select and can make the whole interface feel more usable.

Spacing matters too. When interactive elements sit too close together, accidental selection becomes more likely. The MIT Touch Lab found that the average adult fingertip is about 16-20 mm in diameter. Since people often touch partly outside the intended target, nearby controls can easily be triggered by mistake.

Google's Material Design guidance recommends separating touch targets by at least 8 density-independent pixels to balance information density and usability.

Position is the third major factor. Controls placed in hard-to-reach areas are harder to select. On smartphones, reachability depends on device size, how the person is holding the device, whether they are using one or two hands, and which finger or thumb is doing the work.

Research by Steven Hoober suggests people often prefer to view and touch the center of a smartphone screen, where touch accuracy is highest. Mobile attention also tends to concentrate near the center rather than following the desktop-style pattern of scanning from upper left to lower right.

![Smartphone touch accuracy illustration based on Steven Hoober's research.](/.attachments/2-2-laws-smartphone.touch.accuracy.png)

_**Figure 2-2.** Smartphone touch accuracy illustration based on Steven Hoober's research._

Figure 2-2 shows how touch accuracy varies across a smartphone screen.

A common example of Fitts's law is the relationship between form labels and inputs. When a text label is properly associated with its input, selecting the label performs the same action as selecting the input.

![Touch target area on a text label and form input.](/.attachments/2-3-laws-touch.target.area.png)

_**Figure 2-3.** Touch target area on a text label and form input._

Figure 2-3 shows how the selectable area expands when the label and input work together. This reduces the precision required from both desktop and mobile users.

Form submission buttons are another example. They are usually placed close to the final input in a form.

![Form submission button placed close to the last form input.](/.attachments/2-4-laws-form.submission.png)

_**Figure 2-4.** Form submission button placed close to the last form input._

Figure 2-4 shows how proximity makes the relationship between the final input and the submit action clear. It also minimizes the distance the user must travel to complete the form.

Spacing between actions is just as important as size and position. LinkedIn's iOS connection request confirmation screen places "accept" and "deny" close together on the right side of a dialog.

![LinkedIn dialog showing actions placed close together.](/.attachments/2-5-laws-ample.space.png)

_**Figure 2-5.** LinkedIn dialog showing actions placed close together._

Figure 2-5 shows how tight spacing increases the chance of accidental selection. When actions with opposite outcomes are too close, users must slow down and aim more carefully.

Vehicle interfaces add another layer of risk because the driver may need to keep attention on the road. In a car, a poorly placed or tightly packed control can become more than a usability issue.

Apple CarPlay follows Fitts's law by giving interactive elements generous spacing.

![Apple CarPlay interface with sufficient spacing between items.](/.attachments/2-6-laws-sufficient.space.png)

_**Figure 2-6.** Apple CarPlay interface with sufficient spacing between items._

Figure 2-6 shows how spacing helps reduce the chance of selecting the wrong action.

Apple's Reachability feature is another example of target placement. With larger iPhones, items at the top of the screen can be difficult to reach one-handed. Reachability brings the top half of the screen down so those controls are easier to access.

![iPhone Reachability feature bringing the top of the screen closer.](/.attachments/2-7-laws-reachability.png)

_**Figure 2-7.** iPhone Reachability feature bringing the top of the screen closer._

Figure 2-7 shows how Reachability reduces the distance between the user's thumb and hard-to-reach interface elements.

Fitts's law also explains infinite targets. At the edge of a screen, the pointer cannot overshoot because the screen boundary acts like a wall. This makes edge targets easier to acquire quickly.

Desktop operating systems use this pattern. In macOS, the Dock sits at the bottom edge of the screen, and the application menu sits along the top edge.

![macOS Dock and application menu as infinite targets.](/.attachments/2-8-laws-infinite.targets.png)

_**Figure 2-8.** macOS Dock and application menu as infinite targets._

Figure 2-8 shows how screen edges can make targets easier to reach without sacrificing accuracy.

Fitts's law is not limited to mouse and touch input. Spatial computing introduces interfaces that occupy physical space. In these environments, eye focus can signal intent and help target interactive elements.

Apple's visionOS uses eye input and hand gestures together. It improves target acquisition by placing primary content near the center of the user's field of view, keeping interactive content at a consistent depth, and reducing the need for neck, body, and eye-depth adjustment. Apple also recommends rounded interactive elements because sharp edges can draw the eye toward the boundary and reduce precision.

![Apple visionOS guidance for centered content, consistent depth, and rounded interactive elements.](/.attachments/2-9-laws-vision.os.png)

_**Figure 2-9.** Apple visionOS guidance for centered content, consistent depth, and rounded interactive elements._

Figure 2-9 shows how Fitts's law applies beyond flat screens and into spatial interfaces.

## Technique: Contextual Inquiry

Fitts and Chapanis's investigation into pilot behavior was an early form of contextual inquiry. Contextual inquiry is an ethnographic field study that combines observation and interviews with users in their natural environment.

The goal is to understand real work practices and behaviors. This method can reveal insights that interviews alone may miss. In an interview, users must remember and explain what they do away from the actual context. In contextual inquiry, the researcher watches the work happen directly, which creates a more accurate understanding of the process.

### Primer

Begin by easing the participant into the session. Introduce yourself, explain the goals of the inquiry, and describe what the participant can expect. Make it clear that their feedback is confidential.

### Contextual Interview

Transition into observation by explaining that you will watch while the participant works and may interrupt to ask about interesting moments. Also let them know they can tell you if it is a bad time to interrupt.

Once the session begins, watch and learn first. Pause the participant only when you need to understand or clarify something important. Ask open-ended questions that help them explain why they took a certain action.

Focus on the underlying process and any external resources the participant uses. Discuss both standard steps and unusual variations. Confirm or correct your interpretation of tasks and workflows, but avoid asking for validation too often because it may affect the participant's behavior.

### Wrapping Up

End by asking clarifying questions and summarizing your interpretation of the process. Review your notes and explain what you understood from the session. This gives the participant a chance to correct misunderstandings and fill in missing details.

## References

1. Paul M. Fitts, "The Information Capacity of the Human Motor System in Controlling the Amplitude of Movement," *Journal of Experimental Psychology* 47, no. 6 (1954): 381-91.
2. Kiran Dandekar, Balasundar I. Raju, and Mandayam A. Srinivasan, "3-D Finite-Element Models of Human and Monkey Fingertips to Investigate the Mechanics of Tactile Sense," *Journal of Biomechanical Engineering* 125, no. 5 (2003): 682-91.
3. Steven Hoober, "Design for Fingers, Touch, and People, Part 1," UXmatters, March 6, 2017, https://oreil.ly/piGSh.