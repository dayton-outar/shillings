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
          <VolumesPie v-bind:volumeShares="tradings.volumeShares" />
        </div>
        <div class="column">
          <PriceBar />
        </div>
      </div>
      <StocksLine />
      <StockTrades v-bind:tradings="tradings.stocksTraded" />
    </div>
  </div>
</template>

<script>
import gql from 'graphql-tag'

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
    //
  },
  mounted() {
    //
  },
  destroyed() {
    //
  },
  data() {
    return {
      tradings: {
        stocksTraded: []
      }
    }
  },
  apollo: {
    tradings: {
      query() {
        let r = gql`query {
          stockTradings(
            first: 100
            order: {date: DESC}
            where: { and: [{date: { gte: "2021-05-17T00:00:00.0000000Z" }}, {date: { lte: "2021-05-18T00:00:00.0000000Z" }}] }
          ) {
            edges {
              cursor
              node {
                security {
                  code,
                  security
                },
                volume,
                closingPrice,
                priceChange,
                percentage,
                date
              }
            }
            totalCount
            pageInfo {
              startCursor
              endCursor
              hasPreviousPage
              hasNextPage
            }
          }
        }`

        return r
      },
      update (data) {

        const stocksTraded = data.stockTradings.edges.map(e => {
          return {
            security: e.node.security.security,
            volume: e.node.volume,
            closingPrice: e.node.closingPrice,
            priceChange: e.node.priceChange,
            percentage: e.node.percentage
          }
        })

        const volumeShares = stocksTraded.map(t => {
          return {
            name: t.security,
            y: t.volume,
            sliced: false,
            selected: false
          }
        })

        const priceChanges = stocksTraded.reduce((a, c) => {
          let pos = a.map(e => e.name).indexOf(c.security)
          
          if (pos < 0) {
            a.push({
              name: c.security,
              data: [ c.priceChange ]
            });
          } else {
            a[pos]['data'].push(c.priceChange)
          }
          
          return a
        }, [])

        console.log( priceChanges );

        console.log(stocksTraded.length)

        return {
          stocksTraded,
          volumeShares
        }
      }
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
