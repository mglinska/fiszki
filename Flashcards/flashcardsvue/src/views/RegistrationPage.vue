<template>
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
        //console.log(this.name);
        //this.$router.push({ name: 'Home'});
        //alert("the form has been sent");
        //document.getElementById('reg_form').submit();

        const formData = {};
        formData['name'] = this.name;
        formData['email'] = this.email;
        formData['password'] = this.password;
        const jsonFormData = JSON.stringify(formData);
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



