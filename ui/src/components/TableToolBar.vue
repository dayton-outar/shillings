<template>
    <nav class="level">
        <div class="level-left">
            <div class="level-item">
                <b-dropdown
                    v-model="currentLength" 
                    aria-role="list"
                    @change="changeLen">
                    <template #trigger>
                        <b-button :label="currentLength.toString()" type="is-info" />
                    </template>
                    
                    <b-dropdown-item v-for="(len, index) in pageLengths" :key="index" :value="len" aria-role="listitem">
                        {{ len }}
                    </b-dropdown-item>
                </b-dropdown>
            </div>
        </div>
        
        <div class="level-right">
            <div class="level-item">
                <b-button type="is-info" icon-pack="fas" icon-left="rotate-right" @click.prevent="$emit('refresh')" />
            </div>
        </div>
    </nav>
</template>

<script>

export default {
    props: ['page', 'pageLengths'],
    data() {
        return {
            currentLength: this.page
        }
    },
    methods: {
        changeLen(l) {
            this.$emit('change', l)
        }
    }
}

</script>