using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class InRec
{
    public long Id { get; set; }
    
    
    // <InRec> -> Recipes
    public long Recipe_Id { get; set; }
    public Recipes rRecipes { get; set; }
    
    
    
    // <InRec> -> Ingredient
    public long Ingredient_Id { get; set; }
    public Ingredients rIngredients { get; set; }
    
    
    
    
    
    
    
    
}




public class InRecMap
{
    public InRecMap(EntityTypeBuilder<InRec> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Ingredient_Id).IsRequired();
        entityTypeBuilder.Property(e => e.Recipe_Id).IsRequired();
        
        
        // <InRec> -> Recipes
        entityTypeBuilder
            .HasOne(m => m.rRecipes)
            .WithMany(f => f.lInRec)
            .HasForeignKey(m => m.Recipe_Id);

        
        
        // <InRec> -> Ingredient
        entityTypeBuilder
            .HasOne(m => m.rIngredients)
            .WithMany(f => f.lInRec)
            .HasForeignKey(m => m.Ingredient_Id);


    }
}

