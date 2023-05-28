﻿using ApiGDS.Core.Dto;
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
        Task<Activity> PostActivity(ActivityDTO newActivityDto);
        Task<bool> DeleteActivityById(int? activityId);
    }
}
