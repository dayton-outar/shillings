import { v4 as uuidv4 } from 'uuid'

export default {
    namespaced: true,
    state: {
        portfolio: []
    },
    mutations: {
        add(state, payload) {
            const itrade = state.trades.totalTrades.find(t => t.code === payload.security.code)
            let newPrice = itrade ? itrade.closingPrice : 0
            let oldCost = payload.volume * payload.unitPrice
            let newCost = itrade ? payload.volume * itrade.closingPrice : 0

            payload.id = uuidv4()
            payload.purchaseCost = oldCost
            payload.currentPrice = newPrice
            payload.currentCost = newCost
            payload.variance = (newCost - oldCost)

            state.portfolio.push(payload)
            localStorage.setItem('my-portfolio', JSON.stringify(state.portfolio))
        },
        set(state, payload) {
            state.portfolio = payload
        },
        modify(state, payload) {
            const ix = state.portfolio.findIndex(p => p.id === payload.id);
            if (ix > -1) {
                state.portfolio[ix] = payload;
            }
            localStorage.setItem('my-portfolio', JSON.stringify(state.portfolio))
        },
        remove(state, id) {
            const ix = state.portfolio.findIndex(p => p.id === id);
            if (ix > -1) {
                state.portfolio.splice(ix, 1);
            }
            localStorage.setItem('my-portfolio', JSON.stringify(state.portfolio))
        },
        flush(state) {
            state.portfolio = []
            localStorage.removeItem('my-portfolio')
        }
    },
    actions: {
        fetch({ commit }) {
            commit('set', JSON.parse(localStorage.getItem('my-portfolio')))
        },
        add({ commit }, payload) {
            commit('add', payload)
        },
        update({ commit }, payload) {
            commit('modify', payload)
        },
        remove({ commit }, code) {
            commit('remove', code)
        },
        flush({ commit }) {
            commit('flush')
        }
    }
}