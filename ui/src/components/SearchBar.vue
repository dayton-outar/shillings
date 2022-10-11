<template>
    <div>
        <b-collapse class="card" animation="slide" aria-id="contentIdForIndSearch">
            <template #trigger="props">
                <div class="card-header" 
                        role="button" 
                        aria-controls="contentIdForIndSearch"
                        :aria-expanded="props.open">
                    <p class="card-header-title">Search</p>
                    <a class="card-header-icon">
                        <b-icon pack="fas" :icon="props.open ? 'caret-down' : 'caret-up'"></b-icon>
                    </a>
                </div>
            </template>

            <div class="card-content">
                <form @submit.prevent="$emit('submit', { searchWord })">
                    <div class="columns">
                        <div class="column">
                            <b-field>
                                <b-input 
                                    v-model="searchWord" 
                                    placeholder="Search ..." 
                                    type="Search"
                                    size="is-medium" 
                                    expanded>
                                </b-input>
                                <div class="control">
                                    <b-button class="button is-primary" size="is-medium" native-type="submit">Search</b-button>
                                </div>
                            </b-field>
                        </div>
                    </div>
                </form>
            </div>
        </b-collapse>
    </div>
</template>

<script>

export default {
    data() {
        return {
            searchWord: ''
        }
    }
}

</script>