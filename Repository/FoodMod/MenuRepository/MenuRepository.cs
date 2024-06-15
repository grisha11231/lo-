using Data.FoodMod;
using DTO.FoodMod.MenuDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.MenuRepository;


//Menu
//menu
public class MenuRepository(ApplicationContext context) : IMenuRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Menu> _menu = context.Set<Menu>();
    
    public MenuDto Get(long id)
    {
        var menu = _menu.SingleOrDefault(a => a.Id == id);
        if (menu == null) return null;
        return new MenuDto
        {
            Id = menu.Id,
            Diet_Id = menu.Diet_Id,
            Meal_Id = menu.Meal_Id
        };
    }
    
    public List<MenuDto> GetAll()
    {
        var menus = _menu.ToList();
        List<MenuDto> lmenus = new List<MenuDto>();

        foreach (var menu in menus)
        {
            lmenus.Add(new MenuDto
            {
                Id = menu.Id,
                Diet_Id = menu.Diet_Id,
                Meal_Id = menu.Meal_Id
            });
        }
        return lmenus;
    }
    
    public void Insert(CreateMenuDto dto)
    {
        Menu menu = new Menu
        {
            Diet_Id = dto.Diet_Id,
            Meal_Id = dto.Meal_Id
        };
        _menu.Add(menu);
        context.SaveChanges();
    }
    
    public void Update(UpdateMenuDto dto)
    {
        var menu = _menu.SingleOrDefault(a => a.Id == dto.Id);
        if (menu == null) return;

        menu.Diet_Id = dto.Diet_Id;
        menu.Meal_Id = dto.Meal_Id;

        _menu.Update(menu);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var menu = _menu.SingleOrDefault(a => a.Id == id);
        if (menu == null) return;
        _menu.Remove(menu);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}