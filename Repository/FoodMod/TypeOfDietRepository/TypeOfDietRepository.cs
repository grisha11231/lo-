using Data.FoodMod;
using DTO.FoodMod.TypeOfDietDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.TypeOfDietRepository;


//TypeOfDiet
//typeOfDiet
public class TypeOfDietRepository(ApplicationContext context) : ITypeOfDietRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<TypeOfDiet> _typeOfDiet = context.Set<TypeOfDiet>();
    
    public TypeOfDietDto Get(long id)
    {
        var typeOfDiet = _typeOfDiet.SingleOrDefault(a => a.Id == id);
        if (typeOfDiet == null) return null;
        return new TypeOfDietDto
        {
            Id = typeOfDiet.Id,
            Name = typeOfDiet.Name
        };
    }
    
    public List<TypeOfDietDto> GetAll()
    {
        var typeOfDiets = _typeOfDiet.ToList();
        List<TypeOfDietDto> ltypeOfDiets = new List<TypeOfDietDto>();

        foreach (var typeOfDiet in typeOfDiets)
        {
            ltypeOfDiets.Add(new TypeOfDietDto
            {
                Id = typeOfDiet.Id,
                Name = typeOfDiet.Name
            });
        }
        return ltypeOfDiets;
    }
    
    public void Insert(CreateTypeOfDietDto dto)
    {
        TypeOfDiet typeOfDiet = new TypeOfDiet
        {
            Name = dto.Name
        };
        _typeOfDiet.Add(typeOfDiet);
        context.SaveChanges();
    }
    
    public void Update(UpdateTypeOfDietDto dto)
    {
        var typeOfDiet = _typeOfDiet.SingleOrDefault(a => a.Id == dto.Id);
        if (typeOfDiet == null) return;

        typeOfDiet.Name = dto.Name;

        _typeOfDiet.Update(typeOfDiet);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var typeOfDiet = _typeOfDiet.SingleOrDefault(a => a.Id == id);
        if (typeOfDiet == null) return;
        _typeOfDiet.Remove(typeOfDiet);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}