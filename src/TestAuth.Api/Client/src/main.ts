import { VueQueryPlugin } from '@tanstack/vue-query'

import { createApp } from 'vue'
import App from './App.vue'

import router from './app/router'
import './app/style.css'

const app = createApp(App)

app.use(router)
app.use(VueQueryPlugin)

app.mount('#app')
