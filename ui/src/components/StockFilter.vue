<template>
  <div>
    <p>{{ msg }}</p>
    <section>
      <b-button @click="clickMe">Click Me</b-button>
    </section>
  </div>
</template>

<script>
export default {
  name: 'StockFilter',
  props: {
    msg: String
  },
  methods: {
    clickMe() {
      this.$buefy.notification.open('Clicked!')
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>