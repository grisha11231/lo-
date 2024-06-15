namespace DTO.FoodMod.RecipesDTO;

public class UpdateRecipesDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long calories  { get; set; }
    public string instructions   { get; set; }
    public long Meal_Id { get; set; }
}