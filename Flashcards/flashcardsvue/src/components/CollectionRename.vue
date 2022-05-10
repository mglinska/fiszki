<template>
  <div id="background">
    <h1 style="margin: 30px;">Zmień nazwę kolekcji</h1>
    <v-form 
    id="rename_coll_form"
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field 
      id="text-field"
      v-model="name"
      :rules="nameRules"
      label="Edytuj nazwę kolekcji"
      required
    ></v-text-field>

    <v-btn
      id="btn"
      color="success"
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
  props: ['overlay', 'coll_id', 'coll_name'],
  emits: ['update:overlay'],
  data: () => ({
      name: '',
      nameRules: [
        v => !!v || 'Nazwa kolekcji jest wymagana',
        v => (v && v.length >= 3) || 'Nazwa kolekcji musi mieć wiecej niż 2 znaki',
        v => (v && v.length <= 50) || 'Nazwa kolekcji musi mieć mniej niż 50 znaki'
      ],
    }),
    methods: {
      submit() {
        
        const formData = {};
        
        formData['id_collection'] = this.coll_id;
        formData['name'] = this.name;
        formData['description'] = "abc";
        console.log(formData);
        
        axios.put("http://localhost:5085/api/" + "Collection", formData).then(()=>{
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
    mounted: function() {
      this.name = this.coll_name
    }
}
</script>

<style scoped>
#background {
  background-color: aliceblue;
  padding: 30px;
  border-radius: 10px;
}
</style>