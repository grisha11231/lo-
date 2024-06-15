using DTO.FoodMod.TypeOfDietDTO;
using Repository.FoodMod.TypeOfDietRepository;

namespace Service.FoodMod.TypeOfDietService;

//TypeOfDiet
//typeOfDiet
public class TypeOfDietService(ITypeOfDietRepository typeOfDietRepository) : ITypeOfDietService
{
    private ITypeOfDietRepository _typeOfDietRepository = typeOfDietRepository;
    
    public TypeOfDietDto GetTypeOfDiet(long id)
    {
        return _typeOfDietRepository.Get(id);
    }

    public List<TypeOfDietDto> GetTypeOfDiet()
    {
        return _typeOfDietRepository.GetAll();
    }

    public void InsertTypeOfDiet(CreateTypeOfDietDto dto)
    {
        _typeOfDietRepository.Insert(dto);
    }

    public void UpdateTypeOfDiet(UpdateTypeOfDietDto dto)
    {
        _typeOfDietRepository.Update(dto);
    }

    public void DeleteTypeOfDiet(long id)
    {
        _typeOfDietRepository.Delete(id);
    }
}