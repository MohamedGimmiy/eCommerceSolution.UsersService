using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add Core services to the dependency injection
    /// </summary>
    /// <param name="IServiceCollection"></param>
    /// <param name=""></param>
    /// <returns></returns>
    public static IServiceCollection
    AddCore(this IServiceCollection services)
    {
        // Todo add services to IOC container
        services.AddTransient<IUsersService, UsersService>();

        //add validators all just add one and automatically all is added
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}

