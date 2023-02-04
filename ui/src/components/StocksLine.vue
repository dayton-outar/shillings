<template>
  <div v-if="stocks" :id="lineChartId"></div>
</template>

<script>
import { mapState } from 'vuex'
import { v4 as uuidv4 } from 'uuid'
import moment from 'moment'

import utilMixin from '../utils/utilMixin'

export default {
  name: 'StocksLine',
  props: ['stocks', 'name', 'isPositive', 'options'],
  mixins: [utilMixin],
  computed: {
    ...mapState(['companies']),
    preparedPrices() {
      const prices = this.stocks.map(p => [Date.UTC(moment(p.Date).toDate().getFullYear(), moment(p.Date).toDate().getMonth(), moment(p.Date).toDate().getDate()), p.ClosingPrice])
      return [{
        name: this.name,
        enableMouseTracking: this.options.showDetail,
        data: prices
      }]
    }
  },
  data() {
      return {
          lineChartId: `stocks-line-${ uuidv4()}`,
          positive: true
      }
  },
  mounted() {
    // if (this.options.showDetail) {
      
    // } 
    this.renderLineChart()
  },
  watch: {
    stocks() {
      this.renderLineChart()
    }
  },
  methods: {
    renderLineChart() {
      const chartHeight = this.options.height
      const chartWidth = this.options.width
      const showDetails = this.options.showDetail
      const fm = this.formatMoney
      const defaultPlotOptions = {
        series: {
          label: {
            connectorAllowed: false
          }
        }
      }
      const negPosPlotOpions = {
        line: {
          marker: {
            enabled: showDetails
          },
          color: this.isPositive ? 'green' : 'red'
        },
        series: {
          label: {
            connectorAllowed: false
          }
        }
      }
      
      const linePlotOptions = this.options.showPositiveNegative ? negPosPlotOpions : defaultPlotOptions

      window.Highcharts.chart(`${ this.lineChartId }`, {
        chart: {
          height: chartHeight,
          width: chartWidth,
          backgroundColor: 'transparent'
        },
        title: {
          text: null // 'Stock Closing Price'
        },
        subtitle: {
          text: null // 'Source: www.jamstockex.com'
        },
        yAxis: {
          visible: showDetails,
          title: {
            text: 'Closing Price'
          },
          labels: {
            enabled: showDetails,
            formatter() {
              return `${ fm(this.value) }`
            }
          },
        },
        xAxis: {
          visible: showDetails,
          type: 'datetime',
          title: {
            text: 'Date'
          },
          labels: {
            enabled: showDetails,
            formatter: function () {
              return window.Highcharts.dateFormat('%b %e, %Y', this.value);
            }
          }
        },
        tooltip: {
          enabled: showDetails,
          useHTML: true,
          formatter() {
            return `<div style="color: ${this.point.color }">
                      <h6 class="title is-6">${ this.series.name }</h6>
                      <p class"is-size-5">${ moment.utc(this.point.x).format('MMM D, YYYY') }: <strong>${ fm(this.point.y) }</strong></p>
                    </div>`
          },
          followPointer: showDetails
        },
        legend: {
          enabled: false,
          // layout: 'vertical',
          // align: 'right',
          // verticalAlign: 'middle'
        },
        plotOptions: linePlotOptions,
        series: this.preparedPrices,
        responsive: {
          rules: [{
            condition: {
              maxWidth: 500
            },
            chartOptions: {
              legend: {
                  layout: 'horizontal',
                  align: 'center',
                  verticalAlign: 'bottom'
              }
            }
          }]
        },
        credits: {
            enabled: false
        }
      })
    }
  }
}

</script>