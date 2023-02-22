<template>
    <article class="media">
        <figure class="media-left">
            <div class="image is-48x48">
                <img class="is-rounded"
                    :src="(getLogo(data.files) && getLogo(data.files).length > 0 ? `${fileApiHost}?no=${getLogo(data.files)[0].no}` : require(`../assets/no-image.png`))"
                    alt="Company Logo" />
            </div>
        </figure>
        <div class="media-content">
            <p v-if="data.webSite"><a :href="data.webSite"
                    target="_blank">{{ data.name }}</a></p>
            <p v-else>{{ data.name }}</p>
            <span v-for="(i, ix) in data.industries" :key="ix">
                <b-tag rounded>{{ i.name }}</b-tag>&nbsp;
            </span>
        </div>
    </article>
</template>

<script>
import config from '../config'
import utilMixin from '../utils/utilMixin'

export default {
    name: 'company-tag',
    props: ['data'],
    mixins: [utilMixin],
    data() {
        return {
            fileApiHost: config.fileApiHost
        }
    }
}

</script>