<script setup>
  import { computed, reactive } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  import SubmitFormButton from '@/components/SubmitFormButton.vue'

  const router = useRouter()

  const personalInfo = reactive({
    surname: '',
    name: '',
    gender: '',
    dateOfBirth: '',
  })

  const isDataEntered = computed(() => {
    for (const key in personalInfo) {
      if (personalInfo[key] === '') {
        return false
      }
    }
    return true
  })

  const handleSubmit = async () => {
    try {
      const obj = {
        id: Number(localStorage.getItem('id')),
        ...personalInfo,
      }

      const { data } = await axios.post(`http://localhost:5234/auth/set-information`, obj)

      router.push({ name: 'PersonalAccount' })
      return data
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <div>
    <h3 class="text-xl mb-7">Введите данные</h3>
    <form @submit.prevent="handleSubmit">
      <div class="flex flex-col gap-[22px]">
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="text"
          name="surname"
          placeholder="Фамилия"
          pattern="[А-Я][а-я]{1,15}"
          title="Фамилия должна начинаться с заглавной буквы и состоять из кириллицы"
          v-model="personalInfo.surname"
          required
        />
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="text"
          name="name"
          placeholder="Имя"
          pattern="[А-Я][а-я]{1,15}"
          title="Фамилия должна начинаться с заглавной буквы и состоять из кириллицы"
          v-model="personalInfo.name"
          required
        />
        <select
          class="form-select rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3] appearance-none"
          name="gender"
          required
          v-model="personalInfo.gender"
        >
          <option disabled value="">Пол</option>
          <option value="Мужской">Мужской</option>
          <option value="Женский">Женский</option>
        </select>
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="date"
          name="date-of-birth"
          placeholder="Дата рождения"
          min="1900-01-01"
          v-model="personalInfo.dateOfBirth"
          required
        />
      </div>
      <SubmitFormButton title="Продолжить" :isDisabled="!isDataEntered" />
    </form>
  </div>
</template>
