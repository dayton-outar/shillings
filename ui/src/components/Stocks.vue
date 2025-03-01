<template>
    <div class="column is-full">
        <h2 class="title">Stocks</h2>

        <div class="columns">
            <div class="column is-full">
                <b-button 
                    type="is-info"
                    size="is-medium"
                    icon-pack="fas"
                    icon-left="plus"
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newStock" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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
                    
                        <b-table-column field="code" label="Code" sortable v-slot="props" width="5%">
                            {{ props.row.code }}
                        </b-table-column>

                        <b-table-column field="name" label="Name" sortable v-slot="props">
                            {{ props.row.name }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-success"
                                    icon-pack="fas"
                                    icon-right="money-check-dollar"
                                    @click.prevent="showDividends(props)" />
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

                        <b-table-column width="5%">
                            <template>
                                <b-button
                                    size="is-small"
                                    type="is-danger"
                                    icon-pack="fas"
                                    icon-right="trash" />
                            </template>
                        </b-table-column>

                        <template #detail="props">
                            <component :is="detailComponent" :data="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" :stockCode="props.row.code" :options="sOptions" />
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
import Stock from './Stock.vue'
import Dividends from './Dividends.vue'

export default {
    components: {
        'stock-detail': Stock,
        'stock-dividends': Dividends,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin],
    data() {
        return {
            fetchTitle: 'Stocks',
            deleteTitle: 'Delete Stock',
            detailComponent: 'stock-detail',
            newStock: {
                code: '',
                name: '',
                company: {},
                isListed: true
            },
            sOptions: {
                readOnly: false
            }
        }
    },
    created() {
        this.get()
    },
    computed: {
        ...mapState({ data: state => state.stocks.stocks })
    },
    methods: {
        ...mapActions('stocks', ['fetch', 'delete']),
        showDividends(props) {
            this.detailComponent = 'stock-dividends'
            props.toggleDetails(props.row)
        },
        edit(props) {
            this.detailComponent = 'stock-detail'
            props.toggleDetails(props.row)
        }
    }
}

</script>