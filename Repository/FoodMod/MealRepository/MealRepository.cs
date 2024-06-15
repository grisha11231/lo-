using Data.FoodMod;
using DTO.FoodMod.MealDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.MealRepository;


//Meal
//meal
public class MealRepository(ApplicationContext context) : IMealRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Meal> _meal = context.Set<Meal>();
    
    public MealDto Get(long id)
    {
        var meal = _meal.SingleOrDefault(a => a.Id == id);
        if (meal == null) return null;
        return new MealDto
        {
            Id = meal.Id,
            Recipe_Id = meal.Recipe_Id,
            Time = meal.Time
        };
    }
    
    public List<MealDto> GetAll()
    {
        var meals = _meal.ToList();
        List<MealDto> lmeals = new List<MealDto>();

        foreach (var meal in meals)
        {
            lmeals.Add(new MealDto
            {
                Id = meal.Id,
                Recipe_Id = meal.Recipe_Id,
                Time = meal.Time
            });
        }
        return lmeals;
    }
    
    public void Insert(CreateMealDto dto)
    {
        Meal meal = new Meal
        {
            Recipe_Id = dto.Recipe_Id,
            Time = dto.Time
        };
        _meal.Add(meal);
        context.SaveChanges();
    }
    
    public void Update(UpdateMealDto dto)
    {
        var meal = _meal.SingleOrDefault(a => a.Id == dto.Id);
        if (meal == null) return;

        meal.Recipe_Id = dto.Recipe_Id;
        meal.Time = dto.Time;

        _meal.Update(meal);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var meal = _meal.SingleOrDefault(a => a.Id == id);
        if (meal == null) return;
        _meal.Remove(meal);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}