/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"




class RecipesService{
  async createRecipe(recipeData) {
const response = await api.post('api/recipes', recipeData)
console.log('Creating new recipe', response.data);
  }
  async getRecipeById(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}`)
    console.log(`found recipe with id: ${recipeId}`, response.data);
    const recipe = new Recipe(response.data)
    return recipe
  }

async destroyRecipe(recipeId){
  const recipes = AppState.recipes
  const recipeIndex = recipes.findIndex(recipe => recipe.id == recipeId)
  const response = await api.delete(`api/recipes/${recipeId}`)
  console.log(`deleting recipe ${recipeId}`, response.data);

  if(recipeIndex == -1) throw new Error('findIndex needs adjusted')
    recipes.splice(recipeIndex, 1)
  
}

  async getAllRecipes(){
  const response = await api.get('api/recipes')
  console.log('retrieved all recipes 😋', response.data);
  const recipes = response.data.map(recipesData => new Recipe(recipesData))
  AppState.recipes = recipes
  console.log('All recipes in AppState', AppState.recipes);
}

async setActiveRecipe(recipeId){
  const activeRecipe = await this.getRecipeById(recipeId)
  AppState.activeRecipe = activeRecipe
  console.log("Active Recipe in AppState:", AppState.activeRecipe);
}

async getRecipeIngredients(recipeId) {
  const response = await api.get(`api/recipes/${recipeId}/ingredients`)
  console.log('Getting ingredients', response.data);
  const ingredients = response.data.map(recipeId => new Recipe(recipeId))
  AppState.ingredients = ingredients
}

}


export const recipesService = new RecipesService()