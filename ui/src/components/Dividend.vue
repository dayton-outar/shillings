<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns" v-if="!editMode">
                <div class="column">
                    <b-field
                        label="Stock"
                        :type="validation.stock.type"
                        :message="validation.stock.message">
                        <b-select 
                            v-model="formData.stock"
                            placeholder="Choose Stock"
                            expanded>
                            <option
                                v-for="stock in stocks.nodes" 
                                :key="stock.no"
                                :value="stock">
                                {{stock.name}}
                            </option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">                   
                    <b-field
                        label="Record Date"
                        label-position="inside"
                        :type="validation.recordDate.type"
                        :message="validation.recordDate.message">
                        <b-datepicker
                            ref="datepicker"                    
                            v-model="recordDate"
                            label-position=""
                            placeholder="Set Date"
                            icon-pack="fas"
                            expanded>
                        </b-datepicker>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">                   
                    <b-field
                        label="Payment Date"
                        label-position="inside"
                        :type="validation.paymentDate.type"
                        :message="validation.paymentDate.message">
                        <b-datepicker
                            ref="datepicker"                    
                            v-model="paymentDate"
                            label-position=""
                            placeholder="Set Date"
                            icon-pack="fas"
                            expanded>
                        </b-datepicker>
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
                            <option value="JMD">JMD</option>
                            <option value="USD">USD</option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Amount"
                        label-position="inside"
                        :type="validation.amount.type"
                        :message="validation.amount.message">
                        <b-input v-model="formData.amount" />
                    </b-field>
                </div>
            </div>            
        </template>
        <template #confirm>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Stock">
                        {{ formData.stock.name }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Record Date">
                        {{ formatDate( formData.recordDate, 'dddd, MMM D, YYYY' ) }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Payment Date">
                        {{ formatDate( formData.paymentDate, 'dddd, MMM D, YYYY' ) }}
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
                        label="Amount">
                        {{ formatMoney( formData.amount ) }}
                    </b-field>
                </div>
            </div>
        </template>
    </s-form>
</template>

<script>
import { mapState, mapActions } from 'vuex'

import formMixin from '../utils/formMixin'
import utilMixin from '../utils/utilMixin'

import Form from './Form.vue'

export default {
    components: {
        's-form': Form,
    },
    mixins: [formMixin, utilMixin],
    data() {
        return {
            createTitle: `Create Dividend Entry`,
            validation: {
                stock: {
                    type: '',
                    message: ''
                },
                recordDate: {
                    type: '',
                    message: ''
                },
                paymentDate: {
                    type: '',
                    message: ''
                },
                currency: {
                    type: '',
                    message: ''
                },
                amount: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    beforeCreate() {
        this.$store.dispatch('stocks/fetch', { // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
    },
    computed: {
        ...mapState('stocks', ['stocks']),
        title() {
            return this.editMode ? `Update: ${this.data.stock.name}, ${this.formatDate(this.data.paymentDate, 'MMM-DD-YYYY')}` : this.createTitle
        },
        recordDate: {
            get() {
                return this.convertToDate(this.formData.recordDate)
            },
            set(value) {
                this.formData.recordDate = value
            }
        },
        paymentDate: {
            get() {
                return this.convertToDate(this.formData.paymentDate)
            },
            set(value) {
                this.formData.paymentDate = value
            }
        }
    },
    methods: {
        ...mapActions('dividends', ['create', 'update']),
        assign() {
            this.formData.no = parseInt(this.formData.no, 10)
            this.formData.amount = this.parseMoney( this.formData.amount ) // TODO: Vue3 ... VueCurrency component
        },
        validate() {
            let valid = true

            if (!this.formData.stock) {
                this.validation.stock.type = 'is-danger'
                this.validation.stock.message = 'Please choose stock'
                valid = false
            } else {
                this.validation.stock.type = ''
                this.validation.stock.message = ''
            }

            let vlu = this.parseMoney(this.formData.amount)
            if (!vlu) {
                this.validation.amount.type = 'is-danger'
                this.validation.amount.message = 'Please enter amount'
                valid = false
            } else {
                this.validation.amount.type = ''
                this.validation.amount.message = ''
            }

            this.isValid = valid
        }
    }
}

</script>
