<template>
    <div class="columns">
        <div class="column">
            <b-field
                label="Security"
                label-position="inside">
                <b-dropdown
                expanded
                v-model="chosenCompany"
                aria-role="list">
                <template #trigger>
                    <b-button
                    :label="chosenCompany.security"
                    type="is-light"
                    expanded
                    icon-right="menu-down">
                    </b-button>
                </template>
                
                <b-dropdown-item aria-role="listitem" 
                    v-for="company in companies" 
                    :key="company.code"
                    :value="company">
                    {{company.security}}
                </b-dropdown-item>
                </b-dropdown>
            </b-field>
        </div>
        <div class="column is-one-fifth">
            <b-field
                label="Volume" 
                label-position="inside">
                <b-input 
                    v-model="volume"
                    v-cleave="masks.volume"
                    custom-class="right-aligned" />
            </b-field>
        </div>
        <div class="column is-one-fifth">
            <b-field
                label="Price"
                label-position="inside">
                <b-input
                    v-model="unitPrice"
                    v-cleave="masks.price"
                    custom-class="right-aligned" />
            </b-field>
        </div>
        <div class="column">
            <b-button @click.prevent="addMyPortfolio" type="is-link">Add</b-button>
        </div>        
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
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
}

export default ({
    directives: { cleave },
    data() {
      return {
        chosenCompany: {
          code: '',
          security: '-- NONE --'
        },
        volume: 0,
        unitPrice: 0,
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
    computed: {
        ...mapState(['companies'])
    },
    methods: {
      ...mapActions(['addPortfolio', 'flushPortfolio']),
      addMyPortfolio() {
        const initPrice = this.unitPrice
        const strippedPrice = initPrice.toString().replace(/[^0-9.-]+/g,'')
        const initVolume = this.volume
        const strippedVolume = initVolume.toString().replace(/[^0-9.-]+/g,'')

        this.addPortfolio({
          security: {
            code: this.chosenCompany.code,
            name: this.chosenCompany.security
          },
          volume: parseInt(strippedVolume === '' ? 0 : strippedVolume, 10),
          unitPrice: parseFloat(strippedPrice === '' ? 0 : strippedPrice)
        })
      }      
    }
})

</script>