<template>
    <div id="learn_body">
      <Options v-if="start == false" @setup="setup($event)" />
      <div v-else>
        <div style="margin: auto; text-align: center;">
            <h1 style="padding: 50px 0;"> {{ coll_name }} </h1>
        </div>
        <div id="carousel_conatainer">
          <v-carousel 
            hide-delimiters
            v-model="currentIndex"
          >
            <v-carousel-item
              v-for="(fc, i) in flashcards"
              :key="i"
            >
              <div class="d-flex fill-height justify-center align-center">
                <div :id="'flashcard'+i" class="flip-card">
                  <div class="flip-card-inner">
                    <div class="flip-card-front">
                      <div v-if="!end">
                        <span class="counter text-h4"> {{i+1}}/{{this.flashcards.length}}</span>
                        <span v-if="site == false" class="text-h2"> {{ fc.Question }} </span>
                        <span v-else class="text-h2"> {{ fc.Answer }} </span>
                        <br>
                        <v-btn @click="check(fc, i)" class="check" variant="contained-text" color="white">Sprawdź</v-btn>
                      </div>
                      <div v-if="end">
                        <h3>Udało Ci się ukończyć naukę!</h3>
                        <v-btn @click="this.refreshData(); this.end = false;" class="end_button" variant="contained-text" color="white">Ucz się od początku</v-btn>
                      </div>
                    </div>
                    
                    <div class="flip-card-back">
                      <span class="counter text-h4"> {{i+1}}/{{this.flashcards.length}}</span>
                      <span v-if="site == false" class="text-h2"> {{ fc.Answer }} </span>
                      <span else class="text-h2"> {{ fc.Question }} </span>
                      <br>
                      <v-btn @click="check(fc)" class="check" variant="contained-text" color="white">Wróć</v-btn>
                      <v-btn @click="remove(i)" class="memorized" variant="contained-text" color="white">Pamiętam</v-btn>
                    </div>
                  </div>
                </div>
              </div>
            </v-carousel-item>

            <v-carousel-item v-if="flashcards.length == 0">
              <div class="d-flex fill-height justify-center align-center">
                <div class="flip-card">
                  <div class="flip-card-inner">
                    <div class="flip-card-front">
                      <div v-if="!end">
                        <h3>Ups! Najwyraźniej nie dodano żadnych fiszek do tej kolekcji!</h3>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </v-carousel-item>

          </v-carousel>
        </div>
      </div>
    </div>
</template>

<script>
import axios from 'axios'
import Options from './LearningModeOptions.vue'

export default {
    props: {
      coll_Name: String,
      coll_Id: Number,
  },
    
    data() {
      return {
        flashcards: [], 
        coll_id: this.coll_Id,
        coll_name: '',
        fc_id: null,
        currentIndex: 0,
        end: false,
        start: false,
        site: false,
      }
    },
    watch: {
      currentIndex: function() {
        setTimeout(this.reset, 150);
      }
    },
    methods: {
      decrypt(value) {
      const CryptoJS = require('crypto-js');
      return CryptoJS.enc.Base64.parse(value).toString(CryptoJS.enc.Utf8);
      },
      refreshData() {
        let localCollName = this.decrypt(this.coll_Name);
        this.coll_name = localCollName;
        let localCollId = this.decrypt(this.coll_Id);
        axios
          .get("http://localhost:5085/api/" + "Flashcard/get-by-collection/" + localCollId)
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
      
      check(flashcard, index) {
        flashcard.Inverted = !flashcard.Inverted;
        let id = '#flashcard' + index
        if(flashcard.Inverted)
          document.querySelector(id).classList.add('flip-card-clicked');
        else
          document.querySelector('.flip-card-clicked').classList.remove('flip-card-clicked');
      },
   
      remove(index) {
        if(index == this.flashcards.length - 1) {
          if(this.flashcards.length == 1)
          {
            document.querySelector(".flip-card-clicked").classList.remove('flip-card-clicked');
            this.end = true;
            return;
          }
            this.currentIndex = 0;
            setTimeout(() => {
              this.flashcards.splice(index, 1);
            }, 200);
        }
        else {
          document.querySelector(".flip-card-clicked").classList.remove('flip-card-clicked');
          setTimeout(() => {
            this.flashcards.splice(index, 1);
          }, 200);
        }
      },

      reset() {
        this.flashcards.forEach(function (element) {
            element.Inverted = false;
        });

        setTimeout(() => {
          let fc = document.querySelector(".flip-card-clicked");
          if (fc != null)
            fc.classList.remove('flip-card-clicked');
        }, 200)
      },
      randomArrayShuffle(array) {
        var currentIndex = array.length, temporaryValue, randomIndex;
        while (0 !== currentIndex) {
          randomIndex = Math.floor(Math.random() * currentIndex);
          currentIndex -= 1;
          temporaryValue = array[currentIndex];
          array[currentIndex] = array[randomIndex];
          array[randomIndex] = temporaryValue;
        }
        return array
      },
      setup ({ random, site }) {
        if (random == 'TAK') {
          this.flashcards = this.randomArrayShuffle(this.flashcards);
        }

        if (site == 'TAK') {
          this.site = !this.site;
        }

        this.start = !this.start;
      }
    },
    components: {
      Options,
    },
    mounted: function() {
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
    background-color: rgb(32,124,92);
    width: 80%;
    min-height: 500px;
    border-radius: 20px;
  }

  .memorized {
    position: absolute;
        left: 80%;
        top: 83%;
        background-color: rgb(32,124,92)
  }

  .check {
    background-color: rgb(32,124,92);
    margin-top: 17.5%;
    width: 100px;
    
  }

  .end_button {
    background-color: rgb(32,124,92);
    margin-top: 10px;
    margin-left: 5px;
    margin-right: 5px;
    width: 220px;
  }

  .counter {
    position: absolute;
    right: 15px;
    top: 10px;
  }

  /* The flip card container - set the width and height to whatever you want. We have added the border property to demonstrate that the flip itself goes out of the box on hover (remove perspective if you don't want the 3D effect */
.flip-card {
  height: 80%;
  max-height: 80%;
  width: 50%;
  background-color: transparent;
  text-align: center;
  perspective: 1000px; /* Remove this if you don't want the 3D effect */
}

/* This container is needed to position the front and back side */
.flip-card-inner {
  position: relative;
  width: 100%;
  height: 100%;
  text-align: center;
  transition: transform 0.8s;
  transform-style: preserve-3d;
}

/* Do an horizontal flip when you move the mouse over the flip box container */
.flip-card-clicked .flip-card-inner {
  transform: rotateY(180deg);
}

/* Position the front and back side */
.flip-card-front, .flip-card-back {
  position: absolute;
  width: 100%;
  height: 100%;
  padding: 140px 0;
  -webkit-backface-visibility: hidden; /* Safari */
  backface-visibility: hidden;
  border-radius: 20px;
}

/* Style the front side (fallback if image is missing) */
.flip-card-front {
  background-color: white;
  border-radius: 20px;
}

/* Style the back side */
.flip-card-back {
  background-color: white;
  transform: rotateY(180deg);
}

</style>