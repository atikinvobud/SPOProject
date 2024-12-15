<script setup>
  import { ref, reactive, onMounted } from 'vue'

  import SearchComponent from '@/components/SearchComponent.vue'
  import axios from 'axios'

  const searchQuery = ref('')
  const filters = reactive([
    {
      label: 'Вид спорта',
      options: [],
      selectedId: null,
      isVisible: false,
    },
    {
      label: 'Роль',
      options: [
        { id: 1, name: 'Капитан' },
        { id: 2, name: 'Участник' },
      ],
      selectedId: null,
      isVisible: false,
    },
  ])

  const fetchOptionsForFilters = async () => {
    try {
      const sportsResponse = await axios.get('http://localhost:5234/sports')

      filters[0].options = sportsResponse.data
    } catch (err) {
      console.log(err)
    }
  }

  const onClickSearch = async () => {
    try {
      console.log()
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchOptionsForFilters)
</script>

<template>
  <div class="mx-auto w-[1124px]">
    <h1 class="font-semibold text-[28px] mb-5">Мои команды</h1>
    <p class="text-sm text-blue mb-6">
      Главная <span class="text-dark-blue opacity-[.68]">></span> Команды
    </p>
    <SearchComponent
      v-model:filters="filters"
      v-model:searchQuery="searchQuery"
      @onClickSearch="onClickSearch"
    />
    <div class="w-[700px]">
      <section class="grid grid-cols-3 gap-7 mt-6">
        <div
          class="bg-white p-4 rounded-2xl flex flex-col gap-6 transition hover:-translate-y-2 hover:shadow-lg cursor-pointer"
        >
          <div class="flex flex-col gap-1">
            <h2 class="text-xl">Качки</h2>
            <p class="opacity-[.68]">Футбол</p>
            <p><span class="opacity-[.68]">Роль:</span> Участник</p>
          </div>
          <img
            class="w-[100px] h-[100px] rounded-full self-center"
            src="/other/gigachad.png"
            alt=""
          />
        </div>
        <div
          class="bg-white p-4 rounded-2xl flex flex-col gap-6 transition hover:-translate-y-2 hover:shadow-lg cursor-pointer"
        >
          <div class="flex flex-col gap-1">
            <h2 class="text-xl">Качки</h2>
            <p class="opacity-[.68]">Футбол</p>
            <p><span class="opacity-[.68]">Роль:</span> Участник</p>
          </div>
          <img
            class="w-[100px] h-[100px] rounded-full self-center"
            src="/other/gigachad.png"
            alt=""
          />
        </div>
        <div
          class="bg-white p-4 rounded-2xl flex flex-col gap-6 transition hover:-translate-y-2 hover:shadow-lg cursor-pointer"
        >
          <div class="flex flex-col gap-1">
            <h2 class="text-xl">Качки</h2>
            <p class="opacity-[.68]">Футбол</p>
            <p><span class="opacity-[.68]">Роль:</span> Участник</p>
          </div>
          <img
            class="w-[100px] h-[100px] rounded-full self-center"
            src="/other/gigachad.png"
            alt=""
          />
        </div>
      </section>
      <div class="flex gap-6 justify-center mt-8">
        <button
          class="bg-blue text-white rounded-[18px] py-2 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
        >
          Найти команду
        </button>
        <button
          class="bg-blue text-white rounded-[18px] py-2 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
        >
          Создать команду
        </button>
      </div>
    </div>
  </div>
</template>
