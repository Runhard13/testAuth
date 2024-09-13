import type { UserClaims } from '../model/user-claims'

export function parseJwt(token: string): UserClaims {
  const [, base64Url] = token.split('.')
  const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/')
  const jsonPayload = decodeURIComponent(
    window
      .atob(base64)
      .split('')
      .map((c) => {
        return `%${(`00${c.charCodeAt(0).toString(16)}`).slice(-2)}`
      })
      .join(''),
  )

  return JSON.parse(jsonPayload)
}
