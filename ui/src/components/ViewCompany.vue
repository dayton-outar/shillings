<template>
    <div>
        <div class="columns">
            <div class="column">
                <div class="media">
                    <div class="media-left">
                        <figure class="image is-64x64">
                            <img :src="(getLogo(data.files) ? `${fileApiHost}?no=${getLogo(data.files)[0].no}` : require(`../assets/no-image.png`))" alt="Company Logo" />
                        </figure>
                    </div>
                    <div class="media-content">
                        <p class="title is-4">{{ data.name }}</p>
                        <p class="subtitle is-6">{{ data.code }}</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="columns has-border-top">
            <div class="column">
                <p>{{ data.about }}</p>
            </div>
        </div>
        <div class="columns has-border-top">
            <div class="column">
                <b-icon
                    pack="fas"
                    icon="calendar"
                    size="is-small">
                </b-icon> <strong>Founded</strong> {{ foundedYear(data.founded) }}
            </div>
        </div>
        <div class="columns has-border-top" v-if="data.webSite">
            <div class="column">
                <b-icon
                    pack="fas"
                    icon="globe"
                    size="is-small">
                </b-icon> <strong>Website</strong> <a :href="data.webSite" target="_blank">{{ data.webSite }}</a>
            </div>
        </div>
        <div class="columns has-border-top">
            <div class="column">
                <b-icon
                    pack="fas"
                    icon="people-group"
                    size="is-small">
                </b-icon> <strong>Employees</strong> {{ data.totalEmployed }}
            </div>
        </div>
        <!-- TODO: Industries, CEO (Owners & Staff list)? -->
    </div>
</template>

<script>
import moment from 'moment'

import config from '../config'
import utilMixin from '../utils/utilMixin'

export default {
    name: 'view-company',
    props: ['data'],
    mixins: [utilMixin],
    data() {
        return {
            fileApiHost: config.fileApiHost
        }
    },
    methods: {
        foundedYear(founded) {
            return moment(founded).toDate().getFullYear()
        }
    }
}

</script>

<style scoped>

.has-border-top {
    border-top: 1px solid #dadce0;
}

</style>