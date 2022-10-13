import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    markets: {
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
        type: 'markets',
        pk: 'code',
        payload: response.data.createMarket.market
      })

      return Promise.resolve(response.data.createMarket.market)
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: MarketFilterInput, $ordering: [MarketSortInput!]) {
          markets (
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
            }
            totalCount,
            nodes {
              code,
              name,
              company {
                code,
                name
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
        type: 'markets',
        pk: 'code',
        payload: response.data.markets
      })

      return Promise.resolve(response.data.markets)
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
        type: 'markets',
        pk: 'code',
        payload: response.data.updateMarket.market
      })

      return Promise.resolve(response.data.updateMarket.market)
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
            code: market.code
          }
        }
      })

      if (response.data.deleteMarket.boolean)
      {
        commit('remove', {
          type: 'markets',
          pk: 'code',
          payload: market
        })
      }
      
      return Promise.resolve(response.data.deleteMarket.boolean)
    }
  }
}