/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"




class RecipesService{
  async getRecipeById(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}`)
    console.log(`found recipe with id: ${recipeId}`, response.data);
    const activeRecipe = new Recipe(response.data)
    AppState.activeRecipe = activeRecipe
    console.log("Active Recipe in AppState:", AppState.activeRecipe);
  }

  async getAllRecipes(){
  const response = await api.get('api/recipes')
  console.log('retrieved all recipes 😋', response.data);
  const recipes = response.data.map(recipesData => new Recipe(recipesData))
  AppState.recipes = recipes
  console.log('All recipes in AppState', AppState.recipes);
}
}


export const recipesService = new RecipesService