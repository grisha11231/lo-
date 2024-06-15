namespace DTO.FoodMod.DietsDTO;

public class UpdateDietsDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long Course  { get; set; }
    public string Description  { get; set; }
    public long Type_Id { get; set; }
}