<template>
  <div id="app">
    <header>
      <b-navbar toggleable="md" type="light" variant="light">
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
        <b-navbar-brand to="/">Food Tracker</b-navbar-brand>
        <b-collapse is-nav id="nav-collapse">
          <b-navbar-nav>
            <b-nav-item to="/food-records">Food Records</b-nav-item>
            <b-nav-item href="#" @click.prevent="login" v-if="!user">Login</b-nav-item>
            <b-nav-item href="#" @click.prevent="logout" v-else>Logout</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </header>

    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
  /* eslint-disable */
  export default {
    name: 'app',
    data () {
      return {
        user: null
      }
    },
    async created() {
      await this.refreshUser()
    },
    methods: {
      login () {
        this.$auth.loginRedirect()
      },
      async onRouteChange() {
        await this.refreshUser()
      },
      async refreshUser() {
        this.user = await this.$auth.getUser()
      },
      async logout () {
        await this.$auth.logou()
        await this.refreshUser()
        this.$router.push('/')
      }
    }
  }
</script>

<style>
  body {
    margin: 0;
  }

  #app {
    font-family: 'Avenir', Arial, Helvetica, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
  }

  main {
    text-align: center;
    margin-top: 40px;
  }

  header {
    margin: 0;
    height: 56px;
    padding: 0 16px 0 24px;
    background-color: #f8f9fa;
    color: #fff;
  }

  header span {
    display: block;
    position: relative;
    font-size: 20px;
    line-height: 1;
    letter-spacing: .02em;
    font-weight: 400;
    box-sizing: border-box;
    padding-top: 16px;
  }
</style>