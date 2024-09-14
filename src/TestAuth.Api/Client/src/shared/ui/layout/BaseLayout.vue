<script setup lang="ts">
import { useCurrentUser } from '@/entities/current-user'
import { RouterView } from 'vue-router'

const { getCurrentUser } = useCurrentUser()
await getCurrentUser()
</script>

<template>
  <RouterView />
</template>
