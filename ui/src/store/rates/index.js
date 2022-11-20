import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    interestRates: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, rate) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateInterestRate($input: CreateInterestRateInput!) {
          createInterestRate ( input: $input) {
            interestRate {
              no,
              countryCode,
              rate,
              date,
              log {
                no,
                type,
                event,
                details,
                logged
              }
            }
          }
        }`,
        variables: {
          input: {
            rate: {
              no: 0,
              rate: rate.rate,
              countryCode: rate.countryCode,
              date: rate.date,
              log: {
                no: 0,
                type: 'ANNOUNCEMENT',
                event: 'INFORMATION',
                details: `Created interest rate manually for ${rate.countryCode}`,
                logged: new Date()
              }
            }
          }
        }
      })

      commit('add', {
        type: 'interestRates',
        pk: 'no',
        payload: response.data.createInterestRate.interestRate
      })

      return Promise.resolve(response.data.createInterestRate.interestRate)
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: InterestRateFilterInput, $ordering: [InterestRateSortInput!]) {
          interestRates (
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
                countryCode,
                rate,
                date,
                log {
                    no,
                    type,
                    event,
                    details,
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
        type: 'interestRates',
        pk: 'no',
        payload: response.data.interestRates
      })

      return Promise.resolve(response.data.interestRates)
    },
    async update({ commit }, rate) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateInterestRate($input: UpdateInterestRateInput!) {
          updateInterestRate ( input: $input) {
            interestRate {
              no,
              countryCode,
              rate,
              date,
              log {
                no,
                type,
                event,
                details,
                logged
              }
            }
          }
        }`,
        variables: {
            input: {
                rate: {
                  no: 0,
                  rate: rate.rate,
                  countryCode: rate.countryCode,
                  date: rate.date,
                  log: {
                    no: rate.log.no,
                    type: 'ANNOUNCEMENT',
                    event: 'INFORMATION',
                    details: `Upated interest rate manually for ${rate.countryCode}`,
                    logged: new Date()
                  }
                }
            }
        }
      })

      commit('modify', {
        type: 'interestRates',
        pk: 'no',
        payload: response.data.interestRates.interestRate
      })

      return Promise.resolve(response.data.updateDividends.interestRate)
    },
    async delete({ commit }, rate) {      
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteDividend($input: DeleteInterestRateInput!) {
          deleteInterestRate ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            no: rate.no
          }
        }
      })

      if (response.data.deleteInterestRate.boolean)
      {
        commit('remove', {
          type: 'interestRates',
          pk: 'no',
          payload: rate
        })
      }
      
      return Promise.resolve(response.data.deleteInterestRate.boolean)
    }
  }
}