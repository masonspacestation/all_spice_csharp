
using Dapper;

namespace all_spice_csharp.Repositories;



public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal FavoritedRecipe CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
        INSERT INTO
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT
        favorites.*,
        accounts.*
        FROM favorites
        JOIN accounts ON favorites.accountId = accounts.id
        WHERE favorites.id = LAST_INSERT_ID();";

    FavoritedRecipe favorite = _db.Query<Favorite, FavoritedRecipe, FavoritedRecipe>(sql, (favorite, recipe) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = favorite.AccountId;
      return recipe;
    }, favoriteData).FirstOrDefault();
    return favorite;
    // Favorite favorite = await _db.Query<FavoritedRecipe, FavoritorProfile, Favorite>(sql, (recipe, profile) =>
    // {
    //   profile. = recipe.Id;
    //   profile.RecipeId = recipe.Idl
    //   return recipe;
    // }, favoriteData).FirstOrDefault();
    // return favorite;



    //     FavoritedRecipe favoriteRecipe = _db.Query<Favorite, FavoritorProfile, FavoritedRecipe>
    //     (sql, (favorite, profile) =>
    //     {
    // favorite.AccountId = profile.Id;
    // favorite.RecipeId = profile.RecipeId;
    // favorite.RecipeId = recipe.Id;
    // favorite.AccountId = recipe.CreatorId;
    //   return favorite;
    // }, favoriteData).FirstOrDefault();

    // return favoriteRecipe;
  }
}