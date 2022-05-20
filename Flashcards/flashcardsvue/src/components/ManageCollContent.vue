<template>
    <div id="manage-body">
      <div id="coll-name">
          <h1> {{ coll_Name }} </h1>
      </div>
      <v-btn @click="this.$router.go(-1)" icon="mdi-arrow-left-circle" variant="contained-text" color="white" id="return-button"></v-btn> 
      <br>
      <br>
      <v-btn @click="overlay1 = !overlay1" icon="mdi-plus-box-multiple" id="label-add" variant="contained-text" color="white"></v-btn>

      <div id="flashcard_container">
        <v-responsive>
          <v-card
            id="flashcard-interior"
            class="mx-auto"
            max-width="344"
            v-for="fc in flashcards" 
            :key="fc.Id_flashcard"
          >
            <v-card-title>
              {{ fc.Question }}
            </v-card-title>

            <v-card-subtitle>
              {{ fc.Answer }}
            </v-card-subtitle>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn @click="deleteFlashcard(fc.Id_flashcard)" size="small" color="white" icon="mdi-trash-can" variant="text">
              </v-btn>
              <v-btn @click="overlay2 = !overlay2; this.fc_id = fc.Id_flashcard; this.temp_awers = fc.Question; this.temp_rewers = fc.Answer" size="small" color="white" icon="mdi-pencil" variant="text">
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-responsive>
      </div>

      <v-overlay v-model="overlay1" class="align-center justify-center">
        <FlashcardAdd @refresh="refresh" v-model:overlay="overlay1" v-model:coll_id="coll_id"/>
      </v-overlay>
      <v-overlay v-model="overlay2" class="align-center justify-center">
        <FlashcardEdit @refresh="refresh" v-model:overlay="overlay2" v-model:coll_id="coll_id" v-model:fc_id="fc_id" v-model:awers_="temp_awers" v-model:rewers_="temp_rewers"/>
      </v-overlay>
    </div>
</template>

<script>
import FlashcardAdd from '../components/FlashcardAdd.vue'
import FlashcardEdit from '../components/FlashcardEdit.vue'
import axios from 'axios'
export default {
    props: {
      coll_Name: String,
      coll_Id: Number,
  },
    
    data() {
      return {
        flashcards: [],
        coll_id: this.coll_Id,
        fc_id: null,
        overlay1: false,
        overlay2: false,
        temp_awers: null,
        temp_rewers: null,
      }
    },
    components: {
      FlashcardAdd,
      FlashcardEdit,
    },
    methods: {
      refreshData() {
        axios
          .get("http://localhost:5085/api/" + "Flashcard/get-by-collection/" + this.coll_Id)
          .then( (response)=>{
            console.log(response.data)
            this.flashcards = response.data;
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      },
      deleteFlashcard(id) {
        if( !(confirm("Are you sure you want to delete this flashcard?")) ) {
          return;
        }

        axios.delete("http://localhost:5085/api/" + "Flashcard/" + id)
          .then( ()=> {
            this.refreshData();
          })
          .catch(function(error) { 
            console.log(error.message)
          })
      },
      refresh() {
      this.refreshData()
      }
    },
    mounted: function() {
      if(sessionStorage.getItem('user_id') === null) {
        this.$router.push({ name: 'NoPermissionPage'});
      }
      this.refreshData();
    },
}
</script>

<style scoped>

#coll-name {
  position: absolute;
  transform: translate(-50%, 0);
  left: 50%;
  top: 50px;
}

#return-button {
  position: absolute;
  left: 10%;
  top: 50px;

  width: 70px;
  border-radius: 20px;

  background-color: #3A3731;
}

#label-add {
  z-index: 2;
  position:fixed;
  width:60px;
  height:60px;
  bottom:2%;
  right:2%;
  background-color: #3A3731;
  display: block;
}

#manage-body {
  background-image: url('../assets/floor-tile.png');
  background-repeat: repeat;
  height: 100%;
  padding-top: 1.5%;
}

#coll_title {
    margin: auto;
    text-align: center;
}

.flashcard {
  margin: 5px;
  background: rgb(32,124,92);
  color: white;
  max-height: 140px;
}

.flashcard-text {
    color: white;
}

#flashcard_container {
  margin: auto;
  margin-top: 50px;
  width: 20%;
}

#flashcard_container > * {
    margin: 5px 0;
}

#flashcard-interior {
  margin-top: 10px;
  color: white;
  background-color: rgb(32,124,92);
}

.fc_content {
  float:left;
  width: 70%;
  height: 100%;
  padding: 20px 0;
}

.fc_actions {
  float:left;
  width: 30%;
  height: 100%;
  text-align: center;
}

.action_delete, .action_edit {
  margin: 2px 0px;
  float: right;
  display: default;
}

.label{
        background-color: green;
        display: block;
        margin: 10px;
    }
</style>