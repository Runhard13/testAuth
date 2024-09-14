<script setup lang="ts">
import { useCurrentUser } from '@/entities/current-user'

const { data } = useCurrentUser()
</script>

<template>
  <div class="min-h-screen w-full bg-muted/40">
    <main class="p-6">
      <h2 v-if="data?.username" class="text-2xl font-bold tracking-tight">
        Welcome, {{ data.username }}! This page is for authenticated users only.
      </h2>
    </main>
  </div>
</template>
