<template>
    <div class="column is-full">
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-button 
                        type="is-info"
                        size="is-medium"
                        icon-pack="fas"
                        icon-left="plus"
                        v-if="!isCreatePanelActive"
                        @click.prevent="create" />
                    <industry-detail :industryData="newIndustry" :editMode="false" v-if="isCreatePanelActive" @close="close" />
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
                            :data="industries.nodes"
                            icon-pack="fas"
                            :total="industries.totalCount"
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
                                <industry-detail :industryData="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" />
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
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import TableToolBar from './TableToolBar'
import SearchBar from './SearchBar.vue'
import Industry from './Industry.vue'

export default {
    components: {
        'industry-detail': Industry,
        'search-bar': SearchBar,
        'table-tool-bar': TableToolBar
    },
    data() {
        return {
            sort: ['name', 'asc'],
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            searchWord: '',
            page: 10,
            pageLengths: [10, 20, 50, 100],
            currentPage: 1,
            forward: true,
            isCreatePanelActive: false,
            isLoading: false,
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
        get() {
            this.isLoading = true

            this.fetch({
                first: this.page,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = 1
            }).catch(err => {
                this.isLoading = false
                
                this.$buefy.dialog.alert({
                    title: `Industries`,
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
        find(q) {
            this.searchWord = q.searchWord
            this.get()
        },
        create() {
            this.newIndustry.no += 1

            this.isCreatePanelActive = true
        },
        close(e) {            
            this.isCreatePanelActive = false

            if (e === 'created') {
                //this.get()
            }
        },
        deleteRow(row) {

            this.$buefy.dialog.confirm({
                title: `Delete Industry`,
                message: `<p>Are you sure you want to <b>delete</b> ${row.name}?</p><p>This action cannot be undone.</p>`,
                confirmText: 'OK',
                type: 'is-warning',
                hasIcon: true,
                iconPack: 'fas',
                icon: 'circle-exclamation',
                onConfirm: () => {
                    this.isLoading = true
                    
                    this.delete(row)
                        .then(success => {
                            this.isLoading = false
                            
                            if (success) {
                                this.$buefy.dialog.alert({
                                    title: `Delete Industry`,
                                    message: `Successfully deleted ${row.name}`,
                                    confirmText: 'OK',
                                    type: 'is-success',
                                    hasIcon: true,
                                    iconPack: 'fas',
                                    icon: 'circle-check',
                                    onConfirm: () => {                                
                                        this.$emit('close')
                                        //this.get()
                                    }
                                })
                            } else {
                                this.$buefy.dialog.alert({
                                    title: `Delete Industry`,
                                    message: `Failed to delete ${row.name}`,
                                    confirmText: 'OK',
                                    type: 'is-danger',
                                    hasIcon: true,
                                    iconPack: 'fas',
                                    icon: 'bomb'
                                })
                            }
                        })
                        .catch(err => {    
                            this.isLoading = false

                            this.$buefy.dialog.alert({
                                title: `Delete Industry`,
                                message: `${err.message}`,
                                confirmText: 'OK',
                                type: 'is-danger',
                                hasIcon: true,
                                iconPack: 'fas',
                                icon: 'bug'
                            })
                        })
                }
            })
            
        },
        sortTable(field, order) {
            this.sort = [field, order]

            this.get()
        },
        // HACK: There's a bug here
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.isLoading = true
            
            this.forward = (page > this.currentPage)

            this.fetch({
                first: this.forward ? this.page : null,
                last: !this.forward ? this.page : null,
                next: this.forward ? this.industries.pageInfo.endCursor : null,
                previous: !this.forward ? this.industries.pageInfo.startCursor : null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = page
            }).catch(err => {
                this.isLoading = false
                
                this.$buefy.dialog.alert({
                    title: `Industries`,
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
        }
    },
    computed: {
        ...mapState('industries', ['industries'])
    }
}

</script>