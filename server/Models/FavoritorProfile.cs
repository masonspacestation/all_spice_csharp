namespace all_spice_csharp.Models;


public class FavoritorProfile : Profile
{
  // has profile information + recipeId
  public int FavoritorId { get; set; }
  public int RecipeId { get; set; }
}