using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _servicesRepository;
        public ServicesController(IServiceRepository servicesRepo) 
        {
            _servicesRepository = servicesRepo ?? throw new ArgumentNullException(nameof(servicesRepo));
        }
        [HttpGet("/GetServices")]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {

            return await _servicesRepository.GetServices();
        }
        [HttpPost("/CreateService")]
        public async Task<ActionResult<Service>> PostService(ServiceDTO serviceDto)
        {
            Service service = await _servicesRepository.PostService(serviceDto);
            return Ok(service);
        }
        [HttpDelete("/DeleteServiceById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok(await _servicesRepository.DeleteServiceById(id));
        }
        [HttpPut("/UpdateServiceById/{id:int}")]
        public async Task<IActionResult> Update(int id, ServiceDTO serviceDto)
        {
            if(await _servicesRepository.UpdateService(id, serviceDto))
            {
                return NoContent();
            }
            return BadRequest("Error al editar el servicio");
        }
    }
}
