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
        
        [HttpDelete("/DeleteActivityById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) 
                return NotFound();
            return Ok(await _activityRepository.DeleteActivityById(id));
        }

        [HttpGet("/GetActivitiesByReport")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByReport(int reportId)
        {
            return await _activityRepository.GetAllActivitiesByReport(reportId);
        }
        [HttpPut("/EditActivityById/{id:int}")]
        public async Task<IActionResult> Update(int id, ActivityDTO activity)
        {
            if(await _activityRepository.UpdateActivityById(id, activity))
            {
                return NoContent();
            }
            return BadRequest("Error al editar la actividad");
        }
        [HttpPost("/CreateActivity")]
        public async Task<ActionResult<Activity>> PostActivity(ActivityDTO newActivity)
        {
            Activity activity = await _activityRepository.PostActivity(newActivity);
            return Ok(activity);
        }
    }
}
