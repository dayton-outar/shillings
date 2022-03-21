import Vue from 'vue'
import Vuex from 'vuex'
import gql from 'graphql-tag'
import { v4 as uuidv4 } from 'uuid'

import graphQlClient from './apollo'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    state: {
      companies: [],
      stocks: [],
      totalTradings: null,
      portfolioHoldings: []
    },
    getters: {
        volumeShares(state) {
            const volumes = state.totalTradings.map(t => {
                return {
                  name: t.security,
                  y: t.volume,
                  sliced: false,
                  selected: false
                }
              })

            return volumes
        },
        tradeCosts(state) {
            const costs = state.totalTradings.map(t => {
                return {
                  name: t.security,
                  x: t.volume,
                  y: t.closingPrice,
                  z: t.volume * t.closingPrice
                }
              })
            
            return costs
        },
        pricePercentages(state) {
            const changes = state.totalTradings.map(t => {
              return {
                name: t.security,
                data: [ t.percentage ]
              }
            })
            
            return changes
        },
        holdings(state) {
          const ph = state.portfolioHoldings.map(h => {
            const itrade = state.totalTradings.find(t => t.code === h.security.code)
            let newPrice = itrade ? itrade.closingPrice : 0
            let oldCost = h.volume * h.unitPrice
            let newCost = itrade ? h.volume * itrade.closingPrice : 0

            return {
              id: h.id,
              security: h.security,
              volume: h.volume,
              unitPrice: h.unitPrice,
              purchaseCost: oldCost,
              currentPrice: newPrice,
              currentCost: newCost,
              variance: (newCost - oldCost)
            }
          })

          return ph
        }
    },
    mutations: {
        setCompanies(state, payload) {
          state.companies = payload
        },
        setStocks(state, payload) {
          state.stocks = payload
        },
        setTotalStockTrades(state, payload) {
          state.totalTradings = payload
        },
        setPortfolio(state, payload) {
          state.portfolioHoldings = payload
        },
        addPortfolio(state, payload) {
          const itrade = state.totalTradings.find(t => t.code === payload.security.code)
          let newPrice = itrade ? itrade.closingPrice : 0
          let oldCost = payload.volume * payload.unitPrice
          let newCost = itrade ? payload.volume * itrade.closingPrice : 0

          payload.id = uuidv4()
          payload.purchaseCost = oldCost
          payload.currentPrice = newPrice
          payload.currentCost = newCost
          payload.variance = (newCost - oldCost)

          state.portfolioHoldings.push(payload)
          localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        updatePortfolio(state, payload) {
          const ix = state.portfolioHoldings.findIndex(p => p.id === payload.id);
          if (ix > -1) {
            state.portfolioHoldings[ix] = payload;
          }
          localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        removePortfolio(state, id) {
          const ix = state.portfolioHoldings.findIndex(p => p.id === id);
          if (ix > -1) {
            state.portfolioHoldings.splice(ix, 1);
          }
          localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        flushPortfolio(state) {
          state.portfolioHoldings = []
          localStorage.removeItem('my-portfolio')
        }
    },
    actions: {
        async fetchCompanies({ commit }) {
          const response = await graphQlClient.query({
            query: gql`query {
              companies (
                first: 100
                order: { name: ASC}
                
              ) {
                nodes {
                  code,
                  name,
                  created
                }
              }
            }`
          })
          
          commit('setCompanies', response.data.companies.nodes)
        },
        async fetchStocks({ commit }) {
          const response = await graphQlClient.query({
            query: gql`query {
              stocks (
                first: 100
                order: { name: ASC}
                
              ) {
                nodes {
                  code,
                  name,
                  created
                }
              }
            }`
          })
          
          commit('setStocks', response.data.stocks.nodes)
        },
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
})