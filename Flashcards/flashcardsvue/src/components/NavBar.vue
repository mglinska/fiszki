<template>
  <v-card class="overflow-hidden">
    <v-app-bar
      color="primary"
      shrink-on-scroll
      fade-img-on-scroll
      scroll-target="#scrolling-techniques-4"
    >
      <template v-slot:image>
        <v-img
          gradient="to top right, rgb(32,124,92), rgb(10, 82, 57)"
        ></v-img>
      </template>

      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>Flashcards</v-toolbar-title>

      <v-spacer></v-spacer>

        <v-tabs align-with-title>
          <v-tab class="link" :to="{ name: 'Home'}">Strona główna</v-tab>
          <v-tab v-if="user_id == null" class="link" :to="{ name: 'Login'}">Zaloguj</v-tab>
          <v-tab v-if="user_id == null" class="link" :to="{ name: 'Registration'}">Zarejestruj</v-tab>
          <!-- <v-tab class="link" :to="{ name: 'About'}">O nas</-v-tab> -->
          <v-tab v-if="user_id != null" class="link" :to="{ name: 'Collections'}">Moje kolekcje</v-tab>
          <v-tab v-if="user_id != null" class="link" @click="logout_user" :to="{}">Wyloguj</v-tab>
        </v-tabs>
    </v-app-bar>
    <v-sheet
      id="scrolling-techniques-4"
      class="overflow-y-auto"
      max-height="600"
    >
    </v-sheet>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      user_id: null
  }},
  methods: {
    get_user() {
      this.user_id = sessionStorage.getItem('user_id');
    },
    logout_user() {
        // if( !(confirm("Czy życzysz sobie zostać wylogowanym :D?")) ) {
        //   return;
        // }
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