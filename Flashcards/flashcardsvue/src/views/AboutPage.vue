<template>
  <v-responsive
    class="overflow-y-auto temp2"
    max-height="1000"
    width="500"
  >
    <div v-for="i in 10" :key="i" class="pa-6 text-center temp">
      fiszka 1 
    </div>

    <v-responsive height="200vh" class="text-center pa-2">
    </v-responsive>
  </v-responsive>
</template>

<script>
 export default {
    data: () => ({
      isActive: false,
    }),
  }
</script>

<style scoped>
  .temp {
    background-color: aqua;
    width: 80%;
    margin: auto;
    margin-top: 2px;
    margin-bottom: 2px;
    border: solid 2px;
  }

  .temp2 {
    margin: auto;
  }
</style>