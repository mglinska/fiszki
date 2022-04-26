<template>
  <DefultContent v-if="this.status === 0" v-model:status="status"/>
  <AddContent v-else-if="this.status === 1" v-model:status="status"/>
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
        </v-expansion-panel-text>
      </v-expansion-panel>
      
    </v-expansion-panels>

</template>

<script>
import axios from 'axios'
import DefultContent from '../components/CollDefultContent.vue'
import AddContent from '../components/CollAddContent.vue'

export default {
  data() {
    return {
      title: 'Collections',
      status: 0,
      collections: [],
    }
  },
  methods: {
      refreshData() {
        axios
          .get("http://localhost:5085/api/" + "CollectionUser/" + sessionStorage.getItem('user_id'))
          .then( (response)=>{
            this.collections = response.data;
            console.log(response.data)
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      },
      deleteCollection(id) {
        if( !(confirm("Are you sure you want to delete this user?")) ) {
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
      }
  },
  components: {
    DefultContent,
    AddContent,
  },
  mounted: function() {
      this.refreshData();
    }
}
</script>

<style>
    .label{
        background-color: green;
        display: block;
        margin: 10px;
    }

    #collections{
      width: 20%;
      margin-left: 10px;
    }

    .coll:hover{
      cursor: pointer;
    }


</style>