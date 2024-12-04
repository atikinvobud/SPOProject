<script setup>
  import { ref, reactive, computed } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  const router = useRouter()

  const tournamentInfo = reactive({
    name: '',
    typeOfSport: '',
    format: '',
    placement: '',
    startDate: '',
    endDate: '',
    description: '',
    contacts: '',
    registrationDeadline: '',
  })

  function toLocalISOString(date) {
    const pad = (num) => String(num).padStart(2, '0')

    const year = date.getFullYear()
    const month = pad(date.getMonth() + 1)
    const day = pad(date.getDate())

    const hours = pad(date.getHours())
    const minutes = pad(date.getMinutes())

    return `${year}-${month}-${day}T${hours}:${minutes}`
  }

  const now = new Date()
  const today = ref(toLocalISOString(now).split('T')[0])
  const nowString = ref(toLocalISOString(now).slice(0, 16))

  const maxDateTime = computed(() => {
    return tournamentInfo.startDate ? `${tournamentInfo.startDate}T23:59` : null
  })

  const updateEndDate = () => {
    if (tournamentInfo.endDate && tournamentInfo.endDate < tournamentInfo.startDate) {
      tournamentInfo.endDate = tournamentInfo.startDate
    }
  }

  const isDataEntered = computed(() => {
    for (const key in tournamentInfo) {
      if (tournamentInfo[key] === '') {
        return false
      }
    }
    return true
  })

  const handleSubmit = () => {
    try {
      const obj = {
        ...tournamentInfo,
        organizerID: Number(localStorage.getItem('id')),
        private: false,
      }

      const { data } = axios.post(`https://54d7ea1c7c45f325.mokky.dev/tournaments`, obj)

      router.push({ name: 'PersonalAccount' })
      return data
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <div class="mx-auto w-[880px]">
    <h1 class="font-semibold text-[28px] mb-5">Создание турнира</h1>
    <p class="text-sm text-blue mb-6">
      Главная <span class="text-dark-blue opacity-[.68]">></span> Создание турнира
    </p>
    <div class="bg-white shadow rounded-2xl px-[22px] py-5 flex flex-col">
      <form class="flex flex-col" @submit.prevent="handleSubmit">
        <section class="mb-5">
          <div class="flex flex-col gap-[6px] mb-5">
            <label for="tournament-name">Название турнира</label>
            <input
              class="input-field"
              type="text"
              name="tournament-name"
              required
              v-model="tournamentInfo.name"
            />
          </div>
          <div class="grid grid-cols-2 gap-6 mb-5">
            <div class="flex flex-col gap-[6px]">
              <label for="type-of-sport">Вид спорта</label>
              <select
                class="input-field"
                name="type-of-sport"
                required
                v-model="tournamentInfo.typeOfSport"
              >
                <option value="Футбол">Футбол</option>
                <option value="Настольный теннис">Настольный теннис</option>
                <option value="Шахматы">Шахматы</option>
              </select>
            </div>
            <div class="flex flex-col gap-[6px]">
              <label for="format">Формат турнира</label>
              <select class="input-field" name="format" required v-model="tournamentInfo.format">
                <option value="На выбывание">На выбывание</option>
                <option value="Регулярный">Регулярный</option>
              </select>
            </div>
          </div>
          <div class="flex flex-col gap-[6px] mb-5">
            <label for="placement">Место проведения</label>
            <input
              class="input-field"
              type="text"
              name="placement"
              required
              v-model="tournamentInfo.placement"
            />
          </div>
          <div class="grid grid-cols-2 gap-6">
            <div class="flex flex-col gap-[6px]">
              <label for="start-date">Дата начала</label>
              <input
                class="input-field"
                type="date"
                name="start-date"
                :min="today"
                @change="updateEndDate"
                required
                v-model="tournamentInfo.startDate"
              />
            </div>
            <div class="flex flex-col gap-[6px]">
              <label for="end-date">Дата конца</label>
              <input
                class="input-field"
                type="date"
                name="end-date"
                :min="tournamentInfo.startDate"
                max="2026-01-01"
                required
                v-model="tournamentInfo.endDate"
              />
            </div>
          </div>
        </section>
        <hr class="line mb-5" />
        <section class="flex flex-col gap-6 mb-5">
          <div class="flex flex-col gap-[6px]">
            <label for="description">Описание</label>
            <textarea
              class="input-field"
              type="text"
              name="description"
              v-model="tournamentInfo.description"
            />
          </div>
          <div class="flex flex-col gap-[6px]">
            <label for="contacts">Контакты организатора</label>
            <textarea
              class="input-field"
              type="text"
              name="contacts"
              v-model="tournamentInfo.contacts"
            />
          </div>
        </section>
        <hr class="line mb-5" />
        <section class="mb-5">
          <div class="flex flex-col gap-[6px] max-w-[400px]">
            <label for="registration-deadline">Время окончания регистрации</label>
            <input
              class="input-field"
              type="datetime-local"
              name="registration-deadline"
              :min="nowString"
              :max="maxDateTime"
              v-model="tournamentInfo.registrationDeadline"
            />
          </div>
        </section>
        <button
          :disabled="!isDataEntered"
          class="self-center bg-blue text-white rounded-[18px] py-3 px-4 min-w-[200px] transition disabled:opacity-60 disabled-cursor-no-drop enabled:hover:bg-[#004EC3] mt-7"
          type="submit"
        >
          Создать
        </button>
      </form>
    </div>
  </div>
</template>
