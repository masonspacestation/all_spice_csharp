<!-- eslint-disable no-console -->
<script setup>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";


const recipeData = ref({
  title: '',
  category: '',
  instructions: 'wake up, make coffee, boom! breakfast!',
  img: 'https://images.unsplash.com/photo-1504754524776-8f4f37790ca0?q=80&w=3270&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
})

function resetFirstForm() {
  recipeData.value = {
    title: '',
    category: '',
    instructions: '',
    img: '',
  }
}

async function createRecipe() {
  try {
    const newRecipe = await recipesService.createRecipe(recipeData.value)
    resetFirstForm()
    Pop.toast('New recipe created!')
    console.log('New recipe!');
  } catch (error) {
    Pop.toast('Could not create recipe')
    console.error('Error creating recipe', 'error')
  }
}

</script>


<template>
  <div class="container">
    <form @submit.prevent="createRecipe">
      <div class="row">
        <div class="col-8">
          <label for="recipe-title"></label>
          <input v-model="recipeData.title" type="text" name="recipe-title" id="recipe-title" class="form-control"
            minlength="3" maxlength="50" required>
        </div>

        <div class="col-4">
          <label for="recipe-category"></label>
          <select v-model="recipeData.category" name="recipe-category" id="recipe-category" class="form-control"
            required>
            <option class="text-secondary" value="" default>Select Category</option>
            <option value="breakfast">Breakfast</option>
            <option value="lunch">Lunch</option>
            <option value="dinner">Dinner</option>
            <option value="snack">Snack</option>
            <option value="dessert">Dessert</option>
          </select>
        </div>

      </div>
      <div class="row">

        <div class="col-6 my-3 p-3"><button type="reset" class="btn btn-secondary w-100">Cancel</button></div>
        <div class="col-6 my-3 p-3"><button class="btn btn-primary w-100">Create Recipe</button>
        </div>
      </div>
    </form>

  </div>

</template>


<style lang="scss" scoped></style>