using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catstagram.Server.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnection(this IConfiguration config)
            => config.GetConnectionString("DefaultConnection");
    }
}
