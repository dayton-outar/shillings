<template>
  <div>
    <div id="header">
      <div class="container">
        <img alt="Vue logo" src="./assets/logo.png">
      </div>
    </div>
    <div class="container">
      <stocks-filter @changedDate="dateChanged" />
      <VolumesPie v-if="tradings" :volumes="volumeShares" />
      <PriceBar v-if="tradings" :changes="priceChanges" />
      <TradeCost v-if="tradings" :costs="tradeCosts" />
      <StocksLine />
      <StockTrades v-if="tradings" :tradings="tradings" />
    </div>
  </div>
</template>

<script>
import { mapState, mapGetters } from 'vuex'
import moment from 'moment'

import StockFilter from './components/StockFilter.vue'
import VolumesPie from './components/VolumesPie.vue'
import StocksLine from './components/StocksLine.vue'
import StockTrades from './components/StockTrades.vue'
import PriceBar from './components/PriceBar.vue'
import TradeCost from './components/TradeCost.vue'

export default {
  name: 'App',
  components: {
    'stocks-filter': StockFilter,
    VolumesPie,
    StocksLine,
    StockTrades,
    PriceBar,
    TradeCost
  },
  computed: {
    ...mapState(['tradings']),
    ...mapGetters([
      'volumeShares',
      'tradeCosts',
      'priceChanges',
      ])
  },
  beforeCreate() {
    this.$store.dispatch('fetchStockTrades', {
        begin: moment.utc().toISOString(),
        end: moment.utc().toISOString()
      })
  },
  methods: {
    dateChanged(v) {
      this.$store.dispatch('fetchStockTrades', {
        begin: `${ moment( v[0] ).format('YYYY-MM-DDT00:00:00.000') }Z`, // Clumsy but it's a pain to remove the offset...
        end: `${ moment( v[1] ).format('YYYY-MM-DDT00:00:00.000') }Z`
      })
    }
  }
}
</script>

<style>

#header {
    padding-top: 36px;
    padding-bottom: 32px;
    width: 100%;
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

</style>
