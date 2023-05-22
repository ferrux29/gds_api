using ApiGDS.Core.Dto;
using ApiGDS.Core.Entities;
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
    public class ServicioService : IServiceRepository
    {
        private readonly AppDbContext _context;
        public ServicioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteServiceById(int? serviceId)
        {
            var service = await _context.Servicios.FirstOrDefaultAsync(s => s.Id == serviceId);
            if (service == null)
            {
                return false;
            }
            _context.Servicios.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Core.Entities.Service>> GetServices()
        {
            return Task.FromResult(_context.Servicios.ToList());
        }

        public async Task<Core.Entities.Service> PostService(ServiceDTO newServiceDto)
        {
            ApiGDS.Core.Entities.Service service = new();
            service.Name = newServiceDto.Name;
            service.Price = newServiceDto.Price;
            service.Description = newServiceDto.Description;
            _context.Servicios.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public Task<bool> UpdateService(int serviceId, Core.Entities.Service updatedService)
        {
            throw new NotImplementedException();
        }
    }
}
