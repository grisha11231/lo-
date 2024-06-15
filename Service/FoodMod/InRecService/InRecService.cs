using DTO.FoodMod.InRecDTO;
using Repository.FoodMod.InRecRepository;

namespace Service.FoodMod.InRecService;

//InRec
//inRec
public class InRecService(IInRecRepository inRecRepository) : IInRecService
{
    private IInRecRepository _inRecRepository = inRecRepository;
    
    public InRecDto GetInRec(long id)
    {
        return _inRecRepository.Get(id);
    }

    public List<InRecDto> GetInRec()
    {
        return _inRecRepository.GetAll();
    }

    public void InsertInRec(CreateInRecDto dto)
    {
        _inRecRepository.Insert(dto);
    }

    public void UpdateInRec(UpdateInRecDto dto)
    {
        _inRecRepository.Update(dto);
    }

    public void DeleteInRec(long id)
    {
        _inRecRepository.Delete(id);
    }
}