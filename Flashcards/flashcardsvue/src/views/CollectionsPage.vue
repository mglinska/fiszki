<template>
  <Navbar />
  <CollContent v-model:user_name="user_name"/>
</template>

<script>
import Navbar from '../components/NavBar.vue'
import CollContent from '../components/CollectionsContant.vue'

export default {
  props: {
      username: String,
  },
  data() {
    return {
      user_name: this.username,
    }
  },

  components: {
    Navbar,
    CollContent,
  },
}
</script>

<style scoped>
</style>