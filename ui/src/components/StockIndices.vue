<template>
    <div>
        <div class="columns" v-if="!options.readOnly">
            <div class="column">
                <b-button 
                    type="is-info"
                    size="is-medium"
                    icon-pack="fas"
                    icon-left="plus"
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newStockIndex" :editMode="false" v-if="isCreatePanelActive" @close="close" />
            </div>
        </div>

        <div class="columns">
            <div class="column is-full">
                <div class="box my-4 mx-1">
                    <table-tool-bar :page="page" :pageLengths="pageLengths" @refresh="get" @change="changeLen" v-if="options.showTools" />

                    <b-table
                        ref="tbl"
                        detailed
                        :show-detail-icon="false"
                        :data="data.nodes"
                        icon-pack="fas"
                        :total="data.totalCount"
                        :paginated="options.showTools"
                        :pagination-simple="true"
                        :per-page="page"
                        :current-page.sync="currentPage"
                        :sort-icon="sortIcon" 
                        :sort-icon-size="sortIconSize"
                        :default-sort="sort"
                        :backend-sorting="options.showTools"
                        :backend-pagination="options.showTools"
                        :striped="true" 
                        :hoverable="true"
                        @sort="sortTable"
                        @page-change="pageChange">

                        <b-table-column field="marketIndex.name" label="Index" sortable v-slot="props">
                            {{ props.row.marketIndex.name }}
                        </b-table-column>

                        <b-table-column field="log.logged" label="Date" sortable v-slot="props">
                            {{ formatDate(props.row.log.logged, 'MMM-DD-YYYY') }}
                        </b-table-column>

                        <b-table-column field="value" label="Value" sortable v-slot="props" numeric>
                            {{ formatMoney(props.row.value) }}
                        </b-table-column>

                        <b-table-column field="valueChange" label="Change" sortable v-slot="props" numeric>
                            {{ formatMoney(props.row.valueChange) }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props" v-if="!options.readOnly">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-info"
                                    icon-pack="fas"
                                    icon-right="pen-to-square"
                                    @click.prevent="props.toggleDetails(props.row)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props" v-if="!options.readOnly">
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
import StockIndex from './StockIndex.vue'

export default {
    props: ['index', 'begin', 'end', 'options'],
    components: {
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar,
        'stock-index': StockIndex
    },
    mixins: [tableMixin, utilMixin],
    data() {
        return {
            sort: ['log.logged', 'desc'],
            fetchTitle: 'Indices',
            deleteTitle: 'Delete Index Value',
            detailComponent: 'stock-index',
            filterQuery: this.query(),
            newStockIndex: {
                no: 0,
                value: 0,
                valueChange: 0,
                log: {
                    no: 0,
                    logged: new Date()
                }
            }
        }
    },
    computed: {
        ...mapState({ data: state => state.stockIndices.stockIndices }),
        filterProps() { // https://stackoverflow.com/questions/42737034/vue-js-watch-multiple-properties-with-single-handler
            return `${this.index}${this.begin}${this.end}`
        }
    },
    methods: {
        ...mapActions('stockIndices', ['fetch', 'delete']),
        order() {
            switch (this.sort[0]) {
                case 'marketIndex.name':
                    this.sortingQuery = [{ marketIndex: { [this.sort[0]]: this.sort[1].toUpperCase() } }]
                    break
                case 'log.logged':
                    this.sortingQuery = [{ log: { logged: this.sort[1].toUpperCase() } }]
                    break
                default:
                    this.sortingQuery = [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }
        },
        create() {
            this.newStockIndex.no += 1

            this.isCreatePanelActive = true
        },
        query() {
            let q = null
            
            if (this.index && this.begin && this.end) {
                q = { and: [ { marketIndex: { no: { eq: this.index } } }, { log: { logged: { gte: this.begin } } }, { log: { logged: { lte: this.end } } } ] }
            } else if (this.begin && this.end) {
                q = { and: [ { log: { logged: { gte: this.begin } } }, { log: { logged: { lte: this.end } } } ] }
            } else if (this.index) {
                q = { marketIndex: { no: { eq: this.index } } }
            }

            return q
        }
    },
    watch: {
        filterProps: function() {
            this.filterQuery = this.query()
            this.get()
        }
    }
}

</script>

<style scoped>

.text-right {
    text-align: right;
}

</style>