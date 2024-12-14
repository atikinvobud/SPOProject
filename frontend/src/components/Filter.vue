<script setup>
  import { computed } from 'vue'

  defineProps({
    index: Number,
  })

  const filter = defineModel('filter')

  const emit = defineEmits(['toggleVisibilityNotSelectedFilters'])
  const toggleVisibility = () => {
    filter.value.isVisible = !filter.value.isVisible
    emit('toggleVisibilityNotSelectedFilters', filter.value.label)
  }

  const selectOption = (optionId) => {
    filter.value.selectedId = optionId
  }

  const deleteOption = () => {
    filter.value.selectedId = null
  }

  const filterLabel = computed(() => {
    if (filter.value.selectedId === null) {
      return filter.value.label
    }
    const option = filter.value.options.find((option) => option.id === filter.value.selectedId)
    return option.name
  })
</script>

<template>
  <li class="relative flex">
    <div
      class="flex items-center justify-between border border-[#D5D5D3] px-2 py-1 rounded-lg w-[216px] opacity-[.68] hover:bg-gray cursor-pointer"
      @click="toggleVisibility"
    >
      <span>{{ filterLabel }}</span>
      <img
        v-if="!filter.selectedId"
        class="transition-transform"
        :class="{ '-rotate-90': filter.isVisible }"
        src="/arrow.svg"
        alt="Arrow"
      />
      <img v-else class="w-[14px] h-[14px]" src="/close.svg" alt="Close" @click="deleteOption" />
    </div>
    <ul class="absolute left-[232px] flex flex-col" v-show="filter.isVisible">
      <li
        v-for="option in filter.options"
        :key="option.id"
        @click="selectOption(option.id), toggleVisibility()"
        :class="{ 'bg-gray': false }"
        class="whitespace-nowrap cursor-pointer px-2 py-1 hover:bg-gray bg-white first:rounded-tl-lg first:rounded-tr-lg last:rounded-bl-lg last:rounded-br-lg"
      >
        <span class="opacity-[.68]">
          {{ option.name }}
        </span>
      </li>
    </ul>
  </li>
</template>
