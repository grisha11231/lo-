using DTO.FoodMod.ParMenDTO;

namespace Repository.FoodMod.ParMenRepository;



//ParMen
public interface IParMenRepository
{
    ParMenDto Get(long id);
    List<ParMenDto> GetAll();
    void Insert(CreateParMenDto dto);
    void Update(UpdateParMenDto dto);
    void Delete(long id);
    void SaveChanges();
}