<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted } from "vue";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import FavoriteButton from "./FavoriteButton.vue";
import { favoritesService } from "../services/FavoritesService.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { Modal } from "bootstrap";

// const recipe = defineProps({ recipe: { type: Recipe, required: true } })
const activeRecipe = computed(() => AppState.activeRecipe)
const account = computed(() => AppState.account)


async function destroyFavoriteRecipe(favoriteId) {
  try {
    const wantsToDestroy = await Pop.confirm("Are you sure you want to delete this favorite recipe?")
    if (!wantsToDestroy) return

    await favoritesService.destroyFavoriteRecipe(favoriteId)
  } catch (error) {
    Pop.toast('Could not delete favorite recipe', 'error')
    console.error(error)
  }
}

async function destroyIngredient(ingredientId) {
  try {
    const wantsToDestroy = await Pop.confirm("Are you sure you want to delete this ingredient? It might change the flavor or consistency of your dish.")
    if (!wantsToDestroy) return

    await ingredientsService.destroyIngredient(ingredientId)
  } catch (error) {
    Pop.toast('Could not delete ingredient', 'error')
    console.error(error);
  }
}


async function destroyRecipe(recipeId) {
  try {
    const wantsToDestroy = await Pop.confirm("Are you sure you want to delete this recipe? What will we eat??")
    if (!wantsToDestroy) return

    await recipesService.destroyRecipe(recipeId)
  } catch (error) {
    Pop.toast('Could not delete favorite recipe', 'error')
    console.error(error)
  }
  Pop.toast("Recipe Deleted!", "success")
  Modal.getOrCreateInstance("#recipe-modal").hide()
}

async function getIngredientById(ingredientId) {
  try {
    await ingredientsService.getIngredientById(ingredientId)
  } catch (error) {
    Pop.toast(`Could not get ingredient by ID: ${ingredientId}`)
    console.error(error)
  }
}

async function getFavoriteById(favoriteId) {
  try {
    await favoritesService.getFavoriteById(favoriteId)
  } catch (error) {
    Pop.toast("Could not get favorite by Id")
    console.error(error)
  }
}



// async function getRecipeById(recipeId) {
//   try {
//     console.log(`Looking for the recipe with Id ${recipeId}`);
//     await recipesService.setActiveRecipe(recipeId)
//   } catch (error) {
//     Pop.toast('Could not find that recipe')
//   }
// }

// onMounted(() =>
//   getRecipeById(recipe.recipe.id)
// )

</script>


<template>
  <div v-if="activeRecipe" class="container-fluid">
    <div class="row justify-content-between">
      <div class="col-6">
        <h2>{{ activeRecipe.title }}</h2>
      </div>
      <div class="col-2 text-end">
        <FavoriteButton />
      </div>
      <div class="row">
        <div class="col-8">
          <p>
            {{ activeRecipe.instructions }}
          </p>
        </div>
      </div>
    </div>
    <div class="row">
      <div v-if="activeRecipe.creatorId = account.id">
        <i role="button" @click="destroyRecipe(activeRecipe.id)"
          class="mdi mdi-delete-outline text-danger opacity-50"></i>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>