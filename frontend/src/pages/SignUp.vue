<script setup>
  import { computed, ref } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  import SubmitFormButton from '@/components/SubmitFormButton.vue'

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

      const { data } = await axios.post(`http://localhost:5234/auth/register`, obj)

      localStorage.setItem('id', JSON.stringify(data.id))
      router.push({ name: 'SetInformation' })
    } catch (err) {
      console.log(err)
      isError.value = true
    }
  }
</script>

<template>
  <div>
    <h3 class="text-xl mb-7">Регистрация</h3>
    <form @submit.prevent="handleSubmit">
      <div class="flex flex-col gap-[22px]">
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="email"
          name="email"
          placeholder="Почта"
          pattern="\w+@[a-z_]+\.[a-z]{2,6}"
          title="Неправильный формат почты. username@domain.com (Пример)"
          v-model="email"
          required
        />
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
          type="password"
          name="password"
          placeholder="Пароль"
          v-model="password"
          pattern="\S{6,}"
          title="Пароль должен содержать минимум 6 символов, среди которых нет пробела"
          required
        />
        <input
          class="rounded-lg bg-gray pl-4 py-2.5 border-[#D5D5D3]"
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
      <SubmitFormButton title="Регистрация" :isDisabled="!isDataEntered || !isFormValid" />
    </form>
  </div>
</template>
