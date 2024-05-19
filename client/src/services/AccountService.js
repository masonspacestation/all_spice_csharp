/* eslint-disable no-console */
import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { FavoritedRecipe } from "../models/FavoritedRecipe.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
    this.getFavoriteRecipes()
  }
  async getFavoriteRecipes() {
    const response = await api.get('/account/favorites')
    console.log('getting user favorites', response.data);
    const favoriteRecipes = response.data.map(favoriteData => new FavoritedRecipe(favoriteData))
    AppState.favoritedRecipes = favoriteRecipes
    console.log('😋 favorites', AppState.favoritedRecipes);
  }


}

export const accountService = new AccountService()
