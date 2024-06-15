using DTO.FoodMod.ActivityDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.ActivityService;

namespace WebApplication1.Controllers.FoodMod;



//Activity
//activity


[ApiController]
[Route("activitys")]
public class ActivityController(IActivityService activityService) : Controller
{
    [HttpGet]
    public JsonResult GetActivitys()
    {
        var activitys = activityService.GetActivity();
        return Json(activitys);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetActivity(long id)
    {
        var activity = activityService.GetActivity(id);
        if(activity == null) return NotFound("Автор не найден");
        return Json(activity);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateActivity(CreateActivityDto dto)
    {
        activityService.InsertActivity(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateActivity(UpdateActivityDto dto)
    {
        activityService.UpdateActivity(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteActivity(long id)
    {
        activityService.DeleteActivity(id);
        return Json("deleted");
    }
}