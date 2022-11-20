<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Country"
                        :type="validation.countryCode.type"
                        :message="validation.countryCode.message">
                        <b-select 
                            v-model="formData.countryCode"
                            placeholder="Choose Country"
                            expanded>
                            <option value="JM">Jamaica</option>
                            <option value="TT">Trinidad</option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">                   
                    <b-field
                        label="Date"
                        label-position="inside"
                        :type="validation.date.type"
                        :message="validation.date.message">
                        <b-datepicker
                            ref="datepicker"                    
                            v-model="rateDate"
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
                        label="Rate"
                        label-position="inside"
                        :type="validation.rate.type"
                        :message="validation.rate.message">
                        <b-input v-model="interestRate" />
                    </b-field>
                </div>
            </div>            
        </template>
        <template #confirm>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Country">
                        {{ formData.countryCode }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Date">
                        {{ formatDate( rateDate, 'dddd, MMM D, YYYY' ) }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Amount">
                        {{ formatPercentage( interestRate ) }}
                    </b-field>
                </div>
            </div>
        </template>
    </s-form>
</template>

<script>
import { mapActions } from 'vuex'

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
            createTitle: `Create Interest Rate Entry`,
            validation: {
                countryCode: {
                    type: '',
                    message: ''
                },
                date: {
                    type: '',
                    message: ''
                },
                rate: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    computed: {
        title() {
            return this.editMode ? `Update: ${this.data.countryCode}, ${this.formatDate(this.data.date, 'MMM-DD-YYYY')}` : this.createTitle
        },
        interestRate: {
            get() {
                return parseFloat( this.formData.rate ) * 100
            },
            set(value) {
                this.formData.rate = parseFloat( value ) / 100
            }
        },
        rateDate: {
            get() {
                return this.convertToDate(this.formData.date)
            },
            set(value) {
                this.formData.date = value
            }
        }
    },
    methods: {
        ...mapActions('rates', ['create', 'update']),
        assign() {
            this.formData.no = parseInt(this.formData.no, 10)
        },
        validate() {
            let valid = true

            if (!this.formData.countryCode) {
                this.validation.countryCode.type = 'is-danger'
                this.validation.countryCode.message = 'Please choose country'
                valid = false
            } else {
                this.validation.countryCode.type = ''
                this.validation.countryCode.message = ''
            }

            let vlu = this.parseMoney(this.formData.rate)
            if (!vlu) {
                this.validation.rate.type = 'is-danger'
                this.validation.rate.message = 'Please enter rate'
                valid = false
            } else {
                this.validation.rate.type = ''
                this.validation.rate.message = ''
            }

            this.isValid = valid
        }
    }
}

</script>
