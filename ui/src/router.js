import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from './components/Dashboard.vue'
import FinancialReport from './components/FinancialReport.vue'
import Companies from './components/Companies.vue'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'dashboard',
            component: Dashboard,
            meta: { title: 'Shillings: Dashboard' }
        },
        {
            path: '/finance-report',
            name: 'finance-report',
            component: FinancialReport,
            meta: { title: 'Shillings: Financial Report' }
        },
        {
            path: '/companies',
            name: 'companies',
            component: Companies,
            meta: { title: 'Shillings: Companies' }
        }
    ]
})