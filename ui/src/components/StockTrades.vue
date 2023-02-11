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
          icon-pack="fas"
          :sort-icon="sortIcon"
          :sort-icon-size="sortIconSize"
          :default-sort-direction="defaultSortDirection"
          striped
          hoverable
          detailed
          default-sort="percentage">
            
          <b-table-column field="stock.name" label="Security" sortable v-slot="props">
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

          <b-table-column field="volume" label="Volume" numeric sortable v-slot="props" width="12%">
            {{ formatNumber(props.row.volume) }}
          </b-table-column>

          <!--
          <b-table-column field="marketCapitalization" label="Market Cap" numeric sortable v-slot="props" width="12%">
            {{ formatMoney(props.row.marketCapitalization) }}
          </b-table-column>
          -->
            
          <b-table-column field="closingPrice" label="Price" numeric sortable v-slot="props">
            {{ formatMoney(props.row.closingPrice) }}
          </b-table-column>

          <b-table-column v-slot="props">
            <div style="height: 32px">
              <stocks-line :name="props.row.stock.name" :stocks="props.row.prices" :isPositive="props.row.prices.length && props.row.prices[props.row.prices.length - 1].ClosingPrice >= props.row.prices[0].ClosingPrice" :options="thumbLineOptions" />
            </div>
          </b-table-column>
            
          <b-table-column field="percentage" label="Change" numeric sortable v-slot="props">
            <span :class="(`tag is-medium is-fullwidth is-light ${(props.row.percentage > 0 ? 'is-success' : ( props.row.percentage < 0 ? 'is-danger' : ''))}`)">{{ formatPercentage(props.row.percentage) }}</span>
          </b-table-column>

          <template #detail="props">
            <article>
              <h5 class="title is-5">{{ props.row.stock.name }}</h5>
              
              <div class="columns">
                <div class="column is-three-quarters">
                  <div class="py-3">
                    <span class="tag is-dark is-medium">{{ formatMoney(props.row.lowestPrice) }}</span> <span class="tag is-info is-medium">{{ formatMoney(props.row.highestPrice) }}</span>
                  </div>
                  <stocks-line :name="props.row.stock.name" :stocks="props.row.prices" :options="detailOptions" />
                </div>
                <div class="column">
                  <view-company :data="props.row.stock.company" />
                </div>
              </div>
            </article>
          </template>

          <template #footer>
            <th></th>
            <th>Total</th>
            <th class="right-aligned">{{ formatTotalMarketCapitalization() }}</th>
            <th class="right-aligned">{{ formatTotalVolume() }}</th>
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
import ViewCompany from './ViewCompany.vue'

import config from '../config'
// import tableMixin from '../utils/tableMixin'
import utilMixin from '../utils/utilMixin'

export default {
  name: 'StockTrades',
  props: ['tradings', 'formattedDateRange'],
  components: {
    'stocks-line':StocksLine,
    'view-company': ViewCompany
  },
  mixins: [utilMixin],
  data() {
    return {
      defaultSortDirection: 'desc',
      sortIcon: 'arrow-up',
      sortIconSize: 'is-small',
      fileApiHost: config.fileApiHost,
      thumbLineOptions: {
        showDetail: false,
        showPositiveNegative: true,
        height: 48,
        width: 100
      },
      detailOptions: {
        showDetail: true,
        showPositiveNegative: false,
        height: null,
        width: null
      }
    }
  },
  methods: {
    formatTotalMarketCapitalization() {
      const totalMarketCapitalization = this.tradings.reduce((t, v) => {
        return t + v.marketCapitalization
      }, 0)

      return this.formatMoney(totalMarketCapitalization)
    },
    formatTotalVolume() {
      const totalVolumesTraded = this.tradings.reduce((t, v) => {
        return t + v.volume
      }, 0)

      return this.formatNumber(totalVolumesTraded)
    }
  }
}

</script>