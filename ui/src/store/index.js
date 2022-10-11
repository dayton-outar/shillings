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
import stocks from './stocks'
import finances from './finances'

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
        stocks,
        finances
    }
})