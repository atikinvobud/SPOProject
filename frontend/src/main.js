import './assets/main.css'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import App from './App.vue'

import Auth from './components/global/Auth.vue'
import Main from './components/global/Main.vue'

import SignIn from './pages/SignIn.vue'
import SignUp from './pages/SignUp.vue'
import SetIOriginalnformation from './pages/SetIOriginalnformation.vue'
import PersonalAccount from './pages/PersonalAccount.vue'
import EditPersonalAccount from './pages/EditPersonalAccount.vue'
import SearchTournament from './pages/SearchTournament.vue'
import CreateTournament from './pages/CreateTournament.vue'
import NotFound from './pages/NotFound.vue'
import MyTeams from './pages/MyTeams.vue'
import CreateTeam from './pages/CreateTeam.vue'
import TeamInfo from './pages/TeamInfo.vue'

const app = createApp(App)

const routes = [
  {
    path: '/auth', redirect: '/auth/login', component: Auth, children: [{
      path: 'login', name: 'Login', component: SignIn
    }, {
      path: 'register', name: 'Register', component: SignUp
    }, {
      path: 'register/set-information', name: 'SetInformation', component: SetIOriginalnformation
    }
    ]
  },
  {
    path: '/', component: Main, children: [
      { path: '', name: 'PersonalAccount', component: PersonalAccount },
      { path: '/personal-account/edit', name: 'EditPersonalAccount', component: EditPersonalAccount },
      { path: '/search-tournament', name: 'SearchTournament', component: SearchTournament },
      { path: '/create-tournament', name: 'CreateTournament', component: CreateTournament },
      { path: '/my-teams', name: 'MyTeams', component: MyTeams },
      { path: '/my-teams/create', name: 'CreateTeam', component: CreateTeam },
      { path: '/my-teams/team-info/:id', name: 'TeamInfo', component: TeamInfo }
    ]
  },
  { path: '/:pathMatch(.*)*', name: 'NotFound', component: NotFound }
]


const router = createRouter({
  history: createWebHistory(),
  routes
})

router.beforeEach(async (to, from) => {
  const userId = localStorage.getItem('id')

  if (to.name !== 'Login' && to.name !== 'Register' && !userId) {
    return { name: 'Login' }
  }
})

app.use(router)

app.mount('#app')

