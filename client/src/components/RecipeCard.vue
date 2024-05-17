<script setup>
import { computed } from "vue";
import { Recipe } from "../models/Recipe.js";

const props = defineProps({ recipe: { type: Recipe, required: true } })
const bgStyle = computed(() => `url(${props.recipe.img})`)



</script>


<template>

  <div role="button" data-bs-toggle="modal" data-bs-target="#recipe-modal"
    class="recipe-card rounded rounded-3 shadow d-flex flex-column justify-content-between">
    <i class="mdi mdi-heart-outline mt-1 me-2 fs-3 text-light opacity-50 text-end"></i>
    <div class="card-cover p-2">
      <h3 class="fs-4 text-light">{{ recipe.title }}</h3>
    </div>
  </div>

  <ModalWrapper modalId="recipe-modal">
    <RecipeView :recipe="recipe" />
  </ModalWrapper>
</template>


<style lang="scss" scoped>
.recipe-card {
  height: 30dvh;
  background-image: v-bind(bgStyle);
  background-position: center;
  background-size: cover;
}

.card-cover {
  height: 30%;
  background-color: rgba(148, 148, 148, 0.515);
}
</style>