using DTO.FoodMod.RecipesDTO;

namespace Repository.FoodMod.RecipesRepository;



//Recipes
public interface IRecipesRepository
{
    RecipesDto Get(long id);
    List<RecipesDto> GetAll();
    void Insert(CreateRecipesDto dto);
    void Update(UpdateRecipesDto dto);
    void Delete(long id);
    void SaveChanges();
}