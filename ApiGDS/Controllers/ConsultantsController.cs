using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantRepository _consultantRepository;

        public ConsultantsController(IConsultantRepository consultantRepo)
        {
            _consultantRepository = consultantRepo ?? throw new ArgumentNullException(nameof(consultantRepo));
        }
        // GET: Consultants
        [HttpGet("/GetConsultants")]
        public async Task<ActionResult<IEnumerable<Consultant>>> GetConsultants()
        {
            return await _consultantRepository.GetAllConsultants();
        }
        //GET: consultants/5
        [HttpGet("/GetConsultantById/{id:int}")]
        public async Task<ActionResult<Consultant>> GetConsultant(int id)
        {

            return await _consultantRepository.GetConsultantById(id);
        }
        //GET: consultants/name
        [HttpGet("/GetConsultantByName")]
        public async Task<ActionResult<Consultant>> GetConsultant(string name)
        {
            return await _consultantRepository.GetConsultantByName(name);
        }
        [HttpPost("/CreateConsultant")]
        public async Task<ActionResult<Consultant>> PostConsultant(ConsultantDTO consultantDTO)
        {
            Consultant consultant = await _consultantRepository.PostConsultant(consultantDTO);
            return CreatedAtAction("GetConsultant", new { id = consultant.Id }, consultant);
        }
        [HttpDelete("/DeleteConsultantById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok(await _consultantRepository.DeleteConsultantById(id));
        }
        [HttpPut("/EditConsultantById/{id:int}")]
        public async Task<IActionResult> Update(int id, ConsultantDTO consultantDto)
        {
            if(await _consultantRepository.UpdateConsultantById(id, consultantDto))
            {
                return NoContent();
            }    
            return BadRequest("Error al editar el consultor");
        }
    }
}
