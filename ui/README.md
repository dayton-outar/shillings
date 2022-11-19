# User Interface

This interface provides visualization and an aggregate summary of daily closing prices of stocks traded on the Jamaica Stock Exchange (JSE).

The interface provides a filter, which is a combination of a date range picker and a multiple-selection dropdown box, to expand or narrow results of the JSE daily summary into the visualization and aggregate tools for the user.

Another useful mention, is that users can add a portfolio of stocks purchased to see a statement of how well it performs over various periods.

## Requirements

 * [Node](https://nodejs.org/en/) 14.15 or greater

### Highlighted Packages

 * [Vue](https://vuejs.org/)<sup><a href="https://v2.vuejs.org/">Vue 2</a></sup>
 * [Vuex](https://vuex.vuejs.org/)
 * [Vue Router](https://router.vuejs.org/)
 * [Apollo](https://www.apollographql.com/docs/react/)
 * [Buefy](https://buefy.org/)
 * [Bulma](https://bulma.io/)
 * [ChartJS](https://www.chartjs.org/)
 * [Vue Currency Input](https://vue-currency-input-next.netlify.app/)
 * [Font Awesome](https://fontawesome.com/)
 * [Animate.css](https://animate.style/)
 
## Installation

In order to set up the development environment. Given that the version of node mentioned in requirements is installed on the host machine, perform the following command within this folder on the command line,

```
npm install
```

## Usage

Perform the following command to compile and run the application,

```
npm run serve
```

Perform the following command to compile and distribute files (from `dist` folder) that can be transferred to a web server for hosting,

```
npm run build
```

This application depends on [Babel](https://babeljs.io/) for linting. So, perform the following to lint the source code,
```
npm run lint
```

## Contributions

Since this is a **Vue 2** project, contributors should conform to the style guide outlined in [Vue 2 Style Guide](https://vuejs.org/v2/style-guide/).

Contributors new to **Vue 2** can get up to speed by following the documentation in [Vue 2 Guide](https://vuejs.org/v2/guide/).

[Vue 2 Examples](https://vuejs.org/v2/examples/) and [Vue 2 Recipes](https://vuejs.org/v2/cookbook/) are also available for learning at the [Vue](https://vuejs.org/) site.

### Notes

Had some issue installing a package to integrate vue with graphql and [this reference](https://www.gitmemory.com/issue/vuejs/vue-apollo/1156/821996642) really helped by giving me the following command,

```bash
npm install @vue/apollo-composable --save --legacy-peer-deps
```

## Customize Configuration

See [Configuration Reference](https://cli.vuejs.org/config/).

## Further Reading

1. Front-End Development Projects with Vue.js by Raymond Camden, Hugo Di Francesco, Clifford Gurney, Philip Kirkbride, Maya Shavin (Packt Publishing)
2. Building Vue.js Applications with GraphQL by Heitor Ramon Ribeiro (Packt Publishing)
3. [Vue Apollo v4: the first look](https://dev.to/n_tepluhina/vue-apollo-v4-the-first-look-c32)
4. [Vue Apollo: Smart Query](https://apollo.vuejs.org/api/smart-query.html#options)
5. [Combining GraphQL and Vuex](https://markus.oberlehner.net/blog/combining-graphql-and-vuex/) by Markus Oberlehner
6. [How to change page titles when using vue-router?](https://stackoverflow.com/questions/51639850/how-to-change-page-titles-when-using-vue-router) - StackOverflow
7. [My Vue Experience after 3 projects in 18 months](https://dev.to/crisarji/my-vue-experience-after-3-projects-in-18-months-456c)
8. [Financial Chart: Candlestick Sample](https://www.chartjs.org/chartjs-chart-financial/)
9. [How To Create a Global Event Bus in Vue 2](https://www.digitalocean.com/community/tutorials/vuejs-global-event-bus) - [Digital Ocean](https://www.digitalocean.com/)
10. [Using Vue Currency Input with Buefy](https://codesandbox.io/s/using-vue-currency-input-with-buefy-pnl3q?file=/src/App.vue) - [CodeSandbox](https://codesandbox.io/)

## Tutorial Videos

1. [Vuex Tutorial](https://www.youtube.com/playlist?list=PL4cUxeGkcC9i371QO_Rtkl26MwtiJ30P2) - [The Net Ninja](https://www.youtube.com/c/TheNetNinja)
2. [Vue JS 2](https://www.youtube.com/playlist?list=PL4cUxeGkcC9gQcYgjhBoeQH7wiAyZNrYa) - [The Net Ninja](https://www.youtube.com/c/TheNetNinja)
3. [Vue.js Todo App](https://www.youtube.com/playlist?list=PLEhEHUEU3x5q-xB1On4CsLPts0-rZ9oos) - [Andre Madarang](https://www.youtube.com/c/drehimself)
4. [GraphQL Tutorial](https://www.youtube.com/playlist?list=PL4cUxeGkcC9iK6Qhn-QLcXCXPQUov1U7f) - [The Net Ninja](https://www.youtube.com/c/TheNetNinja)
5. [Electron Tutorial](https://www.youtube.com/playlist?list=PLbu98QxRH81ILK1p1BnSRMPr2x-6Zd1oX) - [Red Stapler](https://www.youtube.com/c/RedStapler_channel)
6. [Vue JS 3 Tutorial for Beginners #10 - The Composition API (part 1)](https://youtu.be/V-kxBWcPJfo) - [The Net Ninja](https://www.youtube.com/c/TheNetNinja)
7. [Vue JS 3 Tutorial for Beginners #11 - The Composition API (part 2)](https://youtu.be/0FwBjPeLqQ8) - [The Net Ninja](https://www.youtube.com/c/TheNetNinja)
8. [Vue 3 Animations & Transitions](https://www.youtube.com/playlist?list=PL4cUxeGkcC9ghm7-iTfS9n468Kp7l9Ipu) - [The Net Ninja](https://www.youtube.com/c/TheNetNinja)
9. [Animating Vue Router Transitions in Vue 3](https://youtu.be/L77Uq93XXzk)
10. [Vue.js Tutorial: Add Analytics to Your App with Google Analytics](https://youtu.be/Umj51NqKF8Y)