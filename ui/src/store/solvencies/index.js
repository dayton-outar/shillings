import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    solvencies: []
  },
  mutations,
  actions: {
    async fetch({ commit }, request) {
        const response = await graphQlClient.query({
            query: gql`query Get($period: Periodical!, $begin: DateTime!, $end: DateTime!, $ordering: [SolvencySortInput!]) {
                solvencies(
                    period: $period,
                    begin: $begin,
                    end: $end,
                    order: $ordering
                ) {
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
                    statementDate,
                    assets,
                    current,
                    debt
                }
            }`,
            variables: {
                period: request.period,
                begin: request.begin,
                end: request.end,
                ordering: request.ordering
            }
        })

        commit('set', {
            type: 'solvencies',
            payload: response.data.solvencies
        })
      
        return Promise.resolve(response.data.solvencies)
    }
  }
}