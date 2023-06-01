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
        private readonly AppDbContext _context;
        public BillService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteBillById(int? billId)
        {
            var bill = await _context.Facturas.FirstOrDefaultAsync(b => b.Id == billId);
            if(bill == null)
            {
                return false;
            }
            _context.Facturas.Remove(bill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Bill>> GetAllBills()
        {
            return await _context.Facturas.Include(b => b.Client).ToListAsync();
        }

        public async Task<Bill> PostBill(BillDTO newBilldto)
        {
            Client? client = _context.Clientes.FirstOrDefault(cliente => cliente.Name == newBilldto.ClientName);
            if (client == null)
            {
                throw new NotFoundException($"Cliente with name {newBilldto.ClientName} not found.");
            };
            Bill bill = new()
            {
                IssueDate = newBilldto.IssueDate,
                Code = newBilldto.Code,
                Note = newBilldto.Note,
                Total = newBilldto.Total,
                Client = client,
                ClientName = newBilldto.ClientName,
            };
            _context.Facturas.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }
    }
}
