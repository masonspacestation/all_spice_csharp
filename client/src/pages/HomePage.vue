<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted, ref } from "vue";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";
import { accountService } from "../services/AccountService.js";
import { Modal } from "bootstrap";
import ModalWrapper from "../components/ModalWrapper.vue";
import NewRecipeFirstForm from "../components/NewRecipeFirstForm.vue";
import RecipeView from "../components/RecipeView.vue";
import { ingredientsService } from "../services/IngredientsService.js";


const filterBy = ref('all')
const account = computed(() => AppState.account)
// const favoritedRecipes = computed(() => AppState.favoritedRecipes)

const recipes = computed(() => {
  if (filterBy.value == 'all') return AppState.recipes
  return AppState.recipes.filter(recipe => recipe.category == filterBy.value)
})

const filters = [
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

async function getAllRecipes() {
  try {
    console.log('going out for recipes');
    await recipesService.getAllRecipes()
  } catch (error) {
    Pop.toast('Could not get recipes', 'error')
  }
}


async function setActiveRecipe(recipeId) {
  try {
    AppState.activeRecipe = null
    AppState.ingredients = null
    console.log(`Setting ${recipeId} to active`);
    await recipesService.getRecipeIngredients(recipeId)
    await recipesService.setActiveRecipe(recipeId)
  } catch (error) {
    Pop.toast('Could not find that recipe')
  }
}

onMounted(() => {
  getAllRecipes()
  // getFavoriteRecipes()
})
</script>

<template>
  <section class="container mt-5">
    <div class="row hero-section rounded rounded-3 shadow mt-2 mx-0 mb-5">
      <Navbar />
    </div>

    <!-- SECTION add recipe floating button -->
    <div v-if="account" class="add-recipe-button w-auto">
      <button class="btn btn-primary round-button shadow" id="add-recipe-round" data-bs-toggle="modal"
        data-bs-target="#create-recipe-modal">+</button>
      <button class="btn btn-primary rounded rounded-pill fw-bold px-4 shadow" id="add-recipe-full"
        data-bs-toggle="modal" data-bs-target="#create-recipe-modal">+ Add Recipe</button>
    </div>

    <!-- SECTION category filters -->
    <div class="row justify-content-center text-center mb-1 filter-buttons-row py-0">
      <div v-for="filterObj in filters" :key="filterObj.name" class="col col-lg-2">
        <div v-if="filterBy.valueOf() == filterObj.name" role="button" @click="filterBy = filterObj.name">
          <h6 class="py-3 text-white text-uppercase">{{ filterObj.title }}</h6>
          <hr class="border-3 border-success opacity-100 w-75 mx-auto my-0 py-0">
        </div>
        <div v-else role="button" @click="filterBy = filterObj.name" class="filter-button rounded">
          <h6 class="py-3 text-secondary fw-light text-uppercase">{{ filterObj.title }}</h6>
        </div>
      </div>

    </div>
    <div class="row justify-content-end clear-filter-row mb-5"><small v-if="filterBy.valueOf() != 'all'"
        class="text-end text-white opacity-50 filter-button cancel-filter-button w-auto py-auto rounded" role="button"
        @click="filterBy = 'all'"><i class="mdi mdi-close-circle-outline"></i> clear
        filter</small>
    </div>

    <!-- SECTION recipe card -->
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-6 col-lg-4 py-3 px-4" role="button"
        data-bs-toggle="modal" data-bs-target="#recipe-modal">
        <RecipeCard :recipe="recipe" @click="setActiveRecipe(recipe.id)" />
      </div>
    </div>

  </section>
  <ModalWrapper modalId="create-recipe-modal">
    <NewRecipeFirstForm />
  </ModalWrapper>

  <ModalWrapper modalId="recipe-modal">
    <RecipeView />
  </ModalWrapper>
</template>

<style scoped lang="scss">
.round-button {
  width: 3rem;
  height: 3rem;
  border-radius: 50%;
}

.add-recipe-button {
  position: fixed;
  bottom: 2rem;
  right: 2rem;
  padding: auto;

  #add-recipe-round {
    display: block;
    font-weight: bold;
    color: whitesmoke;
  }

  #add-recipe-full {
    display: none;
    font-weight: bold;
    color: whitesmoke;
  }
}

.add-recipe-button:hover {
  #add-recipe-round {
    display: none;
  }

  #add-recipe-full {
    display: block;
    height: 3rem;
  }
}

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

.filter-buttons-row {
  border-bottom: .5px rgba(173, 169, 183, 0.45) solid;
}

.filter-button:hover {
  background-color: rgba(173, 169, 183, 0.45);

}

.cancel-filter-button:hover {
  background-color: rgba(173, 169, 183, 0.45);
}

.clear-filter-row {
  height: 1.5em;
  ;
}

.hero-section {
  height: 20dvh;
  background-image: url("https://images.unsplash.com/photo-1509358271058-acd22cc93898?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
  // background-image: url(src/assets/img/calum-lewis-vA1L1jRTM70-unsplash.jpg);
  background-position: center;
  background-size: cover;

  >img {
    transform: rotate(90deg);
  }

  // text-shadow: 0px 0px 10px black;
  // filter: contrast(.8);
}
</style>
