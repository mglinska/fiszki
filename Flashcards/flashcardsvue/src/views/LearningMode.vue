<template>
    <Navbar />
    <Carousel v-model:coll_Name="coll_Name" v-model:coll_Id="coll_Id"/>
</template>

<script>
import Navbar from '../components/NavBar.vue'
import Carousel from '../components/CarouselFc.vue'

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
      Carousel,
    },
}
</script>

<style scoped>
</style>