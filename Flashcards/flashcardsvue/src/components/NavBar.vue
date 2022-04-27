<template>
    <v-app-bar id="app-bar">
      <router-link class="link" :to="{ name: 'Home'}">Strona główna</router-link>
      <router-link v-if="user_id == null" class="link" :to="{ name: 'Login'}">Zaloguj</router-link>
      <router-link v-if="user_id == null" class="link" :to="{ name: 'Registration'}">Zarejestruj</router-link>
      <router-link class="link" :to="{ name: 'About'}">O nas</router-link>
      <router-link v-if="user_id != null" class="link" :to="{ name: 'Collections'}">Moje kolekcje</router-link>
      <v-btn @click="logout_user" v-if="user_id != null"> Wyloguj </v-btn>
    </v-app-bar>
</template>

<script>
export default {
  data() {
    return {
      user_id: null
    }
  },
  methods: {
    get_user() {
      this.user_id = sessionStorage.getItem('user_id');
    },
    logout_user() {
        if( !(confirm("Czy życzysz sobie zostać wylogowanym :D?")) ) {
          return;
        }
      sessionStorage.removeItem('user_id');
      this.user_id = null
      this.$router.push({ name: 'Home'});
    }
  },
  mounted: function() {
      this.get_user();
    },
}
</script>

<style scoped>
#app-bar{
  box-shadow: 0px 0px 0px 0px rgba(66, 68, 90, 1);
}

.link{
  display: inline-block;
  padding: 20px;
}
</style>