<template>
  <aside class="w-52 bg-white pt-[38px] px-4">
    <ul class="flex flex-col gap-7">
      <router-link :to="{ name: 'PersonalAccount' }">
        <li class="flex gap-3 hover:text-light-blue">
          <img src="/sidebar/personal-account-logo.svg" alt="personal-account-logo" />
          <span>Личный кабинет</span>
        </li>
      </router-link>
      <li class="flex gap-3 hover:text-light-blue">
        <img src="/sidebar/search-logo.svg" alt="search-logo" />
        <span>Найти турнир</span>
      </li>
      <li class="flex gap-3 hover:text-light-blue">
        <img src="/sidebar/cup-logo.svg" alt="cup-logo" />
        <span>Турниры</span>
      </li>
      <li class="flex gap-3 hover:text-light-blue">
        <img src="/sidebar/team-logo.svg" alt="team-logo" />
        <span>Команды</span>
      </li>
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
