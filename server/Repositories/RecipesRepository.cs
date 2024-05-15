namespace all_spice_csharp.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
}