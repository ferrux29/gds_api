using ApiGDS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiGDS.Infraestructure.DbCtx
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        { 
            
        }
        public DbSet<Client> Clientes => Set<Client>();
        public DbSet<Contrato> Contratos => Set<Contrato>();
    }
}
