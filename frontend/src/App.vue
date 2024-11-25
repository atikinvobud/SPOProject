<script setup>
  import Header from './components/Header.vue'
  import Footer from './components/Footer.vue'
</script>

<template>
  <div class="flex flex-col min-h-screen">
    <div class="flex-1">
      <Header />
      <router-view></router-view>
    </div>
    <div>
      <Footer />
    </div>
  </div>
</template>
