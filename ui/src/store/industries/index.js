import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    industries: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, industry) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateIndustry($input: CreateIndustryInput!) {
          createIndustry ( input: $input) {
            industry {
              no,
              name,
              wiki
            }
          }
        }`,
        variables: {
          input: {
            industry: {
              no: industry.no,
              name: industry.name,
              wiki: industry.wiki
            }
          }
        }
      })

      commit('add', {
        type: 'industries',
        pk: 'no',
        payload: response.data.createIndustry.industry
      })
    },
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String) {
          industries (
            first: $first,
            last: $last,
            after: $next,
            before: $previous,
            order: { name: ASC }
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
              wiki
            }
          }
        }`,
        variables: {
          first: request.first,
          last: request.last,
          next: request.next,
          previous: request.previous
        }
      })
        
      commit('set', {
        type: 'industries',
        pk: 'no',
        payload: response.data.industries
      })

      return Promise.resolve(response.data.industries)
    },
    async update({ commit }, industry) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateIndustry($input: UpdateIndustryInput!) {
          updateIndustry ( input: $input) {
            industry {
              no,
              name,
              wiki
            }
          }
        }`,
        variables: {
          input: {
            industry: {
              no: industry.no,
              name: industry.name,
              wiki: industry.wiki
            }
          }
        }
      })

      commit('modify', {
        type: 'industries',
        pk: 'no',
        payload: response.data.updateIndustry.industry
      })
    },
    async delete() { // 
    }
  }
}