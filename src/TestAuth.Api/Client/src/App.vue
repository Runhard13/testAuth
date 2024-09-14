<script setup lang="ts">
import BaseLayout from '@/shared/ui/layout/BaseLayout.vue'
import Toaster from '@/shared/ui/toast/Toaster.vue'
import { useColorMode } from '@vueuse/core'

const mode = useColorMode()
mode.value = 'dark'
</script>

<template>
  <Suspense>
    <BaseLayout />
  </Suspense>
  <Toaster />
</template>
