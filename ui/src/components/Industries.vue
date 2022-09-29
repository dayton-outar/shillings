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
                        v-show="!isCreatePanelActive"
                        @click.prevent="createIndustry" />
                    <industry-detail ref="frm" :industryData="newIndustry" :editMode="false" v-show="isCreatePanelActive" @close="closeCreatePanel" />
                </div>
            </div>
            <b-table
                ref="tbl"
                detailed
                :show-detail-icon="false"
                :data="industries.nodes"
                :sort-icon="sortIcon" 
                :sort-icon-size="sortIconSize"
                :default-sort-direction="defaultSortDirection" 
                :striped="true" 
                :hoverable="true">

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
                :total="total"
                :current="currentPage"
                :simple="true"
                :per-page="page"
                order="is-right"
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
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            page: 20,
            currentPage: 1,
            total: 0,
            isCreatePanelActive: false,
            newIndustry: {},
            counter: 0
        }
    },
    created() {
        // this.fetch({
        //     first: 100,
        //     last: null,
        //     next: null,
        //     previous: null
        // }).then(() => {
        //     this.total = this.industries.totalCount;
        // }).catch(err => {
        //     console.log(err)
        // })
    },
    methods: {
        ...mapActions('industries', ['fetch']),
        ...mapMutations('industries', ['remove']),
        createIndustry() {
            this.counter += 1
            this.newIndustry = {
                no: this.counter,
                name: '',
                wiki: ''
            }

            this.isCreatePanelActive = true
        },
        deleteItem(row) {
            this.remove({
                type: 'industries',
                pk: 'no',
                payload: row
            })
            this.total = this.industries.totalCount
        },
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.fetch({
                first: (page > this.currentPage) ? this.page : null,
                last: (page < this.currentPage) ? this.page : null,
                next: (page > this.currentPage) ? this.industries.pageInfo.endCursor : null,
                previous: (page < this.currentPage) ? this.industries.pageInfo.startCursor : null
            }).then(() => {
                this.total = this.industries.totalCount;
            }).catch(err => {
                console.log(err)
            })

            this.currentPage = page
        },
        closeCreatePanel() {
            this.isCreatePanelActive = false
            this.total = this.industries.totalCount
        }
    },
    computed: {
        ...mapState('industries', ['industries'])
    }
}

</script>