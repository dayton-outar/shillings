import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    stocks: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, market) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateMarket($input: CreateMarketInput!) {
          createMarket ( input: $input) {
            market {
                code,
                name
            }
          }
        }`,
        variables: {
          input: {
            market: {
                code: market.code,
                name: market.name
            }
          }
        }
      })

      commit('add', {
        type: 'stocks',
        pk: 'code',
        payload: response.data.createMarket.market
      })

      return Promise.resolve(response.data.createIndustry.industry)
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: StockFilterInput, $ordering: [StockSortInput!]) {
          stocks (
            first: $first,
            last: $last,
            after: $next,
            before: $previous,
            where: $filter,
            order: $ordering            
          )
          {
            pageInfo {
              startCursor,
              hasNextPage,
              hasPreviousPage,
              endCursor
            },
            totalCount,
            nodes {
              code,
              name,
              currency,
              stockType,
              issuedShares,
              outstandingShares,
              isListed,
              created,
              company {
                code,
                name,
                logo {
                  no
                },
                files {
                  no
                }
              },
              indices {
                no,
                name,
                market {
                  code,
                  name,
                  company {
                    code,
                    name,
                    about,
                    totalEmployed,
                    wiki,
                    webSite,
                    founded,
                    countryCode,
                    created
                  }
                }
              }
            }
          }
        }`,
        variables: {
          first: request.first,
          last: request.last,
          next: request.next,
          previous: request.previous,
          filter: request.filter,
          ordering: request.ordering
        }
      })
        
      commit('set', {
        type: 'stocks',
        pk: 'code',
        payload: response.data.stocks
      })

      return Promise.resolve(response.data.stocks)
    },
    async update({ commit }, market) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateMarket($input: UpdateMarketInput!) {
          updateMarket ( input: $input) {
            market {
                code,
                name
            }
          }
        }`,
        variables: {
          input: {
            market: {
                code: market.code,
                name: market.name
            }
          }
        }
      })

      commit('modify', {
        type: 'stocks',
        pk: 'code',
        payload: response.data.updateMarket.market
      })

      return Promise.resolve(response.data.updateIndustry.industry)
    },
    async delete({ commit }, market) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteMarket($input: DeleteMarketInput!) {
          deleteMarket ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            no: market.code
          }
        }
      })

      if (response.data.deleteMarket.boolean)
      {
        commit('remove', {
          type: 'stocks',
          pk: 'code',
          payload: market
        })
      }
      
      return Promise.resolve(response.data.deleteMarket.boolean)
    }
  }
}