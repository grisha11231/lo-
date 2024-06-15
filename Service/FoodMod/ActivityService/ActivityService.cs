using DTO.FoodMod.ActivityDTO;
using Repository.FoodMod.ActivityRepository;

namespace Service.FoodMod.ActivityService;

//Activity
//activity
public class ActivityService(IActivityRepository activityRepository) : IActivityService
{
    private IActivityRepository _activityRepository = activityRepository;
    
    public ActivityDto GetActivity(long id)
    {
        return _activityRepository.Get(id);
    }

    public List<ActivityDto> GetActivity()
    {
        return _activityRepository.GetAll();
    }

    public void InsertActivity(CreateActivityDto dto)
    {
        _activityRepository.Insert(dto);
    }

    public void UpdateActivity(UpdateActivityDto dto)
    {
        _activityRepository.Update(dto);
    }

    public void DeleteActivity(long id)
    {
        _activityRepository.Delete(id);
    }
}