<template>
    <form @submit.prevent="submit">
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="industry.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Wiki"
                        label-position="inside">
                        <b-input v-model="industry.wiki"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-button label="Close" size="is-medium" expanded @click.prevent="$emit('close')" />
                </div>
                <div class="column">
                    <b-button label="Save" type="is-info" size="is-medium" expanded native-type="submit" />
                </div>
            </div>
        </div>
    </form>
</template>

<script>
//import { mapState, mapActions } from 'vuex' 
import { mapMutations } from 'vuex' 
// import moment from 'moment'

export default {
    props: ['industryData', 'editMode'],
    data() {
        return {
            industry: JSON.parse(JSON.stringify(this.industryData)),
        }
    },
    computed: {},
    methods: {
        //...mapActions(['updateStock', 'createStock']),
        ...mapMutations('industries', ['add', 'modify']),
        submit() {
            console.log('submitted')
            // if (this.editMode) {
            //     this.modify( {
            //         type: 'industries',
            //         pk: 'no',
            //         payload: this.industry
            //     } )
            //     this.$emit('close')
            // } else {
            //     this.add( {
            //         type: 'industries',
            //         pk: 'no',
            //         payload: this.industry
            //     } )
            //     this.$emit('close')
            // }
        }
    }
}

</script>