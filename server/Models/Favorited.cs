namespace all_spice_csharp.Models;


public class Favorited : Recipe
{
  // has recipe information + account Id
  public int FavoritedId { get; set; }
  public string AccountId { get; set; }
}