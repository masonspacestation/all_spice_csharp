<!-- eslint-disable no-console -->
<script setup>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { Modal } from "bootstrap";


const recipeData = ref({
  title: '',
  category: '',
  instructions: '',
  img: '',
})

function resetFirstForm() {
  recipeData.value = {
    title: '',
    category: '',
    instructions: '',
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
  <form @submit.prevent="createRecipe">
    <div class="container">

      <div class="row pt-4 pb-2 bg-success">
        <h3>
          Create your own recipe!
        </h3>
      </div>
      <div class="row px-2 ps-lg-2 pe-lg-0 border-bottom">
        <div class="col-12 col-lg-8 pt-3 pe-lg-3 pt-lg-4 d-flex flex-column justify-content-around">

          <div class="row form-floating p-1">
            <input v-model="recipeData.title" type="text" name="recipe-title" id="recipe-title"
              class="form-control mb-3" minlength="3" maxlength="50" placeholder="Recipe Title" required>
            <label for="recipe-title">Recipe Title</label>
          </div>

          <div class="row p-0">
            <div class="col-12 col-lg-6 form-floating p-1">
              <!-- <label for="recipe-category"></label> -->
              <select v-model="recipeData.category" name="recipe-category" id="recipe-category"
                class="form-control mb-3" required>
                <option class="text-secondary" value="" default>Select Category</option>
                <option value="breakfast">Breakfast</option>
                <option value="lunch">Lunch</option>
                <option value="dinner">Dinner</option>
                <option value="snack">Snack</option>
                <option value="dessert">Dessert</option>
              </select>
            </div>

            <div class="col-12 col-lg-6 form-floating p-1">
              <input v-model="recipeData.img" type="text" name="recipe-img" id="recipe-img" class="form-control mb-3"
                minlength="3" maxlength="1000" placeholder="Image URL" required>
              <label for="recipe-img">Image URL</label>
            </div>
          </div>

          <!-- <hr class="border-2 border-success opacity-100 m-0 p-0"> -->
        </div>
        <!-- end of form fields -->

        <div class="col-12 col-lg-4 px-2 p-lg-0">
          <img :src="recipeData.img" alt="" class="img-preview">
        </div>
      </div>


      <div class="row px-1 pb-2">
        <div class="col-12 col-lg-6 my-1 my-lg-3"><button type="reset" data-bs-toggle="modal" data-bs-target="modal"
            class="btn btn-outline-secondary border-2 text-dark w-100">Cancel</button></div>
        <div class="col-12 col-lg-6 my-1 my-lg-3"><button class="btn btn-primary w-100">Create Recipe</button>
        </div>
      </div>
    </div>

  </form>


</template>


<style lang="scss" scoped>
.img-preview {
  width: 100%;
  height: 25dvh;
  object-fit: cover;
  object-position: center;
}
</style>