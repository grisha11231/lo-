using DTO.FoodMod.DietsDTO;

namespace Repository.FoodMod.DietsRepository;



//Diets
public interface IDietsRepository
{
    DietsDto Get(long id);
    List<DietsDto> GetAll();
    void Insert(CreateDietsDto dto);
    void Update(UpdateDietsDto dto);
    void Delete(long id);
    void SaveChanges();
}