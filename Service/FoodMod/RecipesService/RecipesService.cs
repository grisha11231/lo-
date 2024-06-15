using DTO.FoodMod.RecipesDTO;
using Repository.FoodMod.RecipesRepository;

namespace Service.FoodMod.RecipesService;

//Recipes
//recipes
public class RecipesService(IRecipesRepository recipesRepository) : IRecipesService
{
    private IRecipesRepository _recipesRepository = recipesRepository;
    
    public RecipesDto GetRecipes(long id)
    {
        return _recipesRepository.Get(id);
    }

    public List<RecipesDto> GetRecipes()
    {
        return _recipesRepository.GetAll();
    }

    public void InsertRecipes(CreateRecipesDto dto)
    {
        _recipesRepository.Insert(dto);
    }

    public void UpdateRecipes(UpdateRecipesDto dto)
    {
        _recipesRepository.Update(dto);
    }

    public void DeleteRecipes(long id)
    {
        _recipesRepository.Delete(id);
    }
}