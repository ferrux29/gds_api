using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IAppendixRepository
    {
        Task<List<Appendix>> GetAllAppendix();
        Task<Appendix> GetAppendixByName(string name);
        Task<List<Appendix>> GetAllAppendixesByContract(int contractId);
        Task<Appendix> PostAppendix(AppendixDTO newAppendixDto);
        Task<bool> UpdateAppendixById(int appendixId, Appendix updatedAppendix);
        Task<bool> DeleteAppendixById(int? appendixId);
    }
}
