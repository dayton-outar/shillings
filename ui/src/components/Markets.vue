<template>
    <div class="column is-full">
        <h2 class="title">Markets</h2>
        
        <div class="columns">
            <div class="column is-full">
                <b-button 
                    type="is-info"
                    size="is-medium"
                    icon-pack="fas"
                    icon-left="plus"
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newMarket" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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

                        <b-table-column field="name" label="Name" sortable v-slot="props">
                            {{ props.row.name }}
                        </b-table-column>

                        <b-table-column field="company" label="Company" v-slot="props" width="40%">
                            <company-tag :data="props.row.company" />
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
                                    @click.prevent="deleteRow(props.row.code)" />
                            </template>
                        </b-table-column>

                        <template #detail="props">
                            <component :is="detailComponent" :data="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" />
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
import Market from './Market.vue'
import CompanyTag from './CompanyTag.vue'

export default {
    components: {
        'market-detail': Market,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar,
        'company-tag': CompanyTag
    },
    mixins: [tableMixin, utilMixin],
    data() {
        return {
            fetchTitle: 'Markets',
            deleteTitle: 'Delete Market',
            detailComponent: 'market-detail',
            newMarket: {
                code: '',
                name: '',
                company: {}
            }
        }
    },
    computed: {
        ...mapState({ data: state => state.markets.markets })
    },
    methods: {
        ...mapActions('markets', ['fetch', 'delete'])
    }
}

</script>