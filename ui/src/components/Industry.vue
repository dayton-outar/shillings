<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
        <template #input>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside"
                        :type="validation.name.type"
                        :message="validation.name.message">
                        <b-input 
                            v-model.trim="formData.name" 
                            placeholder="Name of industry" 
                            icon-pack="fas"
                            icon="industry"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Wiki"
                        label-position="inside"
                        :type="validation.wiki.type"
                        :message="validation.wiki.message">
                        <b-input 
                            v-model.trim="formData.wiki" 
                            placeholder="Wikipedia Address" 
                            icon-pack="fas"
                            icon="globe" 
                            type="url"
                            validation-message="Please enter valid URL"></b-input>
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
                        label="Wiki">
                        <a :href="formData.wiki" target="_blank">{{ formData.wiki }}</a>
                    </b-field>
                </div>
            </div>
        </template>
    </s-form>
</template>

<script> 
import { mapActions } from 'vuex'

import formMixin from '../utils/formMixin'

import Form from './Form.vue'

export default {
    components: {
        's-form': Form,
    },
    mixins: [formMixin],
    data() {
        return {
            createTitle: 'Create Industry',
            validation: {
                name: {
                    type: '',
                    message: ''
                },
                wiki: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    methods: {
        ...mapActions('industries', ['create', 'update']),
        validate(){
            let valid = true

            if (!this.formData.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            if (!this.formData.wiki) {
                this.validation.wiki.type = 'is-danger'
                this.validation.wiki.message = 'Please enter Wikipedia URL'
                valid = false
            } else {
                this.validation.wiki.type = ''
                this.validation.wiki.message = ''
            }

            this.isValid = valid
        }
    }
}

</script>