/* eslint-disable no-console */
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";
import { recipesService } from "./RecipesService.js";




class IngredientsService{


  async getIngredientById(ingredientId){
      const response = await api.get(`api/${ingredientId}`)
      console.log(`found ingredient with id: ${ingredientId}`, response.data);
      const ingredient = new Ingredient(response.data)
      return ingredient
 } 


}


export const ingredientsService = new IngredientsService()