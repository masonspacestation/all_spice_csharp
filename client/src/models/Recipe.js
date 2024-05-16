import { Account } from "./Account.js"
import { Ingredient } from "./Ingredient.js"




export class Recipe{
  constructor(data){
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category

    this.id = data.id
    this.creatorId = data.creatorId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)

    this.creator = data.creator? new Account(data.creator) : null
    this.ingredients = data.ingredients? new Ingredient(data.ingredients) : null
  }
}