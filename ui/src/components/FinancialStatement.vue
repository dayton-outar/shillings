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
                    :data="statementTypeItems"
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
                            <b-input :value="props.row.description" @input="updateItem(props.row.sequence, 'description', $event)" />
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
                                    :key="section"
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
                                        :key="ass"
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
                            <b-input v-cleave="masks.price" custom-class="input-text-right" :value="props.row.amount" @input="updateItem(props.row.sequence, 'amount', $event)" />
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
                        <th class="right-aligned">{{ formatNet() }}</th>
                        <th></th>
                        <th></th>
                    </template>

                    <template #empty>
                        <div class="has-text-centered">No records</div>
                    </template>
                </b-table>
                </div>                
            </div>
        </div>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import Cleave from 'cleave.js'
import _ from 'lodash'

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
    name: 'financial-statement',
    directives: { cleave },
    props: ['data', 'type', 'no'],
    data() {
        return {
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            selectedAnalytes: [],
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
            },
            iNo: 0
        }
    },
    beforeCreate() {
      this.$store.dispatch('fetchSections');
      this.$store.dispatch('fetchAssays');      
    },
    computed: {
        ...mapState(['sections', 'assays', 'financialReport', 'isItemsValid']),
        statementTypeItems() {
            return this.data.filter(s => s.type === this.type.replace(' ', '_').toUpperCase());
        },
        statementSections() {
            const iss = this.sections.findIndex(ss => ss.type.toLowerCase() === this.type.replace(' ', '_').toLowerCase());

            return this.sections[iss].sections;
        },
        summaryTitle() { // Throws error if fetchSection not completed
            const iss = this.sections.findIndex(ss => ss.type.toLowerCase() === this.type.replace(' ', '_').toLowerCase());

            return this.sections[iss] ? this.sections[iss].summaryTitle : '';
        }
    },
    methods: {
        ...mapActions(['addStatementItem', 'updateStatementItem', 'removeStatementItem', 'validateStatementItem', 'closeStatementItem', 'openStatementItem']),
        removeStatement() {
            this.$emit('removed', this.no)
        },
        addItem() {
          const sqs = this.statementTypeItems.map(a => a.sequence);
          const maxNo = Math.max(...sqs)
          this.iNo = maxNo > this.iNo ? (maxNo + 1) : (this.iNo + 1)

          this.addStatementItem({
              no: 0,
              sequence: this.iNo,
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
            this.updateStatementItem({
                sequence: n,
                type: this.type,
                key: p,
                value: v
            })
        },
        removeItem(id) {
          this.removeStatementItem({
              sequence: id,
              type: this.type
          });

          if (this.statementTypeItems.length === 0) {
              this.iNo = 0;
          }
          
          //localStorage.setItem('my-statement-items', JSON.stringify(this.financialReport.analytes) )
        },
        flushItems() {
          //this.flushStatementItems()
          //localStorage.removeItem('my-statement-items')
        },
        formatMoney(amount) { // TODO: Make global
            const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
            return cfi.format(amount)
        },
        formatTitleCase(plain) {
            return _.startCase(plain.toLowerCase().replace('_', ' '));
        },
        getState(state) {
            return state === 'Opened';
        },
        getSectionAssays(sectionName) {
            let ias = -1
            if (sectionName) {
                ias = this.assays.findIndex(as => as.sectional.toLowerCase() === sectionName.replace(' ', '_').toLowerCase())
            }

            return ias > -1 ? this.assays[ias].assay : []
        },
        openItem(sequence) {
            const item = this.data.find(p => p.type.toLowerCase() === this.type.replace(' ', '_').toLowerCase() && p.sequence === sequence)
            if (item) {
                item.state = 'Opened';
                item.vDesc = {
                type: '',
                message: ''
                };
                item.vSec = {
                type: '',
                message: ''
                };
                item.vAnl = {
                type: '',
                message: ''
                };
                item.vAmt = {
                type: '',
                message: ''
                };
            }
        },
        closeItem(sequence) {
            this.validateStatementItem({ type: this.type.replace(' ', '_').toUpperCase(), sequence: sequence })
                .then(() => {
                    this.closeStatementItem({ type: this.type.replace(' ', '_').toUpperCase(), sequence: sequence });
                })
            
        },
        formatNet() {
            const netValue = this.statementTypeItems.reduce((t, v) => {
                const amt = parseFloat(v.amount.toString().replace(/[^0-9.-]+/g,'')) || 0;

                return t + amt;
                }, 0);
            
            return this.formatMoney(netValue)
        }
    }
}

</script>

<style>

.input-text-right {
    text-align: right;
}

</style>