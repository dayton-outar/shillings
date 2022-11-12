<template>
    <div class="column is-full">
        <h2 class="title">Market Indices</h2>
        
        <div class="columns">
            <div class="column is-full">
                <b-button 
                    type="is-info"
                    size="is-medium"
                    icon-pack="fas"
                    icon-left="plus"
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newIndex" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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

                        <b-table-column field="name" label="Name" sortable v-slot="props">
                            {{ props.row.name }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-info"
                                    icon-pack="fas"
                                    icon-right="table-list"
                                    @click.prevent="view(props)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-info"
                                    icon-pack="fas"
                                    icon-right="pen-to-square"
                                    @click.prevent="edit(props)" />
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
                            <article>
                                <h5 class="title is-5">{{ props.row.name }}</h5>
                                <component :is="detailComponent" :data="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" :index="props.row.no" :options="mixOptions" />
                            </article>
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

import TableToolBar from './TableToolBar'
import SearchBar from './SearchBar.vue'
import MarketIndex from './MarketIndex.vue'
import StockIndices from './StockIndices.vue'

export default {
    components: {
        'market-index-detail': MarketIndex,
        'stock-indices': StockIndices,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin],
    data() {
        return {
            fetchTitle: 'Market Indices',
            deleteTitle: 'Delete Market Index',
            detailComponent: 'market-index-detail',
            newIndex: {
                no: '',
                name: ''
            },
            mixOptions: {
                readOnly: true,
                showTools: true
            }
        }
    },
    computed: {
        ...mapState({ data: state => state.indices.indices })
    },
    methods: {
        ...mapActions('indices', ['fetch', 'delete']),
        create() {
            this.newIndex.no += 1

            this.isCreatePanelActive = true
        },
        view(props) {
            this.detailComponent = 'stock-indices'
            props.toggleDetails(props.row)
        },
        edit(props) {
            this.detailComponent = 'market-index-detail'
            props.toggleDetails(props.row)
        }
    }
}

</script>