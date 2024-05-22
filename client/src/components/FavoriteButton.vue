<script setup>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { favoritesService } from "../services/FavoritesService.js";
import Pop from "../utils/Pop.js";

// const props = defineProps({ recipe: { type: Recipe, required: true } })

const recipeData = {}
const account = computed(() => AppState.account)
const recipe = computed(() => AppState.activeRecipe)
// const favorite = computed(() => AppState.favoritedRecipes.some(favorite => favorite.accountId == account?.value.id))
const myFavorites = computed(() => AppState.favoritedRecipes)

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
  <i v-if="myFavorites.some(favorite => favorite.id == recipe.id)" role="button" @click.prevent="createFavoriteRecipe()"
    class="mdi mdi-heart mt-1 me-2 fs-3 text-dark text-end"></i>
  <i v-else role="button" @click.prevent="createFavoriteRecipe()"
    class="mdi mdi-heart-outline mt-1 me-2 fs-3 text-dark text-end"></i>
</template>


<style lang="scss" scoped></style>