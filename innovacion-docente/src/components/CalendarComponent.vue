<script setup lang="ts">
import { ref } from 'vue'
import rawEvents from '@/data/calendarData.json'

const value = ref(new Date())

const events = ref(
  rawEvents.map((e) => ({
    name: e.name,
    start: e.start,
    end: e.end,
    color: e.color,
    allDay: e.allDay,
  })),
)
</script>

<template>
  <v-calendar
    v-model="value"
    :events="events"
    type="month"
  />
</template>
