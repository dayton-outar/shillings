<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns" v-if="!editMode">
                <div class="column">
                    <b-field
                        label="Market"
                        :type="validation.marketIndex.type"
                        :message="validation.marketIndex.message">
                        <b-select 
                            v-model="formData.marketIndex"
                            placeholder="Choose Market Index"
                            expanded>
                            <option
                                v-for="index in indices.nodes" 
                                :key="index.no"
                                :value="index">
                                {{index.name}}
                            </option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Value"
                        label-position="inside"
                        :type="validation.value.type"
                        :message="validation.value.message">
                        <b-input v-model="formData.value" />
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Value Change"
                        label-position="inside"
                        :type="validation.valueChange.type"
                        :message="validation.valueChange.message">
                        <b-input v-model="formData.valueChange" />
                    </b-field>
                </div>
            </div>
            <div class="columns" v-if="!editMode">
                <div class="column">                   
                    <b-field
                        label="Date"
                        label-position="inside"
                        :type="validation.date.type"
                        :message="validation.date.message">
                        <b-datepicker
                            ref="datepicker"                    
                            v-model="logDate"
                            label-position=""
                            placeholder="Set Date"
                            icon-pack="fas"
                            expanded>
                        </b-datepicker>
                    </b-field>
                </div>
            </div>
        </template>
        <template #confirm>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Market Index">
                        {{ formData.marketIndex.name }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Value">
                        {{ formatMoney( formData.value ) }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Value Change">
                        {{ formatMoney( formData.valueChange ) }}
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Date">
                        {{ formatDate( formData.log.logged, 'dddd, MMM D, YYYY' ) }}
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
            createTitle: `Create Stock Index Entry`,
            validation: {
                marketIndex: {
                    type: '',
                    message: ''
                },
                value: {
                    type: '',
                    message: ''
                },
                valueChange: {
                    type: '',
                    message: ''
                },
                date: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    beforeCreate() {
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
        ...mapState('indices', ['indices']),
        title() {
            return this.editMode ? `Update: ${this.data.marketIndex.name}, ${this.formatDate(this.data.log.logged, 'MMM-DD-YYYY')}` : this.createTitle
        },
        logDate: {
            get() {
                return this.convertToDate(this.formData.log.logged)
            },
            set(value) {
                this.formData.log.logged = value
            }
        }
    },
    methods: {
        ...mapActions('stockIndices', ['create', 'update']),
        assign() {
            this.formData.no = parseInt(this.formData.no, 10)            
            this.formData.log.details = `Manual entry for ${this.formData.marketIndex.name}`
            this.formData.log.event = 'INFORMATION'
            this.formData.log.type = 'STOCK'
            this.formData.value = this.parseMoney( this.formData.value ) // TODO: Vue3 ... VueCurrency component
            this.formData.valueChange = this.parseMoney( this.formData.valueChange )
        },
        validate() {
            let valid = true

            if (!this.formData.marketIndex) {
                this.validation.marketIndex.type = 'is-danger'
                this.validation.marketIndex.message = 'Please choose market index'
                valid = false
            } else {
                this.validation.marketIndex.type = ''
                this.validation.marketIndex.message = ''
            }

            let vlu = this.parseMoney(this.formData.value)
            if (!vlu) {
                this.validation.value.type = 'is-danger'
                this.validation.value.message = 'Please enter value'
                valid = false
            } else {
                this.validation.value.type = ''
                this.validation.value.message = ''
            }

            // let valueChange = this.parseMoney(this.formData.valueChange)
            // if (!valueChange) {
            //     this.validation.valueChange.type = 'is-danger'
            //     this.validation.valueChange.message = 'Please enter value change'
            //     valid = false
            // } else {
            //     this.validation.valueChange.type = ''
            //     this.validation.valueChange.message = ''
            // }

            this.isValid = valid
        }
    }
}

</script>