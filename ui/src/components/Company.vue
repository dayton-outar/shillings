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
                                type="text"
                                placeholder="Summary about company"></b-input>
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
                            label="Founded"
                            :type="validation.founded.type"
                            :message="validation.founded.message">
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
                            label="Country"
                            :type="validation.country.type"
                            :message="validation.country.message">
                            <b-dropdown 
                                v-model="company.countryCode"
                                expanded>
                                <template #trigger>
                                    <b-button
                                        type="is-light"
                                        expanded
                                        icon-right="menu-down">
                                        {{ company.countryCode == '' ? 'Choose Country' : company.countryCode }}
                                    </b-button>
                                </template>

                                <b-dropdown-item value="JM" aria-role="listitem">
                                    <div class="media">
                                        <figure class="media-left">
                                            <div class="image is-32x32">
                                                <img src="https://www.worldometers.info/img/flags/jm-flag.gif" alt="Jamaica Flag" />
                                            </div>
                                        </figure>
                                        <div class="media-content">
                                            <p>Jamaica</p>
                                        </div>
                                    </div>
                                </b-dropdown-item>

                                <b-dropdown-item value="TT" aria-role="listitem">
                                    <div class="media">
                                        <figure class="media-left">
                                            <div class="image is-32x32">
                                                <img src="https://www.worldometers.info/img/flags/td-flag.gif" alt="Trinidad Flag" />
                                            </div>
                                        </figure>
                                        <div class="media-content">
                                            <p>Trinidad</p>
                                        </div>
                                    </div>
                                </b-dropdown-item>

                            </b-dropdown>
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
                                    v-for="industry in industries.nodes" 
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
                        <b-field
                            label="Logo"
                            :type="validation.logo.type"
                            :message="validation.logo.message">
                            <b-field class="file is-info" :class="{'has-name': !!dropFile}">
                                <b-upload
                                    v-model="dropFile"
                                    class="file-label"
                                    drag-drop
                                    expanded
                                    v-if="!hasImg">
                                    <div class="has-text-centered">
                                        <p>
                                            <b-icon
                                                pack="fas"
                                                icon="cloud-arrow-up"
                                                size="is-large">
                                            </b-icon>
                                        </p>
                                        <p>Drop your files here or click to upload</p>
                                    </div>
                                </b-upload>
                                <b-message 
                                    :title="(dropFile ? `File: ${dropFile.name} (${formatBytes(dropFile.size)})` : `File: ${this.company.logo.fileName} (${formatBytes(this.company.logo.contentSize)})`)" 
                                    v-if="hasImg" 
                                    aria-close-label="Close message"
                                    @close="(hasImg = false)">
                                    <img :src="imgSrc" alt="Company Logo" />
                                </b-message>          
                            </b-field>
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
                <!-- slot -->
            </div>
            <div class="content" v-else>
                <!-- slot -->
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Code">
                            {{ company.code }}
                        </b-field>
                    </div>
                </div>
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
                            label="About">
                            {{ company.about }}
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Total Employed">
                            {{ company.totalEmployed }}
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
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Website">
                            <a :href="company.webSite" target="_blank">{{ company.webSite }}</a>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Founded">
                            {{ formatDate(this.company.founded) }}
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Country">
                            {{ this.company.countryCode }}
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Industries">
                            <ul class="list">
                                <li class="list-item" v-for="industry in industries.nodes.filter(i => companyIndustries.includes(i.no))" :key="industry.no">{{industry.name}}</li>
                            </ul>
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field
                            label="Logo">
                            <img :src="imgSrc" alt="Company Logo" />
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
import prettyBytes from 'pretty-bytes';
import config from '../config'

export default {
    props: ['companyData', 'editMode'],
    data() {
        return {
            company: JSON.parse(JSON.stringify(this.companyData)),
            companyIndustries: this.companyData.industries.map(i => i.no),
            dropFile: null,
            hasImg: (this.editMode && !!this.companyData.logo),
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
                },
                logo: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    created() {
        this.$store.dispatch('industries/fetch', {
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            });
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

            if (!this.company.founded) {
                this.validation.founded.type = 'is-danger'
                this.validation.founded.message = 'Please enter date company was founded'
                valid = false
            } else {
                this.validation.founded.type = ''
                this.validation.founded.message = ''
            }

            if (!this.company.countryCode) {
                this.validation.country.type = 'is-danger'
                this.validation.country.message = 'Please choose country'
                valid = false
            } else {
                this.validation.country.type = ''
                this.validation.country.message = ''
            }

            console.log( this.industries.nodes.filter(i => this.companyIndustries.includes(i.no)) )
            // if (this.companyIndustries.length == 0) {
            //     this.validation.industries.type = 'is-danger'
            //     this.validation.industries.message = 'Please choose at least one (1) industry'
            //     valid = false
            // } else {
            //     this.validation.industries.type = ''
            //     this.validation.industries.message = ''
            // }

            if (!this.hasImg) {
                this.validation.logo.type = 'is-danger'
                this.validation.logo.message = 'Please upload a logo'
                valid = false
            } else {
                this.validation.logo.type = ''
                this.validation.logo.message = ''
            }

            this.isValid = valid
        },
        formatBytes(bytes) {
            return prettyBytes(bytes, { locale: 'en' })
        },
        formatDate(date) {
            return moment(date).format('MMMM, YYYY')
        }
    },
    watch: {
        dropFile: function(o) {
          var reader = new FileReader()
          this.hasImg = true
          this.validation.logo.type = ''
          this.validation.logo.message = ''

          reader.onload = e => {    
            this.imgSrc = e.target.result
          }

          if (o) {
            this.company.logo = o
            reader.readAsDataURL(o)
          }
        }
    }
}

</script>