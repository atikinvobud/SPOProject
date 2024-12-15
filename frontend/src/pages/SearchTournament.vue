<script setup>
  import { ref, reactive, onMounted } from 'vue'

  import SearchComponent from '@/components/SearchComponent.vue'
  import TournamentList from '@/components/TournamentList.vue'

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
      label: 'Город',
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

      filters[0].options = sportsResponse.data
      filters[1].options = citiesResponse.data
    } catch (err) {
      console.log(err)
    }
  }

  const tournaments = ref([])
  const isNotFound = ref(false)

  const onClickSearch = async () => {
    try {
      const params = {
        name: `${searchQuery.value}`,
        isPrivate: false,
      }

      const sportId = filters[0].selectedId
      if (sportId !== null) {
        params.sportId = sportId
      }

      const cityId = filters[1].selectedId
      if (cityId !== null) {
        params.cityId = cityId
      }

      const status = filters[2].selectedId
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
      const { data } = await axios.get(`http://localhost:5234/tournaments/get`, { params })

      tournaments.value = data

      if (tournaments.value.length === 0) {
        isNotFound.value = true
      } else {
        isNotFound.value = false
      }
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchOptionsForFilters)
</script>

<template>
  <div class="mx-auto w-[1124px]">
    <h1 class="font-semibold text-[28px] mb-5">Поиск турнира</h1>
    <p class="text-sm text-blue mb-6">
      Главная <span class="text-dark-blue opacity-[.68]">></span> Поиск турнира
    </p>
    <SearchComponent
      v-model:filters="filters"
      v-model:searchQuery="searchQuery"
      @onClickSearch="onClickSearch"
    />
    <TournamentList :tournaments="tournaments" />
    <p v-if="isNotFound" class="text-xl ml-8">Турниры не найдены</p>
  </div>
</template>
