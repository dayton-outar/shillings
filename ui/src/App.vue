<template>
  <div>
    <div v-if="isLoading" class="preloader"></div>
    <div class="bg-dark-blue-gradient">
      <div class="container">
        <div class="py-5 px-4">
          <img alt="Jamaica Stock Exchange" src="./assets/logo.png">
        </div>
        <div>
          <router-link to="/">Home</router-link> |
          <router-link to="/finance-report">Finance Report</router-link> |
          <router-link to="/companies">Companies</router-link> |
          <router-link to="/stocks">Stocks</router-link> |
          <router-link to="/markets">Markets</router-link>
        </div>
      </div>
    </div>
    <div class="bg-light-gray">
      <div class="container">        
        <div class="bg-white py-5 px-4">
          <router-view />
        </div>      
      </div>
    </div>
    <footer class="footer has-background-dark has-text-primary-light">
      <div class="content has-text-centered">
        <p>&copy; Dayton Outar 2021</p>
      </div>
    </footer>
  </div>
</template>

<script>
//import Dashboard from './components/Dashboard.vue'

export default {
  name: 'App',
  components: {
    //'dashboard': Dashboard
  },
  data() {
    return {
      isLoading: false
    }
  },
  watch: {
    $route: {
      immediate: true,
      handler(to) {
        document.title = to.meta.title || `JSE Stock Tracker`
      }
    }
  },
  beforeMount() {
    this.isLoading = false // true
  },
  methods: {
    setLoading(isItLoading) {
      this.isLoading = isItLoading
    }
  }
}

</script>

<style>

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  background: #fafafa;
}

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
  background-image: url(./assets/stocks-chart.png);
  animation: 1s beat 0.15s infinite alternate;
}

@keyframes beat {
  0% { transform: scale(1); }
	70% { transform: scale(1); }
  85% { transform: scale(1.3); }
  100% { transform: scale(1); }
}

.bg-white {
  background: #fff;
}

.bg-light-gray {
  background: #fafafa;
}

.bg-dark-blue-gradient {
    background: #013769;
    background: -moz-linear-gradient(left, #013769 0%, #0082c0 54%, #013769 100%);
    background: -webkit-gradient(linear, left top, right top, color-stop(0%,#013769), color-stop(54%,#0082c0), color-stop(100%,#013769));
    background: -webkit-linear-gradient(left, #013769 0%,#0082c0 54%,#013769 100%);
    background: -o-linear-gradient(left, #013769 0%,#0082c0 54%,#013769 100%);
    background: -ms-linear-gradient(left, #013769 0%,#0082c0 54%,#013769 100%);
    background: linear-gradient(to right, #013769 0%,#0082c0 54%,#013769 100%);
    -webkit-box-shadow: 0 20px 58px #013b6b inset;
    -ms-box-shadow: 0 20px 58px #013b6b inset;
    box-shadow: 0 20px 58px #013b6b inset;
}

.right-aligned {
    text-align: right !important;
}

</style>
