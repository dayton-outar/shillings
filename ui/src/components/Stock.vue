<template>
    <div>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="stockData.code" :disabled="editMode"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="stockData.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Total Employed"
                        label-position="">
                        <b-numberinput v-model="stockData.issuedShares"></b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Total Employed"
                        label-position="">
                        <b-numberinput v-model="stockData.outstandingShares"></b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Currency">
                        <b-select 
                            v-model="stockData.currency"
                            placeholder="Choose Currency"
                            expanded>
                            <option value="JMD">Jamaican Dollar</option>
                            <option value="USD">US Dollar</option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Type">
                        <b-select 
                            v-model="stockData.stockType"
                            placeholder="Choose Type"
                            expanded>
                            <option value="ORDINARY">Ordinary</option>
                            <option value="PREFFERRED">Preferred</option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Company">
                        <b-select 
                            v-model="stockData.company.code"
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
                    <b-button label="Save" type="is-info" size="is-medium" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex' //, mapActions
// import moment from 'moment'

export default {
    props: ['stockData', 'editMode'],
    data() {
        return {}
    },
    beforeCreate() {
        this.$store.dispatch('fetchCompanies')
    },
    computed: {
        ...mapState(['companies'])
    },
    methods: {
        // ...mapActions(['updateCompany']),
        // submit() {
        //     this.company.logo = this.dropFiles[0];            
        //     this.company.announcements = null;
        //     this.company.created = new Date(1999, 10, 4);

        //     if (this.editMode) {
        //         this.updateCompany( this.company );
        //     } else {
        //         this.createCompany( this.company );
        //     }
        // }
    }
}

</script>