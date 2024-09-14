<script setup lang="ts">
import type { User } from '@/entities/users'
import { Button } from '@/shared/ui/button'

import { Checkbox } from '@/shared/ui/checkbox'
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/shared/ui/popover'

import { SaveIcon } from 'lucide-vue-next'
import { ref } from 'vue'

interface UserPopoverProps {
  user: User
}

const props = defineProps<UserPopoverProps>()
const isActive = ref(props.user.isActive)
</script>

<template>
  <Popover @update:open="isActive = props.user.isActive">
    <PopoverTrigger as-child>
      <span class="text-blue-600 dark:text-blue-500 hover:underline cursor-pointer truncate">
        {{ user.username }}
      </span>
    </PopoverTrigger>
    <PopoverContent>
      <div class="grid gap-4">
        <div class="space-y-2">
          <h4 class="font-medium leading-none">
            Редактировать пользователя
          </h4>
        </div>
        <div class="flex items-center space-x-2">
          <span class="w-20">
            Username:
          </span>
          <span>
            {{ user.username }}
          </span>
        </div>

        <div class="flex items-center space-x-2">
          <span class="w-20">
            Active:
          </span>
          <Checkbox id="isActive" v-model:checked="isActive" />
        </div>
        <Button variant="outline">
          <SaveIcon class="w-4 h-4 mr-2" /> Save
        </Button>
      </div>
    </PopoverContent>
  </Popover>
</template>
