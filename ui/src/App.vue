<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <StockFilter msg="Welcome to Stock Watcher" />
    <ul>
    <li v-for="company in companies.nodes" :key="company.id">
      <p>{{company.security}}</p>
    </li>
  </ul>
  </div>
</template>

<script>
import StockFilter from './components/StockFilter.vue'
import gql from 'graphql-tag'

export default {
  name: 'App',
  components: {
    StockFilter
  },
  apollo: {
    companies: {
      query() {
        return gql`query {
          companies (
            first: 100
            order: { security: ASC}
            
          ) {
            nodes {
              code,
              security,
              created
            }
          }
        }`
      }
    },
    update: data => {
      console.log(data)
      return data.companies.nodes
    }
  },
  created() {
    console.log('App created')
  },
  mounted() {
    console.log('App mounted')
  },
  destroyed() {
    console.log('App destroyed')
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
