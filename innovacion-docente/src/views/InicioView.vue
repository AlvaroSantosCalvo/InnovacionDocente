<script setup lang="ts">
import { ref } from 'vue'
import type { Proyect } from '../stores/proyectoStore'
import proyectsData from '../data/proyects.json'

const proyects = ref<Proyect[]>(proyectsData)
</script>

<template>
  <main>
    <div class="banner">
      <h1 class="page-title">Innovación Docente</h1>
      <img src="../assets/banner.jpg" alt="fondo">
    </div>
    <section class="presentation">
      <h2 class="title">Presentación</h2>
      <div class="presentation-container">
        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Porro voluptates dignissimos, provident nisi qui
          ipsam aspernatur maiores earum doloribus, repellat id corrupti recusandae et culpa necessitatibus officiis
          sit, laudantium quisquam!</p>
      </div>
    </section>
    <section class="sections">
      <section class="proyects-section">
        <h3 class="sub-title">Proyectos</h3>
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
        <button class="more-btn">Más proyectos -></button>
      </section>
      <section class="calls-section">
        <h3 class="sub-title">Convocatorias</h3>
        <div class="calendar"></div>
      </section>
      <section class="events-section">
        <h3 class="sub-title">Eventos</h3>
        <div class="event-list"></div>
        <button class="more-btn">Más eventos -></button>
      </section>
    </section>
    <section class="contact-form">
      <h2 class="title">Contacta con nosotros</h2>
      <form action="">
        <p>Envíanos un mensaje y nos pondremos en contacto contigo lo antes posible.</p>
        <input type="text" placeholder="Nombre" required>
        <input type="email" placeholder="Correo electrónico" required>
        <textarea name="message" id="" placeholder="Tu mensaje..." required></textarea>
        <label for="terms">
          <input type="checkbox" id="terms" required>
          Acepto los términos y condiciones
        </label>
        <button type="submit">Enviar</button>
      </form>
    </section>
  </main>
</template>

<style scoped>
/* Generales */
.title {
  font-size: 2rem;
  font-weight: bold;
  color: #333;
  margin-bottom: 1rem;
}

.sub-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #555;
  margin-bottom: 1rem;
}

.more-btn {
  background-color: var(--nebrija-color);
  color: white;
  border: none;
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s;
}

.more-btn:hover {
  background-color: var(--secondary-color);
}

.sections {
  display: flex;
  flex-direction: column;
  gap: 2rem;
  padding: 2rem 0;
}

/* Banner */
.banner {
  position: relative;
  text-align: center;
  color: white;
  padding: 4rem 2rem;
  background: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url('../assets/banner.jpg') no-repeat center center;
  background-size: cover;
}

.page-title {
  font-size: 3rem;
  font-weight: bold;
  margin: 0;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);
  background-color: var(--nebrija-color);
}

.banner img {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
  z-index: -1;
}

/* Sección presentación */
.presentation {
  padding: 2rem;
  background-color: #f8f9fa;
  text-align: center;
}

.presentation-container {
  max-width: 800px;
  margin: 0 auto;
  font-size: 1.1rem;
  line-height: 1.6;
  color: #666;
}

/* Sección Proyectos */
.proyects-section {
  padding: 2rem;
}

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

/* Sección Convocatorias */
.calls-section {
  padding: 2rem;
  background-color: #e9ecef;
}

.calendar {
  /* Placeholder para calendario */
  height: 200px;
  background-color: #fff;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #666;
}

/* Sección Eventos */
.events-section {
  padding: 2rem;
}

.event-list {
  /* Placeholder para lista de eventos */
  height: 200px;
  background-color: #fff;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #666;
}

/* Sección Contacto */
.contact-form {
  padding: 2rem;
  background-color: #f8f9fa;
}

.contact-form form {
  max-width: 600px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.contact-form input,
.contact-form textarea {
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  font-size: 1rem;
}

.contact-form button {
  align-self: flex-start;
  background-color: var(--nebrija-color);
  color: white;
  border: none;
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s;
}

.contact-form button:hover {
  background-color: var(--secondary-color);
}

.contact-form label {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  font-size: 0.9rem;
  color: #666;
}
</style>
