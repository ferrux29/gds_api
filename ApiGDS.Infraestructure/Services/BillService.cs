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

namespace ApiGDS.Infraestructure.Services
{
    public class BillService : IBillRepository
    {
        public readonly AppDbContext _context;
        public BillService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBillById(int? id)
        {
            var bill = await _context.Facturas.FirstOrDefaultAsync(b => b.Id == id);
            if (bill == null)
            {
                return false;
            }
            _context.Facturas.Remove(bill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Bill>> GetAllBills()
        {
            return await _context.Facturas.Include(c => c.Client).Include(c => c.Consultant).Include(a => a.Appendix).ToListAsync();
        }

        public Task<Bill> GetBillById(int id)
        {
            var searchedBill = _context.Facturas.FirstOrDefault(b => b.Id == id);
            if (searchedBill == null)
            {
                throw new NotFoundException($"Bill with id {id} not found.");
            }

            return Task.FromResult(searchedBill);
        }

        public async Task<Bill> PostBill(BillDTO newBillDTO)
        {
            Client? client = _context.Clientes.FirstOrDefault(cliente => cliente.Name == newBillDTO.ClientName);
            if (client == null)
            {
                throw new NotFoundException($"Client with name {newBillDTO.ClientName} not found.");
            };
            Consultant? consultant = _context.Consultores.FirstOrDefault(consultor => consultor.Name == newBillDTO.ConsultantName);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with name {newBillDTO.ConsultantName} not found.");
            };
            Appendix? appendix = _context.Anexos.FirstOrDefault(appendix => appendix.MontoFacturado == newBillDTO.AppendixMontoFacturado);
            if (appendix == null)
            {
                throw new NotFoundException($"Consultant with name {newBillDTO.ConsultantName} not found.");
            };
            Bill bill = new()
            {
                Name = newBillDTO.Name,
                Description = newBillDTO.Description,
                ClientName = newBillDTO.ClientName,
                Client = client,
                ConsultantName = newBillDTO.ConsultantName,
                Consultant = consultant,
                AppendixMontoFacturado = newBillDTO.AppendixMontoFacturado,
                Appendix = appendix
            };
            _context.Facturas.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public Task<bool> UpdateBillById(int id, Bill updatedBill)
        {
            throw new NotImplementedException();
        }
    }
}
