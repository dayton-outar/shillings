<template>
    <div class="panel is-light">
        <h4 class="panel-heading">
            Earnings: {{ formattedDateRange }}
        </h4>
        <div class="panel-block">
            <div class="column">
                <b-table
                    :data="data"
                    icon-pack="fas"
                    :default-sort="sort"
                    striped
                    hoverable>

                    <b-table-column label="Company" sortable v-slot="props">
                        <company-tag :data="props.row.company" />
                    </b-table-column>

                    <b-table-column field="statementDate" label="Date" sortable v-slot="props">
                        {{ formatDate(props.row.statementDate, 'MMM-DD-YYYY') }}
                    </b-table-column>

                    <b-table-column field="revenues" label="Revenues" sortable v-slot="props">
                        {{ formatMoney( props.row.revenues ) }}
                    </b-table-column>

                    <b-table-column field="earnings" label="Earnings" sortable v-slot="props">
                        {{ formatMoney( props.row.earnings ) }}
                    </b-table-column>

                    <b-table-column field="margin" label="Margin" sortable v-slot="props">
                        {{ formatPercentage( props.row.margin * 100 ) }}
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
            fetchTitle: 'Company Earnings'
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
        ...mapState({ data: state => state.earnings.earnings })
    },
    methods: {
        ...mapActions('earnings', ['fetch']),
    }
}

</script>
