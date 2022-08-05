<template>
    <div class="column is-full">
        <div class="box my-4 mx-1">
            <b-table
                :data="fullCompanies.nodes"
                :sort-icon="sortIcon" 
                :sort-icon-size="sortIconSize"
                :default-sort-direction="defaultSortDirection" 
                :striped="true" 
                :hoverable="true">
            
                <b-table-column field="code" label="Code" sortable v-slot="props" width="5%">
                    {{ props.row.code }}
                </b-table-column>

                <b-table-column field="name" label="Name" sortable v-slot="props">
                    {{ props.row.name }}
                </b-table-column>

                <b-table-column width="5%">
                    <template>
                        <b-button
                            size="is-small"
                            type="is-info"
                            icon-right="pencil" />
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

            </b-table>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
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
    computed: {
        ...mapState(['fullCompanies'])
    }
}

</script>