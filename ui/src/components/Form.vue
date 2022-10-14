<template>
    <form @submit.prevent="$emit('validate')">
        <div class="box my-4 mx-1">
            <h5 class="title is-5">{{ title }}</h5>
            <hr class="has-background-grey-light" />
            <div v-if="!isValid">
                <slot name="input"></slot>
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
            <transition 
                enter-active-class="bounceIn">
                <div v-if="isValid">
                    <slot name="confirm"></slot>
                    <hr class="has-background-grey-lighter thinner" />
                    <div class="columns">
                        <div class="column">
                            <b-button label="Cancel" size="is-medium" expanded @click.prevent="(isValid = false)" />
                        </div>
                        <div class="column">
                            <b-button label="OK" type="is-info" size="is-medium" expanded @click.prevent="$emit('save')" :disabled="isLoading" />
                        </div>
                    </div>                    
                </div>
            </transition>
            <b-loading :is-full-page="false" v-model="isLoading"></b-loading>
        </div>
    </form>
</template>

<script>

export default {
    props: ['isValid', 'isLoading', 'title']
}

</script>
