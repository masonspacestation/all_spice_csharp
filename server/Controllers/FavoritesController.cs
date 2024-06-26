using Microsoft.AspNetCore.Identity;

namespace all_spice_csharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
  {
    _favoritesService = favoritesService;
    _auth0Provider = auth0Provider;
  }


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<FavoritedRecipe>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;

      FavoritedRecipe favorite = _favoritesService.CreateFavorite(favoriteData);
      return Ok(favorite);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [Authorize]
  [HttpDelete("{favoriteId}")]
  public async Task<ActionResult<FavoritedRecipe>> DestroyFavorite(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _favoritesService.DestroyFavorite(favoriteId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{favoriteId}")]
  public ActionResult<FavoritedRecipe> GetFavoriteById(int favoriteId)
  {
    try
    {
      FavoritedRecipe favoritedRecipe = _favoritesService.GetFavoriteById(favoriteId);
      return Ok(favoritedRecipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}