<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside"
                        :type="validation.code.type"
                        :message="validation.code.message">
                        <b-input 
                            v-model="formData.code" 
                            placeholder="Unique code" 
                            :disabled="editMode" 
                            icon-pack="fas"
                            icon="file-code" 
                            type="text"
                            maxlength="20"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside"
                        :type="validation.name.type"
                        :message="validation.name.message">
                        <b-input 
                            v-model="formData.name" 
                            placeholder="Stock name"
                            icon-pack="fas"
                            icon="money-bill-trend-up" 
                            type="text"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Issued Shares"
                        label-position=""
                        :type="validation.issuedShares.type"
                        :message="validation.issuedShares.message">
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
                        label-position=""
                        :type="validation.outstandingShares.type"
                        :message="validation.outstandingShares.message">
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
                        label="Currency"
                        :type="validation.currency.type"
                        :message="validation.currency.message">
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
                        label="Stock Type"
                        :type="validation.stockType.type"
                        :message="validation.stockType.message">
                        <b-select 
                            v-model="formData.stockType"
                            placeholder="Choose Stock Type"
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
                        label="Company"
                        :type="validation.company.type"
                        :message="validation.company.message">
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
                        label="Market Indices"
                        :type="validation.indices.type"
                        :message="validation.indices.message">
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
                issuedShares: {
                    type: '',
                    message: ''
                },
                outstandingShares: {
                    type: '',
                    message: ''
                },
                currency: {
                    type: '',
                    message: ''
                },
                stockType: {
                    type: '',
                    message: ''
                },
                company: {
                    type: '',
                    message: ''
                },
                indices: {
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
        ...mapActions('stocks', ['create', 'update']),
        assign() {
            delete this.formData.company.logo
            this.formData.indices = this.formData.indices.map(i => {
                delete i.market.company.logo
                return i
            })
        },
        validate() {
            let valid = true

            if (!this.formData.code) {
                this.validation.code.type = 'is-danger'
                this.validation.code.message = 'Please enter unique code'
                valid = false
            } else {
                this.validation.code.type = ''
                this.validation.code.message = ''
            }

            if (!this.formData.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            if (!this.formData.issuedShares) {
                this.validation.issuedShares.type = 'is-danger'
                this.validation.issuedShares.message = 'Please enter issued shares'
                valid = false
            } else {
                this.validation.issuedShares.type = ''
                this.validation.issuedShares.message = ''
            }

            if (!this.formData.outstandingShares) {
                this.validation.outstandingShares.type = 'is-danger'
                this.validation.outstandingShares.message = 'Please enter outstanding shares'
                valid = false
            } else {
                this.validation.outstandingShares.type = ''
                this.validation.outstandingShares.message = ''
            }

            if (!this.formData.outstandingShares) {
                this.validation.outstandingShares.type = 'is-danger'
                this.validation.outstandingShares.message = 'Please enter outstanding shares'
                valid = false
            } else {
                this.validation.outstandingShares.type = ''
                this.validation.outstandingShares.message = ''
            }

            if (!this.formData.currency) {
                this.validation.currency.type = 'is-danger'
                this.validation.currency.message = 'Please choose currency'
                valid = false
            } else {
                this.validation.currency.type = ''
                this.validation.currency.message = ''
            }

            if (!this.formData.stockType) {
                this.validation.stockType.type = 'is-danger'
                this.validation.stockType.message = 'Please choose stock type'
                valid = false
            } else {
                this.validation.stockType.type = ''
                this.validation.stockType.message = ''
            }

            if (!this.formData.company) {
                this.validation.company.type = 'is-danger'
                this.validation.company.message = 'Please choose company'
                valid = false
            } else {
                this.validation.company.type = ''
                this.validation.company.message = ''
            }

            if (this.formData.indices.length == 0) {
                this.validation.indices.type = 'is-danger'
                this.validation.indices.message = 'Please choose at least one (1) market index'
                valid = false
            } else {
                this.validation.indices.type = ''
                this.validation.indices.message = ''
            }

            this.isValid = valid
        }

    }
}

</script>