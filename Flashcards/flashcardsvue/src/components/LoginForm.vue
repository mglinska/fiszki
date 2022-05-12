<template>
  <div id="login-body">
    <div id="login-container">
      <h1 id="title-text">Logowanie</h1>

      <v-form 
        v-on:submit.prevent="validate"
        id=log_form
        ref="form"
        v-model="valid"
        lazy-validation
      >
      <v-text-field
        class="form-text"
        v-model="email"
        :rules="emailRules"
        label="E-mail"
        required
        v-on:keyup.enter="validate"
      ></v-text-field>
      <v-text-field
        class="form-text"
        v-model="password"
        :rules="passwordRules"
        :type="'password'"
        label="Password"
        required
        v-on:keyup.enter="validate"
      ></v-text-field>

      <h4 id="warning"> {{wrong_data_message}}</h4>

      <v-btn
        id="login-button"
        @click="validate"
      >
        Zaloguj się
      </v-btn>

      </v-form>
    </div>
  </div>
</template>

<script>
  import axios from 'axios'
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
      wrong_data_message: '',
    }),
    methods: {
      submit() {
        const formData = {};
        formData['first_name'] = "";
        formData['email'] = this.email;
        formData['password'] = this.encrypt(this.password);

        axios.post("http://localhost:5085/api/" + "User/login", formData).then((response)=>{
          let zmienna = response.data;
          sessionStorage.setItem('user_id', zmienna.Id_user);
          let message = 'Witaj ponownie ' + zmienna.First_name;
          this.$router.push({ name: 'Collections', params: { username: message }});
        }).catch(() => {
          this.wrong_data_message = 'Niepoprawne dane logowania!'
        })
      },
      encrypt(password) {
        const CryptoJS = require('crypto-js');
        return CryptoJS.enc.Base64.stringify(CryptoJS.enc.Utf8.parse(password));
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
  #login-body {
    background-image: url('../assets/floor-tile.png');
    background-repeat: repeat;
    height: 100%;

    padding-top: 1.5%;
  }
    
  #title-text {
    color: white;
    margin-left: auto;
    margin-right: auto;
    margin-bottom: 30px;
  }

  #login-container {
    text-align: center;

    margin-left: auto;
    margin-right: auto;
    margin-top: 10%;
    width: 20%;

    background-color: rgb(32,124,92);
    padding: 50px;
    border-radius: 20px;
  }

  .form-text {
    color: white;
  }

  #warning {
    color: red;
    padding-bottom: 30px;
  }

  #login-button {
    font-weight: bold;
  }
</style>