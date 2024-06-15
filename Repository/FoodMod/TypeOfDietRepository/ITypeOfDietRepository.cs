using DTO.FoodMod.TypeOfDietDTO;

namespace Repository.FoodMod.TypeOfDietRepository;



//TypeOfDiet
public interface ITypeOfDietRepository
{
    TypeOfDietDto Get(long id);
    List<TypeOfDietDto> GetAll();
    void Insert(CreateTypeOfDietDto dto);
    void Update(UpdateTypeOfDietDto dto);
    void Delete(long id);
    void SaveChanges();
}