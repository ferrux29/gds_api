using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Exceptions;
using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using Microsoft.EntityFrameworkCore;

namespace ApiGDS.Infraestructure.Service
{
    public class ClientService : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Client>> GetAllClients()
        {
            return Task.FromResult(_context.Clientes.ToList());
        }
        
        public Task<Client> GetClientById(int id)
        {
            var searchedClient = _context.Clientes.FirstOrDefault(client => client.Id == id);
            if (searchedClient == null)
            {
                throw new NotFoundException($"Client with id {id} not found.");
            }

            return Task.FromResult(searchedClient);
        }
        public  Task<Client> GetClientByName(string name)
        {
            var searchedClient = _context.Clientes.FirstOrDefault(client => client.Name == name);
            if (searchedClient == null)
            {
                throw new NotFoundException($"Client with name {name} not found.");
            }

            return Task.FromResult(searchedClient);
        }
        public async Task<Client> PostClient(ClientDTO newClientDTO)
        {
            Client client = new Client();
            client.Name = newClientDTO.Name;
            client.ClienteCategory = newClientDTO.ClienteCategory;
            _context.Clientes.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> UpdateClientById(int clientId, ClientDTO updatedClient)
        {
            var searchedClient = _context.Clientes.FirstOrDefault(client => client.Id == clientId);
            if (searchedClient == null) 
            {
                return false;
            }
            searchedClient.Name = updatedClient.Name;
            searchedClient.ClienteCategory = updatedClient.ClienteCategory;
            _context.Clientes.Update(searchedClient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClientById(int? clientId)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == clientId);
            if (cliente == null) 
            { 
                return false; 
            }
             _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
            
        }

    }
}
