<script setup lang="ts">
import { ref, computed, onMounted } from 'vue';
import projectsWrap from '../data/projects-interna.json';
import banner from '../assets/banner-proyectos.png';

type Project = {
  id: number;
  title: string;
  faculty: string;
  responsible?: string;
  summary: string;
  academicYear: string;
  call: string;
  line: string;
  center: string;
  documentFile?: string;
};

const projects = ref<Project[]>(
  (projectsWrap as any).projects.map((p: any) => ({
    id: p.id,
    title: p.title,
    faculty: p.faculty,
    responsible: p.responsible || '',
    summary: p.summary,
    academicYear: p.academicYear,
    call: p.call,
    line: p.line,
    center: p.center,
    documentFile: p.documentFile || '',
  }))
);

const filter = ref({
  year: 'Todos',
  line: 'Todas',
  call: 'Cualquiera',
  center: 'Cualquiera',
  search: '',
  pageSize: 3,
  loaded: 3,
});

const dialogOpen = ref(false);
const dialogProject = ref<Project | null>(null);

function matchesFilters(p: Project) {
  const yearMatch = filter.value.year === 'Todos' || p.academicYear === filter.value.year;
  const lineMatch = filter.value.line === 'Todas' || p.line === filter.value.line;
  const callMatch = filter.value.call === 'Cualquiera' || p.call === filter.value.call;
  const centerMatch = filter.value.center === 'Cualquiera' || p.center === filter.value.center;
  const searchText = `${p.title} ${p.faculty} ${p.summary} ${p.line} ${p.center}`.toLowerCase();
  const searchMatch = !filter.value.search || searchText.includes(filter.value.search.trim().toLowerCase());
  return yearMatch && lineMatch && callMatch && centerMatch && searchMatch;
}

const filtered = computed(() => projects.value.filter(matchesFilters));

const visible = computed(() => {
  const limit = Math.max(filter.value.pageSize, filter.value.loaded);
  return filtered.value.slice(0, limit);
});

function uniqueValues(selector: (p: Project) => string) {
  return Array.from(new Set(projects.value.map(selector).filter(Boolean)));
}

const uniqueYears = computed(() => uniqueValues((p) => p.academicYear));
const uniqueLines = computed(() => uniqueValues((p) => p.line));
const uniqueCalls = computed(() => uniqueValues((p) => p.call));
const uniqueCenters = computed(() => uniqueValues((p) => p.center));

function openDialog(p: Project) {
  dialogProject.value = p;
  dialogOpen.value = true;
}

function closeDialog() {
  dialogOpen.value = false;
  dialogProject.value = null;
}

function loadMore() {
  filter.value.loaded += filter.value.pageSize;
}

function downloadProject(p: Project) {
  const fileName = p.documentFile || `${p.title}.pdf`;
  const localUrl = `/proyectos/${encodeURIComponent(fileName)}`;
  const link = document.createElement('a');
  link.href = localUrl;
  link.download = fileName;
  document.body.appendChild(link);
  link.click();
  link.remove();
}

onMounted(() => {
  // initialize selects with available values
  // keep defaults from filter
});
</script>

