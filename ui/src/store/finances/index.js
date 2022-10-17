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
            mutation: gql`mutation CreateFinancialReport($companyCode: String!, $companyName: String!, $period: Periodical!, $statementDate: DateTime!, $isAudited: Boolean!, $analytes: [StatementAnalyteInput], $logDescription: String!, $logged: DateTime!) {
              createFinancialReport(financialReport: {
                no: 0,
                company: {
                  code: $companyCode,
                  name: $companyName,
                  about: "",
                  announcements: [],
                  countryCode: "",
                  created: "1999-10-04",
                  founded: "1779-01-01",
                  industries: [],
                  industry: "",
                  totalEmployed: 0,
                  webSite: "",
                  wiki: ""
                },
                period: $period,
                statementDate: $statementDate,
                analytes: $analytes,
                isAudited: $isAudited,
                log: {
                  no: 0,
                  type: ANNOUNCEMENT,
                  event: INFORMATION,
                  details: $logDescription,
                  logged: $logged
                }
              }) {
                no
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
            }`,
            variables: {
              companyCode: report.company.code,
              companyName: report.company.name,
              period: report.period,
              statementDate: report.statementDate,
              isAudited: report.isAudited,
              logDescription: report.description,
              logged: report.log.logged,
              analytes: report.analytes
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
            mutation: gql`mutation UpdateFinancialReport($no: Long!, $companyCode: String!, $companyName: String!, $period: Periodical!, $statementDate: DateTime!, $isAudited: Boolean!, $analytes: [StatementAnalyteInput], $logDescription: String!, $logged: DateTime!) {
              updateFinancialReport(financialReport: {
                no: $no,
                company: {
                  code: $companyCode,
                  name: $companyName,
                  about: "",
                  announcements: [],
                  countryCode: "",
                  created: "1999-10-04",
                  founded: "1779-01-01",
                  industries: [],
                  industry: "",
                  totalEmployed: 0,
                  webSite: "",
                  wiki: ""
                },
                period: $period,
                statementDate: $statementDate,
                analytes: $analytes,
                isAudited: $isAudited,
                log: {
                  no: 0,
                  type: ANNOUNCEMENT,
                  event: INFORMATION,
                  details: $logDescription,
                  logged: $logged
                }
              }) {
                no
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
            }`,
            variables: {
              no: report.no,
              companyCode: report.company.code,
              companyName: report.company.name,
              period: report.period,
              statementDate: report.statementDate,
              isAudited: report.isAudited,
              logDescription: report.description,
              logged: report.log.logged,
              analytes: report.analytes
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