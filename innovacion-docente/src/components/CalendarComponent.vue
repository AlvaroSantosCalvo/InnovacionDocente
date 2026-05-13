<script setup lang="ts">
import { ref, computed, watch, onMounted, onUnmounted } from 'vue'
import rawEvents from '@/data/calendarData.json'

const value = ref(new Date())
const viewDate = ref(new Date())
const menuOpen = ref(false)
const selectedEvent = ref<any>(null)
const activator = ref<HTMLElement | undefined>(undefined)

const handleScroll = () => {
  if (menuOpen.value) menuOpen.value = false
}

onMounted(() => {
  window.addEventListener('scroll', handleScroll, { passive: true })
})

onUnmounted(() => {
  window.removeEventListener('scroll', handleScroll)
})

const months = [
  'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
  'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
]

const years = Array.from({ length: 11 }, (_, i) => new Date().getFullYear() - 5 + i)

const events = ref(
  rawEvents.map((e) => ({
    name: e.name,
    title: e.name,
    start: new Date(e.start),
    end: new Date(e.end),
    color: e.color,
    allDay: e.allDay,
    description: e.description,
    place: e.place,
  })),
)

const calendarStart = computed(() => {
  return viewDate.value.toISOString().split('T')[0]
})

const title = computed(() => {
  return viewDate.value.toLocaleDateString('es-ES', { month: 'long', year: 'numeric' }).toUpperCase()
})

const selectedMonth = computed({
  get: () => viewDate.value.getMonth(),
  set: (val) => {
    const newDate = new Date(viewDate.value)
    newDate.setMonth(val)
    viewDate.value = newDate
    value.value = new Date(newDate)
  }
})

const selectedYear = computed({
  get: () => viewDate.value.getFullYear(),
  set: (val) => {
    const newDate = new Date(viewDate.value)
    newDate.setFullYear(val)
    viewDate.value = newDate
    value.value = new Date(newDate)
  }
})

watch(value, (newVal) => {
  if (!newVal) return
  if (newVal.getMonth() !== viewDate.value.getMonth() || newVal.getFullYear() !== viewDate.value.getFullYear()) {
    viewDate.value = new Date(newVal)
  }
})

function prev() {
  const date = new Date(viewDate.value)
  date.setDate(1)
  date.setMonth(date.getMonth() - 1)
  viewDate.value = date
  value.value = new Date(date)
}

function next() {
  const date = new Date(viewDate.value)
  date.setDate(1)
  date.setMonth(date.getMonth() + 1)
  viewDate.value = date
  value.value = new Date(date)
}

function showEvent(nativeEvent: any, { event }: any) {
  selectedEvent.value = event
  activator.value = nativeEvent.target as HTMLElement
  menuOpen.value = true
}
</script>

