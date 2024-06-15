using DTO.FoodMod.MenuDTO;
using Repository.FoodMod.MenuRepository;

namespace Service.FoodMod.MenuService;

//Menu
//menu
public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private IMenuRepository _menuRepository = menuRepository;
    
    public MenuDto GetMenu(long id)
    {
        return _menuRepository.Get(id);
    }

    public List<MenuDto> GetMenu()
    {
        return _menuRepository.GetAll();
    }

    public void InsertMenu(CreateMenuDto dto)
    {
        _menuRepository.Insert(dto);
    }

    public void UpdateMenu(UpdateMenuDto dto)
    {
        _menuRepository.Update(dto);
    }

    public void DeleteMenu(long id)
    {
        _menuRepository.Delete(id);
    }
}