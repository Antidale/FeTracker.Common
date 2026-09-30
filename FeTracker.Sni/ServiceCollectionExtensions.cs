using FeTracker.Sni.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FeTracker.Sni;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddSniServices()
        {
            services.TryAddScoped<DeviceService>();
            return services;
        }

    }
}
