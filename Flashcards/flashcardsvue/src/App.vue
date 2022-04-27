<template>
  <v-app>
      <v-main>
        <router-view />
      </v-main>
  </v-app>
</template>

<script>
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
      this.user_id = null
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
</style>
