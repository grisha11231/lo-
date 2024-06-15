using Data.FoodMod;
using DTO.FoodMod.ActivityDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.FoodMod.ActivityRepository;


//Activity
//activity
public class ActivityRepository(ApplicationContext context) : IActivityRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Activity> _activity = context.Set<Activity>();
    
    public ActivityDto Get(long id)
    {
        var activity = _activity.SingleOrDefault(a => a.Id == id);
        if (activity == null) return null;
        return new ActivityDto
        {
            Id = activity.Id,
            ActivityType = activity.ActivityType
        };
    }
    
    public List<ActivityDto> GetAll()
    {
        var activitys = _activity.ToList();
        List<ActivityDto> lactivitys = new List<ActivityDto>();

        foreach (var activity in activitys)
        {
            lactivitys.Add(new ActivityDto
            {
                Id = activity.Id,
                ActivityType = activity.ActivityType
            });
        }
        return lactivitys;
    }
    
    public void Insert(CreateActivityDto dto)
    {
        Activity activity = new Activity
        {
            ActivityType = dto.ActivityType
        };
        _activity.Add(activity);
        context.SaveChanges();
    }
    
    public void Update(UpdateActivityDto dto)
    {
        var activity = _activity.SingleOrDefault(a => a.Id == dto.Id);
        if (activity == null) return;

        activity.ActivityType = dto.ActivityType;

        _activity.Update(activity);
        context.SaveChanges();
    }
    
    public void Delete(long id)
    {
        var activity = _activity.SingleOrDefault(a => a.Id == id);
        if (activity == null) return;
        _activity.Remove(activity);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
    
    
    
}