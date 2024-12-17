<script setup>
  import { ref, onMounted, reactive, computed } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  const router = useRouter()

  const typeOfSports = ref([])

  const commandInfo = reactive({
    name: '',
    typeOfSport: '',
    contacts: '',
  })

  const isDataEntered = computed(() => {
    for (const key in commandInfo) {
      if (commandInfo[key] === '') {
        return false
      }
    }
    return true
  })

  const handleSubmit = async () => {
    try {
      const obj = {
        ...commandInfo,
        createrId: Number(localStorage.getItem('id')),
      }

      const { data } = axios.post(`https://54d7ea1c7c45f325.mokky.dev/commands`, obj)

      router.push({ name: 'MyCommands' })
      return data
    } catch (err) {
      console.log(err)
    }
  }

  const fetchOptionsForFields = async () => {
    try {
      const { data } = await axios.get(`http://localhost:5234/sports`)

      typeOfSports.value = data
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchOptionsForFields)
</script>

<template>
  <div class="mx-auto w-[680px]">
    <h1 class="font-semibold text-[28px] mb-5">Создание команды</h1>
    <p class="text-sm text-blue mb-6">
      Главная <span class="text-dark-blue opacity-[.68]">></span> Команды
      <span class="text-dark-blue opacity-[.68]">></span> Создание команды
    </p>
    <div class="bg-white shadow rounded-2xl p-5">
      <form class="flex flex-col" @submit.prevent="handleSubmit">
        <img class="w-[120px] h-[120px] rounded-full mx-auto" src="/other/gigachad.png" alt="" />
        <section class="flex justify-between mt-6">
          <div class="flex flex-col gap-1">
            <label for="name">Название</label>
            <input class="w-[300px] input-field" type="text" required v-model="commandInfo.name" />
          </div>
          <div class="flex flex-col gap-1">
            <label for="typeOfSport">Вид спорта</label>
            <select
              class="w-[300px] input-field"
              name="typeOfSport"
              required
              v-model="commandInfo.typeOfSport"
            >
              <option
                v-for="typeOfSport in typeOfSports"
                :key="typeOfSport.id"
                :value="typeOfSport.id"
              >
                {{ typeOfSport.name }}
              </option>
            </select>
          </div>
        </section>
        <hr class="line mt-5 mb-6" />
        <section class="flex flex-col gap-5">
          <label for="contacts">Контакты капитана</label>
          <textarea
            class="input-field"
            name="contacts"
            type="text"
            v-model="commandInfo.contacts"
          ></textarea>
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
