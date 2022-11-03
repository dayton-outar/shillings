export default {
    volumeShares(state) {
        const volumes = state.trades.totalTrades.map(t => {
            return {
              name: t.stock.name,
              y: t.volume,
              sliced: false,
              selected: false
            }
          })

        return volumes
    },
    tradeCosts(state) {
        const costs = state.trades.totalTrades.map(t => {
            return {
              name: t.stock.name,
              x: t.volume,
              y: t.closingPrice,
              z: t.volume * t.closingPrice
            }
          })
        
        return costs
    },
    pricePercentages(state) {
        const changes = state.trades.totalTrades.map(t => {
          return {
            name: t.stock.name,
            data: [ t.percentage ]
          }
        })
        
        return changes
    },
    holdings(state) {
      const ph = state.holdings.portfolio.map(h => {
        const itrade = state.trades.totalTrades.find(t => t.stock.code === h.security.code)
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
}