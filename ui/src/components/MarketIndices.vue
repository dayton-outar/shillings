<template>
    <div class="column is-full">
        <h2 class="title">Market Indices</h2>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column is-full">
                    <b-button 
                        label="Create New Market Index"
                        type="is-info"
                        size="is-medium"
                        @click.prevent="createIndex" />
                    
                    <b-modal
                        v-model="isModalActive"
                        has-modal-card
                        trap-focus
                        :destroy-on-hide="false"
                        aria-role="dialog"
                        aria-label="Create New Market Index"
                        close-button-aria-label="Close"
                        full-screen
                        aria-modal>
                        <template #default="props">
                            <div class="modal-card" style="width: auto">
                                <header class="modal-card-head">
                                    <p class="modal-card-title">Create New Market Index</p>
                                </header>
                                <section class="modal-card-body">
                                    <market-index-detail ref="frmIndex" :marketIndexData="newMarket" :editMode="false" @close="props.close" />
                                </section>
                                <footer class="modal-card-foot">
                                    <b-button
                                        label="Close"
                                        expanded
                                        @click.prevent="props.close" />
                                    <b-button
                                        label="Save"
                                        expanded
                                        type="is-info"
                                        @click.prevent="submit" />
                                </footer>
                            </div>
                        </template>
                    </b-modal>
                </div>
            </div>
            <b-table
                detailed
                :show-detail-icon="false"
                :data="marketIndices"
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
                            icon-right="pencil"
                            @click.prevent="props.toggleDetails(props.row)" />
                    </template>
                </b-table-column>

                <b-table-column width="5%" v-slot="props">
                    <template>
                        <b-button
                            size="is-small"
                            type="is-danger"
                            icon-right="delete"
                            @click.prevent="deleteItem(props.row.code)" />
                    </template>
                </b-table-column>

                <template #detail="props">
                    <article>
                        <h5 class="title is-5">{{ props.row.name }}</h5>
                        <market-index-detail :marketIndexData="props.row" :editMode="true" />
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
import { mapState, mapActions } from 'vuex'
import MarketIndex from './MarketIndex.vue'

export default {
    components: {
        'market-index-detail': MarketIndex,
    },
    data() {
        return {
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            page: 70,
            currentPage: 1,
            total: 0,
            isModalActive: false,
            newIndex: {}
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchMarketIndices', {
            first: 70,
            last: null,
            next: null,
            previous: null
        }).then(() => {
            //this.total = this.fullCompanies.totalCount;
        });
    },
    methods: {
        ...mapActions(['fetchMarketIndices']),
        createMarket() {
            this.newIndex = {
                no: 0,
                name: '',
                market: {}
            } // HACK: This is not refreshing the state. State is kept between events

            this.isModalActive = true
        },
        deleteItem() { //code
            // this.deleteCompany(code)
            //     .then(console.log)
            //     .catch(console.error);
        },
        pageChange() { //page // Credit: https://github.com/buefy/buefy/issues/50
            // this.fetchFullCompanies({
            //     first: (page > this.currentPage) ? this.page : null,
            //     last: (page < this.currentPage) ? this.page : null,
            //     next: (page > this.currentPage) ? this.fullCompanies.pageInfo.endCursor : null,
            //     previous: (page < this.currentPage) ? this.fullCompanies.pageInfo.startCursor : null
            // })
            // this.currentPage = page
        },
        submit() {
            this.$refs.frmIndex.submit()
        }
    },
    computed: {
        ...mapState(['marketIndices'])
    }
}

</script>