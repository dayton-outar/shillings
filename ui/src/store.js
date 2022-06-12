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
      statementItems: []
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
        setStatementItems(state, payload) {
          state.statementItems = payload;
        },
        openStatementItem(state, payload) {
          const item = state.statementItems.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          if (item) {
            item.state = 'Opened';
          }
        },
        closeStatementItem(state, payload) {
          const item = state.statementItems.find(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          if (item) {
            item.state = 'Closed';
          }
        },
        addStatementItem(state, payload) {
          state.statementItems.push(payload)

          //localStorage.setItem('my-statement-items', JSON.stringify(this.statementItems) )
        },
        updateStatementItem(state, payload) {
          const ix = state.statementItems.findIndex(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          // if (payload.key === 'amount') {
          //     payload.value = payload.value.toString().replace(/[^0-9.-]+/g,'');
          // }
          state.statementItems[ix][payload.key] = payload.value;

          //localStorage.setItem('my-statement-items', JSON.stringify(this.statementItems) )
        },
        removeStatementItem(state, payload) {
          const ix = state.statementItems.findIndex(p => p.type.toLowerCase() === payload.type.replace(' ', '_').toLowerCase() && p.sequence === payload.sequence);
          if (ix > -1) {
            state.statementItems.splice(ix, 1);
            
            for (let i = ix; i < state.statementItems.length; i++) {
              if (state.statementItems[i].type === payload.type) {
                state.statementItems[i].no = (state.statementItems[i].no - 1);
              }              
            }
          }

          //localStorage.setItem('my-statement-items', JSON.stringify(this.statementItems) )
        },
        preppedStatementItems(state) {
          state.statementItems.map(i => {
              i.amount = parseFloat(i.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;
              
              return i;
          })
        },
        saveFinancialReport(state, payload) {
          console.log({
            Company: payload.Company,
            Period: payload.Period,
            StatementDate: payload.StatementDate,
            IsAudited: payload.IsAudited,
            Analytes: state.statementItems
          });
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
        }
    },
    actions: {
        async createFinancialReport({ commit }, request) {
          console.log( request );

          const response = await graphQlClient.mutate({
            mutation: gql`mutation CreateFinancialReport($companyCode: String!, $companyName: String!, $period: Periodical!, $statementDate: DateTime!, $analytes: [StatementAnalyteInput], $logDescription: String!, $logged: DateTime!) {
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
                isAudited: true,
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
                  sequence,
                  analyte,
                  amount
                }
              }
            }`,
            variables: {
              companyCode: request.Company.code,
              companyName: request.Company.name,
              period: request.Period,
              statementDate: request.StatementDate,
              logDescription: request.Description,
              logged: request.Logged,
              analytes: request.Analytes
            }
          })

          response.data.createFinancialReport.analytes.forEach(el => {
            el.state = 'Closed';
          });

          commit('setStatementItems', response.data.createFinancialReport.analytes)
        },
        async fetchFinancialReport({ commit }, no) {
          const response = await graphQlClient.query({
            query: gql`query Get($no: Long!) {
              financialReports (
                where: { no: { eq: $no } }                
              ) {
                nodes {
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

          commit('setStatementItems', response.data.financialReports.nodes[0].analytes)
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
                  created
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
        saveFinancialReport({ commit }, payload) {
          commit('saveFinancialReport', payload)
        }
    }
})

// mutation {
//   createFinancialReport(financialReport: {
//     no: 1,
//     company: {
//       code: "NCBFG",
//       name: "National Commercial Bank Financial Group",
//       about: "",
//       announcements: [],
//       countryCode: "",
//       created: "1779-01-01",
//       founded: "1779-01-01",
//       industries: [],
//       industry: "",
//       totalEmployed: 0,
//       webSite: "",
//       wiki: ""
//     },
//     period: QUARTERLY,
//     statementDate: "2020-08-02",
//     analytes: [
//     {
//       no: 1,
//       sequence: 1,
//       amount: 700,
//       analyte: CAPITAL,
//       section: EQUITY,
//       type: FINANCIAL_POSITION,
//       description: ""
//     },
//     {
//       no: 1,
//       sequence: 1,
//       amount: 700,
//       analyte: CAPITAL,
//       section: EQUITY,
//       type: FINANCIAL_POSITION,
//       description: ""
//     }],
//     isAudited: true,
//     log: {
//       no: 0,
//       type: APPLICATION,
//       event: INFORMATION,
//       details: "",
//       logged: "2022-05-08"
//     }
//   }) {
//     company {
//       code,
//       name
//     },
//     period,
//     statementDate
//   }
// }