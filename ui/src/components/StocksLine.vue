<template>
  <div id="stocks-line">
  </div>
</template>

<script>

export default {
  name: 'StocksLine',
  props: ['prices'],
  watch: {
    prices() {
      window.Highcharts.chart('stocks-line', {
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
          series: this.prices,
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