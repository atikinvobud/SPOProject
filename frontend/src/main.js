import './assets/main.css'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import App from './App.vue'

import SignIn from './pages/SignIn.vue'
import SignUp from './pages/SignUp.vue'
import SetIOriginalnformation from './pages/SetIOriginalnformation.vue'

const app = createApp(App)

const routes = [
  { path: '', redirect: '/signin' },
  { path: '/signin', name: 'signin', component: SignIn },
  { path: '/signup', name: 'signup', component: SignUp },
  { path: '/signup/set-information/:id', name: 'set-information', component: SetIOriginalnformation },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

app.use(router)

app.mount('#app')

