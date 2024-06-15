using DTO.FoodMod.MenuDTO;
using Microsoft.AspNetCore.Mvc;
using Service.FoodMod.MenuService;

namespace WebApplication1.Controllers.FoodMod;



//Menu
//menu


[ApiController]
[Route("menus")]
public class MenuController(IMenuService menuService) : Controller
{
    [HttpGet]
    public JsonResult GetMenus()
    {
        var menus = menuService.GetMenu();
        return Json(menus);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetMenu(long id)
    {
        var menu = menuService.GetMenu(id);
        if(menu == null) return NotFound("Автор не найден");
        return Json(menu);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateMenu(CreateMenuDto dto)
    {
        menuService.InsertMenu(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateMenu(UpdateMenuDto dto)
    {
        menuService.UpdateMenu(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteMenu(long id)
    {
        menuService.DeleteMenu(id);
        return Json("deleted");
    }
}