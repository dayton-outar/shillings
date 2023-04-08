import Vue from 'vue'
import Router from 'vue-router'
import Dashboard from './views/Dashboard.vue'
import FinancialReports from './components/FinancialReports.vue'
import Companies from './components/Companies.vue'
import Stocks from './components/Stocks.vue'
import Markets from './components/Markets.vue'
import MarketIndices from './components/MarketIndices.vue'
import Industries from './components/Industries.vue'
import InterestRates from './components/InterestRates.vue'
import ViewCompany from './components/ViewCompany.vue'
import Login from './components/Login.vue'

Vue.use(Router)

const router = new Router({
    routes: [
        {
            path: '/',
            name: 'dashboard',
            component: Dashboard,
            meta: { title: 'Dashboard' }
        },
        {
            path: '/login',
            name: 'login',
            component: Login,
            meta: { title: 'Login' }
        },
        {
            path: '/finance-reports',
            name: 'finance-reports',
            component: FinancialReports,
            meta: { title: 'Financial Reports' }
        },
        {
            path: '/companies',
            name: 'companies',
            component: Companies,
            meta: { title: 'Companies' }
        },
        {
            path: '/stocks',
            name: 'stocks',
            component: Stocks,
            meta: { title: 'Stocks' }
        },
        {
            path: '/markets',
            name: 'markets',
            component: Markets,
            meta: { title: 'Markets' }
        },
        {
            path: '/indices',
            name: 'indices',
            component: MarketIndices,
            meta: { title: 'Market Indices' }
        },
        {
            path: '/industries',
            name: 'industries',
            component: Industries,
            meta: { title: 'Industries' }
        },
        {
            path: '/rates',
            name: 'rates',
            component: InterestRates,
            meta: { title: 'Interest Rates' }
        },
        {
            path: '/about-company',
            name: 'about-company',
            component: ViewCompany,
            meta: { title: 'About Company' }
        }
    ]
})

router.beforeEach((to, from, next) => {
    let token = JSON.parse(localStorage.getItem('sh-auth')) // TODO: Is there a more robust security
    if (!token) {
        if (to.name == 'dashboard' || to.name == 'login') next()
        else next({ name: 'login' })
    }
    else next()
})

router.afterEach((to) => {
    gtag('config', window.GA_TRACKING_ID, {
        app_name: 'Shillings',
        send_page_view: true
      })
})

export default router