<template>
  <div v-if="costs" id="trade-cost"></div>
</template>

<script>

export default {
  name: 'TradeCost',
  props: ['costs'],
  watch: {
    costs: function () {
      window.Highcharts.chart('trade-cost', {
        chart: {
            type: 'bubble',
            plotBorderWidth: 1,
            zoomType: 'xy'
        },
        legend: {
            enabled: false
        },
        title: {
            text: 'Trade Cost'
        },
        subtitle: {
            text: 'Source: <a href="https://www.jamstockex.com/">jamstockex.com</a>'
        },
        accessibility: {
            point: {
            valueDescriptionFormat: '{index}. {point.name}, volume: {point.x}, change: ${point.y}, cost: ${point.z}.'
            }
        },
        xAxis: {
            gridLineWidth: 1,
            title: {
            text: 'Volume'
            },
            labels: {
            format: '{value}'
            },
            plotLines: [{
            color: 'black',
            dashStyle: 'dot',
            width: 2,
            value: 65,
            label: {
                rotation: 0,
                y: 15,
                style: {
                fontStyle: 'italic'
                },
                text: '...'
            },
            zIndex: 3
            }],
            accessibility: {
            rangeDescription: 'Range: a to b.'
            }
        },
        yAxis: {
            startOnTick: false,
            endOnTick: false,
            title: {
            text: 'Closing Price'
            },
            labels: {
            format: '${value}'
            },
            maxPadding: 0.2,
            plotLines: [{
            color: 'black',
            dashStyle: 'dot',
            width: 2,
            value: 0,
            label: {
                align: 'right',
                style: {
                fontStyle: 'italic'
                },
                text: 'Stocks traded firm',
                x: -10
            },
                zIndex: 3
            }],
            accessibility: {
            rangeDescription: 'Range: $- to $-.'
            }
        },
        tooltip: {
            useHTML: true,
            formatter: function () {
            const nfi = new Intl.NumberFormat('en-US')
            const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })

            return `<table>
                <tr><th colspan="2"><h3>${this.point.name}</h3></th></tr>
                <tr><th style="text-align: right;">Volume:</th><td>${ nfi.format(this.point.x) }</td></tr>
                <tr><th style="text-align: right;">Closing Price:</th><td>${ cfi.format(this.point.y) }</td></tr>
                <tr><th style="text-align: right;">Cost:</th><td>${ cfi.format(this.point.z) }</td></tr>
            </table>`
            },
            followPointer: true
        },
        plotOptions: {
            series: {
            dataLabels: {
                enabled: true,
                format: '{point.name}'
            }
            }
        },
        series: [{
            data: this.costs
        }],
        credits: {
            enabled: false
        }
      })
    }
  },
  mounted() {
    console.log('mount costs')
  },
  updated() {
    console.log('update costs')
  }
}

</script>