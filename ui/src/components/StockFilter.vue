<template>
  <div>
    <p>{{ msg }}</p>
    <section>
      <b-dropdown
        :expanded="true"
        aria-role="list">
        <template #trigger="{ active }">
          <b-button
                  label="Companies"
                  type="is-primary"
                  expanded
                  :icon-right="active ? 'menu-up' : 'menu-down'" />
        </template>
        
        <b-dropdown-item aria-role="listitem" v-for="company in companies.nodes" :key="company.id">
          {{company.security}}
        </b-dropdown-item>
      </b-dropdown>
    </section>
  </div>
</template>

<script>
import gql from 'graphql-tag'

export default {
  name: 'StockFilter',
  props: {
    msg: String
  },
  methods: {
    clickMe() {
      this.$buefy.notification.open('Clicked!')
    }
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
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>