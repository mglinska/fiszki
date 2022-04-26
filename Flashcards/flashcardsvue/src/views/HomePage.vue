<template>
  <h1 style="margin: 30px;">Home</h1>
  <h1 style="margin: 30px;">Hello {{ user.First_name }}</h1>
</template>

<script>
import axios from 'axios'
export default {
  data() {
    return {
      user: {First_name: 'none'},
    }
  },
    methods: {
    get_user() {
      console.log(sessionStorage);
      axios.get("http://localhost:5085/api/" + "User/" + sessionStorage.getItem('user_id'))
        .then((response)=>{
          this.user = response.data;
        })
        .catch( function(error) { 
          console.log(error.message)
        })
    },
  },
  mounted: function() {
      this.get_user();
    }
}
</script>

<style>

</style>