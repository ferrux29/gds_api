using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllActivities();
        Task<List<Activity>> GetAllActivitiesByReport(int reportId);
        Task<Activity> PostActivity(ActivityDTO newActivity);
        Task<bool> UpdateActivityById(int activityId, ActivityDTO updatedActivity);
        Task<bool> DeleteActivityById(int? activityId);
    }
}
