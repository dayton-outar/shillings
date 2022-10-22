import Vue from 'vue'
import Vuex from 'vuex'

import state from './state'
import getters from './getters'
import actions from './actions'
import mutations from './mutations'

import companies from './companies'
import industries from './industries'
import markets from './markets'
import indices from './indices'
import stockIndices from './stockIndices'
import stocks from './stocks'
import finances from './finances'
import dividends from './dividends'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    state,
    getters,
    mutations,
    actions,
    modules: {        
        companies,
        industries,
        markets,
        indices,
        stockIndices,
        stocks,
        dividends,
        finances
    }
})