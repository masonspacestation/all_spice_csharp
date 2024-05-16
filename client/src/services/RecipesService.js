import { api } from "./AxiosService.js"




class RecipesService{
  async getRecipeById(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}`)
    console.log(`found recipe with id: ${recipeId}`);
  }

  async getAllRecipes(){
  const response = await api.get('api/recipes')
  console.log('retrieved all recipes 😋');
}
}


export const recipesService = new RecipesService