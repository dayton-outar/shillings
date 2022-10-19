<template>
    <div class="column is-full">
        <h2 class="title">Financial Reports</h2>

        <div class="columns">
            <div class="column is-full">
                <b-button 
                    type="is-info" 
                    size="is-medium" 
                    icon-pack="fas" 
                    icon-left="plus" 
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newReport" :editMode="false" v-if="isCreatePanelActive" @close="close" />
            </div>
        </div>

        <div class="columns">
            <div class="column is-full">
                <search-bar @submit="find" />
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

                        <b-table-column field="no" label="#" sortable v-slot="props" width="5%">
                            {{ props.row.no }}
                        </b-table-column>

                        <b-table-column field="description" label="Description" v-slot="props">
                            {{ props.row.description }}
                        </b-table-column>

                        <b-table-column field="statementDate" label="Date" sortable v-slot="props">
                            {{ formatDate(props.row.statementDate, 'MMM DD, YYYY') }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-info"
                                    icon-pack="fas"
                                    icon-right="pen-to-square"
                                    @click.prevent="props.toggleDetails(props.row)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-danger"
                                    icon-pack="fas"
                                    icon-right="trash"
                                    @click.prevent="deleteRow(props.row)" />
                            </template>
                        </b-table-column>

                        <template #detail="props">
                            <component :is="detailComponent"
                                :data="props.row" 
                                :editMode="true"
                                @close="$refs.tbl.toggleDetails(props.row)" />
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
import FinancialReport from './FinancialReport.vue'

export default {
    components: {
        'financial-report': FinancialReport,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin, utilMixin],
    data() {
        return {
            sort: ['statementDate', 'asc'],
            fetchTitle: 'Financial Reports',
            deleteTitle: 'Delete Financial Report',
            detailComponent: 'financial-report',
            newReport: {}
        }
    },
    computed: {
        ...mapState({ data: state => state.finances.financialReports })
    },
    methods: {
        ...mapActions('finances', ['fetch', 'delete']),
        find(q) {
            this.searchWord = q.searchWord
            this.filterQuery = { company: { name: { startsWith: this.searchWord } } }
            this.get()
        }        
    }
}

</script>