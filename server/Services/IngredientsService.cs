




namespace all_spice_csharp.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repository;
  private readonly RecipesService _recipesService;

  public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
  {
    _repository = repository;
    _recipesService = recipesService;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {

    Ingredient ingredient = _repository.CreateIngredient(ingredientData);
    return ingredient;
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _repository.GetIngredientById(ingredientId);
    if (ingredient == null)
    {
      throw new Exception($"Invalid Id: {ingredientId}");
    }
    return ingredient;
  }

  internal string DestroyIngredient(int ingredientId, string userId)
  {
    Ingredient ingredientToDestroy = GetIngredientById(ingredientId);
    if (ingredientToDestroy.CreatorId != userId)
    {
      throw new Exception($"{ingredientToDestroy.Name} wasn't added by you, and thus, cannot be deleted by you.");
    }
    _repository.DestroyIngredient(ingredientId);
    return $"{ingredientToDestroy.Name} has been removed from this recipe.";
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }
}