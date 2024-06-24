/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"




class RecipesService{
  async createRecipe(recipeData) {
const response = await api.post('api/recipes', recipeData)
console.log('Creating new recipe', response.data);
const newRecipe = new Recipe(response.data)
AppState.recipes.push(newRecipe)
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
  
  if(recipeIndex == -1) throw new Error('findIndex needs adjusted')
    console.log(`deleting recipe ${recipeId}`, response.data);
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
  // await this.getRecipeIngredients(recipeId)
  AppState.activeRecipe = activeRecipe
  console.log("Active Recipe in AppState:", AppState.activeRecipe);
}

async getRecipeIngredients(recipeId) {
  const response = await api.get(`api/recipes/${recipeId}/ingredients`)
  console.log('Getting ingredients', response.data);
  const ingredients = response.data.map(recipeId => new Ingredient(recipeId))
  AppState.ingredients = ingredients
}

// FIXME this is started, but not referenced from anywhere, and probably not right
async updateRecipe(recipeData, recipeId){
  const response = await api.put(`api/recipes/${recipeId}`, recipeData)
  console.log(`Updating recipe: ${recipeData.id}`, response.data);
  AppState.activeRecipe = new Recipe(response.data)
}

}


export const recipesService = new RecipesService()