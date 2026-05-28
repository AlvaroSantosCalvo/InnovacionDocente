<script setup lang="ts">
import { ref } from 'vue';
import speakersData from '@/data/speakers.json';

const activeTab = ref('inicio');
const speakers = (speakersData as any) ?? []

function resolveImage(img: string) {
  if (!img) return ''
  if (/^https?:\/\//.test(img) || img.startsWith('/')) return img
  const filename = img.split('/').pop() || img
  try { return new URL(`../assets/${filename}`, import.meta.url).href } catch { return img }
}

// Formulario de inscripción
const form = ref({
  name: '',
  surname: '',
  email: '',
  affiliation: '',
  role: 'asistente',
  message: '',
  accept: false,
})
const error = ref('')
const success = ref(false)

function handleRegistration() {
  error.value = ''
  success.value = false
  if (!form.value.name || !form.value.surname || !form.value.email || !form.value.accept) {
    error.value = 'Por favor, complete los campos obligatorios y acepte las condiciones.'
    return
  }
  // Simulamos envío
  success.value = true
  // Opcional: limpiar formulario
  form.value.name = ''
  form.value.surname = ''
  form.value.email = ''
  form.value.affiliation = ''
  form.value.role = 'asistente'
  form.value.message = ''
  form.value.accept = false
}
</script>

<template>
  <main>
    <!-- Banner -->
    <div class="banner">
      <img src="../assets/banner-innova.png" alt="Banner Nebrija Innova">
    </div>

    <!-- Navegación de pestañas -->
    <section class="tabs-container">
      <div class="tabs">
        <button @click="activeTab = 'inicio'" :class="['tab', { active: activeTab === 'inicio' }]">
          Inicio
        </button>
        <button @click="activeTab = 'ponentes'" :class="['tab', { active: activeTab === 'ponentes' }]">
          Ponentes
        </button>
        <button @click="activeTab = 'inscripcion'" :class="['tab', { active: activeTab === 'inscripcion' }]">
          Inscripción
        </button>
      </div>
    </section>

    <!-- Contenido de Inicio -->
    <section v-if="activeTab === 'inicio'" class="content-section">
      <!-- Contenedores principales: Left y Right -->
      <div class="main-containers">
        <!-- Contenedor izquierdo -->
        <div class="container left-container">
          <h2 class="event-title">III Jornada Internacional de Investigación y Formación en Innovación Docente (Nebrija
            Innova)</h2>

          <!-- Contenedor de detalles (rojo) -->
          <div class="event-details-box">
            <div class="detail-item">
              <span class="detail-label">📅Fecha:</span>
              <span class="detail-value">12 de junio de 2026</span>
            </div>
            <div class="detail-item">
              <span class="detail-label">🗺️Lugar:</span>
              <span class="detail-value">Campus de Lenguas y Educación en Madrid-Arturo Soria</span>
            </div>
            <div class="detail-item">
              <span class="detail-label">🏫Modalidad:</span>
              <span class="detail-value">Presencial</span>
            </div>
          </div>

          <!-- Descripción del evento -->
          <div class="event-description">
            <p>La III Jornada Internacional de Investigación y Formación en Innovación Docente (Nebrija Innova) se
              enfoca como el evento de referencia anual dedicado a la reflexión, formación e investigación sobre
              innovación docente en la Universidad Nebrija, dotando de especial protagonismo a los docentes que han
              implantado o estén implantando proyectos de innovación docente en nuestra institución. Este espacio
              potencia además ser un laboratorio de ideas sobre innovación docente, buscando fomentar la colaboración
              entre profesores y favoreciendo espacios de formación e investigación.</p>

            <p>La jornada se llevará a cabo el día 12 de junio de 8:30 a 14:30 en el Campus Lenguas y Educación en
              Madrid Arturo Soria (calle Asura, 80). En ella se presentarán intervención los proyectos que han sido
              aprobados en la convocatoria del curso 2025-2026, que esperamos sirvan de inspiración a toda la comunidad
              docente para el impulso de nuevos proyectos. Este año contaremos con la participación de una ponente de
              excepción, Marisell Reyes Millán, directora de Educación Digital en el Tecnológico de Monterrey,
              conferenciista internacional en educación digital e innovación educativa y, con Carlos Magro, presidente
              de la Asociación Educación Abierta y profesional independiente en innovación, la tecnología y las
              políticas educativas.</p>

            <p>¡Esperamos contar con tu asistencia!</p>

            <p><strong>Inscripciones abiertas hasta el 10 de junio de 2026.</strong></p>
          </div>
        </div>

        <!-- Contenedor derecho -->
        <div class="container right-container">
          <!-- Redes sociales -->
          <div class="social-share">
            <h3 class="share-title">Comparte este evento</h3>
            <div class="social-icons">
              <a href="" class="social-icon" title="Facebook">
                <img src="../assets/social-icons/facebook.png" alt="Facebook">
              </a>
              <a href="" class="social-icon" title="X (Twitter)">
                <img src="../assets/social-icons/x.png" alt="X">
              </a>
              <a href="" class="social-icon" title="LinkedIn">
                <img src="../assets/social-icons/linkedin.png" alt="LinkedIn">
              </a>
              <a href="" class="social-icon" title="Email">
                <img src="../assets/social-icons/correo-electronico.png" alt="Email">
              </a>
            </div>
          </div>

          <!-- Botón de inscripción -->
          <button class="inscription-btn" @click="activeTab = 'inscripcion'">INSCRIBIRSE</button>

          <!-- Mapa -->
          <div class="map-container">
            <iframe
              src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6249.582649163408!2d-3.655394136797625!3d40.45679759226153!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd422f3ee9d3ed13%3A0xf1c6d52a65a87b23!2sUniversidad%20Nebrija%20Campus%20de%20Lenguas%2C%20Educaci%C3%B3n%20y%20Psicolog%C3%ADa%20en%20Madrid%20Arturo%20Soria!5e0!3m2!1ses!2sus!4v1779181414585!5m2!1ses!2sus"
              width="100%" height="500" style="border:0;" allowfullscreen="true" loading="lazy"
              referrerpolicy="no-referrer-when-downgrade"></iframe>
          </div>
        </div>
      </div>

      <!-- Contenedor formulario (abajo) -->
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
    </section>

    <!-- Contenido de Ponentes -->
    <section v-if="activeTab === 'ponentes'" class="content-section">
      <div class="main-containers speakers-layout">
        <!-- Grid de ponentes (izquierda) -->
        <div class="container left-container speakers-column">
          <h2 class="section-heading">Ponentes</h2>
          <div class="speakers-scroll">
            <div class="speakers-grid">
              <div v-for="(s, idx) in speakers" :key="idx" class="speaker-card-large">
              <div class="speaker-header">
                <img :src="resolveImage(s.image)" :alt="s.name" class="speaker-avatar" />
                <h3 class="speaker-name">{{ s.name }}</h3>
              </div>
              <p class="speaker-bio">{{ s.bio }}</p>
              </div>
            </div>
          </div>
        </div>

        <!-- Columna derecha con compartir, botón e iframe (derecha) -->
        <div class="container right-container right-sidebar">
          <div class="social-share compact">
            <h3 class="share-title">Comparte este evento</h3>
            <div class="social-icons">
              <a href="#" class="social-icon" title="X (Twitter)">
                <img src="../assets/social-icons/x.png" alt="X">
              </a>
              <a href="#" class="social-icon" title="Facebook">
                <img src="../assets/social-icons/facebook.png" alt="Facebook">
              </a>
              <a href="#" class="social-icon" title="LinkedIn">
                <img src="../assets/social-icons/linkedin.png" alt="LinkedIn">
              </a>
              <a href="#" class="social-icon" title="Email">
                <img src="../assets/social-icons/correo-electronico.png" alt="Email">
              </a>
            </div>
          </div>

          <button class="inscription-btn blue" @click="activeTab = 'inscripcion'">INSCRIBIRSE</button>

          <div class="embed-box">
            <label class="embed-label">Difunde tu evento poniendo el siguiente código en tu sitio</label>
            <textarea readonly class="embed-textarea">&lt;iframe width="100%" height="300px" src="http://actos.nebrija.es/api/widget_map_event/eyJpZCI6IjE1MjciLCJpbnRlcm5hbCI6dHJ1ZX0="&gt;&lt;/iframe&gt;</textarea>
          </div>
        </div>
      </div>
    </section>

    <!-- Contenido de Inscripción -->
    <section v-if="activeTab === 'inscripcion'" class="content-section">
      <div class="registration-layout">
        <div class="registration-info">
          <h2 class="title">Formulario de inscripción</h2>
          <p>Rellena el siguiente formulario para inscribirte en la III Jornada Nebrija Innova. Recibirás un
            correo de confirmación si tu inscripción es correcta.</p>
          <ul>
            <li><strong>Fecha:</strong> 12 de junio de 2026</li>
            <li><strong>Horario:</strong> 8:30 - 14:30</li>
            <li><strong>Lugar:</strong> Campus Lenguas y Educación - Arturo Soria</li>
          </ul>
        </div>

        <div class="registration-form container">
          <form @submit.prevent="handleRegistration">
            <div class="two-cols">
              <input class="form-input" v-model="form.name" type="text" placeholder="Nombre" required>
              <input class="form-input" v-model="form.surname" type="text" placeholder="Apellidos" required>
            </div>

            <input class="form-input" v-model="form.email" type="email" placeholder="Correo electrónico" required>
            <input class="form-input" v-model="form.affiliation" type="text" placeholder="Centro / Afiliación">

            <label class="form-label">Tipo de participante</label>
            <select v-model="form.role" class="form-input">
              <option value="asistente">Asistente</option>
              <option value="ponente">Ponente</option>
              <option value="investigador">Investigador</option>
            </select>

            <textarea class="form-textarea" v-model="form.message" placeholder="Comentarios / Necesidades especiales"></textarea>

            <label class="terms-label">
              <input class="form-checkbox" type="checkbox" v-model="form.accept" required>
              Acepto las condiciones y el tratamiento de datos
            </label>

            <div class="form-actions">
              <button class="form-button" type="submit">Enviar inscripción</button>
            </div>

            <p v-if="error" class="form-error">{{ error }}</p>
            <p v-if="success" class="form-success">Inscripción enviada correctamente. Revisaremos tu solicitud.</p>
          </form>
        </div>
      </div>
    </section>
  </main>
</template>

<style scoped>
/* Generales */
main {
  width: 100%;
}

.title {
  font-size: 2rem;
  font-weight: bold;
  color: #333;
  margin-bottom: 1rem;
}

/* Banner */
.banner {
  width: 100%;
  height: auto;
  overflow: hidden;
}

.banner img {
  width: 80%;
  height: auto;
  display: block;
  margin: 0 auto;
}

/* Tabs Container */
.tabs-container {
  background-color: #f8f9fa;
  border-bottom: 2px solid #ddd;
  padding: 0 2rem;
}

.tabs {
  display: flex;
  gap: 0;
  max-width: 1200px;
  margin: 0 auto;
}

.tab {
  background-color: transparent;
  border: none;
  padding: 1rem 2rem;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 500;
  color: #666;
  border-bottom: 3px solid transparent;
  transition: all 0.3s ease;
  position: relative;
}

.tab:hover {
  color: #333;
}

.tab.active {
  color: #c2002f;
  border-bottom-color: #c2002f;
}

/* Content Section */
.content-section {
  padding: 2rem;
  margin: 0 auto;
}

/* Main containers layout */
.main-containers {
  display: grid;
  grid-template-columns: 60% 35%;
  gap: 2rem;
  margin: 0 auto 3rem;
  width: 95%;
  max-width: calc(100% - 2rem);
}

.container {
  background-color: white;
}

.left-container {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
  padding: 1.5rem;
  border-radius: 0.5rem;
}

.right-container {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
  padding: 1.5rem;
  border-radius: 0.5rem;
}

/* Event Info */
.event-title {
  font-size: 1.6rem;
  font-weight: bold;
  color: #c2002f;
  line-height: 1.4;
  margin: 0;
}

/* Contenedor de detalles (rojo) */
.event-details-box {
  background-color: #c2002f;
  color: white;
  padding: 1.5rem;
  border-radius: 0.5rem;
  display: flex;
  flex-direction: column;
  gap: 1rem;
  width: fit-content;
}

.event-details-box .detail-item {
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
}

.event-details-box .detail-label {
  font-weight: 600;
  font-size: 0.9rem;
  text-transform: uppercase;
  opacity: 0.95;
}

.event-details-box .detail-value {
  font-size: 1rem;
  line-height: 1.4;
}

.event-description {
  color: #555;
  line-height: 1.8;
  text-align: justify;
}

.event-description p {
  margin-bottom: 1rem;
  margin-top: 0;
}

.event-description p:last-child {
  margin-bottom: 0;
}

.event-description strong {
  color: #333;
}

/* Ponentes layout */
.speakers-layout { width: 95%; max-width: calc(100% - 2rem); margin: 0 auto 3rem; }
.section-heading { color: #c2002f; font-weight: 700; margin: 0 0 1rem 0; }

.speakers-grid { display: grid; grid-template-columns: repeat(2, minmax(220px, 1fr)); gap: 1rem; justify-content: stretch; align-items: start; }
.speaker-card-large { background: white; padding: 1rem; box-shadow: 0 2px 6px rgba(0,0,0,0.06); border-radius: 4px; font-size: 0.95rem; width: 100%; max-width: 420px; height: 300px; display: flex; flex-direction: column; }
.speaker-header { display: flex; align-items: center; gap: 0.75rem; }
.speaker-avatar { width: 72px; height: 72px; border-radius: 50%; object-fit: cover; flex-shrink: 0; }
.speaker-name { margin: 0; font-weight: 700; color: #111; font-size: 1rem; }
.speaker-bio { margin-top: 0.75rem; color: #333; line-height: 1.6; text-align: justify; font-size: 0.95rem; overflow-y: auto; flex: 1 1 auto; padding-right: 6px; }

/* Scrollbar inside each card */
.speaker-bio::-webkit-scrollbar { width: 9px; }
.speaker-bio::-webkit-scrollbar-track { background: transparent; }
.speaker-bio::-webkit-scrollbar-thumb { background-color: rgba(0,0,0,0.12); border-radius: 8px; }
.speaker-bio { scrollbar-width: thin; scrollbar-color: rgba(0,0,0,0.12) transparent; }

.speakers-scroll { max-height: 420px; overflow-y: auto; overflow-x: hidden; padding-right: 0.5rem; }
/* Scrollbar styles */
.speakers-scroll::-webkit-scrollbar { width: 10px; }
.speakers-scroll::-webkit-scrollbar-track { background: transparent; }
.speakers-scroll::-webkit-scrollbar-thumb { background-color: rgba(0,0,0,0.12); border-radius: 8px; }
/* Firefox */
.speakers-scroll { scrollbar-width: thin; scrollbar-color: rgba(0,0,0,0.12) transparent; }

.right-sidebar { display: flex; flex-direction: column; gap: 1.25rem; }
.social-share.compact { padding: 1rem; background: transparent; }
.inscription-btn.blue { background-color: #0b66d1; }
.inscription-btn.blue:hover { background-color: #084f9b; }
.embed-box { background: transparent; padding: 0.25rem; }
.embed-label { display: block; color: #333; font-size: 0.95rem; margin-bottom: 0.5rem; }
.embed-textarea { width: 100%; height: 90px; resize: none; border: 1px solid #ddd; padding: 0.5rem; border-radius: 4px; background: #f7f7f7; font-size: 0.8rem; color: #444; }

/* Redes sociales */
.social-share {
  background-color: #f8f9fa;
  padding: 1.5rem;
  border-radius: 0.5rem;
}

.share-title {
  font-size: 1rem;
  font-weight: 600;
  color: #333;
  margin: 0 0 1rem 0;
}

.social-icons {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
}

.social-icon {
  width: 45px;
  height: 45px;
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: transparent;
  border-radius: 0.5rem;
  text-decoration: none;
  transition: transform 0.2s, filter 0.2s;
  cursor: pointer;
  overflow: hidden;
}

.social-icon img {
  width: 100%;
  height: 100%;
  object-fit: contain;
  transition: filter 0.2s;
}

/* Mejoras visuales: tarjetas y formulario */
.speaker-card-large {
  border: 1px solid rgba(0,0,0,0.04);
  border-radius: 8px;
  box-shadow: 0 6px 20px rgba(0,0,0,0.08);
  transition: transform .18s ease, box-shadow .18s ease;
}
.speaker-card-large:hover { transform: translateY(-6px); box-shadow: 0 10px 30px rgba(0,0,0,0.12); }
.speaker-name { font-size: 1.05rem; }
.speaker-header { padding-bottom: 6px; border-bottom: 1px solid rgba(0,0,0,0.04); }

/* Inputs y botones estilizados */
.form-input, .form-textarea, .embed-textarea, select {
  width: 100%;
  padding: 0.7rem 0.9rem;
  border: 1px solid #e2e6ea;
  border-radius: 6px;
  background: #fff;
  box-shadow: inset 0 1px 0 rgba(255,255,255,0.6);
  transition: border-color .14s ease, box-shadow .14s ease, transform .12s ease;
}
.form-input:focus, .form-textarea:focus, select:focus { outline: none; border-color: #0b66d1; box-shadow: 0 6px 18px rgba(11,102,209,0.06); transform: translateY(-1px); }
.form-textarea { min-height: 96px; resize: vertical; }
.form-button {
  background: linear-gradient(180deg,#0b66d1,#0951a8);
  color: white;
  padding: 0.75rem 1.1rem;
  border-radius: 8px;
  border: none;
  cursor: pointer;
  font-weight: 700;
  letter-spacing: 0.4px;
  box-shadow: 0 8px 20px rgba(11,102,209,0.12);
}
.form-button:hover { transform: translateY(-2px); box-shadow: 0 12px 28px rgba(11,102,209,0.14); }

.registration-form { padding: 1.5rem; }
.registration-info p { color: #555; }
.registration-info ul { padding-left: 1.1rem; color: #444; }

.section-heading { font-size: 1.25rem; }

/* Alinear la columna derecha para que el botón quede centrado horizontalmente */
.right-sidebar { align-items: flex-end; }
.right-sidebar .social-share { width: 100%; }
.right-sidebar .embed-box { width: 100%; }

/* Ajustes de tamaño en móviles */
@media (max-width: 900px) {
  .speakers-grid { grid-template-columns: 1fr; }
  .speaker-card-large { height: auto; }
  .right-sidebar { align-items: stretch; }
}

.social-icon:hover img {
  filter: brightness(0.8);
  transform: scale(1.05);
}

/* Botón de inscripción */
.inscription-btn {
  background-color: #c2002f;
  color: white;
  border: none;
  padding: 1rem 1.5rem;
  border-radius: 0.5rem;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 600;
  transition: background-color 0.3s;
  width: 100%;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.inscription-btn:hover {
  background-color: #a00025;
}

/* Mapa */
.map-container {
  border-radius: 0.5rem;
  overflow: hidden;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  width: 100%;
}

/* Sección Contacto */
.contact-form {
  padding: 2rem;
  background-color: #f8f9fa;
  border-radius: 0.5rem;
  margin-top: 2rem;
}

.contact-form form {
  max-width: 600px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.contact-form form p {
  color: #666;
  margin-bottom: 0.5rem;
  margin-top: 0;
}

.form-input {
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  font-size: 1rem;
  background-color: white;
}

.form-input:focus {
  outline: none;
  border-color: #c2002f;
  box-shadow: 0 0 0 3px rgba(194, 0, 47, 0.1);
}

.form-textarea {
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 0.5rem;
  font-size: 1rem;
  height: 75px;
  background-color: white;
  resize: vertical;
}

.form-textarea:focus {
  outline: none;
  border-color: #c2002f;
  box-shadow: 0 0 0 3px rgba(194, 0, 47, 0.1);
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
  flex-shrink: 0;
}

.form-checkbox:checked {
  background-color: #c2002f;
  border-color: #c2002f;
}

.form-checkbox:focus-visible {
  outline: 2px solid #c2002f;
  outline-offset: 2px;
}

.form-button {
  align-self: flex-start;
  background-color: #c2002f;
  color: white;
  border: none;
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s;
}

.form-button:hover {
  background-color: #a00025;
}

.contact-form label {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  font-size: 0.9rem;
  color: #666;
}

/* Ponentes placeholder */
.ponentes-placeholder {
  text-align: center;
  padding: 3rem;
  background-color: #f8f9fa;
  border-radius: 0.5rem;
  color: #666;
  font-size: 1.1rem;
}

/* Inscripción placeholder */
.inscripcion-placeholder {
  text-align: center;
  padding: 3rem;
  background-color: #f8f9fa;
  border-radius: 0.5rem;
  color: #666;
  font-size: 1.1rem;
}

/* Registration form styles */
.registration-layout { display: grid; grid-template-columns: 1fr 420px; gap: 2rem; align-items: start; width: 95%; max-width: calc(100% - 2rem); margin: 0 auto 2rem; }
.registration-info { padding: 1rem; }
.registration-form { padding: 1.25rem; background: white; border-radius: 6px; box-shadow: 0 2px 8px rgba(0,0,0,0.06); }
.two-cols { display: grid; grid-template-columns: 1fr 1fr; gap: 0.75rem; }
.form-label { margin-bottom: 0.25rem; font-weight: 600; }
.form-actions { margin-top: 0.5rem; }
.form-error { color: #b00020; margin-top: 0.5rem; }
.form-success { color: #0b662d; margin-top: 0.5rem; }
.terms-label { display: flex; gap: 0.5rem; align-items: center; font-size: 0.95rem; color: #444; margin-top: 0.5rem; }

@media (max-width: 900px) {
  .registration-layout { grid-template-columns: 1fr; }
  .registration-form { width: 100%; }
}

/* Responsive */
@media (max-width: 768px) {
  .tabs {
    flex-wrap: wrap;
  }

  .tab {
    padding: 0.75rem 1rem;
    font-size: 0.9rem;
  }

  .main-containers {
    grid-template-columns: 1fr;
    gap: 1.5rem;
  }

  .speakers-grid { grid-template-columns: 1fr; }
  .speaker-avatar { width: 64px; height: 64px; }
  .speakers-grid { grid-template-columns: 1fr; }
  .speaker-card-large { width: 100%; height: auto; }

  .left-container,
  .right-container {
    padding: 1rem;
  }

  .event-title {
    font-size: 1.3rem;
  }

  .content-section {
    padding: 1rem;
  }

  .social-icons {
    justify-content: flex-start;
  }

  .inscription-btn {
    width: 100%;
  }
}
</style>
