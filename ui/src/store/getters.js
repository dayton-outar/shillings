export default {
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
        const itrade = state.totalTradings.find(t => t.stock.code === h.security.code)
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