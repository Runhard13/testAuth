import { useCurrentUser } from '@/entities/current-user'
import Login from '@/pages/Login.vue'
import Users from '@/pages/Users.vue'
import Welcome from '@/pages/Welcome.vue'
import { createRouter, createWebHistory } from 'vue-router'
import { routes } from './routes'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: routes.login(),
      name: 'login',
      component: Login,
    },
    {
      path: routes.welcome(),
      name: 'welcome',
      component: Welcome,
      beforeEnter: (to) => {
        const { userData } = useCurrentUser()

        if (!userData.value && to.name !== routes.login()) {
          return { name: 'login' }
        }
      }
      ,
    },
    {
      path: routes.users(),
      name: 'users',
      component: Users,
    },
  ],
})

export default router
