<template>
  <div id="price-bar">
  </div>
</template>

<script>

export default {
  name: 'PriceBar',
  props: ['priceChanges'],
  mounted() {
    window.Highcharts.chart('price-bar', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Daily Price Changes'
        },
        subtitle: {
            text: 'Source: jamstockex.com'
        },
        xAxis: {
            categories: [
                'Tue',
                'Wed',
            ],
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Price (J$)'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: this.priceChanges
    })
    
  }
}

</script>