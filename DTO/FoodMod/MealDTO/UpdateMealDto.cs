namespace DTO.FoodMod.MealDTO;

public class UpdateMealDto
{
    public long Id { get; set; }
    public long Recipe_Id { get; set; }
    public DateTime Time  { get; set; }
}