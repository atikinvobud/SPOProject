<script setup>
  import { ref, computed } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  const router = useRouter()

  const surname = ref('')
  const name = ref('')
  const gender = ref('')
  const dateOfBirth = ref('')

  const isDataEntered = computed(
    () =>
      surname.value !== '' && name.value !== '' && gender.value !== '' && dateOfBirth.value !== '',
  )

  const handleSubmit = async () => {
    try {
      const arr = dateOfBirth.value.split('-')
      dateOfBirth.value = `${arr[2]}.${arr[1]}.${arr[0]}`

      const obj = {
        id: localStorage.getItem('id'),
        surname: surname.value,
        name: name.value,
        gender: gender.value,
        dateOfBirth: dateOfBirth.value,
      }

      const { data } = await axios.post(`https://54d7ea1c7c45f325.mokky.dev/set-information`, obj)

      router.push({ name: 'personal-account' })
      return data
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <div class="w-[464px] bg-white rounded-2xl mt-16 mx-auto px-12 py-10 text-center drop-shadow">
    <h3 class="text-2xl mb-7">Введите данные</h3>
    <form class="mb-6" @submit.prevent="handleSubmit">
      <div class="flex flex-col gap-11">
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="text"
          name="surname"
          placeholder="Фамилия"
          pattern="[А-Я][а-я]{1,15}"
          title="Фамилия должна начинаться с заглавной буквы и состоять из кириллицы"
          v-model="surname"
          required
        />
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="text"
          name="name"
          placeholder="Имя"
          pattern="[А-Я][а-я]{1,15}"
          title="Фамилия должна начинаться с заглавной буквы и состоять из кириллицы"
          v-model="name"
          required
        />
        <select
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          name="gender"
          required
          v-model="gender"
        >
          <option disabled value="">Пол</option>
          <option value="Мужской">Мужской</option>
          <option value="Женский">Женский</option>
        </select>
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="date"
          name="date-of-birth"
          placeholder="Дата рождения"
          min="1900-01-01"
          v-model="dateOfBirth"
          required
        />
      </div>
      <button
        :disabled="!isDataEntered"
        class="bg-blue disabled:opacity-60 enabled:hover:bg-[#004EC3] text-white text-xl rounded-xl py-3 w-60 mx-auto transition mt-7"
        type="submit"
      >
        Продолжить
      </button>
    </form>
  </div>
</template>
