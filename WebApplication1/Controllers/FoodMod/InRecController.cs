using DTO.FoodMod.InRecDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.InRecService;

namespace WebApplication1.Controllers.FoodMod;



//InRec
//inRec


[ApiController]
[Route("inRecs")]
public class InRecController(IInRecService inRecService) : Controller
{
    [HttpGet]
    public JsonResult GetInRecs()
    {
        var inRecs = inRecService.GetInRec();
        return Json(inRecs);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetInRec(long id)
    {
        var inRec = inRecService.GetInRec(id);
        if(inRec == null) return NotFound("Автор не найден");
        return Json(inRec);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateInRec(CreateInRecDto dto)
    {
        inRecService.InsertInRec(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateInRec(UpdateInRecDto dto)
    {
        inRecService.UpdateInRec(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteInRec(long id)
    {
        inRecService.DeleteInRec(id);
        return Json("deleted");
    }
}