import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    fullCompanies: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, company) {
        const response = await graphQlClient.mutate({
            mutation: gql`mutation CreateCompany($input: CreateCompanyInput!) {
              createCompany ( input: $input) {
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
                  logo {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  },
                  files {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  }
                }
              }
            }`,
            variables: {
              input: {
                company: {
                  code: company.code,
                  name: company.name,
                  about: company.about,
                  totalEmployed: company.totalEmployed,
                  wiki: company.wiki,
                  webSite: company.webSite,
                  founded: company.founded,
                  countryCode: company.countryCode,
                  created: company.created,
                  announcements: null,
                  industries: company.industries,
                  files: company.files
                },
                file: company.logo
              }
            }
          })

      commit('add', {
        type: 'fullCompanies',
        pk: 'code',
        payload: response.data.createCompany.company
      })

      return Promise.resolve(response.data.createCompany.company)
    },
    async fetch({ commit }, request) {
        const response = await graphQlClient.query({
            query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: CompanyFilterInput, $ordering: [CompanySortInput!]) {
              companies (
                first: $first,
                last: $last,
                after: $next,
                before: $previous,
                where: $filter,
                order: $ordering
                
              ) {
                pageInfo {
                  startCursor,
                  hasNextPage,
                  hasPreviousPage,
                  endCursor
                },
                totalCount,
                nodes {
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
                  logo {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  },
                  files {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
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
        type: 'fullCompanies',
        pk: 'code',
        payload: response.data.companies
      })

      return Promise.resolve(response.data.companies)
    },
    async update({ commit }, company) {
        const response = await graphQlClient.mutate({
            mutation: gql`mutation UpdateCompany($input: UpdateCompanyInput!) {
              updateCompany ( input: $input) {
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
                  logo {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  },
                  files {
                    no,
                    type,
                    fileName,
                    contentType,
                    contentSize,
                    created
                  }
                }
              }
            }`,
            variables: {
              input: {
                company: {
                  code: company.code,
                  name: company.name,
                  about: company.about,
                  totalEmployed: company.totalEmployed,
                  wiki: company.wiki,
                  webSite: company.webSite,
                  founded: company.founded,
                  countryCode: company.countryCode,
                  created: company.created,
                  announcements: null,
                  industries: company.industries,
                  files: company.files
                },
                file: company.logo
              }
            }
          })

      commit('modify', {
        type: 'fullCompanies',
        pk: 'code',
        payload: response.data.updateCompany.company
      })

      return Promise.resolve(response.data.updateCompany.company)
    },
    async delete({ commit }, company) {
        const response = await graphQlClient.mutate({
            mutation: gql`mutation DeleteCompany($input: DeleteCompanyInput!) {
              deleteCompany ( input: $input) {
                boolean
              }
            }`,
            variables: {
              input: {
                companyCode: company.code
              }
            }
          })

      if (response.data.deleteCompany.boolean)
      {
        commit('remove', {
          type: 'fullCompanies',
          pk: 'code',
          payload: company
        })
      }
      
      return Promise.resolve(response.data.deleteCompany.boolean)
    }
  }
}