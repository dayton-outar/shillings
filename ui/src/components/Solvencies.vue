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

                    <b-table-column label="Company" sortable v-slot="props">
                        <article class="media">
                            <figure class="media-left">
                                <div class="image is-48x48">
                                    <img class="is-rounded"
                                        :src="(getLogo(props.row.company.files) && getLogo(props.row.company.files).length > 0 ? `${fileApiHost}?no=${getLogo(props.row.company.files)[0].no}` : require(`../assets/no-image.png`))" alt="Company Logo" />
                                </div>
                            </figure>
                            <div class="media-content">
                                <p v-if="props.row.company.webSite"><a :href="props.row.company.webSite"
                                    target="_blank">{{props.row.company.name}}</a></p>
                                <p v-else>{{ props.row.company.name }}</p>
                                <b-tag-list v-for="(i, ix) in props.row.company.industries" :key="ix">
                                    <b-tag rounded>{{ i.name }}</b-tag>&nbsp;
                                </b-tag-list>
                            </div>
                        </article>
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

import config from '../config'
//import tableMixin from '../utils/tableMixin'
import utilMixin from '../utils/utilMixin'

export default {
    props: ['formattedDateRange'],
    mixins: [utilMixin],
    data() {
        return {
            sort: ['statementDate', 'desc'],
            fetchTitle: "Companies' Solvency",
            //deleteTitle: 'Delete Interest Rate',
            //detailComponent: 'interest-rate',
            fileApiHost: config.fileApiHost,
            // filterQuery: null
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