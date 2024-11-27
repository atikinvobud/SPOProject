<script setup>
  import { onMounted, ref } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'
  import Sidebar from '@/components/Sidebar.vue'

  const router = useRouter()

  const personalInfo = ref({})

  const fetchPersonalInfo = async () => {
    try {
      const params = {
        id: localStorage.getItem('id'),
      }

      const { data } = await axios.get(`https://54d7ea1c7c45f325.mokky.dev/set-information`, {
        params,
      })
      personalInfo.value = data[0]
    } catch (err) {
      console.log(err)
    }
  }

  const onClickSavePersonalInfo = async () => {
    try {
      const obj = {
        ...personalInfo.value,
      }

      const { data } = await axios.put(`https://54d7ea1c7c45f325.mokky.dev/set-information`, obj)

      router.push({ name: 'personal-account' })
      return data
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
      <section class="bg-white shadow rounded-2xl w-[880px] px-6 py-7 text-lg flex flex-col">
        <img
          class="w-[140px] h-[140px] rounded-full mx-auto mb-6"
          src="/other/gigachad.png"
          alt=""
        />
        <article class="grid grid-cols-2 gap-x-8 gap-y-5">
          <div class="flex flex-col gap-1">
            <label for="surname">Фамилия</label>
            <input
              class="rounded-lg text-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="text"
              required
              v-model="personalInfo.surname"
            />
          </div>
          <div class="flex flex-col gap-1">
            <label for="surname">Имя</label>
            <input
              class="rounded-lg text-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="text"
              required
              v-model="personalInfo.name"
            />
          </div>
          <div class="flex flex-col gap-1">
            <label for="name">Пол</label>
            <select
              class="rounded-lg text-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              name="gender"
              required
              v-model="personalInfo.gender"
            >
              <option value="Мужской">Мужской</option>
              <option value="Женский">Женский</option>
            </select>
          </div>
          <div class="flex flex-col gap-1">
            <label for="date-of-birth">Дата рождения</label>
            <input
              class="rounded-lg text-lg bg-gray pl-4 py-3 border-[#D5D5D3]"
              type="date"
              name="date-of-birth"
              placeholder="Дата рождения"
              min="1900-01-01"
              required
              v-model="personalInfo.dateOfBirth"
            />
          </div>
        </article>
        <hr class="border-t-2 border-dark-blue opacity-[.68] mt-5 mb-5" />
        <article class="flex flex-col gap-4">
          <div class="flex flex-col gap-5 w-[400px]">
            <label for="favorite-types-of-sport">Любимые виды спорта</label>
            <input
              class="rounded-lg text-lg bg-gray pl-4 py-3 border-[#D5D5D3]"
              type="text"
              name="favorite-types-of-sport"
            />
          </div>
          <div class="flex flex-col gap-5 w-[400px]">
            <label for="about">О себе</label>
            <input
              class="rounded-lg text-lg bg-gray pl-4 py-3 border-[#D5D5D3]"
              type="text"
              name="about"
            />
          </div>
        </article>
        <button
          class="self-center bg-blue text-white text-xl rounded-[20px] py-[10px] px-4 w-[200px] transition hover:bg-[#004EC3] mt-7"
          @click="onClickSavePersonalInfo"
        >
          Сохранить
        </button>
      </section>
    </main>
  </div>
</template>
