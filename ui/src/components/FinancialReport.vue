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
                <!--<b-button
                    @click="$refs.datepicker.toggle()"
                    icon-left="calendar-today"
                    type="is-primary" />-->
            </b-field>
        </div>
        <div class="column">
            <b-field>
                <b-checkbox>Is Audited?</b-checkbox>
            </b-field>
        </div>        
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
    data() {
        return {
            chosenCompany: null,
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchCompanies')
    },
    computed: {
        ...mapState(['companies'])
    },
    methods: {
      //...mapActions(['addPortfolio', 'flushPortfolio'])
    }
}

</script>