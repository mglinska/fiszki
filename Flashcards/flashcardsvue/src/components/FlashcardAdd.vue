<template>
  <div id="background">
    <h1 style="margin: 30px;">Dodaj Fiszkę</h1>
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
  </div>
</template>

<script>
import axios from 'axios'

export default {
  props: ['overlay', 'coll_id'],
  emits: ['update:overlay'],
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
        console.log(this.coll_id)
    
        formData['id_collection'] = this.coll_id;
        formData['question'] = this.awers;
        formData['answer'] = this.rewers;
        
        axios.post("http://localhost:5085/api/" + "Flashcard/" + sessionStorage.getItem('user_id'), formData).then(()=>{
          this.$emit('update:overlay', false);
          this.$emit("refresh", "cokolwiek");
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
}

#background {
  background-color: aliceblue;
  padding: 30px;
  border-radius: 10px;
}
</style> 