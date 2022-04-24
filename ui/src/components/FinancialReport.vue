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
                <b-select placeholder="Choose Period" expanded>
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
                    expanded
                    label-position=""
                    placeholder="Set Statement Date">
                </b-datepicker>
            </b-field>
        </div>
        <div class="column">
            <b-field>
                <b-checkbox>Is Audited?</b-checkbox>
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
                expanded />
        </div>
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'

import FinancialStatement from './FinancialStatement.vue'

export default {
    components: {
        'financial-statement': FinancialStatement
    },
    data() {
        return {
            chosenCompany: null,
            statements: []
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchCompanies')
    },
    computed: {
        ...mapState(['companies'])
    },
    methods: {
      addStatement(type) {
          this.statements.push({
              Type: type
          }) // TODO: Put in vuex
      },
      removeStatement(ix) {
          this.statements.splice(ix, 1) // TODO: Put in vuex
      }
    }
}

</script>