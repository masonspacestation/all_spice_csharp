
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
        accounts.*,
        recipes.*
        FROM favorites
        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON favorites.accountId = accounts.id
        WHERE favorites.id = LAST_INSERT_ID();";


    FavoritedRecipe recipe = _db.Query<Favorite, FavoritorProfile, FavoritedRecipe, FavoritedRecipe>(sql, (favorite, profile, recipe) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = profile.Id;
      recipe.Creator = profile;
      return recipe;
    }
    , favoriteData).FirstOrDefault();
    return recipe;
  }

  internal List<FavoritedRecipe> GetAccountFavorites(string userId)
  {
    string sql = @"
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites

        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON favorites.accountId = accounts.id

        WHERE favorites.AccountId = @userId;";

    List<FavoritedRecipe> favoritedRecipes = _db.Query<Favorite, FavoritedRecipe, Profile, FavoritedRecipe>(sql, (favorite, recipe, profile) =>
{
  recipe.FavoriteId = favorite.Id;
  recipe.AccountId = profile.Id;
  recipe.Creator = profile;
  return recipe;
}, new { userId }).ToList();
    return favoritedRecipes;
  }

  internal void DestroyFavorite(int favoriteId)
  {
    string sql = "DELETE FROM favorites WHERE favorites.id = @favoriteId;";
    _db.Execute(sql, new { favoriteId });
  }

  internal FavoritedRecipe GetFavoriteById(int favoriteId)
  {
    string sql = @"
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites

        JOIN recipes ON favorites.recipeId = recipes.id
        JOIN accounts ON favorites.accountId = accounts.id

        WHERE favorites.Id = @favoriteId;";

    FavoritedRecipe favorited = _db.Query<Favorite, FavoritedRecipe, Profile, FavoritedRecipe>(sql, (favorite, recipe, profile) =>
{
  recipe.FavoriteId = favorite.Id;
  recipe.AccountId = profile.Id;
  recipe.Creator = profile;
  return recipe;
}, new { favoriteId }).FirstOrDefault();
    return favorited;
  }
}