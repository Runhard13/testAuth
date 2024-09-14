import { useApiClient } from '@/shared/api'
import { useQuery } from '@tanstack/vue-query'
import { useStorage } from '@vueuse/core'
import { ref } from 'vue'
import { MapCurrentUser } from '../lib/currentUserMapping'

export function useAuthentication() {
  const isLoading = ref(false)
  const token = useStorage('token', '', localStorage)
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

  return { authenticate, token, isLoading }
}

export const currentUserKey = ['currentUser']

export function useCurrentUser() {
  const { data, isError } = useQuery({
    queryKey: currentUserKey,
    queryFn: async () => {
      const { apiClient } = useApiClient()
      const response = await apiClient.api.userCurrentList()
      return response ? MapCurrentUser(response.data.data) : null
    },

  })

  return { data, isError }
}
