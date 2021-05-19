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
              label: 'Volume'
          },
          {
              field: 'closingPrice',
              label: 'Closing Price'
          },
          {
              field: 'priceChange',
              label: 'Price Change'
          },
          {
              field: 'percentage',
              label: 'Percentage'
          }
      ]
    }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>