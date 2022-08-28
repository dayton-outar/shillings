<template>
    <div>
        <h4 class="title is-4">{{  }}</h4>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="company.code"></b-input>
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
                            v-model="company.founded"
                            ref="datepicker"
                            label-position=""
                            placeholder=""
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
                            multiple
                            scrollable
                            aria-role="list"
                            expanded>
                            <template #trigger>
                                <b-button
                                    type="is-light"
                                    expanded
                                    icon-right="menu-down">
                                    Selected 
                                </b-button>
                            </template>
                            
                            <b-dropdown-item aria-role="listitem" 
                                value="Foods">
                                Foods
                            </b-dropdown-item>

                            <b-dropdown-item aria-role="listitem" 
                                value="Finance">
                                Finance
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
                    <b-button label="Save" type="is-info" size="is-large" expanded @click="submit" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapActions } from 'vuex' //mapState,

export default {
    data() {
        return {
            company: {},
            dropFiles: [],
            imgSrc: '#'
        }
    },
    computed: {
        //...mapState(['company'])
    },
    methods: {
        ...mapActions(['updateCompany']),
        deleteDropFile(index) {
            this.dropFiles.splice(index, 1)
        },
        submit() {
            this.company.logo = this.dropFiles[0];
            this.company.industries = [];
            this.company.announcements = null;
            this.company.created = new Date(1999, 10, 4);

            this.updateCompany( this.company );
        }
    },
    watch: {
        $route() {},
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