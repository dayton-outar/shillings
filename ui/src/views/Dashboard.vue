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
        <b-tabs v-model="activeTab">
          <b-tab-item label="Stock Trades">            
            <stock-trades v-if="totalTrades" :formattedDateRange="formattedDateRange" :tradings="totalTrades" />
          </b-tab-item>
          <b-tab-item label="Companies' Earnings">
            <earnings :formattedDateRange="formattedDateRange" />
          </b-tab-item>
          <b-tab-item label="Companies' Solvency">
            <solvencies :formattedDateRange="formattedDateRange" />
          </b-tab-item>
          <!--
          <b-tab-item v-if="totalTrades" label="Volume Shares">
            <b-message title="Volume Shares" type="is-info" aria-close-label="Close message">
              <p>The volume shares visualizes the percentage division of the volume of stocks traded for the period.</p>
              <p>All the divisions are divided by the total volume of shares traded within the period.</p>
            </b-message>
            <volumes-pie :volumes="volumeShares" />
          </b-tab-item>
          <b-tab-item v-if="totalTrades" label="Price Changes">
            <b-message title="Price Changes" type="is-info" aria-close-label="Close message">
              <p>This bar chart visualizes percentage change of the closing price from the opening price for the period.</p>
              <p>Price changes can exceed over 100%, in which case will account for a dramatic gain or loss of your stock.</p>
            </b-message>
            <price-bar :changes="pricePercentages" />
          </b-tab-item>
          <b-tab-item v-if="totalTrades" label="Trade Cost">
            <b-message title="Trade Cost" type="is-info" aria-close-label="Close message">
              <p>This bubble chart visualizes an approximation of the total money spent trading certain stocks for the period.</p>
              <p>The biggest bubble means that most of the money was spent on that stock for the period.</p>
            </b-message>
            <trade-cost :costs="tradeCosts" />
          </b-tab-item>
          <b-tab-item v-if="totalTrades" label="Closing Prices">
            <b-message title="Closing Prices" type="is-info" aria-close-label="Close message">
              <p>This line chart visualizes closing price each day for the period.</p>
              <p>From a glance, you can see the stock with the highest closing price.</p>
            </b-message>
            <stocks-line :stocks="totalTrades" :options="{ isDetail: false}" />
          </b-tab-item>
          -->
        </b-tabs>
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
      },
      activeTab: 0
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