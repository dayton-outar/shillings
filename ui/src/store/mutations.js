import { v4 as uuidv4 } from 'uuid'

export default {
  add(state, payload) {    
    state[payload.type].nodes.push(payload.payload)
    state[payload.type].totalCount += 1
  },
  set(state, payload) {
      state[payload.type] = payload.payload
  },
  modify(state, payload) {
    const ol = JSON.parse( JSON.stringify( state[payload.type] ) )
    var ix = ol.nodes.findIndex(i => i[payload.pk] === payload.payload[payload.pk])
    if (ix > -1) {
      ol.nodes[ix] = payload.payload
    }

    state[payload.type] = ol
  },
  remove(state, payload) {
    var ix = state[payload.type].nodes.findIndex(i => i[payload.pk] === payload.payload[payload.pk])
    if (ix > -1) {
      state[payload.type].nodes.splice(ix, 1)
      state[payload.type].totalCount -= 1
    }
  },
  // --  
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
}