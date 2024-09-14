<script setup lang="ts">
import { useCurrentUser } from '@/entities/current-user'
import { RouterView } from 'vue-router'

const { currentUser, getCurrentUser } = useCurrentUser()

if (!currentUser.value) {
  await getCurrentUser()
}
</script>

<template>
  <RouterView />
</template>
