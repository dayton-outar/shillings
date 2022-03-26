<template>
    <b-dropdown :expanded="true" v-model="analytes" multiple aria-role="list">

        <template #trigger>
            <b-button type="is-light" expanded icon-right="menu-down">
                ({{ analytes.length }})
            </b-button>
        </template>

        <b-dropdown-item value="0" aria-role="listitem">
            Operating
        </b-dropdown-item>

        <b-dropdown-item value="1" aria-role="listitem">
            Direct
        </b-dropdown-item>

        <b-dropdown-item value="2" aria-role="listitem">
            Depreciation
        </b-dropdown-item>

        <b-dropdown-item value="3" aria-role="listitem">
            Impairment
        </b-dropdown-item>

        <b-dropdown-item value="4" aria-role="listitem">
            Interest
        </b-dropdown-item>

        <b-dropdown-item value="5" aria-role="listitem">
            Other
        </b-dropdown-item>

        <b-dropdown-item value="6" aria-role="listitem">
            Investment
        </b-dropdown-item>

        <b-dropdown-item value="7" aria-role="listitem">
            Tax
        </b-dropdown-item>

    </b-dropdown>
</template>

<script>
    export default {
        props: ['selected'],
        data() {
            return {
                analytes: this.selected
            }
        },
    }
</script>