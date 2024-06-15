using DTO.FoodMod.MealDTO;
using Repository.FoodMod.MealRepository;

namespace Service.FoodMod.MealService;

//Meal
//meal
public class MealService(IMealRepository mealRepository) : IMealService
{
    private IMealRepository _mealRepository = mealRepository;
    
    public MealDto GetMeal(long id)
    {
        return _mealRepository.Get(id);
    }

    public List<MealDto> GetMeal()
    {
        return _mealRepository.GetAll();
    }

    public void InsertMeal(CreateMealDto dto)
    {
        _mealRepository.Insert(dto);
    }

    public void UpdateMeal(UpdateMealDto dto)
    {
        _mealRepository.Update(dto);
    }

    public void DeleteMeal(long id)
    {
        _mealRepository.Delete(id);
    }
}