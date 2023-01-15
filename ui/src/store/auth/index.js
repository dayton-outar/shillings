import gql from 'graphql-tag'
import graphQlClient from '../../apollo'

export default {
    namespaced: true,
    state: {
      profile: {
        isAuthenticated: false,
        token: ''
      }
    },
    mutations: {
        set(state, payload) {
            state.profile = payload
            localStorage.setItem('sh-auth', JSON.stringify(state.profile))
        }
    },
    actions: {
        async authenticate({ commit }, credentials) {
            const response = await graphQlClient.mutate({
                mutation: gql`mutation Get($input: TokenInput!) {
                    token(input: $input) {
                        string
                    }
                }`,
                variables: {
                    input: {
                        email: credentials.email,
                        password: credentials.password
                    }
                }
            })

            const pf = {
                isAuthenticated: true,
                token: response.data.token.string
            }

            commit('set', {
                type: 'profile',
                payload: pf
            })
        
            return Promise.resolve(pf)
        }
    }
}