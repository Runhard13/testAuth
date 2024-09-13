<script setup lang="ts">
import { ref } from 'vue'

const username = ref<string>('Lol')
</script>

<template>
  <div class="min-h-screen w-full bg-muted/40">
    <main class="p-6">
      <h2 class="text-2xl font-bold tracking-tight">
        Welcome, {{ username }}! This page is for authenticated users only.
      </h2>
    </main>
  </div>
</template>
