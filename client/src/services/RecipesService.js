/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"




class RecipesService{
  async getRecipeById(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}`)
    console.log(`found recipe with id: ${recipeId}`, response.data);
    const recipe = new Recipe(response.data)
    return recipe
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

}


export const recipesService = new RecipesService