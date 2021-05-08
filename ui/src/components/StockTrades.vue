<template>
  <section>
    <p>{{ tradings.edges.length }} stocks traded</p>
    <b-table :data="tradings.edges" :columns="columns"></b-table>
  </section>
</template>

<script>
import gql from 'graphql-tag'

export default {
  name: 'StockTrades',
  data() {
    return {
      tradings: [],
      columns: [
          {
              field: 'node.security.security',
              label: 'Security'
          },
          {
              field: 'node.volume',
              label: 'Volume'
          },
          {
              field: 'node.priceChange',
              label: 'Price Change'
          },
          {
              field: 'node.percentage',
              label: 'Percentage'
          }
      ]
    }
  },
  apollo: {
    tradings: {
      query() {
        let r = gql`query {
          stockTradings(
            first: 50
            order: {date: DESC}
            where: { date: { eq: "2021-05-07T00:00:00.0000000Z" } }
          ) {
            edges {
              cursor
              node {
                security {
                  code,
                  security
                },
                volume,
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
        return data.stockTradings
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>