import Vue from 'vue';
import Vuex from 'vuex';
import gql from 'graphql-tag'

import graphQlClient from './apollo'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    state: {
        tradings: null
    },
    getters: {
        volumeShares(state) {
            const volumes = state.tradings.map(t => {
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
            const costs = state.tradings.map(t => {
                return {
                  name: t.security,
                  x: t.volume,
                  y: t.closingPrice,
                  z: t.volume * t.closingPrice
                }
              })
            
            return costs
        },
        priceChanges(state) {
            const changes = state.tradings.reduce((a, c) => {
                let pos = a.map(e => e.name).indexOf(c.security)
                
                if (pos < 0) {
                  a.push({
                    name: c.security,
                    data: [ c.priceChange ]
                  });
                } else {
                  a[pos]['data'].push(c.priceChange)
                }
                
                return a
              }, [])
            
            return changes
        }
    },
    mutations: {
        setStockTrades(state, payload) {
            state.tradings = payload
        }
    },
    actions: {
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
        }
    }
})