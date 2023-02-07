using Sales.Interface;
using Sales.Repository;

namespace Sales.API
{
    public class DependencyInjection
    {

        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependency(serviceProvider);
        }

        private static void RepositoryDependency(IServiceCollection serviceProvider)
        {

            serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
