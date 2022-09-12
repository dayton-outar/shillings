<template>
    <div class="column is-full">
        <h2 class="title">Stocks</h2>
        <div class="box my-4 mx-1">
            <b-table
                detailed
                :show-detail-icon="false"
                :data="fullStocks.nodes"
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
                        <stock-detail :stockData="props.row" :editMode="true" />
                    </article>
                </template>

            </b-table>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex'
import Stock from './Stock.vue'

export default {
    components: {
        'stock-detail': Stock,
    },
    data() {
        return {
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small'
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchFullStocks');        
    },
    computed: {
        ...mapState(['fullStocks'])
    }
}

</script>