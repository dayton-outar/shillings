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
                <company-detail :data="newCompany" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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
                            <article class="media">
                                <figure class="media-left">
                                    <div class="image is-48x48">
                                        <img class="is-rounded"
                                            :src="(props.row.logo ? `http://localhost:5000/files?no=${props.row.logo.no}` : require(`../assets/no-image.png`))" />
                                    </div>
                                </figure>
                                <div class="media-content">
                                    <p v-if="props.row.webSite"><a :href="props.row.webSite"
                                            target="_blank">{{props.row.name}}</a></p>
                                    <p v-else>{{ props.row.name }}</p>
                                    <p class="has-text-weight-light">{{ props.row.code }}</p>
                                </div>
                            </article>

                        </b-table-column>

                        <b-table-column field="founded" label="Founded" sortable v-slot="props" width="5%">
                            {{ foundedYear(props.row.founded) }}
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button size="is-small" type="is-info" icon-pack="fas" icon-right="pen-to-square"
                                    @click.prevent="props.toggleDetails(props.row)" />
                            </template>
                        </b-table-column>

                        <b-table-column width="5%" v-slot="props">
                            <template>
                                <b-button size="is-small" type="is-danger" icon-pack="fas" icon-right="trash"
                                    @click.prevent="deleteRow(props.row)" />
                            </template>
                        </b-table-column>

                        <template #detail="props">
                            <article>
                                <h5 class="title is-5">{{ props.row.name }}</h5>
                                <company-detail :data="props.row" :editMode="true"
                                    @close="$refs.tbl.toggleDetails(props.row)" />
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
import moment from 'moment'

import tableMixin from '../mixins/tableMixin'

import SearchBar from './SearchBar.vue'
import TableToolBar from './TableToolBar'
import Company from './Company.vue'

export default {
    components: {
        'company-detail': Company,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    mixins: [tableMixin],
    data() {
        return {
            fetchTitle: 'Companies',
            deleteTitle: 'Delete Company',
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
    methods: {
        ...mapActions('companies', ['fetch', 'delete']),
        foundedYear(founded) {
            return moment(founded).toDate().getFullYear()
        }
    },
    computed: {
        ...mapState({ data: state => state.companies.companies })
    }
}

</script>