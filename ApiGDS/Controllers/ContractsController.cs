using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGDS.Core.Entities;
using ApiGDS.Infraestructure.DbCtx;
using ApiGDS.Core.Interfaces;
using ApiGDS.Core.Dto;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {       
        private readonly IContractRepository _contratoRepository;

        public ContractsController(IContractRepository contratoRepo)
        {           
            _contratoRepository = contratoRepo ?? throw new ArgumentNullException(nameof(contratoRepo));
        }
        // GET: api/Contratoes
        [HttpGet("/GetContracts")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContratos()
        {
            return await _contratoRepository.GetAllContratos();
        }
        // GET: api/Contratoes/5
        [HttpGet("/GetContractById/{id:int}")]
        public async Task<ActionResult<Contract>> GetContrato(int id)
        {           
            return await _contratoRepository.GetContratoById(id);
        }
        //GET: api/contratoes/Cliente
        [HttpGet("/GetContractByCliente")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContratoByCliente(string clienteName)
        {         
            return await _contratoRepository.GetAllContratosByCliente(clienteName);
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/CreateContrato")]
        public async Task<ActionResult<Contract>> PostContrato(ContractDTo contratoDto)
        {
            Contract contrato = await _contratoRepository.PostContrato(contratoDto);
            return CreatedAtAction("GetContrato", new { id = contrato.Id }, contrato);
        }
        // DELETE: Contratos/delete/5
        [HttpDelete("/DeleteContratoById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok(await _contratoRepository.DeleteContratoById(id));
        }
    }
}
