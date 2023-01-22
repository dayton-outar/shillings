<template>
    <form @submit.prevent="onSubmit">
        <div class="box my-4 mx-1">
            <h5 class="title is-5">Login</h5>
            <hr class="has-background-grey-light" />

            <b-field 
                label="Email"
                :type="validation.email.type"
                :message="validation.email.message">
                <b-input v-model="email" maxlength="30"></b-input>
            </b-field>

            <b-field 
                label="Password"
                :type="validation.password.type"
                :message="validation.password.message">
                <b-input 
                    v-model="password"
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
import { mapActions } from 'vuex'

export default {
    data() {
        return {
            email: '',
            password: '',
            validation: {
                email: {
                    type: '',
                    message: ''
                },
                password: {
                    type: '',
                    message: ''
                },
            }
        }
    },
    methods: {
        ...mapActions('auth', ['authenticate']),
        onSubmit() {
            let valid = true

            if (!this.email) {
                this.validation.email.type = 'is-danger'
                this.validation.email.message = 'Please enter email'
                valid = false
            } else {
                this.validation.email.type = ''
                this.validation.email.message = ''
            }

            if (!this.password) {
                this.validation.password.type = 'is-danger'
                this.validation.password.message = 'Please enter password'
                valid = false
            } else {
                this.validation.password.type = ''
                this.validation.password.message = ''
            }

            if (valid) {
                this.authenticate({
                    email: this.email, 
                    password: this.password
                })
                    .then(() => {
                        this.$router.push({ path: '/finance-reports' })
                    })
                    .catch(err => {
                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `${err.message}`,
                            confirmText: 'OK',
                            type: 'is-danger',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'bug'
                        })
                    })
            }
        }
    }
}

</script>