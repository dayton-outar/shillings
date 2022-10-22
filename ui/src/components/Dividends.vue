<template>
    <div class="column is-full">
        <div class="columns" v-if="readOnly">
            <div class="column">
                <b-button 
                    type="is-info"
                    size="is-medium"
                    icon-pack="fas"
                    icon-left="plus"
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newDividend" :editMode="false" v-if="isCreatePanelActive" @close="close" />
            </div>
        </div>

        <div class="columns">
            <div class="column is-full">
                <div class="box my-4 mx-1">
                    <table-tool-bar :page="page" :pageLengths="pageLengths" @refresh="get" @change="changeLen" />

                    <b-table
                        ref="tbl"
                        detailed
                        :show-detail-icon="false"
                        :data="data.nodes"
                        icon-pack="fas"
                        :total="data.totalCount"
                        :paginated="true"
                        :pagination-simple="true"
                        :per-page="page"
                        :current-page.sync="currentPage"
                        :sort-icon="sortIcon" 
                        :sort-icon-size="sortIconSize"
                        :default-sort="sort"
                        :backend-sorting="true"
                        :backend-pagination="true"
                        :striped="true" 
                        :hoverable="true"
                        @sort="sortTable"
                        @page-change="pageChange">

                        <b-table-column label="Stock" sortable v-slot="props">
                            {{ props.row.stock.name }}
                        </b-table-column>

                        <b-table-column label="Record Date" sortable v-slot="props">
                            {{ formatDate(props.row.recordDate, 'MMM-DD-YYYY') }}
                        </b-table-column>

                        <b-table-column label="Payment Date" sortable v-slot="props">
                            {{ formatDate(props.row.paymentDate, 'MMM-DD-YYYY') }}
                        </b-table-column>

                        <b-table-column field="amount" label="Amount" sortable v-slot="props">
                            {{ formatMoney(props.row.amount) }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props" v-if="readOnly">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-info"
                                    icon-pack="fas"
                                    icon-right="pen-to-square"
                                    @click.prevent="props.toggleDetails(props.row)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props" v-if="readOnly">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-danger"
                                    icon-pack="fas"
                                    icon-right="trash"
                                    @click.prevent="deleteRow(props.row)" />
                            </template>
                        </b-table-column>

                        <template slot="detail" slot-scope="props">
                            <component :is="detailComponent" :data="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" />
                        </template>

                        <template #empty>
                            <div class="has-text-centered">No records</div>
                        </template>

                    </b-table>

                    <b-loading :is-full-page="false" v-model="isLoading"></b-loading>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import tableMixin from '../utils/tableMixin'
import utilMixin from '../utils/utilMixin'

import TableToolBar from './TableToolBar'
import SearchBar from './SearchBar.vue'

export default {
    props: ['stockCode', 'readOnly'],
    components: {
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin, utilMixin],
    data() {
        return {
            sort: ['paymentDate', 'desc'],
            fetchTitle: 'Dividends',
            deleteTitle: 'Delete Dividend',
            detailComponent: 'dividend-detail',
            filterQuery: { stock: { code: { eq: this.stockCode } } },
            newDividend: {
                no: 0,
                stock: {},
                currency: '',
                amount: 0
            }
        }
    },
    created() {
        this.get()
    },
    computed: {
        ...mapState({ data: state => state.dividends.dividends })
    },
    methods: {
        ...mapActions('dividends', ['fetch', 'delete']),
        create() {
            this.newDividend.no += 1

            this.isCreatePanelActive = true
        }
    }
}

</script>