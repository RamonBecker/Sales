namespace Sales.API
{
    public class DependencyInjection
    {

        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependency(serviceProvider);
        }

        private static void RepositoryDependency(IServiceCollection services)
        {
        }
    }
}
