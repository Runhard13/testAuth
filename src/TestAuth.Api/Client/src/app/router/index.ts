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
    },
    {
      path: routes.users(),
      name: 'users',
      component: Users,
    },
  ],
})

export default router
