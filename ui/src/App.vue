<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <ul>
    <li v-for="company in companies" :key="company.id">
      <p>{{company.security}}</p>
    </li>
  </ul>
</template>

<script>

import HelloWorld from './components/HelloWorld.vue'
import { gql } from '@apollo/client'
import { ref } from 'vue'
import { useQuery, useResult } from '@vue/apollo-composable'
//import companiesQuery from './gql/companies.gql'

export default {
  name: 'App',
  components: {
    HelloWorld
  },
  setup() {
    const companiesQuery = gql`query {
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
    const { result } = useQuery(companiesQuery)
    const companies = useResult(result, null, data => data.companies.nodes)

    console.log(companies)

    return { companies }
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
