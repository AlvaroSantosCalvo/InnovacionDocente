<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';

</script>

<template>
  <header>
    <nav class="nav">
      <img class="logo" src="/src/assets/logo.png" alt="logo">
      <div class="nav-links">
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/formacion">Formación</RouterLink>
        <RouterLink to="/proyectos">Proyectos</RouterLink>
        <RouterLink to="/eventos">Eventos</RouterLink>
        <RouterLink to="/convocatorias">Convocatorias</RouterLink>
        <RouterLink to="/buenas-practicas">Buenas Prácticas</RouterLink>
      </div>
      <div class="nav-profile"><button>+</button></div>
    </nav>
    <RouterView />
  </header>
</template>

<style scoped>

</style>
