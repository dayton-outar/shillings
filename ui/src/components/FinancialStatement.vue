<template>
    <div class="column is-full">
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column is-four-fifths">
                    <h5 class="title is-5">{{ title }}</h5>
                </div>
                <div class="column is-flex is-justify-content-flex-end">
                    <b-button type="is-danger" icon-right="delete" @click="removeStatement" />
                </div>
            </div>
            <div class="columns">
                <b-table 
                    :data="statementItems"
                    :sort-icon="sortIcon" 
                    :sort-icon-size="sortIconSize"
                    :default-sort-direction="defaultSortDirection" 
                    :striped="true" 
                    :hoverable="true">

                    <b-table-column field="no" label="#" sortable v-slot="props">
                        {{ props.row.no }}
                    </b-table-column>

                    <b-table-column field="description" label="Description" sortable v-slot="props">
                        {{ props.row.description }}
                    </b-table-column>

                    <b-table-column field="amount" label="$" numeric sortable v-slot="props">
                        {{ formatMoney(props.row.amount) }}
                    </b-table-column>

                    <template #footer>
                        <td colspan="3">
                            <tr>
                                <td>
                                    #
                                </td>
                                <td>
                                    <b-field>
                                        <b-input placeholder="Description" v-model="iDescription" />
                                    </b-field>
                                </td>
                                <td>
                                    <b-field>
                                        <b-select 
                                            placeholder="Choose Section" 
                                            v-model="iSection"
                                            expanded>
                                            <option value="0">Revenue</option>
                                            <option value="1">Expenses</option>
                                            <option value="2">Gains</option>
                                            <option value="3">Losses</option>
                                            <option value="6">Assets</option>
                                            <option value="7">Liabilities</option>
                                            <option value="8">Liabilities</option>
                                        </b-select>
                                    </b-field>
                                </td>
                                <td>
                                    <b-dropdown
                                        :expanded="true"
                                        v-model="selectedAnalytes"
                                        multiple
                                        aria-role="list">
                                        
                                        <template #trigger>
                                            <b-button
                                                type="is-light"
                                                expanded
                                                icon-right="menu-down">
                                                ({{ selectedAnalytes.length }})
                                            </b-button>
                                        </template>
                                            
                                        <b-dropdown-item value="0" aria-role="listitem">
                                            Operating
                                        </b-dropdown-item>

                                        <b-dropdown-item value="1" aria-role="listitem">
                                            Direct
                                        </b-dropdown-item>

                                        <b-dropdown-item value="2" aria-role="listitem">
                                            Depreciation
                                        </b-dropdown-item>

                                        <b-dropdown-item value="3" aria-role="listitem">
                                            Impairment
                                        </b-dropdown-item>

                                        <b-dropdown-item value="4" aria-role="listitem">
                                            Interest
                                        </b-dropdown-item>

                                        <b-dropdown-item value="5" aria-role="listitem">
                                            Other
                                        </b-dropdown-item>

                                        <b-dropdown-item value="6" aria-role="listitem">
                                            Investment
                                        </b-dropdown-item>

                                        <b-dropdown-item value="7" aria-role="listitem">
                                            Tax
                                        </b-dropdown-item>

                                    </b-dropdown>
                                </td>
                                <td>
                                    <b-field>
                                        <b-input v-cleave="masks.price" v-model="iAmount" />
                                    </b-field>
                                </td>
                                <td class="is-flex is-justify-content-flex-end">
                                    <b-button type="is-primary" icon-right="playlist-plus" @click.prevent="addItem">Add</b-button>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Total
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                            </tr>
                        </td>
                    </template>

                    <template #empty>
                        <div class="has-text-centered">No records</div>
                    </template>
                </b-table>
            </div>
        </div>
    </div>
</template>

<script>
//import { mapState } from 'vuex'
import Cleave from 'cleave.js'

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
    props: ['title', 'no'],
    data() {
        return {
            defaultSortDirection: 'desc',
            sortIcon: 'arrow-up',
            sortIconSize: 'is-small',
            chosenCompany: null,
            selectedAnalytes: [],
            statementItems: [],
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
            iNo: 0,
            iDescription: '',
            iSection: 0,
            iAnalyte: [],
            iAmount: 'J$'
        }
    },
    computed: {

    },
    methods: {
        removeStatement() {
            this.$emit('removed', this.no)
        },
        addItem() {
          const amt = this.iAmount
          const strippedAmt = amt.toString().replace(/[^0-9.-]+/g,'')
          this.iNo = (this.iNo + 1)

          this.statementItems.push({
              no: this.iNo,
              description: this.iDescription,
              section: this.iSection,
              analyte: this.iAnalyte,
              amount: strippedAmt
          })

          console.log(this.statementItems)
          //localStorage.setItem('my-portfolio', JSON.stringify(this.statementItems) )
        },
        updateItem(payload) {
          const ix = this.statementItems.findIndex(p => p.id === payload.id);
          if (ix > -1) {
            this.statementItems[ix] = payload;
          }
          //localStorage.setItem('my-portfolio', JSON.stringify(this.statementItems) )
        },
        removeItem(id) {
          const ix = this.statementItems.findIndex(p => p.id === id);
          if (ix > -1) {
            this.statementItems.splice(ix, 1);
          }
          //localStorage.setItem('my-portfolio', JSON.stringify(this.statementItems) )
        },
        flushPortfolio() {
          this.statementItems = []
          //localStorage.removeItem('my-portfolio')
        },
        formatMoney(amount) { // TODO: Make global
            const cfi = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
            return cfi.format(amount)
        },
    }
}

</script>