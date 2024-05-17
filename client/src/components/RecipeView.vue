<script setup>
import { Recipe } from "../models/Recipe.js";

const props = defineProps({ recipe: { type: Recipe, required: true } })
</script>


<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-4">
        <h2>{{ recipe.title }}</h2>
      </div>
      <div class="col-8">
        <p>
          {{ recipe.instructions }}
        </p>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>