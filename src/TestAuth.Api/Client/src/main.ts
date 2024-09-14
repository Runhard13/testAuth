import { QueryClient, VueQueryPlugin } from '@tanstack/vue-query'

import { createApp } from 'vue'
import App from './App.vue'

import router from './app/router'
import './app/style.css'

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false,
      retry: false,
    },
  },
})

const app = createApp(App)

app.use(router)
app.use(VueQueryPlugin, {
  queryClient,
})

app.mount('#app')
