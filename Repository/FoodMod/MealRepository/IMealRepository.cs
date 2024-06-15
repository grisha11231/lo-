using DTO.FoodMod.MealDTO;

namespace Repository.FoodMod.MealRepository;



//Meal
public interface IMealRepository
{
    MealDto Get(long id);
    List<MealDto> GetAll();
    void Insert(CreateMealDto dto);
    void Update(UpdateMealDto dto);
    void Delete(long id);
    void SaveChanges();
}