<template>
    <div>
        <div class="box my-4 mx-1">
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Code"
                        label-position="inside">
                        <b-input v-model="industry.name"></b-input>
                    </b-field>
                </div>
            </div>
            <div class="columns">
                <div class="column">
                    <b-field 
                        label="Name"
                        label-position="inside">
                        <b-input v-model="industry.wiki"></b-input>
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
    props: ['industryData', 'editMode'],
    data() {
        return {
            industry: JSON.parse(JSON.stringify(this.industryData)),
        }
    },
    computed: {},
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