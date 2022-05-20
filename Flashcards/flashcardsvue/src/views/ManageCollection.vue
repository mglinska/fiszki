<template>
  <Navbar />
  <Manage v-model:coll_Name="coll_Name" v-model:coll_Id="coll_Id"/>
</template>

<script>
import Navbar from '../components/NavBar.vue'
import Manage from '../components/ManageCollContent.vue'

export default {
    props: {
      collName: String,
      collId: Number,
  },
    
    data() {
      return {
        coll_Name: this.collName,
        coll_Id: this.collId,
      }
    },
    components: {
      Navbar,
      Manage,
    },
}
</script>

<style scoped>
</style>