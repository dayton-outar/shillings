<template>
    <article class="media">
        <figure class="media-left" v-if="data.company">
            <div class="image is-48x48">
                <img class="is-rounded"
                    :src="(getLogo(data.company.files) && getLogo(data.company.files).length > 0 ? `${fileApiHost}?no=${getLogo(data.company.files)[0].no}` : require(`../assets/no-image.png`))" alt="Company Logo" />
            </div>
        </figure>
        <div class="media-content">
            <small v-if="data.company">{{ data.company.name}}</small>
            <p><span class="tag is-light"><small>{{ data.stockType }}</small></span> | {{ data.code }}</p>
        </div>
    </article>
</template>

<script>
import config from '../config'
import utilMixin from '../utils/utilMixin'

export default {
    name: 'stock-tag',
    props: ['data'],
    mixins: [utilMixin],
    data() {
        return {
            fileApiHost: config.fileApiHost
        }
    }
}

</script>