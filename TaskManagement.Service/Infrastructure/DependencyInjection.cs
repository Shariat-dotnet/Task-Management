using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace TaskManagement.Service.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMediaR(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
