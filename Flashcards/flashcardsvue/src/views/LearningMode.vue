<template>
    <Navbar />
    <v-btn @click="this.$router.go(-1)" icon="mdi-arrow-left-circle" variant="outlined" color="green" style="margin-left: 35px;"></v-btn>
   
</template>

<script>
import Navbar from '../components/NavBar.vue'
//import axios from 'axios'

export default {
    props: {
      collName: String,
      collId: Number,
  },
    
    data() {
      return {
        
        flashcards: [
          {Id_flashcard: 1, Id_collection: 1, Question: 'pies', Answer: 'dog'},
          {Id_flashcard: 2, Id_collection: 1, Question: 'kot', Answer: 'cat'},
          {Id_flashcard: 3, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 4, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 5, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 6, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 7, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 8, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 9, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 10, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 11, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 12, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 13, Id_collection: 1, Question: 'ropucha', Answer: 'toad'},
          {Id_flashcard: 14, Id_collection: 1, Question: 'ropucha', Answer: 'toad'}
        ], 

        coll_id: this.collId,
        fc_id: null,
      }
    },
    components: {
      Navbar,
    },

    methods: {
      refreshData() {
        // axios
        //   .get("http://localhost:5085/api/" + "Flashcard/get-by-collection/" + this.collId)
        //   .then( (response)=>{
        //     console.log(response.data)
        //     this.flashcards = response.data;
        //   })
        //   .catch( function(error) { 
        //     console.log(error.message)
        //   })

        this.flashcards.forEach(function (element) {
            element.Memorized = false;
        });
        console.log(this.flashcards);
      },
      refresh() {
      this.refreshData()
      }
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

.label{
        background-color: green;
        display: block;
        margin: 10px;
    }
</style>