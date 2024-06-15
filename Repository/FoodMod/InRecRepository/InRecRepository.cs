using Data.FoodMod;
using DTO.FoodMod.InRecDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.InRecRepository;


//InRec
//inRec
public class InRecRepository(ApplicationContext context) : IInRecRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<InRec> _inRec = context.Set<InRec>();
    
    public InRecDto Get(long id)
    {
        var inRec = _inRec.SingleOrDefault(a => a.Id == id);
        if (inRec == null) return null;
        return new InRecDto
        {
            Id = inRec.Id,
            Ingredient_Id = inRec.Ingredient_Id,
            Recipe_Id = inRec.Recipe_Id
        };
    }
    
    public List<InRecDto> GetAll()
    {
        var inRecs = _inRec.ToList();
        List<InRecDto> linRecs = new List<InRecDto>();

        foreach (var inRec in inRecs)
        {
            linRecs.Add(new InRecDto
            {
                Id = inRec.Id,
                Ingredient_Id = inRec.Ingredient_Id,
                Recipe_Id = inRec.Recipe_Id
            });
        }
        return linRecs;
    }
    
    public void Insert(CreateInRecDto dto)
    {
        InRec inRec = new InRec
        {
            Ingredient_Id = dto.Ingredient_Id,
            Recipe_Id = dto.Recipe_Id
        };
        _inRec.Add(inRec);
        context.SaveChanges();
    }
    
    public void Update(UpdateInRecDto dto)
    {
        var inRec = _inRec.SingleOrDefault(a => a.Id == dto.Id);
        if (inRec == null) return;

        inRec.Ingredient_Id = dto.Ingredient_Id;
        inRec.Recipe_Id = dto.Recipe_Id;

        _inRec.Update(inRec);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var inRec = _inRec.SingleOrDefault(a => a.Id == id);
        if (inRec == null) return;
        _inRec.Remove(inRec);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}