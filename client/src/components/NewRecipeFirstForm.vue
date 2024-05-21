<!-- eslint-disable no-console -->
<script setup>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { Modal } from "bootstrap";


const recipeData = ref({
  title: '',
  category: '',
  // instructions: 'wake up, make coffee, boom! breakfast!',
  img: 'https://images.unsplash.com/photo-1504754524776-8f4f37790ca0?q=80&w=3270&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
})

function resetFirstForm() {
  recipeData.value = {
    title: '',
    category: '',
    // instructions: '',
    img: '',
  }
}

// const imgPreview = ref({
//   recipeData.value.img
// })

async function createRecipe() {
  try {
    const newRecipe = await recipesService.createRecipe(recipeData.value)
    Modal.getOrCreateInstance('#new-recipe-modal').hide()
    Pop.toast('New recipe created!')
    console.log('New recipe!');
  } catch (error) {
    Pop.toast('Could not create recipe')
    console.error('Error creating recipe', 'error')
  }
  resetFirstForm()
}

// async function modalCancel() {
//   resetFirstForm()
//   Modal.getOrCreateInstance('#new-recipe-modal').hide()
// }

</script>


<template>
  <div class="container">
    <form @submit.prevent="createRecipe">
      <div class="row">
        <div class="modal-header">
          <h3>
            Create your own recipe!
          </h3>
        </div>
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
        <!-- <div class="col-8">
          <label for="recipe-instructions"></label>
          <textarea v-model="recipeData.instructions" type="text" rows="6" name="recipe-instructions"
            id="recipe-instructions" class="form-control" minlength="10" maxlength="5000" required></textarea>
        </div> -->
        <div class="col-4">
          <label for="recipe-img"></label>
          <input v-model="recipeData.img" type="text" name="recipe-img" id="recipe-img" class="form-control mb-1"
            minlength="3" maxlength="1000" required>
          <img :src="recipeData.img" alt="" class="img-preview rounded">
        </div>
      </div>
      <div class="row">

        <div class="col-6 my-3 p-3"><button type="reset" data-bs-toggle="modal" data-bs-target="modal"
            class="btn btn-secondary w-100">Cancel</button></div>
        <div class="col-6 my-3 p-3"><button class="btn btn-primary w-100">Create Recipe</button>
        </div>
      </div>
    </form>

  </div>

</template>


<style lang="scss" scoped>
.img-preview {
  width: 100%;
  max-height: 12dvh;
  object-fit: cover;
}
</style>