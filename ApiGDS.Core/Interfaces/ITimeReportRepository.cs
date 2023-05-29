using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface ITimeReportRepository
    {
        Task<List<TimeReport>> GetAllReports();
        Task<List<TimeReport>> GetAllReportsByConsultant(string consultantName);
        Task<TimeReport> PostReport(TimeReportDTO newReport);
        Task<bool> UpdateReportById(int reportId, ReportDto updatedReport);
        Task<bool> DeleteReportById(int? reportId);
    }
}
