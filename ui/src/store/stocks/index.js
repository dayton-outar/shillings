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
    async create({ commit }, stock) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateStock($input: CreateStockInput!) {
          createStock ( input: $input) {
            stock {
              no,
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
                files {
                  no,
                  type,
                  fileName,
                  contentType,
                  contentSize,
                  created
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
          input: {
            stock: {
              code: stock.code,
              name: stock.name,
              currency: stock.currency,
              stockType: stock.stockType,
              issuedShares: stock.issuedShares,
              outstandingShares: stock.outstandingShares,
              company: stock.company,
              isListed: stock.isListed,
              created: stock.created,
              indices: stock.indices
            }
          }
        }
      })

      commit('add', {
        type: 'stocks',
        pk: 'code',
        payload: response.data.createStock.stock
      })

      return Promise.resolve(response.data.createStock.stock)
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
              no,
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
                files {
                  no,
                  type,
                  fileName,
                  contentType,
                  contentSize,
                  created
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
    async update({ commit }, stock) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateStock($input: UpdateStockInput!) {
          updateStock ( input: $input) {
            stock {
              no,
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
                files {
                  no,
                  type,
                  fileName,
                  contentType,
                  contentSize,
                  created
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
          input: {
            stock: {
              no: stock.no,
              code: stock.code,
              name: stock.name,
              currency: stock.currency,
              stockType: stock.stockType,
              issuedShares: stock.issuedShares,
              outstandingShares: stock.outstandingShares,
              company: {
                code: stock.company.code,
                name: stock.company.name,
                about: '',
                totalEmployed: 0,
                wiki: '',
                webSite: '',
                founded: new Date(),
                countryCode: '',
                created: new Date(),
                files: stock.company.files
              },
              isListed: stock.isListed,
              created: stock.created,
              indices: stock.indices
            }
          }
        }
      })

      commit('modify', {
        type: 'stocks',
        pk: 'code',
        payload: response.data.updateStock.stock
      })

      return Promise.resolve(response.data.updateStock.stock)
    },
    async delete({ commit }, stock) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteStock($input: DeleteStockInput!) {
          deleteStock ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            code: stock.code
          }
        }
      })

      if (response.data.deleteStock.boolean)
      {
        commit('remove', {
          type: 'stocks',
          pk: 'code',
          payload: stock
        })
      }
      
      return Promise.resolve(response.data.deleteStock.boolean)
    }
  }
}