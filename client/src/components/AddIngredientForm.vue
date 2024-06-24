<script setup>
import { computed, ref } from "vue";
import { AppState } from "../AppState.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";
const activeRecipe = computed(() => AppState.activeRecipe)

const ingredientData = ref({
  name: '',
  quantity: '',
  recipeId: activeRecipe.value.id,
})

function resetIngredientForm() {
  ingredientData.value = {
    name: '',
    quantity: '',
    recipeId: activeRecipe.value.id,
  }
}

async function createIngredient() {
  try {
    const newIngredient = await ingredientsService.createIngredient(ingredientData.value)
    console.log("Creating ingredient", ingredientData.value.name);
  } catch (error) {
    Pop.toast("Could not add ingredient", "error")
    console.error("Error adding ingredient", error)
  }
  Pop.toast('Added ingredient', 'success')
  resetIngredientForm()
}
</script>


<template>
  <section class="container p-0 m-0 text-center text-lg-end">

    <div class="dropdown">
      <button type="button" class="btn btn-primary dropdown-toggle fs-6" data-bs-toggle="dropdown" aria-expanded="false"
        data-bs-auto-close="outside" title="Add Ingredient">
        Add Ingredient
      </button>
      <form @submit.prevent="createIngredient()"
        class="dropdown-menu dropdown-menu-end shadow col-12 col-lg-8 p-4 p-lg-1" style="">
        <div class="row justify-content-center px-lg-3 justify-content-lg-between align-content-center">
          <div class="col-12 col-lg-6 text-center mb-3 p-lg-1 my-lg-2 form-floating">
            <input v-model="ingredientData.name" type="text" name="ingredient-name" placeholder="Ingredient Name"
              id="ingredient-name" class="form-control" minlength="3" maxlength="50" required title="Ingredient Name">
            <label for="ingredient-name">Ingredient Name</label>
          </div>
          <div class="col-12 col-lg-4 text-center mb-3 p-lg-1 my-lg-2 form-floating">
            <input v-model="ingredientData.quantity" type="text" name="ingredient-quantity"
              placeholder="Ingredient Quantity" id="ingredient-quantity" class="form-control" minlength="1"
              maxlength="50" required title="Ingredient Quantity">
            <label for="ingredient-quantity">Quantity</label>
          </div>
          <div class="col-6 col-lg-2 d-flex flex-column justify-content-center text-center">
            <button type="submit"
              class="btn btn-primary rounded rounded-pill m-auto fw-bold d-block d-lg-none">Add</button>
            <button type="submit" class="btn btn-primary rounded rounded-5 w-auto fw-bold d-none d-lg-block"
              :title="`Add ${ingredientData.quantity} ${ingredientData.name} to recipe`">+</button>
          </div>
        </div>
      </form>
    </div>

  </section>


  <!-- <form @submit.prevent="createIngredient()">
    <div class="form-floating col-12 mb-2">
      <input v-model="ingredientData.name" type="text" name="ingredient-name" placeholder="Ingredient Name"
        id="ingredient-name" class="form-control" minlength="3" maxlength="50" required>
      <label for="ingredient-name">Ingredient Name</label>
    </div>

    <div class="form-floating col-12">
      <input v-model="ingredientData.quantity" type="text" name="ingredient-quantity" placeholder="Ingredient Quantity"
        id="ingredient-quantity" class="form-control" minlength="1" maxlength="50" required>
      <label for="ingredient-quantity">Ingredient Quantity</label>
    </div>

    <button class="btn btn-secondary rounded rounded-pill">+</button>
  </form> -->
</template>


<style lang="scss" scoped></style>