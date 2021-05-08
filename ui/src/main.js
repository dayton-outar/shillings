import Vue from 'vue'
import App from './App.vue'

import { ApolloClient } from 'apollo-client'
import { createHttpLink } from 'apollo-link-http'
import { InMemoryCache } from 'apollo-cache-inmemory'
import VueApollo from 'vue-apollo'
import Buefy from 'buefy'
import '/node_modules/buefy/dist/buefy.css'

// HTTP connection to the API
const httpLink = createHttpLink({
  // You should use an absolute URL here
  uri: 'http://localhost:5000/graphql',
})

// Cache implementation
const cache = new InMemoryCache()

// Create the apollo client
const apolloClient = new ApolloClient({
  link: httpLink,
  cache,
})

Vue.config.productionTip = false

Vue.use(VueApollo)
Vue.use(Buefy)

const apolloProvider = new VueApollo({
  defaultClient: apolloClient,
})

//new Vue({
//  render: h => h(App),
//}).$mount('#app')

new Vue({
  el: '#app',
  // inject apolloProvider here like vue-router or vuex
  apolloProvider,
  render:h => h(App),
})
