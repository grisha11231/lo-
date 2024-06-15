using Data.FoodMod;
using DTO.FoodMod.RecipesDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.RecipesRepository;


//Recipes
//recipes
public class RecipesRepository(ApplicationContext context) : IRecipesRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Recipes> _recipes = context.Set<Recipes>();
    
    public RecipesDto Get(long id)
    {
        var recipes = _recipes.SingleOrDefault(a => a.Id == id);
        if (recipes == null) return null;
        return new RecipesDto
        {
            Id = recipes.Id,
            Name = recipes.Name,
            calories = recipes.calories,
            instructions = recipes.instructions
        };
    }
    
    public List<RecipesDto> GetAll()
    {
        var recipess = _recipes.ToList();
        List<RecipesDto> lrecipess = new List<RecipesDto>();

        foreach (var recipes in recipess)
        {
            lrecipess.Add(new RecipesDto
            {
                Id = recipes.Id,
                Name = recipes.Name,
                calories = recipes.calories,
                instructions = recipes.instructions
            });
        }
        return lrecipess;
    }
    
    public void Insert(CreateRecipesDto dto)
    {
        Recipes recipes = new Recipes
        {
            Name = dto.Name,
            calories = dto.calories,
            instructions = dto.instructions,
            Meal_Id = dto.Meal_Id
        };
        _recipes.Add(recipes);
        context.SaveChanges();
    }
    
    public void Update(UpdateRecipesDto dto)
    {
        var recipes = _recipes.SingleOrDefault(a => a.Id == dto.Id);
        if (recipes == null) return;

        recipes.Name = dto.Name;
        recipes.calories = dto.calories;
        recipes.instructions = dto.instructions;

        _recipes.Update(recipes);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var recipes = _recipes.SingleOrDefault(a => a.Id == id);
        if (recipes == null) return;
        _recipes.Remove(recipes);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}