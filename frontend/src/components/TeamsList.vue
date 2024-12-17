<script setup>
  import TeamCard from './TeamCard.vue'
</script>

<template>
  <div class="w-[700px]">
    <section class="grid grid-cols-3 gap-7 mt-6">
      <router-link :to="{ name: 'TeamInfo', params: { id: 1 } }">
        <TeamCard></TeamCard>
      </router-link>
      <router-link :to="{ name: 'TeamInfo', params: { id: 1 } }">
        <TeamCard></TeamCard>
      </router-link>
      <router-link :to="{ name: 'TeamInfo', params: { id: 1 } }">
        <TeamCard></TeamCard>
      </router-link>
    </section>
    <div class="flex gap-6 justify-center mt-8">
      <button
        class="bg-blue text-white rounded-[18px] py-2 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
      >
        Найти команду
      </button>
      <router-link :to="{ name: 'CreateTeam' }">
        <button
          class="bg-blue text-white rounded-[18px] py-2 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
        >
          Создать команду
        </button>
      </router-link>
    </div>
  </div>
</template>
