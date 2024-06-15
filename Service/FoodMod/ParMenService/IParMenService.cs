using DTO.FoodMod.ParMenDTO;

namespace Service.FoodMod.ParMenService;




//ParMen
public interface IParMenService
{
    ParMenDto GetParMen(long id);
    List<ParMenDto> GetParMen();
    void InsertParMen(CreateParMenDto dto);
    void UpdateParMen(UpdateParMenDto dto);
    void DeleteParMen(long id);
}