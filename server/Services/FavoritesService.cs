
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
}