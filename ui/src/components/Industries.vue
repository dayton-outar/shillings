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
                            @click.prevent="deleteItem(props.row.no)" />
                    </template>
                </b-table-column>

                <template slot="detail" slot-scope="props">
                    <article>
                        <h5 class="title is-5">{{ props.row.name }}</h5>
                        <industry-detail :industryData="props.row" :editMode="true" @close="$refs.tbl.toggleDetails(props.row)" />
                    </article>
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
    beforeCreate() {
        // this.$store.dispatch('industries/fetch', {
        //     first: 100,
        //     last: null,
        //     next: null,
        //     previous: null
        // }).then(() => {
        //     this.total = this.industries.totalCount;
        // }).catch(err => {
        //     console.log(err)
        // });
    },
    methods: {
        ...mapActions('industries', ['fetch']),
        ...mapMutations('industries', ['add', 'remove']),
        createIndustry() {
            this.counter += 1
            this.newIndustry = {
                no: this.counter,
                name: '',
                wiki: ''
            }

            this.isCreatePanelActive = true

            // this.total += 1
        },
        deleteItem(no) {
            this.remove(no)

            this.total -= 1
        },
        pageChange() { //page // Credit: https://github.com/buefy/buefy/issues/50
            // this.fetch({
            //     first: (page > this.currentPage) ? this.page : null,
            //     last: (page < this.currentPage) ? this.page : null,
            //     next: (page > this.currentPage) ? this.fullCompanies.pageInfo.endCursor : null,
            //     previous: (page < this.currentPage) ? this.fullCompanies.pageInfo.startCursor : null
            // })
            // this.currentPage = page
        },
        closeCreatePanel() {
            this.isCreatePanelActive = false
        },
        submit() {
            this.$refs.frm.submit()
        }
    },
    computed: {
        ...mapState('industries', ['industries'])
    }
}

</script>