<template>
  <main>
    <header class="hero" id="hero" :style="{ backgroundImage: `url(${banner})` }">
      <div class="hero-overlay"></div>
      <div class="hero-content">
        <div class="title-box">
          <h1>Proyectos de<br/>Innovación Docente</h1>
        </div>
      </div>
    </header>

    <section class="content">
      <div class="filters" id="filters">
        <div class="filters-grid">
          <label class="filter-box">
            <span class="filter-label">Año académico</span>
            <select class="filter-select" v-model="filter.year">
              <option>Todos</option>
              <option v-for="y in uniqueYears" :key="y">{{ y }}</option>
            </select>
          </label>
          <label class="filter-box">
            <span class="filter-label">Línea</span>
            <select class="filter-select" v-model="filter.line">
              <option>Todas</option>
              <option v-for="l in uniqueLines" :key="l">{{ l }}</option>
            </select>
          </label>
          <label class="filter-box">
            <span class="filter-label">Convocatoria</span>
            <select class="filter-select" v-model="filter.call">
              <option>Cualquiera</option>
              <option v-for="c in uniqueCalls" :key="c">{{ c }}</option>
            </select>
          </label>
          <label class="filter-box">
            <span class="filter-label">Centro</span>
            <select class="filter-select" v-model="filter.center">
              <option>Cualquiera</option>
              <option v-for="c in uniqueCenters" :key="c">{{ c }}</option>
            </select>
          </label>
        </div>
        <div class="filter-row">
          <div class="filter-left">
            <span>Mostrar</span>
            <input type="number" v-model.number="filter.pageSize" min="1" id="pageSizeInput" />
            <span>registros</span>
          </div>
          <div class="filter-right">
            <span>Buscar:</span>
            <input type="text" v-model="filter.search" id="searchInput" />
          </div>
        </div>
      </div>

      <div class="cards" id="cards">
        <article v-if="!projects.length" class="card"><h2 class="project-title">Cargando proyectos...</h2><p class="project-desc">No hay proyectos disponibles.</p></article>
        <article v-for="(p, index) in visible" :key="p.id" class="card" :data-index="index" :data-id="p.id">
          <h2 class="project-title">{{ p.title }}</h2>
          <div class="project-faculty">{{ p.faculty }}</div>
          <p class="project-desc">{{ p.summary }}</p>
          <div class="card-footer">
            <div class="meta">
              <span>Año: {{ p.academicYear }}</span>
            </div>
            <div class="card-actions">
              <button class="project-btn" type="button" @click="openDialog(p)">Ver proyecto</button>
              <button class="download-btn" type="button" @click="downloadProject(p)">Descargar</button>
            </div>
          </div>
        </article>
      </div>

      <div class="more-wrap">
        <button class="more-btn" type="button" :disabled="filtered.length <= visible.length" @click="loadMore">Cargar Mas</button>
      </div>
    </section>

    <div class="dialog-backdrop" v-if="dialogOpen" @click.self="closeDialog">
      <div class="dialog" role="dialog" aria-modal="true">
        <div class="dialog-header">
          <h2 class="dialog-title">{{ dialogProject?.title }}</h2>
          <button class="dialog-close" @click="closeDialog">x</button>
        </div>
        <div class="dialog-body">
          <div><strong>Facultad:</strong> {{ dialogProject?.faculty }}</div>
          <div v-if="dialogProject?.responsible"><strong>Responsable:</strong> {{ dialogProject?.responsible }}</div>
          <div><strong>Convocatoria:</strong> {{ dialogProject?.call }}</div>
          <div><strong>Año:</strong> {{ dialogProject?.academicYear }}</div>
          <div><strong>Línea:</strong> {{ dialogProject?.line }}</div>
          <div><strong>Centro:</strong> {{ dialogProject?.center }}</div>
          <div>{{ dialogProject?.summary }}</div>
        </div>
      </div>
    </div>
  </main>
</template>

<style scoped>
:root{--title:#d00037;--footer:#c60037}
.hero{position:relative;height:200px;display:flex;align-items:center;justify-content:center;color:#fff;background-size:cover;background-position:center}
.hero-overlay{position:absolute;inset:0;background:linear-gradient(rgba(0,0,0,0.35),rgba(0,0,0,0.35));}
.hero-content{position:relative;width:100%;max-width:1100px;margin:0 auto;padding:0 20px;}
.title-box{background-color:var(--nebrija-color,#c2002f);color:#fff;display:inline-block;padding:18px 26px;border-radius:6px}
.title-box h1{margin:0;font-size:26px;line-height:1.1}
.content{padding:28px 0}
.filters{width:min(900px,calc(100% - 72px));margin:0 auto 18px;border:1px solid #a4a4a4;border-radius:8px;padding:10px 12px;background:#fff}
.filters-grid{display:grid;grid-template-columns:repeat(4,1fr);gap:12px}
.filter-label{background:#d9d9d9;font-size:12px;font-weight:700;padding:5px 7px;border-radius:2px;color:#2b2b2b}
.filter-select{height:28px;border:1px solid #bdbdbd;border-radius:2px;padding:0 6px;background:linear-gradient(180deg,#fff,#f3f3f3);font-size:12px;color:#2b2b2b}
.filter-row{margin-top:10px;display:flex;align-items:center;justify-content:space-between;color:#8d8d8d;font-size:12px}
.cards{width:min(900px,calc(100% - 72px));margin:0 auto;display:grid;gap:18px}
.card{border:1px solid #bdb7b0;border-radius:7px;padding:10px 10px 12px;background:#fff}
.project-title{margin:0;color:#dc0000;font-size:15px;line-height:1.15;font-weight:700}
.project-faculty{margin:5px 0 5px;font-size:12px;color:#5d5d5d}
.project-desc{margin:0 0 10px;font-size:11px;line-height:1.35;color:#333}
.card-footer{display:flex;align-items:end;justify-content:space-between;gap:10px;font-size:12px;color:#5d5d5d}
.card-actions{display:flex;align-items:center;gap:8px}
.project-btn,.download-btn,.more-btn{border:0;background:linear-gradient(180deg,#d1003d 0%,#b90035 100%);color:#fff;border-radius:4px;font-size:11px;cursor:pointer;padding:7px 12px}
.more-wrap{display:flex;justify-content:center;margin:20px 0}
.dialog-backdrop{position:fixed;inset:0;background:rgba(17,17,17,0.45);display:flex;align-items:center;justify-content:center;padding:18px;z-index:50}
.dialog{width:min(520px,100%);background:#fff;border-radius:12px;box-shadow:0 24px 60px rgba(0,0,0,0.28);border:1px solid #d8d2cb;overflow:hidden}
.dialog-header{background:var(--title);color:#fff;padding:14px 16px;display:flex;align-items:center;justify-content:space-between}
.dialog-body{padding:16px;color:#2b2b2b;line-height:1.6;display:grid;gap:10px}
</style>
