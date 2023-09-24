<template>
    <div>
      <div>
        <stocks-filter :dates="filterDates" :selectedMarket="market" @filterChanged="filterChanged" />
      </div>
        <!--<stock-indices :options="sixOptions" :begin="beginDate" :end="endDate" />-->
      <div class="my-6">
        <portfolio :formattedDateRange="formattedDateRange" />
      </div>
      <div>
        <stock-trades v-if="totalTrades" :formattedDateRange="formattedDateRange" :tradings="totalTrades" />
      </div>
    </div>
</template>

<script>
import { mapState, mapGetters, mapActions } from 'vuex'
import moment from 'moment'

import StockFilter from '../components/StockFilter.vue'
import StockTrades from '../components/StockTrades.vue'
// import VolumesPie from '../components/VolumesPie.vue'
// import StocksLine from '../components/StocksLine.vue'
// import PriceBar from '../components/PriceBar.vue'
// import TradeCost from '../components/TradeCost.vue'
import Portfolio from '../components/Portfolio.vue'
// import StockIndices from '../components/StockIndices.vue'
import Earnings from '../components/Earnings.vue'
import Solvencies from '../components/Solvencies.vue'

export default {
  components: {
    'stocks-filter': StockFilter,
    // 'stock-indices': StockIndices,
    'portfolio': Portfolio,
    // 'volumes-pie': VolumesPie,
    // 'stocks-line':StocksLine,
    'stock-trades':StockTrades,
    // 'price-bar': PriceBar,
    // 'trade-cost': TradeCost,
    'earnings': Earnings,
    'solvencies': Solvencies
  },
  data() {
    return {
      formattedDateRange: '',
      // TODO: Get latest traded date and use instead of date based on browser settings
      filterDates: [moment().subtract(7, 'days').toDate(), moment().toDate()],
      market: {
        no: -1,
        name: 'All Markets'
      },
      sixOptions: {
        readOnly: true,
        showTools: true
      }
    }
  },
  computed: {
    ...mapState('trades', ['totalTrades']),
    ...mapState({ isLoading: state => state.dependencies.isLoading }),
    ...mapGetters([
      'volumeShares',
      'tradeCosts',
      'pricePercentages'
      ])
  },
  created() {
    this.setLoading(true)
    this.formatDates(this.filterDates)

    this.fetch({
        marketNo: this.market.no,
        begin: `${ moment(this.filterDates[0]).format('YYYY-MM-DDT00:00:00.000') }Z`,
        end: `${ moment(this.filterDates[1]).format('YYYY-MM-DDT00:00:00.000') }Z`
      }).then(() => {
        this.fetchHoldings()
        this.setLoading(false)
      })
  },
  methods: {
    filterChanged(v) {
      this.beginDate = `${ moment( v.dates[0] ).format('YYYY-MM-DDT00:00:00.000') }Z`
      this.endDate = `${ moment( v.dates[1] ).format('YYYY-MM-DDT00:00:00.000') }Z`

      // let lc = v.stocks.reduce((a, v) => a === '' ? `"${v.code}"` : a.concat(`,`, `"${v.code}"`), '')
      this.setLoading(true)
      this.formatDates(v.dates)

      this.fetch({
        marketNo: v.market.no,
        begin: `${ moment( v.dates[0] ).format('YYYY-MM-DDT00:00:00.000') }Z`, // Clumsy but it's a pain to remove the offset...
        end: `${ moment( v.dates[1] ).format('YYYY-MM-DDT00:00:00.000') }Z`
      }).then(() => {
        this.fetchHoldings()
        this.setLoading(false)
      })
    },
    formatDates(dates) {
      this.formattedDateRange = moment( dates[0] ).isSame(moment( dates[1] )) ? `${ moment( dates[0] ).format('dddd, MMM D, YYYY')}` : `${ moment( dates[0] ).format('dddd, MMM D, YYYY')} to ${ moment( dates[1] ).format('dddd, MMM D, YYYY') }`
    },
    ...mapActions('dependencies', ['setLoading']),
    ...mapActions('trades', ['fetch']),
    ...mapActions({ // Credit: https://stackoverflow.com/questions/62407970/mapping-actions-from-a-nemespaced-vuex-modules-into-components-methods-works-onl
      fetchHoldings: 'holdings/fetch'
    })
  }
}

</script>