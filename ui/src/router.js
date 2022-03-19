import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from './components/Dashboard.vue'
import FinancialReport from './components/FinancialReport.vue'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'dashboard',
            component: Dashboard,
            meta: { title: 'JSE Stocks Tracker: Dashboard' }
        },
        {
            path: '/finance-report',
            name: 'finance-report',
            component: FinancialReport,
            meta: { title: 'JSE Stocks Tracker: Financial Report' }
        }
    ]
})