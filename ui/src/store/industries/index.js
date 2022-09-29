import gql from 'graphql-tag'
import graphQlClient from '../../apollo'

export default {
  namespaced: true,
  state: {
    industries: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  getters: {},
  mutations: {
    add(state, payload) {
      state.industries.nodes.push(payload)
      state.industries.totalCount += 1
    },
    set(state, payload) {
        state.industries = payload
    },
    modify(state, payload) {
      var ix = state.industries.nodes.findIndex(i => i.no === payload.no)
      if (ix > -1) {
        state.industries.nodes[ix] = payload
      }
    },
    remove(state, no) {
      var ix = state.industries.nodes.findIndex(i => i.no === no)
      if (ix > -1) {
        state.industries.nodes.splice(ix, 1)
      }
    }
  },
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

      commit('add', response.data.createIndustry.industry)
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
        
      commit('set', response.data.industries)

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

      commit('modify', response.data.updateIndustry.industry)
    },
    async delete() { // 
    }
  }
}