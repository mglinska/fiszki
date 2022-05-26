<template>
  <div id="background">
    <v-input id="input_with_link" :messages="link">
      <h3>Link do udostępnienia:</h3>
    </v-input>
    <v-btn
      id="btn"
      color=rgb(32,124,92)
      style="color: white"
      class="mr-4"
      @click="copy_to_clipboard"
    >
      Skopiuj do schowka
    </v-btn>

    <span id="link" style="display: none"> {{link}} </span>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  props: ['coll_name', 'coll_id'],
  data() {
    return {
      link: '',
      shared_link: 'shared_link',
      generated: '',
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
      this.generated = collName + '-' + collId + '-' + admixture
    },

    copy_to_clipboard() {
      /* Get the text field */
      let copyText = document.querySelector(".v-messages__message");
      
      /* Copy the text inside the text field */
      navigator.clipboard.writeText(copyText.textContent);
    },
    add_link_to_db() {
      let datetime = new Date().toJSON().replace(/-/g,'-')
      const formData = {};
      formData['url'] = this.generated;
      formData['expiration_time'] = datetime;
      axios.post("http://localhost:5085/api/" + "Link", formData).then().catch();
    }
  },

  mounted: function() {
      this.generate_link();
      this.add_link_to_db();
    },
}
</script>

<style scoped>
#background {
  background-color: white;
  padding: 30px;
  border-radius: 10px;
}
</style>