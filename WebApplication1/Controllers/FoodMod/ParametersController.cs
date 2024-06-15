using DTO.FoodMod.ParametersDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.ParametersService;

namespace WebApplication1.Controllers.FoodMod;



//Parameters
//parameters


[ApiController]
[Route("parameterss")]
public class ParametersController(IParametersService parametersService) : Controller
{
    [HttpGet]
    public JsonResult GetParameterss()
    {
        var parameterss = parametersService.GetParameters();
        return Json(parameterss);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetParameters(long id)
    {
        var parameters = parametersService.GetParameters(id);
        if(parameters == null) return NotFound("Автор не найден");
        return Json(parameters);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateParameters(CreateParametersDto dto)
    {
        parametersService.InsertParameters(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateParameters(UpdateParametersDto dto)
    {
        parametersService.UpdateParameters(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteParameters(long id)
    {
        parametersService.DeleteParameters(id);
        return Json("deleted");
    }
}