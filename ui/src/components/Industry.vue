<template>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @close="$emit('close')">
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

import Form from './Form.vue'

export default {
    props: ['data', 'editMode'],
    components: {
        's-form': Form,
    },
    data() {
        return {
            formData: JSON.parse(JSON.stringify(this.data)),
            isValid: false,
            isLoading: false,
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
    computed: {
        title() {
            return this.editMode ? `Update: ${this.data.name}` : `Create Industry`
        }
    },
    methods: {
        ...mapActions('industries', ['create', 'update']),
        save() {
            this.isLoading = true

            if (this.editMode) {
                this.update( this.formData )
                    .then(response => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `Successfully updated ${response.name}`,
                            confirmText: 'OK',
                            type: 'is-success',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'circle-check',
                            onConfirm: () => {                                
                                this.$emit('close', 'updated')
                            }
                        })
                    })
                    .catch(err => {    
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `${err.message}`,
                            confirmText: 'OK',
                            type: 'is-danger',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'bug'
                        })
                    })
            } else {
                this.create( this.formData )
                    .then(response => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `Successfully created ${response.name}`,
                            confirmText: 'OK',
                            type: 'is-success',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'circle-check',
                            onConfirm: () => {
                                this.$emit('close', 'created')
                            }
                        })
                    })
                    .catch(err => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `${err.message}`,
                            confirmText: 'OK',
                            type: 'is-danger',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'bug'
                        })
                    })
            }

        },
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

<style scoped>

.thinner {
    height: 1px !important;
}

@keyframes bounceIn {
  from,
  20%,
  40%,
  60%,
  80%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
  }

  0% {
    opacity: 0;
    transform: scale3d(0.3, 0.3, 0.3);
  }

  20% {
    transform: scale3d(1.1, 1.1, 1.1);
  }

  40% {
    transform: scale3d(0.9, 0.9, 0.9);
  }

  60% {
    opacity: 1;
    transform: scale3d(1.03, 1.03, 1.03);
  }

  80% {
    transform: scale3d(0.97, 0.97, 0.97);
  }

  to {
    opacity: 1;
    transform: scale3d(1, 1, 1);
  }
}

.bounceIn {
  animation-duration: calc(var(--animate-duration) * 0.75);
  animation: bounceIn 0.8s;
}

</style>