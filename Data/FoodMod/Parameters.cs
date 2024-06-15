using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Parameters
{
    public long Id { get; set; }
    public long User_Id { get; set; }
    public long Weight { get; set; }
    public long Height { get; set; }
    public long Activity_Id { get; set; }
    
    
    
    // Parameters -> User
    public User rUser { get; set; }
    
    
    
    // Parameters -> Activity
    public Activity rActivity { get; set; }
    
    
    // Parameters -> <ParMen>
    public List<ParMen> lParMen { get; set; }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}

public class ParametersMap
{
    public ParametersMap(EntityTypeBuilder<Parameters> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.User_Id).IsRequired();
        entityTypeBuilder.Property(e => e.Weight).IsRequired();
        entityTypeBuilder.Property(e => e.Height).IsRequired();
        entityTypeBuilder.Property(e => e.Activity_Id).IsRequired();

        
        // Parameters -> User
        entityTypeBuilder
            .HasOne(m => m.rUser)
            .WithOne(f => f.rParameters)
            .HasForeignKey<Parameters>(m => m.User_Id);

        
        // Parameters -> Activity
        entityTypeBuilder
            .HasOne(m => m.rActivity)
            .WithOne(f => f.rParameters)
            .HasForeignKey<Parameters>(m => m.Activity_Id);
        
        
        // Parameters -> <ParMen>
        entityTypeBuilder
            .HasMany(m => m.lParMen)
            .WithOne(f => f.rParameters);




    }
}