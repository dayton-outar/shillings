<template>
    <form @submit.prevent="validate" novalidate>
        <div class="box my-4 mx-1">            
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="company.code" :disabled="editMode"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="company.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="About"
                        label-position="inside">
                        <b-input v-model="company.about"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Total Employed"
                        label-position="">
                        <b-numberinput 
                            v-model="company.totalEmployed"
                            icon-pack="fas"></b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Wiki"
                        label-position="inside">
                        <b-input v-model="company.wiki"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Website"
                        label-position="inside">
                        <b-input v-model="company.webSite"></b-input>
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
                            placeholder=""
                            icon-pack="fas"
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
                    <b-field>
                        <b-upload
                            v-model="dropFiles"
                            multiple
                            drag-drop
                            expanded>
                            <section class="section">
                                <div class="content has-text-centered">
                                    <p>
                                        <b-icon
                                            icon="upload"
                                            size="is-large">
                                        </b-icon>
                                    </p>
                                    <p>Drop your files here or click to upload</p>
                                </div>
                            </section>
                        </b-upload>
                    </b-field>
                    <div class="tags">
                        <span v-for="(file, index) in dropFiles"
                            :key="index"
                            class="tag is-primary" >
                            {{file.name}}
                            <button class="delete is-small"
                                type="button"
                                @click="deleteDropFile(index)">
                            </button>
                        </span>
                    </div>
                    <img :src="imgSrc" alt="Company Logo" />
                </div>
            </div>
            <hr class="has-background-grey-lighter thinner" />
            <div class="columns">
                <div class="column">
                    <b-button label="Close" size="is-medium" expanded @click.prevent="$emit('close')" />
                </div>
                <div class="column">
                    <b-button label="Save" type="is-info" size="is-medium" expanded @click.prevent="submit" />
                </div>
            </div>
        </div>
    </form>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import moment from 'moment'

export default {
    props: ['companyData', 'editMode'],
    data() {
        return {
            company: JSON.parse(JSON.stringify(this.companyData)),
            companyIndustries: this.companyData.industries.map(i => i.no),
            dropFiles: [],
            imgSrc: this.companyData.logo ? `http://localhost:5000/files?no=${this.companyData.logo.no}` : '#',
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
    beforeCreate() {
        //this.$store.dispatch('fetchIndustries')
    },
    setup() {},
    mounted() {},
    computed: {
        ...mapState('industries', ['industries']),
        foundedDate: {
            get() {
                return moment(this.company.founded).toDate()
            },
            set(value) {
                this.company.founded = value
            }
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
                            title: `Update Company: ${this.company.name}`,
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
                            title: `Update Company: ${this.company.name}`,
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
                            title: `Create Company`,
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
                            title: `Create Company`,
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

            if (!this.company.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            if (!this.company.wiki) {
                this.validation.wiki.type = 'is-danger'
                this.validation.wiki.message = 'Please enter Wikipedia URL'
                valid = false
            } else {
                this.validation.wiki.type = ''
                this.validation.wiki.message = ''
            }

            this.isValid = valid
        }
    },
    watch: {
        dropFiles: function(o) {
          var reader = new FileReader();
          reader.onload = e => { //this.$emit("load", e.target.result);
            this.imgSrc = e.target.result;
          }

          if (o[0]) {
            reader.readAsDataURL(o[0]);
          }
        }
    }
}

</script>