import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    earnings: []
  },
  mutations,
  actions: {
    async fetch({ commit }, request) {
        const response = await graphQlClient.query({
            query: gql`query Get($period: Periodical!, $begin: DateTime!, $end: DateTime!, $ordering: [ReportedEarningsSortInput!]) {
                reportedEarnings(
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
                    revenues,
                    earnings,
                    margin
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
            type: 'earnings',
            payload: response.data.reportedEarnings
        })
      
        return Promise.resolve(response.data.reportedEarnings)
    }
  }
}