<template>
    <div class="column is-full">
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column is-four-fifths">
                    <h5 class="title is-5">{{ type }}</h5>
                </div>
                <div class="column is-flex is-justify-content-flex-end">
                    <b-button 
                        type="is-danger" 
                        icon-pack="fas"
                        icon-right="trash" 
                        @click="removeStatement" />
                </div>
            </div>
            <div class="columns">
                <div class="column is-full is-flex is-justify-content-flex-end">
                    <b-button 
                        type="is-primary" 
                        icon-pack="fas"
                        icon-right="square-plus" 
                        @click.prevent="addItem">Add</b-button>
                </div>
            </div>
            <div class="columns">
                <div class="column is-full">                    
                    <b-table 
                        :data="analytes"
                        :sort-icon="sortIcon" 
                        :sort-icon-size="sortIconSize"
                        :default-sort-direction="defaultSortDirection" 
                        :striped="true" 
                        :hoverable="true">

                    <b-table-column field="no" label="#" sortable v-slot="props" width="5%">
                        {{ props.row.sequence }}
                    </b-table-column>

                    <b-table-column field="description" label="Description" sortable v-slot="props" width="35%">
                        <b-field 
                            v-if="getState(props.row.state)" 
                            :type="props.row.vDesc.type" 
                            :message="props.row.vDesc.message">
                            <b-input 
                                :ref="(`description-${type}-${props.row.sequence}`)" 
                                :value="props.row.description" 
                                @keyup.up.native="previousDescription(props.row.sequence)"
                                @keyup.down.native="nextDescription(props.row.sequence)" 
                                @input="updateItem(props.row.sequence, 'description', $event)" />
                        </b-field>
                        <p v-else>{{ props.row.description }}</p>
                    </b-table-column>

                    <b-table-column field="section" label="" sortable v-slot="props">
                        <b-field 
                            v-if="getState(props.row.state)"
                            :type="props.row.vSec.type" 
                            :message="props.row.vSec.message">
                            <b-select placeholder="Choose Section" :value="props.row.section" @input="updateItem(props.row.sequence, 'section', $event)" expanded>
                                <option 
                                    v-for="section in statementSections" 
                                    :key="`section_${section}`"
                                    :value="section">{{ formatTitleCase(section) }}</option>
                            </b-select>
                        </b-field>
                        <p v-else>{{ formatTitleCase(props.row.section) }}</p>
                    </b-table-column>

                    <b-table-column field="analyte" label="" sortable v-slot="props">
                        <b-field 
                            v-if="getState(props.row.state)">
                            <b-tooltip 
                                :label="props.row.vAnl.message" 
                                :always="(props.row.vAnl.message !== '')"
                                :active="(props.row.vAnl.message !== '')"
                                :type="props.row.vAnl.type">
                                <b-dropdown :expanded="true" v-model="props.row.analyte" multiple aria-role="list" @change="updateItem(props.row.sequence, 'analyte', $event)">

                                    <template #trigger>
                                        <b-button type="is-light" expanded icon-right="menu-down">
                                            ({{ props.row.analyte ? props.row.analyte.length : 0 }})
                                        </b-button>
                                    </template>

                                    <b-dropdown-item 
                                        aria-role="listitem"
                                        v-for="ass in getSectionAssays(props.row.section)"
                                        :key="`assay_${ass}`"
                                        :value="ass">
                                        {{ formatTitleCase(ass) }}
                                    </b-dropdown-item>

                                </b-dropdown>
                            </b-tooltip>
                        </b-field>                        
                    </b-table-column>

                    <b-table-column field="amount" label="$'000" numeric sortable v-slot="props">
                        <b-field 
                            v-if="getState(props.row.state)"
                            :type="props.row.vAmt.type" 
                            :message="props.row.vAmt.message">
                            <b-input 
                                :ref="(`amount-${type}-${props.row.sequence}`)" 
                                v-cleave="masks.price" 
                                custom-class="text-right" 
                                :value="props.row.amount" 
                                @keyup.up.native="previousAmount(props.row.sequence)"
                                @keyup.down.native="nextAmount(props.row.sequence)"
                                @input="updateItem(props.row.sequence, 'amount', $event)" />
                        </b-field>
                        <p v-else>{{ formatMoney(props.row.amount) }}</p>
                    </b-table-column>

                    <b-table-column v-slot="props" width="5%">
                        <template>
                            <b-button
                                v-if="getState(props.row.state)"
                                @click="closeItem(props.row.sequence)"
                                size="is-small"
                                type="is-info"
                                icon-pack="fas"
                                icon-right="close" />
                            <b-button
                                v-else
                                @click="openItem(props.row.sequence)"
                                size="is-small"
                                type="is-info"
                                icon-pack="fas"
                                icon-right="pen-to-square" />
                        </template>
                    </b-table-column>

                    <b-table-column v-slot="props" width="5%">
                        <template>
                            <b-button                            
                                @click="removeItem(props.row.sequence)"
                                size="is-small"
                                type="is-danger"
                                icon-pack="fas"
                                icon-right="trash" />
                        </template>
                    </b-table-column>

                    <template #footer>
                        <th></th>
                        <th>{{ summaryTitle }}</th>
                        <th></th>
                        <th></th>
                        <th class="right-aligned">{{ formatMoney( netValue ) }}</th>
                        <th></th>
                        <th></th>
                    </template>

                    <template #empty>
                        <div class="has-text-centered">No records</div>
                    </template>
                </b-table>
                </div>                
            </div>
            <div class="columns">
                <div class="column is-full is-flex is-justify-content-flex-end">
                    <b-button 
                        type="is-primary" 
                        icon-pack="fas"
                        icon-right="square-plus" 
                        @click.prevent="addItem">Add</b-button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex'
