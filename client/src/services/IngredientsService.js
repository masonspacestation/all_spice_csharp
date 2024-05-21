/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";
import { recipesService } from "./RecipesService.js";




class IngredientsService{


  async getIngredientById(ingredientId){
      const response = await api.get(`api/ingredients/${ingredientId}`)
      console.log(`found ingredient with id: ${ingredientId}`, response.data);
      const ingredient = new Ingredient(response.data)
      return ingredient
 } 

 async destroyIngredient(ingredientId){
  const ingredients = AppState.ingredients
  const ingredientIndex = ingredients.findIndex(ingredient => ingredient.id == ingredientId)
  const response = await api.delete(`api/ingredients/${ingredientId}`)

  if (ingredientIndex == -1) throw new Error('Find by index for ingredients needs adjusted')
    console.log(`Deleting ingredient ${ingredientId}`), response.data;
    ingredients.splice(ingredientIndex, 1)
 }

}


export const ingredientsService = new IngredientsService()