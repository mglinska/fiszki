<template>
    <div id="temp3">
        <h1> {{ collName }} </h1>
    </div>
  
  <v-responsive
    class="overflow-y-auto temp2"
    max-height="1000"
    width="500"
  >
    <div v-for="i in 10" :key="i" class="pa-6 text-center temp">
      fiszka {{ i }} 
    </div>

    <v-responsive height="200vh" class="text-center pa-2">
    </v-responsive>
  </v-responsive>
</template>

<script>
export default {
    props: ['collName'],
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
    border-radius: 25%;
}

.temp2 {
    margin: auto;
}

#temp3 {
    margin: auto;
    text-align: center;
}

</style>