﻿using System;
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
        private readonly DataContext _context;
        private readonly IClienteRepository _clienteRepository;

        public ClientsController(DataContext context, IClienteRepository clientRepo)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _clienteRepository = clientRepo ?? throw new ArgumentNullException(nameof(clientRepo));
        }

        // GET: Clients
        [HttpGet("/GetClients")]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            return await _clienteRepository.GetAllClients();
        }
        //GET: clients/5
        [HttpGet("/GetClientsById/{id:int}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            return await _clienteRepository.GetClientById(id);
        }
        //GET: clients/name
        [HttpGet("/GetClientsByName/")]
        public async Task<ActionResult<Client>> GetClient(string name)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
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
        // DELETE: Clientes/delete/5
        [HttpDelete("/DeleteClienteById/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }
            return Ok(await _clienteRepository.DeleteClientById(id));
        }
    }
}