<template>
  <div>
    <s-form :isValid="isValid" :isLoading="isLoading" :title="title" @validate="validate" @save="save" @cancel="cancel" @close="$emit('close')">
      <template #input>
        <div class="columns">
          <div class="column">
            <b-field
              label="Stock"
              label-position="inside"
              :type="validation.stock.type"
              :message="validation.stock.message">
              <b-select 
                v-model="formData.chosenStock"
                placeholder="Choose Stock"
                expanded>
                <option
                  v-for="stock in stocks.nodes" 
                  :key="stock.no"
                  :value="stock">
                  {{stock.name}}
                </option>
              </b-select>
            </b-field>
          </div>
        </div>
        <div class="columns">
          <div class="column">
            <b-field
              label="Quantity" 
              label-position="inside"
              :type="validation.volume.type"
              :message="validation.volume.message">
              <b-input 
                v-model="formData.volume"
                v-cleave="masks.volume"
                custom-class="right-aligned" />
            </b-field>
          </div>
        </div>
        <div class="columns">
          <div class="column">
            <b-field
              label="Purchase Price"
              label-position="inside"
              :type="validation.unitPrice.type"
              :message="validation.unitPrice.message">
              <b-input
                v-model="formData.unitPrice"
                v-cleave="masks.price"
                custom-class="right-aligned" />
            </b-field>
          </div>
        </div>
      </template>
      <template #confirm>
        <div class="columns">
          <div class="column">
            <b-field
              label="Stock">
              {{ formData.chosenStock.name }}
            </b-field>
          </div>
        </div>
        <div class="columns">
          <div class="column">
            <b-field
              label="Quantity">
              {{ formData.volume }}
            </b-field>
          </div>
        </div>
        <div class="columns">
          <div class="column">
            <b-field 
              label="Purchase Price">
              {{ formData.unitPrice }}
            </b-field>
          </div>
        </div>
      </template>
    </s-form>
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

import Form from './Form.vue'

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
    components: {
        's-form': Form,
    },
    data() {
      return {
        isValid: false,
        isLoading: false,
        title: 'Add Investment',
        validation: {
          stock: {
            type: '',
            message: ''
          },
          volume: {
            type: '',
            message: ''
          },
          unitPrice: {
            type: '',
            message: ''
          }
        },
        formData: {
          chosenStock: null,
          volume: 0,
          unitPrice: 0,
        },
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
    beforeCreate() {
      this.$store.dispatch('stocks/fetch', {
        first: 200,
        last: null,
        next: null,
        previous: null,
        filter: { name: { startsWith: '' } },
        ordering: [{ name: 'ASC' }]
      })
    },
    computed: {
        ...mapState('stocks', ['stocks']),
        ...mapState('trades', ['totalTrades'])
    },
    methods: {
      ...mapActions('holdings', ['add', 'flush']),
      cancel() {
        this.isValid = false
      },
      save() {
        this.isLoading = true

        const initPrice = this.formData.unitPrice
        const strippedPrice = initPrice.toString().replace(/[^0-9.-]+/g,'')
        const initVolume = this.formData.volume
        const strippedVolume = initVolume.toString().replace(/[^0-9.-]+/g,'')
        const volume = parseInt(strippedVolume === '' ? 0 : strippedVolume, 10)
        const unitPrice = parseFloat(strippedPrice === '' ? 0 : strippedPrice)

        const itrade = this.totalTrades.find(t => t.stock.no === this.formData.chosenStock.no)
        let newPrice = itrade ? itrade.closingPrice : 0
        let oldCost = volume * unitPrice
        let newCost = itrade ? volume * itrade.closingPrice : 0

        this.add({
          security: {
            no: this.formData.chosenStock.no,
            name: this.formData.chosenStock.name
          },
          volume: volume,
          unitPrice: unitPrice,
          purchaseCost: oldCost,
          currentPrice: newPrice,
          currentCost: newCost,
          variance: (newCost - oldCost)
        }).then( () => {
          this.isLoading = false
          this.$emit('close')
          this.notificationType = 'is-success'
          this.notificationMessage = 'Successfully added new stock holding'
          this.isNotificationActive = true          
        }).catch( () => {
          this.isLoading = false
          this.notificationType = 'is-warning'
          this.notificationMessage = 'Something went wrong'
          this.isNotificationActive = true
        })
      },
      validate(){
        let valid = true

        if (!this.formData.chosenStock) {
          this.validation.stock.type = 'is-danger'
          this.validation.stock.message = 'Please choose stock'
          valid = false
        } else {
          this.validation.stock.type = ''
          this.validation.stock.message = ''
        }

        if (!this.formData.volume) {
          this.validation.volume.type = 'is-danger'
          this.validation.volume.message = 'Please enter quantity of stock units'
          valid = false
        } else {
          this.validation.volume.type = ''
          this.validation.volume.message = ''
        }

        if (!this.formData.unitPrice) {
          this.validation.unitPrice.type = 'is-danger'
          this.validation.unitPrice.message = 'Please enter price stock units were purchased'
          valid = false
        } else {
          this.validation.unitPrice.type = ''
          this.validation.unitPrice.message = ''
        }

        this.isValid = valid
      }
    }
})

</script>