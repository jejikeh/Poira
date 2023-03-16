using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poira.Application.Interfaces;
using Poira.Persistence.Repositories;

namespace Poira.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PoiraDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("PoiraDbConnection")));

        serviceCollection.AddScoped<IFridgeRepository, FridgeRepository>();
        serviceCollection.AddScoped<IFridgeModelRepository, FridgeModelRepository>();
        return serviceCollection;
    }
}