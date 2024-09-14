import { z } from 'zod'

export const currentUserSchema = z.object({
  userId: z.string(),
  username: z.string(),
})

export type UserClaims = z.infer<typeof currentUserSchema>
