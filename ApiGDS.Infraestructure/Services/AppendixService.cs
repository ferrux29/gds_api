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
            return await _context.Anexos.Include(c => c.consultant).Include(c => c.Contract).Include(c => c.Contract.Client).Include(s => s.Service).ToListAsync();
        }

        public Task<List<Appendix>> GetAllAppendixesByContract(int contractId)
        {
            return Task.FromResult(_context.Anexos.Include(c => c.consultant).Include(c => c.Contract).Include(c => c.Contract.Client).Include(s => s.Service).Where(a => a.ContractId == contractId).ToList());
        }

        public Task<Appendix> GetAppendixByName(string name) 
        {
            var searchedAnexo = _context.Anexos.Include(c => c.consultant).Include(c => c.Contract).Include(c => c.Contract.Client).Include(s => s.Service).FirstOrDefault(a => a.ProjectName == name);
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
            Contract? contract = _context.Contratos.FirstOrDefault(c => c.Id == newAppendixDto.ContractId);
            if (contract == null)
            {
                throw new NotFoundException($"Contract with name {newAppendixDto.ContractId} not found");
            };
            ApiGDS.Core.Entities.Service? service = _context.Servicios.FirstOrDefault(s => s.Name == newAppendixDto.ServiceName);
            if(service == null)
            {
                throw new NotFoundException($"Service with name {newAppendixDto.ServiceName} not found");
            }
            Appendix appendix = new()
            {
                ProjectName = newAppendixDto.ProjectName,
                Service = service,
                ServiceName = newAppendixDto.ServiceName,
                Assignment = newAppendixDto.Assignment,
                consultant = consultant,
                ConsultorName = newAppendixDto.ConsultorName,
                HorasTrabajadas = newAppendixDto.HorasTrabajadas,
                CostoEstimado = newAppendixDto.CostoEstimado,
                Contract = contract,
                ContractId = newAppendixDto.ContractId,
            };
            _context.Anexos.Add(appendix);
            await _context.SaveChangesAsync();
            return appendix;
        }

        public async Task<bool> UpdateAppendixById(int appendixId, AppendixEditDto updatedAppendix)
        {
            Consultant? consultant = _context.Consultores.FirstOrDefault(c => c.Name == updatedAppendix.ConsultorName);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with name {updatedAppendix.ConsultorName} not found");
            };
            ApiGDS.Core.Entities.Service? service = _context.Servicios.FirstOrDefault(s => s.Name == updatedAppendix.ServiceName);
            if (service == null)
            {
                throw new NotFoundException($"Service with name {updatedAppendix.ServiceName} not found");
            }
            var searchedAppendix = _context.Anexos.FirstOrDefault(a => a.Id == appendixId);
            if(searchedAppendix == null)
            {
                return false;
            }
            searchedAppendix.ProjectName = updatedAppendix.ProjectName;
            searchedAppendix.Service = service;
            searchedAppendix.ServiceName = updatedAppendix.ServiceName;
            searchedAppendix.Assignment = updatedAppendix.Assignment;
            searchedAppendix.consultant = consultant;
            searchedAppendix.ConsultorName = updatedAppendix.ConsultorName;
            searchedAppendix.HorasTrabajadas = updatedAppendix.HorasTrabajadas;
            searchedAppendix.CostoEstimado = updatedAppendix.CostoEstimado;
            _context.Anexos.Update(searchedAppendix);
            var reportes = _context.Reporte_Tiempo.Where(rt => rt.Appendix.Id == appendixId).ToList();
            if(reportes.Any())
            {
                reportes.ForEach(rt =>
                {
                    rt.AppendixName = searchedAppendix.ProjectName;
                    _context.Reporte_Tiempo.Update(rt);
                });
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
