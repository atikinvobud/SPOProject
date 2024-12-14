<script setup>
  import { ref } from 'vue'

  const { tournament } = defineProps({
    tournament: Object,
  })

  const convertDate = (date) => {
    return `${date.slice(-2)}.${date.slice(5, 7)}.${date.slice(0, 4)}`
  }

  function calculateTimeDifference(utcDateString) {
    const inputDate = new Date(utcDateString)
    const now = new Date()

    const differenceMs = inputDate - now

    const absDifferenceMs = Math.abs(differenceMs)

    const days = Math.floor(absDifferenceMs / (1000 * 60 * 60 * 24))
    const hours = Math.floor((absDifferenceMs % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
    const minutes = Math.floor((absDifferenceMs % (1000 * 60 * 60)) / (1000 * 60))

    function formatWithDeclension(value, singular, few, many) {
      if (value % 10 === 1 && value % 100 !== 11) {
        return `${value} ${singular}`
      } else if ([2, 3, 4].includes(value % 10) && ![12, 13, 14].includes(value % 100)) {
        return `${value} ${few}`
      } else {
        return `${value} ${many}`
      }
    }

    const daysStr = formatWithDeclension(days, 'день', 'дня', 'дней')
    const hoursStr = formatWithDeclension(hours, 'час', 'часа', 'часов')
    const minutesStr = formatWithDeclension(minutes, 'минута', 'минуты', 'минут')

    const formattedStr = `${daysStr} ${hoursStr} ${minutesStr}`

    return formattedStr
  }

  const remainingTime = ref(calculateTimeDifference(tournament.registrationDeadline))
</script>

<template>
  <div
    class="w-[696px] rounded-2xl bg-white shadow p-4 flex justify-between transition hover:-translate-y-2 hover:shadow-lg cursor-pointer"
  >
    <div>
      <h2 class="text-xl mb-[10px]">{{ tournament.name }}</h2>
      <div class="flex flex-col gap-[5px] text-sm">
        <p><span class="opacity-[.68] mr-2">Город проведения:</span>{{ tournament.city }}</p>
        <p>
          <span class="opacity-[.68] mr-2">Дата проведения:</span
          >{{ convertDate(tournament.startDate) }} -
          {{ convertDate(tournament.endDate) }}
        </p>
        <p><span class="opacity-[.68] mr-2">Статус:</span>{{ tournament.status }}</p>
        <p v-if="tournament.status == 'Регистрация'">
          <span class="opacity-[.68] mr-2">До окончания регистрации:</span>{{ remainingTime }}
        </p>
      </div>
    </div>
    <div class="flex flex-col items-end text-sm opacity-[.68]">
      <h3>{{ tournament.sport }}</h3>
      <h3>{{ tournament.format }}</h3>
    </div>
  </div>
</template>
