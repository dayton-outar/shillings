<template>
    <div class="column is-full">
        <div class="box my-4 mx-1">        
            <div class="columns">
                <div class="column is-four-fifths">
                    <h5 class="title is-5">{{ no }} - {{ title }}</h5>
                </div>
                <div class="column">
                    <b-button 
                        type="is-danger"
                        icon-right="delete"
                        @click="removeStatement" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
//import { mapState } from 'vuex'

export default {
    props: ['title', 'no'],
    data() {
        return {
            chosenCompany: null,
        }
    },
    computed: {
        
    },
    methods: {
      removeStatement() {
          this.$emit('removed', this.no)
      }
    }
}

</script>