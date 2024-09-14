import Login from '@/pages/Login.vue'
import Users from '@/pages/Users.vue'
import Welcome from '@/pages/Welcome.vue'
import { useStorage } from '@vueuse/core'
import { createRouter, createWebHistory } from 'vue-router'
import { routes } from './routes'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: routes.login.pattern,
      name: 'login',
      component: Login,
    },
    {
      path: routes.welcome.pattern,
      name: 'welcome',
      component: Welcome,
      beforeEnter: () => {
        const token = useStorage('token', '', localStorage)
        if (!token.value) {
          return { name: 'login' }
        }
      },
    },
    {
      path: routes.users.pattern,
      name: 'users',
      component: Users,
    },
  ],
})

export default router
