
namespace Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();

        services.AddCommandHandlers(Assembly.GetExecutingAssembly());
        services.AddQueryHandlers(Assembly.GetExecutingAssembly());
        services.AddEventHandlers(Assembly.GetExecutingAssembly());

        return services;
    }


    private static IServiceCollection AddCommandHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));

            services.AddScoped(interfaceType, handlerType);
        }

        return services;
    }

    private static IServiceCollection AddQueryHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));

            services.AddScoped(interfaceType, handlerType);
        }

        return services;
    }

    private static IServiceCollection AddEventHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(IEventHandler<>));

            services.AddScoped(interfaceType, handlerType);
        }

        return services;
    }
}
