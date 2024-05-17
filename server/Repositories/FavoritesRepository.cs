
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
}