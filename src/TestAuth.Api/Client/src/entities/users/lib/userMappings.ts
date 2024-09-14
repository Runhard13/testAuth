import type { UserModel } from '@/shared/api/test-auth-api/generated/TestAuthApi'
import type { User } from '../model/user'

export function MapUsers(users: UserModel[]) {
  const mappedUsers: User[] = users.map((u) => {
    return {
      id: u.id ?? '',
      username: u.username ?? '',
      isActive: u.isActive ?? false,
    }
  })

  return mappedUsers
}
