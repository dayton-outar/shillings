<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="formData.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Market">
                        <b-select 
                            v-model="formData.market"
                            placeholder="Choose Market"
                            expanded>
                            <option
                                v-for="market in markets.nodes" 
                                :key="market.code"
                                :value="market">
                                {{market.name}}
                            </option>
                        </b-select>
                    </b-field>
                </div>
            </div>
        </template>
        <template #confirm>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Name">
                        {{ formData.name }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Market">
                        {{ formData.market.name }}
                    </b-field>
                </div>
            </div>
        </template>
    </s-form>
</template>

<script>
import { mapState, mapActions } from 'vuex' 
// import moment from 'moment'

import formMixin from '../utils/formMixin'

import Form from './Form.vue'

export default {
    components: {
        's-form': Form,
    },
    mixins: [formMixin],
    data() {
        return {
            createTitle: `Create Market Index`,
        }
    },
    beforeCreate() {
        this.$store.dispatch('markets/fetch', { // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
    },
    computed: {
        ...mapState('markets', ['markets'])
    },
    methods: {
        ...mapActions('indices', ['create', 'update'])
    }
}

</script>