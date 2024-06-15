using DTO.FoodMod.DietsDTO;
using Repository.FoodMod.DietsRepository;

namespace Service.FoodMod.DietsService;

//Diets
//diets
public class DietsService(IDietsRepository dietsRepository) : IDietsService
{
    private IDietsRepository _dietsRepository = dietsRepository;
    
    public DietsDto GetDiets(long id)
    {
        return _dietsRepository.Get(id);
    }

    public List<DietsDto> GetDiets()
    {
        return _dietsRepository.GetAll();
    }

    public void InsertDiets(CreateDietsDto dto)
    {
        _dietsRepository.Insert(dto);
    }

    public void UpdateDiets(UpdateDietsDto dto)
    {
        _dietsRepository.Update(dto);
    }

    public void DeleteDiets(long id)
    {
        _dietsRepository.Delete(id);
    }
}