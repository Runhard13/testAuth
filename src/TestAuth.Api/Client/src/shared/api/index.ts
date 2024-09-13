import { TestAuthApi } from './test-auth-api/generated'

export interface ApiClient {
  testAuthApi: TestAuthApi
}

const testAuthApi = new TestAuthApi({
  BASE: import.meta.env.VITE_BASE_URL,
})

const apiClient: ApiClient = {
  testAuthApi,
}

export { apiClient }
