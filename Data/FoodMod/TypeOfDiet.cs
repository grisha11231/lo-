using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class TypeOfDiet
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    
    
    // TypeOfDiet -> <Diets>
    public List<Diets> lDiets { get; set; }
    
    
    
    
    
    
}





public class TypeOfDietMap
{
    public TypeOfDietMap(EntityTypeBuilder<TypeOfDiet> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Name).IsRequired();
        
        
        // TypeOfDiet -> <Diets>
        entityTypeBuilder
            .HasMany(m => m.lDiets)
            .WithOne(f => f.rTypeOfDiet);

    }
}


