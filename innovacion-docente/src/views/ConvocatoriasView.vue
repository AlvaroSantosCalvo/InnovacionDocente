<script setup lang="ts">
import { ref } from 'vue';

// Definición de las Fases según el PDF
const fases = ref([
  { id: 1, title: 'Información', desc: 'Consulta de bases y Anexos (I y Ib).' },
  { id: 2, title: 'Presentación', desc: 'Envío hasta el 24 de julio de 2026.' },
  { id: 3, title: 'Revisión', desc: 'Subsanación de errores (Agosto).' },
  { id: 4, title: 'Evaluación', desc: 'Por pares y doble ciego (Comisión).' },
  { id: 5, title: 'Resolución', desc: 'Publicación provisional y definitiva.' },
  { id: 6, title: 'Ejecución', desc: 'Desarrollo con apoyo tecno-educativo.' },
  { id: 7, title: 'Memoria Final', desc: 'Elaboración y entrega (Anexos III y IV).' },
  { id: 8, title: 'Certificación', desc: 'Emisión tras evaluación positiva.' },
  { id: 9, title: 'Difusión', desc: 'Transferencia y divulgación institucional.' },
]);

// Resumen de las líneas de actuación extraídas del PDF
const lineasActuacion = ref([
  '1. Nuevas tecnologías en enseñanza',
  '2. Metodologías activas en el aula',
  '3. Accesibilidad, inclusión y personalización',
  '4. Aprendizaje autorregulado',
  '5. Colaboración y comunicación digital',
  '6. Competencia digital de estudiantes',
  '7. Transferencia social y divulgación',
  '8. ODS y valores democráticos',
  '9. Instrumentos de evaluación',
  '10. Competencias profesionales y empleabilidad'
]);
</script>

<template>
  <div class="convocatoria-page">
    <header class="hero">
      <div class="hero-overlay"></div>
      <div class="hero-content">
        <div class="title-box">
          <h1>Convocatorias de<br>Innovación Docente</h1>
        </div>
      </div>
    </header>

    <main class="container">

      <section class="section">
        <h2 class="section-title">Convocatoria Ordinaria Curso 2026-2027</h2>
        <div class="cards-grid">
          <div class="info-card">
            <div class="card-header">
              <span class="icon">🎯</span>
              <h3>Objetivos</h3>
            </div>
            <p>Fomentar la calidad e innovación mediante la experimentación. Promover la autorreflexión docente, generar
              un impacto positivo en la institución y apoyar en los procesos de acreditación (Agencias de Calidad).</p>
          </div>

          <div class="info-card">
            <div class="card-header">
              <span class="icon">👥</span>
              <h3>Destinatarios</h3>
            </div>
            <p>Profesorado de la Universidad e Institutos Nebrija (individual o grupo). También personal investigador y
              doctorandos con actividad docente. Máx. 2 responsables por proyecto grupal.</p>
          </div>

          <div class="info-card">
            <div class="card-header">
              <span class="icon">📁</span>
              <h3>Tipos de Proyecto</h3>
            </div>
            <ul>
              <li><strong>A:</strong> En una materia o titulación.</li>
              <li><strong>B:</strong> Transversales (Facultades/Escuelas).</li>
              <li><strong>C:</strong> En conjunto con otras universidades.</li>
            </ul>
          </div>
        </div>
      </section>

      <section class="red-banner">
        <div class="banner-icon">📅</div>
        <div class="banner-content">
          <h3>Fechas Importantes</h3>
          <ul class="dates-list">
            <li><strong>Plazo de presentación:</strong> Hasta el 24 de julio de 2026 (Vía Campus de Innovación)</li>
            <li><strong>Revisión y adecuación:</strong> Agosto de 2026</li>
            <li><strong>Evaluación y Resolución:</strong> Septiembre y Octubre de 2026</li>
            <li><strong>Periodo de ejecución:</strong> Mínimo 1 semestre, máximo 2 cursos académicos</li>
          </ul>
        </div>
      </section>

      <section class="section">
        <h2 class="section-title">Líneas de Actuación</h2>
        <div class="lines-grid">
          <span v-for="(linea, index) in lineasActuacion" :key="index" class="linea-chip">
            {{ linea }}
          </span>
        </div>
      </section>

      <section class="section">
        <h2 class="section-title">Fases de la convocatoria</h2>
        <div class="timeline">
          <div v-for="fase in fases" :key="fase.id" class="timeline-step">
            <div class="step-circle">{{ fase.id }}</div>
            <h4 class="step-title">{{ fase.title }}</h4>
            <p class="step-desc">{{ fase.desc }}</p>
          </div>
        </div>
      </section>

      <section class="cta-box">
        <div class="cta-content">
          <h4>¿Quieres participar?</h4>
          <p>
            Si eres docente de la Universidad Nebrija y estás interesado en desarrollar un proyecto,
            cumplimenta el modelo de solicitud (Anexo I) y envíalo a través del Campus de Innovación Docente.
            Para dudas, escríbenos a <strong>innovaciondocente@nebrija.es</strong>.
          </p>
          <button class="btn-primary">Descargar Bases y Anexos</button>
        </div>
      </section>

    </main>
  </div>
