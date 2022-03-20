<template>
    <div class="box">
        <h5 class="title is-5">{{ title }}</h5>
        <div class="columns">
        </div>
    </div>
</template>

<script>
//import { mapState } from 'vuex'

export default {
    props: ['title'],
    data() {
        return {
            chosenCompany: null,
        }
    },
    computed: {
        
    },
    methods: {
      
    }
}

</script>