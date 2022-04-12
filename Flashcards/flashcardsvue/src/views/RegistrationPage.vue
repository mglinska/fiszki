<template>
  <h1 id="zarejestruj">Nie masz konta? Zarejestruj się!</h1>
  <h1 id="email"> Email:</h1>
  <h1 id="imie">Imię:</h1>
  <h1 id="haslo">Hasło</h1>
  <h1 id="powtorz">Powtórz hasło</h1>
  <h1 class="logo_tekst">Fiszki</h1>
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo">
  <img :src="require('../assets/gfx/ksiazki.svg')" id="ksiazki"> 
  <img :src="require('../assets/gfx/plamka_pomaranczowa.svg')" id="plam_pom"> 
  <img :src="require('../assets/gfx/mniejpomaranczowa.svg')" id="plam_mniej_pom"> 
  <img :src="require('../assets/gfx/zolta.svg')" id="zolta"> 
  <img :src="require('../assets/gfx/zielone_zarejestruj.svg')" id="zielone_zarejestruj"> 
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo"> 
  <img :src="require('../assets/gfx/bordowe.svg')" id="bordowe"> 
 <v-form 
    id=reg_form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="name"
      :counter="20"
      :rules="nameRules"
      label="Name"
      required
    ></v-text-field>

    <v-text-field
      v-model="email"
      :rules="emailRules"
      label="E-mail"
      required
    ></v-text-field>

     <v-text-field
      v-model="password"
      :rules="passwordRules"
      :type="password"
      label="Password"
      required
    ></v-text-field>

     <v-text-field
      v-model="repassword"
      :rules="repasswordRules"
      :type="password"
      label="Repeat password"
      required
    ></v-text-field>

    <v-checkbox
      v-model="checkbox"
      :rules="[v => !!v || 'You must agree to continue!']"
      label="I have read and accept the regulations"
      required
    ></v-checkbox>

    <v-btn
      color="success"
      class="mr-4"
      @click="validate"
    >
      Sign up!
    </v-btn>

  </v-form>
</template>

<script>
  import axios from 'axios'
  export default {
    data: () => ({
      name: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length >= 2) || 'Name must be more than 1 characters',
        v => (v && v.length <= 29) || 'Name must be less than 30 characters',
      ],
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
      repassword: '',
      checkbox: false,
    }),
    computed: {
      repasswordRules() {
        return [
        v => !!v || 'Repeat password is required',
        (v) => (v === this.password) || 'The given passwords do not match',
        ]
      },
    },
    methods: {
      submit() {

        const formData = {};
        formData['name'] = this.name;
        formData['surname'] = "null";
        formData['email'] = this.email;
        formData['password'] = this.password;
        
        axios.post("http://localhost:5085/api/" + "User/register", formData).then(()=>{
          this.$router.push({ name: 'Home'});
          alert("the form has been sent");
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

#zarejestruj {
  color: white;
  z-index: 6;
  position: absolute;
  width: 516px;
  height: 46px;
  left: 751px;
  top: 372px;
}

#email
{
  color: white;
  position: absolute;
  width: 83px;
  height: 32px;
  left: 751px;
  top: 471px;
  z-index: 6;
}
#imie
{
  color: white;
  z-index: 6;
  position: absolute;
  width: 83px;
  height: 32px;
  left: 751px;
  top: 551px;
}
#haslo
{
  color:white;
  position: absolute;
  width: 83px;
  height: 32px;
  left: 750px;
  top: 636px;
  z-index: 6;
}
#powtorz
{
  color: white;
  position: absolute;
  width: 210px;
  height: 32px;
  left: 750px;
  top: 735px;
  z-index: 6;

}
#ksiazki
{
  position: absolute;
  width: 433px;
  height: 322px;
  left: 5px;
  top: 758px;
}

#plam_pom
{

  position: absolute;
  width: 515px;
  height: 574px;
  left: 1905px;
  top: 870px;

}
#plam_mniej_pom
{
  position: absolute;
  width: 433px;
  height: 468px;
  left: 22px;
  top: 739px;
}
#zolta
{
  position: absolute;
  width: 411px;
  height: 562px;
  left: 1206px;
  top: 625px;
}

#bordowe
{
  color: #903F3F;
  position: absolute;
  width: 235px;
  height: 61px;
  left: 913px;
  top: 914px;
  z-index: -0.5;
}
#zielone_zarejestruj
{
  position: absolute;
  width: 829px;
  height: 692px;
  left: 616px;
  top: 314px;
  z-index: -0.5;
}
</style>



