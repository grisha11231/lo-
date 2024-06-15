using DTO.FoodMod.IngredientsDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.IngredientsService;

namespace WebApplication1.Controllers.FoodMod;



//Ingredients
//ingredients


[ApiController]
[Route("ingredientss")]
public class IngredientsController(IIngredientsService ingredientsService) : Controller
{
    [HttpGet]
    public JsonResult GetIngredientss()
    {
        var ingredientss = ingredientsService.GetIngredients();
        return Json(ingredientss);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetIngredients(long id)
    {
        var ingredients = ingredientsService.GetIngredients(id);
        if(ingredients == null) return NotFound("Автор не найден");
        return Json(ingredients);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateIngredients(CreateIngredientsDto dto)
    {
        ingredientsService.InsertIngredients(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateIngredients(UpdateIngredientsDto dto)
    {
        ingredientsService.UpdateIngredients(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteIngredients(long id)
    {
        ingredientsService.DeleteIngredients(id);
        return Json("deleted");
    }
}