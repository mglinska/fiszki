<template>
    <h1 style="margin: 30px;">Dodaj Fiszkę</h1>

    <v-btn :value="status" @click="$emit('update:status', 0)" class="label" variant="contained-text" color="white">Wróć</v-btn>
    
    <v-form 
    id="add_fc_form"
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="awers"
      :rules="awersRules"
      label="Awers"
      required
    ></v-text-field>

     <v-text-field
      v-model="rewers"
      :rules="rewersRules"
      label="Rewers"
    ></v-text-field>

    <v-btn
      color="success"
      class="mr-4"
      @click="validate"
    >
      Dodaj!
    </v-btn>

  </v-form>
</template>

<script>
import axios from 'axios'

export default {
  props: ['status'],
  emits: ['update:status'],
  data: () => ({
      awers: '',
      awersRules: [
        v => !!v || 'To pole jest wymagane',
      ],
      rewers: '',
      rewersRules: [
        v => !!v || 'To pole jest wymagane',
      ],
    }),
    methods: {
      submit() {

        const formData = {};
    
        formData['id_collection'] = 32;
        formData['question'] = this.awers;
        formData['answer'] = this.rewers;
        
        axios.post("http://localhost:5085/api/" + "Flashcard/5", formData).then(()=>{
          this.$emit('update:status', 0);
          this.$parent.refreshData();
          alert("Poprawnie dodano nową kolekcję");
        }).catch((error) => {
          console.log(error.response)
        })
        
      },
      validate() {
        this.$refs.form.resetValidation();
        const prom = this.$refs.form.validate();
        prom.then((a) => {
          if(a.valid) {
            this.submit();
          }
        });
      },
    },
}
</script>

<style scoped>
#add_fc_form {
  margin: 10px;
  width: 20%;
}
</style>