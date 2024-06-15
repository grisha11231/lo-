using DTO.FoodMod.ParMenDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.ParMenService;

namespace WebApplication1.Controllers.FoodMod;



//ParMen
//parMen


[ApiController]
[Route("parMens")]
public class ParMenController(IParMenService parMenService) : Controller
{
    [HttpGet]
    public JsonResult GetParMens()
    {
        var parMens = parMenService.GetParMen();
        return Json(parMens);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetParMen(long id)
    {
        var parMen = parMenService.GetParMen(id);
        if(parMen == null) return NotFound("Автор не найден");
        return Json(parMen);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateParMen(CreateParMenDto dto)
    {
        parMenService.InsertParMen(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateParMen(UpdateParMenDto dto)
    {
        parMenService.UpdateParMen(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteParMen(long id)
    {
        parMenService.DeleteParMen(id);
        return Json("deleted");
    }
}