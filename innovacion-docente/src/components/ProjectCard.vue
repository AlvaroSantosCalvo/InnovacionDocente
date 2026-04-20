<script setup lang="ts">
import { ref } from 'vue'
import type { Proyect } from '../stores/proyectoStore'
import proyectsData from '../data/proyects.json'

const proyects = ref<Proyect[]>(proyectsData)
</script>

<template>
<div class="proyect-slider">
          <article v-for="proyect in proyects" :key="proyect.id" class="proyect-card">
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
        </div>
</template>

<style scoped>
.proyect-slider {
  display: grid;
  gap: 1rem;
  grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
  margin-top: 1rem;
}

.proyect-card {
  padding: 1rem;
  border: 1px solid #ddd;
  border-radius: 1rem;
  background: #fff;
  box-shadow: 0 3px 10px rgba(0, 0, 0, 0.06);
  transition: transform 0.3s, box-shadow 0.3s;
}

.proyect-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
}

.proyect-image {
  width: auto;
  height: 150px;
  border-radius: 0.8rem;
  overflow: hidden;
  background: #f4f4f4;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 1rem;
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

.proyect-title {
  margin: 0 0 0.5rem;
  font-size: 1.1rem;
  font-weight: 600;
  color: #333;
}

.proyect-description {
  margin: 0;
  color: #444;
  font-size: 0.95rem;
  line-height: 1.5;
}
</style>
