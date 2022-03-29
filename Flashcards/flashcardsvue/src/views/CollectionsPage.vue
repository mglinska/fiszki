<template>
  <DefultContent v-if="this.status === 0" v-model:status="status"/>
  <AddContent v-else-if="this.status === 1" v-model:status="status"/>
  <EditContent v-else-if="this.status === 2" v-model:status="status"/>
  <DeleteContent v-else-if="this.status === 3" v-model:status="status"/>
  

</template>

<script>
import DefultContent from '../components/CollDefultContent.vue'
import AddContent from '../components/CollAddContent.vue'
import EditContent from '../components/CollEditContent.vue'
import DeleteContent from '../components/CollDeleteContent.vue'


export default {
  data() {
    return {
      title: 'Collections',
      status: 0
    }
  },
  components: {
    DefultContent,
    AddContent,
    EditContent,
    DeleteContent,
  },
}
</script>

<style>
    .label{
        background-color: green;
        display: block;
        margin: 10px;
    }
</style>