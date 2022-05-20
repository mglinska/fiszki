<template>
  <CarouselShared v-model:coll_Name="coll_Name" v-model:coll_Id="coll_Id"/>
</template>

<script>
import CarouselShared from '../components/CarouselFcForShardedCollection.vue'

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
      CarouselShared,
    },
}
</script>