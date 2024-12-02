<script setup>
  import { onMounted, ref } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  const router = useRouter()

  const personalInfo = ref({})

  const fetchPersonalInfo = async () => {
    try {
      const id = localStorage.getItem('id')

      const { data } = await axios.get(`https://54d7ea1c7c45f325.mokky.dev/users-info/${id}`)
      personalInfo.value = data
    } catch (err) {
      console.log(err)
    }
  }

  const onClickSavePersonalInfo = async () => {
    try {
      const obj = {
        ...personalInfo.value,
      }

      const id = localStorage.getItem('id')
      const { data } = await axios.patch(`https://54d7ea1c7c45f325.mokky.dev/users-info/${id}`, obj)

      router.push({ name: 'PersonalAccount' })
      return data
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchPersonalInfo)
</script>

<template>
  <div class="mx-auto w-[880px]">
    <h1 class="font-semibold text-[28px] mb-5">Личная информация</h1>
    <section class="bg-white shadow rounded-2xl px-[22px] py-6 flex flex-col">
      <article class="flex justify-between">
        <img
          class="w-[140px] h-[140px] rounded-full self-center"
          src="/other/gigachad.png"
          alt=""
        />
        <div class="grid grid-cols-2 gap-x-[68px] gap-y-5">
          <div class="flex flex-col gap-1">
            <label for="surname">Фамилия</label>
            <input
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="text"
              required
              v-model="personalInfo.surname"
            />
          </div>
          <div class="flex flex-col gap-1">
            <label for="surname">Имя</label>
            <input
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="text"
              required
              v-model="personalInfo.name"
            />
          </div>
          <div class="flex flex-col gap-1">
            <label for="name">Пол</label>
            <select
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
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
              class="w-[300px] rounded-lg bg-gray pl-4 py-3 border-[#D5D5D3]"
              type="date"
              name="date-of-birth"
              placeholder="Дата рождения"
              min="1900-01-01"
              required
              v-model="personalInfo.dateOfBirth"
            />
          </div>
        </div>
      </article>
      <hr class="line mt-5 mb-5" />
      <article class="flex flex-col gap-4">
        <div class="flex flex-col gap-5">
          <label for="favorite-types-of-sport">Любимые виды спорта</label>
          <textarea
            class="rounded-lg text-lg bg-gray pl-4 py-2 border-[#D5D5D3]"
            type="text"
            name="favorite-types-of-sport"
          />
        </div>
        <div class="flex flex-col gap-4">
          <label for="about">О себе</label>
          <textarea
            class="rounded-lg text-lg bg-gray pl-4 py-2 border-[#D5D5D3]"
            type="text"
            name="about"
          />
        </div>
      </article>
      <button
        class="self-center bg-blue text-white rounded-[18px] py-3 px-4 min-w-[200px] transition hover:bg-[#004EC3] mt-7"
        @click="onClickSavePersonalInfo"
      >
        Сохранить
      </button>
    </section>
  </div>
</template>
