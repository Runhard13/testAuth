import { z } from 'zod'

export const usersSchema = z.object({
  id: z.string(),
  username: z.string(),
  isActive: z.boolean(),
})

export type User = z.infer<typeof usersSchema>
