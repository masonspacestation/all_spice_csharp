<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted } from "vue";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";

const recipes = computed(() => AppState.recipes)

async function getAllRecipes() {
  try {
    console.log('going out for recipes');
    await recipesService.getAllRecipes()
  } catch (error) {
    Pop.toast('Could not get recipes', 'error')
  }
}

async function getRecipeById(recipeId) {
  try {
    console.log(`Looking for the recipe with Id ${recipeId}`);
    await recipesService.getRecipeById(recipeId)
  } catch (error) {
    Pop.toast('Could not find that recipe')
  }
}


onMounted(() => {
  getAllRecipes()
})
</script>

<template>
  <section class="container">
    <div class="row hero-section rounded rounded-3 shadow mt-2 mb-5">
      <!-- <img
        src="https://images.unsplash.com/photo-1588959286493-eb5582aa5f39?q=80&w=2160&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
        class="" alt=""> -->
    </div>

    <!-- category filters -->
    <div class="row justify-content-center text-center mb-5 border-bottom py-0">
      <div class="col-2">
        <h5 class="pb-3">🍳 Breakfast</h5>
      </div>
      <div class="col-2">
        <h5 class="pb-3">🥪 Lunch</h5>
      </div>
      <!-- NOTE active category -->
      <div class="col-2">
        <h5 class="pb-3">🍕 Dinner</h5>
      </div>
      <div class="col-2">
        <h5 class="pb-3">🍿 Snacks</h5>
        <hr class="border-3 border-primary w-75 mx-auto my-0 ">
      </div>
      <div class="col-2">
        <h5 class="pb-3">🍦 Desserts</h5>
      </div>
    </div>


    <!-- default -->
    <div class="row">
      <!-- <div class="col-3 p-3">
        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Impedit officiis a eligendi, deserunt accusamus quae
          quam!</p>
        <button @click="getRecipeById(4)" class="btn btn-secondary text-light">Create</button>
      </div> -->
      <!-- NOTE recipe card -->
      <div v-for="recipe in recipes" :key="recipe.id" class="col-3 p-3">
        <RecipeCard :recipe="recipe" />
        <!-- <div class="recipe-card px-1 px-3 rounded rounded-3 shadow d-flex flex-column justify-content-between">
          <i class="mdi mdi-heart-outline fs-3 text-light opacity-50 text-end"></i>
          <h3 class="text-light">Recipe</h3>
        </div> -->
      </div>

    </div>

    <!-- filtered view -->
    <div class="row">
      <small><i class="mdi mdi-alpha-x-circle-outline"></i> clear filter</small>
      <p>
        It's alllll spice alllll the time, baby 😎
      </p>
    </div>





  </section>
</template>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
      // transform: rotate(90deg);
    }
  }
}



.hero-section {
  height: 20dvh;
  background-image: url("https://images.unsplash.com/photo-1588959286493-eb5582aa5f39?q=80&w=2160&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
  background-position: center;
  background-size: cover;

  >img {
    transform: rotate(90deg);
  }

  // text-shadow: 0px 0px 10px black;
  // filter: contrast(.8);
}

// .hero-section {
//   height: 20dvh;
//   background-image:
//   background-size: cover;
//   background-position: center;

// >img {
//   max-width: 100%;
//   width: 100%;
//   object-fit: cover;
//   object-position: center;
//   transform: rotate(90deg);
// }
// }</style>
