


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

  internal FavoritedRecipe GetFavoriteById(int favoriteId)
  {
    FavoritedRecipe favorited = _repository.GetFavoriteById(favoriteId);
    if (favorited == null)
    {
      throw new Exception($"Invalid Id: {favoriteId}");
    }
    return favorited;
  }

  internal string DestroyFavorite(int favoriteId, string userId)
  {
    FavoritedRecipe favoritedRecipeToDestroy = GetFavoriteById(favoriteId);
    if (favoritedRecipeToDestroy.Creator.Id != userId)
    {
      throw new Exception("Sorry, this is someone else's favorite recipe. You can't delete it.");
    }
    _repository.DestroyFavorite(favoriteId);
    return $"{favoritedRecipeToDestroy.Id} has been deleted.";
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