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
                        v-model="formData.about"
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
                        v-model="formData.totalEmployed"
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
                        v-model="formData.wiki"
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
                        v-model="formData.webSite"
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
                        v-model="formData.countryCode"
                        expanded>
                        <template #trigger>
                        <b-button
                            type="is-light"
                            expanded
                            icon-right="menu-down">
                            {{ formData.countryCode == '' ? 'Choose Country' : formData.countryCode }}
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
                    <b-field class="file is-info" :class="{'has-name': !hasImg}">
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
                            :title="(dropFile ? `File: ${dropFile.name} (${formatBytes(dropFile.size)})` : `File: ${getLogo(formData.files)[0].fileName} (${formatBytes(getLogo(formData.files)[0].contentSize)})`)" 
                            v-if="hasImg" 
                            aria-close-label="Close message"
                            @close="(hasImg = false)">
                            <img :src="imgSrc" alt="Company Logo" />
                        </b-message>          
                    </b-field>
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
                    label="About">
                    {{ formData.about }}
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Total Employed">
                    {{ formData.totalEmployed }}
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
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Website">
                    <a :href="formData.webSite" target="_blank">{{ formData.webSite }}</a>
                </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                <b-field 
                    label="Founded">
                    {{ formatDate(formData.founded) }}
                </b-field>
                </div>
            </div>
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
        </template>
    </s-form>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import moment from 'moment'
import prettyBytes from 'pretty-bytes';
import config from '../config'

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
            createTitle: 'Create Company',
            companyIndustries: this.data.industries.map(i => i.no),
            dropFile: null,
            hasImg: (this.editMode && !!this.data.files),
            imgSrc: this.getLogo(this.data.files) ? `${config.fileApiHost}?no=${this.getLogo(this.data.files)[0].no}` : '#',
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
        this.$store.dispatch('industries/fetch', { // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
    },
    computed: {
        ...mapState('industries', ['industries']),
        foundedDate: {
            get() {
                return moment(this.formData.founded).toDate()
            },
            set(value) {
                this.formData.founded = value
            }
        }
    },
    methods: {
        ...mapActions('companies', ['create', 'update']),
        assign() {
            this.formData.logo = this.dropFile
            this.formData.industries = this.industries.nodes.filter(i => this.companyIndustries.includes(i.no))
        },
        validate(){
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

            if (!this.formData.about) {
                this.validation.about.type = 'is-danger'
                this.validation.about.message = 'Please enter summary about the formData'
                valid = false
            } else {
                this.validation.about.type = ''
                this.validation.about.message = ''
            }

            if (!this.formData.totalEmployed) {
                this.validation.totalEmployed.type = 'is-danger'
                this.validation.totalEmployed.message = 'Please enter total employed'
                valid = false
            } else {
                this.validation.totalEmployed.type = ''
                this.validation.totalEmployed.message = ''
            }

            // if (!this.formData.wiki) {
            //     this.validation.wiki.type = 'is-danger'
            //     this.validation.wiki.message = 'Please enter Wikipedia address'
            //     valid = false
            // } else {
            //     this.validation.wiki.type = ''
            //     this.validation.wiki.message = ''
            // }

            // if (!this.formData.webSite) {
            //     this.validation.webSite.type = 'is-danger'
            //     this.validation.webSite.message = 'Please enter website address'
            //     valid = false
            // } else {
            //     this.validation.webSite.type = ''
            //     this.validation.webSite.message = ''
            // }

            if (!this.foundedDate) {
                this.validation.founded.type = 'is-danger'
                this.validation.founded.message = 'Please enter date company was founded'
                valid = false
            } else {
                this.validation.founded.type = ''
                this.validation.founded.message = ''
            }

            if (!this.formData.countryCode) {
                this.validation.country.type = 'is-danger'
                this.validation.country.message = 'Please choose country'
                valid = false
            } else {
                this.validation.country.type = ''
                this.validation.country.message = ''
            }

            if (this.companyIndustries.length == 0) {
                this.validation.industries.type = 'is-danger'
                this.validation.industries.message = 'Please choose at least one (1) industry'
                valid = false
            } else {
                this.validation.industries.type = ''
                this.validation.industries.message = ''
            }

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
            reader.readAsDataURL(o)
          }
        }
    }
}

</script>