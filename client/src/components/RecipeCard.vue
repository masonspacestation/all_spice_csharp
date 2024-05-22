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
const account = computed(() => AppState.account)

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

  <div class="recipe-card rounded rounded-3 shadow row align-items-end">


    <!-- <div class="category-icon rounded rounded-pill p-2 mt-3 ms-3 bg-success">
        <h3 class="d-inline mx-1">{{ recipe.icon }}</h3>
        <h3 v-if="recipe.creatorId == account?.id" class="d-inline mx-1">🤌</h3>
      </div> -->


    <!-- <i role="button" @click="createFavoriteRecipe(recipe.id)"
        class="mdi mdi-heart-outline mt-1 me-2 fs-3 text-light opacity-50 text-end"></i> -->
    <!-- v-if="favoritedRecipes.includes((favorite) => favoriteId == recipe.id)"  -->
    <!-- <i role="button" @click="deleteFavoriteRecipe(recipe.id)" class="mdi mdi-heart mt-1 me-2 fs-3 text-end"></i> -->
    <div class="p-0 col-12">
      <div class="title-cover p-2 pt-0 my-0">
        <hr class="border-light border-2 p-0 m-0 mb-1 w-75 opacity-100">
        <h4 class="fs-5 text-light">{{ recipe.title }}</h4>
      </div>
      <div class="row card-cover align-items-center rounded-bottom-3 bg-info p-2 pt-3 m-0">
        <small class="text-light w-auto">By <strong>{{ recipe.creator.name }}</strong></small>
        <div class="category-icon bg-info border border-light rounded rounded-pill px-2 py-1 ms-auto">
          <small class="text-light mx-1">{{ recipe.category }}</small>
          <span class="d-inline mx-1">{{ recipe.categoryTag }}</span>
          <h6 v-if="recipe.creatorId == account?.id" class="d-inline mx-1">🤌</h6>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.recipe-card {
  height: 30dvh;
  background-image: linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)), v-bind(bgStyle);
  background-position: center;
  background-size: cover;
}

// .card-cover {
// height: 30%;
// background-color: rgb(148, 148, 148);
// }

.title-cover {
  height: 3em;

}

.category-icon {
  width: max-content;
}
</style>