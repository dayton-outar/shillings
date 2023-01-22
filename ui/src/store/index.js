import Vue from 'vue'
import Vuex from 'vuex'

import getters from './getters'
import mutations from './mutations'

import companies from './companies'
import industries from './industries'
import markets from './markets'
import indices from './indices'
import stockIndices from './stockIndices'
import stocks from './stocks'
import finances from './finances'
import dividends from './dividends'
import rates from './rates'
import trades from './trades'
import earnings from './earnings'
import solvencies from './solvencies'
import holdings from './holdings'
import dependencies from './dependencies'
import auth from './auth'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    getters,
    mutations,
    modules: {
        dependencies,
        companies,
        industries,
        markets,
        indices,
        stockIndices,
        stocks,
        dividends,
        rates,
        finances,
        trades,
        earnings,
        solvencies,
        holdings,
        auth
    }
})