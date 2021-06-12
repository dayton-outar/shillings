<template>
  <div class="box">
      <div class="columns">
        <div class="column is-one-fifth">
          <b-datepicker
            placeholder="Click to select..."
            v-model="dates"
            :date-formatter="dateFormatter"
            range
            @input="dateChanged">
          </b-datepicker>
        </div>
        <div class="column is-four-fifths">
          <b-dropdown
            :expanded="true"
            v-model="selectedCompanies"
            multiple
            scrollable
            aria-role="list">
            <template #trigger>
              <b-button
                type="is-light"
                expanded
                icon-right="menu-down">
                Selected ({{ selectedCompanies.length }})
              </b-button>
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
  </div>
</template>

<script>
import { mapState } from 'vuex'
import moment from 'moment'

export default {
  name: 'StockFilter',
  beforeCreate() {
    this.$store.dispatch('fetchCompanies')
  },
  methods: {
    clickMe() {
      this.$buefy.notification.open('Clicked!')
    },
    dateChanged(v) {
      this.$emit('changedDate', v)
    },
    dateFormatter(dates) {
      return `${ moment(dates[0]).format('MMM-D-YYYY') } ⟶ ${ moment(dates[1]).format('MMM-D-YYYY') }`
    }
  },
  computed: {
    ...mapState(['companies'])
  },
  data() {
    return {
      dates: [new Date(), new Date()],
      selectedCompanies: []
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>