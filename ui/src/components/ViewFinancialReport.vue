<template>
    <div class="bg-white p-5">
        <div class="columns">
            <div class="column is-full">
                <div class="media">
                    <div class="media-left">
                        <figure class="image is-64x64">
                            <img :src="(data.company.logo ? `${fileApiHost}?no=${data.company.logo.no}` : require(`../assets/no-image.png`))" alt="Company Logo" />
                        </figure>
                    </div>
                    <div class="media-content">
                        <h3 class="title is-3">{{ data.company.name }}</h3>
                    </div>
                </div>
            </div>
        </div>
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
                                        <th class="text-right">{{ formatMoney(assets.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(liabilities.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(equities.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(revenues.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(gains.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(expenses.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(losses.reduce((p, c) => c.amount + p, 0)) }}</th>
                                    </tr>
                                </template>
                                <template v-if="revenues.length || gains.length || expenses.length || losses.length">
                                    <tr>
                                        <th>Net Income</th>
                                        <th class="text-right">{{ formatMoney( netProfit ) }}</th>
                                    </tr>
                                </template>
                                <template v-if="profitShares.length">
                                    <tr>
                                        <th colspan="2">Profit Attributable to:</th>
                                    </tr>
                                    <tr v-for="i in profitShares" :key="i.no">
                                        <td><p class="ml-4">{{ i.description }}</p></td>
                                        <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                    </tr>
                                </template>
                                <template v-if="eps.length">
                                    <tr>
                                        <th colspan="2">Earnings per Stock Unit</th>
                                    </tr>
                                    <tr>
                                        <th></th>
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
                                        <th class="text-right">{{ formatMoney(operations.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(finances.reduce((p, c) => c.amount + p, 0)) }}</th>
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
                                        <th class="text-right">{{ formatMoney(investments.reduce((p, c) => c.amount + p, 0)) }}</th>
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
    </div>
</template>

<script>

import config from '../config'
import utilMixin from '../utils/utilMixin'

export default {
    props: ['data'],
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
        totalEquityAndLiabilities() {
            return (this.liabilities.reduce((p, c) => c.amount + p, 0) + this.equities.reduce((p, c) => c.amount + p, 0))
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
        netProfit() {
            return ( this.revenues.reduce((p, c) => c.amount + p, 0) + this.gains.reduce((p, c) => c.amount + p, 0) ) - ( this.expenses.reduce((p, c) => c.amount + p, 0) + this.losses.reduce((p, c) => c.amount + p, 0) )
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
        netCash() {
            return ( this.operations.reduce((p, c) => c.amount + p, 0) + this.finances.reduce((p, c) => c.amount + p, 0) + this.investments.reduce((p, c) => c.amount + p, 0) )
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