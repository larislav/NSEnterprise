using Microsoft.Extensions.DependencyInjection;
using NSE.Cliente.API.Data;

namespace NSE.Cliente.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ClienteContext>();
        }
    }
}
