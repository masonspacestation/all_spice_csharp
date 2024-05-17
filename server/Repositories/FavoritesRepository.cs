
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
        favorites(favoriteId, recipeId, accountId)
        VALUES(@FavoriteId, @RecipeId, @AccountId);

        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN accounts ON favorites.accountId = accounts.id
        JOIN recipes ON favorites.recipeId = recipes.id
        WHERE favorites.id = LAST_INSERT_ID();";


    FavoritedRecipe recipe = _db.Query<Favorite, FavoritedRecipe, FavoritedRecipe>(sql, (favorite, recipe) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.CreatorId = favorite.AccountId;
      return recipe;
    }
    , favoriteData).FirstOrDefault();
    return recipe;
  }
}