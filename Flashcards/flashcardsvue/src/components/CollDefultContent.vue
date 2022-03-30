<template>
  <h1 style="margin: 30px;">Kolekcje</h1>
  <v-btn :value="status" @click="$emit('update:status', 1)" class="label" variant="contained-text" color="white">Dodaj kolekcje</v-btn>
</template>

<script>
export default {
  props: ['status'],
  emits: ['update:status'],
}
</script>


