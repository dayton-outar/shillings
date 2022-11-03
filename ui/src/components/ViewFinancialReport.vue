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
            <div v-for="(statementType, ix) in statementTypes" :key="ix" class="columns">
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
                                        <tr v-for="i in assets" :key="i.no">
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
                                        <tr v-for="i in liabilities" :key="i.no">
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
                                        <tr v-for="i in equities" :key="i.no">
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
                                        <tr v-for="i in revenues" :key="i.no">
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
                                        <tr v-for="i in gains" :key="i.no">
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
                                        <tr v-for="i in expenses" :key="i.no">
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
                                        <tr v-for="i in losses" :key="i.no">
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
                                        <tr v-for="i in profitShares" :key="i.no">
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
                                        <tr v-for="i in eps" :key="i.no">
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
                                        <tr v-for="i in operations" :key="i.no">
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
                                        <tr v-for="i in finances" :key="i.no">
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
                                        <tr v-for="i in investments" :key="i.no">
                                            <td><p class="ml-6">{{ i.description }}</p></td>
                                            <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th class="text-right">{{ formatMoney( totalInvestingActivities ) }}</th>
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
                                <th>Revenue</th>
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
        totalAssets() {
            return this.assets.reduce((p, c) => c.amount + p, 0)
        },
        totalLiabilities() {
            return this.liabilities.reduce((p, c) => c.amount + p, 0)
        },
        totalEquity() {
            return this.equities.reduce((p, c) => c.amount + p, 0)
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
        profitShares() {
            return this.get('INCOME', 'PROFIT_SHARE')
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
            const ox = this.expenses.filter(e => e.analyte.indexOf('OPERATING') > -1)
            return ox.reduce((p, c) => c.amount + p, 0)
        },
        totalInterestExpenses() {
            const ix = this.expenses.filter(e => e.analyte.indexOf('INTEREST') > -1)
            return ix.reduce((p, c) => c.amount + p, 0)
        },
        totalDepreciationAndAmortization() {
            const ix = this.expenses.filter(e => e.analyte.indexOf('DEPRECIATION') > -1 || e.analyte.indexOf('IMPAIRMENT') > -1)
            return ix.reduce((p, c) => c.amount + p, 0)
        },
        tax() {
            const taxes = this.expenses.filter(e => e.analyte.indexOf('TAX') > -1)
            return taxes.reduce((p, c) => c.amount + p, 0)
        },
        netProfit() {
            return ( this.totalRevenues + this.totalGains ) - ( this.totalExpenses + this.totalLosses )
        },
        profitMargin() {
            return ( ( this.netProfit / this.totalRevenues ) * 100).toFixed(2)
        },
        ebitda() {
            return ( this.netProfit + this.tax + this.totalInterestExpenses + this.totalDepreciationAndAmortization )
        },
        taxRate() {
            return ( this.tax / ( this.netProfit + this.tax ) ) * 100  
        },
        basicEps() {
            const basic = this.eps.filter(e => e.analyte.indexOf('BASIC') > -1)[0]
            return basic ? basic.amount : 0
        },
        dilutedEps() {
            const diluted = this.eps.filter(e => e.analyte.indexOf('DILUTED') > -1)[0]
            return diluted ? diluted.amount : 0
        },
        eps() { // Earnings per Stock
            return this.get('INCOME', 'EARNINGS_PER_STOCK')
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
        totalOperatingActivities() {
            return this.operations.reduce((p, c) => c.amount + p, 0)
        },
        totalFinancingActivities() {
            return this.finances.reduce((p, c) => c.amount + p, 0)
        },
        totalInvestingActivities() {
            return this.investments.reduce((p, c) => c.amount + p, 0)
        },
        netCash() {
            return ( this.totalOperatingActivities + this.totalFinancingActivities + this.totalInvestingActivities )
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