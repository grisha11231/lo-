using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Ingredients
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    
    
    
    
    
    // Ingredients -> <InRec>
    public List<InRec> lInRec { get; set; }
    
    
}


public class IngredientsMap
{
    public IngredientsMap(EntityTypeBuilder<Ingredients> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Name).IsRequired();
        entityTypeBuilder.Property(e => e.Type).IsRequired();
        
        
        // Ingredients -> <InRec>
        entityTypeBuilder
            .HasMany(m => m.lInRec)
            .WithOne(f => f.rIngredients);
    }
}