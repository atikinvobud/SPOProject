<script setup>
  import Header from '../Header.vue'
  import Sidebar from '../Sidebar.vue'
</script>

<template>
  <div class="flex-1 flex flex-col min-h-screen">
    <Header />
    <div class="flex-1 flex">
      <Sidebar />
      <main class="flex-1 pt-5 pb-8">
        <router-view></router-view>
      </main>
    </div>
  </div>
</template>
