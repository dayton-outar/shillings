<template>
    <div class="column is-full">
        <h2 class="title">Companies</h2>

        <div class="columns">
            <div class="column is-full">
                <b-button 
                    type="is-info" 
                    size="is-medium" 
                    icon-pack="fas" 
                    icon-left="plus" 
                    v-if="!isCreatePanelActive"
                    @click.prevent="create" />
                <component :is="detailComponent" :data="newCompany" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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

                        <b-table-column field="name" label="Company" sortable v-slot="props">
                            <company-tag :data="props.row" />
                        </b-table-column>

                        <b-table-column field="founded" label="Founded" sortable v-slot="props" width="5%">
                            {{ foundedYear(props.row.founded) }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button size="is-small" type="is-light" icon-pack="fas" icon-right="circle-info" rounded
                                    @click.prevent="view(props)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button size="is-small" type="is-info" icon-pack="fas" icon-right="pen-to-square"
                                    @click.prevent="edit(props)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button size="is-small" type="is-danger" icon-pack="fas" icon-right="trash"
                                    @click.prevent="deleteRow(props.row)" />
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

import config from '../config'
import tableMixin from '../utils/tableMixin'
import utilMixin from '../utils/utilMixin'

import SearchBar from './SearchBar.vue'
import TableToolBar from './TableToolBar'
import Company from './Company.vue'
import ViewCompany from './ViewCompany.vue'
import CompanyTag from './CompanyTag.vue'

export default {
    components: {
        'company-detail': Company,
        'company-info': ViewCompany,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar,
        'company-tag': CompanyTag
    },
    mixins: [tableMixin, utilMixin],
    data() {
        return {
            fetchTitle: 'Companies',
            deleteTitle: 'Delete Company',
            detailComponent: 'company-detail',
            fileApiHost: config.fileApiHost,
            newCompany: {
                code: '',
                name: '',
                about: '',
                totalEmployed: 0,
                wiki: '',
                webSite: '',
                founded: new Date(),
                countryCode: '',
                created: new Date(),
                industries: [],
                files: []
            }
        }
    },
    computed: {
        ...mapState({ data: state => state.companies.companies })
    },
    methods: {
        ...mapActions('companies', ['fetch', 'delete']),
        view(props) {
            this.detailComponent = 'company-info'
            props.toggleDetails(props.row)
        },
        edit(props) {
            this.detailComponent = 'company-detail'
            props.toggleDetails(props.row)
        },
        foundedYear(founded) {
            return this.convertToDate(founded).getFullYear()
        }
    }
}

</script>