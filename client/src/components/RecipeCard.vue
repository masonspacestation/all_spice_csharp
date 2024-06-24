<!-- eslint-disable no-console -->
<script setup>
import { computed, ref } from "vue";
import { Recipe } from "../models/Recipe.js";
import Pop from "../utils/Pop.js";
import { favoritesService } from "../services/FavoritesService.js";
import { AppState } from "../AppState.js";

const props = defineProps({ recipe: { type: Recipe, required: true } })
const bgStyle = computed(() => `url(${props.recipe.img})`)
const favoritedRecipes = computed(() => AppState.favoritedRecipes)
const account = computed(() => AppState.account)

const recipeData = {}
const filterBy = ref('all')

const filters = [
  // {
  //   name: 'all',
  //   title: 'All'
  // },
  {
    name: 'breakfast',
    title: 'Breakfast',
    icon: '🍳',
  },
  {
    name: 'lunch',
    title: 'Lunch',
    icon: '🥪'
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

</script>


<template>

  <div class="recipe-card rounded rounded-3 shadow row align-items-end">
    <div class="p-0 col-12">
      <div class="title-cover p-3 pt-0 my-0">
        <!-- <hr class="border-light border-2 p-0 m-0 mb-1 w-75 opacity-100"> -->
        <h4 class="fs-5 text-light">{{ recipe.title }}</h4>
      </div>

      <div class="row card-cover align-items-center rounded-bottom-3 bg-success p-2 pt-3 m-0">
        <small class="text-light w-auto">By <strong>{{ recipe.creator.name }}</strong></small>
        <div class="category-icon  border border-light rounded rounded-pill px-2 py-1 ms-auto">
          <!-- <small class="text-light mx-1">{{ recipe.category }}</small> -->
          <span class="d-inline mx-1">{{ recipe.categoryTag }}</span>
          <h6 v-if="recipe.creatorId == account?.id" class="d-inline mx-1">🤌</h6>
        </div>
      </div>
    </div>
  </div>


</template>


<style lang="scss" scoped>
.recipe-card {
  height: 30dvh;
  background-image: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), v-bind(bgStyle);
  // background-image: linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)), v-bind(bgStyle);
  background-position: center;
  background-size: cover;
}

// .card-cover {
// height: 30%;
// background-color: rgb(148, 148, 148);
// }

.title-cover {
  height: 3em;

}

.category-icon {
  width: max-content;
}
</style>