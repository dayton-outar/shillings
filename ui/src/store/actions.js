import gql from 'graphql-tag'
import graphQlClient from '../apollo'

export default {
    async fetchTotalStockTrades({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($companyCode: String, $begin: DateTime!, $end: DateTime!) {
              totalTrades
              (
                companyCode: $companyCode
                begin: $begin
                end: $end
                order: { volume: DESC }
              ) {
                code,
                security,
                volume,
                openingDate,
                openingPrice,
                closingDate,
                closingPrice,
                lowestPrice,
                highestPrice,
                marketCapitalization,
                percentage,
                prices
              }
            }`,
          variables: {
              companyCode: request.companyCode,
              begin: request.begin,
              end: request.end
          }
      })

      const totalTrades = response.data.totalTrades.map(t => {
        try {
          t.prices = JSON.parse(t.prices)
        }
        catch (err) {
          console.log(err.message)
          console.log('Already parsed')
        }

        return t
      })

      commit('setTotalStockTrades', totalTrades)
    },
    async fetchSections({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
              sectionals {
                summaryTitle,
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