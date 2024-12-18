import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    dividends: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, dividend) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateDividends($input: CreateDividendsInput!) {
          createDividends ( input: $input) {
            dividend {
              no,
              stock {
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
              },
              currency,
              amount,
              recordDate,
              paymentDate
            }
          }
        }`,
        variables: {
          input: {
            dividend: {
              no: dividend.no,
              stock: dividend.stock,
              currency: dividend.currency,
              amount: dividend.amount,
              recordDate: dividend.recordDate,
              paymentDate: dividend.paymentDate,
              log: {
                no: 0,
                type: 'ANNOUNCEMENT',
                event: 'INFORMATION',
                details: `Created dividends manually for ${dividend.stock.name}`,
                logged: new Date()
              }
            }
          }
        }
      })

      commit('add', {
        type: 'dividends',
        pk: 'no',
        payload: response.data.createDividends.dividend
      })

      return Promise.resolve(response.data.createDividends.dividend)
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: DividendFilterInput, $ordering: [DividendSortInput!]) {
          dividends (
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
              stock {
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
              },
              currency,
              amount,
              recordDate,
              paymentDate
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
        type: 'dividends',
        pk: 'no',
        payload: response.data.dividends
      })

      return Promise.resolve(response.data.dividends)
    },
    async update({ commit }, dividend) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateDividends($input: UpdateDividendsInput!) {
          updateDividends ( input: $input) {
            dividend {
              no,
              stock {
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
              },
              currency,
              amount,
              recordDate,
              paymentDate
            }
          }
        }`,
        variables: {
          input: {
            dividend: {
              no: dividend.no,
              stock: dividend.stock,
              currency: dividend.currency,
              amount: dividend.amount,
              recordDate: dividend.recordDate,
              paymentDate: dividend.paymentDate,
              log: {
                no: 0,
                type: 'ANNOUNCEMENT',
                event: 'INFORMATION',
                details: '',
                logged: new Date()
              }
            }
          }
        }
      })

      commit('modify', {
        type: 'dividends',
        pk: 'no',
        payload: response.data.updateDividends.dividend
      })

      return Promise.resolve(response.data.updateDividends.dividend)
    },
    async delete({ commit }, dividend) {      
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteDividend($input: DeleteDividendsInput!) {
          deleteDividends ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            no: dividend.no
          }
        }
      })

      if (response.data.deleteDividends.boolean)
      {
        commit('remove', {
          type: 'dividends',
          pk: 'no',
          payload: dividend
        })
      }
      
      return Promise.resolve(response.data.deleteDividends.boolean)
    }
  }
}