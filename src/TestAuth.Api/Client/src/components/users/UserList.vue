<script setup lang="ts">
import type { SbisDocumentAttachment } from '@/entities/document-attachment/attachment'
import { downloadDocument } from '@/components/attachment-list/api/document-download'

import { Button } from '@/shared/ui/button'
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/shared/ui/dialog'

import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from '@/shared/ui/popover'
import { Separator } from '@/shared/ui/separator'
import { ArchiveIcon, FileTextIcon } from '@radix-icons/vue'

interface AttachmentListPopover {
  documentId: string
  label: string
  attachments: SbisDocumentAttachment[]
}

defineProps<AttachmentListPopover>()
</script>

<template>
  <Popover>
    <PopoverTrigger as-child>
      <span class="text-blue-600 dark:text-blue-500 hover:underline cursor-pointer truncate">
        {{ label }}
      </span>
    </PopoverTrigger>
    <PopoverContent class="w-[500px]">
      <div class="grid gap-4">
        <div class="space-y-2">
          <h4 class="font-medium leading-none">
            Вложения
          </h4>
        </div>
        <div v-for="attachment in attachments" :key="attachment.id" class="grid gap-2">
          <Dialog>
            <DialogTrigger as-child>
              <span class="font-medium text-blue-600 dark:text-blue-500 hover:underline cursor-pointer">
                {{ attachment.name }}
              </span>
            </DialogTrigger>
            <DialogContent class="sm:max-w-[425px]">
              <DialogHeader>
                <DialogTitle>Просмотр документа</DialogTitle>
                <DialogDescription>
                  Функция "Просмотр вложения" в разработке. Сейчас вы можете посмотреть все вложения сразу или скачать их в PDF
                </DialogDescription>
                <DialogFooter>
                  <div class="flex gap-2">
                    <Button variant="outline" @click="downloadDocument(documentId, 'pdf', true)">
                      <FileTextIcon class="w-4 h-4 mr-2" /> Посмотреть вложения
                    </Button>
                    <Button variant="outline" @click="downloadDocument(documentId, 'pdf', false)">
                      <ArchiveIcon class="w-4 h-4 mr-2" /> Скачать PDF
                    </Button>
                  </div>
                </DialogFooter>
              </DialogHeader>
            </DialogContent>
          </Dialog>
        </div>
        <Separator class="my-4" />
        <div class="flex gap-2">
          <Button variant="outline" @click="downloadDocument(documentId, 'pdf', true)">
            <FileTextIcon class="w-4 h-4 mr-2" /> Посмотреть вложения
          </Button>
          <Button variant="outline" @click="downloadDocument(documentId, 'pdf', false)">
            <ArchiveIcon class="w-4 h-4 mr-2" /> Скачать PDF
          </Button>
        </div>
      </div>
    </PopoverContent>
  </Popover>
</template>
