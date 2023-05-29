using ApiGDS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Infraestructure.DbCtx
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clientes  { get; set; }
        public DbSet<Contract> Contratos { get; set; }
        public DbSet<Consultant> Consultores { get; set; }
        public DbSet<Appendix> Anexos { get; set; }
        public DbSet<TimeReport> Reporte_Tiempo { get; set; }
        public DbSet<ApiGDS.Core.Entities.Service> Servicios { get; set; }
        public DbSet<Activity> Actividades { get; set; }
    }

}
