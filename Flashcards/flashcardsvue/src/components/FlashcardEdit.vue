<template>
  <div id="background">
    <h1 style="margin: 30px;">Edytuj fiszkę</h1>
    <v-form 
    id="edit_fc_form"
    ref="form"
    v-model="valid"
    lazy-validation
    v-on:submit.prevent="validate"
  >
    <v-text-field
      class="text-field"
      v-model="awers"
      :rules="awersRules"
      label="Awers"
      required
      v-on:keyup.enter="validate"
    ></v-text-field>

     <v-text-field
       class="text-field"
       v-model="rewers"
       :rules="rewersRules"
       label="Rewers"
       required
       v-on:keyup.enter="validate"
    ></v-text-field>

    <v-btn
      id="btn"
      color=rgb(32,124,92)
      style="color: white"
      class="mr-4"
      @click="validate"
    >
      Zapisz!
    </v-btn>
  </v-form>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  props: ['overlay', 'coll_id' , 'fc_id', 'awers_', 'rewers_'],
  emits: ['update:overlay', 'update:fc_id'],
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
          this.$emit('update:overlay', false);
          this.$emit('update:fc_id', null);
          this.$emit("refresh", "cokolwiek");
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
    mounted: function() {
      console.log(this.awers_)
      console.log(this.rewers_)
      this.awers = this.awers_
      this.rewers = this.rewers_
    },
}
</script>

<style scoped>
#edit_fc_form {
  margin: 10px;
}

#background {
  background-color: white;
  padding: 30px;
  border-radius: 10px;
}
</style> 