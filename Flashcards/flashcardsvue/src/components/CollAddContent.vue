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

     <v-text-field
      v-model="description"
      :rules="descriptionRules"
      label="Opis"
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
  props: ['status'],
  emits: ['update:status'],
  data: () => ({
      name: '',
      nameRules: [
        v => !!v || 'Nazwa kolekcji jest wymagana',
        v => (v && v.length >= 3) || 'Nazwa kolekcji musi mieć wiecej niż 2 znaki',
        v => (v && v.length <= 50) || 'Nazwa kolekcji musi mieć mniej niż 50 znaki'
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

        console.log(formData)
        
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
#add_fc_form {
  margin: 10px;
}

#background {
  background-color: aliceblue;
  padding: 30px;
  border-radius: 10px;
}
</style> 
