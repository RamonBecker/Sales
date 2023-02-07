using Sales.Repository;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.Common;

namespace Sales.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Setando a ConnectionString do banco
        public DbConnection DbConnection => new NpgsqlConnection(Configuration.GetConnectionString("App"));
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {

            //Assembly = indicando onde será carregado as informações
            services.AddDbContext<ApplicationDBContext> (options =>
            {

                options.UseNpgsql(DbConnection, assembly => assembly.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName));
            });

                DependencyInjection.Register(services);
            
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                ;
        }
    }
}
