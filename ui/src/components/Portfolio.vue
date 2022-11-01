<template>
    <div class="panel is-info">
      <h4 class="panel-heading">
        My Portfolio: {{ formattedDateRange }}
      </h4>
      <div class="panel-block">
        <div class="column">
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

            <b-table-column v-slot="props">
              <template>
                <b-button
                  @click="removeMyPortfolio(props.row.id)"
                  size="is-small"
                  type="is-danger"
                  icon-pack="fas"
                  icon-right="trash" />
              </template>
            </b-table-column>

            <template #footer>
              <th>Total</th>
              <th></th>
              <th></th>
              <th class="right-aligned">{{ formatTotalPurchaseCost() }}</th>
              <th></th>
              <th class="right-aligned">{{ formatTotalCurrentCost() }}</th>
              <th class="right-aligned">{{ formatTotalGainOrLoss() }}</th>
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
import { mapGetters, mapActions } from 'vuex'

import utilMixin from '../utils/utilMixin'

export default ({
  props: ['formattedDateRange'],
  mixins: [utilMixin],
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
    ...mapActions(['removePortfolio']),
    removeMyPortfolio(id) {
      this.removePortfolio(id).then(() => {
        this.$buefy.toast.open({
          duration: 3000,
          message: `Successfully removed a stock holding`,
          type: 'is-success'
        })
      }).catch(() => {
        this.$buefy.toast.open({
          duration: 3000,
          message: `Something went wrong`,
          type: 'is-danger'
        })
      })
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
