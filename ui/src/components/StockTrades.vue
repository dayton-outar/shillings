<template>
  <div class="panel is-light">
    <h4 class="panel-heading">
        Market Summary: ... [Date]
    </h4>
    <div class="panel-block">
      <div class="column">
        <p>{{ tradings.length }} stocks traded</p>
          <b-table 
            :data="tradings"
            :sort-icon="sortIcon"
            :sort-icon-size="sortIconSize"
            :default-sort-direction="defaultSortDirection"
            :striped="true"
            :hoverable="true"
            default-sort="percentage">
            <b-table-column field="security" label="Security" sortable v-slot="props">
              {{ props.row.security }}
            </b-table-column>
            <b-table-column field="volume" label="Volume" numeric sortable v-slot="props">
              {{ formatVolume(props.row.volume) }}
            </b-table-column>
            <b-table-column field="openingPrice" label="Opening" numeric sortable v-slot="props">
              {{ formatMoney(props.row.openingPrice) }}
            </b-table-column>
            <b-table-column field="closingPrice" label="Closing" numeric sortable v-slot="props">
              {{ formatMoney(props.row.closingPrice) }}
            </b-table-column>
            <b-table-column field="percentage" label="Percentage" numeric sortable v-slot="props">
              {{ formatPercentage(props.row.percentage) }}
            </b-table-column>
          </b-table>
        </div>
      </div>
  </div>
</template>

<script>

export default {
  name: 'StockTrades',
  props: ['tradings'],
  data() {
    return {
      defaultSortDirection: 'desc',
      sortIcon: 'arrow-up',
      sortIconSize: 'is-small'
    }
  },
  methods: {
    formatVolume(volume) {
      const nfi = new Intl.NumberFormat('en-US')
      return nfi.format(volume)
    },
    formatMoney(amount) {
      const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
      return cfi.format(amount)
    },
    formatPercentage(percentage) {
      return `${ percentage }%`
    }
  }
}

</script>