import Cleave from 'cleave.js'

import utilMixin from '../utils/utilMixin'

const cleave = {
    name: 'cleave',
    bind(el, binding) {
        const input = el.querySelector('input')
        input._vCleave = new Cleave(input, binding.value)
    },
    unbind(el) {
        const input = el.querySelector('input')
        input._vCleave.destroy()
    }
} // TODO: Remove duplication. I think this should be globally accessible

export default {
    directives: { cleave },
    props: ['data', 'type', 'no'],
    mixins: [utilMixin],
    data() {
        return {
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            selectedAnalytes: [],
            isItemsValid: true,
            analytes: JSON.parse(JSON.stringify(this.data.filter(s => s.type === this.type.replace(' ', '_').toUpperCase()))).map(a => { a.state = 'Closed'; return a; }),
            masks: {
                price: {
                    numeral: true,
                    numeralThousandsGroupStyle: 'thousand',
                    prefix: 'J$'
                },
                volume: {
                    numeral: true,
                    numeralDecimalScale: 0,
                    numeralThousandsGroupStyle: 'thousand'
                }
            }
        }
    },
    beforeCreate() {
      this.$store.dispatch('dependencies/fetch');   
    },
    computed: {
        ...mapState('dependencies', ['dependencies']),
        statementSections() {
            const iss = this.dependencies.sectionals.findIndex(ss => ss.type.toLowerCase() === this.type.replace(' ', '_').toLowerCase())

            return this.dependencies.sectionals[iss].sections
        },
        summaryTitle() {
            let title = ''

            switch(this.type) {
                case 'Income':
                    title = 'Net Income'
                    break
                case 'Financial Position':
                    title = 'Total Equity and Liabilities'
                    break
                case 'Cash Flow':
                    title = 'Net Cash Change'
                    break
            }

            return title
        },
        totalRevenues() {
            return this.get('REVENUES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalGains() {
            return this.get('GAINS').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalExpenses() {
            return this.get('EXPENSES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalLosses() {
            return this.get('LOSSES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalEquity() {
            return this.get('EQUITY').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalLiabilities() {
            return this.get('LIABILITIES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalOperations() {
            return this.get('OPERATING_ACTIVITIES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalFinances() {
            return this.get('FINANCING_ACTIVITIES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        totalInvestments() {
            return this.get('INVESTING_ACTIVITIES').reduce((t, v) => t + (this.parseMoney(v.amount)), 0)
        },
        netValue() {
            let netVal = 0

            switch(this.type) {
                case 'Income': 
                    netVal = (this.totalRevenues + this.totalGains) - (this.totalExpenses + this.totalLosses)
                    break
                case 'Financial Position': 
                    netVal = (this.totalEquity + this.totalLiabilities)
                    break
                case 'Cash Flow':
                    netVal = (this.totalOperations + this.totalFinances + this.totalInvestments)
                    break
            }
            
            return netVal

        }
    },
    methods: {
        get(section) {
            return this.analytes.filter(a => a.section === section)
        },
        removeStatement() {
            this.$emit('removed', this.no)
        },
        validateItem(item) {
            if (!item.description) {
                item.vDesc.type = 'is-danger'
                item.vDesc.message = 'Please enter description'

                this.isItemsValid = false
            } else {
                item.vDesc.type = ''
                item.vDesc.message = ''
            }

            if (!item.section) {
                item.vSec.type = 'is-danger'
                item.vSec.message = 'Please choose section'

                this.isItemsValid = false
            } else {
                item.vSec.type = ''
                item.vSec.message = ''
            }

            if (!item.analyte.length) {
                item.vAnl.type = 'is-danger'
                item.vAnl.message = 'Please choose categories'

                this.isItemsValid = false
            } else {
                item.vAnl.type = ''
                item.vAnl.message = ''
            }

            let amt = this.parseMoney(item.amount);
            if (!amt) {
                item.vAmt.type = 'is-danger'
                item.vAmt.message = 'Please enter amount'

                this.isItemsValid = false
            } else {
                item.vAmt.type = ''
                item.vAmt.message = ''
            }
        },
        validateItems() {
            this.isItemsValid = true

            this.analytes.forEach(i => {
                if (i.state == 'Opened') {
                    this.validateItem(i)
                }
            })
        },
        addItem() {
          const sqs = this.analytes.map(a => a.sequence);
          const maxNo = sqs.length
          let iNo = maxNo + 1;

          this.analytes.push({
              no: 0,
              sequence: iNo,
              description: '',
              vDesc: {
                type: '',
                message: ''
              },
              vSec: {
                type: '',
                message: ''
              },
              vAnl: {
                type: '',
                message: ''
              },
              vAmt: {
                type: '',
                message: ''
              },
              type: this.type.replace(' ', '_').toUpperCase(),
              section: 0,
              analyte: this.selectedAnalytes,
              state: 'Opened',
              amount: 'J$'
          })
        },
        updateItem(n, p, v) {
            const ix = this.analytes.findIndex(p => p.sequence === n)
            this.analytes[ix][p] = v
            if (p === 'section') {
                this.analytes[ix]['analyte'] = []
            }
        },
        removeItem(id) {
            const ix =this.analytes.findIndex(p => p.sequence === id)
            if (ix > -1) {
                this.analytes.splice(ix, 1)
                this.rearrangeSequence(id);
            }
        },
        rearrangeSequence(start) {
            // Find all items with sequence > start
            let affected = this.analytes.filter(i => i.sequence > start)
            for(let x in affected) {
                affected[x].sequence--
            }
        },
        flushItems() {
          this.analytes = []
        },
        getState(state) {
            return state === 'Opened'
        },
        getSectionAssays(sectionName) {
            let ias = -1
            if (sectionName) {
                ias = this.dependencies.assays.findIndex(as => as.sectional.toLowerCase() === sectionName.replace(' ', '_').toLowerCase())
            }

            return ias > -1 ? this.dependencies.assays[ias].assay : []
        },
        openItem(sequence) {
            const item = this.analytes.find(p => p.sequence === sequence)
            if (item) {
                item.state = 'Opened'
                item.vDesc = {
                    type: '',
                    message: ''
                }
                item.vSec = {
                    type: '',
                    message: ''
                }
                item.vAnl = {
                    type: '',
                    message: ''
                }
                item.vAmt = {
                    type: '',
                    message: ''
                }
            }
        },
        closeItem(sequence) {
            const item = this.analytes.find(p => p.sequence === sequence)

            if (item) {
                
                this.isItemsValid = true
                this.validateItem(item)

                if (this.isItemsValid) {
                    item.state = 'Closed'
                }

            }            
        },
        getItems() {
            return this.analytes
        },
        nextDescription(sequence) {
            if (sequence < this.analytes.length) {
                sequence++;
            }
            if (this.$refs[`description-${this.type}-${sequence}`]) {
                this.$refs[`description-${this.type}-${sequence}`].focus()
            }
        },
        previousDescription(sequence) {
            if (sequence > 1) {
                sequence--;
            }
            if (this.$refs[`description-${this.type}-${sequence}`]) {
                this.$refs[`description-${this.type}-${sequence}`].focus()
            }
        },
        nextAmount(sequence) {
            if (sequence < this.analytes.length) {
                sequence++;
            }
            if (this.$refs[`amount-${this.type}-${sequence}`]) {
                this.$refs[`amount-${this.type}-${sequence}`].focus()
            }
        },
        previousAmount(sequence) {
            if (sequence > 1) {
                sequence--;
            }
            if (this.$refs[`amount-${this.type}-${sequence}`]) {
                this.$refs[`amount-${this.type}-${sequence}`].focus()
            }
        }
    }
}

</script>

<style scoped>

.text-right {
    text-align: right;
}

</style>