using DTO.FoodMod.IngredientsDTO;

namespace Service.FoodMod.IngredientsService;




//Ingredients
public interface IIngredientsService
{
    IngredientsDto GetIngredients(long id);
    List<IngredientsDto> GetIngredients();
    void InsertIngredients(CreateIngredientsDto dto);
    void UpdateIngredients(UpdateIngredientsDto dto);
    void DeleteIngredients(long id);
}