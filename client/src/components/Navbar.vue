<!-- eslint-disable no-console -->
<script setup>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

const theme = ref(loadState('theme') || 'light')

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}


</script>

<template>
  <nav
    class="navbar navbar-expand-sm bg-none d-flex align-items-start align-items-lg-center justify-content-between px-4 pt-2">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }" title="Return to Home page.">
      <div class="d-flex flex-column align-items-center">
        <h3 class="text-white">🧿 AllSpice</h3>
      </div>
    </router-link>
    <!-- <button class="navbar-toggler bg-success" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button> -->
    <div class="" id="navbarText">
      <ul class="navbar-nav ms-auto">
      </ul>
      <Login />
    </div>
  </nav>
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
