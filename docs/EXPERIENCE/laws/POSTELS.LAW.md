# Chapter 5: Postel's Law

Be conservative in what you do, and be liberal in what you accept from others.

## Overview

Good user experience design is good human experience design. People are not machines. We are inconsistent, distracted, emotional, and sometimes error-prone. We expect products to understand us, forgive mistakes, and avoid asking for more effort than necessary.

At the same time, the devices and software people use vary widely. Screens, input methods, assistive technologies, feature support, connection speeds, and form factors all differ. To meet users where they are, products need to be robust and adaptable.

Postel's law, also known as the robustness principle, gives designers a useful way to think about this. The first half says to be conservative in what you do. In design, that means the interface or system we produce should be reliable, accessible, and usable by the broadest reasonable range of people.

The second half says to be liberal in what you accept from others. In design, that means accepting varied input from users across many contexts: keyboard, mouse, touch, gesture, assistive technology, voice, different languages, different dialects, different screen sizes, different resolutions, and different network conditions.

Postel's law helps designers create products that adapt to people as they actually are.

## Origins

Jon Postel was an American computer scientist whose work helped shape the protocols that became the internet. One of his major contributions was an early implementation of the Transmission Control Protocol, or TCP, which defines how data is sent and received over a network.

In the TCP specification, Postel introduced the robustness principle: implementations should be strict about what they send, but flexible about what they accept. Programs that send data should follow the specification. Programs that receive data should be able to accept and interpret imperfect input when the meaning is still clear.

Postel's principle was originally a network engineering guideline. Its fault tolerance helped nodes on the early internet communicate reliably. But the influence of the principle extends into software architecture and user experience design.

HTML and CSS are strong examples. Their loose error handling lets browsers recover gracefully from authoring mistakes or unsupported features. If the browser does not understand something, it usually ignores that part and continues. This flexibility helped make the web resilient and widely adaptable.

In user experience design, Postel's law applies to the relationship between system output and user input. Humans and computers communicate differently, so design has to bridge the gap. Designers can predict user behavior, but they should not assume perfect attention, perfect rationality, or perfect technical conditions.

## Examples

Postel's law encourages designers to anticipate variation in input, access, and capability while still providing a reliable interface. Forms are one of the clearest examples.

Forms are a primary way people provide information to digital systems. A product needs information, and the user provides it through inputs that the system processes.

The first design consideration is to be conservative about what you ask for. Every required field adds effort. More fields increase cognitive load, can contribute to decision fatigue, and reduce the chance that someone will finish the form. A form should ask only for what is necessary and avoid requesting information the system already has.

The second consideration is flexibility. Forms often assume a narrow model of human identity and address structure. Name order differs by culture. Addresses do not always fit a country, state, city, and postal code pattern. Names may include hyphens, spaces, short strings, or structures the system designer did not expect.

Validation and error messaging also matter. Telling someone that their name is "wrong" or "not accepted" can make the product feel hostile. A resilient form accepts valid variation, explains boundaries clearly, and helps users recover when something cannot be processed.

Systems should also handle input that differs from what the computer expects. The best examples reduce effort for the user while translating human input into a format the system can use.

Apple's Face ID is one example. It lets users authenticate without entering a username or password every time they unlock a device, approve a purchase, or sign in to an app.

> [!figure]
> Figure 5-1 placeholder: Apple Face ID authentication.

Figure 5-1 shows Face ID as a flexible input method that reduces user effort while still producing secure system-readable authentication.

Responsive web design is another major example. As more devices gained web access, designers needed a way to serve content across many screen sizes and contexts.

Ethan Marcotte introduced responsive web design in 2010 as an approach based on fluid grids, flexible images, and media queries. Instead of designing separate desktop and mobile sites, responsive design lets content adapt fluidly to its viewing context.

> [!figure]
> Figure 5-2 placeholder: responsive web design adapting to different device sizes.

Figure 5-2 shows responsive web design embracing the fluid nature of the web. This approach accepts a wide range of devices and produces output that adapts reliably, from smartwatches and phones to laptops, desktops, gaming consoles, and TVs.

Progressive enhancement is another expression of Postel's law. It is a web design strategy that starts with core content and functionality, then progressively adds style and interaction when the user's browser, device, and connection can support them.

The approach was introduced by Steve Champeon and Nick Finck in 2003. It emphasizes universal access first. Everyone gets the core experience. Users with newer browsers, stronger devices, faster connections, or additional feature support receive enhanced layers.

