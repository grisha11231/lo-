using DTO.FoodMod.ParametersDTO;

namespace Repository.FoodMod.ParametersRepository;



//Parameters
public interface IParametersRepository
{
    ParametersDto Get(long id);
    List<ParametersDto> GetAll();
    void Insert(CreateParametersDto dto);
    void Update(UpdateParametersDto dto);
    void Delete(long id);
    void SaveChanges();
}