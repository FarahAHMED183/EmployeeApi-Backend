using Microsoft.Extensions.DependencyInjection;

namespace Project.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddProblemDetails();

        return services;
    }
}
