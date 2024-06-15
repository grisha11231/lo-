using DTO.FoodMod.TypeOfDietDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.TypeOfDietService;

namespace WebApplication1.Controllers.FoodMod;



//TypeOfDiet
//typeOfDiet


[ApiController]
[Route("typeOfDiets")]
public class TypeOfDietController(ITypeOfDietService typeOfDietService) : Controller
{
    [HttpGet]
    public JsonResult GetTypeOfDiets()
    {
        var typeOfDiets = typeOfDietService.GetTypeOfDiet();
        return Json(typeOfDiets);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetTypeOfDiet(long id)
    {
        var typeOfDiet = typeOfDietService.GetTypeOfDiet(id);
        if(typeOfDiet == null) return NotFound("Автор не найден");
        return Json(typeOfDiet);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateTypeOfDiet(CreateTypeOfDietDto dto)
    {
        typeOfDietService.InsertTypeOfDiet(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateTypeOfDiet(UpdateTypeOfDietDto dto)
    {
        typeOfDietService.UpdateTypeOfDiet(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteTypeOfDiet(long id)
    {
        typeOfDietService.DeleteTypeOfDiet(id);
        return Json("deleted");
    }
}