using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddDbPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddDbPersistence(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<ExampleDbContext>(x => x.UseSqlite(configuration.GetConnectionString("ExampleDbConnection")));

        return services;
    }
}
