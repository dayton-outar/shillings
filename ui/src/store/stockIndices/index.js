import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    stockIndices: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, stockIndex) { // TODO: Fix
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateMarketIndex($input: CreateMarketIndexInput!) {
          createMarketIndex ( input: $input) {
            marketIndex {
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
                  created,
                  industries {
                    no,
                    name,
                    wiki
                  },
                  logo {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  },
                  files {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  }
                }
              }
            }
          }
        }`,
        variables: {
          input: {
            stockIndex: {
              no: stockIndex.no,
              name: stockIndex.name,
              market: stockIndex.market
            }
          }
        }
      })

      commit('add', {
        type: 'stockIndices',
        pk: 'no',
        payload: response.data.createStockIndex.stockIndices
      })

      return Promise.resolve(response.data.createMarketIndex.marketIndex)
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: StockIndexFilterInput, $ordering: [StockIndexSortInput!]) {
          stockIndices (
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
              marketIndex {
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
                    created,
                    industries {
                        no,
                        name,
                        wiki
                    },
                    logo {
                        no,
                        type,
                        fileName,
                        contentType,
                        contentSize,
                        created
                    },
                    files {
                        no,
                        type,
                        fileName,
                        contentType,
                        contentSize,
                        created
                    }
                    }
                }
              },
              value,
              valueChange,
              log {
                logged
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
        type: 'stockIndices',
        pk: 'no',
        payload: response.data.stockIndices
      })

      return Promise.resolve(response.data.marketIndices)
    },
    async update({ commit }, stockIndex) { // TODO: Fix
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateStockIndex($input: UpdateStockIndexInput!) {
          updateStockIndex ( input: $input) {
            marketIndex {
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
                  created,
                  industries {
                    no,
                    name,
                    wiki
                  },
                  logo {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  },
                  files {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  }
                }
              }
            }
          }
        }`,
        variables: {
          input: {
            stockIndex: {
                no: stockIndex.no,
                name: stockIndex.name,
                market: stockIndex.market
            }
          }
        }
      })

      commit('modify', {
        type: 'stockIndices',
        pk: 'no',
        payload: response.data.updateStockIndex.stockIndex
      })

      return Promise.resolve(response.data.updateStockIndex.stockIndex)
    },
    async delete({ commit }, stockIndex) { // TODO: Fix
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteMarketIndex($input: DeleteMarketIndexInput!) {
          deleteMarketIndex ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            no: stockIndex.no
          }
        }
      })

      if (response.data.deleteMarketIndex.boolean)
      {
        commit('remove', {
          type: 'stockIndices',
          pk: 'no',
          payload: stockIndex
        })
      }
      
      return Promise.resolve(response.data.deleteMarketIndex.boolean)
    }
  }
}