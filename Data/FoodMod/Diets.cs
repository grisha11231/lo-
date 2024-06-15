using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Diets
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long Course  { get; set; }
    public string Description  { get; set; }
    public long Type_Id { get; set; }
    
    
    
    // Diets -> Menu
    public long Menu_Id { get; set; }
    public Menu rMenu { get; set; }
    
    
    // <Diets> -> TypeOfDiet
    public TypeOfDiet rTypeOfDiet { get; set; }
    
    
    
    
    
}






public class DietsMap
{
    public DietsMap(EntityTypeBuilder<Diets> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Name).IsRequired();
        entityTypeBuilder.Property(e => e.Course).IsRequired();
        entityTypeBuilder.Property(e => e.Description).IsRequired();
        entityTypeBuilder.Property(e => e.Type_Id).IsRequired();
        
        
        
        // Diets -> Menu
        entityTypeBuilder
            .HasOne(m => m.rMenu)
            .WithOne(f => f.rDiets)
            .HasForeignKey<Diets>(m => m.Menu_Id);

        
        
        // <Diets> -> TypeOfDiet
        entityTypeBuilder
            .HasOne(m => m.rTypeOfDiet)
            .WithMany(f => f.lDiets)
            .HasForeignKey(m => m.Type_Id);


    }
}








