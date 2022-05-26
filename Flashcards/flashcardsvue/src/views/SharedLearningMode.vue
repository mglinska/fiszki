<template>
  <CarouselShared v-model:coll_Name="coll_Name" v-model:coll_Id="coll_Id"/>
</template>

<script>
import CarouselShared from '../components/CarouselFcForSharedCollection.vue'
import axios from 'axios'

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
    methods: {
      check_link() {
        let link = window.location.pathname.substring(1)
        axios.post("http://localhost:5085/api/" + "Link/" + link).then((response)=>{
          if (!response.data) {
            this.$router.push({ name: 'NoPermissionPage'});
          }
        }).catch(() => {
          this.$router.push({ name: 'NoPermissionPage'});
        })
      }
    },
    components: {
      CarouselShared,
    },
  mounted: function() {
    this.check_link()
    }
}
</script>