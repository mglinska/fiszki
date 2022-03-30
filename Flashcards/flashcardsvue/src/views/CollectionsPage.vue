<template>
  <DefultContent v-if="this.status === 0" v-model:status="status"/>
  <AddContent v-else-if="this.status === 1" v-model:status="status"/>
  <div style="height: 10px;"></div>
    <v-expansion-panels  id="collections">

      <v-expansion-panel v-for="coll in collections" :key="coll.id">
        <v-expansion-panel-title color="green" hide-actions="True">
          {{ coll.title }}
        </v-expansion-panel-title>
        <v-expansion-panel-text>
          <v-btn class="label" variant="contained-text" color="white">Ucz się!</v-btn>
          <v-btn class="label" variant="contained-text" color="white">Zarządzaj</v-btn>
          <v-btn class="label" variant="contained-text" color="white">Usuń</v-btn>
        </v-expansion-panel-text>
      </v-expansion-panel>
    </v-expansion-panels>
  

</template>

<script>
import DefultContent from '../components/CollDefultContent.vue'
import AddContent from '../components/CollAddContent.vue'

export default {
  data() {
    return {
      title: 'Collections',
      status: 0,
      collections: [
        {title: "Angielski - zwierzęta", id: 1},
        {title: "POI - kartkówka", id: 2},
        {title: "Stolice Państw", id: 3},
      ]
    }
  },
  components: {
    DefultContent,
    AddContent,
  },
}
</script>

<style>
    .label{
        background-color: green;
        display: block;
        margin: 10px;
    }

    #collections{
      width: 20%;
      margin-left: 10px;
    }

    .coll:hover{
      cursor: pointer;
    }


</style>