import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    dependencies: {
        sections: [],
        assays: []
    }
  },
  mutations,
  actions: {
    async fetch({ commit }) {
        const response = await graphQlClient.query({
            query: gql`query {
                dependencies {
                    sectionals {
                        type,
                        sections
                    },
                    assays {
                        sectional,
                        assay
                    }
                }
            }`
        })
        
        commit('set', {
            type: 'dependencies',
            payload: response.data.dependencies
        })

        return Promise.resolve(response.data.dependencies)
    }
  }
}