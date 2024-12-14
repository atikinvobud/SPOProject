<script setup>
  import { ref } from 'vue'

  import Filter from '@/components/Filter.vue'

  const filters = defineModel('filters')
  const searchQuery = defineModel('searchQuery')

  const isVisibleDropdown = ref(false)

  const closeDropdown = () => {
    isVisibleDropdown.value = false
    for (const filter of filters.value) {
      filter.isVisible = false
    }
  }

  const openDropdown = () => {
    isVisibleDropdown.value = true
  }

  const toggleVisibilityOfDropdown = (isSearchButton = false) => {
    if (isVisibleDropdown.value === true) {
      closeDropdown()
    } else if (!isSearchButton) {
      openDropdown()
    }
  }

  const toggleVisibilityNotSelectedFilters = (label) => {
    for (const otherFilter of filters.value) {
      if (otherFilter.label !== label) {
        otherFilter.isVisible = false
      }
    }
  }

  const emit = defineEmits(['onClickSearch'])
</script>

<template>
  <div class="flex items-center gap-6">
    <div class="bg-white flex items-center rounded-2xl pl-2 pr-1 border border-[#D5D5D3] w-[700px]">
      <div class="flex-1 flex">
        <img src="/search-logo.svg" alt="Иконка поиска" />
        <input
          class="flex-1 border-0 pl-2 pr-0 py-[6px] focus:ring-0"
          type="text"
          name="search-field"
          placeholder="Найти турнир"
          v-model="searchQuery"
        />
      </div>
      <button
        class="bg-blue text-white rounded-2xl px-[13px] py-1 transition hover:bg-[#004EC3]"
        @click="emit('onClickSearch'), toggleVisibilityOfDropdown(true)"
      >
        Поиск
      </button>
    </div>
    <div class="relative flex-1">
      <div
        class="px-4 py-[5px] bg-white rounded-2xl border border-[#D5D5D3] hover:bg-gray inline-flex cursor-pointer"
        @click="toggleVisibilityOfDropdown()"
      >
        <button class="flex items-baseline gap-1">
          Фильтр
          <img
            :class="{ '-rotate-180': isVisibleDropdown }"
            class="transition-transform"
            src="/arrow.svg"
            alt="Arrow"
          />
        </button>
      </div>
      <div class="absolute mt-1 bg-white rounded-2xl px-3 py-4 text-sm" v-show="isVisibleDropdown">
        <ul class="flex flex-col gap-5">
          <Filter
            v-for="(_, index) in filters"
            :key="index"
            :index="index"
            v-model:filter="filters[index]"
            @toggleVisibilityNotSelectedFilters="toggleVisibilityNotSelectedFilters"
          />
        </ul>
      </div>
    </div>
  </div>
</template>
