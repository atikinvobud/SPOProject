<script setup>
  import { onMounted, ref } from 'vue'
  import { useRouter } from 'vue-router'

  import axios from 'axios'

  const router = useRouter()

  const cities = ref([])
  const typeOfSports = ref([])

  const personalInfo = ref({})

  const fetchPersonalInfo = async () => {
    try {
      const id = localStorage.getItem('id')

      const [personalInfoResponse, citiesResponse, sportsResponse] = await Promise.all([
        axios.get(`http://localhost:5234/personal-account/${id}`),
        axios.get('http://localhost:5234/cities'),
        axios.get('http://localhost:5234/sports'),
      ])

      const data = personalInfoResponse.data
      personalInfo.value = {
        surname: data.surname,
        name: data.name,
        gender: data.gender,
        dateOfBirth: data.birthday,
        city: data.city,
        favouriteSports: data.favouriteSports,
        description: data.description,
      }

      cities.value = citiesResponse.data
      typeOfSports.value = sportsResponse.data
    } catch (err) {
      console.log(err)
    }
  }

  const onClickSavePersonalInfo = async () => {
    try {
      const cityId = cities.value.find((city) => city.name === personalInfo.value.city).id
      const favouriteSports = typeOfSports.value.filter((typeOfSport) =>
        personalInfo.value.favouriteSports.includes(typeOfSport.name),
      )

      const favouriteSportsId = favouriteSports.map((typeOfSport) => typeOfSport.id)

      const obj = {
        id: Number(localStorage.getItem('id')),
        surname: personalInfo.value.surname,
        name: personalInfo.value.name,
        gender: personalInfo.value.gender,
        dateOfBirth: personalInfo.value.dateOfBirth,
        description: personalInfo.value.description,
        cityId: cityId,
        favouriteSportsId: favouriteSportsId,
      }

      const { data } = await axios.put(`http://localhost:5234/personal-account/edit`, obj)

      router.push({ name: 'PersonalAccount' })
      return data
    } catch (err) {
      console.log(err)
    }
  }

  onMounted(fetchPersonalInfo)
</script>

<template>
  <div class="mx-auto w-[880px]">
    <h1 class="font-semibold text-[28px] mb-5">Личная информация</h1>
    <section class="bg-white shadow rounded-2xl px-[22px] py-6 flex flex-col">
      <article class="flex justify-between">
        <img
          class="w-[140px] h-[140px] rounded-full self-center"
          src="/other/gigachad.png"
          alt=""
        />
        <div class="grid grid-cols-2 gap-x-[68px] gap-y-5">
          <div class="flex flex-col gap-1">
            <label for="surname">Фамилия</label>
            <input
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="text"
              required
              v-model="personalInfo.surname"
            />
          </div>
          <div class="flex flex-col gap-1">
            <label for="surname">Имя</label>
            <input
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="text"
              required
              v-model="personalInfo.name"
            />
          </div>
          <div class="flex flex-col gap-1">
            <label for="name">Пол</label>
            <select
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              name="gender"
              required
              v-model="personalInfo.gender"
            >
              <option value="Мужской">Мужской</option>
              <option value="Женский">Женский</option>
            </select>
          </div>
          <div class="flex flex-col gap-1">
            <label for="date-of-birth">Дата рождения</label>
            <input
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              type="date"
              name="date-of-birth"
              placeholder="Дата рождения"
              min="1900-01-01"
              required
              v-model="personalInfo.dateOfBirth"
            />
          </div>
          <div class="flex flex-col gap-1 col-span-2 justify-self-center">
            <label for="city">Город</label>
            <select
              class="w-[300px] rounded-lg bg-gray pl-4 py-[10px] border-[#D5D5D3]"
              name="city"
              required
              v-model="personalInfo.city"
            >
              <option v-for="city in cities" :key="city.id" :value="city.name">
                {{ city.name }}
              </option>
            </select>
          </div>
        </div>
      </article>
      <hr class="line mt-5 mb-5" />
      <article class="flex flex-col gap-4">
        <div class="flex flex-col gap-5">
          <label for="favorite-types-of-sport">Любимые виды спорта</label>
          <select
            class="rounded-lg text-lg bg-gray pl-4 py-2 border-[#D5D5D3] basis-2/5"
            type="text"
            name="favorite-types-of-sport"
            multiple
            v-model="personalInfo.favouriteSports"
          >
            <option
              v-for="typeOfSport in typeOfSports"
              :key="typeOfSport.id"
              :value="typeOfSport.name"
            >
              {{ typeOfSport.name }}
            </option>
          </select>
        </div>
        <div class="flex flex-col gap-4">
          <label for="about">О себе</label>
          <textarea
            class="rounded-lg text-lg bg-gray pl-4 py-2 border-[#D5D5D3]"
            type="text"
            name="about"
            v-model="personalInfo.description"
          />
        </div>
      </article>
      <button
        class="self-center bg-blue text-white rounded-[18px] py-3 px-4 min-w-[200px] transition hover:bg-[#004EC3] mt-7"
        @click="onClickSavePersonalInfo"
      >
        Сохранить
      </button>
    </section>
  </div>
</template>
