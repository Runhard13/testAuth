<script setup lang="ts">
import type {
  ColumnDef,
  ColumnFiltersState,
  ExpandedState,
  SortingState,
  VisibilityState,
} from '@tanstack/vue-table'

import { valueUpdater } from '@/shared/lib/utils'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/shared/ui/card'

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/shared/ui/table'
import { CheckCircledIcon, CrossCircledIcon } from '@radix-icons/vue'
import {
  FlexRender,
  getCoreRowModel,
  getExpandedRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useVueTable,
} from '@tanstack/vue-table'
import { h, ref } from 'vue'

export interface User {
  id: string
  username: string
  isActive: boolean
}

const data: User[] = [
  {
    id: 'm5gr84i9',
    username: 'user1',
    isActive: true,
  },
  {
    id: '3u1reuv4',
    username: 'user2',
    isActive: true,
  },
]

const columns: ColumnDef<User>[] = [

  {
    accessorKey: 'username',
    header: 'Username',
    cell: ({ row }) => h('div', { class: 'capitalize' }, row.getValue('username')),
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

    enableSorting: false,
    enableHiding: false,
  },

]

const sorting = ref<SortingState>([])
const columnFilters = ref<ColumnFiltersState>([])
const columnVisibility = ref<VisibilityState>({})
const rowSelection = ref({})
const expanded = ref<ExpandedState>({})

const table = useVueTable({
  data,
  columns,
  getCoreRowModel: getCoreRowModel(),
  getPaginationRowModel: getPaginationRowModel(),
  getSortedRowModel: getSortedRowModel(),
  getFilteredRowModel: getFilteredRowModel(),
  getExpandedRowModel: getExpandedRowModel(),
  onSortingChange: updaterOrValue => valueUpdater(updaterOrValue, sorting),
  onColumnFiltersChange: updaterOrValue => valueUpdater(updaterOrValue, columnFilters),
  onColumnVisibilityChange: updaterOrValue => valueUpdater(updaterOrValue, columnVisibility),
  onRowSelectionChange: updaterOrValue => valueUpdater(updaterOrValue, rowSelection),
  onExpandedChange: updaterOrValue => valueUpdater(updaterOrValue, expanded),
  state: {
    get sorting() { return sorting.value },
    get columnFilters() { return columnFilters.value },
    get columnVisibility() { return columnVisibility.value },
    get rowSelection() { return rowSelection.value },
    get expanded() { return expanded.value },
  },
})
</script>

<template>
  <div class="min-h-screen w-full bg-muted/40">
    <main class="p-6">
      <Card class="max-w-xl">
        <CardHeader class="px-7">
          <CardTitle>Users</CardTitle>
          <CardDescription>
            Manage users.
          </CardDescription>
        </CardHeader>
        <CardContent>
          <Table>
            <TableHeader>
              <TableRow v-for="headerGroup in table.getHeaderGroups()" :key="headerGroup.id">
                <TableHead v-for="header in headerGroup.headers" :key="header.id">
                  <FlexRender v-if="!header.isPlaceholder" :render="header.column.columnDef.header" :props="header.getContext()" />
                </TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              <template v-if="table.getRowModel().rows?.length">
                <template v-for="row in table.getRowModel().rows" :key="row.id">
                  <TableRow :data-state="row.getIsSelected() && 'selected'">
                    <TableCell v-for="cell in row.getVisibleCells()" :key="cell.id">
                      <FlexRender :render="cell.column.columnDef.cell" :props="cell.getContext()" />
                    </TableCell>
                  </TableRow>
                </template>
              </template>

              <TableRow v-else>
                <TableCell
                  :colspan="columns.length"
                  class="h-24 text-center"
                >
                  No users.
                </TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </CardContent>
      </Card>
    </main>
  </div>
</template>
