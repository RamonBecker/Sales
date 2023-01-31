using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository
{
    public class ApplicationDBContext : DbContext
    {
        // Executa: Cria o model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chamada da carga de mapeamento no assembly
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            // GetType = ApplicationDBContext 
        }

        public ApplicationDBContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
