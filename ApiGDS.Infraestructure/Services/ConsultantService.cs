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
    public class ConsultantService: IConsultantRepository
    {
        public readonly AppDbContext _context;
        public ConsultantService(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Consultant>> GetAllConsultants() 
        { 
            return Task.FromResult(_context.Consultores.ToList());
        }

        public Task<Consultant> GetConsultantById(int id) 
        { 
            var searchedConsultant = _context.Consultores.FirstOrDefault(consultant => consultant.Id == id);
            if(searchedConsultant == null) 
            { 
                throw new NotFoundException($"Consultant with id {id} not found."); 
            }
            return Task.FromResult(searchedConsultant);
        }
        public Task<Consultant> GetConsultantByName(string name)
        {
            var searchedConsultant = _context.Consultores.FirstOrDefault(consultant => consultant.Name == name);
            if (searchedConsultant == null)
            {
                throw new NotFoundException($"Consultant with name {name} not found.");
            }
            return Task.FromResult(searchedConsultant);
        }
        public async Task<Consultant> PostConsultant(ConsultantDTO newConsultantDTO) 
        {
            Consultant consultant = new Consultant();
            consultant.Name = newConsultantDTO.Name;
            _context.Consultores.Add(consultant);
            await _context.SaveChangesAsync();
            return consultant;
        }
        public async Task<bool> UpdateConsultantById(int consultantId, ConsultantDTO updatedConsultant)
        {
            var searchedConsultant = _context.Consultores.FirstOrDefault(c => c.Id == consultantId);
            if(searchedConsultant == null)
            {
                return false;
            }
            searchedConsultant.Name = updatedConsultant.Name;
            _context.Consultores.Update(searchedConsultant);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteConsultantById(int? consultantId) 
        {
            var Consultant = await _context.Consultores.FirstOrDefaultAsync(c => c.Id == consultantId);
            if (Consultant == null) 
            { 
                return  false; 
            }
            _context.Consultores.Remove(Consultant);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
