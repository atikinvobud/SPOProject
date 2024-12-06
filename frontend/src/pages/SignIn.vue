<script setup>
  import { ref, computed } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  import SubmitFormButton from '@/components/SubmitFormButton.vue'

  const router = useRouter()

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
      const { data } = await axios.get('http://localhost:5234/auth/login', { params })

      localStorage.setItem('id', JSON.stringify(data.id))
      router.push({ name: 'PersonalAccount' })
    } catch (err) {
      console.log(err)
      isError.value = true
    }
  }
</script>

<template>
  <div>
    <h3 class="text-xl mb-7">Вход в аккаунт</h3>
    <form @submit.prevent="handleSubmit">
      <div class="flex flex-col gap-5">
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="email"
          name="email"
          placeholder="Почта"
          required
          v-model="email"
        />
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="password"
          name="password"
          placeholder="Пароль"
          required
          v-model="password"
        />
      </div>
      <p v-if="isError" class="text-left text-red mt-2">Неверная почта или пароль</p>
      <SubmitFormButton title="Вход" :isDisabled="!isDataEntered" />
    </form>
    <p class="text-left font-medium text-light-blue mt-5">Забыли пароль?</p>
    <router-link :to="{ name: 'Register' }">
      <button
        class="bg-[#31DC65] hover:bg-[#12CC49] rounded-xl text-white text-lg py-2.5 w-full transition mt-[14px]"
      >
        Регистрация
      </button>
    </router-link>
  </div>
</template>
