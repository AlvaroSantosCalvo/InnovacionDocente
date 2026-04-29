import { defineStore } from 'pinia'
import { ref, computed } from 'vue'

export interface Proyect {
  id: number
  title: string
  description: string
  imgUrl: string
  autor: string
  fecha: string
  linea: string
  centro: string
}

export const useProyectoStore = defineStore('proyecto', () => {
  // State
  const proyectList = ref<Proyect[]>([])

  // Getters
  const getTotalProyects = computed(() => proyectList.value.length)

  //Actions
  function setNewProyect(newProyect: Proyect) {
    proyectList.value.push(newProyect)
  }

  return { proyectList, getTotalProyects, setNewProyect }
})
