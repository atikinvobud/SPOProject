<script setup>
  import { onMounted, ref } from 'vue'

  import Sidebar from '@/components/Sidebar.vue'
  import axios from 'axios'

  const personalInfo = ref({})

  const fetchPersonalInfo = async () => {
    try {
      const params = {
        id: localStorage.getItem('id'),
      }
      console.log(params)
      const { data } = await axios.get(`https://54d7ea1c7c45f325.mokky.dev/set-information`, {
        params,
      })

      personalInfo.value = data[0]
      console.log(personalInfo.value)
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchPersonalInfo)
</script>

<template>
  <div class="flex-1 flex">
    <Sidebar />
    <main class="flex-1 pt-5 pl-[246px] pb-80">
      <h1 class="font-semibold text-[32px] mb-3">Личная информация</h1>
      <section class="bg-white shadow rounded-2xl w-[880px] px-6 py-7 text-xl flex flex-col">
        <article class="flex gap-8 mb-5">
          <img class="w-[140px] h-[140px] rounded-full" src="/other/gigachad.png" alt="" />
          <div class="flex flex-col gap-3">
            <div class="flex gap-[10px]">
              <span class="opacity-[.68]">Фамилия:</span>
              <span>{{ personalInfo.surname }}</span>
            </div>
            <div class="flex gap-[10px]">
              <span class="opacity-[.68]">Имя:</span>
              <span>{{ personalInfo.name }}</span>
            </div>
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
        <hr class="border-t-2 border-dark-blue opacity-[.68] mb-5" />
        <article class="flex flex-col gap-5">
          <div class="flex flex-col gap-1">
            <span class="opacity-[.68]">Любимые виды спорта:</span>
            <span class="text-lg">Футбол, Настольный Теннис</span>
          </div>
          <div class="flex flex-col gap-1">
            <span class="opacity-[.68]">О себе:</span>
            <span class="text-lg">Люблю футбол и настольный теннис</span>
          </div>
        </article>
        <router-link class="self-end" :to="{ name: 'edit-personal-account' }">
          <button
            class="bg-blue text-white text-xl rounded-[20px] py-[10px] px-4 w-[200px] transition hover:bg-[#004EC3] mt-9"
          >
            Редактировать
          </button>
        </router-link>
      </section>
    </main>
  </div>
</template>
