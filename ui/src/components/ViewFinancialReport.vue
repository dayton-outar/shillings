<template>
    <div>
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
            <div class="column is-full">
                <div class="has-border-bottom-thin">
                    <h4 class="title is-4">Statement of {{ formatTitleCase(statementType) }}</h4>
                    <h5 class="subtitle is-5 has-text-grey">{{ formatDate(data.statementDate, 'D MMMM YYYY') }}</h5>
                </div>
                <div>
                    <table>
                        <thead>
                            <tr>
                                <th class="wide-70"></th>
                                <th class="text-right wide-30">$'000</th>
                            </tr>
                        </thead>
                        <tbody>
                            <template v-if="statementType === 'FINANCIAL_POSITION'">
                                <tr>
                                    <th colspan="2">Assets</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'ASSETS')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Total Assets</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <th colspan="2">Liabilities</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'LIABILITIES')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Total Liabiliities</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <th colspan="2">Equity</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'EQUITY')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Total Equity</th>
                                    <th></th>
                                </tr>
                            </template>
                            <template v-if="statementType === 'INCOME'">
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'REVENUES')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Revenues</th>
                                    <th></th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'EXPENSES')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Expenses</th>
                                    <th></th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'GAINS')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Other income</th>
                                    <th></th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'LOSSES')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th>Other expenses</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <th colspan="2">Profit Attributable to:</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'PROFIT_SHARE')" :key="ix">
                                    <td><p class="ml-4">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                            </template>
                            <template v-if="statementType === 'CASH_FLOW'">
                                <tr>
                                    <th colspan="2">Operating Activities</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'OPERATING_ACTIVITIES')" :key="ix">
                                    <td><p class="ml-6">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th colspan="2">Financing Activities</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'FINANCING_ACTIVITIES')" :key="ix">
                                    <td><p class="ml-6">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
                                <tr>
                                    <th colspan="2">Investing Activities</th>
                                </tr>
                                <tr v-for="(i, ix) in getItemsBySection(statementType, 'INVESTING_ACTIVITIES')" :key="ix">
                                    <td><p class="ml-6">{{ i.description }}</p></td>
                                    <td class="text-right">{{ formatMoney(i.amount) }}</td>
                                </tr>
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
        }
    },
    methods: {
        getItemsBySection(type, section) {
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
    text-align: right;
}

</style>