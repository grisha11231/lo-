using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Recipes
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long calories  { get; set; }
    public string instructions   { get; set; }
    public long Meal_Id { get; set; }
    
    
    
    // <Recipes> -> Meal
    public Meal rMeal { get; set; }
    
    // Recipes -> <InRec>
    public List<InRec> lInRec { get; set; }
    
    
    
}






public class RecipesMap
{
    public RecipesMap(EntityTypeBuilder<Recipes> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Name).IsRequired();
        entityTypeBuilder.Property(e => e.calories).IsRequired();
        entityTypeBuilder.Property(e => e.instructions).IsRequired();


        // <Recipes> -> Meal
        entityTypeBuilder
            .HasOne(m => m.rMeal)
            .WithMany(f => f.lRecipes)
            .HasForeignKey(m => m.Meal_Id);
        
        
        // Recipes -> <InRec>
        entityTypeBuilder
            .HasMany(m => m.lInRec)
            .WithOne(f => f.rRecipes);




    }
}





