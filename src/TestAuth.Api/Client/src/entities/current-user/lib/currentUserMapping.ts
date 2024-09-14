import type { GetCurrentUserResponse } from '@/shared/api/test-auth-api/generated/TestAuthApi'
import type { UserClaims } from '../model/user-claims'

export function MapCurrentUser(user?: GetCurrentUserResponse) {
  const u: UserClaims = {
    userId: user?.id ?? '',
    username: user?.username ?? '',
  }

  return u
}
