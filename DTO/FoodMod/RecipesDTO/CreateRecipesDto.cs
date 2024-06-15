namespace DTO.FoodMod.RecipesDTO;

public class CreateRecipesDto
{
    public string Name { get; set; }
    public long calories  { get; set; }
    public string instructions   { get; set; }
    public long Meal_Id { get; set; }
}