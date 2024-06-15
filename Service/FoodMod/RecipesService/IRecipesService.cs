using DTO.FoodMod.RecipesDTO;

namespace Service.FoodMod.RecipesService;




//Recipes
public interface IRecipesService
{
    RecipesDto GetRecipes(long id);
    List<RecipesDto> GetRecipes();
    void InsertRecipes(CreateRecipesDto dto);
    void UpdateRecipes(UpdateRecipesDto dto);
    void DeleteRecipes(long id);
}