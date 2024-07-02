<script setup>
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'


</script>

<template>
  <header class="container">
  </header>
  <main class="pb-4">
    <router-view />
  </main>
  <footer class="bg-dark">
    <div class="container justify-content-center">
      <FooterLinks />
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
}

footer {
  min-height: 48px;
}

.icon {
  height: 32px;
  width: 32px;
  margin: 0;
  padding: 0;
}
</style>
