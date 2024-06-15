using Data.FoodMod;
using DTO.FoodMod.ParametersDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.ParametersRepository;


//Parameters
//parameters
public class ParametersRepository(ApplicationContext context) : IParametersRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Parameters> _parameters = context.Set<Parameters>();
    
    public ParametersDto Get(long id)
    {
        var parameters = _parameters.SingleOrDefault(a => a.Id == id);
        if (parameters == null) return null;
        return new ParametersDto
        {
            Id = parameters.Id,
            User_Id = parameters.User_Id,
            Weight = parameters.Weight,
            Height = parameters.Height,
            Activity_Id = parameters.Activity_Id
        };
    }
    
    public List<ParametersDto> GetAll()
    {
        var parameterss = _parameters.ToList();
        List<ParametersDto> lparameterss = new List<ParametersDto>();

        foreach (var parameters in parameterss)
        {
            lparameterss.Add(new ParametersDto
            {
                Id = parameters.Id,
                User_Id = parameters.User_Id,
                Weight = parameters.Weight,
                Height = parameters.Height,
                Activity_Id = parameters.Activity_Id
            });
        }
        return lparameterss;
    }
    
    public void Insert(CreateParametersDto dto)
    {
        Parameters parameters = new Parameters
        {
            User_Id = dto.User_Id,
            Weight = dto.Weight,
            Height = dto.Height,
            Activity_Id = dto.Activity_Id
        };
        _parameters.Add(parameters);
        context.SaveChanges();
    }
    
    public void Update(UpdateParametersDto dto)
    {
        var parameters = _parameters.SingleOrDefault(a => a.Id == dto.Id);
        if (parameters == null) return;

        parameters.User_Id = dto.User_Id;
        parameters.Weight = dto.Weight;
        parameters.Height = dto.Height;
        parameters.Activity_Id = dto.Activity_Id;

        _parameters.Update(parameters);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var parameters = _parameters.SingleOrDefault(a => a.Id == id);
        if (parameters == null) return;
        _parameters.Remove(parameters);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}