using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        private readonly ITimeReportRepository _timeReportRepository;
        public TimeReportsController(ITimeReportRepository timeReportRepository)
        {
            _timeReportRepository = timeReportRepository ?? throw new ArgumentNullException(nameof(timeReportRepository));
        }
        [HttpGet("/GetReports")]
        public async Task<ActionResult<IEnumerable<TimeReport>>> GetReports()
        {
            return await _timeReportRepository.GetAllReports();
        }
        [HttpGet("/GetReportsByConsultant")]
        public async Task<ActionResult<IEnumerable<TimeReport>>> GetReportByConsultant(string consultantName)
        {
            return await _timeReportRepository.GetAllReportsByConsultant(consultantName);
        }
        [HttpPost("/CreateReport")]
        public async Task<ActionResult<TimeReport>> PostReport(TimeReportDTO timeReportDTO)
        {
            TimeReport report = await _timeReportRepository.PostReport(timeReportDTO);
            return Ok(report);
        }
        [HttpDelete("/DeleteReport")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return Ok(await _timeReportRepository.DeleteReportById(id));
        }
        [HttpPut("/EditReportById/{id:int}")]
        public async Task<IActionResult> Update(int id, ReportDto timeReportDto)
        {
            if(await _timeReportRepository.UpdateReportById(id, timeReportDto))
            {
                return NoContent();
            }
            return BadRequest("Error al editar reporte");
        }
    }
}
