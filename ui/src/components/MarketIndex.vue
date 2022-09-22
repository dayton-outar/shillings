<template>
    <div>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="marketIndex.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field
                        label="Company">
                        <b-select 
                            v-model="marketIndex.market"
                            placeholder="Choose Market"
                            expanded>
                            <option
                                v-for="market in markets" 
                                :key="market.code"
                                :value="market">
                                {{market.name}}
                            </option>
                        </b-select>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-button label="Save" type="is-info" size="is-medium" expanded @click.prevent="submit" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
//import { mapState, mapActions } from 'vuex' 
// import moment from 'moment'

export default {
    props: ['marketIndexData', 'editMode'],
    data() {
        return {
            marketIndex: JSON.parse(JSON.stringify(this.marketIndexData)),
        }
    },
    beforeCreate() {
        this.$store.dispatch('fetchMarkets')
    },
    computed: {
        ...mapState(['markets'])
    },
    methods: {
        //...mapActions(['updateStock', 'createStock']),
        submit() {
            if (this.editMode) {
                //this.updateStock( this.stock );
            } else {
                //this.createStock( this.stock );
            }
        }
    }
}

</script>