<template>
  <div class="calendar-container bg-white rounded-xl elevation-2 pa-4">
    <div class="d-flex align-center justify-center mb-12 position-relative">
      <!-- Selectores a la izquierda -->
      <div class="selectors-wrapper d-inline-flex rounded-pill border shadow-sm bg-grey-lighten-5">
        <v-select v-model="selectedMonth" :items="months.map((m, i) => ({ title: m, value: i }))" density="compact"
          variant="plain" hide-details class="month-selector nav-text" :menu-props="{
            scrollStrategy: 'none',
            persistent: false,
            location: 'bottom start',
            offset: [0, 0],
            width: 160,
            contentClass: 'selector-menu-content'
          }"></v-select>
        <v-divider vertical></v-divider>
        <v-select v-model="selectedYear" :items="years" density="compact" variant="plain" hide-details
          class="year-selector nav-text" :menu-props="{
            scrollStrategy: 'none',
            persistent: false,
            location: 'bottom start',
            offset: [0, 0],
            width: 110,
            contentClass: 'selector-menu-content'
          }"></v-select>
      </div>

      <h2 class="text-h2 font-weight-black text-grey-darken-4">
        {{ title }}
      </h2>

      <!-- Botones a la derecha -->
      <div class="nav-wrapper">
        <div class="d-inline-flex rounded-pill border shadow-sm bg-grey-lighten-5 overflow-hidden"
          style="height: 48px;">
          <v-btn icon variant="text" height="100%" rounded="0" @click="prev">
            <v-icon size="32" class="nav-icon">mdi-chevron-left</v-icon>
          </v-btn>
          <v-btn variant="text" class="px-6 font-weight-bold nav-text" height="100%" rounded="0"
            @click="value = new Date(); viewDate = new Date()">
            Hoy
          </v-btn>
          <v-btn icon variant="text" height="100%" rounded="0" @click="next">
            <v-icon size="32" class="nav-icon">mdi-chevron-right</v-icon>
          </v-btn>
        </div>
      </div>
    </div>

    <v-calendar v-model="value" :start="calendarStart" :events="events" type="month" @click:event="showEvent" />
  </div>

  <v-menu v-model="menuOpen" :activator="activator" location="bottom center" offset="10" :close-on-content-click="false"
    scroll-strategy="none" :persistent="false">
    <v-card v-if="selectedEvent" min-width="350" class="elevation-24 rounded-xl overflow-hidden">
      <v-toolbar :color="selectedEvent.color" flat>
        <v-toolbar-title class="text-h5 font-weight-bold">
          {{ selectedEvent.title }}
        </v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn icon="mdi-close" variant="text" @click="menuOpen = false"></v-btn>
      </v-toolbar>

      <v-card-text class="pa-6">
        <div class="d-flex align-center mb-6">
          <v-avatar :color="selectedEvent.color + '-lighten-4'" size="48" class="mr-4">
            <v-icon :color="selectedEvent.color" size="28">mdi-calendar-clock</v-icon>
          </v-avatar>
          <div>
            <div class="text-overline font-weight-black text-grey-darken-1 mb-n1">FECHA DEL EVENTO</div>
            <div class="text-h6 text-grey-darken-3">
              {{ selectedEvent.start.toLocaleDateString('es-ES', { day: 'numeric', month: 'long' }) }}
              <span v-if="selectedEvent.start.getTime() !== selectedEvent.end.getTime()">
                - {{ selectedEvent.end.toLocaleDateString('es-ES', { day: 'numeric', month: 'long' }) }}
              </span>
            </div>
          </div>
        </div>

        <v-divider class="mb-6"></v-divider>

        <div class="text-overline font-weight-black text-grey-darken-1 mb-2">DESCRIPCIÓN</div>
        <p class="text-body-1 text-grey-darken-3 leading-relaxed">
          {{ selectedEvent.description }}
        </p>

        <v-divider class="mb-6"></v-divider>

        <div class="text-overline font-weight-black text-grey-darken-1 mb-2">LUGAR</div>
        <p class="text-body-1 text-grey-darken-3 leading-relaxed">
          {{ selectedEvent.place }}
        </p>
      </v-card-text>

      <v-card-actions class="pa-4 bg-grey-lighten-4">
        <v-spacer></v-spacer>
        <v-btn :color="selectedEvent.color" variant="elevated" rounded="pill" class="px-6 font-weight-bold"
          @click="menuOpen = false">
          Entendido
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-menu>
</template>

<style scoped>
.selectors-wrapper {
  position: absolute;
  left: 0;
  z-index: 100;
  height: 48px;
  /* Altura fija para coincidir con los botones */
  align-items: center;
}

.month-selector {
  width: 160px;
}

.year-selector {
  width: 110px;
}

/* Estilo para que el menú parezca una extensión del botón */
:deep(.selector-menu-content) {
  border-radius: 0 0 16px 16px !important;
  border: 1px solid #e0e0e0 !important;
  box-shadow: 0 4px 6px -1px rgb(0 0 0 / 0.1) !important;
  margin-top: 1px !important;
}

:deep(.v-select .v-field__input),
:deep(.v-select .v-field__append-inner) {
  color: #000000 !important;
  opacity: 1 !important;
  font-weight: bold;
  justify-content: center !important;
  text-align: center !important;
  height: 48px;
  align-items: center;
}

:deep(.v-select .v-field__input) {
  padding-left: 32px !important;
}

.nav-wrapper {
  position: absolute;
  right: 0;
  z-index: 100;
}

.nav-icon {
  color: #000000 !important;
  opacity: 1 !important;
}

.nav-text {
  color: #000000 !important;
  opacity: 1 !important;
}

.calendar-container {
  width: 100%;
}

:deep(.v-overlay) {
  z-index: 9999 !important;
}
</style>
