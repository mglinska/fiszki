<template>
  <div id="collections-body">
    <v-btn @click="overlay2 = !overlay2" icon="mdi-plus-box-multiple" id="label-add" variant="contained-text" color="white"></v-btn>
      <div id="user-name">
          <h1> {{ user_name }} </h1>
      </div>
      <div v-if="this.user_name == undefined" id="user-name">
          <h1> Moje kolekcje </h1>
      </div>
      <v-expansion-panels  id="collections">
        <v-col
          v-for="coll in collections"
          :key="coll.id"
          cols="4"
          sm="4"
        >
        <v-expansion-panel class="collection-item">
          <v-expansion-panel-title class="collection-title" color=rgb(32,124,92) hide-actions="True">
            <h3 class="title">{{ coll.Name }}</h3>
          </v-expansion-panel-title>
          <v-expansion-panel-text style="background-color: white;">
            <v-btn @click="moveTo(coll.Name, coll.Id_collection, 1)" class="label" variant="contained-text" color="white">Ucz się!</v-btn>
            <v-btn @click="moveTo(coll.Name, coll.Id_collection, 2)" class="label" variant="contained-text" color="white">Zarządzaj</v-btn>
            <v-btn @click="deleteCollection(coll.Id_collection)" class="label" variant="contained-text" color="white">Usuń</v-btn>
            <v-btn @click="overlay = !overlay; this.temp_id = coll.Id_collection; this.temp_name = coll.Name" class="label" variant="contained-text" color="white">Edytuj nazwę</v-btn>
            <v-btn @click="overlay3 = !overlay3; this.temp_id = coll.Id_collection; this.temp_name = coll.Name" class="label" variant="contained-text" color="white">Udostępnij</v-btn>
          </v-expansion-panel-text>
        </v-expansion-panel>
        </v-col>

      </v-expansion-panels>
        <v-overlay v-model="overlay" class="align-center justify-center">
          <CollectionRename @refresh="refresh" v-model:overlay="overlay" v-model:coll_id="temp_id" v-model:coll_name="temp_name" />
        </v-overlay>
        <v-overlay v-model="overlay2" class="align-center justify-center">
          <AddContent @refresh="refresh" v-model:overlay="overlay2" />
        </v-overlay>
        <v-overlay v-model="overlay3" class="align-center justify-center">
          <Share v-model:coll_name="temp_name" v-model:coll_id="temp_id"/>
        </v-overlay>
  </div>
</template>

<script>
import axios from 'axios'
import AddContent from '../components/CollAddContent.vue'
import CollectionRename from '../components/CollectionRename.vue'
import Share from '../components/ShareLink.vue'

export default {
  props: {
      user_name: String,
  },
  data() {
    return {
      title: 'Collections',
      status: 0,
      collections: [],
      overlay: false,
      overlay2: false,
      overlay3: false,
      temp_id: null,
      temp_name: null
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
      moveTo(collectionName, collectionId, where) {
        if (where == 1) {
          this.$router.push({ name: 'LearningMode', params: { collName: collectionName, collId: collectionId } })
        }

        if (where == 2) {
          this.$router.push({ name: 'ManageCollection', params: { collName: collectionName, collId: collectionId } })
        }
      },
      refresh() {
      this.refreshData()
    },
  },
  components: {
    AddContent,
    CollectionRename,
    Share
  },
  mounted: function() {
      if(sessionStorage.getItem('user_id') === null) {
        this.$router.push({ name: 'NoPermissionPage'});
      }
      this.refreshData();
    }
}
</script>

<style scoped>
    #page-title {
      margin-left: auto;
      margin-right: auto;
    }

    #collections-body {
      background-image: url('../assets/floor-tile.png');
      background-repeat: repeat;
      height: 100%;

      padding-top: 1.5%;
    }

    #label-add {
      z-index: 2;

      position:fixed;
      width:60px;
      height:60px;
      bottom:2%;
      right:2%;

      background-color:#3A3731;
      display: block;
    }

    .label{
      width: 50%;

      margin-left: auto;
      margin-right: auto;
      
      background-color:rgb(32,124,92);
      display: block;

      margin-top: 2.5%;
    }

    .title {
      width: 100%;
    }

    .collection-title {
      color: white;
      font-size: 32px;
      min-height: 100px;
    }

    .collection-item {
      margin-left: 10%;
      margin-right: 10%;
    }

    #collections{
      padding: 20px;
      margin-top: 40px;
    }

    .coll:hover{
      cursor: pointer;
    }

    #user-name {
  position: absolute;
  transform: translate(-50%, 0);
  left: 50%;
  top: 30px;
}

</style>