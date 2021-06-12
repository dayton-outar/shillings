<template>
    <section>
        <b-table 
          :data="holdings"
          :sort-icon="sortIcon"
          :sort-icon-size="sortIconSize"
          :default-sort-direction="defaultSortDirection"
          :striped="true"
          :hoverable="true"
          default-sort="variance">
          <b-table-column field="security.name" label="Security" sortable v-slot="props">
            {{ props.row.security.name }}
          </b-table-column>
          <b-table-column field="volume" label="Volume" numeric sortable v-slot="props">
            {{ formatVolume(props.row.volume) }}
          </b-table-column>
          <b-table-column field="unitPrice" label="Unit Price" numeric sortable v-slot="props">
            {{ formatMoney(props.row.unitPrice) }}
          </b-table-column>
          <b-table-column field="purchaseCost" label="Purchase Cost" numeric sortable v-slot="props">
            {{ formatMoney(props.row.purchaseCost) }}
          </b-table-column>
          <b-table-column field="currentPrice" label="Current Price" numeric sortable v-slot="props">
            {{ formatMoney(props.row.currentPrice) }}
          </b-table-column>
          <b-table-column field="currentCost" label="Current Cost" numeric sortable v-slot="props">
            {{ formatMoney(props.row.currentCost) }}
          </b-table-column>
          <b-table-column field="variance" label="Gain or Loss" numeric sortable v-slot="props">
            {{ formatMoney(props.row.variance) }}
          </b-table-column>

          <template #footer>
            <th>Total</th>
            <th></th>
            <th></th>
            <th class="right-aligned">{{ formatTotalPurchaseCost() }}</th>
            <th></th>
            <th class="right-aligned">{{ formatTotalCurrentCost() }}</th>
            <th class="right-aligned">{{ formatTotalGainOrLoss() }}</th>
          </template>
        </b-table>
    </section>
</template>

<script>
import { mapGetters } from 'vuex'

export default ({
    data() {
      return {
        defaultSortDirection: 'desc',
        sortIcon: 'arrow-up',
        sortIconSize: 'is-small'
      }
    },
    computed: {
        ...mapGetters(['holdings'])
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
      formatTotalPurchaseCost() {
        const totalPurchaseCost = this.holdings.reduce((t, v) => {
          return t + v.purchaseCost
        }, 0)

        return this.formatMoney(totalPurchaseCost)
      },
      formatTotalCurrentCost() {
        const totalCurrentCost = this.holdings.reduce((t, v) => {
          return t + v.currentCost
        }, 0)

        return this.formatMoney(totalCurrentCost)
      },
      formatTotalGainOrLoss() {
        const totalVariance = this.holdings.reduce((t, v) => {
          return t + v.variance
        }, 0)

        return this.formatMoney(totalVariance)
      }
    }
})

</script>
