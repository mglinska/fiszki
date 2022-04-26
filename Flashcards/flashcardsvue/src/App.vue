<template>
  <v-app>
    <v-app-bar id="app-bar">
      <router-link class="link" :to="{ name: 'Home'}">Strona główna</router-link>
      <router-link class="link" :to="{ name: 'Login'}">Zaloguj</router-link>
      <router-link class="link" :to="{ name: 'Registration'}">Zarejestruj</router-link>
      <router-link class="link" :to="{ name: 'About'}">O nas</router-link>
      <v-btn @click="logout_user" v-if="user_id != null"> Wyloguj </v-btn>
    </v-app-bar>
      <v-main>
        <router-view />
      </v-main>
  </v-app>
</template>

<script>
//import axios from 'axios'
export default {
  data() {
    return {
      title: 'Fiszki',
      user_id: null
    }
  },
  methods: {
    get_user() {
      console.log(sessionStorage);
      this.user_id = sessionStorage.getItem('user_id');
    },
    logout_user() {
      sessionStorage.removeItem('user_id');
      window.location.reload(true);
      this.$router.push({ name: 'Home'});
    }
  },
  mounted: function() {
      this.get_user();
    },
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
