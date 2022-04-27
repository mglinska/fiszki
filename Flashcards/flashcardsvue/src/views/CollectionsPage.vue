<template>
  <Navbar />
  <h1 style="margin: 35px;">Kolekcje</h1>
  <v-btn @click="overlay2 = !overlay2" class="label" variant="contained-text" color="white">Dodaj kolekcje</v-btn>

  <div style="height: 10px;"></div>
    <v-expansion-panels  id="collections">

      <v-expansion-panel v-for="coll in collections" :key="coll.id">
        <v-expansion-panel-title color="green" hide-actions="True">
           <h3>{{ coll.Name }}</h3>
        </v-expansion-panel-title>
        <v-expansion-panel-text>
          <v-btn class="label" variant="contained-text" color="white">Ucz się!</v-btn>
          <v-btn @click="moveTo(coll.Name, coll.Id_collection)" class="label" variant="contained-text" color="white">Zarządzaj</v-btn>
          <v-btn @click="deleteCollection(coll.Id_collection)" class="label" variant="contained-text" color="white">Usuń</v-btn>
          <v-btn @click="overlay = !overlay; this.temp_id = coll.Id_collection" icon="mdi-pencil" class="label" variant="contained-text" color="white"></v-btn>
        </v-expansion-panel-text>
      </v-expansion-panel>
      
    </v-expansion-panels>
      <v-overlay v-model="overlay" class="align-center justify-center">
        <CollectionRename @refresh="refresh" v-model:overlay="overlay" v-model:coll_id="temp_id"/>
      </v-overlay>
      <v-overlay v-model="overlay2" class="align-center justify-center">
        <AddContent @refresh="refresh" v-model:overlay="overlay2" />
      </v-overlay>
</template>

<script>
import axios from 'axios'
import AddContent from '../components/CollAddContent.vue'
import Navbar from '../components/NavBar.vue'
import CollectionRename from '../components/CollectionRename.vue'

export default {
  data() {
    return {
      title: 'Collections',
      status: 0,
      collections: [],
      overlay: false,
      overlay2: false,
      temp_id: null
    }
  },
  methods: {
      refreshData() {
        let zmienna = sessionStorage.getItem('user_id') == null ? -1 : sessionStorage.getItem('user_id')
        axios.get("http://localhost:5085/api/" + "CollectionUser/" + zmienna)
          .then( (response)=>{
            this.collections = response.data;
            console.log(response.data)
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      },
      deleteCollection(id) {
        if( !(confirm("Are you sure you want to delete this collection?")) ) {
          return;
        }

        axios.delete("http://localhost:5085/api/" + "Collection/" + id)
          .then( ()=> {
            this.refreshData();
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      },
      moveTo(collectionName, collectionId) {
        this.$router.push({ name: 'ManageCollection', params: { collName: collectionName, collId: collectionId } })
      },
      refresh() {
      this.refreshData()
    },
  },
  components: {
    AddContent,
    Navbar,
    CollectionRename,
  },
  mounted: function() {
      this.refreshData();
    }
}
</script>

<style scoped>
    .label{
        background-color: green;
        display: block;
        margin: 10px;
        margin-left: 35px;
    }

    #collections{
      width: 20%;
      margin-left: 35px;
    }

    .coll:hover{
      cursor: pointer;
    }

</style>