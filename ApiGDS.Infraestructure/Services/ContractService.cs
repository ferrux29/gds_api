using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using ApiGDS.Core.Exceptions;
using ApiGDS.Core.Interfaces;
using ApiGDS.Infraestructure.DbCtx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Infraestructure.Service
{
    public class ContractService : IContractRepository 
    {
        public  readonly AppDbContext _context;
        public ContractService(AppDbContext context) {  
            _context = context; 
        }

        public async Task<List<Contract>> GetAllContratos()
        {
            return await _context.Contratos.Include(c => c.Client).Include(s => s.Service).ToListAsync();
        }
        public Task<Contract> GetContratoById(int id)
        {
            var searchedContrato = _context.Contratos.Include(c => c.Client).Include(s => s.Service).FirstOrDefault(
                contrato => contrato.Id == id);

            if (searchedContrato == null)
            {
                throw new NotFoundException($"Contrato with id {id} not found.");
            }

            return Task.FromResult(searchedContrato);
        }
        public Task<List<Contract>> GetAllContratosByCliente(string clienteName) 
        { 
            return Task.FromResult(_context.Contratos.Include(c=>c.Client).Where(contratos => contratos.ClienteName== clienteName).ToList());
        }
        public async Task<Contract> PostContrato(ContractDTo newContratoDTO)
        {
            Client? client = _context.Clientes.FirstOrDefault(cliente => cliente.Name == newContratoDTO.ClienteName);
            if (client == null) 
            {
                throw new NotFoundException($"Cliente with name {newContratoDTO.ClienteName} not found.");
            };
            ApiGDS.Core.Entities.Service? service = _context.Servicios.FirstOrDefault(s => s.Name == newContratoDTO.ServiceName);
            if (service == null)
            {
                throw new NotFoundException($"Servicio with name {newContratoDTO.ClienteName} not found.");
            };

            Contract contrato = new()
            {              
                Clase = newContratoDTO.Clase,
                MontoMax = newContratoDTO.MontoMax,
                ClienteName = newContratoDTO.ClienteName,
                Client = client,
                Fianza = newContratoDTO.Fianza,
                ServiceName = newContratoDTO.ServiceName,
                Service = service,
            };
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();
            return contrato;
        }

        public Task<bool> UpdateContratoById(int contratoId, Contract updatedContrato)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteContratoById(int? contratoId)
        {
            var contrato = await _context.Contratos
                .FirstOrDefaultAsync(m => m.Id == contratoId);
            if (contrato == null) 
            { 
                return false; 
            }
            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
