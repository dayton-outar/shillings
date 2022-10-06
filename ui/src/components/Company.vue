<template>
    <form @submit.prevent="validate" novalidate>
        <div class="box my-4 mx-1">
            <h5 class="title is-5">{{ title }}</h5>
            <hr class="has-background-grey-light" />
            <div v-if="!isValid">
                <!-- slot -->
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Code"
                            label-position="inside"
                            :type="validation.code.type"
                            :message="validation.code.message">
                            <b-input 
                                v-model="company.code"
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
                                v-model="company.name"
                                placeholder="Company name"
                                icon-pack="fas"
                                icon="building" 
                                type="text"></b-input>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="About"
                            label-position="inside"
                            :type="validation.about.type"
                            :message="validation.about.message">
                            <b-input 
                                v-model="company.about"
                                icon-pack="fas"
                                icon="file-lines" 
                                type="text"></b-input>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Total Employed"
                            label-position="inside"
                            :type="validation.totalEmployed.type"
                            :message="validation.totalEmployed.message">
                            <b-numberinput 
                                v-model="company.totalEmployed"
                                icon-pack="fas"
                                type="is-info"
                                controls-position="compact"
                                expanded></b-numberinput>
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
                                v-model="company.wiki"
                                placeholder="Wikipedia address" 
                                icon-pack="fas"
                                icon="globe" 
                                type="url"
                                validation-message="Please enter valid URL"></b-input>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Website"
                            label-position="inside"
                            :type="validation.webSite.type"
                            :message="validation.webSite.message">
                            <b-input 
                                v-model="company.webSite"
                                placeholder="Web address" 
                                icon-pack="fas"
                                icon="globe" 
                                type="url"
                                validation-message="Please enter valid URL"></b-input>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Founded">
                            <b-datepicker
                                v-model="foundedDate"
                                ref="datepicker"
                                label-position=""
                                placeholder="mm/dd/yyyy"
                                icon-pack="fas"
                                icon="calendar"
                                editable
                                expanded>
                            </b-datepicker>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Country">
                            <b-select 
                                v-model="company.countryCode"
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
                            label="Industries">
                            <b-dropdown
                                v-model="companyIndustries"
                                multiple
                                scrollable
                                aria-role="list"
                                expanded>
                                <template #trigger>
                                    <b-button
                                        type="is-light"
                                        expanded
                                        icon-right="menu-down">
                                        Selected ({{ companyIndustries.length }})
                                    </b-button>
                                </template>

                                <b-dropdown-item aria-role="listitem" 
                                    v-for="industry in industries" 
                                    :key="industry.no"
                                    :value="industry.no">
                                    {{industry.name}}
                                </b-dropdown-item>

                            </b-dropdown>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field class="file is-info" :class="{'has-name': !!dropFile}">
                            <b-upload
                                v-model="dropFile"
                                class="file-label"
                                drag-drop
                                expanded>
                                <span class="file-cta">
                                    <b-icon
                                        class="file-icon"
                                        pack="fas"
                                        icon="upload"></b-icon>
                                    <span class="file-label">Click to upload</span>
                                </span>
                                <span class="file-name" v-if="dropFile">
                                    {{ dropFile.name }}
                                </span>
                            </b-upload>
                        </b-field>
                        <img :src="imgSrc" alt="Company Logo" v-if="dropFile" />                        
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
                <!-- slot -->
            </div>
            <div v-else>
                <!-- slot -->
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Name">
                            {{ company.name }}
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Wiki">
                            <a :href="company.wiki" target="_blank">{{ company.wiki }}</a>
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
                <!-- slot -->
            </div>
        </div>
    </form>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import moment from 'moment'
import config from '../config'

export default {
    props: ['companyData', 'editMode'],
    data() {
        return {
            company: JSON.parse(JSON.stringify(this.companyData)),
            companyIndustries: this.companyData.industries.map(i => i.no),
            dropFile: null,
            hasImg: this.companyData.logo,
            imgSrc: this.companyData.logo ? `${config.fileApiHost}?no=${this.companyData.logo.no}` : '#',
            isValid: false,
            isLoading: false,
            validation: {
                code: {
                    type: '',
                    message: ''
                },
                name: {
                    type: '',
                    message: ''
                },
                about: {
                    type: '',
                    message: ''
                },
                totalEmployed: {
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
                }
            }
        }
    },
    computed: {
        ...mapState('industries', ['industries']),
        foundedDate: {
            get() {
                return moment(this.company.founded).toDate()
            },
            set(value) {
                this.company.founded = value
            }
        },
        title() {
            return this.editMode ? `Update Company: ${this.companyData.name}` : `Create Company`
        }
    },
    methods: {
        ...mapActions('companies', ['create', 'update']),
        save() {
            this.isLoading = true

            if (this.editMode) {
                this.update( this.company )
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
                this.create( this.company )
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

            if (!this.company.code) {
                this.validation.code.type = 'is-danger'
                this.validation.code.message = 'Please enter unique code'
                valid = false
            } else {
                this.validation.code.type = ''
                this.validation.code.message = ''
            }

            if (!this.company.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            if (!this.company.about) {
                this.validation.about.type = 'is-danger'
                this.validation.about.message = 'Please enter summary about the company'
                valid = false
            } else {
                this.validation.about.type = ''
                this.validation.about.message = ''
            }

            if (!this.company.totalEmployed) {
                this.validation.totalEmployed.type = 'is-danger'
                this.validation.totalEmployed.message = 'Please enter total employed'
                valid = false
            } else {
                this.validation.totalEmployed.type = ''
                this.validation.totalEmployed.message = ''
            }

            if (!this.company.wiki) {
                this.validation.wiki.type = 'is-danger'
                this.validation.wiki.message = 'Please enter Wikipedia address'
                valid = false
            } else {
                this.validation.wiki.type = ''
                this.validation.wiki.message = ''
            }

            if (!this.company.webSite) {
                this.validation.webSite.type = 'is-danger'
                this.validation.webSite.message = 'Please enter website address'
                valid = false
            } else {
                this.validation.webSite.type = ''
                this.validation.webSite.message = ''
            }

            console.log( this.company.founded ) // null

            console.log( this.company.countryCode ) // ''

            console.log( this.companyIndustries.length ) // 0

            this.isValid = valid
        }
    },
    watch: {
        dropFile: function(o) {
          var reader = new FileReader()
          //this.hasImg = true

          reader.onload = e => {    
            this.imgSrc = e.target.result
            //this.company.logo = this.dropFiles[0]
            console.log(e.target.result)
            console.log( this.dropFiles )
          }

          if (o) {
            reader.readAsDataURL(o)
          }
        }
    }
}

</script>