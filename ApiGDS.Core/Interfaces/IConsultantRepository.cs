using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IConsultantRepository
    {
        Task<List<Consultant>> GetAllConsultants();
        Task<Consultant> GetConsultantById(int id);
        Task<Consultant> GetConsultantByName(string name);
        Task<Consultant> PostConsultant(ConsultantDTO newConsultantDto);
        Task<bool> UpdateConsultantById(int consultantId, ConsultantDTO updatedConsultant);
        Task<bool> DeleteConsultantById(int? consultantId);
    }
}
