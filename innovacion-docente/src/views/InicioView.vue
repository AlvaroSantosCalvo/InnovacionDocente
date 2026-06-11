<script setup lang="ts">
import ProjectCard from '@/components/ProjectCard.vue';
import CalendarComponent from '@/components/CalendarComponent.vue';
import SpeakerCard from '@/components/SpeakerCard.vue';
import speakers from '@/data/speakers.json'
</script>

<template>
  <main>
    <div class="banner">
      <h1 class="page-title">Innovación Docente</h1>
      <img src="../assets/banner-home.jpg" alt="fondo">
    </div>
    <section class="presentation">
      <h2 class="title">Presentación</h2>
      <div class="presentation-container">
        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Poro voluptates dignissimos, provident nisi qui
          ipsam aspernatur maiores earum doloribus, repellat id corrupti recusandae et culpa necessitatibus officiis
          sit, laudantium quisquam!</p>
      </div>
    </section>
    <section class="sections">
      <section class="proyects-section">
        <h3 class="sub-title">Proyectos</h3>
        <ProjectCard />
        <button class="more-btn">Más proyectos -></button>
      </section>
      <section class="calls-section">
        <h3 class="sub-title">Convocatorias</h3>
        <CalendarComponent />
      </section>
      <section class="events-section">
        <h3 class="sub-title">Eventos</h3>
        <div class="event-list">
          <div class="event-card">
            <div class="event-card-left">
              <h4 class="event-card-title">III Jornada Internacional de Investigación y Formación en Innovación Docente</h4>
              <div class="event-meta">12 de junio de 2026 · Campus Lenguas y Educación (Arturo Soria)</div>
              <p class="event-excerpt">La III Jornada Nebrija Innova es el encuentro anual de referencia para la reflexión, formación e investigación en innovación docente. Presentación de proyectos, ponencias y espacios de colaboración.</p>
              <router-link class="event-link" :to="{ path: '/eventos', hash: '#inicio' }">Ver detalle del evento</router-link>
            </div>
            <div class="event-card-right">
              <img src="../assets/logo-nebrija-innova-bombilla.png" alt="Nebrija Innova" />
            </div>
          </div>
        </div>
        <div class="speakers-list">
          <SpeakerCard v-for="(s, i) in speakers" :key="i" :speaker="s" />
        </div>
        <button class="more-btn">Más eventos -></button>
      </section>
    </section>
    <section class="contact-form">
      <h2 class="title">Contacta con nosotros</h2>
      <form action="">
        <p>Envíanos un mensaje y nos pondremos en contacto contigo lo antes posible.</p>
        <input class="form-input" type="text" placeholder="Nombre" required>
        <input class="form-input" type="email" placeholder="Correo electrónico" required>
        <textarea class="form-textarea" name="message" id="" placeholder="Tu mensaje..." required></textarea>
        <label for="terms">
          <input class="form-checkbox" type="checkbox" id="terms" required>
          Acepto los términos y condiciones
        </label>
        <button class="form-button" type="submit">Enviar</button>
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
  margin: 15px;
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
  background: linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.5)), url('../assets/banner.jpg') no-repeat center center;
  background-size: cover;
  /* height: 100px; */
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

/* Sección Convocatorias */
.calls-section {
  padding: 2rem;
  background-color: #ffffff;
}

.calls-section :deep(.v-calendar) {
  border-radius: 0.5rem;
  overflow: hidden;
  border: 1px solid #ddd;
  background-color: #ffffff;
}

/* Sección Eventos */
.events-section {
  padding: 2rem;
}

.event-list {
  padding: 12px;
}

.event-card{
  display:flex;
  gap:12px;
  background:#fff;
  border:1px solid #ddd;
  border-radius:8px;
  padding:12px;
  align-items:center;
}
.event-card-left{flex:1}
.event-card-title{margin:0;font-size:1.05rem;color:var(--nebrija-color,#c2002f)}
.event-meta{font-size:0.9rem;color:#666;margin:8px 0}
.event-excerpt{color:#555;margin:0 0 8px 0}
.event-link{display:inline-block;background:var(--nebrija-color,#c2002f);color:#fff;padding:8px 12px;border-radius:6px;text-decoration:none}

.event-card-right img{width:140px;height:auto;border-radius:6px;object-fit:cover}

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

.form-input {
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  font-size: 1rem;
  background-color: white;
}

.form-textarea {
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  font-size: 1rem;
  height: 75px;
  background-color: white;
}

.form-checkbox {
  -webkit-appearance: none;
  appearance: none;
  border: 1px solid #9c9c9c;
  width: 1.2rem;
  height: 1.2rem;
  border-radius: 9999px;
  background-color: white;
  cursor: pointer;
  position: relative;
  transition: background-color 0.2s ease, border-color 0.2s ease;
}

.form-checkbox:checked {
  background-color: var(--nebrija-color);
  border-color: var(--nebrija-color);
  border: 1px solid #9c9c9c;
}

.form-checkbox:focus-visible {
  outline: 2px solid var(--secondary-color);
  outline-offset: 2px;
}

.form-button {
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
