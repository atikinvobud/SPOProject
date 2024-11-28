<script setup>
  import { computed, ref } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  const router = useRouter()

  const email = ref('')
  const password = ref('')
  const repeatPassword = ref('')

  // Ошибка 409 Conflict
  const isError = ref(false)

  const isDataEntered = computed(
    () => email.value !== '' && password.value !== '' && repeatPassword.value !== '',
  )

  const isFormValid = computed(() => password.value === repeatPassword.value)

  const handleSubmit = async () => {
    try {
      const obj = {
        email: email.value,
        password: password.value,
      }

      const { data } = await axios.post(`https://54d7ea1c7c45f325.mokky.dev/signin`, obj)

      localStorage.setItem('id', JSON.stringify(data[0].id))
      router.push({ name: 'set-information' })
    } catch (err) {
      console.log(err)
      isError.value = true
    }
  }
</script>

<template>
  <div class="w-[464px] bg-white rounded-2xl mt-16 mx-auto px-12 py-10 text-center drop-shadow">
    <h3 class="text-2xl mb-7">Регистрация</h3>
    <form class="mb-6" @submit.prevent="handleSubmit">
      <div class="flex flex-col gap-11">
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="email"
          name="email"
          placeholder="Почта"
          v-model="email"
          required
        />
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="password"
          name="password"
          placeholder="Пароль"
          v-model="password"
          required
        />
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="password"
          name="repeat-password"
          placeholder="Повторить пароль"
          v-model="repeatPassword"
          required
        />
      </div>
      <p v-if="!isFormValid" class="text-left text-red mt-3">Пароли не совпадают</p>
      <p v-if="isError" class="text-left text-red mt-3">
        Пользователь с такой почтой уже существует
      </p>
      <button
        :disabled="!isDataEntered || !isFormValid"
        class="bg-blue disabled:opacity-60 enabled:hover:bg-[#004EC3] text-white text-xl rounded-xl py-3 w-60 mx-auto transition mt-7"
        type="submit"
      >
        Регистрация
      </button>
    </form>
  </div>
</template>
