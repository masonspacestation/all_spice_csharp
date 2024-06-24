<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted, ref } from "vue";
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import FavoriteButton from "./FavoriteButton.vue";
import { favoritesService } from "../services/FavoritesService.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { Modal } from "bootstrap";
import AddIngredientForm from "./AddIngredientForm.vue";

// const recipe = defineProps({ recipe: { type: Recipe, required: true } })
const activeRecipe = computed(() => AppState.activeRecipe)
const ingredients = computed(() => AppState.ingredients)
const account = computed(() => AppState.account)

// const props = defineProps({ recipe: { type: Recipe, required: true } })
const bgStyle = computed(() => `url(${activeRecipe.value?.img})`)

const recipeData = ref({
  // title: '',
  // category: '',
  instructions: '',
  // id: activeRecipe.value?.id,
  // img: 'https://images.unsplash.com/photo-1504754524776-8f4f37790ca0?q=80&w=3270&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
})

function resetFirstForm() {
  recipeData.value = {
    // title: '',
    // category: '',
    instructions: '',
    // id: activeRecipe.value?.id,
    // img: '',
  }
}

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

async function updateRecipe(recipeId) {
  try {
    // recipeData.value.id = recipeId
    console.log('updating recipe', activeRecipe.value.id);
    await recipesService.updateRecipe(recipeData.value, recipeId)
  } catch (error) {
    Pop.toast('Could not edit recipe', 'error')
    console.error(error)
  }
}

// async function getIngredientById(ingredientId) {
//   try {
//     await ingredientsService.getIngredientById(ingredientId)
//   } catch (error) {
//     Pop.toast(`Could not get ingredient by ID: ${ingredientId}`)
//     console.error(error)
//   }
// }

// async function getFavoriteById(favoriteId) {
//   try {
//     await favoritesService.getFavoriteById(favoriteId)
//   } catch (error) {
//     Pop.toast("Could not get favorite by Id")
//     console.error(error)
//   }
// }



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
      <div class="col-4 overflow-hidden recipe-image">
        <!-- <img class="recipe-image" :src="activeRecipe.img" alt=""> -->
      </div>


      <div class="col-8">
        <div class="row justify-content-between bg-secondary p-2 mb-3 text-light text-opacity-75">
          <div class="col-9">
            <h2>{{ activeRecipe.title }}</h2>
          </div>
          <div class="col-2 text-end">
            <div v-if="activeRecipe.creator.id == account?.id" class="text-end btn-group dropstart">
              <i role="button" class="mdi mdi-dots-horizontal fs-3" data-bs-toggle="dropdown"
                data-bs-auto-close="outside" aria-expanded="false"></i>

              <div>
                <ul class="dropdown-menu text-center w-auto p-1">
                  <i role="button" @click="destroyRecipe(activeRecipe.id)"
                    class="fs-3 m-2 mdi mdi-delete opacity-75"></i>
                  <FavoriteButton :recipe="activeRecipe" />
                </ul>
              </div>

            </div>
            <div v-else>
              <FavoriteButton :recipe="activeRecipe" />
            </div>
          </div>

          <!-- SECTION instructions -->
        </div>
        <div class="row justify-content-between p-2 pe-4">
          <div class="col-8 p-2">
            <div class="row justify-content-between align-items-center">
              <h4 class="w-auto">Instructions</h4>
              <!-- NOTE can edit instructions if recipe creator -->
              <i v-if="activeRecipe.creator.id == account?.id" class="mdi mdi-pencil w-auto fs-5 opacity-25"
                title="Edit Recipe"></i>
            </div>
            <!-- NOTE shows instructions if not null -->
            <!-- <div v-if="activeRecipe.instructions != null"> -->
            <div>
              <p>
                {{ activeRecipe.instructions }}
              </p>
              <!-- NOTE shows text area if instructions are null -->
              <div v-if="activeRecipe.creator.id == account?.id && activeRecipe.instructions == ''">
                <label for="recipe-instructions"></label>
                <textarea v-model="recipeData.instructions" type="text" rows="6" name="recipe-instructions"
                  id="recipe-instructions" class="form-control" minlength="10" maxlength="5000" required
                  :title="`Add instructions for ${activeRecipe.title} recipe.`"
                  :placeholder="`Add instructions for ${activeRecipe.title} recipe.`"></textarea>
                <button @click="updateRecipe(activeRecipe.id)" title="Save changes">Save</button>
              </div>
            </div>
          </div>
          <!-- SECTION ingredients -->
          <div class="col-3 d-flex flex-column justify-content-between p-0 pt-2 ps-3 ingredients">
            <div class="row">
              <h4>Ingredients</h4>
              <div v-for="ingredient in ingredients" :key="ingredient.id" class="mb-1 col-12 ingredient-list-item">
                <h6 class="fw-bold mb-0">{{ ingredient.name }}</h6>

                <div class="row">
                  <small class="text-secondary col-10">{{ ingredient.quantity }}</small>
                  <div v-if="activeRecipe.creator.id == account?.id" class="col-1 delete-icon">
                    <i role="button" @click="destroyIngredient(ingredient.id)"
                      class="mdi mdi-close-circle-outline text-danger opacity-75" title="Delete Ingredient"></i>
                  </div>
                </div>
                <hr class="border-1 mt-0">
              </div>
              <!-- SECTION add ingredient button -->
            </div>
          </div>
          <div v-if="activeRecipe.creator.id == account?.id" class="col-12">
            <AddIngredientForm />
          </div>
        </div>


      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.delete-icon {
  display: none;
  height: 1em;
}

.ingredients {
  border-left: 2px rgba(173, 169, 183, 0.5) solid;
}

.ingredient-list-item:hover {
  .delete-icon {
    display: block;
    // background-color: red;
  }
}

.recipe-image {
  // object-position: center;
  // object-fit: cover;
  background-image: v-bind(bgStyle);
  background-position: center;
  background-size: cover;
}
</style>