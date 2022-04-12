<template>
  <h1 class="onas"> O nas</h1>
  <h1 class="tekst"> Jesteśmy grupą młodych ludzi, a Fiszki są połączeniem naszych dwóch pasji - nauki i nowoczesnej technologii. Chcemy, żeby nauka z Fiszek była skuteczna i przyjemna. Stworzyliśmy te stronę, by pomóc innym w poszerzaniu swojej wiedzy w łatwy sposób, bo nauka może być świetną zabawą!:) </h1>
  <h1 class="logo_tekst">Fiszki</h1>
  <img :src="require('../assets/gfx/ksiazki.svg')" id="ksiazki"> 
  <img :src="require('../assets/gfx/plamka_pomaranczowa.svg')" id="plam_pom"> 
  <img :src="require('../assets/gfx/mniejpomaranczowa.svg')" id="plam_mniej_pom"> 
  <img :src="require('../assets/gfx/zolta.svg')" id="zolta"> 
  <img :src="require('../assets/gfx/zielone.svg')" id="zielone"> 
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo"> 


  <v-app>
    <v-main>
      <UserList/>
    </v-main>
  </v-app>
</template>

<script>
import UserList from '../components/UserList.vue'

export default {
  name: 'App',

  components: {
    UserList,
  },

  data: () => ({
    //
  }),
}
</script>

<style scoped>
.onas {

  text-align: center;
  position: absolute;
  width: 1135px;
  height: 92px;
  left: 403px;
  top: 214px;

}
.tekst
{
  color:#FFFFFF;
  position: absolute;
  width: 1040px;
  height: 252px;
  left: 473px;
  top: 522px;
  z-index: 6;
}

#ksiazki{

  position: absolute;
  width: 433px;
  height: 322px;
  left: 5px;
  top: 758px;

} 

#plam_pom
{
  position: absolute;
  width: 515px;
  height: 574px;
  left: 1905px;
  top: 870px;

}

#plam_mniej_pom
{
  position: absolute;
  width: 433px;
  height: 468px;
  left: 22px;
  top: 739px;
}

#zolta 
{
  position: absolute;
  width: 492px;
  height: 562px;
  left: 1206px;
  top: 625px;

}
#zielone
{
  position: absolute;
  width: 1124px;
  height: 504px;
  left: 438px;
  top: 400px;
  z-index: -0.5;
}

</style>

<style>
.sowa_logo
{
  position: absolute;
  width: 180px;
  height: 145px;
  left: 0px;
  top: 10px;
}

.logo_tekst{
  position: absolute;
  width: 160px;
  height: 65px;
  left: 136px;
  top: 50px;

}


</style>