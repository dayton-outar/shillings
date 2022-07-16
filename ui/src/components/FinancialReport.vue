<template>
    <div>
    <h4 class="title is-4">Financial Report</h4>
    <div class="columns">
        <div class="column">
            <b-field
                label="Company"
                label-position="inside"
                :type="vCompany.type"
                :message="vCompany.message">
                <b-select 
                  v-model="chosenCompany"
                  placeholder="Choose Company"
                  @input="clearVCompany">
                  <option
                    v-for="company in companies" 
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
                    v-model="period"
                    placeholder="Choose Period" 
                    expanded
                    @input="clearVPeriod">
                    <option value="QUARTERLY">Quarterly</option>
                    <option value="ANNUAL">Annual</option>
                </b-select>
            </b-field>
        </div>
        <div class="column is-one-fifth">
            <b-field
                label="Date"
                label-position="inside"
                :type="vStatementDate.type"
                :message="vStatementDate.message">
                <b-datepicker
                    ref="datepicker"                    
                    v-model="statementDate"
                    label-position=""
                    placeholder="Set Statement Date"
                    expanded
                    @input="clearVStatementDate">
                </b-datepicker>
            </b-field>
        </div>
        <div class="column">
            <b-field>
                <b-checkbox v-model="isAudited">Is Audited?</b-checkbox>
            </b-field>
        </div>        
    </div>
    
    <div v-for="(stmt, ix) in statements" :key="ix" class="columns">
        <financial-statement 
            :type="stmt.Type" 
            :no="ix" 
            @removed="removeStatement" />
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
                        icon-right="plus" />
                </template>


                <b-dropdown-item aria-role="listitem" @click="addStatement('Income')">Income</b-dropdown-item>
                <b-dropdown-item aria-role="listitem" @click="addStatement('Financial Position')">Financial Position</b-dropdown-item>
                <b-dropdown-item aria-role="listitem" @click="addStatement('Cash Flow')">Cash Flow</b-dropdown-item>
            </b-dropdown>
        </div>
    </div>
    <div class="columns">
        <div class="column">
            <b-button 
                label="Save"
                type="is-info"
                expanded
                @click.prevent="saveReport" />
        </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import _ from 'lodash'

import FinancialStatement from './FinancialStatement.vue'

export default {
    components: {
        'financial-statement': FinancialStatement
    },
    data() {
        return {
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
    beforeCreate() {
        this.$store.dispatch('fetchCompanies');
    },
    computed: {
        ...mapState(['companies', 'financialReport', 'financialReportCompany']),
        chosenCompany: {
            get() {
                return this.financialReport.company
            },
            set(value) {
                this.$store.commit('updateReportCompany', value)
            }
        },
        period: {
            get() {
                return this.financialReport.period
            },
            set(value) {
                this.$store.commit('updateReportPeriod', value)
            }
        },
        statementDate: {
            get() {
                return this.financialReport.statementDate ? new Date(this.financialReport.statementDate) : null
            },
            set(value){
                this.$store.commit('updateReportDate', value)
            }
        },
        isAudited: {
            get() {
                return this.financialReport.isAudited
            },
            set(value) {
                this.$store.commit('updateReportIsAudit', value)
            }
        }
    },
    methods: {
      ...mapActions(['saveFinancialReport', 'createFinancialReport', 'prepStatementItems', 'updateFinancialReport', 'flushFinancialReport']),
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
            this.prepStatementItems();

            if (this.financialReport.no) {
                console.log( 'Update', this.financialReport.no );
                // this.updateFinancialReport();
            } else {
                console.log( 'Create' );
                // this.createFinancialReport();
            }
        }        
      },
      validateReport() {
        let valid = true

        if (!this.financialReport.company) {
            this.vCompany.type = 'is-danger'
            this.vCompany.message = 'Please choose company'
            valid = false
        } else {
            this.vCompany.type = ''
            this.vCompany.message = ''
        }

        if (!this.financialReport.period) {
            this.vPeriod.type = 'is-danger'
            this.vPeriod.message = 'Please choose period'
            valid = false
        } else {
            this.vPeriod.type = ''
            this.vPeriod.message = ''
        }

        if (!this.financialReport.statementDate) {
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

            if (to.query.no) {
                this.$store.dispatch('fetchFinancialReport', parseInt(to.query.no, 10))
                    .then(() => {                        
                        if (this.financialReport.analytes) {
                            this.financialReport.analytes.forEach(el => {
                                if (!this.statements.find(sl => sl.Type == this.formatTitleCase( el.type ))) {
                                    this.statements.push({
                                        Type: this.formatTitleCase( el.type )
                                    });
                                }
                            });
                        }
                    });
            } else {
                this.flushFinancialReport();
            }
        }
    }
}

</script>