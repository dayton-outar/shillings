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
                    v-model="chosenPeriod"
                    placeholder="Choose Period" 
                    expanded>
                    <option value="0">Quarterly</option>
                    <option value="1">Annual</option>
                </b-select>
            </b-field>
        </div>
        <div class="column is-one-fifth">
            <b-field
                label="Date"
                label-position="inside">
                <b-datepicker
                    ref="datepicker"                    
                    v-model="chosenStatementDate"
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
            chosenCompany: null,
            chosenPeriod: null,
            chosenStatementDate: null,
            isAudited: null,
            statements: []
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchCompanies');
        if (this.$route.query.no) {
            this.$store.dispatch('fetchFinancialReport', parseInt(this.$route.query.no, 10))
                .then(() => {
                    if (this.statementItems) {
                        this.statementItems.forEach(el => {
                            if (!this.statements.find(sl => sl.Type == this.formatTitleCase( el.type ))) {
                                this.statements.push({
                                    Type: this.formatTitleCase( el.type )
                                });
                            }
                        });
                    }
                });
        }
    },
    computed: {
        ...mapState(['companies', 'statementItems'])
    },
    methods: {
      ...mapActions(['saveFinancialReport']),
      addStatement(type) {
          this.statements.push({
              Type: type
          }); // TODO: Put in vuex
      },
      removeStatement(ix) {
          this.statements.splice(ix, 1); // TODO: Put in vuex
      },
      saveReport() {
        this.saveFinancialReport({
            Company: this.chosenCompany,
            Period: this.chosenPeriod,
            StatementDate: this.chosenStatementDate,
            IsAudited: this.isAudited,
        });
      },
      formatTitleCase(plain) {
        return _.startCase(plain.toLowerCase().replace('_', ' '));
      },
    }
}

</script>