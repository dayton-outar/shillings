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
                <financial-report :data="newReport" :editMode="false" v-if="isCreatePanelActive" @close="close" />
            </div>
        </div>

        <div class="columns"><!-- TODO: This can be refactored into a reusable component-->
            <div class="column is-full">
                <b-collapse class="card" animation="slide" aria-id="contentIdForIndSearch">
                    <template #trigger="props">
                        <div class="card-header" 
                            role="button" 
                            aria-controls="contentIdForIndSearch"
                            :aria-expanded="props.open">
                            <p class="card-header-title">
                                Search
                            </p>
                            <a class="card-header-icon">
                                <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'"></b-icon>
                            </a>
                        </div>
                    </template>

                    <div class="card-content">
                        <form @submit.prevent="get">
                            <div class="columns">
                                <div class="column">
                                    <b-field>
                                        <b-input 
                                            v-model="searchWord" 
                                            placeholder="Search ..." 
                                            type="Search"
                                            size="is-medium" 
                                            expanded></b-input>
                                        <div class="control">
                                            <b-button class="button is-primary" size="is-medium" native-type="submit">
                                                Search</b-button>
                                        </div>
                                    </b-field>
                                </div>
                            </div>
                        </form>
                    </div>
                </b-collapse>
            </div>
        </div>

        <div class="columns">
            <div class="column is-full">
                <div class="box my-4 mx-1">
                    <b-table
                        ref="tbl"
                        detailed 
                        :show-detail-icon="false"
                        :data="financialReports.nodes"
                        icon-pack="fas"
                        :total="financialReports.totalCount"
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
                            {{ formatDate(props.row.statementDate) }}
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
                            <financial-report 
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
import moment from 'moment'

import FinancialReport from './FinancialReport.vue'

export default {
    components: {
        'financial-report': FinancialReport,
    },
    data() {
        return {
            sort: ['statementDate', 'asc'],
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            searchWord: '',
            page: 10,
            pageLengths: [10, 20, 50, 100],
            currentPage: 1,
            forward: true,
            isCreatePanelActive: false,
            isLoading: false,
            newReport: {}
        }
    },
    created() {
        this.get()
    },
    methods: {
        ...mapActions('finances', ['fetch', 'delete']),
        get() {
            this.isLoading = true

            this.fetch({
                first: this.page,
                last: null,
                next: null,
                previous: null,
                filter: { company: { name: { startsWith: this.searchWord } } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = 1
            }).catch(err => {
                this.isLoading = false
                
                this.$buefy.dialog.alert({
                    title: `Financial Reports`,
                    message: `${err.message}`,
                    confirmText: 'OK',
                    type: 'is-danger',
                    hasIcon: true,
                    iconPack: 'fas',
                    icon: 'bug',
                    onConfirm: () => {
                        this.isLoading = false
                    }
                })
            })
        },
        create() {
            this.isCreatePanelActive = true
        },
        close(e) {
            this.isCreatePanelActive = false

            if (e === 'created') {
                //this.get()
            }
        },
        sortTable(field, order) {
            this.sort = [field, order]

            this.get()
        },
        pageChange(page) {
            this.isLoading = true
            
            this.forward = (page > this.currentPage)

            this.fetch({
                first: this.forward ? this.page : null,
                last: !this.forward ? this.page : null,
                next: this.forward ? this.financialReports.pageInfo.endCursor : null,
                previous: !this.forward ? this.financialReports.pageInfo.startCursor : null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = page
            }).catch(err => {
                this.isLoading = false
                
                this.$buefy.dialog.alert({
                    title: `Financial Reports`,
                    message: `${err.message}`,
                    confirmText: 'OK',
                    type: 'is-danger',
                    hasIcon: true,
                    iconPack: 'fas',
                    icon: 'triangle-exclamation',
                    onConfirm: () => {
                        this.isLoading = false
                    }
                })
            })
        },
        changeLen(l) {
            this.page = l

            this.get()
        },
        formatDate(stmtDate) {
            return moment(stmtDate).format('MMM DD, YYYY')
        }
    },
    computed: {
        ...mapState('finances', ['financialReports'])
    }
}

</script>