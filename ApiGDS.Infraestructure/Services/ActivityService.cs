using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Infraestructure.Services
{
    public class ActivityService : IActivityRepository
    {
        private readonly AppDbContext _context;
        public ActivityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteActivityById(int? activityId)
        {
            var activity = await _context.Actividades.FirstOrDefaultAsync(m =>  m.Id == activityId);
            if (activity == null) 
            { 
                return false; 
            }
            _context.Actividades.Remove(activity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Activity>> GetAllActivities()
        {
            return Task.FromResult(_context.Actividades.ToList());
        }

        public async Task<bool> UpdateActivityById(int activityId, ActivityDTO updatedActivity)
        {
            var searchedActivity = _context.Actividades.FirstOrDefault(a => a.Id == activityId);
            if(searchedActivity == null)
            {
                return false;
            }
            searchedActivity.Name = updatedActivity.Name;
            searchedActivity.Code = updatedActivity.Code;
            searchedActivity.Category = updatedActivity.Category;
            _context.Actividades.Update(searchedActivity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
