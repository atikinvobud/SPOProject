<script setup>
  import Header from '../Header.vue'
</script>

<template>
  <div class="flex-1 flex flex-col min-h-screen">
    <Header />
    <div class="w-96 bg-white rounded-2xl mt-10 mx-auto px-8 py-8 text-center drop-shadow">
      <router-view></router-view>
    </div>
  </div>
</template>
