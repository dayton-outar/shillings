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
        const itrade = state.trades.totalTrades.find(t => t.stock.no === h.security.no)

        let newPrice = itrade ? itrade.closingPrice : 0
        let newCost = itrade ? h.volume * itrade.closingPrice : 0

        return {
          id: h.id,
          stock: itrade ? itrade.stock : null,
          volume: h.volume,
          unitPrice: h.unitPrice,
          purchaseCost: h.purchaseCost,
          currentPrice: newPrice,
          currentCost: newCost,
          variance: (newCost - h.purchaseCost),
          prices: itrade ? itrade.prices : []
        }
      })

      return ph
    }
}