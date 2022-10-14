<template>
    <form @submit.prevent="validate" novalidate>
        <div class="box my-4 mx-1">
            <h5 class="title is-5">{{ title }}</h5>
            <hr class="has-background-grey-light" />

            <div class="columns">
                <div class="column">
                    <b-field
                        label="Company"
                        label-position="inside"
                        :type="vCompany.type"
                        :message="vCompany.message">
                        <b-select 
                        v-model="formData.company"
                        placeholder="Choose Company"
                        @input="clearVCompany">
                        <option
                            v-for="company in companies.nodes" 
                            :key="company.code"
                            :value="company">
                            {{company.name}}
                        </option>
                        </b-select>
                    </b-field>
                </div>
                <div class="column is-one-fifth">
                    <b-field 
                        label="Period"
                        label-position="inside"
                        :type="vPeriod.type"
                        :message="vPeriod.message">
                        <b-select 
                            v-model="formData.period"
                            placeholder="Choose Period" 
                            expanded
                            @input="clearVPeriod">
                            <option value="QUARTERLY">Quarterly</option>
                            <option value="ANNUAL">Annual</option>
                        </b-select>
                    </b-field>
                </div>
                <div class="column is-one-fifth">
                    <!--
                    <b-field
                        label="Date"
                        label-position="inside"
                        :type="vStatementDate.type"
                        :message="vStatementDate.message">
                        <b-datepicker
                            ref="datepicker"                    
                            v-model="formData.statementDate"
                            label-position=""
                            placeholder="Set Statement Date"
                            expanded
                            @input="clearVStatementDate">
                        </b-datepicker>
                    </b-field>
                    -->
                </div>
                <div class="column">
                    <b-field>
                        <b-checkbox v-model="formData.isAudited">Is Audited?</b-checkbox>
                    </b-field>
                </div>        
            </div>    
            
            <div class="columns">
                <div class="column is-full">
                    <div class="columns">
                        <div class="column">
                            <div v-for="(stmt, ix) in statements" :key="ix" class="columns">
                                <financial-statement 
                                    :data="formData.analytes"
                                    :type="stmt.Type" 
                                    :no="ix" 
                                    @removed="removeStatement" />
                            </div>
                        </div>
                    </div>
                    <div class="columns">
                        <div class="column is-flex is-justify-content-flex-end">
                            <b-dropdown 
                                aria-role="list"
                                position="is-top-left">
                                <template #trigger>
                                    <b-button
                                        type="is-info"
                                        size="is-medium"
                                        icon-pack="fas"
                                        icon-right="plus" />
                                </template>


                                <b-dropdown-item aria-role="listitem" @click="addStatement('Income')">Income</b-dropdown-item>
                                <b-dropdown-item aria-role="listitem" @click="addStatement('Financial Position')">Financial Position</b-dropdown-item>
                                <b-dropdown-item aria-role="listitem" @click="addStatement('Cash Flow')">Cash Flow</b-dropdown-item>
                            </b-dropdown>
                        </div>
                    </div>
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
  </form>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import _ from 'lodash'

import FinancialStatement from './FinancialStatement.vue'

export default {
    props: ['data', 'editMode'],
    components: {
        'financial-statement': FinancialStatement
    },
    data() {
        return {
            formData: JSON.parse(JSON.stringify(this.data)),
            statements: [],
            vCompany: {
                type: '',
                message: ''
            },
            vPeriod: {
                type: '',
                message: ''
            },
            vStatementDate: {
                type: '',
                message: ''
            }
        }
    },
    created() {
        this.$store.dispatch('companies/fetch', { // TODO: Remove after implementing Global cache
                first: 100,
                last: null,
                next: null,
                previous: null,
                filter: { name: { startsWith: '' } },
                ordering: [{ name: 'ASC' }]
            })
        
        if (this.formData.analytes) {
            this.formData.analytes.forEach(el => {
                if (!this.statements.find(sl => sl.Type == this.formatTitleCase( el.type ))) {
                    this.statements.push({
                        Type: this.formatTitleCase( el.type )
                    })
                }
            })
        }
    },
    computed: {
        ...mapState('companies', ['companies']),
        ...mapState(['isItemsValid']),
        title() {
            return this.editMode ? `Update: ${this.formData.description}` : `Create Financial Report`
        }
    },
    methods: {
        ...mapActions('finances', ['create', 'update']),
      //...mapActions(['saveFinancialReport', 'createFinancialReport', 'prepStatementItems', 'updateFinancialReport', 'validateStatementItems', 'flushFinancialReport']),
      addStatement(type) {
          this.statements.push({
              Type: type
          });
      },
      removeStatement(ix) {
          this.statements.splice(ix, 1);
      },
      saveReport() {        
        if (this.validateReport()) {
            this.validateStatementItems()
            .then(() => {
                if (this.isItemsValid) {
                    this.prepStatementItems();

                    if (this.financialReport.no) {
                        this.updateFinancialReport(this.financialReport);
                    } else {
                        this.createFinancialReport(this.financialReport);
                    }
                }                
            })
        }        
      },
      validateReport() {
        let valid = true

        if (!this.formData.company) {
            this.vCompany.type = 'is-danger'
            this.vCompany.message = 'Please choose company'
            valid = false
        } else {
            this.vCompany.type = ''
            this.vCompany.message = ''
        }

        if (!this.formData.period) {
            this.vPeriod.type = 'is-danger'
            this.vPeriod.message = 'Please choose period'
            valid = false
        } else {
            this.vPeriod.type = ''
            this.vPeriod.message = ''
        }

        if (!this.formData.statementDate) {
            this.vStatementDate.type = 'is-danger'
            this.vStatementDate.message = 'Please set statement date'
            valid = false
        } else {
            this.vStatementDate.type = ''
            this.vStatementDate.message = ''
        }

        return valid
      },
      formatTitleCase(plain) {
        return _.startCase(plain.toLowerCase().replace('_', ' '));
      },
      clearVCompany() {
        this.vCompany.type = ''
        this.vCompany.message = ''
      },
      clearVPeriod() {
        this.vPeriod.type = ''
        this.vPeriod.message = ''
      },
      clearVStatementDate() {
        this.vStatementDate.type = ''
        this.vStatementDate.message = ''
      }
    },
    watch: {
        $route(to) {
            this.statements = []; // flush statements
            this.clearVCompany();
            this.clearVPeriod();
            this.clearVStatementDate();

            if (to.query.no) {
                this.$store.dispatch('fetchFinancialReport', parseInt(to.query.no, 10))
                    .then(() => {                    
                        
                    });
            } else {                
                this.flushFinancialReport();
            }
        }
    }
}

</script>