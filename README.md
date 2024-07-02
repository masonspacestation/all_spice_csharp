# AllSpice
Full Stack Application: Vue.js, C#, MySQL, API

#### Andrew Mason
#### Completed June 2024
#### Live Site: [AllSpice](https://all_spice_csharp.andrewmason.dev/)

***

AllSpice allows users to create recipes and add them to a shared collection of user-submitted recipes. AllSpice is a full-stack application where I used Vue.js on the front end. I created a .NET and C# API, and stored user-submitted content in a mySQL database.

### Improved Skills
This app focused a lot on data relationships and reactivity. Recipes are tied to ingredients (one-to-many), and to a creator (one-to-one). Recipes can be edited or deleted by their creator. The creator can also add or remove ingredients as needed. Users can favorite or 'un-favorite' any recipe, and that favorite is a one to one relationship object between the recipe and the user.

### Edit Upon Creation
Recipes are created through a simple form. I chose to give users the ability to quickly jot down a title, category, and image to create a placeholder recipe without getting bogged down with instructions and ingredients. I set the create function to swap the modal view to take them to instantly have the option of adding instructions and ingredients if they have the time for it right then.

### Integrated Edits
Ingredients are simple to add or remove while looking at a recipe. The form to add them is built into a dropdown button. They can be deleted directly from the list.

### Requirements
- Users can Register, login and are automatically authenticated on refresh

- Visitors can see all recipes (login not required)

-Users can sort recipes by category

- All users have a public profile page

- Logged in users can: 
	- Create and Delete Recipes
	- Mark Recipes as 'favorites'
	- Edit their account and public profile

- The owner of a recipe can:
	- Edit the recipe instructions
	- Delete the recipe
	- Add or delete ingredients

- Back end must pass all Postman tests for valid authorization, no authorization, and invalid authorization

- Basic form validation using a combination of input types

- UI adheres to Web UI, Accessibility, and Professional Standards
