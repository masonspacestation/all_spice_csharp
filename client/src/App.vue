<script setup>
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'


</script>

<template>
  <header class="container">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark">
    <div class="container justify-content-center">
      <p class="text-success mt-4">
        The spice must flow 🧿
      </p>
    </div>
  </footer>
</template>

<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  min-height: 48px;
}
</style>
