using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetServices();
        Task<Service> PostService(ServiceDTO newServiceDTO);
        Task<bool> UpdateService(int serviceId, ServiceDTO updatedService);
        Task<bool> DeleteServiceById(int? serviceId);
    }
}
