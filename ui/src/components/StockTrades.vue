<template>
  <div class="panel is-light">
    <h4 class="panel-heading">
        Market Summary: {{ formattedDateRange }}
    </h4>
    <div class="panel-block">
      <div class="column">
        <p>{{ tradings.length }} stocks traded</p>
          <b-table 
            :data="tradings"
            :sort-icon="sortIcon"
            :sort-icon-size="sortIconSize"
            :default-sort-direction="defaultSortDirection"
            striped
            hoverable
            detailed
            default-sort="percentage">
            <b-table-column field="security" label="Security" sortable v-slot="props">
              {{ props.row.security }}
            </b-table-column>
            <b-table-column field="highestPrice" numeric sortable v-slot="props">
              <span>
                <span class="tag is-dark">{{ formatMoney(props.row.lowestPrice) }}</span> <span class="tag is-info">{{ formatMoney(props.row.highestPrice) }}</span>
              </span>
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

            <template #detail="props">
              <article>
                <h5 class="title is-5">{{ props.row.security }}</h5>
                <div class="py-3">
                  <span class="tag is-dark is-medium">{{ formatMoney(props.row.lowestPrice) }}</span> <span class="tag is-info is-medium">{{ formatMoney(props.row.highestPrice) }}</span>
                </div>
                <stocks-line :name="props.row.security" :stocks="props.row.prices" :isDetail="true" />
                <!--
                <b-table
                  :data="props.row.prices"
                  striped
                  hoverable>
                  <b-table-column field="Date" label="Date" v-slot="details">
                    {{ formatDate(details.row.Date) }}
                  </b-table-column>
                  <b-table-column field="ClosingPrices" label="ClosingPrice" numeric v-slot="details">
                    {{ formatMoney(details.row.ClosingPrice) }}
                  </b-table-column>
                </b-table>
                -->
              </article>
            </template>

            <template #footer>
              <th></th>
              <th>Total</th>
              <th></th>
              <th class="right-aligned">{{ formatTotalVolume() }}</th>
              <th></th>
              <th></th>
              <th></th>
            </template>

            <template #empty>
                <div class="has-text-centered">No records</div>
            </template>
            
          </b-table>
        </div>
      </div>
  </div>
</template>

<script>
import StocksLine from './StocksLine.vue'
import moment from 'moment'

export default {
  name: 'StockTrades',
  props: ['tradings', 'formattedDateRange'],
  components: {
    'stocks-line':StocksLine,
  },
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
    },
    formatDate(date) {
      return  `${ moment(date).format('ddd. MMM, D, YYYY') }`
    },
    formatTotalVolume() {
      const totalVolumesTraded = this.tradings.reduce((t, v) => {
        return t + v.volume
      }, 0)

      return this.formatVolume(totalVolumesTraded)
    }
  }
}

</script>