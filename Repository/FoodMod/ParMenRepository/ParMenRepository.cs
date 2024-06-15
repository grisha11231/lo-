using Data.FoodMod;
using DTO.FoodMod.ParMenDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.ParMenRepository;


//ParMen
//parMen
public class ParMenRepository(ApplicationContext context) : IParMenRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<ParMen> _parMen = context.Set<ParMen>();
    
    public ParMenDto Get(long id)
    {
        var parMen = _parMen.SingleOrDefault(a => a.Id == id);
        if (parMen == null) return null;
        return new ParMenDto
        {
            Id = parMen.Id,
            Menu_Id = parMen.Menu_Id,
            Parameters_Id = parMen.Parameters_Id
        };
    }
    
    public List<ParMenDto> GetAll()
    {
        var parMens = _parMen.ToList();
        List<ParMenDto> lparMens = new List<ParMenDto>();

        foreach (var parMen in parMens)
        {
            lparMens.Add(new ParMenDto
            {
                Id = parMen.Id,
                Menu_Id = parMen.Menu_Id,
                Parameters_Id = parMen.Parameters_Id
            });
        }
        return lparMens;
    }
    
    public void Insert(CreateParMenDto dto)
    {
        ParMen parMen = new ParMen
        {
            Menu_Id = dto.Menu_Id,
            Parameters_Id = dto.Parameters_Id
        };
        _parMen.Add(parMen);
        context.SaveChanges();
    }
    
    public void Update(UpdateParMenDto dto)
    {
        var parMen = _parMen.SingleOrDefault(a => a.Id == dto.Id);
        if (parMen == null) return;

        parMen.Menu_Id = dto.Menu_Id;
        parMen.Parameters_Id = dto.Parameters_Id;

        _parMen.Update(parMen);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var parMen = _parMen.SingleOrDefault(a => a.Id == id);
        if (parMen == null) return;
        _parMen.Remove(parMen);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}