<script setup lang="ts">
import { columns } from '@/components/users-table/model/columns'
import UsersTable from '@/components/users-table/ui/UsersTable.vue'
import { useUsersQuery } from '@/entities/users/api/useUsersQuery'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/shared/ui/card'

const { data } = useUsersQuery()
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
          <UsersTable v-if="data" :data="data" :columns="columns" />
        </CardContent>
      </Card>
    </main>
  </div>
</template>
