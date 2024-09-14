import type { UserClaims } from '../model/user-claims'
import router from '@/app/router'
import { routes } from '@/app/router/routes'
import { useApiClient } from '@/shared/api'
import { useStorage } from '@vueuse/core'
import { ref } from 'vue'
import { MapCurrentUser } from '../lib/currentUserMapping'

const token = useStorage('token', '', localStorage)

export function useAuthentication() {
  const isLoading = ref(false)

  const { apiClient } = useApiClient()

  const authenticate = async (username: string, password: string) => {
    isLoading.value = true

    try {
      const response = await apiClient.api.authLoginCreate({ username, password })
      token.value = response.data.data?.accessToken
    }
    catch {
      token.value = ''
    }
    finally {
      isLoading.value = false
    }
  }

  return { authenticate, isLoading }
}

const currentUser = ref<UserClaims | null>(null)

export function useCurrentUser() {
  const getCurrentUser = async () => {
    const { apiClient } = useApiClient()

    try {
      const response = await apiClient.api.userCurrentList()
      currentUser.value = MapCurrentUser(response.data.data)
    }
    catch {
      currentUser.value = null
    }
  }

  const logout = () => {
    token.value = ''
    currentUser.value = null
    router.push(routes.login())
  }

  return { currentUser, logout, getCurrentUser }
}
