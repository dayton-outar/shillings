import Vue from 'vue'
import Vuex from 'vuex'

import state from './state'
import getters from './getters'
import actions from './actions'
import mutations from './mutations'

import companies from './companies'
import industries from './industries'
import finances from './finances'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    state,
    getters,
    mutations,
    actions,
    modules: {
        finances,
        companies,
        industries
    }
})