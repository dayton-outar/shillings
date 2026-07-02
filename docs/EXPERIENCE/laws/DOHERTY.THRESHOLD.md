# Chapter 10: Doherty Threshold

_Productivity rises when a computer and user interact quickly enough that neither has to wait on the other, ideally under_ ${400\text{ ms}}$.

## Overview

Performance is essential to good user experience. Slow processing, missing feedback, and long load times can quickly turn into frustration and leave a negative impression.

Speed is often treated as a technical concern, but it is also a design feature. Initial load time, interaction response time, feedback timing, and page-to-page speed all shape the user's experience.

Many factors affect performance, but page weight is one of the most important. Page weight is the total size of the files, scripts, and media required to load a page. On the web, average page weight has grown dramatically.

According to the HTTP Archive, the average desktop page in 2023 weighed more than 2 MB, or 2286 KB. The average mobile page was just over 2 MB, or 2007 KB. In 2010-2011, those averages were much smaller: 634 KB on desktop and 260 KB on mobile.

![Average page weight increasing over time.](/.attachments/10-1-laws-average.page.weight.png)

_**Figure 10-1.** Average page weight increasing over time._

Figure 10-1 shows the growth in average page weight.

More weight usually means more waiting. Waiting is painful when users are trying to complete a task, and long waits can lead to frustration or abandonment.

Response timing also affects productivity. A response around ${100\text{ ms}}$ feels instant. A delay between ${100\text{ ms}}$ and ${300\text{ ms}}$ becomes perceptible, and users begin to feel less in control.

Once delay passes ${1000\text{ ms}}$, or ${1\text{ second}}$, people start thinking about other things. Their attention wanders, task-relevant information begins to fade, cognitive load increases, and performance drops.

## Origins

In the early days of desktop computing, a two-second response time was considered acceptable. The assumption was that this gave users time to think about their next action.

In 1982, IBM employees Walter J. Doherty and Ahrvind J. Thadani challenged that standard in a study titled "The Economic Value of Rapid Response Time." They argued that productivity increases more than proportionally as response time decreases when the threshold is under ${400\text{ ms}}$.

Their claim was that when computers and users interact at a pace where neither waits on the other, productivity rises, work costs fall, employee satisfaction improves, and work quality tends to increase.

This became known as the Doherty threshold: the observation that computer response time has a disproportionate effect on productivity.

## Psychology Concept: Flow

Flow is a mental state in which a person is fully immersed in an activity. It includes energized focus, full involvement, enjoyment, and a sense of control.

Psychologist Mihály Csíkszentmihályi coined the term in 1970. The concept has since been used across many fields, especially occupational therapy.

Flow happens when the difficulty of a task is balanced with the user's skill level. A task that is too hard can create frustration. A task that is too easy can create boredom.

When people are in flow, they are deeply absorbed in the task, free from inner criticism, and significantly more productive.

Design can support flow by providing clear feedback, reducing unnecessary friction, improving responsiveness, and making useful content and features discoverable before users disengage.

## Examples

Sometimes processing takes longer than the Doherty threshold allows. When a task requires more than ${400\text{ ms}}$, the system can still provide timely feedback while the work continues in the background.

This creates the perception that the product is faster than it really is.

Skeleton screens are one common pattern. Platforms such as Instagram show placeholder blocks where content will appear. These blocks are gradually replaced by real text and images as they load.

![Instagram skeleton screen while content loads.](/.attachments/10-2-laws-instagram.skeleton.png)

_**Figure 10-2.** Instagram skeleton screen while content loads._

Figure 10-2 shows how a skeleton screen reduces the perception of waiting. It also reserves space for content, preventing the page from jumping around as items load.

The "blur up" technique is another perceived-performance pattern. It is especially useful for images, which often contribute heavily to slow loading.

The system first loads a tiny version of the image and scales it into the space where the final image will appear. A Gaussian blur hides pixelation and noise. When the high-resolution image finishes loading in the background, it replaces the blurred version.

![Unsplash using the blur up technique for faster perceived image loading.](/.attachments/10-3-laws-unsplash.png)

_**Figure 10-3.** Unsplash using the blur up technique for faster perceived image loading._

Figure 10-3 shows how blur up prioritizes perceived speed while reserving layout space for the final image.

