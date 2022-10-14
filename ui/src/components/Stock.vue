<template>
    <div>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="stock.code" :disabled="editMode"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="stock.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Issued Shares"
                        label-position="">
                        <b-numberinput v-model="stock.issuedShares"></b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Outstanding Shares"
                        label-position="">
                        <b-numberinput v-model="stock.outstandingShares"></b-numberinput>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Currency">
                        <b-select 
                            v-model="stock.currency"
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
                            v-model="stock.stockType"
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
                            v-model="stock.company"
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
                    <b-field 
                        label="Market Indices">
                        <b-dropdown
                            v-model="stock.indices"
                            multiple
                            scrollable
                            aria-role="list"
                            expanded>
                            <template #trigger>
                                <b-button
                                    type="is-light"
                                    expanded
                                    icon-right="menu-down">
                                    Selected ({{ stock.indices.length }})
                                </b-button>
                            </template>

                            <b-dropdown-item aria-role="listitem" 
                                v-for="index in marketIndices" 
                                :key="index.no"
                                :value="index" :class="(stock.indices.some(i => i.no === index.no) ? 'is-active': '')">
                                {{index.name}}
                            </b-dropdown-item>

                        </b-dropdown>
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
            stock: JSON.parse(JSON.stringify(this.data)),
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchCompanies')
        this.$store.dispatch('fetchMarketIndices')
    },
    computed: {
        ...mapState(['companies', 'marketIndices'])
    },
    methods: {
        ...mapActions(['updateStock', 'createStock']),
        submit() {
            if (this.editMode) {
                this.updateStock( this.stock );
            } else {
                this.createStock( this.stock );
            }
        }
    }
}

</script>