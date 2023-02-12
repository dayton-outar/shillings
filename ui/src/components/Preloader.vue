<template>
    <div v-show="isLoading" class="preloader"></div>
</template>

<script>

export default {
    props: ['isLoading']
}

</script>

<style scoped>
.preloader {
  position: fixed;
  left: 0px;
  top: 0px;
  width: 100%;
  height: 100%;
  z-index: 999999;
  background-color: #ffffff;
  background-position: center center;
  background-repeat: no-repeat;
  background-image: url(../assets/logo.png);
  animation: 1s beat 0.15s infinite alternate;
}

@keyframes beat {
  0% { transform: scale(1); }
	70% { transform: scale(1); }
  85% { transform: scale(1.3); }
  100% { transform: scale(1); }
}

</style>