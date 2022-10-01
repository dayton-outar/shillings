<template>
    <form @submit.prevent="validate">
        <div class="box my-4 mx-1">
            <h5 class="title is-5">{{ title }}</h5>
            <hr class="has-background-grey-light" />
            <div v-if="!isValid">                
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Name"
                            label-position="inside"
                            :type="validation.name.type"
                            :message="validation.name.message">
                            <b-input 
                                v-model.trim="industry.name" 
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
                                v-model.trim="industry.wiki" 
                                placeholder="Wikipedia URL" 
                                icon-pack="fas"
                                icon="globe" 
                                type="url"
                                validation-message="Please enter valid URL"></b-input>
                        </b-field>
                    </div>
                </div>
                <hr class="has-background-grey-lighter thinner" />
                <div class="columns">
                    <div class="column">
                        <b-button label="Close" size="is-medium" expanded @click.prevent="$emit('close')" />
                    </div>
                    <div class="column">
                        <b-button label="Save" type="is-info" size="is-medium" expanded native-type="submit" />
                    </div>
                </div>
            </div>
            <div v-else>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Name">
                            {{ industry.name }}
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Wiki">
                            <a :href="industry.wiki" target="_blank">{{ industry.wiki }}</a>
                        </b-field>
                    </div>
                </div>
                <hr class="has-background-grey-lighter thinner" />
                <div class="columns">
                    <div class="column">
                        <b-button label="Cancel" size="is-medium" expanded @click.prevent="(isValid = false)" />
                    </div>
                    <div class="column">
                        <b-button label="OK" type="is-info" size="is-medium" expanded @click.prevent="save" :disabled="isLoading" />
                    </div>
                </div>
            </div>
            <b-loading :is-full-page="false" v-model="isLoading"></b-loading>
        </div>
    </form>
</template>

<script> 
import { mapActions } from 'vuex' 

export default {
    props: ['industryData', 'editMode'],
    data() {
        return {
            industry: JSON.parse(JSON.stringify(this.industryData)),
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
            return this.editMode ? `Update Industry: ${this.industry.name}` : `Create Industry`
        }
    },
    methods: {
        ...mapActions('industries', ['create', 'update']),
        save() {
            this.isLoading = true

            if (this.editMode) {
                this.update( this.industry )
                    .then(response => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title(),
                            message: `Successfully updated ${response.name}`,
                            confirmText: 'OK',
                            type: 'is-success',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'circle-check',
                            onConfirm: () => {                                
                                this.$emit('close')
                            }
                        })
                    })
                    .catch(err => {    
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title(),
                            message: `${err.message}`,
                            confirmText: 'OK',
                            type: 'is-danger',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'triangle-exclamation'
                        })
                    })
            } else {
                this.create( this.industry )
                    .then(response => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title(),
                            message: `Successfully created ${response.name}`,
                            confirmText: 'OK',
                            type: 'is-success',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'circle-check',
                            onConfirm: () => {
                                this.$emit('close')
                            }
                        })
                    })
                    .catch(err => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title(),
                            message: `${err.message}`,
                            confirmText: 'OK',
                            type: 'is-danger',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'triangle-exclamation'
                        })
                    })
            }

        },
        validate(){
            let valid = true

            if (!this.industry.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            if (!this.industry.wiki) {
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

</style>