<template>
  <v-app>
    <v-app-bar id="app-bar">
      <div class="link">
        <a href="#/">Strona główna</a>
      </div>
      <div class="link">
        <a href="#/login">Zaloguj</a>
      </div>
      <div class="link">
        <a href="#/registration">Zarejestruj</a>
      </div>
      <div class="link">
        <a href="#/about">O nas</a>
      </div>
    
    </v-app-bar>
     <v-main>
        <About v-if="this.currentPath.slice(2) === 'about'" />
        <Login v-else-if="this.currentPath.slice(2) === 'login'" />
        <Registration v-else-if="this.currentPath.slice(2) === 'registration'" />
        <collections v-else-if="this.currentPath.slice(2) === 'collections'" />
        <Home v-else />
      </v-main>
  </v-app>
</template>

<script>
import Home from './HomePage.vue'
import About from './AboutPage.vue'
import NotFound from './NotFoundPage.vue'
import Registration from './RegistrationPage.vue'
import Login from './LoginPage.vue'
import Collections from './CollectionsPage.vue'

const routes = {
  '/': Home,
  '/about': About,
  '/login': Login,
  '/registration': Registration,
  '/collections': Collections
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
    Collections,
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

#app-bar{
  box-shadow: 0px 0px 0px 0px rgba(66, 68, 90, 1);
  border: solid 2px;
}

.link{
  display: inline-block;
  padding: 20px;
}

</style>
