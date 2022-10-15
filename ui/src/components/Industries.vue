<template>
    <div class="column is-full">
        <div class="columns">
            <div class="column">
                <b-button 
                    type="is-info"
                    size="is-medium"
                    icon-pack="fas"
                    icon-left="plus"
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newIndustry" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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
                            <a :href="props.row.wiki" target="_blank">{{ props.row.name }}</a>
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

import TableToolBar from './TableToolBar'
import SearchBar from './SearchBar.vue'
import Industry from './Industry.vue'

export default {
    components: {
        'industry-detail': Industry,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin],
    data() {
        return {
            fetchTitle: 'Industries',
            deleteTitle: 'Delete Industry',
            detailComponent: 'industry-detail',
            newIndustry: {
                no: 0,
                name: '',
                wiki: ''
            }
        }
    },
    created() {
        this.get()
    },
    methods: {
        ...mapActions('industries', ['fetch', 'delete']),
        create() {
            this.newIndustry.no += 1

            this.isCreatePanelActive = true
        }
    },
    computed: {
        ...mapState({ data: state => state.industries.industries })
    }
}

</script>