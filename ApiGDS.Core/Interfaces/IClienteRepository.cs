using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
        Task<Client> GetClientByName(string name);
        Task<Client> PostClient(ClientDTO newClientDto);
        Task<bool> UpdateClientById(int clientId, Client updatedClient);
        Task<bool> DeleteClientById(int? clienteId);
    }
}
