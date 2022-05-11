<template>
  <div id="background">
    <h1 style="margin: 30px;">Dodaj kolekcje</h1>
    <v-form 
    id="add_coll_form"
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="name"
      :rules="nameRules"
      label="Wprowadź nazwę kolekcji"
      required
    ></v-text-field>

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
      description: '',
      descriptionRules: [
        v => (v.length <= 255) || 'Opis kolekcji musi mieć mniej niż 255 znaków',
      ],
      user: []
    }),
    methods: {
      submit() {
        
        const formData = {};
        
        formData['name'] = this.name;
        formData['description'] = this.description;

        axios.post("http://localhost:5085/api/" + "Collection/" + sessionStorage.getItem('user_id'), formData).then(()=>{
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
}
</style> 
