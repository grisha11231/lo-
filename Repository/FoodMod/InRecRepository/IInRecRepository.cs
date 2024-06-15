using DTO.FoodMod.InRecDTO;

namespace Repository.FoodMod.InRecRepository;



//InRec
public interface IInRecRepository
{
    InRecDto Get(long id);
    List<InRecDto> GetAll();
    void Insert(CreateInRecDto dto);
    void Update(UpdateInRecDto dto);
    void Delete(long id);
    void SaveChanges();
}