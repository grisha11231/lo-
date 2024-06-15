using DTO.FoodMod.DietsDTO;

namespace Service.FoodMod.DietsService;




//Diets
public interface IDietsService
{
    DietsDto GetDiets(long id);
    List<DietsDto> GetDiets();
    void InsertDiets(CreateDietsDto dto);
    void UpdateDiets(UpdateDietsDto dto);
    void DeleteDiets(long id);
}