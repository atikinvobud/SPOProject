<script setup>
  import { ref, computed } from 'vue'
  import axios from 'axios'

  const email = ref('')
  const password = ref('')

  const isDataEntered = computed(() => email.value !== '' && password.value !== '')

  const isError = ref(false)

  const handleSubmit = async () => {
    try {
      const params = {
        email: email.value,
        password: password.value,
      }
      const { data } = await axios.get('https://54d7ea1c7c45f325.mokky.dev/signin', { params })
    } catch (err) {
      console.log('Не найден, Бро...')
      isError.value = true
    }
  }
</script>

<template>
  <div class="form-window bg-white rounded-2xl mt-16 mx-auto px-12 py-10 text-center drop-shadow">
    <h3 class="text-2xl mb-7">Вход в аккаунт</h3>
    <form class="mb-6" @submit.prevent="handleSubmit">
      <div class="flex flex-col gap-11">
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="email"
          name="email"
          placeholder="Почта"
          required
          v-model="email"
        />
        <input
          class="rounded-lg text-xl bg-gray pl-4 py-3 border-[#D5D5D3]"
          type="password"
          name="password"
          placeholder="Пароль"
          required
          v-model="password"
        />
      </div>
      <p v-if="isError" class="text-left text-red mt-3">Неверная почта или пароль</p>
      <button
        :disabled="!isDataEntered"
        class="bg-blue disabled:opacity-60 enabled:hover:bg-[#004EC3] text-white text-xl rounded-xl py-3 w-60 mx-auto transition mt-7"
        type="submit"
      >
        Войти
      </button>
    </form>
    <div class="flex flex-col gap-4 text-left font-medium text-light-blue">
      <p>Забыли адрес электронной почты?</p>
      <router-link :to="{ name: 'signup' }"><p>Регистрация</p></router-link>
    </div>
  </div>
</template>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap');

  .title {
    font-size: 32px;
  }

  .form-window {
    max-width: 464px;
  }
</style>
