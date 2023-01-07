import Vue from 'vue'
import App from './App.vue'

import { store } from './store'
import router from './router'

// Install Buefy and reference it's stylesheet
import Buefy from 'buefy'
import '/node_modules/buefy/dist/buefy.css'
import '/node_modules/@fortawesome/fontawesome-free/css/all.css'

// Install Highcharts and extended modules
import Highcharts from 'highcharts'
import more from 'highcharts/highcharts-more'
more(Highcharts) // Credit to https://stackoverflow.com/questions/47116730/how-to-import-highcharts-more
window.Highcharts = Highcharts

Vue.config.productionTip = false

Vue.use(Buefy)

// const utilMixin = {
//   methods: {
//     formatNumber(volume) {
//       const nfi = new Intl.NumberFormat('en-US')
//       return nfi.format(volume)
//     },
//     formatMoney(amount) {
//       const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
//       return cfi.format(amount)
//     },
//     formatPercentage(percentage) {
//       return `${ percentage }%`
//     }
//   }
// }

new Vue({
  el: '#app',
  //mixins: [utilMixin],
  store,
  router,
  render:h => h(App),
})
