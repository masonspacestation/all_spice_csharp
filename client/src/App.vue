<script setup>
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'


</script>

<template>
  <header class="container">
    <!-- <Navbar /> -->
  </header>
  <main class="pb-4">
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

main {
  background-color: #2c3a47;
  background-image: url("https://www.transparenttextures.com/patterns/black-felt.png");
  /* This is mostly intended for prototyping; please download the pattern and re-host for production environments. Thank you! */
}

footer {
  min-height: 48px;
}
</style>
