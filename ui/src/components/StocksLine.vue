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
              name: d.security,
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
                }
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