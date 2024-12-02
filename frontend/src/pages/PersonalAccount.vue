<script setup>
  import { onMounted, ref } from 'vue'

  import axios from 'axios'

  const personalInfo = ref({})

  const fetchPersonalInfo = async () => {
    try {
      const id = localStorage.getItem('id')
      const { data } = await axios.get(`https://54d7ea1c7c45f325.mokky.dev/users-info/${id}`)

      personalInfo.value = data
      console.log(personalInfo.value)
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchPersonalInfo)
</script>

<template>
  <div class="mx-auto w-[680px]">
    <h1 class="font-semibold text-[28px] mb-5">Личная информация</h1>
    <section class="bg-white shadow rounded-2xl px-[22px] py-6 flex flex-col">
      <article class="flex gap-8 mb-5">
        <img class="w-[150px] h-[150px] rounded-full" src="/other/gigachad.png" alt="" />
        <div class="flex flex-col gap-3">
          <p class="text-2xl mb-4">{{ personalInfo.surname }} {{ personalInfo.name }}</p>
          <div class="flex gap-[10px]">
            <span class="opacity-[.68]">Пол:</span>
            <span>{{ personalInfo.gender }}</span>
          </div>
          <div class="flex gap-[10px]">
            <span class="opacity-[.68]">Город:</span>
            <span>{{ personalInfo.city }}</span>
          </div>
          <div class="flex gap-[10px]">
            <span class="opacity-[.68]">Возраст:</span>
            <span>{{ personalInfo.age }}</span>
          </div>
        </div>
      </article>
      <hr class="line mb-[22px]" />
      <article class="flex flex-col gap-[22px]">
        <div class="flex flex-col gap-1">
          <span class="opacity-[.68]">Любимые виды спорта:</span>
          <span class="text-sm">Футбол, Настольный Теннис</span>
        </div>
        <div class="flex flex-col gap-1">
          <span class="opacity-[.68]">О себе:</span>
          <span class="text-sm">Люблю футбол и настольный теннис</span>
        </div>
      </article>
      <router-link class="self-center" :to="{ name: 'EditPersonalAccount' }">
        <button
          class="bg-blue text-white rounded-[18px] py-3 px-4 min-w-[200px] transition hover:bg-[#004EC3] mt-7"
        >
          Редактировать
        </button>
      </router-link>
    </section>
  </div>
</template>
