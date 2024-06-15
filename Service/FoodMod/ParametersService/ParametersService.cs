using DTO.FoodMod.ParametersDTO;
using Repository.FoodMod.ParametersRepository;

namespace Service.FoodMod.ParametersService;

//Parameters
//parameters
public class ParametersService(IParametersRepository parametersRepository) : IParametersService
{
    private IParametersRepository _parametersRepository = parametersRepository;
    
    public ParametersDto GetParameters(long id)
    {
        return _parametersRepository.Get(id);
    }

    public List<ParametersDto> GetParameters()
    {
        return _parametersRepository.GetAll();
    }

    public void InsertParameters(CreateParametersDto dto)
    {
        _parametersRepository.Insert(dto);
    }

    public void UpdateParameters(UpdateParametersDto dto)
    {
        _parametersRepository.Update(dto);
    }

    public void DeleteParameters(long id)
    {
        _parametersRepository.Delete(id);
    }
}