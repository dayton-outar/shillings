<template>
  <div v-if="stocks" :id="lineChartId"></div>
</template>

<script>
import { mapState } from 'vuex'
import { v4 as uuidv4 } from 'uuid'
import moment from 'moment'

export default {
  name: 'StocksLine',
  props: ['stocks', 'name', 'isDetail'],
  computed: {
    ...mapState(['companies']),
    preparedPrices() {
        if (this.isDetail) {
            const prices = this.stocks.map(p => [Date.UTC(moment(p.Date).toDate().getFullYear(), moment(p.Date).toDate().getMonth(), moment(p.Date).toDate().getDate()), p.ClosingPrice])
            return [{
              name: this.name,
              data: prices
            }]
        } else {
          return this.stocks.map(d => {
            return {
              name: d.stock.name,
              data: d.prices.map(p => [Date.UTC(moment(p.Date).toDate().getFullYear(), moment(p.Date).toDate().getMonth(), moment(p.Date).toDate().getDate()), p.ClosingPrice])
            }
          })
        }
    }
  },
  data() {
      return {
          lineChartId: `stocks-line-${ uuidv4()}`
      }
  },
  mounted() {
    if (this.isDetail) {
      this.renderLineChart()
    }
  },
  watch: {
    stocks() {
      this.renderLineChart()
    }
  },
  methods: {
      renderLineChart() {
          window.Highcharts.chart(`${ this.lineChartId }`, {
            title: {
                text: 'Stock Closing Price'
            },
            subtitle: {
                text: 'Source: www.jamstockex.com'
            },
            yAxis: {
                title: {
                    text: 'Closing Price'
                },
                labels: {
                  formatter() {
                    const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
                    return `${ cfi.format(this.value) }`
                  }
                },
            },
            xAxis: {
                type: 'datetime',
                title: {
                    text: 'Date'
                },
                labels: {
                  formatter: function () {
                    return window.Highcharts.dateFormat('%b %e, %Y', this.value);
                  }
                }
            },
            tooltip: {
                useHTML: true,
                formatter() {
                  const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })

                  return `<div style="color: ${this.point.color }">
                            <h6 class="title is-6">${ this.series.name }</h6>
                            <p class"is-size-5">${ moment.utc(this.point.x).format('MMM D, YYYY') }: <strong>${ cfi.format(this.point.y) }</strong></p>
                          </div>`
                },
                followPointer: true
            },
            legend: {
                enabled: false,
                //layout: 'vertical',
                //align: 'right',
                //verticalAlign: 'middle'
            },
            plotOptions: {
                series: {
                    label: {
                        connectorAllowed: false
                    },
                    //pointStart: 2010
                }
            },
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