<template>
    <div class="column is-full">
        <h2 class="title">Companies</h2>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column is-full">
                    <b-button 
                        label="Create New Company"
                        type="is-primary"
                        size="is-medium"
                        @click.prevent="isModalActive = true" />
                    
                    <b-modal
                        v-model="isModalActive"
                        has-modal-card
                        trap-focus
                        :destroy-on-hide="false"
                        aria-role="dialog"
                        aria-label="Example Modal"
                        close-button-aria-label="Close"
                        aria-modal>
                        <template>
                            <div class="modal-card" style="width: auto">
                                <header class="modal-card-head">
                                    <p class="modal-card-title">Create New Company</p>
                                    <!--<button
                                        type="button"
                                        class="delete"
                                        @click="$emit('close')"/>-->
                                </header>
                                <section class="modal-card-body">
                                    <company-detail :companyData="newCompany" :editMode="false" />
                                </section>
                            </div>
                        </template>
                    </b-modal>
                </div>
            </div>
            <b-table
                detailed
                :show-detail-icon="false"
                :data="fullCompanies.nodes"
                :sort-icon="sortIcon" 
                :sort-icon-size="sortIconSize"
                :default-sort-direction="defaultSortDirection" 
                :striped="true" 
                :hoverable="true">
            
                <b-table-column v-slot="props" width="5%">
                    <figure class="image is-32x32">
                        <img class="is-rounded" :src="(props.row.logo ? `http://localhost:5000/files?no=${props.row.logo.no}` :`https://bulma.io/images/placeholders/128x128.png`)">
                    </figure>
                </b-table-column>

                <b-table-column field="code" label="Code" sortable v-slot="props" width="5%">
                    {{ props.row.code }}
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
                        <company-detail :companyData="props.row" :editMode="true" />
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
import Company from './Company.vue'

export default {
    components: {
        'company-detail': Company,
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
                logo: {},
                files: []
            }
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchFullCompanies', {
            first: 70,
            last: null,
            next: null,
            previous: null
        }).then(() => {
            this.total = this.fullCompanies.totalCount;
        });
    },
    methods: {
        ...mapActions(['deleteCompany', 'fetchFullCompanies']),
        createCompany() {
            
        },
        deleteItem(code) {
            this.deleteCompany(code)
                .then(console.log)
                .catch(console.error);
        },
        pageChange(page) { // Credit: https://github.com/buefy/buefy/issues/50
            this.fetchFullCompanies({
                first: (page > this.currentPage) ? this.page : null,
                last: (page < this.currentPage) ? this.page : null,
                next: (page > this.currentPage) ? this.fullCompanies.pageInfo.endCursor : null,
                previous: (page < this.currentPage) ? this.fullCompanies.pageInfo.startCursor : null
            })
            this.currentPage = page
        }
    },
    computed: {
        ...mapState(['fullCompanies'])
    }
}

</script>