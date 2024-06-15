using DTO.FoodMod.TypeOfDietDTO;

namespace Service.FoodMod.TypeOfDietService;




//TypeOfDiet
public interface ITypeOfDietService
{
    TypeOfDietDto GetTypeOfDiet(long id);
    List<TypeOfDietDto> GetTypeOfDiet();
    void InsertTypeOfDiet(CreateTypeOfDietDto dto);
    void UpdateTypeOfDiet(UpdateTypeOfDietDto dto);
    void DeleteTypeOfDiet(long id);
}