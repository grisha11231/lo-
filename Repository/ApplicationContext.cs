using Data.FoodMod;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using User = Data.FoodMod.User;


namespace Repository;



public class  ApplicationContext : IdentityDbContext<User, IdentityRole<long>, long>
{

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // FoodMod
        new ActivityMap(modelBuilder.Entity<Activity>());
        new DietsMap(modelBuilder.Entity<Diets>());
        new IngredientsMap(modelBuilder.Entity<Ingredients>());
        new InRecMap(modelBuilder.Entity<InRec>());
        new MealMap(modelBuilder.Entity<Meal>());
        new MenuMap(modelBuilder.Entity<Menu>());
        new ParametersMap(modelBuilder.Entity<Parameters>());
        new ParMenMap(modelBuilder.Entity<ParMen>());
        new RecipesMap(modelBuilder.Entity<Recipes>());
        new TypeOfDietMap(modelBuilder.Entity<TypeOfDiet>());
        
        
        
    }
    
    
    
    
    
    
    
    
    
   
}

