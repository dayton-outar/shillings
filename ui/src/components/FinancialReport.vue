<template>
    <div>
    <h4 class="title is-4">Financial Report</h4>
    <div class="columns">
        <div class="column">
            <b-field
                label="Company"
                label-position="inside">
                <b-select 
                  v-model="chosenCompany"
                  placeholder="Choose Company">
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
                label-position="inside">
                <b-select 
                    v-model="this.financialReport.period"
                    placeholder="Choose Period" 
                    expanded>
                    <option value="QUARTERLY">Quarterly</option>
                    <option value="ANNUAL">Annual</option>
                </b-select>
            </b-field>
        </div>
        <div class="column is-one-fifth">
            <b-field
                label="Date"
                label-position="inside">
                <b-datepicker
                    ref="datepicker"                    
                    v-model="statementDate"
                    label-position=""
                    placeholder="Set Statement Date"
                    expanded>
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
            statements: []
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
        statementDate: {
            get() {
                return new Date(this.financialReport.statementDate)
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
      ...mapActions(['saveFinancialReport', 'createFinancialReport', 'prepStatementItems', 'updateFinancialReport']),
      addStatement(type) {
          this.statements.push({
              Type: type
          }); // TODO: Put in vuex
      },
      removeStatement(ix) {
          this.statements.splice(ix, 1); // TODO: Put in vuex
      },
      saveReport() {
          // TODO: parse amounts to decimal by removing J$ prefix.
        this.prepStatementItems();

        if (this.reportNo) {
            console.log( 'Update' );
            // this.updateFinancialReport({
            //     No: parseInt(this.$route.query.no, 10),
            //     Company: this.chosenCompany,
            //     Period: this.chosenPeriod,
            //     StatementDate: this.chosenStatementDate,
            //     Description: `${this.chosenCompany.name} ${_.startCase(this.chosenPeriod)} Report`,
            //     IsAudited: this.isAudited,
            //     Logged: new Date(),
            //     Analytes: JSON.parse( JSON.stringify(this.financialReport.analytes) ),
            // });
        } else {
            console.log( 'Create' );
            // this.createFinancialReport({
            //     Company: this.chosenCompany,
            //     Period: this.chosenPeriod,
            //     StatementDate: this.chosenStatementDate,
            //     Description: `${this.chosenCompany.name} ${_.startCase(this.chosenPeriod)} Report`,
            //     IsAudited: this.isAudited,
            //     Logged: new Date(),
            //     Analytes: JSON.parse( JSON.stringify(this.financialReport.analytes) ),
            // });
        }
        
      },
      formatTitleCase(plain) {
        return _.startCase(plain.toLowerCase().replace('_', ' '));
      },
    },
    watch: {
        $route(to) {
            if (to.query.no) {
                //this.report.no = parseInt(to.query.no, 10);
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
                //this.report.no = null;
            }
        }
    }
}

</script>