namespace all_spice_csharp.Models;

public class Favorite : RepoItem<int>
{
  // connects accounts to recipes
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
}