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

        public async Task<Activity> PostActivity(ActivityDTO newActivityDto)
        {
            Activity activity = new Activity();
            activity.Name = newActivityDto.Name;
            activity.Code = newActivityDto.Code;
            activity.Category = newActivityDto.Category;
            _context.Actividades.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }
    }
}
