<template>
  <!-- <p>Можно отключить сервера Конкорда, но нельзя отключить нашу любовь к нему</p> -->
  <div class="flex-1 flex flex-col min-h-screen text-center gap-5">
    <h1 class="text-4xl pt-10">Страница не найдена</h1>
    <router-link :to="{ name: 'PersonalAccount' }">
      <p class="text-xl text-blue">Главная</p>
    </router-link>
  </div>
</template>
