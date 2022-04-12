<template>
  <h1 id="home">Witaj na naszej stronie</h1>
  <h1 id="witaj"> Masz dość nudnego uczenia się z książek? Nauka przychodzi Ci nad wyraz trudno?Mamy na to rozwiązanie! Dzięki nam opanujesz każdy materiał dobrze się przy tym bawiąc. Już teraz dołącz do nas i zaproś swoich znajomych! </h1>
  <h1 class="logo_tekst">Fiszki</h1>
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo">
  <img :src="require('../assets/gfx/ksiazki.svg')" id="ksiazki"> 
  <img :src="require('../assets/gfx/plamka_pomaranczowa.svg')" id="plam_pom"> 
  <img :src="require('../assets/gfx/mniejpomaranczowa.svg')" id="plam_mniej_pom"> 
  <img :src="require('../assets/gfx/zolta.svg')" id="zolta"> 
  <img :src="require('../assets/gfx/zielone.svg')" id="zielone"> 
  <img :src="require('../assets/gfx/logo.svg')" class="sowa_logo"> 

</template>

<script>

export default {
  data() {
    return {
      title: 'Home'
    }
  }
}
</script>

<style scoped>
#home {
  color: black;
  position: absolute;
  width: 1135px;
  height: 92px;
  left: 403px;
  top: 214px;
}

#witaj
{
  color: white;
  position: absolute;
  width: 1040px;
  height: 250px;
  left: 473px;
  top: 522px;
  z-index: 6;
}

#ksiazki
{
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
  width: 411px;
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


