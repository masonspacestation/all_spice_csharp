import { api } from "./AxiosService.js"




class RecipesService{

  async getAllRecipes(){
  const response = await api.get('api/recipes')
  console.log('retrieved all recipes 😋');
}
}


export const recipesService = new RecipesService