<script setup>
import { Recipe } from "../models/Recipe.js";

const props = defineProps({ recipe: { type: Recipe, required: true } })

</script>


<template>
  <div class="recipe-card rounded rounded-3 shadow d-flex flex-column justify-content-between">
    <i class="mdi mdi-heart-outline mt-1 me-2 fs-3 text-light opacity-50 text-end"></i>
    <div class="card-cover p-2">
      <h3 class="fs-4 text-light">{{ recipe.title }}</h3>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.recipe-card {
  height: 30dvh;
  background-image: url("https://images.unsplash.com/photo-1552539618-7eec9b4d1796?q=80&w=3036&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
  background-position: center;
  background-size: cover;
}

.card-cover {
  height: 30%;
  background-color: rgba(148, 148, 148, 0.515);
}
</style>