<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted, ref } from "vue";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";

// const recipe = computed(() => AppState.recipes)

const filterBy = ref('all')

const recipes = computed(() => {
  if (filterBy.value == 'all') return AppState.recipes
  return AppState.recipes.filter(recipe => recipe.category == filterBy.value)
})

const filters = [
  // {
  //   name: 'all',
  //   title: 'All'
  // },
  {
    name: 'breakfast',
    title: 'Breakfast'
  },
  {
    name: 'lunch',
    title: 'Lunch'
  },
  {
    name: 'dinner',
    title: 'Dinner'
  },
  {
    name: 'snack',
    title: 'Snack'
  },
  {
    name: 'dessert',
    title: 'Dessert'
  },
]

async function getAllRecipes() {
  try {
    console.log('going out for recipes');
    await recipesService.getAllRecipes()
  } catch (error) {
    Pop.toast('Could not get recipes', 'error')
  }
}

async function getFavoriteRecipes() {

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
    <div class="row justify-content-center text-center mb-1 border-bottom py-0">
      <div v-for="filterObj in filters" :key="filterObj.name" class="col-2">
        <div v-if="filterBy.valueOf() == filterObj.name" role="button" @click="filterBy = filterObj.name">
          <h5 class="py-3">{{ filterObj.title }}</h5>
          <hr class="border-3 border-primary w-75 mx-auto my-0 py-0">
        </div>
        <div v-else role="button" @click="filterBy = filterObj.name" class="filter-button rounded">
          <h5 class="py-3">{{ filterObj.title }}</h5>
        </div>
      </div>

    </div>
    <div class="row justify-content-end clear-filter-row mb-5"><small v-if="filterBy.valueOf() != 'all'"
        class="text-end filter-button cancel-filter-button w-auto py-auto rounded" role="button"
        @click="filterBy = 'all'"><i class="mdi mdi-close-circle-outline"></i> clear
        filter</small>
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
      <p>
        The spice must flow 🧿
      </p>
    </div>





  </section>
  <ModalWrapper modalId="recipe-modal">
    <!-- <RecipeView /> -->
  </ModalWrapper>
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

.filter-button:hover {
  background-color: rgba(173, 216, 230, 0.45);

}

.cancel-filter-button:hover {
  background-color: rgba(229, 138, 138, 0.2);
}

.clear-filter-row {
  height: 1.5em;
  ;
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
</style>
