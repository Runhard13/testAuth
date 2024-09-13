import type { UserClaims } from '../model/user-claims'
import router from '@/app/router'
import { routes } from '@/app/router/routes'
import { apiClient } from '@/shared/api'
import { useStorage } from '@vueuse/core'
import { ref } from 'vue'
import { parseJwt } from '../lib/parse-jwt'

const token = useStorage('token', '', localStorage)
const userData = ref<UserClaims | undefined>(token.value ? parseJwt(token.value) : undefined)

export function useCurrentUser() {
  const returnUrl = ref(routes.welcome())
  const isLoading = ref(false)

  const authenticate = async (username: string, password: string) => {
    isLoading.value = true
    const response = await apiClient.testAuthApi.auth.postApiAuthLogin({ username, password }).catch(() => {
      token.value = ''
    })

    if (response) {
      token.value = response.data?.accessToken
    }
    else {
      token.value = ''
    }

    isLoading.value = false
    router.push(returnUrl.value)
  }

  return { authenticate, userData, isLoading }
}
