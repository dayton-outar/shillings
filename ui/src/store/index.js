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
import trades from './trades'
import holdings from './holdings'
import dependencies from './dependencies'

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
        finances,
        trades,
        holdings
    }
})