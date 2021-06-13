<template>
  <div :id="lineChartId"></div>
</template>

<script>
import { mapState } from 'vuex'
import { v4 as uuidv4 } from 'uuid'
import moment from 'moment'

export default {
  name: 'StocksLine',
  props: ['data', 'name', 'isDetail'],
  computed: {
    ...mapState(['companies']),
    preparedDates() {
        if (this.isDetail) {
            const closingDates = this.data.map(p => p.Date)
            return [{
              name: this.name,
              data: closingDates
            }]
        } else {
          return this.data.map(d => {
            return {
              name: d.security,
              data: d.prices.map(p => p.Date)
            }
          })
        }
    },
    preparedPrices() {
        if (this.isDetail) {
            const prices = this.data.map(p => [p.Date, p.ClosingPrice])
            return [{
              name: this.name,
              data: prices
            }]
        } else {
          return this.data.map(d => {
            return {
              name: d.security,
              data: d.prices.map(p => [moment(p.Date).toDate(), p.ClosingPrice])
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
    this.renderLineChart()
  },
  watch: {
    data() {
      this.renderLineChart()
    }
  },
  methods: {
      renderLineChart() {
          console.log(this.lineChartId, this.preparedPrices)
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
                dateTimeLabelFormats: {
                    month: '%e. %b',
                    year: '%b'
                },
                title: {
                    text: 'Date'
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