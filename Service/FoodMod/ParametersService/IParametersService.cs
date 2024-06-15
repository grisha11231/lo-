using DTO.FoodMod.ParametersDTO;

namespace Service.FoodMod.ParametersService;




//Parameters
public interface IParametersService
{
    ParametersDto GetParameters(long id);
    List<ParametersDto> GetParameters();
    void InsertParameters(CreateParametersDto dto);
    void UpdateParameters(UpdateParametersDto dto);
    void DeleteParameters(long id);
}