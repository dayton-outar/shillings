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
                  <p>{{ props.row.stock.code }}</p>
                  <small v-if="props.row.stock.company">{{ props.row.stock.company.name}}</small>                  
                </div>
              </article>
            </b-table-column>

            <!--
            <b-table-column field="highestPrice" numeric sortable v-slot="props">
              <span>
                <span class="tag is-dark">{{ formatMoney(props.row.lowestPrice) }}</span> <span class="tag is-info">{{ formatMoney(props.row.highestPrice) }}</span>
              </span>
            </b-table-column>
            -->

            <b-table-column field="marketCapitalization" label="Market Cap" numeric sortable v-slot="props" width="12%">
              {{ formatMoney(props.row.marketCapitalization) }}
            </b-table-column>
            
            <b-table-column field="closingPrice" label="Closing" numeric sortable v-slot="props">
              {{ formatMoney(props.row.closingPrice) }}
            </b-table-column>

            <b-table-column v-slot="props">
              <div style="height: 32px">
                <stocks-line :name="props.row.stock.name" :stocks="props.row.prices" :options="thumbLineOptions" />
              </div>
            </b-table-column>
            
            <b-table-column field="percentage" label="Percentage" numeric sortable v-slot="props">
              {{ formatPercentage(props.row.percentage) }}
            </b-table-column>

            <template #detail="props">
              <article>
                <h5 class="title is-5">{{ props.row.stock.name }}</h5>
                <div class="py-3">
                  <span class="tag is-dark is-medium">{{ formatMoney(props.row.lowestPrice) }}</span> <span class="tag is-info is-medium">{{ formatMoney(props.row.highestPrice) }}</span>
                </div>
                <stocks-line :name="props.row.stock.name" :stocks="props.row.prices" :options="detailOptions" />
                <!--
                <b-table
                  :data="props.row.prices"
                  striped
                  hoverable>
                  <b-table-column field="Date" label="Date" v-slot="details">
                    {{ formatDate(details.row.Date, 'ddd. MMM, D, YYYY') }}
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
              <th class="right-aligned">{{ formatTotalMarketCapitalization() }}</th>
              <th class="right-aligned">{{ formatTotalVolume() }}</th>
              <th></th>
              <th></th>
              <!--<th></th>-->
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

import config from '../config'
// import tableMixin from '../utils/tableMixin'
import utilMixin from '../utils/utilMixin'

export default {
  name: 'StockTrades',
  props: ['tradings', 'formattedDateRange'],
  components: {
    'stocks-line':StocksLine,
  },
  mixins: [utilMixin],
  data() {
    return {
      defaultSortDirection: 'desc',
      sortIcon: 'arrow-up',
      sortIconSize: 'is-small',
      fileApiHost: config.fileApiHost,
      thumbLineOptions: {
        isDetail: true,
        height: 48,
        width: 100
      },
      detailOptions: {
        isDetail: true,
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