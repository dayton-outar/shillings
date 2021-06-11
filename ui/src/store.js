import Vue from 'vue';
import Vuex from 'vuex';
import gql from 'graphql-tag'

import graphQlClient from './apollo'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    state: {
      companies: [],
      tradings: null,
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
        closingPrices(state) {
          const prices = state.totalTradings.map(t => {
            return {
              name: t.security,
              data: t.prices.map(p => p.ClosingPrice)
            }
          })

          return prices
        },
        holdings(state) {
          const ph = state.portfolioHoldings.map(h => {
            const itrade = state.totalTradings.find(t => t.code === h.security.code)
            let newPrice = itrade ? itrade.closingPrice : 0
            let oldCost = h.volume * h.unitPrice
            let newCost = itrade ? h.volume * itrade.closingPrice : 0

            return {
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
        setStockTrades(state, payload) {
          state.tradings = payload
        },
        setTotalStockTrades(state, payload) {
          state.totalTradings = payload
        },
        addPortfolio(state, payload) {
          state.portfolioHoldings.push(payload)
          //localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        updatePortfolio(state, payload) {
          const ix = state.portfolioHoldings.findIndex((p => p.security.code == payload.security.code));
          if (ix > -1) {
            state.portfolioHoldings[ix] = payload;
          }
          //localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        removePortfolio(state, code) {
          const ix = state.portfolioHoldings.findIndex((p => p.security.code == code));
          if (ix > -1) {
            state.portfolioHoldings.splice(ix, 1);
          }
          //ocalStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        flushPortfolio(state) {
          state.portfolioHoldings = []
          //localStorage.removeItem('my-portfolio')
        }
    },
    actions: {
        async fetchCompanies({ commit }) {
          const response = await graphQlClient.query({
            query: gql`query {
              companies (
                first: 100
                order: { security: ASC}
                
              ) {
                nodes {
                  code,
                  security,
                  created
                }
              }
            }`
          })
          
          commit('setCompanies', response.data.companies.nodes)
        },
        async fetchStockTrades({ commit }, request) {
            const response = await graphQlClient.query({
                query: gql`query Get($page: Int!, $begin: DateTime, $end: DateTime) {
                    stockTradings(
                      first: $page
                      order: { date: DESC }
                      where: { and: [{date: { gte: $begin }}, {date: { lte: $end }}] }
                    ) {
                      edges {
                        cursor
                        node {
                          security {
                            code,
                            security
                          },
                          volume,
                          closingPrice,
                          priceChange,
                          percentage,
                          date
                        }
                      }
                      totalCount
                      pageInfo {
                        startCursor
                        endCursor
                        hasPreviousPage
                        hasNextPage
                      }
                    }
                  }`,
                variables: {
                    page: 50,
                    begin: request.begin,
                    end: request.end
                },
                error (error) {
                    console.error(`We've got an error`, error)
                }
            })

            const tradings = response.data.stockTradings.edges.map(e => {
                return {
                  security: e.node.security.security,
                  volume: e.node.volume,
                  closingPrice: e.node.closingPrice,
                  priceChange: e.node.priceChange,
                  percentage: e.node.percentage
                }
              })

            commit('setStockTrades', tradings)
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
              console.log(t.security, err.message, t.prices)
              t.prices = []
            }

            return t
          })

          commit('setTotalStockTrades', totalTrades)
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