using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class Activity
{
    public long Id { get; set; }
    public string ActivityType { get; set; }
    
    
    
    
    
    // Activity -> Parameters
    public long Parameters_Id { get; set; }
    public Parameters rParameters { get; set; }
    
    
    
    
    
}

public class ActivityMap
{
    public ActivityMap(EntityTypeBuilder<Activity> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.ActivityType).IsRequired();
        
        // Activity -> Parameters
        entityTypeBuilder
            .HasOne(m => m.rParameters)
            .WithOne(f => f.rActivity)
            .HasForeignKey<Activity>(m => m.Parameters_Id);


    }
}