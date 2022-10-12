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
            v-model="selectedStocks"
            multiple
            scrollable
            aria-role="list"
            @change="selectStocks">
            <template #trigger>
              <b-button
                type="is-light"
                expanded
                icon-right="menu-down">
                Selected ({{ selectedStocks.length }})
              </b-button>
            </template>
            
            <b-dropdown-item aria-role="listitem" 
                v-for="stock in stocks.nodes" 
                :key="stock.code"
                :value="stock">
              {{stock.name}}
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
    this.$store.dispatch('stocks/fetch', {
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
  },
  methods: {
    dateChanged() {
      this.$emit('filterChanged', { dates: this.dates, stocks: this.selectedStocks })
    },
    selectStocks(v) {
      this.selectedStocks = v
      this.$emit('filterChanged', { dates: this.dates, stocks: this.selectedStocks })
    },
    dateFormatter(dates) {
      return `${ moment(dates[0]).format('MMM-D-YYYY') } ⟶ ${ moment(dates[1]).format('MMM-D-YYYY') }`
    }
  },
  computed: {
    ...mapState('stocks', ['stocks'])
  },
  data() {
    return {
      dates: [new Date(), new Date()],
      selectedStocks: []
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>