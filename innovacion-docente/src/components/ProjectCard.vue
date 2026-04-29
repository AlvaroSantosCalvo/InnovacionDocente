<script setup lang="ts">
// Imports
import { ref } from 'vue'
import SliderComponent from './SliderComponent.vue'
import type { Proyect } from '../stores/proyectoStore'
import proyectsData from '../data/proyects.json'

// State
const proyects = ref<Proyect[]>(proyectsData)
const selectedProject = ref<Proyect | null>(null)

// Methods
const openProject = (project: Proyect) => {
  selectedProject.value = project
}

const closeProject = () => {
  selectedProject.value = null
}
</script>

<template>
  <div class="proyect-slider">
    <!-- Slider with project cards -->
    <SliderComponent>
      <article v-for="proyect in proyects" :key="proyect.id" class="card proyect-card" @click="openProject(proyect)"
        role="button" tabindex="0" @keydown.enter="openProject(proyect)">
        <div class="proyect-image" v-if="proyect.imgUrl">
          <img :src="proyect.imgUrl" :alt="proyect.title" />
        </div>

        <div class="proyect-image placeholder" v-else>
          Sin imagen disponible
        </div>

        <div class="proyect-content">
          <h4 class="proyect-title">{{ proyect.title }}</h4>
          <p class="proyect-description">{{ proyect.description }}</p>
        </div>
      </article>
    </SliderComponent>

    <!-- Modal with full project details -->
    <div v-if="selectedProject" class="modal-overlay" @click.self="closeProject">
      <div class="modal-card">
        <button class="modal-close" @click="closeProject" aria-label="Cerrar ventana">
          ×
        </button>

        <div class="modal-image" v-if="selectedProject.imgUrl">
          <img :src="selectedProject.imgUrl" :alt="selectedProject.title" />
        </div>

        <div class="modal-content">
          <h3>{{ selectedProject.title }}</h3>
          <p class="modal-description">{{ selectedProject.description }}</p>

          <div class="modal-meta">
            <p><strong>Autor:</strong> {{ selectedProject.autor }}</p>
            <p><strong>Fecha:</strong> {{ selectedProject.fecha }}</p>
            <p><strong>Línea:</strong> {{ selectedProject.linea }}</p>
            <p><strong>Centro:</strong> {{ selectedProject.centro }}</p>
          </div>

          <button class="download-button" type="button">
            Descargar proyecto
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Slider wrapper */
.proyect-slider {
  width: 100%;
  margin-top: 1rem;
}

/* Card styles */
.proyect-card {
  padding: 0.9rem;
  border: 1px solid #ddd;
  border-radius: 1rem;
  background: #fff;
  box-shadow: 0 3px 10px rgba(0, 0, 0, 0.06);
  transition: transform 0.3s, box-shadow 0.3s;
  width: 300px;
  height: 360px;
  flex: 0 0 auto;
  scroll-snap-align: start;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  cursor: pointer;
}

.proyect-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
}

.proyect-card:focus {
  outline: 2px solid var(--nebrija-color);
  outline-offset: 4px;
}

/* Image block */
.proyect-image {
  width: auto;
  height: 130px;
  border-radius: 0.8rem;
  overflow: hidden;
  background: #f4f4f4;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 0.75rem;
  color: #666;
  font-size: 0.95rem;
  text-align: center;
  padding: 0.75rem;
}

.proyect-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

/* Card text */
.proyect-content {
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
  flex: 1;
}

.proyect-title {
  margin: 0;
  font-size: 1.05rem;
  font-weight: 600;
  color: #333;
}

.proyect-description {
  margin: 0;
  color: #444;
  font-size: 0.92rem;
  line-height: 1.4;
  overflow: hidden;
  text-overflow: ellipsis; /*puntos suspensivos si pasa de 6 líneas*/
  display: -webkit-box;
  line-clamp: 6;
  -webkit-line-clamp: 6;
  -webkit-box-orient: vertical;
}

/* Modal styles */
.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.55);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
  padding: 1rem;
}

.modal-card {
  width: min(700px, 100%);
  max-height: min(90vh, 800px);
  background: #fff;
  border-radius: 1.25rem;
  overflow: hidden;
  box-shadow: 0 20px 60px rgba(0, 0, 0, 0.25);
  position: relative;
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1.5rem;
}

.modal-close {
  position: absolute;
  top: 1rem;
  right: 1rem;
  background: transparent;
  border: none;
  font-size: 1.75rem;
  cursor: pointer;
  color: #333;
}

.modal-image {
  min-height: 240px;
  background: #f7f7f7;
  display: flex;
  align-items: center;
  justify-content: center;
}

.modal-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.modal-content {
  padding: 2rem 2rem 1.5rem;
  overflow-y: auto;
}

.modal-content h3 {
  margin: 0 0 1rem;
  font-size: 1.5rem;
  color: #222;
}

.modal-description {
  margin: 0 0 1.25rem;
  color: #444;
  line-height: 1.6;
}

.modal-meta p {
  margin: 0 0 0.75rem;
  color: #555;
  font-size: 0.95rem;
}

.download-button {
  margin-top: 1rem;
  background: var(--nebrija-color);
  color: #fff;
  border: none;
  border-radius: 999px;
  padding: 0.9rem 1.4rem;
  cursor: pointer;
  font-weight: 600;
  transition: background-color 0.25s ease;
}

.download-button:hover {
  background: #a00038;
}

/* Responsive */
@media (max-width: 900px) {
  .proyect-card {
    width: 260px;
    height: 340px;
  }

  .modal-card {
    grid-template-columns: 1fr;
  }
}

@media (max-width: 700px) {
  .proyect-card {
    width: 220px;
    height: 320px;
  }
}

@media (max-width: 520px) {
  .proyect-card {
    width: min(100%, 220px);
    height: auto;
  }
}
</style>
