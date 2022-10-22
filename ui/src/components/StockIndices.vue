<template>
    <div class="column is-full">
        <div class="columns" v-if="!readOnly">
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
                    <table-tool-bar :page="page" :pageLengths="pageLengths" @refresh="get" @change="changeLen" v-if="showToolbar" />

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

                        <b-table-column label="Index" sortable v-slot="props">
                            {{ props.row.marketIndex.name }}
                        </b-table-column>

                        <b-table-column field="logged" label="Date" sortable v-slot="props">
                            {{ formatDate(props.row.log.logged, 'MMM-DD-YYYY') }}
                        </b-table-column>

                        <b-table-column field="value" label="Value" sortable v-slot="props">
                            {{ formatMoney(props.row.value) }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props" v-if="!readOnly">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-info"
                                    icon-pack="fas"
                                    icon-right="pen-to-square"
                                    @click.prevent="props.toggleDetails(props.row)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props" v-if="!readOnly">
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
    props: ['index', 'readOnly', 'showToolbar', 'begin', 'end'],
    components: {
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin, utilMixin],
    data() {
        return {
            sort: ['logged', 'desc'],
            fetchTitle: 'Indices',
            deleteTitle: 'Delete Index Value',
            detailComponent: '',
            filterQuery: (this.index && this.begin && this.end) ? 
                { and: [ { marketIndex: { no: { eq: this.index } } }, { log: { logged: { gte: this.begin } } }, { log: { logged: { lte: this.end } } } ] } : 
                (this.begin && this.end) ? { and: [ { log: { logged: { gte: this.begin } } }, { log: { logged: { lte: this.end } } } ] } : null,
            newStockIndex: {
                no: 0
            }
        }
    },
    created() {
        this.get()
    },
    computed: {
        ...mapState({ data: state => state.stockIndices.stockIndices })
    },
    methods: {
        ...mapActions('stockIndices', ['fetch', 'delete']),
        order() {
            switch (this.sort[0]) {
                case 'name':
                    this.sortingQuery = [{ marketIndex: { [this.sort[0]]: this.sort[1].toUpperCase() } }]
                    break
                case 'logged':
                    this.sortingQuery = [{ log: { logged: this.sort[1].toUpperCase() } }]
                    break
                default:
                    this.sortingQuery = [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }
        },
        create() {
            this.newStockIndex.no += 1

            this.isCreatePanelActive = true
        }
    }
}

</script>