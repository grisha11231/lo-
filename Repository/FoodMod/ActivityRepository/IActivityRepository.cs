using DTO.FoodMod.ActivityDTO;

namespace Repository.FoodMod.ActivityRepository;



//Activity
public interface IActivityRepository
{
    ActivityDto Get(long id);
    List<ActivityDto> GetAll();
    void Insert(CreateActivityDto dto);
    void Update(UpdateActivityDto dto);
    void Delete(long id);
    void SaveChanges();
}