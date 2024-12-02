<script setup>
  import Footer from './components/Footer.vue'
</script>

<template>
  <div class="flex flex-col">
    <router-view></router-view>
    <Footer />
  </div>
</template>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');
</style>
