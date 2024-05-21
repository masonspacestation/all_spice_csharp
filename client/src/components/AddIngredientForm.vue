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
  <form @submit.prevent="createIngredient()">
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
  </form>
</template>


<style lang="scss" scoped></style>