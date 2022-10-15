<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="formData.code" :disabled="editMode"></b-input>
                    </b-field>
                </div>
            </div>
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
                        label="Issued Shares"
                        label-position="">
                        <b-numberinput 
                            v-model="formData.issuedShares"
                            icon-pack="fas"
                            type="is-info"
                            controls-position="compact"
                            expanded>
                        </b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Outstanding Shares"
                        label-position="">
                        <b-numberinput 
                            v-model="formData.outstandingShares"
                            icon-pack="fas"
                            type="is-info"
                            controls-position="compact"
                            expanded>
                        </b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Currency">
                        <b-select 
                            v-model="formData.currency"
                            placeholder="Choose Currency"
                            expanded>
                            <option value="JMD">Jamaican Dollar</option>
                            <option value="USD">US Dollar</option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Type">
                        <b-select 
                            v-model="formData.stockType"
                            placeholder="Choose Type"
                            expanded>
                            <option value="ORDINARY">Ordinary</option>
                            <option value="PREFFERRED">Preferred</option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Company">
                        <b-select 
                            v-model="formData.company"
                            placeholder="Choose Company"
                            expanded>
                            <option
                                v-for="company in companies.nodes" 
                                :key="company.code"
                                :value="company">
                                {{company.name}}
                            </option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Market Indices">
                        <b-dropdown
                            v-model="formData.indices"
                            multiple
                            scrollable
                            aria-role="list"
                            expanded>
                            <template #trigger>
                                <b-button
                                    type="is-light"
                                    expanded
                                    icon-right="menu-down">
                                    Selected ({{ formData.indices ? formData.indices.length : 0 }})
                                </b-button>
                            </template>

                            <b-dropdown-item aria-role="listitem" 
                                v-for="index in marketIndices.nodes" 
                                :key="index.no"
                                :value="index" :class="(formData.indices && formData.indices.some(i => i.no === index.no) ? 'is-active': '')">
                                {{index.name}}
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
                    label="Code">
                    {{ formData.code }}
                </b-field>
                </div>
            </div>
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
                    label="Issued Shares">
                    {{ formData.issuedShares }}
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Outstanding Shares">
                    {{ formData.outstandingShares }}
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Currency">
                    {{ formData.currency }}
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Type">
                    {{ formData.stockType }}
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Company">
                    {{ formData.company.name }}
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Market Indices">
                    <ul class="list">
                        <li class="list-item" v-for="index in marketIndices.nodes.filter(i => formData.indices.map(i => i.no).includes(i.no))" :key="index.no">{{index.name}}</li>
                    </ul>
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
            createTitle: 'Create Stock',
            validation: {
                code: {
                    type: '',
                    message: ''
                },
                name: {
                    type: '',
                    message: ''
                },
                wiki: {
                    type: '',
                    message: ''
                },
                webSite: {
                    type: '',
                    message: ''
                },
                founded: {
                    type: '',
                    message: ''
                },
                country: {
                    type: '',
                    message: ''
                },
                industries: {
                    type: '',
                    message: ''
                },
                logo: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    beforeCreate() {
        this.$store.dispatch('companies/fetch',{ // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
        this.$store.dispatch('indices/fetch', { // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
    },
    computed: {
        ...mapState(
            { 
                companies: state => state.companies.companies, 
                marketIndices: state => state.indices.indices
            })
    },
    methods: {
        ...mapActions('stocks', ['create', 'update'])
    }
}

</script>