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
      totalTradings: null
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
                    percentage
                  }
                }`,
              variables: {
                  companyCode: request.companyCode,
                  begin: request.begin,
                  end: request.end
              }
          })

          commit('setTotalStockTrades', response.data.totalTrades)
        }
    }
})