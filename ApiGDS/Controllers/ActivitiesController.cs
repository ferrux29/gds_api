using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        public ActivitiesController(IActivityRepository activityRepo)
        {
            _activityRepository = activityRepo ?? throw new ArgumentException(nameof(activityRepo));
        }
        [HttpGet("/GetActivities")]
        public async Task<ActionResult<IEnumerable<Activity>>> Get()
        {
            return await _activityRepository.GetAllActivities();
        }
        [HttpPost("/CreateActivity")]
        public async Task<ActionResult<Activity>> PostActivity(ActivityDTO activityDto)
        {
            Activity activity = await _activityRepository.PostActivity(activityDto);
            return Ok(activity);
        }
        [HttpDelete("/DeleteActivityById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) 
                return NotFound();
            return Ok(await _activityRepository.DeleteActivityById(id));
        }
    }
}
