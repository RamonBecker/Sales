using Microsoft.EntityFrameworkCore;
using Sales.Domain;


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

        // DBSet coleção de entidades em memória, que faz acesso ao BD
         public  DbSet<Cidade> Cidades { get; set; }
         public  DbSet<Cliente> Clientes { get; set; }
         public  DbSet<Produto> Produtos { get; set; }
         public  DbSet<Pedido> Pedidos { get; set; }
         public  DbSet<Combo> Combos { get; set; }
         public  DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
         public  DbSet<CategoriaProduto> CategoriasProdutos { get; set; }

        public ApplicationDBContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
    }
}
