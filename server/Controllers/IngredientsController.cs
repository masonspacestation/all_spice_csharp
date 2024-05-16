using Microsoft.AspNetCore.Http.HttpResults;

namespace all_spice_csharp.Controllers;


[ApiController]
[Route("api/[controller]")]

public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth0Provider;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
  {
    _ingredientsService = ingredientsService;
    _auth0Provider = auth0Provider;
  }




  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      ingredientData.CreatorId = userInfo.Id;

      Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
      return Ok(ingredient);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{ingredientId}")]
  public async Task<ActionResult<Ingredient>> DestroyIngredient(int ingredientId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      string message = _ingredientsService.DestroyIngredient(ingredientId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }



  }

}