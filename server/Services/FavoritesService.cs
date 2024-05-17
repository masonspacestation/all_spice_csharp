

namespace all_spice_csharp.Services;



public class FavoritesService
{
  private readonly FavoritesRepository _repository;

  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }

  internal FavoritedRecipe CreateFavorite(Favorite favoriteData)
  {
    FavoritedRecipe favorite = _repository.CreateFavorite(favoriteData);
    return favorite;
  }

  internal List<FavoritedRecipe> GetAccountFavorites(string userId)
  {
    List<FavoritedRecipe> favoritedRecipes = _repository.GetAccountFavorites(userId);
    // if (favoritedRecipes == null)
    // {
    //   throw new Exception("No favorite recipes found. Look around and add some.");
    // }
    return favoritedRecipes;
  }
}