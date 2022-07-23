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
      stocks: [],
      totalTradings: null,
      portfolioHoldings: [],
      sections: [],
      assays: [],
      financialReport: {
        no: null,
        company: null,
        description: '',
        period: null,
        statementDate: null,
        isAudited: null,
        analytes: [],
        log: {
          logged: new Date()
        }
      },
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
        setCompanies(state, payload) {
          state.companies = payload
        },
        setStocks(state, payload) {
          state.stocks = payload
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
        setFinancialReport(state, payload) {
          state.financialReport = payload
        },
        openStatementItem(state, payload) {
          const item = state.financialReport.analytes.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
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
          const item = state.financialReport.analytes.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          let isValid = true;

          if (item) {
            if (!item.description) {
              item.vDesc.type = 'is-danger'
              item.vDesc.message = 'Please enter description'

              isValid = false
            } else {
              item.vDesc.type = ''
              item.vDesc.message = ''
            }

            if (!item.section) {
              item.vSec.type = 'is-danger'
              item.vSec.message = 'Please choose section'

              isValid = false
            } else {
              item.vSec.type = ''
              item.vSec.message = ''
            }

            if (!item.analyte.length) {
              item.vAnl.type = 'is-danger'
              item.vAnl.message = 'Please choose categories'

              isValid = false
            } else {
              item.vAnl.type = ''
              item.vAnl.message = ''
            }

            let amt = parseFloat(item.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
            if (!amt) {
              item.vAmt.type = 'is-danger'
              item.vAmt.message = 'Please enter amount'

              isValid = false
            } else {
              item.vAmt.type = ''
              item.vAmt.message = ''
            }

            if (isValid) {
              item.state = 'Closed';
            }
          }
        },
        addStatementItem(state, payload) {
          state.financialReport.analytes.push(payload)

          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReport.analytes) )
        },
        updateStatementItem(state, payload) {
          const ix = state.financialReport.analytes.findIndex(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          // if (payload.key === 'amount') {
          //     payload.value = payload.value.toString().replace(/[^0-9.-]+/g,'');
          // }
          state.financialReport.analytes[ix][payload.key] = payload.value;

          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReport.analytes) )
        },
        removeStatementItem(state, payload) {
          const ix = state.financialReport.analytes.findIndex(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          if (ix > -1) {
            state.financialReport.analytes.splice(ix, 1);
            
            for (let i = ix; i < state.financialReport.analytes.length; i++) {
              if (state.financialReport.analytes[i].type === payload.type) {
                state.financialReport.analytes[i].no = (state.financialReport.analytes[i].no - 1);
              }              
            }
          }

          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReport.analytes) )
        },
        preppedStatementItems(state) {
          state.financialReport.analytes.map(i => {
              i.amount = parseFloat(i.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
              
              return i;
          })
        },
        validateStatementItems(state) {
          state.isItemsValid = true

          state.financialReport.analytes.forEach(i => {
            if (!i.description) {
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
          state.financialReport.company = payload
        },
        updateReportPeriod(state, payload) {
          state.financialReport.period = payload
        },
        updateReportDate(state, payload) {
          state.financialReport.statementDate = payload.toJSON()
        },
        updateReportIsAudit(state, payload) {
          state.financialReport.isAudited = payload
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
        async fetchFinancialReport({ commit }, no) {
          const response = await graphQlClient.query({
            query: gql`query Get($no: Long!) {
              financialReports (
                where: { no: { eq: $no } }                
              ) {
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
              no: no
            }
          })
          
          response.data.financialReports.nodes[0].analytes.forEach(el => {
            el.state = 'Closed';
          });

          commit('setFinancialReport', response.data.financialReports.nodes[0])          
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
                  name
                }
              }
            }`
          })
          
          commit('setCompanies', response.data.companies.nodes)
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
        prepStatementItems( { commit } ) {
          commit('preppedStatementItems')
        },
        validateStatementItems( { commit } ) {
          commit('validateStatementItems')
        },
        updateFinancialReportCompany( { commit }, value) {
          commit('updateReportCompany', value)
        },
        saveFinancialReport({ commit }, payload) {
          commit('saveFinancialReport', payload)
        }
    }
})