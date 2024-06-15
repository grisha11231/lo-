using DTO.FoodMod.ParMenDTO;
using Repository.FoodMod.ParMenRepository;

namespace Service.FoodMod.ParMenService;

//ParMen
//parMen
public class ParMenService(IParMenRepository parMenRepository) : IParMenService
{
    private IParMenRepository _parMenRepository = parMenRepository;
    
    public ParMenDto GetParMen(long id)
    {
        return _parMenRepository.Get(id);
    }

    public List<ParMenDto> GetParMen()
    {
        return _parMenRepository.GetAll();
    }

    public void InsertParMen(CreateParMenDto dto)
    {
        _parMenRepository.Insert(dto);
    }

    public void UpdateParMen(UpdateParMenDto dto)
    {
        _parMenRepository.Update(dto);
    }

    public void DeleteParMen(long id)
    {
        _parMenRepository.Delete(id);
    }
}