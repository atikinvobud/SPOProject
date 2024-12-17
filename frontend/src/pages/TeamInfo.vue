<template>
  <div class="mx-auto w-[680px]">
    <h1 class="font-semibold text-[28px] mb-5">Информация о команде</h1>
    <p class="text-sm text-blue mb-6">
      <router-link :to="{ name: 'PersonalAccount' }"
        ><span class="hover:underline hover:underline-offset-4">Главная</span></router-link
      >
      <span class="text-dark-blue opacity-[.68]"> > </span>
      <router-link :to="{ name: 'MyTeams' }"
        ><span class="hover:underline hover:underline-offset-4">Команды</span></router-link
      >
      <span class="text-dark-blue opacity-[.68]"> > </span> Информация о команде
    </p>
    <div class="bg-white shadow rounded-2xl p-5">
      <section class="flex items-center gap-8">
        <img class="w-[120px] h-[120px] rounded-full" src="/other/gigachad.png" alt="" />
        <div class="flex flex-col gap-6">
          <h2 class="text-2xl">Команда</h2>
          <p><span class="opacity-[.68] mr-2.5">Вид спорта:</span> Футбол</p>
        </div>
      </section>
      <hr class="line my-4" />
      <section>
        <h3 class="text-xl mb-4">Участники: 1</h3>
        <div class="flex flex-col gap-4">
          <div class="flex gap-3 items-center w-[300px]">
            <img class="w-10 h-10 rounded-full" src="/other/gigachad.png" alt="" />
            <div class="flex-1 flex justify-between items-center">
              <p>Иванов Иван</p>
              <p class="text-2xl">&copy;</p>
            </div>
          </div>
        </div>
      </section>
      <hr class="line my-4" />
      <section>
        <h3 class="text-xl mb-5">Контакты капитана:</h3>
        <p class="mb-2">Вк: https://vk.com/ivanov_ivan</p>
        <p>Телеграм: @ivanov.ivan</p>
      </section>
      <section class="flex justify-center gap-8 mt-8">
        <button
          class="bg-red opacity-90 text-white rounded-[18px] py-3 px-4 min-w-[200px] transition hover:opacity-100"
        >
          Удалить команду
        </button>
        <button
          class="bg-blue text-white rounded-[18px] py-3 px-4 min-w-[200px] transition hover:bg-[#004EC3]"
        >
          Редактировать
        </button>
      </section>
    </div>
  </div>
</template>