This differs from graceful degradation, which starts with an advanced experience and then provides fallbacks when support is missing. Progressive enhancement begins with the resilient baseline and builds up from there.

A simple search box shows the idea well. The base experience allows anyone to type a query. If voice recognition is supported, the component can add voice input without removing the core text-input behavior.

> [!figure]
> Figure 5-3 placeholder: progressively enhanced search component with default search box and optional voice input.

Figure 5-3 shows a search component that works by default and then adds voice support where available.

Postel's law also applies to design processes. Design systems are collections of reusable components, patterns, and standards that help teams build consistent products at scale.

An effective design system must be liberal in what it accepts. Contributions may come from design, content, code, strategy, critique, and many different teams. But the output should be conservative: clear guidelines, purposeful components, coherent patterns, and practical principles.

> [!figure]
> Figure 5-4 placeholder: design systems from IBM, Salesforce, and Shopify.

Figure 5-4 shows how design systems help organizations scale design in a manageable and consistent way.

## Technique: User Interviews

Postel's law is about bridging the communication gap between humans and computers. To do that well, designers need to understand users instead of guessing about them.

User interviews are a direct way to collect that understanding. In a user interview, a researcher speaks one-on-one with a participant about a topic of interest, such as system use, behavior, habits, needs, or pain points.

Interviews can reveal what people think about a site, app, product, process, or service. They can uncover memorable content, priorities, frustrations, and ideas for improvement. Interviews can happen before design, alongside contextual inquiry, or after usability testing to understand observed behavior.

### Define the Goal of the Interview

Start by clarifying what the team needs to learn. A useful goal should be specific and tied to user behavior or attitudes.

"Learn more about our users" is too broad. A stronger goal would be: learn how doctors share patient medical history with other doctors, and where they see challenges or opportunities. That kind of goal creates sharper questions and more actionable insights.

### Prepare the Discussion Guide

Prepare questions before the session and keep them focused on the interview goal. Do not be afraid to ask follow-up questions based on the participant's responses.

A natural conversation can reveal unexpected insights. In many cases, a guide of themes is more useful than a rigid list of questions.

### Build Rapport with the Interviewee

Participants give better responses when they feel comfortable. Start by asking about them, where they live, and whether they have done anything like the interview before.

Reassure them that there are no right or wrong answers. Answer their questions and make it clear that the session is not a test of their knowledge or ability. People are more likely to open up when they trust the interviewer.

### Avoid Leading Questions

Avoid questions that can be answered only with "yes" or "no." Also avoid vague questions that are unlikely to produce specific, useful answers.

Use open questions that begin with "what," "how," or "when," or prompts such as "tell me about..." Be careful with wording because the way a question is framed can influence the response.

## Key Consideration: Design Resiliency

User input is variable. To create better experiences, systems should accept a broad range of input. But flexibility also creates more opportunities for things to go wrong. The more designers anticipate and plan for variation, the more resilient the design becomes.

Internationalization is one example. The same text string can become much longer or shorter depending on the language. Designers often plan only for their native language, but translation can create major layout changes. English is compact, and some English words can expand by up to 300 percent when translated into a less compact language such as Italian.

Text direction can also vary. Some languages read left to right, others right to left, and some can be vertical. Resilient designs account for changing text length and orientation.

> [!figure]
> Figure 5-5 placeholder: text expansion from English to Italian.

Figure 5-5 shows how translated text can expand and affect layout.

User-controlled font size is another example. People can adjust default font sizes on mobile devices and in browsers, often to improve accessibility. Designs that do not account for larger text can break when spacing, wrapping, and layout change.

Amazon's website header navigation responds well to minimum font size customization. As font size increases, lower-priority quick links are removed while the most important controls remain available.

> [!figure]
> Figure 5-6 placeholder: Amazon.com adapting to minimum font size customization.

Figure 5-6 shows an interface adapting to user-controlled font size instead of failing under it.

## References

1. Jon Postel, "RFC 793: Transmission Control Protocol," September 1981, https://oreil.ly/uxMIB.
2. "Why Do We Make Worse Decisions at the End of the Day?," The Decision Lab, August 15, 2019, https://oreil.ly/0qEbe.
3. Ethan Marcotte, "Responsive Web Design," *A List Apart*, May 25, 2010, https://oreil.ly/RYGX0.
