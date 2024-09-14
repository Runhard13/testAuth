import type { ApiResponseErrors } from '@/shared/api/test-auth-api/generated/TestAuthApi'
import '@tanstack/vue-query'

declare module '@tanstack/vue-query' {
  interface Register {
    defaultError: ApiResponseErrors
  }
}
