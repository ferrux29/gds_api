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
    public class ReportService : ITimeReportRepository
    {
        public readonly AppDbContext _context;
        public ReportService(AppDbContext context)
        {
            _context = context;     
        }
        public async Task<bool> DeleteReportById(int? reportId)
        {
            var report = await _context.Reporte_Tiempo
                .FirstOrDefaultAsync(m => m.Id == reportId);
            if (report == null)
            {
                return false;
            }
            _context.Reporte_Tiempo.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task <List<TimeReport>> GetAllReports()
        {
            return await _context.Reporte_Tiempo.Include(c => c.Client).Include(r => r.Consultant).Include(r => r.Appendix).Include(r => r.Appendix.Contract).ToListAsync();
        }

        public Task<List<TimeReport>> GetAllReportsByConsultant(string consultantName)
        {
            return Task.FromResult(_context.Reporte_Tiempo.Include(r => r.Client).Include(r => r.Consultant).Include(r => r.Appendix).Include(r => r.Appendix.Contract).Where(r => r.ConsultantName == consultantName).ToList());
        }

        public async Task<TimeReport> PostReport(TimeReportDTO newReport)
        {
            Client? client = _context.Clientes.FirstOrDefault(cliente => cliente.Name == newReport.ClientName);
            if (client == null)
            {
                throw new NotFoundException($"Client with name {newReport.ClientName} not found.");
            };
            Consultant? consultant = _context.Consultores.FirstOrDefault(consultor => consultor.Name == newReport.ConsultantName);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with name {newReport.ConsultantName} not found.");
            };
            Appendix? appendix = _context.Anexos.FirstOrDefault(appendix => appendix.ProjectName == newReport.AppendixName);
            if (appendix == null)
            {
                throw new NotFoundException($"Appendix with name of {newReport.AppendixName} not found.");
            };

            TimeReport report = new()
            {
                Serial = newReport.Serial,
                Client = client,
                ClientName = newReport.ClientName,
                Consultant = consultant,
                ConsultantName = newReport.ConsultantName,
                Appendix = appendix,
                AppendixName = newReport.AppendixName,
                Horas = newReport.Horas,
                Observaciones = newReport.Observaciones,
                FirmaCliente = newReport.FirmaCliente,
                FirmaEmpleado = newReport.FirmaEmpleado,
                Activities = newReport.Activities,
            };
            _context.Reporte_Tiempo.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public Task<bool> UpdateReportById(int reportId, TimeReport updatedReport)
        {
            throw new NotImplementedException();
        }
    }
}
