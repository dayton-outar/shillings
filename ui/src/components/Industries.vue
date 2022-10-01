<template>
    <div class="column is-full">
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column is-full">
                    <b-button 
                        label="Create New Industry"
                        type="is-info"
                        size="is-medium"
                        v-if="!isCreatePanelActive"
                        @click.prevent="create" />
                    <industry-detail ref="frm" :industryData="newIndustry" :editMode="false" v-if="isCreatePanelActive" @close="close" />
                </div>
            </div>
            <div class="columns">
                <div class="column is-full">
                    <b-collapse 
                        class="card" 
                        animation="slide" 
                        aria-id="contentIdForIndSearch">
                        <template #trigger="props">
                            <div
                                class="card-header"
                                role="button"
                                aria-controls="contentIdForIndSearch"
                                :aria-expanded="props.open">
                                <p class="card-header-title">
                                    Search
                                </p>
                                <a class="card-header-icon">
                                    <b-icon
                                        pack="fas"
                                        :icon="props.open ? 'caret-down' : 'caret-up'">
                                    </b-icon>
                                </a>
                            </div>
                        </template>

                        <div class="card-content">
                            <form @submit.prevent="search">
                                <div class="columns">
                                    <div class="column">
                                        <b-field :label-position="labelPosition">
                                            <b-input 
                                                v-model="searchWord"
                                                placeholder="Search ..." 
                                                type="Search" 
                                                size="is-medium"
                                                expanded></b-input>
                                            <div class="control">
                                                <b-button 
                                                    class="button is-primary"
                                                    size="is-medium"
                                                    native-type="submit">Search</b-button>
                                            </div>
                                        </b-field>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </b-collapse>
                </div>
            </div>

            <b-dropdown
                v-model="page"
                aria-role="list"
                @change="search">
                <template #trigger>
                    <b-button
                        :label="page.toString()"
                        type="is-primary" />
                </template>

                <b-dropdown-item
                    v-for="(len, index) in pageLengths"
                    :key="index"
                    :value="len" aria-role="listitem">
                    {{ len }}
                </b-dropdown-item>
            </b-dropdown>

            <b-table
                ref="tbl"
                detailed
                icon-pack="fas"
                :show-detail-icon="false"
                :data="industries.nodes"
                :sort-icon="sortIcon" 
                :sort-icon-size="sortIconSize"
                :default-sort="sort"
                :backend-sorting="true"
                :backend-pagination="true"
                :striped="true" 
                :hoverable="true"
                @sort="sortTable">

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
                            icon-right="pen-to-square"
                            @click.prevent="props.toggleDetails(props.row)"
                            @close="console.log('Ooh!')" />
                    </template>
                </b-table-column>

                <b-table-column width="5%" v-slot="props">
                    <template>
                        <b-button
                            size="is-small"
                            type="is-danger"
                            icon-pack="fas"
                            icon-right="trash"
                            @click.prevent="delete(props.row)" />
                    </template>
                </b-table-column>

                <template slot="detail" slot-scope="props">
                    <industry-detail :industryData="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" />
                </template>

                <template #empty>
                    <div class="has-text-centered">No records</div>
                </template>

            </b-table>
            <b-pagination
                :total="industries.totalCount"
                :current="currentPage"
                :simple="true"
                :per-page="page"
                order="is-right"
                icon-pack="fas"
                @change="pageChange">
            </b-pagination>
            <b-loading :is-full-page="false" v-model="isLoading"></b-loading>
        </div>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import Industry from './Industry.vue'

export default {
    components: {
        'industry-detail': Industry,
    },
    data() {
        return {
            sort: ['name', 'asc'],
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            searchWord: '',
            page: 20,
            pageLengths: [20, 50, 100],
            currentPage: 1,
            forward: true,
            isCreatePanelActive: false,
            isLoading: false,
            newIndustry: {
                no: 0,
                name: '',
                wiki: ''
            },
            labelPosition: 'on-border'
        }
    },
    created() {
        this.isLoading = true

        this.get({
            first: this.page,
            last: null,
            next: null,
            previous: null,
            filter: { name: { startsWith: this.searchWord } },
            ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
        })
    },
    methods: {
        ...mapActions('industries', ['fetch', 'delete']),
        get(request) {

            this.fetch(request).then(() => {
                this.isLoading = false
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
        create() {
            this.newIndustry.no += 1

            this.isCreatePanelActive = true
        },
        close() {
            this.isCreatePanelActive = false
        },
        delete(row) {
            console.log(row)
            // this.remove({
            //     type: 'industries',
            //     pk: 'no',
            //     payload: row
            // })
        },
        sortTable(field, order) {
            this.sort = [field, order]

            this.get({
                first: this.page,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            })
        },
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.forward = (page > this.currentPage)

            this.get({
                first: this.forward ? this.page : null,
                last: !this.forward ? this.page : null,
                next: this.forward ? this.industries.pageInfo.endCursor : null,
                previous: !this.forward ? this.industries.pageInfo.startCursor : null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            })
        },
        search() {
            this.get({
                first: this.page,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: this.searchWord } },
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            })
        }
    },
    computed: {
        ...mapState('industries', ['industries'])
    }
}

</script>