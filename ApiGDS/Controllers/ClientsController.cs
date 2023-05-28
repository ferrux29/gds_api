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
using ApiGDS.Infraestructure.Service;
using ApiGDS.Core.Dto;
using System.Net;

namespace ApiGDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
       
        private readonly IClienteRepository _clienteRepository;

        public ClientsController(IClienteRepository clientRepo)
        {           
            _clienteRepository = clientRepo ?? throw new ArgumentNullException(nameof(clientRepo));
        }

        // GET: Clients
        [HttpGet("/GetClients")]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
           
            return await _clienteRepository.GetAllClients();
        }
        //GET: clients/5
        [HttpGet("/GetClientsById/{id:int}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
           
            return await _clienteRepository.GetClientById(id);
        }
        //GET: clients/name
        [HttpGet("/GetClientsByName/")]
        public async Task<ActionResult<Client>> GetClient(string name)
        {
            return await _clienteRepository.GetClientByName(name);
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/CreateClient")]
        public async Task<ActionResult<Client>> PostClient(ClientDTO clientDto)
        {
            Client client = await _clienteRepository.PostClient(clientDto);
            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }
        // PUT: Clientes/Edit/5
        [HttpPut("/EditClienteById/{id:int}")]
        public async Task<IActionResult> Update(int id, ClientDTO clientDto)
        {
            if (await _clienteRepository.UpdateClientById(id, clientDto))
            {
                return NoContent();
            };
            return BadRequest("Error al editar el cliente");
        }
        // DELETE: Clientes/delete/5
        [HttpDelete("/DeleteClienteById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();          
            return Ok(await _clienteRepository.DeleteClientById(id));
        }
    }
}
