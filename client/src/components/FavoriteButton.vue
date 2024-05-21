<script setup>
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { favoritesService } from "../services/FavoritesService.js";
import Pop from "../utils/Pop.js";

// const props = defineProps({ recipe: { type: Recipe, required: true } })

const recipeData = {}

async function createFavoriteRecipe() {
  try {
    recipeData.recipeId = AppState.activeRecipe.id
    await favoritesService.createFavoriteRecipe(recipeData)
  } catch (error) {
    Pop.toast("Could not add to your favorites", "error")
    console.error("Error adding to favorites", error)
  }
  Pop.toast('Added Favorite!', 'success')
}
</script>


<template>
  <i role="button" @click="createFavoriteRecipe()"
    class="mdi mdi-heart-outline mt-1 me-2 fs-3 text-dark opacity-50 text-end"></i>
</template>


<style lang="scss" scoped></style>