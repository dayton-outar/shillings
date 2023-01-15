<template>
    <form @submit.prevent="onSubmit">
        <div class="box my-4 mx-1">
            <h5 class="title is-5">Login</h5>
            <hr class="has-background-grey-light" />

            <b-field label="Username">
                <b-input maxlength="30"></b-input>
            </b-field>

            <b-field label="Password">
                <b-input 
                    type="password"
                    icon-pack="fas"
                    password-reveal>
                </b-input>
            </b-field>
            <hr class="has-background-grey-lighter thinner" />
            <div class="columns">
                <div class="column">
                    <b-button label="Login" type="is-info" size="is-medium" expanded native-type="submit" />
                </div>
            </div>
        </div>
    </form>
</template>

<script>

export default {
    props: ['isValid', 'isLoading', 'title'],
    methods: {
        onSubmit() {
            console.log('boom')
        }
    }
}

</script>