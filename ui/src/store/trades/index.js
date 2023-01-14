import gql from 'graphql-tag'
import graphQlClient from '../../apollo'
import mutations from '../mutations'

export default {
  namespaced: true,
  state: {
    totalTrades: null
  },
  mutations,
  actions: {
    async fetch({ commit }, request) {
      const response = await graphQlClient.query({
        query: gql`query Get($marketNo: Long!, $begin: DateTime!, $end: DateTime!) {
          totalTrades
          (
            marketNo: $marketNo,
            begin: $begin
            end: $end
            order: { volume: DESC }
          ) {
            stock {
              no,
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
                files {
                  no,
                  type,
                  fileName,
                  contentType,
                  contentSize,
                  created
                }
              }
            },
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
          marketNo: request.marketNo,
          begin: request.begin,
          end: request.end
        }
      })
  
      const totalTrades = response.data.totalTrades.map(t => {
        try {
          t.prices = JSON.parse(t.prices)
        }
        catch (err) {
          // TODO: Raise appropriate response
          //console.log(err.message)
          //console.log('Already parsed')
        }
  
        return t
      })

      commit('set', {
        type: 'totalTrades',
        payload: totalTrades
      })
  
      return Promise.resolve(totalTrades)
    }
  }
}