Animation can also keep people engaged while loading or processing happens. Percent-done progress indicators, commonly known as progress bars, make waiting more tolerable even when they are not perfectly accurate.

Progress bars work because they:

- Reassure people that their action is being processed.
- Provide visual interest while people wait.
- Shift attention toward visible progress instead of the act of waiting.

Gmail uses an animated logo with a progress bar while the app loads.

![Gmail loading animation and progress bar.](/.attachments/10-4-laws-gmail.workspace.png)

_**Figure 10-4.** Gmail loading animation and progress bar._

Figure 10-4 shows how animation can reduce uncertainty and make wait time feel shorter.

${10\text{ seconds}}$ is commonly treated as the limit for keeping a user's attention focused on a task. When a wait exceeds that limit, users usually want to do something else while they wait.

For waits longer than ${10\text{ seconds}}$, progress bars should be paired with an estimated time remaining and a description of the current task. This helps users understand how long they may need to wait and whether they can safely shift attention elsewhere.

![Apple update screen with estimated time to completion and progress bar.](/.attachments/10-5-laws-apple.estimated.time.to.completion.png)

_**Figure 10-5.** Apple update screen with estimated time to completion and progress bar._

Figure 10-5 shows Apple providing progress and estimated completion time during an update.

Optimistic UI is another technique for improving perceived performance. It gives immediate feedback that an action was successful while the system continues processing in the background.

Instagram uses this pattern by displaying comments before they are actually posted. If the post fails, the app shows an error afterward.

![Instagram optimistically displaying a comment before it is fully posted.](/.attachments/10-6-laws-instagram.optimistical.display.png)

_**Figure 10-6.** Instagram optimistically displaying a comment before it is fully posted._

Figure 10-6 shows how optimistic UI improves perceived responsiveness while background processing continues.

## Key Consideration: Friction

Most response-time problems happen because a system is too slow. But response times can also be too fast.

If a change happens faster than users expect, they may miss it entirely. This is especially likely when the change happens automatically rather than in response to an action. A response that is too fast can also make it hard to understand what happened because users do not have enough time to process the change.

Too-fast responses can even create mistrust when they do not match the user's expectations about the task. In some cases, adding a purposeful delay can increase perceived value and trust, even when the system could complete the process faster.

Friction can be useful when users need to make a careful decision. A confirmation modal, for example, can introduce enough pause to activate more deliberate System 2 thinking and reduce mistakes.

Google's Privacy Checkup is another example. The process scans an account for potential privacy vulnerabilities, but Google also uses the waiting time to explain what is being checked. The added time can make the scan feel more thorough and trustworthy.

![Google Privacy Checkup scan with educational waiting state.](/.attachments/10-7-laws-google.privacy.checkup.png)

_**Figure 10-7.** Google Privacy Checkup scan with educational waiting state._

Figure 10-7 shows how a deliberate delay can educate users and build trust when the task feels important.

## References

1. Walter J. Doherty and Ahrvind J. Thadani, "The Economic Value of Rapid Response Time," IBM Systems Journal, 1982. The original study has been lost, but a copy is available on Jim Elliott's Mainframe Blog: https://oreil.ly/8Gpua.
2. Mihály Csíkszentmihályi, *Flow: The Psychology of Optimal Experience* (New York: Harper & Row, 1990).
3. Joshua Gold and Joseph Ciorciari, "A Review on the Role of the Neuroscience of Flow States in the Modern World," *Behavioral Sciences* 10, no. 9 (2020): 137, https://doi.org/10.3390/bs10090137.
4. Brad A. Myers, "The Importance of Percent-Done Progress Indicators for Computer-Human Interfaces," in *CHI '85: Proceedings of the SIGCHI Conference on Human Factors in Computing Systems* (New York: Association for Computing Machinery, 1985), 11-17.
5. Robert B. Miller, "Response Time in Man-Computer Conversational Transactions," in *Proceedings of the December 9-11, 1968, Fall Joint Computer Conference, Part I*, vol. 33 (New York: Association for Computing Machinery, 1968), 267-77.
6. Mark Wilson, "The UX Secret That Will Ruin Apps for You," *Fast Company*, July 6, 2016, https://oreil.ly/meoX2.
