





namespace all_spice_csharp.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }


  private Ingredient PopulateCreator(Ingredient ingredient, Profile profile)
  {
    ingredient.CreatorId = profile.Id;
    return ingredient;
  }
  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
        INSERT INTO
        ingredients(name, quantity, recipeId, creatorId)
        VALUES(@Name, @Quantity, @RecipeId, @CreatorId);

        SELECT
        ingredients.*,
        accounts.*
        FROM ingredients
        JOIN accounts ON accounts.id = ingredients.creatorId
        WHERE ingredients.id = LAST_INSERT_ID()

        ;";
    // Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, PopulateCreator, ingredientData).FirstOrDefault();
    Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
    {
      ingredient.CreatorId = profile.Id;
      return ingredient;
    }, ingredientData).FirstOrDefault();
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
        SELECT
        ingredients.*,
        recipes.*
        FROM
        ingredients

JOIN recipes ON recipes.id = ingredients.recipeId
WHERE ingredients.recipeId = @recipeId
        ;";

    List<Ingredient> ingredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;

  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    string sql = @"
        SELECT
        ingredients.*,
        accounts.*
        FROM
        ingredients

        JOIN accounts ON ingredients.creatorId = accounts.id
        WHERE ingredients.id = @ingredientId;";

    Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, PopulateCreator, new { ingredientId }).FirstOrDefault();
    return ingredient;
  }

  internal void DestroyIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE ingredients.id = @ingredientId;";
    _db.Execute(sql, new { ingredientId });

  }
}