import Vue from 'vue'
import Vuex from 'vuex'
import gql from 'graphql-tag'
import { v4 as uuidv4 } from 'uuid'

import graphQlClient from './apollo'

Vue.use(Vuex)

export const store = new Vuex.Store({
    strict: true,
    state: {
      companies: [],
      fullCompanies: [],
      marketIndices: [],
      industries: [],
      markets: [],
      stocks: [],
      fullStocks: [],
      totalTradings: null,
      portfolioHoldings: [],
      sections: [],
      assays: [],
      financialReports: [],
      statementItems: [],
      isItemsValid: true
    },
    getters: {
        volumeShares(state) {
            const volumes = state.totalTradings.map(t => {
                return {
                  name: t.security,
                  y: t.volume,
                  sliced: false,
                  selected: false
                }
              })

            return volumes
        },
        tradeCosts(state) {
            const costs = state.totalTradings.map(t => {
                return {
                  name: t.security,
                  x: t.volume,
                  y: t.closingPrice,
                  z: t.volume * t.closingPrice
                }
              })
            
            return costs
        },
        pricePercentages(state) {
            const changes = state.totalTradings.map(t => {
              return {
                name: t.security,
                data: [ t.percentage ]
              }
            })
            
            return changes
        },
        holdings(state) {
          const ph = state.portfolioHoldings.map(h => {
            const itrade = state.totalTradings.find(t => t.code === h.security.code)
            let newPrice = itrade ? itrade.closingPrice : 0
            let oldCost = h.volume * h.unitPrice
            let newCost = itrade ? h.volume * itrade.closingPrice : 0

            return {
              id: h.id,
              security: h.security,
              volume: h.volume,
              unitPrice: h.unitPrice,
              purchaseCost: oldCost,
              currentPrice: newPrice,
              currentCost: newCost,
              variance: (newCost - oldCost)
            }
          })

          return ph
        }
    },
    mutations: {
        setCompany(state, payload) {         
          let ix = state.fullCompanies.nodes.findIndex(s => s.code === payload.code)
          state.fullCompanies.nodes[ix] = payload
        },
        addCompany(state, payload) {         
          state.fullCompanies.nodes.push(payload)
        },
        setCompanies(state, payload) {
          state.companies = payload
        },
        setFullCompanies(state, payload) {
          state.fullCompanies = payload
        },
        removeFullCompany(state, code) {
          var ix = state.fullCompanies.nodes.findIndex(c => c.code === code);
          if (ix > -1) {
            state.fullCompanies.nodes.splice(ix, 1);
          }
        },
        setMarkets(state, payload) {
          state.markets = payload
        },
        setMarketIndices(state, payload) {
          state.marketIndices = payload
        },
        setIndustries(state, payload) {
          state.industries = payload
        },
        setStock(state, payload) {
          var ix = state.stocks.findIndex(s => s.code === payload.code);
          state.stocks[ix] = payload;
        },
        setStocks(state, payload) {
          state.stocks = payload
        },
        setFullStocks(state, payload) {
          state.fullStocks = payload
        },
        setSections(state, payload) {
          state.sections = payload
        },
        setAssays(state, payload) {
          state.assays = payload
        },
        setTotalStockTrades(state, payload) {
          state.totalTradings = payload
        },
        setPortfolio(state, payload) {
          state.portfolioHoldings = payload
        },
        setFinancialReports(state, payload) {
          state.financialReports = payload.nodes
        },
        setFinancialReport(state, payload) {
          var ix = state.financialReports.findIndex(f => f.no === payload.no);
          state.financialReports[ix] = payload
        },
        openStatementItem(state, payload) {
          const item = state.financialReports.analytes.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          if (item) {
            item.state = 'Opened';
            item.vDesc = {
              type: '',
              message: ''
            };
            item.vSec = {
              type: '',
              message: ''
            };
            item.vAnl = {
              type: '',
              message: ''
            };
            item.vAmt = {
              type: '',
              message: ''
            };
          }
        },
        closeStatementItem(state, payload) {
          const item = state.financialReports.analytes.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);

          if (item) { // TODO: Need refactoring
            
            if (state.isItemsValid) {
              item.state = 'Closed';
            }
          }
        },
        addStatementItem(state, payload) {
          state.financialReports.analytes.push(payload)

          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReports.analytes) )
        },
        updateStatementItem(state, payload) {
          const ix = state.financialReports.analytes.findIndex(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          // if (payload.key === 'amount') {
          //     payload.value = payload.value.toString().replace(/[^0-9.-]+/g,'');
          // }
          state.financialReports.analytes[ix][payload.key] = payload.value;

          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReports.analytes) )
        },
        removeStatementItem(state, payload) {
          const ix = state.financialReports.analytes.findIndex(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          if (ix > -1) {
            state.financialReports.analytes.splice(ix, 1);
            
            for (let i = ix; i < state.financialReports.analytes.length; i++) {
              if (state.financialReports.analytes[i].type === payload.type) {
                state.financialReports.analytes[i].no = (state.financialReports.analytes[i].no - 1);
              }              
            }
          }

          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReports.analytes) )
        },
        preppedStatementItems(state) {
          state.financialReports.analytes.map(i => {
              delete i.vDesc;
              delete i.vSec;
              delete i.vAnl;
              delete i.vAmt;

              i.amount = parseFloat(i.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
              
              return i;
          })
        },
        validateStatementItem(state, payload) {
          const item = state.financialReports.analytes.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);

          if (!item.description) {
            item.vDesc.type = 'is-danger'
            item.vDesc.message = 'Please enter description'

            state.isItemsValid = false
          } else {
            item.vDesc.type = ''
            item.vDesc.message = ''
          }

          if (!item.section) {
            item.vSec.type = 'is-danger'
            item.vSec.message = 'Please choose section'

            state.isItemsValid = false
          } else {
            item.vSec.type = ''
            item.vSec.message = ''
          }

          if (!item.analyte.length) {
            item.vAnl.type = 'is-danger'
            item.vAnl.message = 'Please choose categories'

            state.isItemsValid = false
          } else {
            item.vAnl.type = ''
            item.vAnl.message = ''
          }

          let amt = parseFloat(item.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
          if (!amt) {
            item.vAmt.type = 'is-danger'
            item.vAmt.message = 'Please enter amount'

            state.isItemsValid = false
          } else {
            item.vAmt.type = ''
            item.vAmt.message = ''
          }
        },
        validateStatementItems(state) {
          state.isItemsValid = true

          state.financialReports.analytes.forEach(i => {
            if (i.state == 'Opened') {
              if (!i.description) { // TODO: Need refactoring
                // HACK: These fields do not exist on the graphql model
                i.vDesc.type = 'is-danger'
                i.vDesc.message = 'Please enter description'

                state.isItemsValid = false
              } else {
                i.vDesc.type = ''
                i.vDesc.message = ''
              }

              if (!i.section) {
                i.vSec.type = 'is-danger'
                i.vSec.message = 'Please choose section'

                state.isItemsValid = false
              } else {
                i.vSec.type = ''
                i.vSec.message = ''
              }

              if (!i.analyte.length) {
                i.vAnl.type = 'is-danger'
                i.vAnl.message = 'Please choose categories'

                state.isItemsValid = false
              } else {
                i.vAnl.type = ''
                i.vAnl.message = ''
              }

              let amt = parseFloat(i.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
              if (!amt) {
                i.vAmt.type = 'is-danger'
                i.vAmt.message = 'Please enter amount'

                state.isItemsValid = false
              } else {
                i.vAmt.type = ''
                i.vAmt.message = ''
              }
            }
          })
        },
        addPortfolio(state, payload) {
          const itrade = state.totalTradings.find(t => t.code === payload.security.code)
          let newPrice = itrade ? itrade.closingPrice : 0
          let oldCost = payload.volume * payload.unitPrice
          let newCost = itrade ? payload.volume * itrade.closingPrice : 0

          payload.id = uuidv4()
          payload.purchaseCost = oldCost
          payload.currentPrice = newPrice
          payload.currentCost = newCost
          payload.variance = (newCost - oldCost)

          state.portfolioHoldings.push(payload)
          localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        updatePortfolio(state, payload) {
          const ix = state.portfolioHoldings.findIndex(p => p.id === payload.id);
          if (ix > -1) {
            state.portfolioHoldings[ix] = payload;
          }
          localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        removePortfolio(state, id) {
          const ix = state.portfolioHoldings.findIndex(p => p.id === id);
          if (ix > -1) {
            state.portfolioHoldings.splice(ix, 1);
          }
          localStorage.setItem('my-portfolio', JSON.stringify(state.portfolioHoldings) )
        },
        flushPortfolio(state) {
          state.portfolioHoldings = []
          localStorage.removeItem('my-portfolio')
        },
        updateReportCompany(state, payload) {
          state.financialReports.company = payload
        },
        updateReportPeriod(state, payload) {
          state.financialReports.period = payload
        },
        updateReportDate(state, payload) {
          state.financialReports.statementDate = payload.toJSON()
        },
        updateReportIsAudit(state, payload) {
          state.financialReports.isAudited = payload
        }
    },
    actions: {
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
})