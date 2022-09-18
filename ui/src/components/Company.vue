<template>
    <div>
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
                        <b-numberinput v-model="company.totalEmployed"></b-numberinput>
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
                            v-model="company.industries"
                            multiple
                            scrollable
                            aria-role="list"
                            expanded>
                            <template #trigger>
                                <b-button
                                    type="is-light"
                                    expanded
                                    icon-right="menu-down">
                                    Selected ({{ company.industries.length }})
                                </b-button>
                            </template>

                            <b-dropdown-item aria-role="listitem" 
                                v-for="industry in industries" 
                                :key="industry.no"
                                :value="industry" :class="(company.industries.some(i => i.no === industry.no) ? 'is-active': '')">
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
            <div class="columns">
                <div class="column">
                    <b-button label="Save" type="is-info" size="is-medium" expanded @click.prevent="submit" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import moment from 'moment'

export default {
    props: ['companyData', 'editMode'],
    data() {
        return {
            company: JSON.parse(JSON.stringify(this.companyData)),
            dropFiles: [],
            imgSrc: this.companyData.logo ? `http://localhost:5000/files?no=${this.companyData.logo.no}` : '#'
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchIndustries')
    },
    computed: {
        ...mapState(['industries']),
        foundedDate: {
            get() {
                return moment(this.company.founded).toDate()
            },
            set(value) {
                this.company.founded = value // HACK: Need for $store mutation method
            }
        }
    },
    methods: {
        ...mapActions(['updateCompany', 'createCompany']),
        deleteDropFile(index) {
            this.dropFiles.splice(index, 1)
        },
        submit() {
            console.log(this.company);
            
            this.company.logo = this.dropFiles[0];            
            this.company.announcements = null;
            this.company.created = new Date(1999, 10, 4);

            if (this.editMode) {
                this.updateCompany( this.company );
            } else {
                this.createCompany( this.company );
            }
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