<template>
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
        //this.$router.push({ name: 'Home'});
        //alert("walidacja po stronie serwera");
        //document.getElementById('log_form').submit();

        const formData = {};
        formData['email'] = this.email;
        formData['password'] = this.password;
        const jsonFormData = JSON.stringify(formData)
        axios.post('/', jsonFormData).then((response)=>{
          this.$router.push({ name: 'Home'});
          console.log(response.data);
          alert("the form has been sent");
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

