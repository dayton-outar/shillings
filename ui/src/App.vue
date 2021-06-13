<template>
  <div>
    <div v-if="isLoading" class="preloader"></div>
    <div class="bg-dark-blue-gradient">
      <div class="container">
        <div class="py-5 px-4">
          <img alt="Jamaica Stock Exchange" src="./assets/logo.png">
        </div>
      </div>
    </div>
    <div class="bg-light-gray">
      <div class="container">        
        <div class="bg-white py-5 px-4">
          <stocks-filter @changedDate="dateChanged" />
          <portfolio-form />
          <portfolio :formattedDateRange="formattedDateRange" />
          <volumes-pie v-if="totalTradings" :volumes="volumeShares" />
          <price-bar v-if="tradings" :changes="pricePercentages" />
          <trade-cost v-if="totalTradings" :costs="tradeCosts" />
          <stocks-line v-if="totalTradings" :data="totalTradings" :isDetail="false" />
          <stock-trades v-if="totalTradings" :formattedDateRange="formattedDateRange" :tradings="totalTradings" />
        </div>      
      </div>
    </div>
    <footer class="footer has-background-dark has-text-primary-light">
      <div class="content has-text-centered">
        <p>&copy; Dayton Outar 2021</p>
      </div>
    </footer>
  </div>
</template>

<script>
import { mapState, mapGetters, mapActions } from 'vuex'
import moment from 'moment'

import StockFilter from './components/StockFilter.vue'
import VolumesPie from './components/VolumesPie.vue'
import StocksLine from './components/StocksLine.vue'
import StockTrades from './components/StockTrades.vue'
import PriceBar from './components/PriceBar.vue'
import TradeCost from './components/TradeCost.vue'
import PortfolioForm from './components/PortfolioForm.vue'
import Portfolio from './components/Portfolio.vue'

export default {
  name: 'App',
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
    ...mapState(['tradings', 'totalTradings']),
    ...mapGetters([
      'volumeShares',
      'tradeCosts',
      'pricePercentages'
      ])
  },
  beforeMount() {
    this.isLoading = true
    this.formatDates([new Date(), new Date()])

    this.$store.dispatch('fetchCompanies')
    this.$store.dispatch('fetchTotalStockTrades', {
        companyCode: '',
        begin: `${ moment.utc().format('YYYY-MM-DDT00:00:00.000') }Z`,
        end: `${ moment.utc().format('YYYY-MM-DDT00:00:00.000') }Z`
      }).then(() => {
        this.$store.dispatch('getPortfolio')
        this.isLoading = false
      })
  },
  methods: {
    dateChanged(v) {
      this.isLoading = true
      this.formatDates(v)

      this.fetchTotalStockTrades({
        companyCode: '',
        begin: `${ moment( v[0] ).format('YYYY-MM-DDT00:00:00.000') }Z`, // Clumsy but it's a pain to remove the offset...
        end: `${ moment( v[1] ).format('YYYY-MM-DDT00:00:00.000') }Z`
      }).then(() => {
        this.$store.dispatch('getPortfolio')
        this.isLoading = false
      })
    },
    formatDates(dates) {
      this.formattedDateRange = moment( dates[0] ).isSame(moment( dates[1] )) ? `${ moment( dates[0] ).format('dddd, MMM D, YYYY')}` : `${ moment( dates[0] ).format('dddd, MMM D, YYYY')} to ${ moment( dates[1] ).format('dddd, MMM D, YYYY') }`
    },
    ...mapActions(['fetchTotalStockTrades', 'addPortfolio', 'flushPortfolio'])
  }
}
</script>

<style>

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  background: #fafafa;
}

.preloader {
  position: fixed;
  left: 0px;
  top: 0px;
  width: 100%;
  height: 100%;
  z-index: 999999;
  background-color: #ffffff;
  background-position: center center;
  background-repeat: no-repeat;
  background-image: url(./assets/stocks-chart.png);
  animation: 1s beat 0.15s infinite alternate;
}

@keyframes beat {
  0% { transform: scale(1); }
	70% { transform: scale(1); }
  85% { transform: scale(1.3); }
  100% { transform: scale(1); }
}

.bg-white {
  background: #fff;
}

.bg-light-gray {
  background: #fafafa;
}

.bg-dark-blue-gradient {
    background: #013769;
    background: -moz-linear-gradient(left, #013769 0%, #0082c0 54%, #013769 100%);
    background: -webkit-gradient(linear, left top, right top, color-stop(0%,#013769), color-stop(54%,#0082c0), color-stop(100%,#013769));
    background: -webkit-linear-gradient(left, #013769 0%,#0082c0 54%,#013769 100%);
    background: -o-linear-gradient(left, #013769 0%,#0082c0 54%,#013769 100%);
    background: -ms-linear-gradient(left, #013769 0%,#0082c0 54%,#013769 100%);
    background: linear-gradient(to right, #013769 0%,#0082c0 54%,#013769 100%);
    -webkit-box-shadow: 0 20px 58px #013b6b inset;
    -ms-box-shadow: 0 20px 58px #013b6b inset;
    box-shadow: 0 20px 58px #013b6b inset;
}

.right-aligned {
    text-align: right !important;
}

</style>
