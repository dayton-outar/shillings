import gql from 'graphql-tag'
import graphQlClient from '../apollo'

export default {
    async fetchSections({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
              sectionals {
                type,
                sections
              }
            }`
          })
      
      commit('setSections', response.data.sectionals)
    },
    async fetchAssays({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
              assays {
                sectional,
                assay
              }
            }`
          })
      
      commit('setAssays', response.data.assays)
    },
    getPortfolio({ commit }) {
      commit('setPortfolio', JSON.parse(localStorage.getItem('my-portfolio')) )
    },
    addPortfolio({ commit }, payload) {
      commit('addPortfolio', payload)
    },
    updatePortfolio({ commit }, payload) {
      commit('updatePortfolio', payload)
    },
    removePortfolio({ commit }, code) {
      commit('removePortfolio', code)
    },
    flushPortfolio({ commit }) {
      commit('flushPortfolio')
    }
}