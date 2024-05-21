<!-- eslint-disable no-console -->
<script setup>
import { computed, ref } from "vue";
import { Recipe } from "../models/Recipe.js";
import Pop from "../utils/Pop.js";
import { favoritesService } from "../services/FavoritesService.js";
import { AppState } from "../AppState.js";

const props = defineProps({ recipe: { type: Recipe, required: true } })
const bgStyle = computed(() => `url(${props.recipe.img})`)
const favoritedRecipes = computed(() => AppState.favoritedRecipes)

const recipeData = {}
const filterBy = ref('all')

const filters = [
  // {
  //   name: 'all',
  //   title: 'All'
  // },
  {
    name: 'breakfast',
    title: 'Breakfast',
    icon: '🍳',
  },
  {
    name: 'lunch',
    title: 'Lunch',
    icon: '🥪',
  },
  {
    name: 'dinner',
    title: 'Dinner',
    icon: '🍕',
  },
  {
    name: 'snack',
    title: 'Snack',
    icon: '🍿',
  },
  {
    name: 'dessert',
    title: 'Dessert',
    icon: '🍦',
  },
]

async function createFavoriteRecipe(recipeId) {
  try {
    recipeData.recipeId = recipeId
    await favoritesService.createFavoriteRecipe(recipeData)
  } catch (error) {
    Pop.toast("Could not add to your favorites", "error")
    console.error("Error adding to favorites", error)
  }
  Pop.toast('Added Favorite!', 'success')
}

</script>


<template>

  <div class="recipe-card rounded rounded-3 shadow d-flex flex-column justify-content-between">
    <!-- FIXME make the icon dynamic -->
    <div class="row justify-content-end py-2 px-4">

      <h4 class="rounded rounded-pill w-auto p-2 bg-success text-end">🍕</h4>
    </div>
    <!-- <i role="button" @click="createFavoriteRecipe(recipe.id)"
      class="mdi mdi-heart-outline mt-1 me-2 fs-3 text-light opacity-50 text-end"></i> -->
    <!-- v-if="favoritedRecipes.includes((favorite) => favoriteId == recipe.id)"  -->
    <!-- <i role="button" @click="deleteFavoriteRecipe(recipe.id)" class="mdi mdi-heart mt-1 me-2 fs-3 text-end"></i> -->
    <div class="card-cover p-2">
      <h3 class="fs-4 text-light">{{ recipe.title }}</h3>
    </div>
  </div>

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