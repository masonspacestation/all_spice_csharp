namespace all_spice_csharp.Models;


public class FavoritedRecipe : Recipe
{
  // has recipe information + account Id
  public int FavoriteId { get; set; }
  // public Profile AccountId { get; set; }
}