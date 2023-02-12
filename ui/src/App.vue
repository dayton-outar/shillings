<template>
  <div>
    <preloader :isLoading="isLoading" />
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
import { mapState, mapActions } from 'vuex'

import Preloader from './components/Preloader.vue'

export default {
  name: 'App',
  components: {
    'preloader': Preloader,
  },
  data() {
    return {}
  },
  computed: {
    ...mapState({ auth: state => state.auth.profile }),
    ...mapState({ isLoading: state => state.dependencies.isLoading })
  },
  watch: {
    $route: {
      immediate: true,
      handler(to) {
        document.title = to.meta.title || `JSE Stock Tracker`
      }
    }
  },
  created() {
    this.setLoading(true)
    this.fetch()
      .then(() => {
        // this.setLoading(false)
      })
  },
  methods: {
    ...mapActions('auth', ['fetch']),
    ...mapActions('dependencies', ['setLoading'])
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

.right-aligned {
    text-align: right !important;
}
</style>
