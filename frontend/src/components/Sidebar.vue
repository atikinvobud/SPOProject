<script setup>
  import { reactive, ref } from 'vue'

  const isVisibleMainDropdown = ref(false)
  const isVisibleAdditionalDropdowns = reactive({
    participant: false,
    organizer: false,
  })

  const toggleVisibleMainDropdown = () => {
    if (isVisibleMainDropdown.value === false) {
      isVisibleMainDropdown.value = true
    } else {
      isVisibleMainDropdown.value = false
      for (const dropdown in isVisibleAdditionalDropdowns) {
        isVisibleAdditionalDropdowns[dropdown] = false
      }
    }
  }

  const toggleVisibleAdditionalDropdown = (event) => {
    const id = event.currentTarget.id
    isVisibleAdditionalDropdowns[id] = !isVisibleAdditionalDropdowns[id]
  }
</script>

<template>
  <aside class="w-52 bg-white pt-[38px] px-4">
    <ul class="flex flex-col gap-7">
      <router-link :to="{ name: 'PersonalAccount' }">
        <li class="flex gap-3 hover:text-light-blue">
          <img src="/sidebar/personal-account-logo.svg" alt="personal-account-logo" />
          <span>Личный кабинет</span>
        </li>
      </router-link>
      <router-link :to="{ name: 'SearchTournament' }">
        <li class="flex gap-3 hover:text-light-blue">
          <img src="/sidebar/search-logo.svg" alt="search-logo" />
          <span>Найти турнир</span>
        </li>
      </router-link>
      <li>
        <div
          class="hover:text-light-blue flex justify-between cursor-pointer"
          @click="toggleVisibleMainDropdown"
        >
          <div class="flex gap-3">
            <img src="/sidebar/cup-logo.svg" alt="cup-logo" />
            <span>Турниры</span>
          </div>
          <img
            class="transition-transform"
            :class="{ '-rotate-90': isVisibleMainDropdown }"
            src="/arrow.svg"
            alt="Arrow"
          />
        </div>
        <ul v-show="isVisibleMainDropdown" class="pl-10 mt-3 flex flex-col gap-3">
          <li class="">
            <div
              class="flex justify-between cursor-pointer hover:text-light-blue"
              id="participant"
              @click="toggleVisibleAdditionalDropdown"
            >
              <span>Участник</span>
              <img
                class="transition-transform"
                :class="{ '-rotate-90': isVisibleAdditionalDropdowns.participant }"
                src="/arrow.svg"
                alt="Arrow"
              />
            </div>
            <ul
              v-show="isVisibleAdditionalDropdowns.participant"
              class="mt-2 pl-4 flex flex-col gap-2 text-sm"
            >
              <li class="cursor-pointer hover:text-light-blue">Активные</li>
              <li class="cursor-pointer hover:text-light-blue">Завершённые</li>
            </ul>
          </li>
          <li>
            <div
              class="flex justify-between cursor-pointer hover:text-light-blue"
              id="organizer"
              @click="toggleVisibleAdditionalDropdown"
            >
              <span>Организатор</span>
              <img
                class="transition-transform"
                :class="{ '-rotate-90': isVisibleAdditionalDropdowns.organizer }"
                src="/arrow.svg"
                alt="Arrow"
              />
            </div>
            <ul
              v-show="isVisibleAdditionalDropdowns.organizer"
              class="mt-2 pl-4 flex flex-col gap-2 text-sm"
            >
              <li class="cursor-pointer hover:text-light-blue">Активные</li>
              <li class="cursor-pointer hover:text-light-blue">Завершённые</li>
            </ul>
          </li>
        </ul>
      </li>
      <router-link :to="{ name: 'MyCommands' }">
        <li class="flex gap-3 hover:text-light-blue">
          <img src="/sidebar/team-logo.svg" alt="team-logo" />
          <span>Команды</span>
        </li>
      </router-link>
      <li class="flex gap-3 hover:text-light-blue">
        <img src="/sidebar/requests-logo.svg" alt="requests-logo" />
        <span>Заявки</span>
      </li>
      <router-link :to="{ name: 'CreateTournament' }">
        <li class="flex gap-3 hover:text-light-blue">
          <img src="/sidebar/plus-logo.svg" alt="plus-logo" />
          <span>Создать турнир</span>
        </li>
      </router-link>
    </ul>
  </aside>
</template>
