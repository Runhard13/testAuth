import type { ApiError } from '@/shared/api/sbis-connect/generated'
import '@tanstack/vue-query'

declare module '@tanstack/vue-query' {
  interface Register {
    defaultError: ApiError
  }
}
