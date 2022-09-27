import gql from 'graphql-tag'
import graphQlClient from './apollo'

export default {
    async createFinancialReport({ commit }, report) {
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
              name
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
      });

      commit('setFinancialReport', response.data.createFinancialReport)
    },
    async updateFinancialReport({ commit }, report) {
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
              name
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
      });

      commit('setFinancialReport', response.data.updateFinancialReport)
    },
    async fetchFinancialReports({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String) {
          financialReports (
            first: $first,
            last: $last,
            after: $next,
            before: $previous,
            order: { statementDate: DESC }
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
                name
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
          previous: request.previous
        }
      })
      
      //response.data.financialReports.nodes[0].analytes.forEach(el => {
      //  el.state = 'Closed';
      //});

      commit('setFinancialReports', response.data.financialReports)
      
      return Promise.resolve(response.data.financialReports)
    },
    async fetchCompanies({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
          companies (
            first: 100
            order: { name: ASC}
            
          ) {
            nodes {
              code,
              name,
              logo {
                no
              },
              files {
                no
              }
            }
          }
        }`
      })
      
      commit('setCompanies', response.data.companies.nodes)
    },
    async fetchMarkets({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
          markets (
            first: 100
            order: { name: ASC}
            
          ) {
            nodes {
              code,
              name,
              company {
                code,
                name
              }
            }
          }
        }`
      })
      
      commit('setMarkets', response.data.markets.nodes)
    },
    async fetchMarketIndices({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
          marketIndices {
            nodes {
              no,
              name,
              market {
                code,
                name,
                company {
                  code,
                  name,
                  about,
                  totalEmployed,
                  wiki,
                  webSite,
                  founded,
                  countryCode,
                  created
                }
              }
            }
          }
        }`
      })
      
      commit('setMarketIndices', response.data.marketIndices.nodes)
    },
    async fetchIndustries({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
          industries (
            first: 100,
            order: { name: ASC }
          )
          {
            nodes {
              no,
              name,
              wiki
            }
          }
        }`
      })
      
      commit('setIndustries', response.data.industries.nodes)
    },
    async fetchFullCompanies({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String) {
          companies (
            first: $first,
            last: $last,
            after: $next,
            before: $previous,
            order: { name: ASC}
            
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
          previous: request.previous
        }
      })
      
      commit('setFullCompanies', response.data.companies)
    },
    async updateCompany({ commit }, company) {
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

      commit('setCompany', response.data.updateCompany.company)
    },
    async createCompany({ commit }, company) {
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

      commit('addCompany', response.data.createCompany.company)
    },
    async deleteCompany({ commit }, companyCode) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation DeleteCompany($input: DeleteCompanyInput!) {
          deleteCompany ( input: $input) {
            boolean
          }
        }`,
        variables: {
          input: {
            companyCode: companyCode
          }
        }
      })

      if (response.data.deleteCompany.boolean) {
        commit('removeFullCompany', companyCode)
      }
    },
    async fetchStocks({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
          stocks (
            first: 100
            order: { name: ASC}
            
          ) {
            nodes {
              code,
              name,
              created
            }
          }
        }`
      })
      
      commit('setStocks', response.data.stocks.nodes)
    },
    async fetchTotalStockTrades({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($companyCode: String, $begin: DateTime!, $end: DateTime!) {
              totalTrades
              (
                companyCode: $companyCode
                begin: $begin
                end: $end
                order: { volume: DESC }
              ) {
                code,
                security,
                volume,
                openingDate,
                openingPrice,
                closingDate,
                closingPrice,
                lowestPrice,
                highestPrice,
                marketCapitalization,
                percentage,
                prices
              }
            }`,
          variables: {
              companyCode: request.companyCode,
              begin: request.begin,
              end: request.end
          }
      })

      const totalTrades = response.data.totalTrades.map(t => {
        try {
          t.prices = JSON.parse(t.prices)
        }
        catch (err) {
          console.log(err.message)
          console.log('Already parsed')
        }

        return t
      })

      commit('setTotalStockTrades', totalTrades)
    },
    async fetchFullStocks({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($first: Int, $last: Int, $next: String, $previous: String) {
          stocks (
            first: $first,
            last: $last,
            after: $next,
            before: $previous,
            order: { name: ASC }
          ) {
            pageInfo {
              startCursor,
              hasNextPage,
              hasPreviousPage,
              endCursor
            }
            totalCount,
            nodes {
              code,
              name,
              currency,
              stockType,
              issuedShares,
              outstandingShares,
              isListed,
              created,
              company {
                code,
                name,
                logo {
                  no
                },
                files {
                  no
                }
              },
              indices {
                no,
                name,
                market {
                  code,
                  name,
                  company {
                    code,
                    name,
                    about,
                    totalEmployed,
                    wiki,
                    webSite,
                    founded,
                    countryCode,
                    created
                  }
                }
              }
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
      
      commit('setFullStocks', response.data.stocks)
    },
    async updateStock({ commit }, stock) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation UpdateStock($input: UpdateStockInput!) {
          updateStock ( input: $input) {
            stock {
              code,
              name,
              currency,
              stockType,
              issuedShares,
              outstandingShares,
              isListed,
              created,
              company {
                code,
                name,
                logo {
                  no
                },
                files {
                  no
                }
              },
              indices {
                no,
                name
              }
            }
          }
        }`,
        variables: {
          input: {
            stock: {
              code: stock.code,
              name: stock.name,
              currency: stock.currency,
              stockType: stock.stockType,
              issuedShares: stock.issuedShares,
              outstandingShares: stock.outstandingShares,
              company: {
                code: stock.company.code,
                name: stock.company.name,
                about: '',
                totalEmployed: 0,
                wiki: '',
                webSite: '',
                founded: new Date(),
                countryCode: '',
                created: new Date(),
                logo: stock.company.logo,
                files: stock.company.files
              },
              isListed: stock.isListed,
              created: stock.created,
              indices: stock.indices
            }
          }
        }
      })

      commit('setStock', response.data.updateStock.stock)
    },
    async createStock({ commit }, stock) {
      const response = await graphQlClient.mutate({
        mutation: gql`mutation CreateStock($input: CreateStockInput!) {
          createStock ( input: $input) {
            stock {
              code,
              name,
              currency,
              stockType,
              issuedShares,
              outstandingShares,
              isListed,
              created,
              company {
                code,
                name,
                logo {
                  no
                },
                files {
                  no
                }
              },
              indices {
                no,
                name
              }
            }
          }
        }`,
        variables: {
          input: {
            stock: {
              code: stock.code,
              name: stock.name,
              currency: stock.currency,
              stockType: stock.stockType,
              issuedShares: stock.issuedShares,
              outstandingShares: stock.outstandingShares,
              company: stock.company,
              isListed: stock.isListed,
              created: stock.created,
              indices: stock.indices
            }
          }
        }
      })

      commit('setStock', response.data.createStock.stock)
    },
    async fetchSections({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
              sectionals {
                summaryTitle,
                type,
                sections
              }
            }`
          })
      
      commit('setSections', response.data.sectionals)
    },
    async fetchAssays({ commit }) {
      const response = await graphQlClient.query({
        query: gql`query {
              assays {
                sectional,
                assay
              }
            }`
          })
      
      commit('setAssays', response.data.assays)
    },
    flushFinancialReport() {
      this.commit('setFinancialReport', {
        no: null,
        company: {},
        description: null,
        period: null,
        statementDate: null,
        isAudited: null,
        analytes: []
      })
    },
    getPortfolio({ commit }) {
      commit('setPortfolio', JSON.parse(localStorage.getItem('my-portfolio')) )
    },
    addPortfolio({ commit }, payload) {
      commit('addPortfolio', payload)
    },
    updatePortfolio({ commit }, payload) {
      commit('updatePortfolio', payload)
    },
    removePortfolio({ commit }, code) {
      commit('removePortfolio', code)
    },
    flushPortfolio({ commit }) {
      commit('flushPortfolio')
    },
    addStatementItem({ commit }, payload) {
      commit('addStatementItem', payload)
    },
    updateStatementItem({ commit }, payload) {
      commit('updateStatementItem', payload)
    },
    removeStatementItem({ commit }, payload) {
      commit('removeStatementItem', payload)
    },
    closeStatementItem({ commit }, payload) {
      commit('closeStatementItem', payload)
    },
    openStatementItem({ commit }, payload) {
      commit('openStatementItem', payload)
    },
    prepStatementItems( { commit } ) {
      commit('preppedStatementItems')
    },
    validateStatementItems( { commit } ) {
      commit('validateStatementItems')
    },
    validateStatementItem( { commit }, payload ) {
      commit('validateStatementItem', payload)
    },
    updateFinancialReportCompany( { commit }, value) {
      commit('updateReportCompany', value)
    },
    saveFinancialReport({ commit }, payload) {
      commit('saveFinancialReport', payload)
    }
}