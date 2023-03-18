using System.Reflection;
using Poira.Application;
using Poira.Application.Common.Mappings;
using Poira.Application.Interfaces;
using Poira.Persistence;

namespace Poira.WebApi.Extensions;

public static class ServiceMiddlewareExtension
{
    public static WebApplicationBuilder RegisterServiceMiddlewares(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IFridgeRepository).Assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(IFridgeModelRepository).Assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(IProductRepository).Assembly));
        });

        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration);
        
        return builder;
    }
    
    public static WebApplication InitializeServiceContextProvider(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var shedulerDbContext = serviceProvider.GetRequiredService<PoiraDbContext>();
            DbInitializer.Initialize(shedulerDbContext);
        }
        catch (Exception ex)
        {
            //
        }

        return app;
    }
}