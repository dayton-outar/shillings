<template>
  <div v-if="changes" id="price-bar"></div>
</template>

<script>

export default {
  name: 'PriceBar',
  props: ['changes'],
  watch: {
    changes() {
      window.Highcharts.chart('price-bar', {
        chart: {
            type: 'column'
        },
        legend: {
            enabled: false
        },
        title: {
            text: 'Price Changes by Percentage'
        },
        subtitle: {
            text: 'Source: jamstockex.com'
        },
        xAxis: {
          title: {
            text: 'Stocks'
          }
        },
        yAxis: {
          title: {
            text: 'Percentage (%)'
          }
        },
        tooltip: {
            useHTML: true,
            formatter: function () {              
              return `<table>
                        <tr>
                          <td style="color:${this.series.color};padding:0">${this.series.name}: </td>
                          <td style="padding:0">&nbsp;<b>${ this.point.y }%</b></td>
                        </tr>
                      </table>`
            },
            followPointer: true
        },
        plotOptions: {
            column: {
              pointPadding: 0.2,
              borderWidth: 0
            }
        },
        series: this.changes,
        credits: {
            enabled: false
        }
      })
    }
  },
  mounted() {
    //
  },
  updated() {
    //
  }
}

</script>