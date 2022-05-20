<template>
  <div id="home-body">
    <v-card
      max-width="1000"
      class="mx-auto"
    >
      <v-container>
        <v-row dense>
          <v-col cols="12">
            <v-card>
              <v-img
              :src="'https://www.uspeak.pl/wp-content/uploads/2020/11/fiszki-angielski.jpg'"
              class="white--text"
              gradient="to bottom, rgba(0,0,0,.4), rgba(0,0,0,.8)"
              height="500px"
              cover
            >
              <v-card-title>
                <span class="card_title">Nauka poprzez fiszki</span>
              </v-card-title>
              <div class="card_description">
                <span>Niemiecki uczony Sebastian Leitner po latach badań nad mechanizmami zapominania, opracował system nauki oparty na 'fiszkach'. 
                  Uważał on, że dzięki tej metodzie każdy człowiek może nauczyć się aż 10 języków obcych. 
                  Oczywiście fiszk idealnie mogą pasować do nauki wielu zagadnień z inncyh dziedzin. 
                  Załóż u nas konto, twórz swoje zestawy fiszek, ucz się i przekonaj się sam o skuteczności tej metody!</span>
              </div>
            </v-img>
            
              <v-card-actions>
                <a href="https://en.wikipedia.org/wiki/Leitner_system" style="text-decoration: none;">
                  <v-btn
                    class="ml-2"
                    variant="outlined"
                    size="small"
                    color="black"
                  >
                    Dowiedz się więcej
                  </v-btn>
                </a>
              </v-card-actions>
            </v-card>
          </v-col>
          <v-col cols="12">
            <v-card>
                <v-img
                :src="'https://www.csee-etuce.org/images/Pictures/ICT/STUDENTS-ON-COMPUTERS.jpg'"
                class="white--text"
                gradient="to bottom, rgba(0,0,0,.4), rgba(0,0,0,.8)"
                height="416px"
                cover
              >
                <v-card-title>
                  <span class="card_title">Nasi użytkownicy</span>
                </v-card-title>
                <div class="card_description">
                  <span>Obecnie z naszej strony korzysta <strong>{{ users_sum }}</strong> zadowolnych użytkowników 
                  a ich liczba rośnie z każdym kolejnym dniem! Dołącz do nich i zacznij pamiętać więcej i na dłużej. Pozwoł sobie uczynić swoją naukę jeszcze bardziej przyjemną i skutczeną!</span>
                </div>
              </v-img>
            </v-card>
          </v-col>
          <v-col cols="12">
            <v-card>
              <v-img
                :src="'https://www.centrumpomyslow.pl/system/cache/img/5d1b3f6cdbf78-711omq9svm80.jpg'"
                class="white--text"
                gradient="to bottom, rgba(0,0,0,.4), rgba(0,0,0,.8)"
                height="500px"
                cover
              >
                <v-card-title>
                  <span class="card_title">Twórz własne nielimitowane kolekcje i ucz się czego tylko chcesz!</span>
                </v-card-title>

                <div class="card_description">
                  <span>Nasi użytkownicy aktywnie tworzą nowe kolekcje, z których uczą się następnie w specjalnie przygotowanym trybie uczenia. 
                    Obecnie udało im się utworzyć już {{ collections_sum }} najróżniejszych unikatowych kolekcji.
                  </span>
                </div>
              </v-img>
            </v-card>
          </v-col>

          <v-col cols="12">
            <v-card>
              <v-img
                :src="'https://nauczona.pl/wp-content/uploads/2020/01/IMG-0309.jpg'"
                class="white--text"
                gradient="to bottom, rgba(0,0,0,.4), rgba(0,0,0,.8)"
                height="350px"
                cover
              >
          
                <v-card-title class="text-h5 space">
                  <span class="card_title">Aż tyle?</span>
                </v-card-title>

                <div class="card_description">
                  <span>Nasi użytkownicy nie próżnują i ciągle tworzą nowe fiszki i pogłębiają swoją wiedzę. 
                  Na ten moment udało im się utworzyć w swoich kolekcjach łącznie {{ flashcards_sum }} fiszek!
                  </span>
                </div>
              </v-img>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-card>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data() {
    return {
      users_sum: '',
      collections_sum: '',
      flashcards_sum: '',
    }
  },
    methods: {
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
          this.collections_sum = response.data.length;
        })
        .catch( function() { 
          this.collections_sum = 'BŁĄD'
        })

      axios.get("http://localhost:5085/api/" + "Flashcard")
        .then((response)=>{
          this.flashcards_sum = response.data.length;
        })
        .catch( function() { 
          this.flashcards_sum = 'BŁĄD'
        })

      return "hehe";
    }
  },
  mounted: function() {
      this.get_summary_data();
    }
}
</script>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Nunito&display=swap');

  #home-body {
    background-image: url('../assets/floor-tile.png');
    background-repeat: repeat;
    height: 100%;
    padding: 30px 0;
  }

  .card_title {
    font-family: 'Nunito', sans-serif;
    font-weight: 700;
    font-size: 64px;
    line-height: 1;
    color: white;
    padding: 30px;
  }

  .card_description {
    font-family: 'Nunito', sans-serif;
    font-weight: 600;
    font-size: 32px;
    color: white;
    line-height: 1;
    text-align: justify;
    padding: 30px 50px;
  }
</style>