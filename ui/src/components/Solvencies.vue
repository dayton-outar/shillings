<template>
    <div class="panel is-light">
        <h4 class="panel-heading">
            Solvency: {{ formattedDateRange }}
        </h4>
        <div class="panel-block">
            <div class="column">
                <b-table
                    :data="data"
                    icon-pack="fas"
                    :default-sort="sort"
                    striped
                    hoverable>

                    <b-table-column field="company.name" label="Company" sortable v-slot="props">
                        <company-tag :data="props.row.company" />
                    </b-table-column>

                    <b-table-column field="statementDate" label="Date" sortable v-slot="props">
                        {{ formatDate(props.row.statementDate, 'MMM-DD-YYYY') }}
                    </b-table-column>

                    <b-table-column field="assets" label="Total Assets" sortable v-slot="props">
                        {{ formatMoney( props.row.assets ) }}
                    </b-table-column>

                    <b-table-column field="current" label="Working Capital" sortable v-slot="props">
                        {{ formatNumber( props.row.current ) }}
                    </b-table-column>

                    <b-table-column field="debt" label="Debt-to-Equity" sortable v-slot="props">
                        {{ formatPercentage( props.row.debt * 100 ) }}
                    </b-table-column>

                    <template #empty>
                        <div class="has-text-centered">No records</div>
                    </template>
                </b-table>
            </div>
        </div>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import utilMixin from '../utils/utilMixin'

import CompanyTag from './CompanyTag.vue'

export default {
    props: ['formattedDateRange'],
    components: {
        'company-tag': CompanyTag
    },
    mixins: [utilMixin],
    data() {
        return {
            sort: ['statementDate', 'desc'],
            fetchTitle: "Companies' Solvency"
        }
    },
    created() {
        this.fetch({
            period: 'ANNUAL',
            begin: '2009-01-01',
            end: '2022-12-01',
            ordering: this.sortingQuery
        })
    },
    computed: {
        ...mapState({ data: state => state.solvencies.solvencies })
    },
    methods: {
        ...mapActions('solvencies', ['fetch']),
    }
}

</script>