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
    public class AppendixService : IAppendixRepository
    {
        private readonly AppDbContext _context;
        public AppendixService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAppendixById(int? appendixId)
        {
            var Appendix = await _context.Anexos.FirstOrDefaultAsync(a => a.Id == appendixId);
            if (Appendix == null) 
            { 
                return false;
            }
            _context.Anexos.Remove(Appendix);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Appendix>> GetAllAppendix()
        {
            return await _context.Anexos.Include(a => a.consultant).ToListAsync();
        }

        public Task<List<Appendix>> GetAllAppendixesByConsultor(string consultantName)
        {
            return Task.FromResult(_context.Anexos.Where(a => a.ConsultorName == consultantName).ToList());
        }

        public Task<Appendix> GetAppendixByName(string name) 
        {
            var searchedAnexo = _context.Anexos.FirstOrDefault(a => a.Name == name);
            if(searchedAnexo == null)
            {
                throw new NotFoundException($"Anexo with name {name} not found.");
            }
            return Task.FromResult(searchedAnexo);
        }

        public async Task<Appendix> PostAppendix(AppendixDTO newAppendixDto)
        {
            Consultant? consultant = _context.Consultores.FirstOrDefault(c=> c.Name == newAppendixDto.ConsultorName);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with name {newAppendixDto.ConsultorName} not found");
            };
            Appendix appendix = new()
            {
                consultant = consultant,
                ConsultorName = newAppendixDto.ConsultorName,
                HorasTrabajadas = newAppendixDto.HorasTrabajadas,
                CostoEstimado = newAppendixDto.CostoEstimado,
                MontoFacturado = newAppendixDto.MontoFacturado
            };
            _context.Anexos.Add(appendix);
            await _context.SaveChangesAsync();
            return appendix;
        }

        public async Task<bool> UpdateAppendixById(int appendixId, Appendix updatedAppendix)
        {
            throw new NotImplementedException();
        }
    }
}
