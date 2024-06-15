using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.FoodMod;

public class ParMen
{
    public long Id { get; set; }
    
    
    // <ParMen> -> Parameters
    public long Parameters_Id { get; set; }
    public Parameters rParameters { get; set; }
    
    
    // <ParMen> -> Menu
    public long Menu_Id { get; set; }
    public Menu rMenu { get; set; }
    
    
    
    
    
}




public class ParMenMap
{
    public ParMenMap(EntityTypeBuilder<ParMen> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);
        entityTypeBuilder.Property(e => e.Menu_Id).IsRequired();
        entityTypeBuilder.Property(e => e.Parameters_Id).IsRequired();
        
        
        // <ParMen> -> Parameters
        entityTypeBuilder
            .HasOne(m => m.rParameters)
            .WithMany(f => f.lParMen)
            .HasForeignKey(m => m.Parameters_Id);
        

        // <ParMen> -> Menu
        entityTypeBuilder
            .HasOne(m => m.rMenu)
            .WithMany(f => f.lParMen)
            .HasForeignKey(m => m.Menu_Id);






    }
}