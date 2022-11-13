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
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Industries"
                    :type="validation.industries.type"
                    :message="validation.industries.message">                    
                    <b-dropdown
                        v-model="indexIndustries"
                        multiple
                        scrollable
                        aria-role="list"
                        expanded>
                        <template #trigger>
                        <b-button
                            type="is-light"
                            expanded
                            icon-right="menu-down">
                            Selected ({{ indexIndustries.length }})
                        </b-button>
                        </template>

                        <b-dropdown-item aria-role="listitem" 
                        v-for="industry in industries.nodes" 
                        :key="industry.no"
                        :value="industry.no">
                        {{industry.name}}
                        </b-dropdown-item>

                    </b-dropdown>                    
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
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Industries">
                    <ul class="list">
                        <li class="list-item" v-for="industry in industries.nodes.filter(i => indexIndustries.includes(i.no))" :key="industry.no">{{industry.name}}</li>
                    </ul>
                </b-field>
                </div>
            </div>
        </template>
    </s-form>
</template>

<script>
import { mapState, mapActions } from 'vuex'

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
            indexIndustries: this.data.industries.map(i => i.no),
            validation: {
                name: {
                    type: '',
                    message: ''
                },
                industries: {
                    type: '',
                    message: ''
                }
            }
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
        
        this.$store.dispatch('industries/fetch', { // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
    },
    computed: {
        ...mapState('markets', ['markets']),
        ...mapState('industries', ['industries']),
    },
    methods: {
        ...mapActions('indices', ['create', 'update']),
        assign() {
            this.formData.no = parseInt(this.formData.no, 10)
            this.formData.industries = this.industries.nodes.filter(i => this.indexIndustries.includes(i.no))
        },
        validate() {
            let valid = true

            if (!this.formData.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            // if (this.indexIndustries.length == 0) {
            //     this.validation.industries.type = 'is-danger'
            //     this.validation.industries.message = 'Please choose at least one (1) industry'
            //     valid = false
            // } else {
            //     this.validation.industries.type = ''
            //     this.validation.industries.message = ''
            // }

            this.isValid = valid
        }
    }
}

</script>