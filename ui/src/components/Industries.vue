<template>
    <div class="column is-full">
        <h2 class="title">Industries</h2>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column is-full">
                    <b-button 
                        label="Create New Industry"
                        type="is-info"
                        size="is-medium"
                        v-if="!isCreatePanelActive"
                        @click.prevent="createIndustry" />
                    <industry-detail ref="frm" :industryData="newIndustry" :editMode="false" v-if="isCreatePanelActive" @close="closeCreatePanel" />
                </div>
            </div>
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
                            @click.prevent="deleteItem(props.row)" />
                    </template>
                </b-table-column>

                <template slot="detail" slot-scope="props">
                    <article>
                        <h5 class="title is-5">{{ props.row.name }}</h5>
                        <industry-detail :industryData="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" />
                    </article>
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
        </div>
    </div>
</template>

<script>
import { mapState, mapActions, mapMutations } from 'vuex'
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
            page: 20,
            currentPage: 1,
            forward: true,
            isCreatePanelActive: false,
            newIndustry: {
                no: 0,
                name: '',
                wiki: ''
            }
        }
    },
    created() {
        this.fetch({
            first: this.page,
            last: null,
            next: null,
            previous: null,
            ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
        }).then(() => {

        }).catch(err => {
            console.log(err)
        })
    },
    methods: {
        ...mapActions('industries', ['fetch']),
        ...mapMutations('industries', ['remove']),
        createIndustry() {
            this.newIndustry.no += 1

            this.isCreatePanelActive = true
        },
        deleteItem(row) {
            this.remove({
                type: 'industries',
                pk: 'no',
                payload: row
            })
        },
        sortTable(field, order) {
            this.sort = [field, order]            

            this.fetch({
                first: this.page,
                last: null,
                next: null,
                previous: null,
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.currentPage = 1
            }).catch(err => {
                console.log(err)
            })
        },
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.forward = (page > this.currentPage)

            this.fetch({
                first: this.forward ? this.page : null,
                last: !this.forward ? this.page : null,
                next: this.forward ? this.industries.pageInfo.endCursor : null,
                previous: !this.forward ? this.industries.pageInfo.startCursor : null,
                ordering: [{ [this.sort[0]]: this.sort[1].toUpperCase() }]
            }).then(() => {
                this.currentPage = page
            }).catch(err => {
                console.log(err)
            })
        },
        closeCreatePanel() {
            this.isCreatePanelActive = false
        }
    },
    computed: {
        ...mapState('industries', ['industries'])
    }
}

</script>