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
    public class ContratoesController : ControllerBase
    {       
        private readonly IContratoRepository _contratoRepository;

        public ContratoesController(IContratoRepository contratoRepo)
        {           
            _contratoRepository = contratoRepo ?? throw new ArgumentNullException(nameof(contratoRepo));
        }
        // GET: api/Contratoes
        [HttpGet("/GetContracts")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            return await _contratoRepository.GetAllContratos();
        }
        // GET: api/Contratoes/5
        [HttpGet("/GetContractById/{id:int}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {           
            return await _contratoRepository.GetContratoById(id);
        }
        //GET: api/contratoes/name
        [HttpGet("/GetContractByName")]
        public async Task<ActionResult<Contrato>> GetContrato(string name)
        {         
            return await _contratoRepository.GetContratoByName(name);
        }
        //GET: api/contratoes/clase
        [HttpGet("/GetContractByClase")]
        public async Task<ActionResult<Contrato>> GetContratoClase(string clase)
        {          
            return await _contratoRepository.GetContratoByClase(clase);
        }
        //GET: api/contratoes/Cliente
        [HttpGet("/GetContractByCliente")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratoByCliente(string clienteName)
        {         
            return await _contratoRepository.GetAllContratosByCliente(clienteName);
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/CreateContrato")]
        public async Task<ActionResult<Contrato>> PostContrato(ContratoDTO contratoDto)
        {
            Contrato contrato = await _contratoRepository.PostContrato(contratoDto);
            return CreatedAtAction("GetContrato", new { id = contrato.Id }, contrato);
        }
        /*// PUT: Clientes/Edit/5
        [HttpPut("/EditClienteById/{id:int}")]
        public async Task<HttpStatusCode> Edit(int? id, [FromBody] Client cliente)
        {
            if (id == null || _context.Clientes == null || _clienteRepository == null)
            {
                return HttpStatusCode.NotFound;
            }

            if (cliente == null)
            {
                return HttpStatusCode.NotFound;
            }
            if (cliente.Id == id)
            {
                _clienteRepository.UpdateClientById(clientId)
                await _context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotModified;
        }*/
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
