import { Account } from "./Account.js"
import { Ingredient } from "./Ingredient.js"


function getIcon(category){
  switch(category){
    case "breakfast":
      return "🍳";
      case "lunch":
        return "🥪";
        case "dinner":
          return "🍕";
        case "snack":
          return "🍿";
        case "dessert":
          return "🍦";
  }
}

export class Recipe{
  constructor(data){
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.icon = data.icon ? data.icon : getIcon(data.category)

    this.id = data.id
    this.creatorId = data.creatorId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)

    this.creator = data.creator? new Account(data.creator) : null
    this.ingredients = data.ingredients? new Ingredient(data.ingredients) : null
  }
}