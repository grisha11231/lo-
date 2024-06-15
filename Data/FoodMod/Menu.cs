using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Menu
{
    public long Id { get; set; }
    public long Diet_Id { get; set; }
    public long Meal_Id  { get; set; }
    
    
    
    
    
    
    
    
    // Menu -> <ParMen>
    public  List<ParMen> lParMen { get; set; }
    
    
    // <Menu> -> Meal
    public  Meal rMeal { get; set; }
    
    // Menu -> Diets
    public Diets rDiets { get; set; }
    
    
    
    
}







public class MenuMap
{
    public MenuMap(EntityTypeBuilder<Menu> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Diet_Id).IsRequired();
        entityTypeBuilder.Property(e => e.Meal_Id).IsRequired();

        
        // Menu -> <ParMen>
        entityTypeBuilder
            .HasMany(m => m.lParMen)
            .WithOne(f => f.rMenu);
        
        
        // <Menu> -> Meal
        entityTypeBuilder
            .HasOne(m => m.rMeal)
            .WithMany(f => f.lMenu)
            .HasForeignKey(m=>m.Meal_Id);
        
        
        // Menu -> Diets
        entityTypeBuilder
            .HasOne(m => m.rDiets)
            .WithOne(f => f.rMenu)
            .HasForeignKey<Menu>(m => m.Diet_Id);
        
        
        
        

    }
}


