<script setup>
  import CommandCard from './CommandCard.vue'
</script>

<template>
  <div class="w-[700px]">
    <section class="grid grid-cols-3 gap-7 mt-6">
      <CommandCard></CommandCard>
      <CommandCard></CommandCard>
      <CommandCard></CommandCard>
    </section>
    <div class="flex gap-6 justify-center mt-8">
      <button
        class="bg-blue text-white rounded-[18px] py-2 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
      >
        Найти команду
      </button>
      <router-link :to="{ name: 'CreateCommand' }">
        <button
          class="bg-blue text-white rounded-[18px] py-2 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
        >
          Создать команду
        </button>
      </router-link>
    </div>
  </div>
</template>
