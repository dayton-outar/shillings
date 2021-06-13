<template>
  <div :id="lineChartId"></div>
</template>

<script>
import { v4 as uuidv4 } from 'uuid'

export default {
  name: 'StocksLine',
  props: ['data', 'isDetail'],
  computed: {
    preparedPrices() {
        if (this.isDetail) {
            const prices = this.data.map(p => p.ClosingPrice)
            return [{
              name: 'Yo',
              data: prices
            }]
        } else {
          return this.data.map(d => {
            return {
              name: d.security,
              data: d.prices.map(p => p.ClosingPrice)
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
                //accessibility: {
                //    rangeDescription: 'Range: 2010 to 2017'
                //}
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