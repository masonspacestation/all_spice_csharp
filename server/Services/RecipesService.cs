namespace all_spice_csharp.Services;

public class RecipesService
{
  private readonly RecipesRepository _repository;

  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }
}