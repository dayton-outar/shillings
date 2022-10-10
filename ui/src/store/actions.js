import gql from 'graphql-tag'
import graphQlClient from '../apollo'

export default {
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
    saveFinancialReport({ commit }, payload) {
      commit('saveFinancialReport', payload)
    }
}