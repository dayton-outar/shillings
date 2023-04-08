import { v4 as uuidv4 } from 'uuid'

export default {
    namespaced: true,
    state: {
        portfolio: []
    },
    mutations: {
        add(state, payload) {
            payload.id = uuidv4()

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
            if (!localStorage.getItem('my-portfolio')) {
                localStorage.setItem('my-portfolio', JSON.stringify([]))
            }
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