using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

    public static class DependencyInjection
    {
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection
    /// </summary>
    /// <param name="IServiceCollection"></param>
    /// <param name=""></param>
    /// <returns></returns>
        public static IServiceCollection 
        AddInfrastructure(this IServiceCollection services)
    {
        // Todo add services to IOC container
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
    }

