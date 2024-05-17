import { Account } from "./Account.js"
import { Ingredient } from "./Ingredient.js"




export class FavoritedRecipe{
  constructor(data){
    this.id = data.id
    this.creatorId = data.creatorId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
// favorite info
    this.favoriteId = data.favoriteId
    this.accountId = data.accountId
    this.recipeId = data.recipeId
//recipe info
this.title = data.title
this.instructions = data.instructions
this.img = data.img
this.category = data.category

this.creator = data.creator? new Account(data.creator) : null
this.ingredients = data.ingredients? new Ingredient(data.ingredients) : null
  }
}