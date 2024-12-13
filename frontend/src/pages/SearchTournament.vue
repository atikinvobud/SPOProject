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
      label: 'Формат',
      options: [],
      selectedId: null,
      isVisible: false,
    },
    {
      label: 'Статус',
      options: [
        { id: 1, name: 'Регистрация' },
        { id: 2, name: 'Регистрация завершена' },
        { id: 3, name: 'Идёт' },
      ],
      selectedId: null,
      isVisible: false,
    },
  ])

  const fetchOptionsForFilters = async () => {
    try {
      const [citiesResponse, sportsResponse] = await Promise.all([
        axios.get('http://localhost:5234/cities'),
        axios.get('http://localhost:5234/sports'),
      ])

      filters[0].options = citiesResponse.data
      filters[1].options = sportsResponse.data
    } catch (err) {
      console.log(err)
    }
  }

  const onClickSearch = async () => {
    console.log(filters)
    const params = {
      name: `*${searchQuery.value}*`,
      isPrivate: false,
    }

    const cityId = filters[0].selectedId
    if (cityId !== null) {
      params.cityId = cityId
    }

    const sportId = filters[1].selectedId
    if (sportId !== null) {
      params.sportId = sportId
    }

    const status = filters[2].selectedValue
    switch (status) {
      case 0:
        params.status = 'registraton'
        break
      case 1:
        params.status = 'registrationclosed'
        break
      case 2:
        params.status = 'active'
        break
    }
    const { data } = await axios.get(`https://54d7ea1c7c45f325.mokky.dev/tournaments`, { params })
    console.log(data)
    return data
  }

  onMounted(fetchOptionsForFilters)
</script>

<template>
  <div class="mx-auto w-[1124px]">
    <h1 class="font-semibold text-[28px] mb-5">Поиск турнира</h1>
    <p class="text-sm text-blue mb-6">Главная <span class="opacity-[.68]">></span> Поиск турнира</p>
    <SearchComponent
      v-model:filters="filters"
      v-model:searchQuery="searchQuery"
      @onClickSearch="onClickSearch"
    />
  </div>
</template>
