import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from './components/Dashboard.vue'
import FinancialReport from './components/FinancialReport.vue'
import Companies from './components/Companies.vue'
import Stocks from './components/Stocks.vue'
import Markets from './components/Markets.vue'
import MarketIndices from './components/MarketIndices.vue'
import Industries from './components/Industries.vue'

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
        },
        {
            path: '/stocks',
            name: 'stocks',
            component: Stocks,
            meta: { title: 'Shillings: Stocks' }
        },
        {
            path: '/markets',
            name: 'markets',
            component: Markets,
            meta: { title: 'Shillings: Markets' }
        },
        {
            path: '/indices',
            name: 'indices',
            component: MarketIndices,
            meta: { title: 'Shillings: Market Indices' }
        },
        {
            path: '/industries',
            name: 'industries',
            component: Industries,
            meta: { title: 'Shillings: Industries' }
        }
    ]
})