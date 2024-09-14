<script setup lang="ts">
import router from '@/app/router'
import { routes } from '@/app/router/routes'
import { useAuthentication, useCurrentUser } from '@/entities/current-user'
import { Button } from '@/shared/ui/button'
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/shared/ui/card'
import { Input } from '@/shared/ui/input'
import { Label } from '@/shared/ui/label'
import { ReloadIcon } from '@radix-icons/vue'
import { ref } from 'vue'

const username = ref('')
const password = ref('')
const isError = ref(false)
const description = ref('Enter your username below to login to your account.')

const { authenticate, isLoading } = useAuthentication()
const { currentUser, getCurrentUser } = useCurrentUser()

if (currentUser.value) {
  router.push(routes.welcome())
}

async function login() {
  isError.value = false

  await authenticate(username.value, password.value)
  await getCurrentUser()

  if (currentUser.value) {
    router.push(routes.welcome())
  }
  else {
    isError.value = true
    description.value = 'We could not log you in. Please check your username/password and try again'
    password.value = ''
  }
}
</script>

<template>
  <div class="h-screen w-full flex items-center justify-center">
    <Card class="w-full max-w-sm">
      <CardHeader>
        <CardTitle class="text-2xl">
          Login
        </CardTitle>
        <CardDescription :class="isError ? 'text-red-500' : ''">
          {{ description }}
        </CardDescription>
      </CardHeader>
      <CardContent class="grid gap-4">
        <div class="grid gap-2">
          <Label for="username">Username</Label>
          <Input id="username" v-model="username" placeholder="username" required />
        </div>
        <div class="grid gap-2">
          <Label for="password">Password</Label>
          <Input id="password" v-model="password" type="password" autocomplete="off" required />
        </div>
      </CardContent>
      <CardFooter>
        <Button v-if="!isLoading" class="w-full" @click="login()">
          Submit
        </Button>
        <Button v-else disabled class="w-full">
          <ReloadIcon class="w-4 h-4 mr-2 animate-spin" />
          Please wait
        </Button>
      </CardFooter>
    </Card>
  </div>
</template>
