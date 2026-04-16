import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/formacion',
      name: 'formacion',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/FormacionView.vue'),
    },
    {
      path: '/proyectos',
      name: 'proyectos',
      component: () => import('../views/ProyectosView.vue'),
    },
    {
      path: '/eventos',
      name: 'eventos',
      component: () => import('../views/EventosView.vue'),
    },
    {
      path: '/convocatorias',
      name: 'convocatorias',
      component: () => import('../views/ConvocatoriasView.vue'),
    },
    {
      path: '/buenas-practicas',
      name: 'buenas-practicas',
      component: () => import('../views/BuenasPracticasView.vue'),
    },
  ],
})

export default router
