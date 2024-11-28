import './assets/main.css'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import App from './App.vue'

import SignIn from './pages/SignIn.vue'
import SignUp from './pages/SignUp.vue'
import SetIOriginalnformation from './pages/SetIOriginalnformation.vue'
import PersonalAccount from './pages/PersonalAccount.vue'
import EditPersonalAccount from './pages/EditPersonalAccount.vue'

const app = createApp(App)

const routes = [
  { path: '', redirect: '/signin' },
  { path: '/signin', name: 'signin', component: SignIn },
  { path: '/signup', name: 'signup', component: SignUp },
  { path: '/signup/set-information', name: 'set-information', component: SetIOriginalnformation },
  { path: '/personal-account', name: 'personal-account', component: PersonalAccount },
  { path: '/personal-account/edit', name: 'edit-personal-account', component: EditPersonalAccount }
]


const router = createRouter({
  history: createWebHistory(),
  routes
})

router.beforeEach(async (to, from) => {
  const userId = localStorage.getItem('id')

  if (to.name !== 'signin' && to.name !== 'signup' && !userId) {
    return { name: 'signin' }
  }
})

app.use(router)

app.mount('#app')

