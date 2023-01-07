<template>
    <div class="bg-white p-5">
        <div class="columns">
            <div class="column is-full">
                <div class="media">
                    <div class="media-left">
                        <figure class="image is-64x64">
                            <img :src="(getLogo(data.company.files) ? `${fileApiHost}?no=${getLogo(data.company.files)[0].no}` : require(`../assets/no-image.png`))" alt="Company Logo" />
                        </figure>
                    </div>
                    <div class="media-content">
                        <h3 class="title is-3">{{ data.company.name }}</h3>
                    </div>
                </div>
            </div>
        </div>
        <template v-if="showDetails">
            <div v-for="(statementType, ix) in statementTypes" :key="(`stmt_type_${ix}`)" class="columns">
                <div class="column is-full pb-6">
                    <div class="has-border-bottom-thin">
                        <h4 class="title is-4">Statement of {{ formatTitleCase(statementType) }}</h4>
                        <h5 class="subtitle is-5 has-text-grey">{{ formatDate(data.statementDate, 'D MMMM YYYY') }}</h5>
                    </div>
                    <div>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="wide-70"></th>
                                    <th class="text-right wide-30">$'000</th>
                                </tr>
                            </thead>
                            <tbody>
                                <template v-if="statementType === 'FINANCIAL_POSITION'">
                                    <template v-if="assets.length">
                                        <tr>
                                            <th colspan="2">Assets</th>
                                        </tr>
                                        <tr v-for="i in assets" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th><p class="ml-4">Total Assets</p></th>
                                            <th class="text-right">{{ formatMoney( totalAssets ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="liabilities.length">
                                        <tr>
                                            <th colspan="2">Liabilities</th>
                                        </tr>
                                        <tr v-for="i in liabilities" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th><p class="ml-4">Total Liabilities</p></th>
                                            <th class="text-right">{{ formatMoney( totalLiabilities ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="equities.length">
                                        <tr>
                                            <th colspan="2">Equity</th>
                                        </tr>
                                        <tr v-for="i in equities" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th><p class="ml-4">Total Equity</p></th>
                                            <th class="text-right">{{ formatMoney( totalEquity ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="liabilities.length && equities.length">
                                        <tr>
                                            <th>Total Equity and Liabilities</th>
                                            <th class="text-right">{{ formatMoney( totalEquityAndLiabilities ) }}</th>
                                        </tr>
                                    </template>
                                </template>
                                <template v-if="statementType === 'INCOME'">
                                    <template v-if="revenues.length">
                                        <tr>
                                            <th colspan="2">Revenues</th>
                                        </tr>
                                        <tr v-for="i in revenues" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th><p class="ml-4">Total Revenues</p></th>
                                            <th class="text-right">{{ formatMoney( totalRevenues ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="gains.length">
                                        <tr>
                                            <th colspan="2">Gains</th>
                                        </tr>
                                        <tr v-for="i in gains" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>                                    
                                        <tr>
                                            <th><p class="ml-4">Total Gains</p></th>
                                            <th class="text-right">{{ formatMoney( totalGains ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="expenses.length">
                                        <tr>
                                            <th colspan="2">Expenses</th>
                                        </tr>
                                        <tr v-for="i in expenses" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th><p class="ml-4">Total Expenses</p></th>
                                            <th class="text-right">{{ formatMoney( totalExpenses ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="losses.length">
                                        <tr>
                                            <th colspan="2">Losses</th>
                                        </tr>
                                        <tr v-for="i in losses" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th><p class="ml-4">Total Losses</p></th>
                                            <th class="text-right">{{ formatMoney( totalLosses ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="revenues.length || gains.length || expenses.length || losses.length">
                                        <tr>
                                            <th>Net Income</th>
                                            <th class="text-right">{{ formatMoney( netProfit ) }}</th>
                                        </tr>
                                    </template>
                                    <tr>
                                        <th colspan="2">&nbsp;</th>
                                    </tr>
                                    <template v-if="profitShares.length">
                                        <tr>
                                            <th colspan="2">Profit Attributable to:</th>
                                        </tr>
                                        <tr v-for="i in profitShares" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                    </template>
                                    <tr>
                                        <th colspan="2">&nbsp;</th>
                                    </tr>
                                    <template v-if="sharesOutstanding.length">
                                        <tr>
                                            <th>Shares Outstanding</th>
                                            <th class="text-right">$</th>
                                        </tr>
                                        <tr v-for="i in sharesOutstanding" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                    </template>                                    
                                    <tr>
                                        <th colspan="2">&nbsp;</th>
                                    </tr>
                                    <template v-if="eps.length">
                                        <tr>
                                            <th>Earnings per Stock Unit</th>
                                            <th class="text-right">$</th>
                                        </tr>
                                        <tr v-for="i in eps" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-4">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                    </template>
                                </template>
                                <template v-if="statementType === 'CASH_FLOW'">
                                    <template v-if="operations.length">
                                        <tr>
                                            <th colspan="2">Operating Activities</th>
                                        </tr>
                                        <tr v-for="i in operations" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-6">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th class="text-right">{{ formatMoney( totalOperatingActivities ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="finances.length">
                                        <tr>
                                            <th colspan="2">Financing Activities</th>
                                        </tr>
                                        <tr v-for="i in finances" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-6">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th class="text-right">{{ formatMoney( totalFinancingActivities ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="investments.length">
                                        <tr>
                                            <th colspan="2">Investing Activities</th>
                                        </tr>
                                        <tr v-for="i in investments" :key="(`${statementType}_${i.sequence}`)">
                                            <td><p class="ml-6">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th class="text-right">{{ formatMoney( totalInvestingActivities ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="fxChanges.length">
                                        <tr>
                                            <td>Effects of Exchange Rates on Cash</td>
                                            <th class="text-right">{{ formatMoney( totalFxChanges ) }}</th>
                                        </tr>
                                    </template>
                                    <template v-if="operations.length || finances.length || investments.length">
                                        <tr>
                                            <th>Net Cash Change</th>
                                            <th class="text-right">{{ formatMoney( netCash ) }}</th>
                                        </tr>
                                    </template>
                                </template>
                            </tbody>
                        </table>
                    </div>                
                </div>
            </div>
        </template>
        <template>
            <div class="has-border-bottom-thin mb-6">
                <h4 class="title is-4">Summary</h4>
                <h5 class="subtitle is-5 has-text-grey">{{ formatDate(data.statementDate, 'D MMMM YYYY') }}</h5>
            </div>
            <b-collapse class="card" animation="slide" aria-id="incomeStatement" :open="true">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="incomeStatement">
                  <p class="card-header-title">Income Statement</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                    <table class="table">
                        <tbody>
                            <tr>
                                <th style="width: 50%">Revenue</th>
                                <td>{{ formatMoney( totalRevenues ) }}</td>
                            </tr>
                            <tr>
                                <th>Operating Expenses</th>
                                <td>{{ formatMoney( totalOperatingExpenses ) }}</td>
                            </tr>
                            <tr>
                                <th>Net income</th>
                                <td>{{ formatMoney( netProfit ) }}</td>
                            </tr>
                            <tr>
                                <th>Net profit margin</th>
                                <td>{{ formatPercentage( profitMargin ) }}</td>
                            </tr>
                            <tr>
                                <th>Earnings per stock</th>
                                <td>{{ formatMoney( basicEps ) }}</td>
                            </tr>
                            <tr>
                                <th>Shares outstanding</th>
                                <td>{{ formatMoney( weighedAverageSharesOutstanding ) }}</td>
                            </tr>
                            <tr>
                                <th>EBITDA</th>
                                <td>{{ formatMoney( ebitda ) }}</td>
                            </tr>
                            <tr>
                                <th>Effective tax rate</th>
                                <td>{{ formatPercentage( taxRate ) }}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
              </div>
            </b-collapse>
            <b-collapse class="card" animation="slide" aria-id="balanceSheet" :open="false">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="balanceSheet">
                  <p class="card-header-title">Balance Sheet</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                    <table class="table">
                        <tbody>
                            <tr>
                                <th style="width: 50%">Cash and equivalents</th>
                                <td>{{ formatMoney( totalCashAssets ) }}</td>
                            </tr>
                            <tr>
                                <th>Inventories</th>
                                <td>{{ this.totalInventories == 0 ? '&ndash;' : formatMoney( this.totalInventories ) }}</td>
                            </tr>
                            <tr>
                                <th>Total assets</th>
                                <td>{{ formatMoney( totalAssets ) }}</td>
                            </tr>
                            <tr>
                                <th>Total liabilities</th>
                                <td>{{ formatMoney( totalLiabilities ) }}</td>
                            </tr>
                            <tr>
                                <th>Total equity</th>
                                <td>{{ formatMoney( totalEquity ) }}</td>
                            </tr>
                            <tr>
                                <th>Book value per stock</th>
                                <td>{{ this.bvs == 0 ? '&ndash;' : formatMoney( bvs ) }}</td>
                            </tr>
                            <tr>
                                <th>Quick Ratio</th>
                                <td>{{ formatNumber( quickRatio ) }}</td>
                            </tr>
                            <tr>
                                <th>Current ratio</th>
                                <td>{{ formatNumber( currentRatio ) }}</td>
                            </tr>
                            <tr>
                                <th>Debt to equity</th>
                                <td>{{ formatPercentage( debtToEquity ) }}</td>
                            </tr>
                            <tr>
                                <th>Return on assets</th>
                                <td>{{ formatPercentage( roa ) }}</td>
                            </tr>
                            <tr>
                                <th>Return on capital</th>
                                <td>{{ formatPercentage( roc ) }}</td>
                            </tr>
                            <tr>
                                <th>Return on equity</th>
                                <td>{{ formatPercentage( roe ) }}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
              </div>
            </b-collapse>
            <b-collapse class="card" animation="slide" aria-id="cashFlow" :open="false">
              <template #trigger="props">
                <div
                  class="card-header"
                  role="button"
                  aria-controls="cashFlow">
                  <p class="card-header-title">Cash Flow</p>
                  <a class="card-header-icon">
                    <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'" />
                  </a>
                </div>
              </template>
              <div class="card-content">
                <div class="content">
                    <table class="table">
                        <tbody>
                            <tr>
                                <th style="width: 50%">Cash from operations</th>
                                <td>{{ formatMoney( totalOperatingActivities ) }}</td>
                            </tr>
                            <tr>
                                <th>Cash from investing</th>
                                <td>{{ formatMoney( totalInvestingActivities ) }}</td>
                            </tr>
                            <tr>
                                <th>Cash from financing</th>
                                <td>{{ formatMoney( totalFinancingActivities ) }}</td>
                            </tr>
                            <tr>
                                <th>Net change in cash</th>
                                <td>{{ formatMoney( netCash ) }}</td>
                            </tr>
                            <tr>
                                <th>Free cash flow</th>
                                <td>{{ formatMoney( freeCashFlow ) }}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
              </div>
            </b-collapse>
        </template>
    </div>
</template>

<script>

import config from '../config'
import utilMixin from '../utils/utilMixin'

export default {
    props: ['data', 'showDetails'],
    mixins: [utilMixin],
    data() {
        return {
            fileApiHost: config.fileApiHost
        }
    },
    computed: {
        statementTypes() {
            return this.data.analytes.map(a => a.type).filter((value, index, array) => array.indexOf(value) === index)
        },
        assets() {
            return this.get('FINANCIAL_POSITION', 'ASSETS')
        },
        liabilities() {
            return this.get('FINANCIAL_POSITION', 'LIABILITIES')
        },
        equities() {
            return this.get('FINANCIAL_POSITION', 'EQUITY')
        },
        inventories() {
            return this.assets.filter(l => l.analyte.indexOf('INVENTORIES') > -1)
        },
        totalAssets() {
            return this.assets.reduce((p, c) => c.amount + p, 0)
        },
        totalCashAssets() {
            return this.assets.filter(l => l.analyte.indexOf('CASH') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalInventories() {
            return this.inventories.reduce((p, c) => c.amount + p, 0)
        },
        totalCurrentAssets() {
            return this.assets.filter(l => l.analyte.indexOf('CURRENT') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalLiabilities() {
            return this.liabilities.reduce((p, c) => c.amount + p, 0)
        },
        totalLongtermDebt() {
            return this.liabilities.filter(l => l.analyte.indexOf('LOAN') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalCurrentLiabilities() {
            return this.liabilities.filter(l => l.analyte.indexOf('CURRENT') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalEquity() {
            return this.equities.reduce((p, c) => c.amount + p, 0)
        },
        totalNonControllingEquity() {
            return this.equities.filter(l => l.analyte.indexOf('NON_CONTROLLING') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalShareholdersEquity() {
            return this.totalEquity - this.totalNonControllingEquity
        },
        totalEquityAndLiabilities() {
            return (this.totalLiabilities + this.totalEquity)
        },
        revenues() {
            return this.get('INCOME', 'REVENUES')
        },
        expenses() {
            return this.get('INCOME', 'EXPENSES')
        },
        gains() {
            return this.get('INCOME', 'GAINS')
        },
        losses() {
            return this.get('INCOME', 'LOSSES')
        },
        totalShareholdersProfit() {
            return this.profitShares.filter(l => l.analyte.indexOf('SHAREHOLDERS') > -1).reduce((p, c) => c.amount + p, 0)
        },
        profitShares() {
            return this.get('INCOME', 'PROFIT_SHARE')
        },
        sharesOutstanding() {
            return this.get('INCOME', 'SHARES_OUTSTANDING')
        },
        weighedAverageSharesOutstanding() {
            return this.sharesOutstanding.reduce((p, c) => c.amount + p, 0)
        },
        totalRevenues() {
            return this.revenues.reduce((p, c) => c.amount + p, 0)
        },
        totalGains() {
            return this.gains.reduce((p, c) => c.amount + p, 0)
        },
        totalExpenses() {
            return this.expenses.reduce((p, c) => c.amount + p, 0)
        },
        totalLosses() {
            return this.losses.reduce((p, c) => c.amount + p, 0)
        },
        totalOperatingExpenses() {
            return this.expenses.filter(e => e.analyte.indexOf('OPERATING') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalInterestExpenses() {
            return this.losses.filter(e => e.analyte.indexOf('INTEREST') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalDepreciationAndAmortization() {
            return this.expenses.filter(e => e.analyte.indexOf('DEPRECIATION') > -1 || e.analyte.indexOf('IMPAIRMENT') > -1).reduce((p, c) => c.amount + p, 0)
        },
        tax() {
            return this.expenses.filter(e => e.analyte.indexOf('TAX') > -1).reduce((p, c) => c.amount + p, 0)
        },
        netProfit() {
            return ( this.totalRevenues + this.totalGains ) - ( this.totalExpenses + this.totalLosses )
        },
        profitMargin() {
            return this.totalRevenues > 0 ? ( ( this.netProfit / this.totalRevenues ) * 100).toFixed(2) : 0
        },
        ebitda() {
            return ( this.netProfit + this.tax + this.totalInterestExpenses + this.totalDepreciationAndAmortization )
        },
        taxRate() {
            return this.netProfit > 0 ? ( this.tax / ( this.netProfit + this.tax ) ) * 100  : 0
        },
        basicEps() {
            let bEps = 0
            const basic = this.eps.filter(e => e.analyte.indexOf('BASIC') > -1)
            bEps = basic ? 
                    basic.reduce((p, c) => c.amount + p, 0) : 
                    ( (this.totalShareholdersProfit && this.weighedAverageSharesOutstanding) ? this.totalShareholdersProfit / this.weighedAverageSharesOutstanding : 0)
            return bEps
        },
        dilutedEps() {
            return this.eps.filter(e => e.analyte.indexOf('DILUTED') > -1).reduce((p, c) => c.amount + p, 0)
        },
        eps() { // Earnings per Stock
            return this.get('INCOME', 'EARNINGS_PER_STOCK')
        },
        quickRatio() {
            return ( ( this.totalCurrentAssets - this.totalInventories ) / this.totalCurrentLiabilities )
        },
        currentRatio() {
            return ( this.totalCurrentAssets / this.totalCurrentLiabilities )
        },
        roa() {
            return ( this.netProfit / this.totalAssets ) * 100
        },
        roe() {
            return ( this.totalShareholdersProfit / this.totalShareholdersEquity ) * 100
        },
        roc() { // Credit: https://corporatefinanceinstitute.com/resources/accounting/capital-employed/
            const capitalEmployed = (this.totalAssets - this.totalCurrentLiabilities)
            const ebit = ( this.netProfit + this.tax + this.totalInterestExpenses )
            return ( ebit / capitalEmployed ) * 100
        },
        debtToEquity() {
            return ( this.totalLongtermDebt / this.totalShareholdersEquity ) * 100
        },
        bvs() {
            return this.weighedAverageSharesOutstanding == 0 ? 0 : ( this.totalShareholdersEquity / this.weighedAverageSharesOutstanding )
        },
        operations() {
            return this.get('CASH_FLOW', 'OPERATING_ACTIVITIES')
        },
        finances() {
            return this.get('CASH_FLOW', 'FINANCING_ACTIVITIES')
        },
        investments() {
            return this.get('CASH_FLOW', 'INVESTING_ACTIVITIES')
        },
        fxChanges() {
            return this.get('CASH_FLOW', 'NONE')
        },
        totalOperatingActivities() {
            return this.operations.reduce((p, c) => c.amount + p, 0)
        },
        totalFinancingActivities() {
            return this.finances.reduce((p, c) => c.amount + p, 0)
        },
        totalInvestingActivities() {
            return this.investments.reduce((p, c) => c.amount + p, 0)
        },
        totalCapEx() {
            return this.investments.filter(e => e.analyte.indexOf('CAPITAL') > -1).reduce((p, c) => c.amount + p, 0)
        },
        totalFxChanges() {
            return this.fxChanges.filter(e => e.analyte.indexOf('EXCHANGE_RATE_CHANGES') > -1).reduce((p, c) => c.amount + p, 0)
        },
        netCash() {
            return ( this.totalOperatingActivities + this.totalFinancingActivities + this.totalInvestingActivities + this.totalFxChanges )
        },
        freeCashFlow() {
            // Credit: https://corporatefinanceinstitute.com/resources/financial-modeling/free-cash-flow-to-firm-fcff/
            // -- Approach #1
            // FCFF = NI + D&A +INT(1 – TAX RATE) – CAPEX – ΔNet WC

            // Where: 
            // NI = Net Income

            // D&A = Depreciation and Amortization
            // Int = Interest Expense
            // CAPEX = Capital Expenditures
            // Δ Net WC = Net Change in Working capital

            // -- Approach #2
            // FCFF = CFO + INT(1-Tax Rate) – CAPEX
            // Where: 
            // CFO = Cash Flow from Operations
            // INT = Interest Expense
            // CAPEX = Capital Expenditures
            
            return Math.abs(this.totalOperatingActivities) + Math.abs(this.totalInterestExpenses * (1 - (this.taxRate / 100) ) ) - Math.abs(this.totalCapEx)
        }
    },
    methods: {
        get(type, section) {
            return this.data.analytes.filter(a => a.type === type && a.section === section)
        }
    }
}

</script>

<style scoped>

.has-border-bottom-thin {
    border-bottom: 1px solid;
}

.wide-70 {
    width: 70%;
}

.wide-30 {
    width: 30% !important;
}

.text-right {
    text-align: right !important;
}

</style>