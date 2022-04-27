<template>
  <Navbar />
  <h1 style="margin: 30px;">Hello {{ user.First_name }}</h1>
</template>

<script>
import axios from 'axios'
import Navbar from '../components/NavBar.vue'
export default {
  data() {
    return {
      user: {First_name: ''},
    }
  },
    methods: {
    get_user() {
      axios.get("http://localhost:5085/api/" + "User/" + sessionStorage.getItem('user_id'))
        .then((response)=>{
          this.user = response.data;
        })
        .catch( function(error) { 
          console.log(error.message)
        })
    },
  },
  components: {
    Navbar
  },
  mounted: function() {
      this.get_user();
    }
}
</script>

<style>

</style>