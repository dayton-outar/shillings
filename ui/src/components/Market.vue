<template>
    <div>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="formData.code" :disabled="editMode"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="formData.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Company">
                        <b-select 
                            v-model="formData.company"
                            placeholder="Choose Company"
                            expanded>
                            <option
                                v-for="company in companies" 
                                :key="company.code"
                                :value="company">
                                {{company.name}}
                            </option>
                        </b-select>
                    </b-field>
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
// import moment from 'moment'

export default {
    props: ['data', 'editMode'],
    data() {
        return {
            formData: JSON.parse(JSON.stringify(this.data)),
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchCompanies')
    },
    computed: {
        ...mapState(['companies'])
    },
    methods: {
        ...mapActions(['updateStock', 'createStock']),
        submit() {
            if (this.editMode) {
                //this.updateStock( this.stock );
            } else {
                //this.createStock( this.stock );
            }
        }
    }
}

</script>