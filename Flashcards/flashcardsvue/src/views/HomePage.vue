<template>
  <h1 style="margin: 30px;">Home</h1>
  <h1 style="margin: 30px;">{{ user.First_name }}</h1>
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
          axios.get("http://localhost:5085/api/" + "User/check-logged-user")
            .then( (response)=>{
              this.user = response.data;
            })
            .catch( function(error) { 
              console.log(error.message)
            })
        },
  } 
}
</script>

<style>

</style>