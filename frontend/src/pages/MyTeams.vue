<script setup>
  import { ref, reactive, onMounted } from 'vue'

  import SearchComponent from '@/components/SearchComponent.vue'
  import TeamsList from '@/components/TeamsList.vue'
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
      <router-link :to="{ name: 'PersonalAccount' }"
        ><span class="hover:underline hover:underline-offset-4">Главная</span></router-link
      >
      <span class="text-dark-blue opacity-[.68]"> > </span>Команды
    </p>
    <SearchComponent
      v-model:filters="filters"
      v-model:searchQuery="searchQuery"
      @onClickSearch="onClickSearch"
    />
    <TeamsList></TeamsList>
  </div>
</template>
