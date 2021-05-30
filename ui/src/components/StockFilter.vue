<template>
  <div>
    <section>
      <div class="columns">
        <div class="column">
          <b-datepicker
            placeholder="Click to select..."
            v-model="dates"
            range
            @input="dateChanged">
          </b-datepicker>
        </div>
        <div class="column is-two-thirds">
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
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import gql from 'graphql-tag'
import moment from 'moment'

export default {
  name: 'StockFilter',
  methods: {
    clickMe() {
      this.$buefy.notification.open('Clicked!')
    },
    dateChanged(v) {
      console.log(moment(v[0]).format('MMM-DD-yyyy'), moment(v[1]).format('MMM-DD-yyyy'))
    }
  },
  data() {
    return {
      dates: [],
      currentCompany: {
        code: '--',
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