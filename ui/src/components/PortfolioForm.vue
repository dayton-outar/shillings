<template>
  <div class="box">
    <h4 class="title is-4">Add Portfolio</h4>
    <div class="columns">
        <div class="column">
            <b-field
                label="Security"
                label-position="inside">
                <b-select 
                  v-model="chosenCompany"
                  placeholder="Choose Security">
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
            <b-button @click.prevent="addMyPortfolio" expanded type="is-link" size="is-medium">Add</b-button>
        </div>        
    </div>
    <!--
    <divclass="columns">
      <div class="column">
        
      </div>
    </div>
    -->
    <b-notification
        auto-close
        has-icon
        :type="notificationType"
        v-model="isNotificationActive"
        aria-close-label="Close notification">
        {{ notificationMessage }}
    </b-notification>
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
        chosenCompany: null,
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
        },
        isNotificationActive: false,
        notificationMessage: '',
        notificationType: 'is-success'
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
            name: this.chosenCompany.name
          },
          volume: parseInt(strippedVolume === '' ? 0 : strippedVolume, 10),
          unitPrice: parseFloat(strippedPrice === '' ? 0 : strippedPrice)
        }).then( () => {
          this.chosenCompany = null
          this.volume = 0
          this.unitPrice = 0
          this.notificationType = 'is-success'
          this.notificationMessage = 'Successfully added new stock holding'
          this.isNotificationActive = true          
        }).catch( () => {
          this.notificationType = 'is-warning'
          this.notificationMessage = 'Something went wrong'
          this.isNotificationActive = true
        })
      }      
    }
})

</script>