<template>
    <div>
        <stocks-filter @filterChanged="filterChanged" />
        <portfolio-form />
        <portfolio :formattedDateRange="formattedDateRange" />
        <section v-if="totalTradings">
          <div class="mb-5">
            <b-collapse class="card" animation="slide" aria-id="volumeShares" :open="false">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="volumeShares">
                  <p class="card-header-title">Volume Shares: Pie Chart</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                  <b-message title="Volume Shares" type="is-info" aria-close-label="Close message">
                    <p>The volume shares visualizes the percentage division of the volume of stocks traded for the period.</p>
                    <p>All the divisions are divided by the total volume of shares traded within the period.</p>
                  </b-message>
                  <volumes-pie :volumes="volumeShares" />
                </div>
              </div>
            </b-collapse>
            <b-collapse class="card" animation="slide" aria-id="priceBar" :open="false">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="priceBar">
                  <p class="card-header-title">Price Changes: Bar Chart</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                  <b-message title="Price Changes" type="is-info" aria-close-label="Close message">
                    <p>This bar chart visualizes percentage change of the closing price from the opening price for the period.</p>
                    <p>Price changes can exceed over 100%, in which case will account for a dramatic gain or loss of your stock.</p>
                  </b-message>
                  <price-bar :changes="pricePercentages" />
                </div>
              </div>
            </b-collapse>
            <b-collapse class="card" animation="slide" aria-id="tradeCost" :open="false">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="tradeCost">
                  <p class="card-header-title">Trade Cost: Bubble Chart</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                  <b-message title="Trade Cost" type="is-info" aria-close-label="Close message">
                    <p>This bubble chart visualizes an approximation of the total money spent trading certain stocks for the period.</p>
                    <p>The biggest bubble means that most of the money was spent on that stock for the period.</p>
                  </b-message>
                  <trade-cost :costs="tradeCosts" />
                </div>
              </div>
            </b-collapse>
            <b-collapse class="card" animation="slide" aria-id="stocksClosingPrices" :open="false">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="stocksClosingPrices">
                  <p class="card-header-title">Closing Prices: Line Chart</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                  <b-message title="Closing Prices" type="is-info" aria-close-label="Close message">
                    <p>This line chart visualizes closing price each day for the period.</p>
                    <p>From a glance, you can see the stock with the highest closing price.</p>
                  </b-message>
                  <stocks-line :stocks="totalTradings" :isDetail="false" />
                </div>
              </div>
            </b-collapse>
          </div>
          <stock-trades :formattedDateRange="formattedDateRange" :tradings="totalTradings" />
        </section>
    </div>
</template>

<script>
import { mapState, mapGetters, mapActions } from 'vuex'
import moment from 'moment'

import StockFilter from './StockFilter.vue'
import VolumesPie from './VolumesPie.vue'
import StocksLine from './StocksLine.vue'
import StockTrades from './StockTrades.vue'
import PriceBar from './PriceBar.vue'
import TradeCost from './TradeCost.vue'
import PortfolioForm from './PortfolioForm.vue'
import Portfolio from './Portfolio.vue'

export default {
  components: {
    'stocks-filter': StockFilter,
    'portfolio': Portfolio,
    'portfolio-form': PortfolioForm,
    'volumes-pie': VolumesPie,
    'stocks-line':StocksLine,
    'stock-trades':StockTrades,
    'price-bar': PriceBar,
    'trade-cost': TradeCost
  },
  data() {
    return {
      formattedDateRange: '',
      isLoading: false
    }
  },
  computed: {
    ...mapState(['totalTradings']),
    ...mapGetters([
      'volumeShares',
      'tradeCosts',
      'pricePercentages'
      ])
  },
  beforeMount() {
    this.$emit('changeLoading', true)
    this.formatDates([new Date(), new Date()])

    this.$store.dispatch('fetchTotalStockTrades', {
        companyCode: '',
        begin: `${ moment.utc().format('YYYY-MM-DDT00:00:00.000') }Z`,
        end: `${ moment.utc().format('YYYY-MM-DDT00:00:00.000') }Z`
      }).then(() => {
        this.$store.dispatch('getPortfolio')
        this.$emit('changeLoading', false)
      })
  },
  methods: {
    filterChanged(v) {
      let lc = v.stocks.reduce((a, v) => a === '' ? `"${v.code}"` : a.concat(`,`, `"${v.code}"`), '')
      this.$emit('changeLoading', true)
      this.formatDates(v.dates)

      this.fetchTotalStockTrades({
        companyCode: lc,
        begin: `${ moment( v.dates[0] ).format('YYYY-MM-DDT00:00:00.000') }Z`, // Clumsy but it's a pain to remove the offset...
        end: `${ moment( v.dates[1] ).format('YYYY-MM-DDT00:00:00.000') }Z`
      }).then(() => {
        this.$store.dispatch('getPortfolio')
        this.$emit('changeLoading', false)
      })
    },
    formatDates(dates) {
      this.formattedDateRange = moment( dates[0] ).isSame(moment( dates[1] )) ? `${ moment( dates[0] ).format('dddd, MMM D, YYYY')}` : `${ moment( dates[0] ).format('dddd, MMM D, YYYY')} to ${ moment( dates[1] ).format('dddd, MMM D, YYYY') }`
    },
    ...mapActions(['fetchTotalStockTrades', 'addPortfolio', 'flushPortfolio'])
  }
}

</script>