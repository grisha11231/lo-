using DTO.FoodMod.InRecDTO;

namespace Service.FoodMod.InRecService;




//InRec
public interface IInRecService
{
    InRecDto GetInRec(long id);
    List<InRecDto> GetInRec();
    void InsertInRec(CreateInRecDto dto);
    void UpdateInRec(UpdateInRecDto dto);
    void DeleteInRec(long id);
}