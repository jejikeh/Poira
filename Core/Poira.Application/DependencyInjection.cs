using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Poira.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return serviceCollection;
    }
}