using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppendixesController : ControllerBase
    {
        private readonly IAppendixRepository _appendixRepository;
        public AppendixesController(IAppendixRepository appendixRepository)
        {
            _appendixRepository = appendixRepository ?? throw new ArgumentNullException(nameof(appendixRepository));
        }
        [HttpGet("/GetAppendixes")]
        public async Task<ActionResult<IEnumerable<Appendix>>> Get()
        {
            return await _appendixRepository.GetAllAppendix();
        }
        [HttpGet("/GetAppendixByConsultant")]
        public async Task<ActionResult<IEnumerable<Appendix>>> GetAppendixByConsultant(string consultantName)
        {
            return await _appendixRepository.GetAllAppendixesByConsultor(consultantName);
        }
        [HttpPost("/CreateAppendix")]
        public async Task<ActionResult<Appendix>> PostAppendix(AppendixDTO appendixDTO)
        {
            Appendix appendix = await _appendixRepository.PostAppendix(appendixDTO);
            return Ok(appendix);
        }
        [HttpDelete("/DeleteAppendixById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok(await _appendixRepository.DeleteAppendixById(id));
        }
    }
}
