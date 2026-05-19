<template>
	<div v-if="localSpeaker" class="speaker-card" @click="open = true" role="button" tabindex="0" @keydown.enter="open = true">
		<img :src="imageSrc" :alt="localSpeaker.name" class="avatar" />
		<div class="info">
			<h3 class="name">{{ localSpeaker.name }}</h3>
		</div>
	</div>

	<div v-if="open && localSpeaker" class="modal-overlay" @click.self="open = false">
		<div class="modal">
			<button class="close" @click="open = false" aria-label="Cerrar">✕</button>
			<div class="modal-header">
				<img :src="imageSrc" :alt="localSpeaker.name" class="avatar large" />
				<div>
					<h2>{{ localSpeaker.name }}</h2>
				</div>
			</div>
			<div class="modal-body">
				<p v-if="localSpeaker.bio">{{ localSpeaker.bio }}</p>
			</div>
		</div>
	</div>
</template>

<script setup lang="ts">
import { ref, watchEffect, computed, onMounted, onBeforeUnmount } from 'vue'

interface Speaker {
	name: string
	image: string
	bio?: string
}

const props = defineProps<{ speaker?: Speaker }>()
const open = ref(false)
const localSpeaker = ref<Speaker | null>(null)

const imageSrc = computed(() => {
	if (!localSpeaker.value) return ''
	const img = String(localSpeaker.value.image || '')
	if (/^https?:\/\//.test(img) || img.startsWith('/')) return img
	const filename = img.split('/').pop() || img
	try { return new URL(`../assets/${filename}`, import.meta.url).href } catch { return img || 'https://via.placeholder.com/150' }
})

// Si se pasa la prop, la usamos; si no, cargamos el primer ponente del JSON
if (props.speaker) {
	localSpeaker.value = props.speaker
} else {
	// import dinámico para evitar problemas con el bundler si no se usa
	import('@/data/speakers.json').then((m: any) => {
		const list: Speaker[] = m.default ?? m
		if (Array.isArray(list) && list.length > 0) {
			const first = list[0]
			if (first) localSpeaker.value = first as Speaker
		}
	})
}

// Mantener localSpeaker sincronizado si la prop cambia
watchEffect(() => {
	if (props.speaker) localSpeaker.value = props.speaker
})
// Cerrar modal con Escape
onMounted(() => {
	const handler = (e: KeyboardEvent) => { if (e.key === 'Escape') open.value = false }
	window.addEventListener('keydown', handler)
	// limpiar
	onBeforeUnmount(() => window.removeEventListener('keydown', handler))
})
</script>

<style scoped>
.speaker-card {
	display: flex;
	align-items: center;
	gap: 12px;
	padding: 10px;
	border-radius: 8px;
	cursor: pointer;
	transition: background .15s ease, transform .08s ease;
}
.speaker-card:focus,
.speaker-card:hover {
	background: rgba(0,0,0,0.03);
	transform: translateY(-1px);
}
.avatar {
	width: 56px;
	height: 56px;
	object-fit: cover;
	border-radius: 50%;
	flex-shrink: 0;
}
.avatar.large { width: 96px; height: 96px; }
.info { display: flex; flex-direction: column; justify-content: center; }
.info .name { margin: 0; font-size: 1rem; }

.modal-overlay {
	position: fixed;
	inset: 0;
	background: rgba(0,0,0,0.45);
	display: flex;
	align-items: center;
	justify-content: center;
	z-index: 1000;
}
.modal {
	background: white;
	max-width: 720px;
	width: 90%;
	border-radius: 10px;
	padding: 18px;
	position: relative;
	box-shadow: 0 10px 30px rgba(0,0,0,0.2);
}
.close {
	position: absolute;
	right: 12px;
	top: 12px;
	background: transparent;
	border: none;
	font-size: 18px;
	cursor: pointer;
}
.modal-header { display: flex; gap: 14px; align-items: center; }
.modal-header > div { display: flex; flex-direction: column; justify-content: center; }
.modal-body { margin-top: 12px; white-space: pre-wrap; }
/* detalles eliminados: solo se muestra la descripción */
</style>

