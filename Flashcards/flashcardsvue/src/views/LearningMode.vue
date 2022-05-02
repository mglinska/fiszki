<template>
    <Navbar />
    <div id="learn_body">
      <v-btn @click="this.$router.go(-1)" icon="mdi-arrow-left-circle" variant="outlined" color="green" style="margin-left: 35px; margin-top: 10px;"></v-btn>

      <div id="carousel_conatainer">
        <v-carousel 
          hide-delimiters
          v-model="currentIndex"
        >
          <v-carousel-item
            v-for="fc in flashcards"
            :key="fc.Id_flashcard"
          >
            <div class="d-flex fill-height justify-center align-center">
              <div class="text-h2 flashcard">
                <span v-if="fc.Inverted == false"> {{ fc.Question }} </span>
                <span v-else> {{ fc.Answer }} </span>
                <br>
                <v-btn v-if="fc.Inverted == false" @click="check(fc)" class="check" variant="contained-text" color="white">Sprawdź</v-btn>
                <v-btn v-else @click="check(fc)" class="check" variant="contained-text" color="white">Wróć</v-btn>
                <v-btn v-if="fc.Inverted == true" @click="console.log('XD')" class="memorized" variant="contained-text" color="white">Pamiętam</v-btn>
              </div>
            </div>

          </v-carousel-item>
        </v-carousel>
      </div>
    </div>
</template>

<script>
import Navbar from '../components/NavBar.vue'
import axios from 'axios'

export default {
    props: {
      collName: String,
      collId: Number,
  },
    
    data() {
      return {
        flashcards: [], 
        coll_id: this.collId,
        fc_id: null,
        currentIndex: 0,
      }
    },
    components: {
      Navbar,
    },
    watch: {
      currentIndex: function() {
        console.log('xD')
      }
    },
    methods: {
      refreshData() {
        axios
          .get("http://localhost:5085/api/" + "Flashcard/get-by-collection/" + this.collId)
          .then( (response)=>{
            this.flashcards = response.data;
            this.flashcards.forEach(function (element) {
            element.Memorized = false;
            element.Inverted = false;
        });
          })
          .catch( function(error) { 
            console.log(error.message)
          })
      },
      
      check(flashcard) {
        flashcard.Inverted = !flashcard.Inverted;
      },

      checkIfEverythingIsMemorized()
      {
        if (this.flashcards.length == 0) {
          console.log('przejebane')
        }
      },
    },
    mounted: function() {
      this.refreshData();
    },
}
</script>

<style scoped>
  #learn_body {
    background-image: url('../assets/floor-tile.png');
    background-repeat: repeat;
    height: 100%;
  }
  #carousel_conatainer {
    position: absolute;
    left: 50%;
    top: 150px;
    transform: translate(-50%, 0);
  margin: auto;
  background-color: orange;
  width: 80%;
  min-height: 500px;
  }

  .flashcard {
    position: absolute;
    height: 80%;
    max-height: 80%;
    width: 50%;
    background-color: bisque;
    text-align: center;
    padding: 160px 0;
  }

  .memorized {
    position: absolute;
        left: 80%;
        top: 83%;
        background-color: orange
  }

  .check {
    background-color: green;
    margin-top: 10px;
  }
  

</style>