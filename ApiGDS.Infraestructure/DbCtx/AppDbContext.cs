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
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Consultant> Consultores { get; set; }
        public DbSet<Appendix> Anexos { get; set; }
        public DbSet<Bill> Facturas { get; set; }
    }

}
