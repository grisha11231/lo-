using Data.FoodMod;
using DTO.FoodMod.IngredientsDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.IngredientsRepository;


//Ingredients
//ingredients
public class IngredientsRepository(ApplicationContext context) : IIngredientsRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Ingredients> _ingredients = context.Set<Ingredients>();
    
    public IngredientsDto Get(long id)
    {
        var ingredients = _ingredients.SingleOrDefault(a => a.Id == id);
        if (ingredients == null) return null;
        return new IngredientsDto
        {
            Id = ingredients.Id,
            Name = ingredients.Name,
            Type = ingredients.Type
        };
    }
    
    public List<IngredientsDto> GetAll()
    {
        var ingredientss = _ingredients.ToList();
        List<IngredientsDto> lingredientss = new List<IngredientsDto>();

        foreach (var ingredients in ingredientss)
        {
            lingredientss.Add(new IngredientsDto
            {
                Id = ingredients.Id,
                Name = ingredients.Name,
                Type = ingredients.Type
            });
        }
        return lingredientss;
    }
    
    public void Insert(CreateIngredientsDto dto)
    {
        Ingredients ingredients = new Ingredients
        {
            Name = dto.Name,
            Type = dto.Type
        };
        _ingredients.Add(ingredients);
        context.SaveChanges();
    }
    
    public void Update(UpdateIngredientsDto dto)
    {
        var ingredients = _ingredients.SingleOrDefault(a => a.Id == dto.Id);
        if (ingredients == null) return;

        ingredients.Name = dto.Name;
        ingredients.Type = dto.Type;

        _ingredients.Update(ingredients);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var ingredients = _ingredients.SingleOrDefault(a => a.Id == id);
        if (ingredients == null) return;
        _ingredients.Remove(ingredients);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}