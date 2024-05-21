/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { FavoritedRecipe } from "../models/FavoritedRecipe.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js"




class FavoritesService{
  async destroyFavoriteRecipe(favoriteId) {
    const response = await api.delete(`api/favorites/${favoriteId}`)
    console.log(`Deleting favorite`, response.data);
  }
  async createFavoriteRecipe(recipeId) {
    const response = await api.post('api/favorites', recipeId)
    console.log('favorite', response.data);
    const newFavorite = new FavoritedRecipe(response.data)
    AppState.favoritedRecipes.unshift(newFavorite)
  }

}


export const favoritesService = new FavoritesService()