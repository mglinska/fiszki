<template>
  <v-container class="grey lighten-5">
    <v-row
      v-for="user in users"
      :key="user"
      :class="'mb-6'"
      no-gutters
    >
      <v-col>
        <v-card 
          class="pa-2"
          outlined
          tile
        >
          {{user.Email}}
        </v-card>
        <v-card 
          class="pa-2"
          outlined
          tile
        >
          {{user.Name}}
        </v-card>
        <v-card 
          class="pa-2"
          outlined
          tile
        >
          {{user.Surname}}
        </v-card>
        <v-btn plain color="error" @click="deleteUser(user.Id)">Delete</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  import axios from 'axios'

  export default {
    data: () => ({
      users: [
      ],
    }),
    methods: {
      refreshData() {
        axios
          .get("http://localhost:5085/api/" + "User")
          .then( (response)=>{
            this.users = response.data;
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      },
      deleteUser(id) {
        if( !(confirm("Are you sure you want to delete this user?")) ) {
          return;
        }

        axios.delete("http://localhost:5085/api/" + "User/" + id )
          .then( (response)=> {
            this.refreshData();
            alert(response.data)
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      }
    },
    mounted: function() {
      this.refreshData();
    }
  }
</script>