import { Account } from "./Account.js"




export class Ingredient{
  constructor(data){
    this.id = data.id
    this.creatorId = data.creatorId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)

    this.name = data.name
    this.quantity = data.quantity
    this.recipeId = data.recipeId
    // this.creator = data.creator? new Account(data.creator) : null
  }
}