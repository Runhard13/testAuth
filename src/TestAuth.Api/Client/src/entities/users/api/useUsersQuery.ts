import type { QueryClient } from '@tanstack/vue-query'
import type { User } from '../model/user'
import { useAuthentication } from '@/entities/current-user'
import { useApiClient } from '@/shared/api'
import { useMutation, useQuery } from '@tanstack/vue-query'
import { MapUsers } from '../lib/userMappings'

export const userKeys = {
  userList: {
    root: () => ['users'],
  },
}

export function useUsersQuery() {
  const { data, error } = useQuery({
    queryKey: userKeys.userList.root(),
    queryFn: async () => {
      const { apiClient } = useApiClient()
      const response = await apiClient.api.userUsersCreate()
      return MapUsers(response.data.data ?? [])
    },
  })

  return { data, error }
}

const { logout } = useAuthentication()
export function useUserUpdateQuery(queryClient: QueryClient, currentUserId: string) {
  const { isError, error, isSuccess, data, mutate } = useMutation({
    mutationFn: async (user: User) => {
      const { apiClient } = useApiClient()

      return await apiClient.api.userUpdateCreate({ userId: user.id, isActive: user.isActive })
    },

    onSuccess: (data) => {
      queryClient.invalidateQueries({ queryKey: userKeys.userList.root() })

      if (currentUserId === data.data.data?.id && !data.data.data.isActive) {
        logout()
      }
    },
  })

  return { isError, error, isSuccess, data, mutate }
}
