using DTO.FoodMod.IngredientsDTO;
using Repository.FoodMod.IngredientsRepository;

namespace Service.FoodMod.IngredientsService;

//Ingredients
//ingredients
public class IngredientsService(IIngredientsRepository ingredientsRepository) : IIngredientsService
{
    private IIngredientsRepository _ingredientsRepository = ingredientsRepository;
    
    public IngredientsDto GetIngredients(long id)
    {
        return _ingredientsRepository.Get(id);
    }

    public List<IngredientsDto> GetIngredients()
    {
        return _ingredientsRepository.GetAll();
    }

    public void InsertIngredients(CreateIngredientsDto dto)
    {
        _ingredientsRepository.Insert(dto);
    }

    public void UpdateIngredients(UpdateIngredientsDto dto)
    {
        _ingredientsRepository.Update(dto);
    }

    public void DeleteIngredients(long id)
    {
        _ingredientsRepository.Delete(id);
    }
}