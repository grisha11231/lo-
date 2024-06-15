using DTO.FoodMod.MenuDTO;

namespace Service.FoodMod.MenuService;




//Menu
public interface IMenuService
{
    MenuDto GetMenu(long id);
    List<MenuDto> GetMenu();
    void InsertMenu(CreateMenuDto dto);
    void UpdateMenu(UpdateMenuDto dto);
    void DeleteMenu(long id);
}