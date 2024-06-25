/* eslint-disable no-console */
import { AppState } from "../AppState.js";
import { FavoritedRecipe } from "../models/FavoritedRecipe.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js"




class FavoritesService{
  async destroyFavoriteRecipe(favoriteId) {
const favorites = AppState.favoritedRecipes;
const favoriteIndex = favorites.findIndex(favorite => favorite.favoriteId == favoriteId)
    const response = await api.delete(`api/favorites/${favoriteId}`)
    if(favoriteIndex == -1) throw new Error("Find by index for favorites needs adjusted");
      favorites.splice(favoriteIndex, 1)
  }

async getFavoriteById(favoriteId){
  const response = await api.get(`api/favorites/${favoriteId}`)
  console.log('Finding favorite', response.data);
  const favorite = new FavoritedRecipe(response.data)
  return favorite
}

  async createFavoriteRecipe(recipeId) {
    const response = await api.post('api/favorites', recipeId)
    console.log('favorite', response.data);
    const newFavorite = new FavoritedRecipe(response.data)
    AppState.favoritedRecipes.unshift(newFavorite)
  }

}


export const favoritesService = new FavoritesService()