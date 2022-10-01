<template>
    <form @submit.prevent="validate">
        <div class="box my-4 mx-1">
            <h5 class="title is-5">{{ title }}</h5>
            <hr class="has-background-grey-light" />
            <div v-if="!isValid">                
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
                <hr class="has-background-grey-lighter thinner" />
                <div class="columns">
                    <div class="column">
                        <b-button label="Close" size="is-medium" expanded @click.prevent="$emit('close')" />
                    </div>
                    <div class="column">
                        <b-button label="Save" type="is-info" size="is-medium" expanded native-type="submit" />
                    </div>
                </div>
            </div>
            <div v-else>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Name">
                            {{ industry.name }}
                        </b-field>
                    </div>
                </div>
                <div class="columns">
                    <div class="column">
                        <b-field 
                            label="Wiki">
                            {{ industry.wiki }}
                        </b-field>
                    </div>
                </div>
                <hr class="has-background-grey-lighter thinner" />
                <div class="columns">
                    <div class="column">
                        <b-button label="Cancel" size="is-medium" expanded @click.prevent="(isValid = false)" />
                    </div>
                    <div class="column">
                        <b-button label="OK" type="is-info" size="is-medium" expanded @click.prevent="save" />
                    </div>
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
            isValid: false
        }
    },
    computed: {
        title() {
            return this.editMode ? `Update Industry: ${this.industry.name}` : `Create Industry`
        }
    },
    methods: {
        //...mapActions(['updateStock', 'createStock']),
        ...mapMutations('industries', ['add', 'modify']),
        save() {
            
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
        },
        validate(){
            console.log('validating ...')
            this.isValid = true
        }
    }
}

</script>

<style scoped>

.thinner {
    height: 1px !important;
}

</style>