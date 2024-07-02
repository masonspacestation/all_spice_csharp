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

    </div>
    <FooterLinks />
    <!-- <div class="row w-75 justify-content-between my-2 mx-auto">
      <div class="col-12 col-md-4">
        <span class="text-light opacity-50 fs-6">Site by </span>
        <a href="https://andrewmason.dev" class="w-auto"><img class="icon"
            src="../src/assets/img/AMDev-favicon-colorbg.png" title="Andrew Mason - Development and Design" /><span
            class="link-underline-light link-light link-offset-2 link-underline-opacity-25 link-underline-opacity-75-hover">
            Andrew
            Mason - Development and Design</span></a>
      </div>
      <div class="col-12 col-md-8 text-end">
        <LinkIcons class="w-auto me-auto" />
      </div>
    </div> -->
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

.icon {
  height: 32px;
  width: 32px;
  margin: 0;
  padding: 0;
}
</style>
