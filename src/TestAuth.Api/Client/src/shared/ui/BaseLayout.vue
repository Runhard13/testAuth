<script setup lang="ts">
import { RouterView } from 'vue-router'
</script>

<template>
  <div class="flex min-h-screen w-full flex-col bg-muted/40">
    <div class="flex flex-col sm:gap-4 sm:py-4">
      <main class="gap-4 p-4 sm:px-6 sm:py-0 md:gap-8 overflow-hidden">
        <RouterView />
      </main>
    </div>
  </div>
</template>
