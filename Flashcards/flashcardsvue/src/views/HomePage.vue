<template>
  <Navbar />
  <h1 style="margin: 35px;">Hello {{ user.First_name }}</h1>
  <h3 style="margin: 35px;">Liczba użytkoników: {{ users_sum }}</h3>
  <h3 style="margin: 35px;">Liczba utworzonych kolekcji przez naszych użytkoników: {{ collections_sum }}</h3>
  <h3 style="margin: 35px;">Liczba utworzonych fiszek przez naszych użytkoników: {{ flashcards_sum }}</h3>
</template>

<script>
import axios from 'axios'
import Navbar from '../components/NavBar.vue'
export default {
  data() {
    return {
      user: {First_name: ''},
      users_sum: '',
      collections_sum: '',
      flashcards_sum: '',
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
    get_summary_data() {
      axios.get("http://localhost:5085/api/" + "User")
        .then((response)=>{
          this.users_sum = response.data.length;
        })
        .catch( function() { 
          this.users_sum = 'BŁĄD'
        })
      
      axios.get("http://localhost:5085/api/" + "Collection")
        .then((response)=>{
          this.flashcards_sum = response.data.length;
        })
        .catch( function() { 
          this.flashcards_sum = 'BŁĄD'
        })

      axios.get("http://localhost:5085/api/" + "Flashcard")
        .then((response)=>{
          this.collections_sum = response.data.length;
        })
        .catch( function() { 
          this.collections_sum = 'BŁĄD'
        })
    }
  },
  components: {
    Navbar
  },
  mounted: function() {
      this.get_user();
      this.get_summary_data();
    }
}
</script>

<style>

</style>