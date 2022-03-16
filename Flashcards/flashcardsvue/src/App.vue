<template>
  <v-card>
    <v-layout>
      <v-navigation-drawer
        floating
        permanent
      >
        <v-list
          density="compact"
          nav
        >
          <v-list-item prepend-icon="mdi-home" href="#/" title="Home" value="home"></v-list-item>
          <v-list-item prepend-icon="mdi-information-outline" href="#/about" title="About" value="about"></v-list-item>
          <v-list-item prepend-icon="mdi-login" href="#/login" title="Log in" value="about"></v-list-item>
          <v-list-item prepend-icon="mdi-account-plus" href="#/registration" title="Sign up" value="about"></v-list-item>
        </v-list>
      </v-navigation-drawer>
      <v-main>
        <About v-if="this.currentPath.slice(2) === 'about'" />
        <Login v-else-if="this.currentPath.slice(2) === 'login'" />
        <Registration v-else-if="this.currentPath.slice(2) === 'registration'" />
        <Home v-else />
      </v-main>
    </v-layout>
  </v-card>
  <!--
  <v-app>
    <v-main>
      <a href="#/">Home</a> |
      <a href="#/about">About</a> |
      <a href="#/login">Login</a> |
      <a href="#/registration">Register</a>
      <component :is="currentView" />
    </v-main>
  </v-app>
  -->
</template>

<script>
import Home from './HomePage.vue'
import About from './AboutPage.vue'
import NotFound from './NotFoundPage.vue'
import Registration from './RegistrationPage.vue'
import Login from './LoginPage.vue'

const routes = {
  '/': Home,
  '/about': About,
  '/login': Login,
  '/registration': Registration
}

export default {
  data() {
    return {
      currentPath: window.location.hash,
      type: 0,
      title: 'Fiszki',
      openDrawer: false
    }
  },
  components: {
    Home,
    About,
    Login,
    Registration,
  },
  computed: {
    currentView() {
      console.log(this.currentPath.slice(1) || '/')
      return routes[this.currentPath.slice(1) || '/'] || NotFound
    },
  },
  mounted() {
    window.addEventListener('hashchange', () => { this.currentPath = window.location.hash
		})
  }
}
</script>

<style>
body{
  padding: 0;
  margin: 0;
}
</style>
