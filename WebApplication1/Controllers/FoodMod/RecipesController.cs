using DTO.FoodMod.RecipesDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.RecipesService;

namespace WebApplication1.Controllers.FoodMod;



//Recipes
//recipes


[ApiController]
[Route("recipess")]
public class RecipesController(IRecipesService recipesService) : Controller
{
    [HttpGet]
    public JsonResult GetRecipess()
    {
        var recipess = recipesService.GetRecipes();
        return Json(recipess);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetRecipes(long id)
    {
        var recipes = recipesService.GetRecipes(id);
        if(recipes == null) return NotFound("Автор не найден");
        return Json(recipes);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateRecipes(CreateRecipesDto dto)
    {
        recipesService.InsertRecipes(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateRecipes(UpdateRecipesDto dto)
    {
        recipesService.UpdateRecipes(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteRecipes(long id)
    {
        recipesService.DeleteRecipes(id);
        return Json("deleted");
    }
}