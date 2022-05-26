<template>
    <div id="container">
      <h1 id="title-text">Opcje trybu uczenia</h1>

      <v-form 
        id=log_form
        ref="form"
      >
      <v-container fluid>
        <v-switch
            v-model="random"
            :label="`Losowa kolejność fiszek: ${random.toString()}`"
            true-value="TAK"
            false-value="NIE"
        ></v-switch>
        <v-switch
            v-model="site"
            :label="`Zamień strony fiszki: ${site.toString()}`"
            true-value="TAK"
            false-value="NIE"
        ></v-switch>
      </v-container>
    

      <v-btn
        id="button"
        @click="send"
      >
        ZACZNIJ NAUKĘ
      </v-btn>

      </v-form>
    </div>
</template>

<script>
  export default {
    data () {
      return {
        random: 'NIE',
        site: 'NIE',
      }
    },
    methods: {
        send() {
            this.$emit('setup', { random: this.random, site: this.site })
        }
    },
  }
</script>

<style scoped>
  #title-text {
    color: white;
    margin-left: auto;
    margin-right: auto;
    margin-bottom: 30px;
  }

  #container {
    text-align: center;
    
    position: absolute;
    transform: translate(-50%, -50%);
    left: 50%;
    top: 50%;

    width: 20%;

    background-color: rgb(32,124,92);
    padding: 50px;
    border-radius: 20px;

  }

  .form-text {
    color: white;
  }

  #button {
    font-weight: bold;
  }
</style>

