<script setup lang="ts">
import { useCurrentUser } from '@/entities/current-user'
import { Button } from '@/shared/ui/button'

const { currentUser, logout } = useCurrentUser()
</script>

<template>
  <div class="min-h-screen w-full bg-muted/40">
    <main class="p-6">
      <h2 v-if="currentUser?.username" class="text-2xl font-bold tracking-tight mb-6">
        Welcome, {{ currentUser.username }}! This page is for authenticated users only.
      </h2>

      <Button @click="logout()">
        Logout
      </Button>
    </main>
  </div>
</template>
