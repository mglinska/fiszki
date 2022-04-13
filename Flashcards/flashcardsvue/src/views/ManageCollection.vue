<template>
    <div id="temp">
        <h1> {{ collName }} </h1>
    </div>
    <v-btn v-if="this.status === 0" @click="this.status = 1" variant="contained-text" color="green">Utwórz fiszkę</v-btn>
    <FlashcardAdd v-if="this.status === 1" v-model:status="status"/>
    <div id="flashcard_container">
      <v-responsive>
        <v-card v-for="fc in flashcards" :key="fc.id" class="flashcard">
          <div class="fc_content">
            <v-card-text>
              {{ fc.question }}
            </v-card-text>
            <v-card-text>
              {{ fc.answer }}
            </v-card-text>
          </div>
          <div class="fc_actions">
            <v-card-actions>
              <v-col align="center">
                <v-btn icon="mdi-trash-can" variant="outlined" class="action_delete">
                </v-btn>
                <v-btn icon="mdi-pencil" variant="outlined" class="action_edit">
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
export default {
    props: ['collName'],
    data() {
      return {
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
        ],
        status: 0,
      }
    },
    components: {
      FlashcardAdd,
    }
}
</script>

<style scoped>

#temp {
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