<template>
  <div>
    <div v-if="isLoading" class="preloader"></div>
    <div class="has-background-success">
      <div class="container">
        <b-navbar spaced type="is-success">
          <template #brand>
            <b-navbar-item tag="router-link" :to="{ path: '/' }">
              <img src="./assets/logo.png" alt="Shillings: Your Guide to Wealth">
            </b-navbar-item>
          </template>
          <template #start>
            <b-navbar-item v-if="auth.isAuthenticated" tag="router-link" :to="{ path: '/finance-reports' }">Finance Reports</b-navbar-item>
            <b-navbar-item v-if="auth.isAuthenticated" tag="router-link" :to="{ path: '/companies' }">Companies</b-navbar-item>
            <b-navbar-dropdown v-if="auth.isAuthenticated" label="Manage">
              <b-navbar-item tag="router-link" :to="{ path: '/stocks' }">Stocks</b-navbar-item>
              <b-navbar-item tag="router-link" :to="{ path: '/markets' }">Markets</b-navbar-item>
              <b-navbar-item tag="router-link" :to="{ path: '/indices' }">Indices</b-navbar-item>
              <b-navbar-item tag="router-link" :to="{ path: '/industries' }">Industries</b-navbar-item>
              <b-navbar-item tag="router-link" :to="{ path: '/rates' }">Interest Rates</b-navbar-item>
            </b-navbar-dropdown>            
          </template>
        </b-navbar>        
      </div>
    </div>
    <div class="">
      <div class="container">        
        <div class="has-background-white py-5 px-4">
          <router-view />
        </div>      
      </div>
    </div>
    <footer class="footer has-background-dark has-text-primary-light">
      <div class="content has-text-centered">
        <p>&copy; Kri&#962;y&#962; 2022</p>
      </div>
    </footer>
  </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
  name: 'App',
  data() {
    return {
      isLoading: false
    }
  },
  computed: {
    ...mapState({ auth: state => state.auth.profile })
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
  background: #f5f5f5;
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
  background-image: url(./assets/logo-icon.png);
  animation: 1s beat 0.15s infinite alternate;
}

@keyframes beat {
  0% { transform: scale(1); }
	70% { transform: scale(1); }
  85% { transform: scale(1.3); }
  100% { transform: scale(1); }
}

.right-aligned {
    text-align: right !important;
}

</style>