</template>

<style scoped>
.convocatoria-page {
  --nebrija-red: #c2002f;
  --text-dark: #333333;
  --text-gray: #666666;
  --bg-light: #f4f5f7;
  --bg-white: #ffffff;
  font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
  color: var(--text-dark);
  background-color: #fafafa;
  min-height: 100vh;
}

/* Header / Hero Section */
.hero {
  position: relative;
  height: 250px;
  background: url('https://images.unsplash.com/photo-1456735190827-d1262f71b8a3?auto=format&fit=crop&w=1600&q=80') center/cover no-repeat;
  display: flex;
  align-items: center;
}

.hero-overlay {
  position: absolute;
  inset: 0;
  background: rgba(0, 0, 0, 0.4);
}

.hero-content {
  position: relative;
  width: 100%;
  max-width: 1100px;
  margin: 0 auto;
  padding: 0 20px;
}

.title-box {
  background-color: var(--nebrija-red);
  color: white;
  display: inline-block;
  padding: 30px 40px;
  max-width: 500px;
}

.title-box h1 {
  margin: 0;
  font-size: 2rem;
  font-weight: 600;
  line-height: 1.2;
}

/* Contenedor Principal */
.container {
  max-width: 1100px;
  margin: 40px auto;
  padding: 0 20px;
}

.section {
  margin-bottom: 50px;
}

.section-title {
  color: var(--nebrija-red);
  font-size: 1.5rem;
  font-weight: 500;
  margin-bottom: 25px;
}

/* Tarjetas Grid (Adaptación de las tarjetas grises) */
.cards-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 20px;
}

.info-card {
  background-color: var(--bg-light);
  padding: 25px;
  border-radius: 8px;
}

.card-header {
  display: flex;
  align-items: center;
  gap: 10px;
  margin-bottom: 15px;
}

.card-header .icon {
  font-size: 1.5rem;
}

.card-header h3 {
  margin: 0;
  font-size: 1.1rem;
  color: var(--text-dark);
}

.info-card p,
.info-card ul {
  font-size: 0.9rem;
  color: var(--text-gray);
  line-height: 1.5;
  margin: 0;
}

.info-card ul {
  padding-left: 20px;
}

.info-card li {
  margin-bottom: 5px;
}

/* Banner Rojo de Fechas */
.red-banner {
  background-color: var(--nebrija-red);
  color: white;
  border-radius: 10px;
  padding: 30px;
  display: flex;
  align-items: flex-start;
  gap: 20px;
  margin-bottom: 50px;
}

.banner-icon {
  font-size: 2.5rem;
}

.banner-content h3 {
  margin: 0 0 15px 0;
  font-size: 1.2rem;
}

.dates-list {
  list-style: none;
  padding: 0;
  margin: 0;
}

.dates-list li {
  margin-bottom: 8px;
  font-size: 0.95rem;
}

/* Líneas de Actuación (Chips) */
.lines-grid {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
}

.linea-chip {
  background-color: white;
  border: 1px solid #ddd;
  padding: 8px 15px;
  border-radius: 20px;
  font-size: 0.85rem;
  color: var(--text-gray);
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.02);
}

/* Fases de la Convocatoria (Timeline Wrapping) */
.timeline {
  display: flex;
  flex-wrap: wrap;
  gap: 30px 15px;
  justify-content: center;
  position: relative;
  margin-top: 30px;
}

.timeline-step {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  width: 150px;
  position: relative;
}

.step-circle {
  width: 50px;
  height: 50px;
  background-color: var(--nebrija-red);
  color: white;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.2rem;
  font-weight: bold;
  margin-bottom: 15px;
  z-index: 2;
}

.step-title {
  margin: 0 0 5px 0;
  font-size: 0.9rem;
  font-weight: 600;
  color: var(--text-dark);
}

.step-desc {
  margin: 0;
  font-size: 0.75rem;
  color: var(--text-gray);
  line-height: 1.3;
}

/* Call To Action Box */
.cta-box {
  background-color: white;
  border: 1px solid #e0e0e0;
  border-radius: 10px;
  padding: 30px;
  margin-top: 60px;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.03);
}

.cta-content h4 {
  margin: 0 0 10px 0;
  font-size: 1.2rem;
}

.cta-content p {
  color: var(--text-gray);
  font-size: 0.95rem;
  margin-bottom: 20px;
  max-width: 800px;
}

.btn-primary {
  background-color: var(--nebrija-red);
  color: white;
  border: none;
  padding: 10px 24px;
  border-radius: 5px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.2s;
}

.btn-primary:hover {
  background-color: #a00e26;
}

/* Responsive Ajustes */
@media (max-width: 768px) {
  .hero-content .title-box {
    max-width: 100%;
  }

  .red-banner {
    flex-direction: column;
  }

  .timeline {
    flex-direction: column;
    align-items: flex-start;
  }

  .timeline-step {
    flex-direction: row;
    width: 100%;
    text-align: left;
    align-items: flex-start;
  }

  .step-circle {
    margin-right: 15px;
    margin-bottom: 0;
    flex-shrink: 0;
  }
}
</style>
