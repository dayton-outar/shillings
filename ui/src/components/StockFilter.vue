<template>
  <div class="box">
      <div class="columns">
        <div class="column is-one-fifth">
          <b-datepicker
            placeholder="Click to select..."
            v-model="dates"
            :date-formatter="dateFormatter"
            icon-pack="fas"
            range
            @input="dateChanged">
          </b-datepicker>
        </div>
        <div class="column is-four-fifths">
          <b-dropdown
            :expanded="true"
            v-model="selectedMarket"
            scrollable
            aria-role="list"
            @change="selectMarket">
            <template #trigger>
              <b-button
                type="is-light"
                expanded
                icon-right="menu-down">
                {{ selectedMarket.name }}
              </b-button>
            </template>
            
            <b-dropdown-item aria-role="listitem" 
                v-for="market in markets.nodes" 
                :key="market.no"
                :value="market">
              {{market.name}}
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
  props: ['dates', 'selectedMarket'],
  beforeCreate() {
    this.$store.dispatch('markets/fetch', {
        first: 200,
        last: null,
        next: null,
        previous: null,
        filter: { name: { startsWith: '' } },
        ordering: [{ name: 'ASC' }]
      })
  },
  methods: {
    dateChanged() {
      this.$emit('filterChanged', { dates: this.dates, market: this.selectedMarket })
    },
    selectMarket(v) {
      this.selectedMarket = v
      this.$emit('filterChanged', { dates: this.dates, market: this.selectedMarket })
    },
    dateFormatter(dates) {
      return `${ moment(dates[0]).format('MMM-D-YYYY') } ⟶ ${ moment(dates[1]).format('MMM-D-YYYY') }`
    }
  },
  computed: {
    ...mapState('markets', ['markets'])
  },
  data() {
    return {}
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>