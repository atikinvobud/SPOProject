<script setup>
  import TournamentCard from './TournamentCard.vue'

  defineProps({
    tournaments: Array,
  })
</script>

<template>
  <div class="flex flex-col gap-7 mt-6">
    <TournamentCard
      v-for="tournament in tournaments"
      :key="tournament.id"
      :tournament="tournament"
    />
  </div>
</template>
