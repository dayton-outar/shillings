<template>
  <div>
    <div class="columns">
      <div class="column is-full">
        <b-button 
          type="is-info"
          size="is-medium"
          icon-pack="fas"
          icon-left="plus"
          class="is-pulled-right"
          v-if="!isCreatePanelActive"
          @click.prevent="create">Add Investment</b-button>
          <portfolio-form v-if="isCreatePanelActive" @close="close" />
      </div>
    </div>
    <div class="panel is-light">
      <h4 class="panel-heading">
        My Portfolio: {{ formattedDateRange }}
      </h4>
      <div class="panel-block">
        <div class="column">
          <b-table 
            :data="holdings"
            icon-pack="fas"
            :sort-icon="sortIcon"
            :sort-icon-size="sortIconSize"
            :default-sort-direction="defaultSortDirection"
            :striped="true"
            :hoverable="true"
            detailed
            default-sort="variance">
            
            <b-table-column field="stock.name" label="Security" sortable v-slot="props">
              <stock-tag :data="props.row.stock" />
            </b-table-column>
            
            <b-table-column field="volume" label="Quantity" numeric sortable v-slot="props">
              {{ formatNumber(props.row.volume) }}
            </b-table-column>
            
            <b-table-column field="unitPrice" label="Purchase Price" numeric sortable v-slot="props">
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
            
            <b-table-column field="variance" label="Gain/Loss" numeric sortable v-slot="props">
              <span :class="(props.row.variance > 0 ? 'has-text-success-dark' : ( props.row.variance < 0 ? 'has-text-danger-dark' : ''))">{{ formatMoney(props.row.variance) }}</span>
            </b-table-column>

            <b-table-column v-slot="props" centered>
              <template>
                <b-button
                  @click="removeMyPortfolio(props.row.id)"
                  size="is-small"
                  type="is-danger"
                  icon-pack="fas"
                  icon-right="trash" />
              </template>
            </b-table-column>

            <template #detail="props">
              <article>
                <h5 class="title is-5">{{ props.row.stock.name }}</h5>
                <div class="columns">
                  <div class="column is-full">
                    <stocks-line :name="props.row.stock.name" :stocks="props.row.prices" :options="stocksLineOptions" />
                  </div>
                </div>
              </article>
            </template>

            <template #footer>
              <th>Total</th>
              <th></th>
              <th></th>
              <th></th>
              <th class="right-aligned">{{ formatTotalPurchaseCost() }}</th>
              <th></th>
              <th class="right-aligned">{{ formatTotalCurrentCost() }}</th>
              <th class="right-aligned">{{ formatTotalGainOrLoss() }}</th>
              <th></th>
            </template>

            <template #empty>
                <div class="has-text-centered is-size-4">
                  <p>Watch your stocks by adding them here.</p> 
                  <p><a @click.prevent="create">Click here to add first stock</a>.</p>
                </div>                
            </template>
            
          </b-table>
        </div>
        
      </div>
    </div>
  </div>    
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

import utilMixin from '../utils/utilMixin'

import PortfolioForm from './PortfolioForm.vue'
import StocksLine from './StocksLine.vue'
import StockTag from './StockTag.vue'

export default ({
  components: {
    'portfolio-form': PortfolioForm,
    'stocks-line':StocksLine,
    'stock-tag': StockTag
  },
  props: ['formattedDateRange'],
  mixins: [utilMixin],
  data() {
    return {
      defaultSortDirection: 'desc',
      sortIcon: 'arrow-up',
      sortIconSize: 'is-small',
      isCreatePanelActive: false,
      stocksLineOptions: {
        showDetail: true,
        showPositiveNegative: false,
        height: null,
        width: null
      }
    }
  },
  computed: {
    ...mapGetters(['holdings'])
  },
  methods: {
    ...mapActions('holdings', ['remove']),
    create() {
      this.isCreatePanelActive = true
    },
    close() {
      this.isCreatePanelActive = false
    },
    removeMyPortfolio(id) {
      this.remove(id).then(() => {
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
