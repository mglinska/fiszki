<template>
  <div id="background">
    <v-input :messages="link" id="input_with_link">
      <h3>Link do udostępnienia:</h3>
    </v-input>
    <v-btn
      color="success"
      class="mr-4"
      @click="copy_to_clipboard"
    >
      Skopiuj do schowka
    </v-btn>
    <span id='link' style="display: none;"> {{ link }} </span>
  </div>
</template>

<script>

export default {
  props: ['coll_name', 'coll_id'],
  data() {
    return {
      link: '',
      shared_link: 'shared_link'
    }
  },
  methods: {
    encrypt(value) {
      const CryptoJS = require('crypto-js');
      return CryptoJS.enc.Base64.stringify(CryptoJS.enc.Utf8.parse(value));
    },
    generate_link() {
      let base = 'http://localhost:8080/'
      let admixture = this.encrypt(Math.floor(Date.now() / 1000));
      let collName = this.encrypt(this.coll_name);
      let collId = this.encrypt(this.coll_id);
      this.link = base + collName + '-' + collId + '-' + admixture
      console.log(this.link);
    },

    copy_to_clipboard() {
      /* Get the text field */
      let copyText = document.querySelector(".v-messages__message");
      
      /* Copy the text inside the text field */
      navigator.clipboard.writeText(copyText.textContent);
    }
  },

  mounted: function() {
      this.generate_link();
    },
}
</script>

<style scoped>
#background {
  background-color: aliceblue;
  padding: 30px;
  border-radius: 10px;
}
</style> 