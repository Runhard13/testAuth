import { useStorage } from '@vueuse/core'
import { Api, ContentType } from './test-auth-api/generated/TestAuthApi'

const token = useStorage('token', '', localStorage)
const apiClient = new Api<string>({
  baseUrl: import.meta.env.VITE_BASE_URL,
  baseApiParams: {
    headers: {
      'Content-Type': ContentType.Json,
    },
    format: 'json',
    credentials: 'include',
  },
  securityWorker: async () => {
    return { headers: { Authorization: `Bearer ${token.value}` } }
  },

})

export function useApiClient() {
  apiClient.setSecurityData(token.value)
  return { apiClient }
}
