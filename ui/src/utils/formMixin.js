export default {
    props: ['data', 'editMode'],
    data() {
        return {
            createTitle: '[Create Data]',
            formData: JSON.parse(JSON.stringify(this.data)),
            isValid: false,
            isLoading: false,
            validation: {
                name: {
                    type: '',
                    message: ''
                }
            }
        }
    },
    computed: {
        title() {
            return this.editMode ? `Update: ${this.data.name}` : this.createTitle
        }
    },
    methods: {
        cancel() {
            this.isValid = false
        },
        assign() {},
        save() {
            this.isLoading = true

            this.assign()

            if (this.editMode) {
                this.update( this.formData )
                    .then(() => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `Successfully updated`,
                            confirmText: 'OK',
                            type: 'is-success',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'circle-check',
                            onConfirm: () => {                                
                                this.$emit('close', 'updated')
                            }
                        })
                    })
                    .catch(err => {    
                        this.isLoading = false

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
            } else {
                this.create( this.formData )
                    .then(() => {
                        this.isLoading = false

                        this.$buefy.dialog.alert({
                            title: this.title,
                            message: `Successfully created`,
                            confirmText: 'OK',
                            type: 'is-success',
                            hasIcon: true,
                            iconPack: 'fas',
                            icon: 'circle-check',
                            onConfirm: () => {
                                this.$emit('close', 'created')
                            }
                        })
                    })
                    .catch(err => {
                        this.isLoading = false

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

        },
        validate(){
            let valid = true

            if (!this.formData.name) {
                this.validation.name.type = 'is-danger'
                this.validation.name.message = 'Please enter name'
                valid = false
            } else {
                this.validation.name.type = ''
                this.validation.name.message = ''
            }

            this.isValid = valid
        }
    }
}