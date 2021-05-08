<template>
  <div>
    <div id="header">
      <div class="container">
        <img alt="Vue logo" src="./assets/logo.png">
      </div>
    </div>
    <div class="container">
      <StockFilter />
      <div class="columns">
        <div class="column">
          <VolumesPie />
        </div>
        <div class="column">
          <PriceBar />
        </div>
      </div>
      <StocksLine />
      <StockTrades />
    </div>
  </div>
</template>

<script>
import StockFilter from './components/StockFilter.vue'
import VolumesPie from './components/VolumesPie.vue'
import StocksLine from './components/StocksLine.vue'
import StockTrades from './components/StockTrades.vue'
import PriceBar from './components/PriceBar.vue'

export default {
  name: 'App',
  components: {
    StockFilter,
    VolumesPie,
    StocksLine,
    StockTrades,
    PriceBar
  },
  created() {
    console.log('App created')
  },
  mounted() {
    console.log('App mounted')
  },
  destroyed() {
    console.log('App destroyed')
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
