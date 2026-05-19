<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';

</script>

<template>
  <header>
    <nav class="nav">
      <img class="logo" src="/src/assets/logo-nebrija-innova.png" alt="logo">
      <div class="nav-links">
        <RouterLink class="btn-nav" to="/">Inicio</RouterLink>
        <RouterLink class="btn-nav" to="/proyectos">Proyectos</RouterLink>
        <RouterLink class="btn-nav" to="/convocatorias">Convocatorias</RouterLink>
        <RouterLink class="btn-nav" to="/eventos">Nebrija Innova</RouterLink>
        <!-- <RouterLink class="btn-nav" to="/formacion">Formación</RouterLink>
        <RouterLink class="btn-nav" to="/buenas-practicas">Buenas Prácticas</RouterLink> -->
      </div>
      <div class="nav-profile"><button>o</button></div>
    </nav>
    <RouterView />
  </header>
</template>

<style scoped>
header {
  padding-top: 80px;
}

.nav {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1rem;
  background-color: var(--grey-color);
  color: white;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.logo {
  height: 60px;
}

.nav-links {
  display: flex;
  gap: 1rem;
}

.btn-nav {
  background-color: var(--nebrija-color);
  color: white;
  text-decoration: none;
  border: 1px solid white;
  padding: 0.5rem 1rem;
}

.btn-nav:hover {
  background-color: white;
  color: var(--nebrija-color);
  border: 1px solid var(--nebrija-color);
}

.nav-profile button {
  width: 40px;
  height: 40px;
  background-color: white;
  color: var(--nebrija-color);
  border: none;
  padding: 0.5rem;
  cursor: pointer;
  border: 1px solid var(--nebrija-color);
  border-radius: 50%;
}

.nav-profile button:hover {
  background-color: var(--nebrija-color);
  color: white;
}
</style>
