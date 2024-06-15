using DTO.FoodMod.MealDTO;

namespace Service.FoodMod.MealService;




//Meal
public interface IMealService
{
    MealDto GetMeal(long id);
    List<MealDto> GetMeal();
    void InsertMeal(CreateMealDto dto);
    void UpdateMeal(UpdateMealDto dto);
    void DeleteMeal(long id);
}