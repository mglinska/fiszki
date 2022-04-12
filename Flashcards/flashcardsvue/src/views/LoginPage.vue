<template>
  <h1 id="zaloguj">Zaloguj się</h1>
  <h1 id="email"> Email:</h1>
  <h1 id="haslo">Hasło:</h1>
  <h1 id="zapomniales">Zapomniałeś hasła?</h1>
  <h1 class="logo_tekst">Fiszki</h1>
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo">
  <img :src="require('../assets/gfx/ksiazki.svg')" id="ksiazki"> 
  <img :src="require('../assets/gfx/plamka_pomaranczowa.svg')" id="plam_pom"> 
  <img :src="require('../assets/gfx/mniejpomaranczowa.svg')" id="plam_mniej_pom"> 
  <img :src="require('../assets/gfx/zolta.svg')" id="zolta"> 
  <img :src="require('../assets/gfx/zielone_zaloguj.svg')" id="zielone_zaloguj"> 
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo"> 
  <img :src="require('../assets/gfx/bordowe.svg')" id="bordowe"> 
 <v-form 
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
    ></v-text-field>

     <v-text-field
      v-model="password"
      :rules="passwordRules"
      :type="password"
      label="Password"
      required
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
    
        formData['email'] = this.email;
        formData['password'] = this.password;
        formData['name'] = "";
        formData['surname'] = "";

        axios.post("http://localhost:5085/api/" + "User/login", formData).then(()=>{
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

#zaloguj {
  color: white;
  position: absolute;
  width: 178px;
  height: 46px;
  left: 893px;
  top: 418px;
  z-index: 6;

}

#email
{
  color: white;
  position: absolute;
  width: 83px;
  height: 32px;
  left: 751px;
  top: 522px;
  z-index: 6;
}
#haslo
{
  color: white;
  z-index: 6;
  position: absolute;
  width: 83px;
  height: 32px;
  left: 751px;
  top: 615px;
}
#zapomniales
{
  color:purple;
  position: absolute;
  left: 54.9%;
  right: 36.15%;
  top: 62.78%;
  bottom: 34.44%;
  z-index: 6;
}
#zielone_zaloguj
{
  position: absolute;
  width: 688px;
  height: 617px;
  left: 645px;
  top: 339px;
  z-index: -0.5;
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
  left: 45.36%;
  right: 42.4%;
  top: 72.27%;
  bottom: 22.08%;

}
</style>

