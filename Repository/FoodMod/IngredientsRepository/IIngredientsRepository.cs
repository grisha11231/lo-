using DTO.FoodMod.IngredientsDTO;

namespace Repository.FoodMod.IngredientsRepository;



//Ingredients
public interface IIngredientsRepository
{
    IngredientsDto Get(long id);
    List<IngredientsDto> GetAll();
    void Insert(CreateIngredientsDto dto);
    void Update(UpdateIngredientsDto dto);
    void Delete(long id);
    void SaveChanges();
}