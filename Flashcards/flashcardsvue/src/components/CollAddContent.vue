<template>
  <div id="background">
    <h1 style="margin: 30px;">Dodaj kolekcję</h1>
    <v-form 
    id="add_coll_form"
    ref="form"
    v-model="valid"
    lazy-validation
    v-on:submit.prevent="validate"
  >
    <v-text-field
      class="text-field"
      v-model="name"
      :rules="nameRules"
      label="Wprowadź nazwę kolekcji"
      required
    ></v-text-field>

    <h4 id="warning"> {{wrong_data_message}}</h4>

    <v-btn
      id="button-add"
      color=rgb(32,124,92)
      style="color: white"
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
  props: ['overlay'],
  emits: ['update:overlay'],
  data: () => ({
      name: '',
      nameRules: [
        v => !!v || 'Nazwa kolekcji jest wymagana',
        v => (v && v.length >= 3) || 'Nazwa kolekcji musi mieć wiecej niż 2 znaki',
        v => (v && v.length <= 40) || 'Nazwa kolekcji musi mieć mniej niż 40 znaki'
      ],
      user: [],
      wrong_data_message: ''
    }),
    methods: {
      submit() {
        
        const formData = {};
        
        formData['name'] = this.name;
        formData['description'] = '';

        axios.post("http://localhost:5085/api/" + "Collection/" + sessionStorage.getItem('user_id'), formData).then((response)=>{
          if (response.data.Id_collection == -1)
          {
            this.wrong_data_message = 'Kolekcja o podanej nazwie już istnieje. Wprowadź inną nazwę kolekcji.'
            return
          }
          this.$emit('update:overlay', false);
          this.$emit("refresh", "cokolwiek");
        }).catch((error) => {
          console.log(error.response)
        })
      },
      validate() {
        this.wrong_data_message = ''
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
#button-add {
  background-color:rgb(32,124,92)
}

#add_fc_form {
  margin: 10px;
}

#background {
  background-color: white;
  padding: 30px;
  border-radius: 10px;
  width: 400px;
}

#warning {
    color: red;
    padding-bottom: 30px;
  }
</style> 
