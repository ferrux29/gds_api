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
    public class ContratoService : IContratoRepository 
    {
        public  readonly AppDbContext _context;
        public ContratoService(AppDbContext context) {  
            _context = context; 
        }

        public async Task<List<Contrato>> GetAllContratos()
        {
            return await _context.Contratos.Include(c => c.Client).ToListAsync();
        }
        public Task<Contrato> GetContratoById(int id)
        {
            var searchedContrato = _context.Contratos.FirstOrDefault(
                contrato => contrato.Id == id
            );

            if (searchedContrato == null)
            {
                throw new NotFoundException($"Contrato with id {id} not found.");
            }

            return Task.FromResult(searchedContrato);
        }
        public Task<Contrato> GetContratoByName(string name)
        {
            var searchedContrato = _context.Contratos.FirstOrDefault(contrato => contrato.Name == name);
            if (searchedContrato == null)
            {
                throw new NotFoundException($"Contrato with name {name} not found.");
            }

            return Task.FromResult(searchedContrato);
        }
        public Task<Contrato> GetContratoByClase(string clase) 
        { 
            var searchedContrato = _context.Contratos.FirstOrDefault(contrato => contrato.Clase== clase);
            if(searchedContrato == null) 
            {
                throw new NotFoundException($"Contrato with clase {clase} not found.");
            }
            return Task.FromResult<Contrato>(searchedContrato);
        }
        public Task<List<Contrato>> GetAllContratosByCliente(string clienteName) 
        { 
            return Task.FromResult(_context.Contratos.Where(contratos => contratos.ClienteName== clienteName).ToList());
        }
        public async Task<Contrato> PostContrato(ContratoDTO newContratoDTO)
        {
            Client? client = _context.Clientes.FirstOrDefault(cliente => cliente.Name == newContratoDTO.ClienteName);
            if (client == null) 
            {
                throw new NotFoundException($"Cliente with name {newContratoDTO.ClienteName} not found.");
            };

            Contrato contrato = new()
            {
                Name = newContratoDTO.Name,
                Clase = newContratoDTO.Clase,
                ClienteName = newContratoDTO.ClienteName,
                Client = client
            };
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();
            return contrato;
        }

        public Task<bool> UpdateContratoById(int contratoId, Contrato updatedContrato)
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
