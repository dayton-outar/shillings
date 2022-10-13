import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    indices: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, marketIndex) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateMarketIndex($input: CreateMarketIndexInput!) {
          createMarketIndex ( input: $input) {
            marketIndex {
              no,
              name,
              market {
                code,
                name
              }
            }
          }
        }`,
        variables: {
          input: {
            marketIndex: {
              no: marketIndex.no,
              name: marketIndex.name,
              market: {
                code: marketIndex.code
              }
            }
          }
        }
      })

      commit('add', {
        type: 'indices',
        pk: 'no',
        payload: response.data.createMarketIndex.marketIndex
      })

      return Promise.resolve(response.data.createMarketIndex.marketIndex)
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: MarketIndexFilterInput, $ordering: [MarketIndexSortInput!]) {
          marketIndices (
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
        type: 'indices',
        pk: 'no',
        payload: response.data.marketIndices
      })

      return Promise.resolve(response.data.marketIndices)
    },
    async update({ commit }, marketIndex) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateMarketIndex($input: UpdateMarketIndexInput!) {
          updateMarketIndex ( input: $input) {
            marketIndex {
              no,
              name,
              market {
                code,
                name
              }
            }
          }
        }`,
        variables: {
          input: {
            marketIndex: {
                no: marketIndex.no,
                name: marketIndex.name,
                market: {
                  code: marketIndex.code
                }
            }
          }
        }
      })

      commit('modify', {
        type: 'indices',
        pk: 'no',
        payload: response.data.updateMarketIndex.marketIndex
      })

      return Promise.resolve(response.data.updateIndustry.industry)
    },
    async delete({ commit }, marketIndex) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteMarketIndex($input: DeleteMarketIndexInput!) {
          deleteMarketIndex ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            no: marketIndex.no
          }
        }
      })

      if (response.data.deleteMarketIndex.boolean)
      {
        commit('remove', {
          type: 'indices',
          pk: 'no',
          payload: marketIndex
        })
      }
      
      return Promise.resolve(response.data.deleteMarketIndex.boolean)
    }
  }
}