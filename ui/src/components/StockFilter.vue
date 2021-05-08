<template>
  <div>
    <section>
      <b-dropdown
        :expanded="true"
        v-model="currentCompany"
        aria-role="list">
        <template #trigger>
          <b-button
                  :label="currentCompany.security"
                  type="is-primary"
                  expanded
                  icon-right="menu-down" />
        </template>
        
        <b-dropdown-item aria-role="listitem" 
            v-for="company in companies" 
            :key="company.code"
            :value="company">
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
      currentCompany: {
        code: 'all',
        security: 'Companies',
        created: new Date()
      },
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