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
            
            <b-table-column label="Security" sortable v-slot="props">
              <article class="media">
                <figure class="media-left" v-if="props.row.stock.company">
                  <div class="image is-48x48">
                    <img class="is-rounded"
                          :src="(getLogo(props.row.stock.company.files) && getLogo(props.row.stock.company.files).length > 0 ? `${fileApiHost}?no=${getLogo(props.row.stock.company.files)[0].no}` : require(`../assets/no-image.png`))" alt="Company Logo" />
                  </div>
                </figure>
                <div class="media-content">
                  <p><span class="tag is-light"><small>{{ props.row.stock.stockType }}</small></span> | {{ props.row.stock.code }}</p>
                  <small v-if="props.row.stock.company">{{ props.row.stock.company.name}}</small>                  
                </div>
              </article>
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
              <th class="right-aligned">{{ formatTotalPurchaseCost() }}</th>
              <th></th>
              <th class="right-aligned">{{ formatTotalCurrentCost() }}</th>
              <th class="right-aligned">{{ formatTotalGainOrLoss() }}</th>
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
  </div>    
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

import config from '../config'
import utilMixin from '../utils/utilMixin'

import PortfolioForm from './PortfolioForm.vue'
import StocksLine from './StocksLine.vue'

export default ({
  components: {
    'portfolio-form': PortfolioForm,
    'stocks-line':StocksLine
  },
  props: ['formattedDateRange'],
  mixins: [utilMixin],
  data() {
    return {
      defaultSortDirection: 'desc',
      sortIcon: 'arrow-up',
      sortIconSize: 'is-small',
      fileApiHost: config.fileApiHost,
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
    close(e) {
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
