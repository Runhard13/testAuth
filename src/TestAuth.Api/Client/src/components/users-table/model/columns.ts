import type { User } from '@/entities/users'
import type { ColumnDef } from '@tanstack/vue-table'
import UserPopover from '@/components/users-popover/ui/UserPopover.vue'
import { CheckCircledIcon, CrossCircledIcon } from '@radix-icons/vue'
import { h } from 'vue'

export const columns: ColumnDef<User>[] = [

  {
    accessorKey: 'username',
    header: 'Username',
    cell: ({ row }) => h(UserPopover, { user: row.original }),
  },
  {
    accessorKey: 'isActive',
    header: 'Active',
    cell: ({ row }) => {
      const icon = row.original.isActive ? h(CheckCircledIcon) : h(CrossCircledIcon)

      return h('div', { class: 'flex w-[50px] items-center' }, [
        h(icon, { class: 'mr-2 h-4 w-4 text-muted-foreground' }),
        h('span', { class: 'max-w-[70px] truncate' }, row.original.isActive ? 'Yes' : 'No'),
      ])
    },
  },

]
