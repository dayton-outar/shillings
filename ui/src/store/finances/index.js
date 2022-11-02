import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    financialReports: {
      pageInfo: {},
      totalCount: 0,
      nodes: []      
    }
  },
  mutations,
  actions: {
    async create({ commit }, report) {
        const response = await graphQlClient.mutate({
            mutation: gql`mutation CreateFinancialReport($input: CreateFinancialReportInput!) {
              createFinancialReport(input: $input) {
                financialReport{
                  no,
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
                  description,
                  period,
                  statementDate,
                  isAudited,
                  analytes {
                    no,
                    sequence,
                    description,
                    section,
                    type,
                    analyte,
                    amount
                  },
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
                financialReport: {
                  company: {
                    code: report.company.code,
                    name: report.company.name,
                    about: "",
                    announcements: [],
                    countryCode: "",
                    created: "1999-10-04",
                    founded: "1779-01-01",
                    industries: [],
                    totalEmployed: 0,
                    webSite: "",
                    wiki: ""
                  },
                  period: report.period,
                  statementDate: report.statementDate,
                  isAudited: report.isAudited,
                  analytes: report.analytes,
                  log: {
                    no: 0,
                    type: 'ANNOUNCEMENT',
                    event: 'INFORMATION',
                    details: report.description,
                    logged: report.log.logged
                  }
                }
              }
            }
          })
    
          response.data.createFinancialReport.analytes.forEach(el => {
            el.state = 'Closed';
          })

        commit('add', {
            type: 'financialReports',
            pk: 'no',
            payload: response.data.createFinancialReport
        })
    
        return Promise.resolve(response.data.updateCompany.company)
    },
    async fetch({ commit }, request) {
        const response = await graphQlClient.query({
            query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String, $filter: FinancialReportFilterInput, $ordering: [FinancialReportSortInput!]) {
              financialReports (
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
                }
                totalCount,
                nodes {
                  no,
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
                  description,
                  period,
                  statementDate,
                  isAudited,
                  analytes {
                    no,
                    sequence,
                    description,
                    section,
                    type,
                    analyte,
                    amount
                  },
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
            type: 'financialReports',
            pk: 'no',
            payload: response.data.financialReports
        })
        
        return Promise.resolve(response.data.financialReports)
    },
    async update({ commit }, report) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateFinancialReport($input: UpdateFinancialReportInput!) {
              updateFinancialReport(input: $input) {
                financialReport{
                  no,
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
                  description,
                  period,
                  statementDate,
                  isAudited,
                  analytes {
                    no,
                    sequence,
                    description,
                    section,
                    type,
                    analyte,
                    amount
                  },
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
                financialReport: {
                  no: report.no,
                  company: {
                    code: report.company.code,
                    name: report.company.name,
                    about: "",
                    announcements: [],
                    countryCode: "",
                    created: "1999-10-04",
                    founded: "1779-01-01",
                    industries: [],
                    totalEmployed: 0,
                    webSite: "",
                    wiki: ""
                  },
                  period: report.period,
                  statementDate: report.statementDate,
                  isAudited: report.isAudited,
                  analytes: report.analytes,
                  log: {
                    no: 0,
                    type: 'ANNOUNCEMENT',
                    event: 'INFORMATION',
                    details: report.description,
                    logged: report.log.logged
                  }
                }
              }
            }
          })
    
          response.data.updateFinancialReport.analytes.forEach(el => {
            el.state = 'Closed';
          })

        commit('modify', {
            type: 'financialReports',
            pk: 'no',
            payload: response.data.updateFinancialReport
        })
    
        return Promise.resolve(response.data.updateCompany.company)
    },
    async delete({ commit }, report) {
        const response = await graphQlClient.mutate({
            mutation: gql`mutation DeleteFinancialReport($input: DeleteFinancialReportInput!) {
              deleteFinancialReport ( input: $input) {
                boolean
              }
            }`,
            variables: {
              input: {
                no: report.no
              }
            }
          })

        if (response.data.deleteFinancialReport.boolean)
        {
            commit('remove', {
                type: 'financialReports',
                pk: 'no',
                payload: report
            })
        }
      
        return Promise.resolve(response.data.deleteFinancialReport.boolean)
    }
  }
}