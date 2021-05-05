<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <ul>
    <!--
    <li v-for="" :key="">
      <p>{{}}</p>
    </li>
    -->
  </ul>
</template>

<script>

import HelloWorld from './components/HelloWorld.vue'
import { gql } from '@apollo/client'
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
        order: { security: ASC}        
      ) {
        edges {
          node {
            code,
            security,
            created
          }
        }
      }
    }`
    const { result } = useQuery(companiesQuery)

    console.log( result )
    //const companies = useResult(result, null, data => )
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
