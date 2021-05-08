<template>
  <div>
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
        
        <b-dropdown-item aria-role="listitem" v-for="company in companies" :key="company.id">
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
  methods: {
    clickMe() {
      this.$buefy.notification.open('Clicked!')
    }
  },
  data() {
    return {
      companies: []
    }
  },
  apollo: {
    companies: {
      query() {
        let r = gql`query {
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

        return r
      },
      update (data) {
        return data.companies.nodes
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>