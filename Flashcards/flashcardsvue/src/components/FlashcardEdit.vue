<template>
    <h1 style="margin: 30px;">Edytuj Fiszkę</h1>

    <v-btn :value="status" @click="$emit('update:status', 0); $emit('update:fc_id', null)" class="label" variant="contained-text" color="white">Wróć</v-btn>
    
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
      Zapisz!
    </v-btn>

  </v-form>
</template>

<script>
import axios from 'axios'

export default {
  props: ['status', 'coll_id' , 'fc_id'],
  emits: ['update:status', 'update:fc_id'],
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

        formData['id_flashcard'] = this.fc_id;
        formData['id_collection'] = this.coll_id;
        formData['question'] = this.awers;
        formData['answer'] = this.rewers;

        console.log(formData)

        axios.put("http://localhost:5085/api/" + "Flashcard", formData).then(()=>{
          this.$emit('update:status', 0);
          this.$emit('update:fc_id', null);
          this.$parent.refreshData();
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