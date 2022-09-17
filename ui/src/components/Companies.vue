<template>
    <div class="column is-full">
        <h2 class="title">Companies</h2>
        <div class="box my-4 mx-1">
            <b-table
                detailed
                :show-detail-icon="false"
                :data="fullCompanies.nodes"
                :sort-icon="sortIcon" 
                :sort-icon-size="sortIconSize"
                :default-sort-direction="defaultSortDirection" 
                :striped="true" 
                :hoverable="true"
                :paginated="true">
            
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

                <b-table-column width="5%">
                    <template>
                        <b-button
                            size="is-small"
                            type="is-danger"
                            icon-right="delete" />
                    </template>
                </b-table-column>

                <template #detail="props">
                    <article>
                        <h5 class="title is-5">{{ props.row.name }}</h5>
                        <company-detail :companyData="props.row" :editMode="true" />
                    </article>
                </template>

            </b-table>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex'
import Company from './Company.vue'

export default {
    components: {
        'company-detail': Company,
    },
    data() {
        return {
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small'
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchFullCompanies');
    },
    methods: {},
    computed: {
        ...mapState(['fullCompanies'])
    }
}

</script>