<template>
  <div>
    <div id="header">
      <div class="container">
        <img alt="Vue logo" src="./assets/logo.png">
      </div>
    </div>
    <div class="container">
      <StockFilter @changedDate="dateChanged" />
      <VolumesPie v-if="tradings" :volumes="tradings.volumeShares" />
      <PriceBar v-if="tradings" :changes="tradings.priceChanges" />
      <TradeCost v-if="tradings" :costs="tradings.tradeCosts" />
      <StocksLine />
      <StockTrades v-if="tradings" :tradings="tradings.stocksTraded" />
    </div>
  </div>
</template>

<script>
import gql from 'graphql-tag'
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
    StockFilter,
    VolumesPie,
    StocksLine,
    StockTrades,
    PriceBar,
    TradeCost
  },
  created() {
    //
  },
  mounted() {
    //
  },
  updated() {
    console.log('something was updated')
  },
  destroyed() {
    //
  },
  methods: {
    dateChanged(v) {      
      this.begin = `${ moment( v[0] ).format('YYYY-MM-DDT00:00:00.000') }Z` // Clumsy but it's a pain to remove the offset...
      this.end = `${ moment( v[1] ).format('YYYY-MM-DDT00:00:00.000') }Z`
      this.$apollo.queries.tradings.refresh()
    }
  },
  data() {
    return {
      tradings: null,
      begin: moment.utc().toISOString(),
      end: moment.utc().toISOString()
    }
  },
  apollo: {
    tradings: {
      query: gql`query Get($page: Int!, $begin: DateTime, $end: DateTime) {
          stockTradings(
            first: $page
            order: { date: DESC }
            where: { and: [{date: { gte: $begin }}, {date: { lte: $end }}] }
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
        }`,
      variables () {
        return {
          page: 50,
          begin: this.begin,
          end: this.end
        }
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

        const tradeCosts = stocksTraded.map(t => {
          return {
            name: t.security,
            x: t.volume,
            y: t.priceChange,
            z: t.volume * t.priceChange
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

        return {
          stocksTraded,
          volumeShares,
          priceChanges,
          tradeCosts
        }
      },
      error (error) {
        console.error(`We've got an error`, error)
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
