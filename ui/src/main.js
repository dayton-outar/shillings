import Vue from 'vue'
import App from './App.vue'

import { store } from './store'

// Install Buefy and reference it's stylesheet
import Buefy from 'buefy'
import '/node_modules/buefy/dist/buefy.css'
import '/node_modules/@mdi/font/css/materialdesignicons.min.css'

// Install Highcharts and extended modules
import Highcharts from 'highcharts'
import more from 'highcharts/highcharts-more'
more(Highcharts) // Credit to https://stackoverflow.com/questions/47116730/how-to-import-highcharts-more
window.Highcharts = Highcharts

Vue.config.productionTip = false

Vue.use(Buefy)

new Vue({
  el: '#app',
  store,
  render:h => h(App),
})
