<template>
    <Navbar />
    <div id="coll_title">
        <h1> {{ collName }} </h1>
    </div>
    <v-btn @click="this.$router.go(-1)" icon="mdi-arrow-left-circle" variant="outlined" color="green"></v-btn>
    <v-btn v-if="this.status === 0" @click="this.status = 1" variant="contained-text" color="green">Utwórz fiszkę</v-btn>

    <FlashcardAdd v-if="this.status === 1" v-model:status="status" v-model:coll_id="coll_id"/>
    <FlashcardEdit v-if="this.status === 2" v-model:status="status" v-model:coll_id="coll_id" v-model:fc_id="fc_id"/>
    <div id="flashcard_container">
      <v-responsive>
        <v-card v-for="fc in flashcards" :key="fc.Id_flashcard" class="flashcard">
          <div class="fc_content">
            <v-card-text>
              {{ fc.Question }}
            </v-card-text>
            <v-card-text>
              {{ fc.Answer }}
            </v-card-text>
          </div>
          <div class="fc_actions">
            <v-card-actions>
              <v-col align="center">
                <v-btn @click="deleteFlashcard(fc.Id_flashcard)" icon="mdi-trash-can" variant="outlined" class="action_delete">
                </v-btn>
                <v-btn @click="this.status = 2; this.fc_id = fc.Id_flashcard;" icon="mdi-pencil" variant="outlined" class="action_edit">
                </v-btn>
              </v-col>
            </v-card-actions>
          </div>
          <div style="clear: both;"></div>
        </v-card>
      </v-responsive>
    </div>
</template>

<script>
import FlashcardAdd from '../components/FlashcardAdd.vue'
import FlashcardEdit from '../components/FlashcardEdit.vue'
import Navbar from '../components/NavBar.vue'
import axios from 'axios'
export default {
    props: {
      collName: String,
      collId: Number,
  },
    
    data() {
      return {
        /*
        flashcards: [
          {id: 1, id_coll: 1, question: 'pies', answer: 'dog'},
          {id: 2, id_coll: 1, question: 'kot', answer: 'cat'},
          {id: 3, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 4, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 5, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 6, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 7, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 8, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 9, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 10, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 11, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 12, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 13, id_coll: 1, question: 'ropucha', answer: 'toad'},
          {id: 14, id_coll: 1, question: 'ropucha', answer: 'toad'}
        ], */

        flashcards: [],
        status: 0,
        coll_id: this.collId,
        fc_id: null,
        overlay: false,
      }
    },
    components: {
      FlashcardAdd,
      FlashcardEdit,
      Navbar,
    },
    methods: {
      refreshData() {
        // musi byc po id kolekcji wyswietlanie fiszek
        axios
          .get("http://localhost:5085/api/" + "Flashcard/get-by-collection/" + this.collId)
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
    },
    mounted: function() {
      this.refreshData();
    },
}
</script>

<style scoped>

#coll_title {
    margin: auto;
    text-align: center;
}

.flashcard {
  margin: 5px;
  background: gainsboro;
  max-height: 140px;
}

#flashcard_container {
  position: absolute;
    left: 50%;
    top: 50px;
    transform: translate(-50%, 0);
  margin: auto;
  width: 20%;
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





</style>