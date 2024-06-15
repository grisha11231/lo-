using Data.FoodMod;
using DTO.FoodMod.DietsDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.DietsRepository;


//Diets
//diets
public class DietsRepository(ApplicationContext context) : IDietsRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Diets> _diets = context.Set<Diets>();
    
    public DietsDto Get(long id)
    {
        var diets = _diets.SingleOrDefault(a => a.Id == id);
        if (diets == null) return null;
        return new DietsDto
        {
            Id = diets.Id,
            Name = diets.Name,
            Course = diets.Course,
            Description = diets.Description,
            Type_Id = diets.Type_Id
        };
    }
    
    public List<DietsDto> GetAll()
    {
        var dietss = _diets.ToList();
        List<DietsDto> ldietss = new List<DietsDto>();

        foreach (var diets in dietss)
        {
            ldietss.Add(new DietsDto
            {
                Id = diets.Id,
                Name = diets.Name,
                Course = diets.Course,
                Description = diets.Description,
                Type_Id = diets.Type_Id
            });
        }
        return ldietss;
    }
    
    public void Insert(CreateDietsDto dto)
    {
        Diets diets = new Diets
        {
            Name = dto.Name,
            Course = dto.Course,
            Description = dto.Description,
            Type_Id = dto.Type_Id
        };
        _diets.Add(diets);
        context.SaveChanges();
    }
    
    public void Update(UpdateDietsDto dto)
    {
        var diets = _diets.SingleOrDefault(a => a.Id == dto.Id);
        if (diets == null) return;

        diets.Name = dto.Name;
        diets.Course = dto.Course;
        diets.Description = dto.Description;
        diets.Type_Id = dto.Type_Id;

        _diets.Update(diets);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var diets = _diets.SingleOrDefault(a => a.Id == id);
        if (diets == null) return;
        _diets.Remove(diets);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}