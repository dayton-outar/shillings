import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from './components/Dashboard.vue'
import FinancialReports from './components/FinancialReports.vue'
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
            path: '/finance-reports',
            name: 'finance-reports',
            component: FinancialReports,
            meta: { title: 'Shillings: Financial Reports' }
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