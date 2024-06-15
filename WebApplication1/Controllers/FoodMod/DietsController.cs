using DTO.FoodMod.DietsDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.DietsService;

namespace WebApplication1.Controllers.FoodMod;



//Diets
//diets


[ApiController]
[Route("dietss")]
public class DietsController(IDietsService dietsService) : Controller
{
    [HttpGet]
    public JsonResult GetDietss()
    {
        var dietss = dietsService.GetDiets();
        return Json(dietss);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetDiets(long id)
    {
        var diets = dietsService.GetDiets(id);
        if(diets == null) return NotFound("Автор не найден");
        return Json(diets);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateDiets(CreateDietsDto dto)
    {
        dietsService.InsertDiets(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateDiets(UpdateDietsDto dto)
    {
        dietsService.UpdateDiets(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteDiets(long id)
    {
        dietsService.DeleteDiets(id);
        return Json("deleted");
    }
}