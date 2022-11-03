import { v4 as uuidv4 } from 'uuid'

export default {
  add(state, payload) {
    state[payload.type].nodes.unshift(payload.payload)
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
    setSections(state, payload) {
      state.sections = payload
    },
    setAssays(state, payload) {
      state.assays = payload
    },
    setPortfolio(state, payload) {
      state.portfolioHoldings = payload
    },
    // ---
    addPortfolio(state, payload) {
      const itrade = state.trades.totalTrades.find(t => t.code === payload.security.code)
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
}