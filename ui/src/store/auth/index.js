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
            if (payload) {
                state.profile = payload
                localStorage.setItem('sh-auth', JSON.stringify(state.profile))
            }
        },
        flush(state) {
            state.portfolio = []
            localStorage.removeItem('sh-auth')
        }
    },
    actions: {
        fetch({ commit }) {
            commit('set', JSON.parse(localStorage.getItem('sh-auth')))
        },
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

            commit('set', pf)
        
            return Promise.resolve(pf)
        }
    }
}