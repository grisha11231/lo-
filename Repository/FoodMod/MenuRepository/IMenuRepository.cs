using DTO.FoodMod.MenuDTO;

namespace Repository.FoodMod.MenuRepository;



//Menu
public interface IMenuRepository
{
    MenuDto Get(long id);
    List<MenuDto> GetAll();
    void Insert(CreateMenuDto dto);
    void Update(UpdateMenuDto dto);
    void Delete(long id);
    void SaveChanges();
}