<template>
  <section>
    <p>{{ tradings.length }} stocks traded</p>
    <b-table :data="tradings" :columns="columns"></b-table>
  </section>
</template>

<script>

export default {
  name: 'StockTrades',
  props: ['tradings'],
  data() {
    return {
      columns: [
          {
              field: 'security',
              label: 'Security'
          },
          {
              field: 'volume',
              label: 'Volume',
              numeric: true
          },
          {
              field: 'closingPrice',
              label: 'Closing Price',
              numeric: true
          },
          {
              field: 'priceChange',
              label: 'Price Change',
              numeric: true
          },
          {
              field: 'percentage',
              label: 'Percentage',
              numeric: true
          }
      ]
    }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>