using DTO.FoodMod.ActivityDTO;

namespace Service.FoodMod.ActivityService;




//Activity
public interface IActivityService
{
    ActivityDto GetActivity(long id);
    List<ActivityDto> GetActivity();
    void InsertActivity(CreateActivityDto dto);
    void UpdateActivity(UpdateActivityDto dto);
    void DeleteActivity(long id);
}