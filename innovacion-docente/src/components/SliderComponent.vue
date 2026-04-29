<script setup lang="ts">
// Vue imports
import { ref, onMounted, onBeforeUnmount, watch, useSlots } from 'vue'

// Refs
const sliderRef = ref<HTMLElement | null>(null)
const canScrollLeft = ref(false)
const canScrollRight = ref(false)
const slots = useSlots()

// Actualiza el estado de los botones según la posición del slider
const updateButtons = () => {
  const slider = sliderRef.value
  if (!slider) return

  const { scrollLeft, scrollWidth, clientWidth } = slider
  canScrollLeft.value = scrollLeft > 0
  canScrollRight.value = scrollLeft + clientWidth < scrollWidth - 1
}

// Navega el slider hacia la izquierda o la derecha
const handleScroll = (direction: 'left' | 'right') => {
  const slider = sliderRef.value
  if (!slider) return

  const width = slider.clientWidth
  const scrollAmount = Math.round(width * 0.8)
  const nextPosition =
    direction === 'left'
      ? slider.scrollLeft - scrollAmount
      : slider.scrollLeft + scrollAmount

  slider.scrollTo({
    left: nextPosition,
    behavior: 'smooth',
  })
}

// Eventos del ciclo de vida del componente
onMounted(() => {
  updateButtons()
  const slider = sliderRef.value
  if (!slider) return

  slider.addEventListener('scroll', updateButtons)
  window.addEventListener('resize', updateButtons)
})

onBeforeUnmount(() => {
  const slider = sliderRef.value
  if (slider) {
    slider.removeEventListener('scroll', updateButtons)
  }
  window.removeEventListener('resize', updateButtons)
})

// Refresca los botones cuando cambia el contenido del slot
watch(
  () => slots.default?.(),
  () => {
    updateButtons()
  },
  { flush: 'post' }
)
</script>

<template>
  <div class="slider-component">
    <!-- Botón izquierda -->
    <button class="carousel-btn carousel-btn-left" @click="handleScroll('left')"
      aria-label="Desplazar slider a la izquierda" :disabled="!canScrollLeft">
      ‹
    </button>

    <!-- Contenedor principal del slider -->
    <div ref="sliderRef" class="carousel">
      <slot />
    </div>

    <!-- Botón derecha -->
    <button class="carousel-btn carousel-btn-right" @click="handleScroll('right')"
      aria-label="Desplazar slider a la derecha" :disabled="!canScrollRight">
      ›
    </button>
  </div>
</template>

<style scoped>
/* Contenedor del slider */
.slider-component {
  display: flex;
  align-items: center;
  gap: 1rem;
  width: 100%;
}

/* Área de desplazamiento */
.carousel {
  width: 100%;
  overflow-x: auto;
  display: flex;
  gap: 1em;
  scroll-behavior: smooth;
  scroll-snap-type: x mandatory;
  -webkit-overflow-scrolling: touch;
}

.carousel::-webkit-scrollbar {
  display: none;
}

/* Botones del slider */
.carousel-btn {
  background-color: var(--nebrija-color);
  color: white;
  border: none;
  border-radius: 50%;
  width: 40px;
  height: 40px;
  font-size: 1.25rem;
  cursor: pointer;
  z-index: 10;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: all 0.3s ease;
  box-shadow: 0 2px 8px rgba(194, 0, 47, 0.3);
  flex-shrink: 0;
}

.carousel-btn:hover {
  background-color: #a00038;
  transform: scale(1.05);
}

.carousel-btn:active {
  transform: scale(0.95);
}

.carousel-btn:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.carousel-btn-left {
  order: -1;
}

.carousel-btn-right {
  order: 1;
}

/* Estilos opcionales para las cards dentro del slider */
.card {
  scroll-snap-align: start;
  flex: 0 0 20em;
  aspect-ratio: 5 / 3;
  background-color: var(--rojo-nebrija);
  padding: 1em;
  border-radius: 1em;
  text-align: center;
  align-content: center;
}

@media (max-width: 500px) {
  .card {
    flex: 0 0 100%;
  }
}
</style>
