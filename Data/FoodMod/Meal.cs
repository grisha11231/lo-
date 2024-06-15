using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Meal
{
    public long Id { get; set; }
    public long Recipe_Id { get; set; }
    public DateTime Time  { get; set; }
    
    
    
    
    
    // Meal -> <Menu>
    public List<Menu> lMenu { get; set; }
    
    
    
    
    
    // Meal -> <Recipes>
    public List<Recipes> lRecipes { get; set; }
    
    
    
    
    
    
    
    
    
    
}






public class MealMap
{
    public MealMap(EntityTypeBuilder<Meal> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Recipe_Id).IsRequired();
        entityTypeBuilder.Property(e => e.Time).IsRequired();
        
        
        // <Meal> -> Menu
        entityTypeBuilder
            .HasMany(m => m.lMenu)
            .WithOne(f => f.rMeal);

        
        // Meal -> <Recipes>
        entityTypeBuilder
            .HasMany(m => m.lRecipes)
            .WithOne(f => f.rMeal);

    }
}





