<template>
 <Navbar />
 <h1 style="margin: 35px;">Login</h1>
 <v-form 
    v-on:submit.prevent="validate"
    id=log_form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="email"
      :rules="emailRules"
      label="E-mail"
      required
      v-on:keyup.enter="validate"
    ></v-text-field>

     <v-text-field
      v-model="password"
      :rules="passwordRules"
      :type="password"
      label="Password"
      required
      v-on:keyup.enter="validate"
    ></v-text-field>

    <v-btn
      color="success"
      class="mr-4"
      @click="validate"
    >
      Log in!
    </v-btn>

  </v-form>
</template>

<script>
  import axios from 'axios'
  import Navbar from '../components/NavBar.vue'
  export default {
    data: () => ({
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],
      password: '',
      passwordRules: [
        v => !!v || 'Password is required',
        v => (v && v.length >= 8) || 'Password must be more than 8 characters',
        v => (v && v.length <= 29) || 'Password must be less than 30 characters',
      ],
    }),
    methods: {
      submit() {

        const formData = {};

        formData['first_name'] = "";
        formData['email'] = this.email;
        formData['password'] = this.encrypt(this.password);

        axios.post("http://localhost:5085/api/" + "User/login", formData).then((response)=>{
          console.log(response.data);
          let zmienna = response.data;
          sessionStorage.setItem('user_id', zmienna.Id_user);
          this.$router.push({ name: 'Home'});
        }).catch((error) => {
          console.log(error.response)
        })
      },
      encrypt(password) {
        const CryptoJS = require('crypto-js');
        return CryptoJS.enc.Base64.stringify(CryptoJS.enc.Utf8.parse(password));
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
    components: {
      Navbar
    }
  }
</script>

