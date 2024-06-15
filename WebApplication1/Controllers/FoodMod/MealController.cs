using DTO.FoodMod.MealDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.MealService;

namespace WebApplication1.Controllers.FoodMod;



//Meal
//meal


[ApiController]
[Route("meals")]
public class MealController(IMealService mealService) : Controller
{
    [HttpGet]
    public JsonResult GetMeals()
    {
        var meals = mealService.GetMeal();
        return Json(meals);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetMeal(long id)
    {
        var meal = mealService.GetMeal(id);
        if(meal == null) return NotFound("Автор не найден");
        return Json(meal);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateMeal(CreateMealDto dto)
    {
        mealService.InsertMeal(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateMeal(UpdateMealDto dto)
    {
        mealService.UpdateMeal(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteMeal(long id)
    {
        mealService.DeleteMeal(id);
        return Json("deleted");
    }
}