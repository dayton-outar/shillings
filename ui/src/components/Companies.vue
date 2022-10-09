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
                <company-detail :companyData="newCompany" :editMode="false" v-if="isCreatePanelActive" @close="close" />
            </div>
        </div>

        <div class="columns">
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
                    <nav class="level">
                        <div class="level-left">
                            <div class="level-item">
                                <b-dropdown 
                                    v-model="page" 
                                    aria-role="list" 
                                    @change="changeLen">
                                    <template #trigger>
                                        <b-button :label="page.toString()" type="is-info" />
                                    </template>

                                    <b-dropdown-item v-for="(len, index) in pageLengths" :key="index" :value="len"
                                        aria-role="listitem">
                                        {{ len }}
                                    </b-dropdown-item>
                                </b-dropdown>
                            </div>
                        </div>

                        <div class="level-right">
                            <div class="level-item">
                                <b-button type="is-info" icon-pack="fas" icon-left="refresh" @click.prevent="get" />
                            </div>
                        </div>
                    </nav>

                    <b-table 
                        ref="tbl" 
                        detailed 
                        :show-detail-icon="false" 
                        :data="companies.nodes" 
                        icon-pack="fas"
                        :total="companies.totalCount" 
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
                                <company-detail :companyData="props.row" :editMode="true"
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

import Company from './Company.vue'

export default {
    components: {
        'company-detail': Company,
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
    created() {
        this.get()
    },
    methods: {
        ...mapActions('companies', ['fetch', 'delete']),
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
                    title: `Companies`,
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
            console.log(e)
            this.isCreatePanelActive = false

            if (e === 'created') {
                //this.get()
            }
        },
        deleteRow(row) {

            this.$buefy.dialog.confirm({
                title: `Delete Company`,
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
                                    title: `Delete Company`,
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
                                    title: `Delete Company`,
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
                                title: `Delete Company`,
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
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.isLoading = true
            
            this.forward = (page > this.currentPage)

            this.fetch({
                first: this.forward ? this.page : null,
                last: !this.forward ? this.page : null,
                next: this.forward ? this.companies.pageInfo.endCursor : null,
                previous: !this.forward ? this.companies.pageInfo.startCursor : null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.isLoading = false
                this.currentPage = page
            }).catch(err => {
                this.isLoading = false
                
                this.$buefy.dialog.alert({
                    title: `Companies`,
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
        foundedYear(founded) {
            return moment(founded).toDate().getFullYear()
        }
    },
    computed: {
        ...mapState('companies', ['companies'])
    }
}

</script>